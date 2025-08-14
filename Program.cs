using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/GetNBA", ([FromBody] NbaRequest? request) =>
{
    var id = request?.Id;
    NbaResponse response = null;
    if (id == "990e1b60-f262-4b74-a949-8abe7f519929") { response = new NbaResponse(id, "auto"); }
    else response = new NbaResponse(id, GenerateRandomNBAResult());
    return Results.Ok(response);

    // generate local function to return empty string
    string GenerateRandomNBAResult()
{
    var results = new[] { "auto", "reis", "hypotheek", "aanhanger", "duikboot" };
    var random = new Random();
    return results[random.Next(results.Length)];
}

})();

app.Run();

public record NbaRequest(string? Id);
public record NbaResponse(string? Id, string NBA);

// generate function which returns one of the following:
// auto, reis, hypotheek, aanhanger, duikboot
