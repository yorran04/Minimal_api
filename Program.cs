using minimal_api.Dominio.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) => {
    if(loginDTO.Emial == "adm@teste.com" && loginDTO.Password == "1234")
         return Results.Ok("Login realizado com sucesso");
    else
        return Results.Unauthorized();
});

app.Run();


