namespace WarehouseOperative.Models.EntitiesForView
{
    public class SuppliersForAllView
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string SuplierAddressStreetName { get; set; }
        public string SuplierAddressPostcode { get; set; }
        public string SuplierAddressCity { get; set; }
        public string SuplierAddressCountry { get; set; }
        public string SuplierAddressPhone { get; set; }
        public string SuplierAddressFax { get; set; }
        public string SupplierAddressHomePage { get; set; }
        public bool IsActive { get; set; }
    }
}
