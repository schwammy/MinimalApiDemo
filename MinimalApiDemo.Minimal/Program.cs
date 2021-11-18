using Microsoft.AspNetCore.Authorization;
using MinimalApiDemo.Minimal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDataService, DataService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/customer/{custId}/order/{orderId}", [Authorize](int custId, int orderId) => 
$"customer: {custId}, order: {orderId}");

app.MapGet("/querystring/", (int custId, int orderId) => $"customer: {custId}, order: {orderId}");


app.MapPost("/User", (User u) => $"username: {u.UserName}, password: {u.Password}");


app.MapGet("/async", async () => await Task.FromResult("this was async"));

app.MapGet("/customer", (int custId) =>
{
    if (custId == 0)
    {
        return Results.BadRequest();
    }

    if (custId == 1)
    {
        return Results.NotFound();
    }
    return Results.Ok("foo");
});




app.Logger.LogInformation("The app started");


app.Run();



internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public User()
    {
        User2 user2 = new User2("andy", "password");
        var user3 = new User2("andy", "password");
        User2 user4 = new ("andy", "password");

        //pretend this works:
        User user5 = new() { UserName = "Andy", Password = "asfasdf"};


        UserName = "andy";
        Password = "password";
    }
}

public record User2(string UserName, string Password);


