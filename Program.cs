using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/GetNBA", ([FromBody] NbaRequest? request) =>
{
    var id = request?.Id;
    return Results.Ok(new NbaResponse(id, "nba"));
});

app.Run();

public record NbaRequest(string? Id);
public record NbaResponse(string? Id, string Value);
