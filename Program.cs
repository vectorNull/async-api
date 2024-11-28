using AsyncApi.Data;
using AsyncApi.Dtos;
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

// Status Endpoint
app.MapGet("api/v1/productstatus/{requestId}", (AppDbContext context, string requestId) => {

    var listingRequest = context.ListingRequests.FirstOrDefault(lr => lr.RequestId == requestId);

    if (listingRequest is null) return Results.NotFound();

    ListingStatus listingStatus = new ListingStatus
    {
        RequestStatus = listingRequest.RequestStatus,
        ResourceUrl = string.Empty
    };

    if (listingRequest.RequestStatus!.ToUpper() == "COMPLETE")
    {
        listingStatus.ResourceUrl = $"api/v1/products/{Guid.NewGuid().ToString()}";
        return Results.Ok(listingStatus);
    }

    listingStatus.EstimatedCompletionTime = "2024-11-26:14:11:11";

    return Results.Ok(listingStatus);
});

app.Run();

