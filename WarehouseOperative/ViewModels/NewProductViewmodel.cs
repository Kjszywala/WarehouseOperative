using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseOperative.ViewModels
{
    public class NewProductViewmodel : WorkspaceViewModel
    {
        #region Constructor
        public NewProductViewmodel()
        {
            //set the bookmark name here
            base.DisplayName = "Product";
        }
        #endregion
    }
}
