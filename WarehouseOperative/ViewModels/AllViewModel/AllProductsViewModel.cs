using System;
using System.Collections.Generic;
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
                AllList = (
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
                    }).ToList();
                List = new ObservableCollection<ProductsForAllView>(AllList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        protected override List<string> GetSearchComboBoxItems()
        {
            return new List<string>()
            {
                "Product Name",
                "Product Code"
            };
        }

        protected override List<string> GetSortComboBoxItems()
        {
            return new List<string>()
            {
                "Product Name",
                "Product Code",
                "Actual Quantity",
                "Actual Price"
            };
        }

        protected override void Search()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("Search box is empty!", "Status");
                return;
            }
            switch (SearchField)
            {
                case "Product Name":
                    List = new ObservableCollection<ProductsForAllView>(AllList.Where(item => item.ProductName.ToLower().Trim() == SearchText));
                    break;
                case "Product Code":
                    List = new ObservableCollection<ProductsForAllView>(AllList.Where(item => item.ProductCode.ToString().Trim() == SearchText));
                    break;
            }
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Product Name":
                    List = new ObservableCollection<ProductsForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.ProductName) :
                        List.OrderBy(item => item.ProductName));
                    break;
                case "Product Code":
                    List = new ObservableCollection<ProductsForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.ProductCode) :
                        List.OrderBy(item => item.ProductCode));
                    break;
                case "Actual Quantity":
                    List = new ObservableCollection<ProductsForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.ActualQuantity) :
                        List.OrderBy(item => item.ActualQuantity));
                    break;
                case "Actual Price":
                    List = new ObservableCollection<ProductsForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.ActualPrice) :
                        List.OrderBy(item => item.ActualPrice));
                    break;
            }
        }
        #endregion
    }
}
