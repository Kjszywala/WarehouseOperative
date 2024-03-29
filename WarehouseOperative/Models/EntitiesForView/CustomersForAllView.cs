﻿using System.Data.SqlTypes;

namespace WarehouseOperative.Models.EntitiesForView
{
    public class CustomersForAllView
    {
        public int CustomerId { get; set; }
        public string CreationDate { get; set; }
        public decimal ModificationDate { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
