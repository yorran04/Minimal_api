using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Dominio.ModelViews;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrurura.Db;
using minimal_api.Infraestrurura.Interfaces;

#region  Build

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministrador, AdmServico>();
builder.Services.AddScoped<IveiculoServico, VeiculoServico>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexaoPadrao")));

var app = builder.Build();

#endregion

# region Home
app.MapGet("/", () => Results.Json(new Home()));
#endregion

#region Administrador
app.MapPost("/administradores/login", ([FromBody] LoginDTO loginDTO, IAdministrador administradorServico) => {
    if(administradorServico.Login(loginDTO) != null)
         return Results.Ok("Login realizado com sucesso");
    else
        return Results.Unauthorized();
});
#endregion

#region Veiculos
app.MapPost("/veiculos", ([FromBody] VeiculoDTO veiculoDTO, IveiculoServico veiculoServico) => {
   
    var veiculo = new Veiculo{
        Name = veiculoDTO.Name,
        Marca = veiculoDTO.Marca,
        Ano = veiculoDTO.Ano,
    };

    veiculoServico.Incluir(veiculo);

    return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
   
});
#endregion

#region Api
app.UseSwagger();
app.UseSwaggerUI();


app.Run();

#endregion
