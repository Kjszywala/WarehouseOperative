using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewProductsLogViewModel : AddRowViewModel<ProductLogs>
    {
        #region Properties
        public DateTime LogsDate
        {
            get
            {
                return Item.LogsDate;
            }
            set
            {
                if (value != Item.LogsDate)
                {
                    Item.LogsDate = value;
                    OnPropertyChanged(() => LogsDate);
                }
            }
        }
        public string ProductLogDescription
        {
            get
            {
                return Item.ProductLogDescrition;
            }
            set
            {
                if (value != Item.ProductLogDescrition)
                {
                    Item.ProductLogDescrition = value;
                    OnPropertyChanged(() => ProductLogDescription);
                }
            }
        }
        public decimal OldPrice
        {
            get
            {
                return Item.OldPrice;
            }
            set
            {
                if (value != Item.OldPrice)
                {
                    Item.OldPrice = value;
                    OnPropertyChanged(() => OldPrice);
                }
            }
        }
        public decimal NewPrice
        {
            get
            {
                return Item.NewPrice;
            }
            set
            {
                if (value != Item.NewPrice)
                {
                    Item.NewPrice = value;
                    OnPropertyChanged(() => NewPrice);
                }
            }
        }
       
        #endregion

        #region Constructor
        public NewProductsLogViewModel()
          : base("ProductLog")
        {
            Item = new ProductLogs()
            {
                LogsDate = DateTime.Now
            };
        }
        #endregion

        #region Methods
       
        /// <summary>
        /// Save item to db.
        /// </summary>
        public override void Save()
        {
            try
            {
                Db.ProductLogs.AddObject(Item);
                Db.SaveChanges();
                Messenger.Default.Send(Item);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
