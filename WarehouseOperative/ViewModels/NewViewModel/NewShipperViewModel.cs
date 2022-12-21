using System.Windows;
using System;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewShipperViewModel : AddRowViewModel<Shippers>
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
