using System;

namespace WarehouseOperative.Models.EntitiesForView
{
    public class OrdersForAllView
    {
        public int OrderId { get; set; }
        public string CustomersCustomerName { get; set; }
        public string ProductsProductName { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal ProductsUnitPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public string ShipperName { get; set; }
        public string EmployeeName { get; set; }
        public decimal PricePaid { get; set; }
    }
}
