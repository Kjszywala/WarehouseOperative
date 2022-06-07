using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomisSamochodowy.ViewModels
{
    public class WszystkieTowaryViewModel : WorkspaceViewModel
    {
        #region Constructor
        public WszystkieTowaryViewModel()
        {
            //set the bookmark name here
            base.DisplayName = "Products";
        }
        #endregion
    }
}
