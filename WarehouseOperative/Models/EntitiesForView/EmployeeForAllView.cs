using System;

namespace WarehouseOperative.Models.EntitiesForView
{
    public class EmployeeForAllView
    {
        #region Properties
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }
        public string EmployeeAddress { get; set; }
        public int? EmployeeAnualLeaveDaysLeft { get; set; }
        #endregion
    }
}
