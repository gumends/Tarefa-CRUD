using UsuarioApi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TarefaContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// Adicionar suporte a controllers
builder.Services.AddControllers();

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
