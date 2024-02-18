using Microsoft.AspNetCore.Localization;
using MilesCarRentalApi.DbConnection;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//ConfigurationRegistrar un servicio
builder.Services.AddServices(builder.Configuration);

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder => builder
           .AllowAnyOrigin()
           //.WithOrigins("https://localhost:4200", "http://localhost:4200")
           .AllowAnyMethod()
           //.AllowCredentials()           
           .AllowAnyHeader());
});

// Configure RequestLocalizationOptions
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("es-ES"); // Configura la cultura predeterminada en "es-ES"
    options.SupportedCultures = new[] { new CultureInfo("es-ES") }; // Configura solo la cultura "es-ES" como admitida
    options.SupportedUICultures = options.SupportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
