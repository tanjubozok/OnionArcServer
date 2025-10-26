using OnionArc.API.Extentions;
using OnionArc.Application.Extensions;
using OnionArc.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddOpenApi();



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGroup("/api")
   .RegisterEndpoints();

app.Run();
