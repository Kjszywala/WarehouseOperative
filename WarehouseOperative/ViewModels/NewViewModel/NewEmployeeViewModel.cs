using System;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewEmployeeViewModel : AddRowViewModel<Employees>
    {
        #region Constructor
        public NewEmployeeViewModel()
            : base("Add Employee")
        {
            Item = new Employees();
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
        #endregion

        #region Save
        public override void Save()
        {
            Item.IsActive = true;
            if (string.IsNullOrEmpty(JobTitle))
            {
                MessageBox.Show("Item is empty.");
                return;
            }
            Db.Employees.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
