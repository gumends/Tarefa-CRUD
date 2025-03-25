using Tarefa_CRUD.Context;
using Microsoft.EntityFrameworkCore;
using Tarefa_CRUD.Services;

// Configurar a aplicação
var builder = WebApplication.CreateBuilder(args);

// Configurar o banco de dados
builder.Services.AddDbContext<TarefaContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// Adicionar suporte a controllers
builder.Services.AddControllers();

// Registra o serviço TarefaServices
builder.Services.AddScoped<TarefaServices>();

// Configurar Swagger (documentação)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar o roteamento de controllers
app.UseAuthorization();
app.MapControllers(); // <- Adiciona suporte aos controllers

app.Run();
