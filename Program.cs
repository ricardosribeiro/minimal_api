using System.Data.Common;
using Microsoft.OpenApi.Models;
using MinimalApiPizza;

#region API Configuration
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "V1",
        Title="Minimal API Pizza",
        Description="An .Net Minimal API"
    });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

#endregion

#region Routes

app.MapGet("/pizzas", ()=>PizzaDb.GetPizzas());
app.MapGet("/pizza/{id}", (int id)=>PizzaDb.GetPizza(id));
app.MapPost("/pizza",(Pizza pizza)=>PizzaDb.CreatePizza(pizza));
app.MapPut("/pizza", (Pizza pizza)=>PizzaDb.UpdatePizza(pizza));
app.MapDelete("/pizza/{id}",(int id)=>PizzaDb.RemovePizza(id));

#endregion
app.Run();
