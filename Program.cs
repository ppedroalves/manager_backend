using Manager.Data;
using Manager.Integracoes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>();
builder.Services.AddSingleton<ApiCnpj>();
var app = builder.Build();

app.MapControllers();

app.Run();
