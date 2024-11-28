using AsyncApi.Data;
using AsyncApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite("Data Source=RequestDB.db"));

var app = builder.Build();

app.UseHttpsRedirection();

// Start Endpoint
app.MapPost("/api/v1/products", async (AppDbContext context, ListingRequest listingRequest) => {
    
    if (listingRequest == null) return Results.BadRequest();

    listingRequest.RequestStatus = "In progress";
    listingRequest.EstimatedCompletionTime = "2024-11-26:14:00:00"; // some method to get estimated completion time

    await context.ListingRequests.AddAsync(listingRequest);
    await context.SaveChangesAsync();

    return Results.Accepted($"api/v1/productstatus/{listingRequest.RequestId}", listingRequest);
});

app.Run();

