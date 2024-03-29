﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewOrderPositionViewModel : AddRowViewModel<OrdersPositions>, IDataErrorInfo
    {
        #region Properties

        public string Title
        {
            get
            {
                return Item.Title;
            }
            set
            {
                if (value != Item.Title)
                {
                    Item.Title = value;
                    OnPropertyChanged(() => Title);
                }
            }
        }
        public int? ProductId
        {
            get
            {
                return Item.ProductId;
            }
            set
            {
                if (value != Item.ProductId)
                {
                    Item.ProductId = value;
                    OnPropertyChanged(() => ProductId);
                }
            }
        }
        public int? OrderId
        {
            get
            {
                return Item.OrderId;
            }
            set
            {
                if (value != Item.OrderId)
                {
                    Item.OrderId = value;
                    OnPropertyChanged(() => OrderId);
                }
            }
        }
        public decimal Price
        {
            get
            {
                return Item.Price;
            }
            set
            {
                if (value != Item.Price)
                {
                    Item.Price = value;
                    OnPropertyChanged(() => Price);
                }
            }
        }
        public decimal Quantity
        {
            get
            {
                return Item.Quantity;
            }
            set
            {
                if (value != Item.Quantity)
                {
                    Item.Quantity = value;
                    OnPropertyChanged(() => Quantity);
                }
            }
        }
        public List<ComboBoxKeyAndValue> ProductsList { get; set; }
        public string OrderDetails { get; set; }
        #endregion

        #region Constructor

        public NewOrderPositionViewModel()
            : base("OrderPositions")
        {
            Item = new OrdersPositions()
            {
                IsActive = true,
                Notes = "My notes"
            };
            ProductsList = Db.Products.Where(item => item.IsActive == true).Select(item => new ComboBoxKeyAndValue()
            {
                Key = item.Id,
                Value = item.ProductName
            }).ToList();
            Messenger.Default.Register<Orders>(this, GetOrder);
        }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Price):
                        return DecimalValidator.IsNotNegative(Price);
                    case nameof(Quantity):
                        return DecimalValidator.IsNotNegative(Quantity);
                    case nameof(Title):
                        return StringValidator.IsLenghtCorrect(Title, 255);
                    default:
                        return string.Empty;
                }
            }
        }

        #endregion

        #region Methods
        protected override bool IsValid()
        {
            return this[nameof(Price)] == string.Empty
                && this[nameof(Quantity)] == string.Empty
                && this[nameof(Title)] == string.Empty;
        }
        private void GetOrder(Orders item)
        {
            OrderDetails = $"Order ID: {item.Id}, Creation Date: {item.CreationDate}, Price Paid: {item.PricePaid}.";
            OrderId = item.Id;
        }

        public override void Save()
        {
            try
            {
                Db.OrdersPositions.AddObject(Item);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
