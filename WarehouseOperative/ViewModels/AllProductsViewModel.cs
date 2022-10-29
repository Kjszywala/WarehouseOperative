using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseOperative.ViewModels
{
    public class AllProductsViewModel : WorkspaceViewModel
    {
        #region Constructor
        public AllProductsViewModel()
        {
            //set the bookmark name here
            base.DisplayName = "Products";
        }
        #endregion
    }
}
