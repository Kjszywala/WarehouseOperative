using System;
using System.Windows;
using WarehouseOperative.Models.Entities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels
{
    public class NewEmployeeViewModel: AddRowViewModel<Employees>
    {
        #region Constructor
        public NewEmployeeViewModel()
            :base("Add Employee")
        {
            Item = new Employees();
        }
        #endregion

        #region Properties
        public string First_Name
        {
            get
            {
                return Item.First_Name;
            }
            set
            {
                if (value != Item.First_Name)
                {
                    Item.First_Name = value;
                    OnPropertyChanged(() => First_Name);
                }
            }
        }
        public string Last_Name
        {
            get
            {
                return Item.Last_Name;
            }
            set
            {
                if (value != Item.Last_Name)
                {
                    Item.Last_Name = value;
                    OnPropertyChanged(() => Last_Name);
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
        public DateTime Hire_Date
        {
            get
            {
                return Item.Hire_Date;
            }
            set
            {
                if (value != Item.Hire_Date)
                {
                    Item.Hire_Date = value;
                    OnPropertyChanged(() => Hire_Date);
                }
            }
        }
        public string Job_Title
        {
            get
            {
                return Item.Job_Title;
            }
            set
            {
                if (value != Item.Job_Title)
                {
                    Item.Job_Title = value;
                    OnPropertyChanged(() => Job_Title);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.IsActive = true;
            if (string.IsNullOrEmpty(Job_Title))
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
