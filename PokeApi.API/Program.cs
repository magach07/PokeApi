using Microsoft.AspNetCore.Mvc;
using PokeApi.Application.Commands.PokeAPIContext;
using PokeApi.Application.Interfaces;
using PokeApi.Application.Receivers;
using PokeApi.Infrastructure.Factory;
using PokeApi.Infrastructure.Repositories;
using PokeApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

//Injeções de Dependências
builder.Services.AddScoped<SQLiteFactory>();
builder.Services.AddTransient<IPokeRepository, PokeRepository>();
builder.Services.AddTransient<IPokeService, PokeService>();
builder.Services.AddTransient<IInsertRepository, InsertRepository>();
builder.Services.AddTransient<InsertReceiver>();

var app = builder.Build();

// Método GET para 10 Pokémon aleatórios.
app.MapGet("/PokeApi/Get10PokesRandom/", ([FromServices] IPokeRepository repository) =>
{
    return repository.Get10PokesRange();
});

// Método GET para 1 Pokémon específico.
app.MapGet("/PokeApi/GetPokemon/", ([FromServices] IPokeRepository repository, string pokemon) =>
{
    return repository.GetPokemon(pokemon);
});

// Método GET para listar Pokémons capturados.
app.MapGet("/PokeApi/GetPokesCapturados/", ([FromServices] IPokeRepository repository) =>
{
    return repository.GetPokemonsCapturados();
});

// Método POST para cadastro de Mestre Pokémon.
app.MapPost("/PokeApi/PostMestrePokemon/", ([FromServices] InsertReceiver receiver, [FromBody]MestrePokemonCommand command) =>
{
    return receiver.ActionMestre(command);
});

// Método POST para cadasrtar Pokémon Capturado.
app.MapPost("/PokeApi/PostPokemonCapturado/", ([FromServices] InsertReceiver receiver, [FromBody]PokemonCapturadoCommand command) =>
{
    return receiver.ActionCaptura(command);
});

app.Run(); 