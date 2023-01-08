using System;
using System.Linq;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.Models.BuisnessLogic
{
    public class OrdersB : DatabaseClass
    {
        #region Properties

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        #endregion

        #region Constructor

        public OrdersB(KjsCompany2Entities2 db) : base(db)
        {
        }

        #endregion

        #region Methods

        public decimal Profit()
        {
            var profit = Db.Orders.Where(item => 
                item.CreationDate >= DateFrom && 
                item.CreationDate <= DateTo)
                .Sum(item => (item.PricePaid));

            return profit;
        }

        #endregion

    }
}
