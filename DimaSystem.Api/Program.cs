var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//EndPoints -> URL para acesso 
//Convenções de Mercado
//https://localhost:0000/

app.MapGet("/products", () => "Hello World!");
app.MapGet("/products/{id}", () => "Hello World!");
app.MapGet("/products`/{id}/categories", () => "Hello World!");
app.MapGet("/products/{id}/categories/{cid}/sub-categories", () => "Hello World!");

app.MapPost("/categories", () => "Hello World!");
app.MapPut("/categories", () => "Hello World!");
app.MapDelete("/categories", () => "Hello World!");


app.Run();
