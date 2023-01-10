using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewEmployeeViewModel : AddRowViewModel<Employees>, IDataErrorInfo
    {
        #region Constructor
        public NewEmployeeViewModel()
            : base("Employee")
        {
            Item = new Employees()
            {
                HireDate = DateTime.Now,
                IsActive = true,
                Title = "New Employee",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
            Messenger.Default.Register<EmployeeAddresses>(this, GetEmployeeAddress);
            Messenger.Default.Register<EmployeeAnnualLeaves>(this, GetEmployeeAnnualLeave);
        }
        #endregion

        #region Properties

        public string FirstName
        {
            get
            {
                return Item.FirstName;
            }
            set
            {
                if (value != Item.FirstName)
                {
                    Item.FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }
        public string LastName
        {
            get
            {
                return Item.LastName;
            }
            set
            {
                if (value != Item.LastName)
                {
                    Item.LastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }
        public string Email
        {
            get
            {
                return Item.Email;
            }
            set
            {
                if (value != Item.Email)
                {
                    Item.Email = value;
                    OnPropertyChanged(() => Email);
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
        public DateTime HireDate
        {
            get
            {
                return Item.HireDate;
            }
            set
            {
                if (value != Item.HireDate)
                {
                    Item.HireDate = value;
                    OnPropertyChanged(() => HireDate);
                }
            }
        }
        public string JobTitle
        {
            get
            {
                return Item.JobTitle;
            }
            set
            {
                if (value != Item.JobTitle)
                {
                    Item.JobTitle = value;
                    OnPropertyChanged(() => JobTitle);
                }
            }
        }

        public int? EmployeeAddressId
        {
            get
            {
                return Item.EmployeeAddressId;
            }
            set
            {
                if (value != Item.EmployeeAddressId)
                {
                    Item.EmployeeAddressId = value;
                    OnPropertyChanged(() => EmployeeAddressId);
                }
            }
        }
        public string EmployeeAddress { get; set; }

        public int? EmployeeAnnualLeaveId
        {
            get
            {
                return Item.EmployeeAnnualLeave;
            }
            set
            {
                if (value != Item.EmployeeAnnualLeave)
                {
                    Item.EmployeeAnnualLeave = value;
                    OnPropertyChanged(() => EmployeeAnnualLeaveId);
                }
            }
        }
        public string EmployeeAnnualLeaves { get; set; }

        public string CustomerDetails { get; set; }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Email):
                        return StringValidator.EmailCheck(Email);
                    case nameof(FirstName):
                        return StringValidator.IsLenghtCorrect(FirstName, 255);
                    case nameof(LastName):
                        return StringValidator.IsLenghtCorrect(LastName, 255);
                    case nameof(Phone):
                        return StringValidator.IsLenghtCorrect(Phone, 50);
                    case nameof(JobTitle):
                        return StringValidator.IsLenghtCorrect(JobTitle, 40);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Methods
        private void GetEmployeeAddress(EmployeeAddresses item)
        {
            EmployeeAddress = $"Postcode: {item.PostCode}, City: {item.City}, Country: {item.Country}";
            EmployeeAddressId = item.Id;
        }
        private void GetEmployeeAnnualLeave(EmployeeAnnualLeaves item)
        {
            EmployeeAnnualLeaves = $"StartDate: {item.StartDate}, End Date: {item.EndDate}, Days Left: {item.DaysLeft}";
            EmployeeAnnualLeaveId = item.Id;
        }
        public override void Save()
        {
            try
            {
                Db.Employees.AddObject(Item);
                Db.SaveChanges();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
