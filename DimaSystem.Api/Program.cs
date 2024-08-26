using DimaSystem.Api.Data;
using DimaSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Connection Db
var cnnStr = builder.Configuration.GetConnectionString(name:"DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(cnnStr);
});
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddTransient<Handler>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



//EndPoints -> URL para acesso 
//Convenções de Mercado
//https://localhost:0000/
//Usar versionamento

    app.MapPost(
        pattern: "/v1/categories",
        handler: (Request request, Handler handler) 
                    => handler.handle(request))
        .WithName("Category Create")
        .WithSummary("Cria uma nova categoria")
        .Produces<Response>();

    app.Run();

}

