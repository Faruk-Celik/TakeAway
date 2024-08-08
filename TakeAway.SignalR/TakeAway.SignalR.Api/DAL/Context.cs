using Microsoft.EntityFrameworkCore;

namespace TakeAway.SignalR.Api.DAL
{
    public class Context :DbContext
    {
        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6VB768D\\SQLEXPRESS02; initial catalog=TakeAwaySignalRDb; integrated Security=true; TrustServerCertificate=true;");
        }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}
