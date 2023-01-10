using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewEmployeeAnnualLeavesViewModel : AddRowViewModel<EmployeeAnnualLeaves>, IDataErrorInfo
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
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(DaysLeft):
                        return IntValidator.IsNegative(DaysLeft);
                    default:
                        return string.Empty;
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
        protected override bool IsValid()
        {
            return this[nameof(DaysLeft)] == string.Empty;
        }

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
