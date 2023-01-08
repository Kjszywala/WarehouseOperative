using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;
using WarehouseOperative.ViewModels.AllViewModel;
using WarehouseOperative.Views.AllView;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewInvoiceViewModel : AddRowViewModel<Invoices>
    {
        #region Properties

        Window window = new Window();
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

        private string _OrderDetails;
        public string OrderDetails
        {
            get
            {
                return _OrderDetails;
            }
            set
            {
                if (value != _OrderDetails)
                {
                    _OrderDetails = value;
                    OnPropertyChanged(() => OrderDetails);
                    window.Close();
                }
            }
        }


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
            Messenger.Default.Register<OrdersForAllView>(this, GetOrder);
        }
        #endregion

        #region Commands

        private ICommand _ChooseOrderCommand;
        public ICommand ChooseOrderCommand
        {
            get
            {
                if (_ChooseOrderCommand == null)
                {
                    _ChooseOrderCommand = new BaseCommand(() => ChooseOrder());
                }
                return _ChooseOrderCommand;
            }
        }

        #endregion

        #region Methods

        private void GetOrder(OrdersForAllView item)
        {
            OrderDetails = $"Order Id: {item.OrderId}, Creation Date: {item.CreationDate}, Price Paid: {item.PricePaid}";
            OrderId = item.OrderId;
        }

        private void ChooseOrder()
        {
            
            AllOrdersView allOrdersView = new AllOrdersView();
            allOrdersView.DataContext = new AllOrdersViewModel();
            window.Content = allOrdersView;
            window.Background = System.Windows.Media.Brushes.DimGray;
            window.Width = 1000;
            window.Height = 500;
            window.Show();
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
