using System.Windows;
using System;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using WarehouseOperative.Models.EntitiesForView;
using System.ComponentModel;
using WarehouseOperative.Models.Validators;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewProductViewmodel : AddRowViewModel<Products>, IDataErrorInfo
    {
        #region Properties
        public string Title
        {
            get
            {
                return Item.Title;
            }
            set
            {
                if (value != Item.Title)
                {
                    Item.Title = value;
                    OnPropertyChanged(() => Title);
                }
            }
        }
        public string Notes
        {
            get
            {
                return Item.Notes;
            }
            set
            {
                if (value != Item.Notes)
                {
                    Item.Notes = value;
                    OnPropertyChanged(() => Notes);
                }
            }
        }
        public string ProductName
        {
            get
            {
                return Item.ProductName;
            }
            set
            {
                if (value != Item.ProductName)
                {
                    Item.ProductName = value;
                    OnPropertyChanged(() => ProductName);
                }
            }
        }
        public string ProductCode
        {
            get
            {
                return Item.ProductCode;
            }
            set
            {
                if (value != Item.ProductCode)
                {
                    Item.ProductCode = value;
                    OnPropertyChanged(() => ProductCode);
                }
            }
        }
        public int? CategoryId
        {
            get
            {
                return Item.CategoryId;
            }
            set
            {
                if (value != Item.CategoryId)
                {
                    Item.CategoryId = value;
                    OnPropertyChanged(() => CategoryId);
                }
            }
        }
        public int? SupplierId
        {
            get
            {
                return Item.SupplierId;
            }
            set
            {
                if (value != Item.SupplierId)
                {
                    Item.SupplierId = value;
                    OnPropertyChanged(() => SupplierId);
                }
            }
        }
        public int? ProductLogId
        {
            get
            {
                return Item.ProductLogId;
            }
            set
            {
                if (value != Item.ProductLogId)
                {
                    Item.ProductLogId = value;
                    OnPropertyChanged(() => ProductLogId);
                }
            }
        }
        public decimal ActualQuantity
        {
            get
            {
                return Item.ActualQuantity;
            }
            set
            {
                if (value != Item.ActualQuantity)
                {
                    Item.ActualQuantity = value;
                    OnPropertyChanged(() => ActualQuantity);
                }
            }
        }
        public decimal ActualPrice
        {
            get
            {
                return Item.ActualPrice;
            }
            set
            {
                if (value != Item.ActualPrice)
                {
                    Item.ActualPrice = value;
                    OnPropertyChanged(() => ActualPrice);
                }
            }
        }
        public int? QuantityTypeId
        {
            get
            {
                return Item.QuantityType;
            }
            set
            {
                if (value != Item.QuantityType)
                {
                    Item.QuantityType = value;
                    OnPropertyChanged(() => QuantityTypeId);
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
        /// <summary>
        /// Lists needed for combo box.
        /// </summary>
        public List<ComboBoxKeyAndValue> quantityTypes { get; set; }
        public List<ComboBoxKeyAndValue> categoriesList { get; set; }
        public List<ComboBoxKeyAndValue> suppliers { get; set; }
        private string _ProductsLogDescription;
        public string ProductsLogDescription
        {
            get
            {
                return _ProductsLogDescription;
            }
            set
            {
                if (value != _ProductsLogDescription)
                {
                    _ProductsLogDescription = value;
                    OnPropertyChanged(() => _ProductsLogDescription);
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
                    case nameof(Title):
                        return StringValidator.IsLenghtCorrect(Title, 255);
                    case nameof(Notes):
                        return StringValidator.IsLenghtCorrect(Notes, 255);
                    case nameof(ProductName):
                        return StringValidator.IsLenghtCorrect(ProductName, 255);
                    case nameof(ProductCode):
                        return StringValidator.IsLenghtCorrect(ProductCode, 255);
                    case nameof(ActualQuantity):
                        return DecimalValidator.IsNotNegative(ActualQuantity);
                    case nameof(ActualPrice):
                        return DecimalValidator.IsNotNegative(ActualPrice);
                    case nameof(Discount):
                        return DecimalValidator.IsNotNegative(Discount);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Constructor
        public NewProductViewmodel()
            :base("Product")
        {
            Item = new Products()
            {
                IsActive = true,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
            //quantityTypes = Db.QuantityTypes.Where(item => item.IsActive == true).ToList();
            //categoriesList = Db.Categories.Where(item => item.IsActive == true).ToList();
            //suppliers = Db.Suppliers.Where(item => item.IsActive == true).ToList();
            quantityTypes = Db.QuantityTypes.Where(item => item.IsActive == true).Select(item => new ComboBoxKeyAndValue()
            {
                Key = item.Id,
                Value = item.title
            }).ToList();
            categoriesList = Db.Categories.Where(item => item.IsActive == true).Select(item => new ComboBoxKeyAndValue()
            {
                Key = item.Id,
                Value = item.CategoryDescription
            }).ToList();
            suppliers = Db.Suppliers.Where(item => item.IsActive == true).Select(item => new ComboBoxKeyAndValue()
            {
                Key = item.Id,
                Value = item.CompanyName
            }).ToList();
            Messenger.Default.Register<ProductLogs>(this, GetProductLog);
        }

        #endregion

        #region Methods
        protected override bool IsValid()
        {
            return this[nameof(Title)] == string.Empty
                && this[nameof(Notes)] == string.Empty
                && this[nameof(ProductName)] == string.Empty
                && this[nameof(ProductCode)] == string.Empty
                && this[nameof(ActualQuantity)] == string.Empty
                && this[nameof(ActualPrice)] == string.Empty
                && this[nameof(Discount)] == string.Empty;
        }
        /// <summary>
        /// Get Product log description for given log.
        /// </summary>
        /// <param name="kontrahent"></param>
        private void GetProductLog(ProductLogs log)
        {
            ProductsLogDescription = $"Description: {log.ProductLogDescrition}, New Price: {log.NewPrice}, Old Price: {log.OldPrice}";
            ProductLogId = log.Id;
        }

        /// <summary>
        /// Save item to db.
        /// </summary>
        public override void Save()
        {
            try
            {
                Db.Products.AddObject(Item);
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
