using Duvido.GestãoDeGame.WEB_API.Data;
using Duvido.GestãoDeGame.WEB_API.Repositorio;
using Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conexao = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<AppDbContext>(opcoes =>
{
    opcoes.UseMySql(conexao, ServerVersion.Parse("10.4.28-MariaDB"));
});

builder.Services.AddScoped<IListaRepositorio, ListaRepositorio>();
builder.Services.AddScoped<IItensDaListaRepositorio, ItensDaListaRepositorio>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuarioRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
