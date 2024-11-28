using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });

    #region Other Rate limiter Options

    // rateLimiterOptions.AddSlidingWindowLimiter("SlidingWindow", options =>
    // {
    //     options.Window = TimeSpan.FromSeconds(10);
    //     options.SegmentsPerWindow = 5;
    // });
    
    //      rateLimiterOptions.AddTokenBucketLimiter("Bucket", options =>
    //  {
    //      options.QueueLimit =11;
    //      options.TokenLimit = 5;
    //  });
    
    // rateLimiterOptions.AddConcurrencyLimiter("Concurrency", options =>
    // {
    //     options.PermitLimit = 12;
    //     options.PermitLimit = 5;
    // });

    #endregion
});


builder.Services.AddRateLimiter(rateLimiterOptions => { });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRateLimiter();

app.MapReverseProxy();

app.Run();