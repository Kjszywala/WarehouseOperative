using System;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewSupplierViewModel : AddRowViewModel<Suppliers>
    {
        #region Constructor

        public NewSupplierViewModel()
            : base("Add Employee")
        {
            Item = new Suppliers()
            {
                IsActive = true
            };
        }
        #endregion

        #region Properties

        public string CompanyName
        {
            get
            {
                return Item.CompanyName;
            }
            set
            {
                if (value != Item.CompanyName)
                {
                    Item.CompanyName = value;
                    OnPropertyChanged(() => CompanyName);
                }
            }
        }
        public string ContactName
        {
            get
            {
                return Item.ContactName;
            }
            set
            {
                if (value != Item.ContactName)
                {
                    Item.ContactName = value;
                    OnPropertyChanged(() => ContactName);
                }
            }
        }
        public string ContactTitle
        {
            get
            {
                return Item.ContactTitle;
            }
            set
            {
                if (value != Item.ContactTitle)
                {
                    Item.ContactTitle = value;
                    OnPropertyChanged(() => ContactTitle);
                }
            }
        }
        public int? SuplierAddressId
        {
            get
            {
                return Item.SupplierAddressId;
            }
            set
            {
                if (value != Item.SupplierAddressId)
                {
                    Item.SupplierAddressId = value;
                    OnPropertyChanged(() => SuplierAddressId);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            try
            {
                Db.Suppliers.AddObject(Item);
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
