using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Data
{
    public class SqlRepository : IRepository
    {
        public void AddDataModel(GeneratedDataModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Data.Add(model);
                db.SaveChanges();
            }
        }
    }
}
