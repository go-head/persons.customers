using Newtonsoft.Json;
using Persons.Customers.Api.Extensions;
using Persons.Customers.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add config to the container.
builder.Configuration.AddCustomJsonConfigFiles(builder);
builder.Configuration.AddCustomSettings(builder);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureContainer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();