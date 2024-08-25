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

//Request
public class Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
//Response
public class Response
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
//Handler
public class Handler(AppDbContext context)
{
    public Response handle(Request request)
    {
        var category = new Category
        {
            Title = request.Title,
            Description = request.Description
        };

        context.Categories.Add(category);
        context.SaveChanges();

        return new Response
        {
            Id = category.Id,
            Title = category.Title
        };

    }
}

