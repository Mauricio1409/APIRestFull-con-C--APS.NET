var builder = WebApplication.CreateBuilder(args);

// Agregar controladores
builder.Services.AddControllers();

// Configuración Swagger (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Mensaje en la consola
Console.WriteLine("La API está corriendo en: https://localhost:5001");
Console.WriteLine("Prueba los endpoints con herramientas como Postman o cURL.");

app.Run();
