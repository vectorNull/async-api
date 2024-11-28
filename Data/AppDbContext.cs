using AsyncApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        DbSet<ListingRequest> ListingRequests => Set<ListingRequest>();
    }
}