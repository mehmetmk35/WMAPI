using DepoYaz�l�mAPI.Application.Validators.StockCard;
using DepoYaz�l�mAPI.Infrastructure;
using DepoYaz�l�mAPI.Infrastructure.Filters.Validation;
using DepoYaz�l�mAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers(opt=>opt.Filters.Add<ValidationFilter>())//filter ekleme yap�yorz
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateStockCardRecordValidator>()) //bu i�lemde controller'a gelmeden �nce kontrol edip geri d�n�� verir taray�c� consola
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true); //bu i�lemde mevcur filterlar� devreye sokuyoruz ama bizim yazd���m�z filterlar�  controllera girmesini sa�l�yoruz

 
//cors hatas� i�in eklendi 
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
app.UseStaticFiles(); //wwwroot kullabilmek i�in
app.UseCors();
app.MapControllers();
app.Run();
