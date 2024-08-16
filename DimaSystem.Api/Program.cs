using DimaSystem.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString(name:"DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(cnnStr);
});

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
    pattern: "/v1/products",
    handler: (Request request, Handler handler) 
                => handler.handle(request))
    .WithName("Transaction Create")
    .WithSummary("Cria uma nova transação")
    .Produces<Response>();

app.Run();

//Request
public class Request
{
    public string Title { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; }

    public decimal Amount { get; set; }

    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
//Response
public class Response
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
//Handler
public class Handler
{
    public Response handle(Request request)
    {
        return new Response
        {
            Id = 1,
            Title = request.Title
        };

    }
}

