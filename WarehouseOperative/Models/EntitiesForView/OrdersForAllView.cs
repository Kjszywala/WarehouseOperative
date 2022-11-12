using System;

namespace WarehouseOperative.Models.EntitiesForView
{
    public class OrdersForAllView
    {
        public int OrderId { get; set; }
        public string CustomersCustomerName { get; set; }
        public string ProductsProductName { get; set; }
        public int OrderQuantity { get; set; }
        public decimal ProductsUnitPrice { get; set; }
        public decimal CustomersPricePaid { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShippersShipperCompanyName { get; set; }
        public string SuppliersCompanyName { get; set; }
        public string CategoriesDescription { get; set; }
        public DateTime LastChangedDateTime { get; set; }
    }
}
