using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
