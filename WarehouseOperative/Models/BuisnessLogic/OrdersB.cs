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
            try
            {
                var profit = Db.Orders.Where(item =>
                    item.CreationDate >= DateFrom &&
                    item.CreationDate <= DateTo)
                    .Sum(item => (item.PricePaid));

                return profit;
            }
            catch
            {
                return 0;
            }
        }

        public decimal ItemsSold()
        {
            try
            {
                var profit = Db.OrdersPositions.Where(item =>
                    item.Products.CreationDate >= DateFrom &&
                    item.Products.CreationDate <= DateTo)
                    .Sum(item => item.Quantity);

                return profit;
            }
            catch
            {
                return 0;
            }
        }

        public DateTime MostItemsSold()
        {
            try
            {
                var orders = from item in Db.OrdersPositions
                             join item2 in Db.Orders on item.Id equals item2.Id
                             select item;

                var date = orders.OrderByDescending(item => item.Quantity).ToList();
                var highestDate = date.FirstOrDefault();

                return highestDate.Products.CreationDate;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        #endregion

    }
}
