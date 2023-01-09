using System;
using System.Linq;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.Models.BuisnessLogic
{
    public class ProductsB : DatabaseClass
    {
        #region Constructor

        public ProductsB(KjsCompany2Entities2 db) : base(db)
        {
        }

        #endregion

        #region Methods

        public decimal GetAllProductAmount()
        {
            try
            {
                var p = Db.Products.Sum(item => item.ActualQuantity);
                return p;
            }
            catch
            {
                return 0;
            }
        }
        public decimal GetMostExpensiveProduct()
        {
            try
            {
                var p = Db.Products.OrderByDescending(item => item.ActualPrice).FirstOrDefault();
                return p.ActualPrice;
            }
            catch
            {
                return 0;
            }
        }
        public decimal GetBestDiscount()
        {
            try
            {
                var p = Db.Products.OrderByDescending(item => item.Discount).FirstOrDefault();
                return p.Discount;
            }
            catch
            {
                return 0;
            }
        }
        public decimal GetStoreTheMost()
        {
            try
            {
                var p = Db.Products.OrderByDescending(item => item.ActualQuantity).FirstOrDefault();
                return p.ActualQuantity;
            }
            catch
            {
                return 0;
            }
        }
        public string GetBestSeller()
        {
            try
            {
                var p = Db.OrdersPositions.GroupBy(w => w.Products.ProductName).OrderByDescending(g => g.Count()).First().Key;
                return p;
            }
            catch
            {
                return "Not Choosen";
            }
        }
        public DateTime GetLatestAdded()
        {
            try
            {
                var p = Db.Products.OrderByDescending(item => item.CreationDate).FirstOrDefault();
                return p.CreationDate;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        #endregion
    }
}
