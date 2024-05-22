using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the Container

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
});


var app = builder.Build();
//Configure request pipelines

app.MapCarter();
app.Run();
