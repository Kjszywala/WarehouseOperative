using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class AllProductsViewModel : AllViewModel<ProductsForAllView>
    {
        #region Constructor
        public AllProductsViewModel()
            : base("Products")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            try
            {
                List = new ObservableCollection<ProductsForAllView>(
                    from products in WarehouseEntities.Products
                    where products.IsActive == true
                    select new ProductsForAllView
                    {
                        ProductName = products.ProductName,
                        ProductCode = products.ProductCode,
                        CategoryCategoryDescription = products.Categories.CategoryDescription,
                        SupplierCompanyName = products.Suppliers.CompanyName,
                        ProductLogsDescription = products.ProductLogs.ProductLogDescrition,
                        ActualQuantity = products.ActualQuantity,
                        ActualPrice = products.ActualPrice,
                        QuantityTypesQuantityType = products.QuantityTypes.title
                    }
                );
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
