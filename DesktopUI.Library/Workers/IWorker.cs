using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Workers
{
    public interface IWorker
    {
        /// <summary>
        /// Does one unit of work
        /// </summary>
        void Work();
    }
}
