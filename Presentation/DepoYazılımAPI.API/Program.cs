using DepoYazýlýmAPI.Application;
using DepoYazýlýmAPI.Application.Validators.StockCard;
using DepoYazýlýmAPI.Infrastructure;
using DepoYazýlýmAPI.Infrastructure.Filters.Validation;
using DepoYazýlýmAPI.Infrastructure.Services.Storage.Local;
using DepoYazýlýmAPI.Persistence;
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
builder.Services.AddControllers(opt=>opt.Filters.Add<ValidationFilter>())//filter ekleme yapýyorz    //CreateStockCardRecordValidator startupda verilebilr kendisi bulucak ise 
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateStockCardRecordValidator>()) //bu iþlemde controller'a gelmeden önce kontrol edip geri dönüþ verir tarayýcý consola
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true); //bu iþlemde mevcur filterlarý devreye sokuyoruz ama bizim yazdýðýmýz filterlarý  controllera girmesini saðlýyoruz

//cors hatasý için eklendi 
builder.Services.AddCors(options=>
options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//jwt için ekleme yapýlþdý
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    { //token olarak bir doðrulama geliyor ise jwt olduðunu bil  bu jwt doðrularken alttaki alanlara göre doðrula
        options.TokenValidationParameters = new()
        {//token doðrulama 
            ValidateAudience = true,//oluþturulacak token kimlerin yada hangi siter kullanacak
            ValidateIssuer = true,//oluþacak tokený kimin daðatacaðýný belirliyoruz 
            ValidateLifetime = true,//oluþan tokenýn süresini kontrol eder 
            ValidateIssuerSigningKey = true,//üretecek token deðerin uygulamamýza ait olduðunu ifade eder 

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = ( notBefore, expires,securityToken, validationParameters) => expires!=null ? expires>DateTime.UtcNow:false
            ,NameClaimType=ClaimTypes.Name //jwt üzerinden Name Claime karþýlýk gelen deüeri user.identity.name proptan elde ederiz ve tokený üretiðimiz yerede ekliyotz
        };

    }

    );
//serilog'u devreye alýyoruz
// Kullanýcý adýný al

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
                // Diðer sütunlarý eklemeye devam edebilirsiniz, istemediðiniz sütunlarý çýkararak
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
// app.UseHttpLogging(); eklendi  yapýlan requestleri log ile takip ediyorz 
//serilog'u devreye alýyoruz 


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(); //wwwroot kullabilmek için
app.UseSerilogRequestLogging();//eklendiði satýrdan sonra loglamaya baþlar 
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
