using System.Windows;
using System;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using GalaSoft.MvvmLight.Messaging;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewProductViewmodel : AddRowViewModel<Products>
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
        public List<QuantityTypes> quantityTypes { get; set; }
        public List<Categories> categoriesList { get; set; }
        public List<Suppliers> suppliers { get; set; }
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
        #endregion

        #region Constructor
        public NewProductViewmodel()
            :base("Product")
        {
            Item = new Products()
            {
                IsActive = true,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                SupplierId = this.SupplierId,
                CategoryId = this.CategoryId,
                QuantityType = this.QuantityTypeId
            };
            quantityTypes = Db.QuantityTypes.Where(item => item.IsActive == true).ToList();
            categoriesList = Db.Categories.Where(item => item.IsActive == true).ToList();
            suppliers = Db.Suppliers.Where(item => item.IsActive == true).ToList();
            Messenger.Default.Register<ProductLogs>(this, GetProductLog);
        }

        #endregion

        #region Methods
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
