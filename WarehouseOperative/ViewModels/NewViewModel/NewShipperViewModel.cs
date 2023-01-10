using System.Windows;
using System;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;
using System.ComponentModel;
using WarehouseOperative.Models.Validators;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewShipperViewModel : AddRowViewModel<Shippers>, IDataErrorInfo
    {
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
        public string Phone
        {
            get
            {
                return Item.Phone;
            }
            set
            {
                if (value != Item.Phone)
                {
                    Item.Phone = value;
                    OnPropertyChanged(() => Phone);
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
                    case nameof(CompanyName):
                        return StringValidator.IsLenghtCorrect(CompanyName, 255);
                    case nameof(Phone):
                        return StringValidator.IsLenghtCorrect(Phone, 50);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Constructor
        public NewShipperViewModel()
           : base("Shipper")
        {
            Item = new Shippers()
            {
                IsActive = true
            };
        }
        #endregion

        #region Methods

        public override void Save()
        {
            try
            {
                Db.Shippers.AddObject(Item);
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
