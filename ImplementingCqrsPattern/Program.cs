using ImplementingCqrsPattern;
using ImplementingCqrsPattern.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<Settings>();
builder.Services.AddDbContext<AppDbContext>((provider, opt) =>
{
    string? connectionString = provider.GetRequiredService<Settings>().ConnectionString;
    ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

    opt
    .UseSqlServer(connectionString)
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine);
});
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddMediatR(e =>
{
    e.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
