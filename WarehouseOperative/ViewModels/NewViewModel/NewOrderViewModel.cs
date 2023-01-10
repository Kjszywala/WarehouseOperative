using GalaSoft.MvvmLight.Messaging;
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
    public class NewOrderViewModel : AddRowViewModel<Orders>, IDataErrorInfo
    {
        #region Properties
        public int? CustomerId
        {
            get
            {
                return Item.CustmerId;
            }
            set
            {
                if (value != Item.CustmerId)
                {
                    Item.CustmerId = value;
                    OnPropertyChanged(() => CustomerId);
                }
            }
        }
        public int? ShipperId
        {
            get
            {
                return Item.ShipperId;
            }
            set
            {
                if (value != Item.ShipperId)
                {
                    Item.ShipperId = value;
                    OnPropertyChanged(() => ShipperId);
                }
            }
        }
        public int? EmployeeId
        {
            get
            {
                return Item.EmployeeId;
            }
            set
            {
                if (value != Item.EmployeeId)
                {
                    Item.EmployeeId = value;
                    OnPropertyChanged(() => EmployeeId);
                }
            }
        }
        public DateTime AddDate
        {
            get
            {
                return Item.AddDate;
            }
            set
            {
                if (value != Item.AddDate)
                {
                    Item.AddDate = value;
                    OnPropertyChanged(() => AddDate);
                }
            }
        }
        public decimal PricePaid
        {
            get
            {
                return Item.PricePaid;
            }
            set
            {
                if (value != Item.PricePaid)
                {
                    Item.PricePaid = value;
                    OnPropertyChanged(() => PricePaid);
                }
            }
        }
        public decimal Discount
        {
            get
            {
                return Item.Discount;
            }
            set
            {
                if (value != Item.Discount)
                {
                    Item.Discount = value;
                    OnPropertyChanged(() => Discount);
                }
            }
        }
        public List<ComboBoxKeyAndValue> EmployeesList { get; set; }
        public List<ComboBoxKeyAndValue> ShippersList { get; set; }
        public string CustomerDetails { get; set; }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(PricePaid):
                        return DecimalValidator.IsNotNegative(PricePaid);
                    case nameof(Discount):
                        return DecimalValidator.IsNotNegative(Discount);
                    default:
                        return string.Empty;
                }
            }
        }

        #endregion

        #region Constructor

        public NewOrderViewModel()
            :base("Orders")
        {
            Item = new Orders()
            {
                IsActive = true,
                Notes = "New Order",
                Title = "Order",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                AddDate = DateTime.Now
            };
            EmployeesList = Db.Employees.Where(item => item.IsActive == true).Select(item => new ComboBoxKeyAndValue()
            {
                Key = item.Id,
                Value = item.FirstName+" "+item.LastName
            }).ToList();
            ShippersList = Db.Shippers.Select(item => new ComboBoxKeyAndValue()
            {
                Key = item.Id,
                Value = item.CompanyName
            }).ToList();
            Messenger.Default.Register<Customers>(this, GetCustomer);
        }

        #endregion

        #region Methods

        private void GetCustomer(Customers item)
        {
            CustomerDetails = $"Name: {item.FirstName} {item.SecondName}, Id: {item.Id}.";
            CustomerId = item.Id;
        }

        public override void Save()
        {
            try
            {
                Db.Orders.AddObject(Item);
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
