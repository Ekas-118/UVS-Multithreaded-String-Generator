using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Data
{
    public interface IRepository
    {
        void AddDataModel(GeneratedDataModel model);
    }
}
