using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddCarter();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviors<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddMarten(opts => { opts.Connection(builder.Configuration.GetConnectionString("Database")!); })
    .UseLightweightSessions();

var app = builder.Build();

//configure the Http request pipeline. 
app.MapCarter();

app.Run();