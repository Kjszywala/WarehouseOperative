using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseOperative.Models.EntitiesForView
{
    public class ProductsForAllView
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string CategoryCategoryDescription { get; set; }
        public string SupplierCompanyName { get; set; }
        public string ProductLogsDescription { get; set; }
        public decimal ActualQuantity { get; set; }
        public decimal ActualPrice { get; set; }
        public string QuantityTypesQuantityType { get; set; }
    }
}
