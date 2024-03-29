﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewProductsLogViewModel : AddRowViewModel<ProductLogs>, IDataErrorInfo
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
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ProductLogDescription):
                        return StringValidator.IsLenghtCorrect(ProductLogDescription, 255);
                    case nameof(OldPrice):
                        return DecimalValidator.IsNotNegative(OldPrice);
                    case nameof(NewPrice):
                        return DecimalValidator.IsNotNegative(NewPrice);
                    default:
                        return string.Empty;
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
        protected override bool IsValid()
        {
            return this[nameof(ProductLogDescription)] == string.Empty
                && this[nameof(OldPrice)] == string.Empty
                && this[nameof(NewPrice)] == string.Empty;
        }

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
