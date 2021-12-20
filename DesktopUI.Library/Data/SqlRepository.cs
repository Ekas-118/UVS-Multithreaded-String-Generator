using DesktopUI.Library.Models;

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
