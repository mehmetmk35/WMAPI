using DepoYazýlýmAPI.Application.Validators.StockCard;
using DepoYazýlýmAPI.Infrastructure;
using DepoYazýlýmAPI.Infrastructure.Filters.Validation;
using DepoYazýlýmAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers(opt=>opt.Filters.Add<ValidationFilter>())//filter ekleme yapýyorz
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateStockCardRecordValidator>()) //bu iþlemde controller'a gelmeden önce kontrol edip geri dönüþ verir tarayýcý consola
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true); //bu iþlemde mevcur filterlarý devreye sokuyoruz ama bizim yazdýðýmýz filterlarý  controllera girmesini saðlýyoruz

 
//cors hatasý için eklendi 
builder.Services.AddCors(options=>
options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles(); //wwwroot kullabilmek için
app.UseCors();
app.MapControllers();
app.Run();
