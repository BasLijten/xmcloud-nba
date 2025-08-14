using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/GetNBA", ([FromBody] NbaRequest? request) =>
{
    var id = request?.Id;
    NbaResponse response = null;
    var choices = new[] { "reis", "auto", "aanhanger", "duikboot", "hypotheek" };
    var nba = choices[System.Random.Shared.Next(choices.Length)];
    if (id == "bas") { response = new NbaResponse(id, "auto"); }
    else { response = new NbaResponse(id, nba); }
    return Results.Ok(response);
});

app.Run();

public record NbaRequest(string? Id);
public record NbaResponse(string? Id, string NBA);
