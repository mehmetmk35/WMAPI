using DepoYaz�l�mAPI.Application;
using DepoYaz�l�mAPI.Application.Validators.StockCard;
using DepoYaz�l�mAPI.Infrastructure;
using DepoYaz�l�mAPI.Infrastructure.Filters.Validation;
using DepoYaz�l�mAPI.Infrastructure.Services.Storage.Local;
using DepoYaz�l�mAPI.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddControllers(opt=>opt.Filters.Add<ValidationFilter>())//filter ekleme yap�yorz    //CreateStockCardRecordValidator startupda verilebilr kendisi bulucak ise 
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateStockCardRecordValidator>()) //bu i�lemde controller'a gelmeden �nce kontrol edip geri d�n�� verir taray�c� consola
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true); //bu i�lemde mevcur filterlar� devreye sokuyoruz ama bizim yazd���m�z filterlar�  controllera girmesini sa�l�yoruz

//cors hatas� i�in eklendi 
builder.Services.AddCors(options=>
options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//jwt i�in ekleme yap�l�d�
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    { //token olarak bir do�rulama geliyor ise jwt oldu�unu bil  bu jwt do�rularken alttaki alanlara g�re do�rula
        options.TokenValidationParameters = new()
        {//token do�rulama 
            ValidateAudience = true,//olu�turulacak token kimlerin yada hangi siter kullanacak
            ValidateIssuer = true,//olu�acak token� kimin da�ataca��n� belirliyoruz 
            ValidateLifetime = true,//olu�an token�n s�resini kontrol eder 
            ValidateIssuerSigningKey = true,//�retecek token de�erin uygulamam�za ait oldu�unu ifade eder 

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = ( notBefore, expires,securityToken, validationParameters) => expires!=null ? expires>DateTime.UtcNow:false
            ,NameClaimType=ClaimTypes.Name //jwt �zerinden Name Claime kar��l�k gelen de�eri user.identity.name proptan elde ederiz ve token� �reti�imiz yerede ekliyotz
        };

    }

    );
//serilog'u devreye al�yoruz
// Kullan�c� ad�n� al

Logger log = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("WMDB"), "logs", autoCreateSqlTable: true,
    columnOptions: new ColumnOptions
    {
        Store = new Collection<StandardColumn>
            {
                StandardColumn.Id,
                StandardColumn.MessageTemplate,
                StandardColumn.Level,
                StandardColumn.TimeStamp,
                StandardColumn.Exception,
                StandardColumn.LogEvent
                // Di�er s�tunlar� eklemeye devam edebilirsiniz, istemedi�iniz s�tunlar� ��kararak
            },
        AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn { ColumnName = "Username", DataType = SqlDbType.NVarChar, DataLength = 100 }
            }
    })
      
      .MinimumLevel.Information()
    .CreateLogger();
builder.Host.UseSerilog(log);
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");   
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});
// app.UseHttpLogging(); eklendi  yap�lan requestleri log ile takip ediyorz 
//serilog'u devreye al�yoruz 


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(); //wwwroot kullabilmek i�in
app.UseSerilogRequestLogging();//eklendi�i sat�rdan sonra loglamaya ba�lar 
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();//sonradan ekeldni jwt kontrol endpoint kontrol 
app.UseCors();
app.Use(async (context, next) => 
{
    var username =  context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("Username", username);
       await next(); 
});
app.MapControllers();
app.Run();
