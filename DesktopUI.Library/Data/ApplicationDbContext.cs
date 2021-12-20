using DesktopUI.Library.Models;
using System.Data.Entity;

namespace DesktopUI.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("UVS Data")
        {

        }

        public DbSet<GeneratedDataModel> Data { get; set; }
    }
}
