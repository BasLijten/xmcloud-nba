using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/GetNBA", ([FromBody] NbaRequest? request) =>
{
    var id = request?.Id;
    NbaResponse response = null;
    if (id == "990e1b60-f262-4b74-a949-8abe7f519929") { response = new NbaResponse(id, "auto"); }
    if (id == "stefan") { response = new NbaResponse(id, "reis"); }
    return Results.Ok(response);
});

app.Run();

public record NbaRequest(string? Id);
public record NbaResponse(string? Id, string NBA);
