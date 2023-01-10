using System;
using System.Linq;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.Models.BuisnessLogic
{
    public class CustomersB : DatabaseClass
    {
        #region Properties

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        #endregion

        #region Constructor

        public CustomersB(KjsCompany2Entities2 db) : base(db)
        {
        }

        #endregion

        #region Methods

        public int GetCustomersAmount()
        {
            try
            {
                return Db.Customers.Where(item => 
                    item.CreationDate >= DateFrom &&
                    item.CreationDate <= DateTo)
                    .Count();
            }
            catch
            {
                return 0;
            }
        }

        public string GetMostPayCustomer()
        {
            var b = (from item in Db.Orders
                        join item2 in Db.Customers on item.CustmerId equals item2.Id
                        where item.CreationDate >= DateFrom && item.CreationDate <= DateTo
                        select item).ToList().OrderByDescending(item => item.PricePaid).FirstOrDefault();

            if(b == null)
            {
                return "None";
            }

            return b.Customers.FirstName + " " + b.Customers.SecondName;
            
        } 

        public string GetFirstCustomer()
        {
            var b = Db.Customers.OrderBy(item => item.Id).FirstOrDefault();

            return b.FirstName + " " + b.SecondName;
        }

        public string GetLastCustomer()
        {
            var b = Db.Customers.OrderByDescending(item => item.Id).FirstOrDefault();

            return b.FirstName + " " + b.SecondName;
        }

        #endregion
    }
}
