using System;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewEmployeeViewModel : AddRowViewModel<Employees>
    {
        #region Constructor
        public NewEmployeeViewModel()
            : base("Add Employee")
        {
            Item = new Employees()
            {
                HireDate = DateTime.Now,
                IsActive = true,
                Title = "New Employee",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
        };
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
        //public string FlatNumber
        //{
        //    get
        //    {
        //        return Item.FlatNumber;
        //    }
        //    set
        //    {
        //        if (value != Item.FlatNumber)
        //        {
        //            Item.JobTitle = value;
        //            OnPropertyChanged(() => FlatNumber);
        //        }
        //    }
        //}
        //public string StreetName
        //{
        //    get
        //    {
        //        return Item.StreetName;
        //    }
        //    set
        //    {
        //        if (value != Item.StreetName)
        //        {
        //            Item.JobTitle = value;
        //            OnPropertyChanged(() => StreetName);
        //        }
        //    }
        //}
        //public string PostCode
        //{
        //    get
        //    {
        //        return Item.PostCode;
        //    }
        //    set
        //    {
        //        if (value != Item.PostCode)
        //        {
        //            Item.JobTitle = value;
        //            OnPropertyChanged(() => PostCode);
        //        }
        //    }
        //}
        //public string City
        //{
        //    get
        //    {
        //        return Item.City;
        //    }
        //    set
        //    {
        //        if (value != Item.City)
        //        {
        //            Item.JobTitle = value;
        //            OnPropertyChanged(() => City);
        //        }
        //    }
        //}
        //public string Country
        //{
        //    get
        //    {
        //        return Item.Country;
        //    }
        //    set
        //    {
        //        if (value != Item.Country)
        //        {
        //            Item.JobTitle = value;
        //            OnPropertyChanged(() => Country);
        //        }
        //    }
        //}
        #endregion

        #region Save
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
