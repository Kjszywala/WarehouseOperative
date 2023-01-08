using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewInvoiceViewModel : AddRowViewModel<Invoices>
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
        public string InvoiceNumber
        {
            get
            {
                return Item.InvoiceNumber;
            }
            set
            {
                if (value != Item.InvoiceNumber)
                {
                    Item.InvoiceNumber = value;
                    OnPropertyChanged(() => InvoiceNumber);
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
        public int? PaymentMethodId
        {
            get
            {
                return Item.PaymentMethodId;
            }
            set
            {
                if (value != Item.PaymentMethodId)
                {
                    Item.PaymentMethodId = value;
                    OnPropertyChanged(() => PaymentMethodId);
                }
            }
        }
        public bool IsConfirmed
        {
            get
            {
                return Item.IsConfirmed;
            }
            set
            {
                if (value != Item.IsConfirmed)
                {
                    Item.IsConfirmed = value;
                    OnPropertyChanged(() => IsConfirmed);
                }
            }
        }
        public List<ComboBoxKeyAndValue> PaymentMethodsList { get; set; }
        public string OrderDetails { get; set; }

        #endregion

        #region Constructior
        public NewInvoiceViewModel()
            :base("Invoices")
        {
            Item = new Invoices()
            {
                IsActive = true,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                Notes = "New invoice"
            };
            PaymentMethodsList = Db.PaymentMethods.Where(item => item.IsActive == true).Select(item => new ComboBoxKeyAndValue()
            {
                Key = item.Id,
                Value = item.Title
            }).ToList();
            Messenger.Default.Register<Orders>(this, GetInvoice);
        }
        #endregion

        #region Methods

        private void GetInvoice(Orders item)
        {
            OrderDetails = $"Order Id: {item.Id}, Creation Date: {item.AddDate}, Price Paid: {item.PricePaid}";
            OrderId = item.Id;
        }
        public override void Save()
        {
            try
            {
                Db.Invoices.AddObject(Item);
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
