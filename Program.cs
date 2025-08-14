using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/GetNBA", ([FromBody] NbaRequest? request) =>
{
    var id = request?.Id;
    var nba = new NbaResponse(id);
    if (id == "bas") { nba.NBA = "auto"; }
    if (id == "stefan") { nba.NBA = "reis"; }
    return Results.Ok(nba);
});

app.Run();

public record NbaRequest(string? Id);
public record NbaResponse(string? Id, string NBA);
