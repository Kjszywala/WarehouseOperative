using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewEmployeeAnnualLeavesViewModel : AddRowViewModel<EmployeeAnnualLeaves>
    {
        #region properties

        public DateTime? StartDate
        {
            get
            {
                return Item.StartDate;
            }
            set
            {
                if (value != Item.StartDate)
                {
                    Item.StartDate = value;
                    OnPropertyChanged(() => StartDate);
                }
            }
        }
        public DateTime? EndDate
        {
            get
            {
                return Item.EndDate;
            }
            set
            {
                if (value != Item.EndDate)
                {
                    Item.EndDate = value;
                    OnPropertyChanged(() => EndDate);
                }
            }
        }
        public int DaysLeft
        {
            get
            {
                return Item.DaysLeft;
            }
            set
            {
                if (value != Item.DaysLeft)
                {
                    Item.DaysLeft = value;
                    OnPropertyChanged(() => DaysLeft);
                }
            }
        }

        #endregion

        #region Constructor
        public NewEmployeeAnnualLeavesViewModel()
            : base("EmployeeAnnualLeaves")
        {
            Item = new EmployeeAnnualLeaves()
            {
                ModificationDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
        }

        #endregion

        #region Methods

        public override void Save()
        {
            try
            {
                Db.EmployeeAnnualLeaves.AddObject(Item);
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
