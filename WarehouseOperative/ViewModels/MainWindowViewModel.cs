using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.ViewModels.AllViewModel;
using WarehouseOperative.ViewModels.NewViewModel;

namespace WarehouseOperative.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// It will include collections of commends from left menu and 
        /// collection of bookmarks.
        /// </summary>
        #region Commands
        public ICommand NewInvoiceCommand
        {
            get
            {
                return new BaseCommand(() => addBookmarkCreateNew(new NewInvoiceViewModel()));
            }
        }
        public ICommand RestoreButtonCommand
        {
            get
            {
                return new BaseCommand(restoreBookmarks);
            }
        }
        public ICommand DeleteAllBookmarks
        {
            get
            {
                return new BaseCommand(deleteAllBookmarks);
            }
        }
        public ICommand AllInvoicesCommand
        {
            get
            {
                return new BaseCommand(showAllInvoices);
            }
        }
        public ICommand ErrorLog
        {
            get
            {
                return new BaseCommand(getErrorLog);
            }
        }
        public ICommand NewProductCommand
        {
            get
            {
                return new BaseCommand(() => addBookmarkCreateNew(new NewProductViewmodel()));
            }
        }
        public ICommand AllProductsCommand
        {
            get
            {
                return new BaseCommand(showAllProducts);
            }
        }
        public ICommand AddEmployee
        {
            get
            {
                return new BaseCommand(() => addBookmarkCreateNew(new NewEmployeeViewModel()));
            }
        }
        public ICommand GetSuppliers
        {
            get
            {
                return new BaseCommand(getSuppliers);
            }
        }
        public ICommand GetEmployees
        {
            get
            {
                return new BaseCommand(getEmployees);
            }
        }
        public ICommand getCloseCommand
        {
            get
            {
                return new BaseCommand(getClose);
            }
        }
        public ICommand InfoCommand
        {
            get
            {
                return new BaseCommand(getInfo);
            }
        }
        public ICommand CloseBookmark
        {
            get
            {
                return new BaseCommand(deleteBookmark);
            }
        }
        #endregion

        #region Buttons in left side menu
        // This is the collection of command in left menu.
        private ReadOnlyCollection<CommandViewModel> _Commands;
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                // Check if buttons from left side menu are initialized.
                // If not create list of buttons with CreateCommands() method and
                // set this list to ReadOnlyCollection because you can
                // only create ReadOnlyCollection, you can't add it.
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        //Here we decide which buttons are in left side menu
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                // Creat buttons
                new CommandViewModel("Add Product", new BaseCommand(()=>addBookmarkCreateNew(new NewProductViewmodel())),"pack://application:,,,/Views/Content/Icons/leftaddproduct.png"),
                new CommandViewModel("All Products", new BaseCommand(showAllProducts),"pack://application:,,,/Views/Content/Icons/leftproducts.png"),
                new CommandViewModel("Add Invoice", new BaseCommand(()=>addBookmarkCreateNew(new NewInvoiceViewModel())),"pack://application:,,,/Views/Content/Icons/leftaddinvoice.png"),
                new CommandViewModel("All Invoices", new BaseCommand(showAllInvoices),"pack://application:,,,/Views/Content/Icons/leftallinvoices.png"),
                new CommandViewModel("Add Employee", new BaseCommand(()=>addBookmarkCreateNew(new NewEmployeeViewModel())),"pack://application:,,,/Views/Content/Icons/leftaddemployee.png"),
                new CommandViewModel("All Employees", new BaseCommand(getEmployees),"pack://application:,,,/Views/Content/Icons/leftaddemployees.png"),
                new CommandViewModel("All Customers", new BaseCommand(getCustomers),"pack://application:,,,/Views/Content/Icons/leftallcustomers.png"),
                new CommandViewModel("All Orders", new BaseCommand(getOrders),"pack://application:,,,/Views/Content/Icons/leftallorders.png")
            };
        }
        #endregion

        #region Bookmarks
        // This is  the collection of bookmarks.
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if(_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private ObservableCollection<WorkspaceViewModel> _WorkspacesHistory;
        public ObservableCollection<WorkspaceViewModel> WorkspacesHistory
        {
            get
            {
                if (_WorkspacesHistory == null)
                {
                    _WorkspacesHistory = new ObservableCollection<WorkspaceViewModel>();
                    _WorkspacesHistory.CollectionChanged += this.onWorkspacesChanged;
                }
                return _WorkspacesHistory;
            }
            set
            {
                _WorkspacesHistory = value;
            }
        }
        // This methods are standards copied from Microsoft 
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e) 
        { 
            if (e.NewItems != null && e.NewItems.Count != 0) 
                foreach (WorkspaceViewModel workspace in e.NewItems) 
                    workspace.RequestClose += this.onWorkspaceRequestClose; 
            if (e.OldItems != null && e.OldItems.Count != 0) 
                foreach (WorkspaceViewModel workspace in e.OldItems) 
                    workspace.RequestClose -= this.onWorkspaceRequestClose; 
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel; 
            //workspace.Dispos();
            this.Workspaces.Remove(workspace); 
        }
        #endregion

        #region HelpFunctions
        /// <summary>
        /// Delete current bookmark and add bookmarks to history list.
        /// </summary>
        private void deleteBookmark()
        {
            if (Workspaces.Count>0)
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
                WorkspacesHistory.Add(Workspaces[collectionView.CurrentPosition]);
                Workspaces.RemoveAt(collectionView.CurrentPosition);
            }
        }

        /// <summary>
        /// Delete all bookmarks and add bookmarks to history list.
        /// </summary>
        private void deleteAllBookmarks()
        {
            if (WorkspacesHistory.Count > 0)
            {
                WorkspacesHistory.Clear();
            }
            foreach (var item in Workspaces)
            {
                WorkspacesHistory.Add(item);
            }
            Workspaces.Clear();
        }

        /// <summary>
        /// Restore bookmarks from history.
        /// </summary>
        private void restoreBookmarks()
        {
            foreach(WorkspaceViewModel workspace in WorkspacesHistory)
            {
                this._Workspaces.Add(workspace);
                this.setActiveWorkspace(workspace);
            }
            WorkspacesHistory.Clear();
        }

        /// <summary>
        /// Get information about application.
        /// </summary>
        private void getInfo()
        {
            MessageBox.Show("Author: Kamil Szywala.\nThis program was made for\nWyzsza Szkola Biznesu - National Luis University\nin a purpose of end-semester project from\nC# Interfaces.");
        }

        /// <summary>
        /// Close the aplication.
        /// </summary>
        private void getClose()
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// Create a bookmark method, we do not need to write this method for each bookmark
        /// instead of it we can just pass parameter to this function and then call it like below
        /// new BaseCommand(()=>addBookmark(new NewEmployeeViewModel()))
        /// </summary>
        /// <param name="workspace"></param>
        private void addBookmarkCreateNew(WorkspaceViewModel workspace)
        {
            // add bookmark to active bookmark collection.
            this._Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        // This is function to open bookmark with all bookmarks.
        // This method when is called checks if bookmark exist, if exist making 
        // this bookmark active, if not creating a new one.
        private void showAllProducts()
        {
            // First we looking for in bookmark collection a bookmark which is all bookmarks.
            AllProductsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllProductsViewModel) as AllProductsViewModel;
            // If there is no bookmarks like this, then we creating a new one.
            if(workspace == null)
            {
                workspace = new AllProductsViewModel();
                this.Workspaces.Add(workspace);
            }
            // Bookmark activation.
            this.setActiveWorkspace(workspace);
        }

        private void showAllInvoices()
        {
            AllInvoicesViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllInvoicesViewModel) as AllInvoicesViewModel;
            if(workspace == null)
            {
                workspace = new AllInvoicesViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void getErrorLog()
        {
            ErrorLogViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is ErrorLogViewModel) as ErrorLogViewModel;
            if (workspace == null)
            {
                workspace = new ErrorLogViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void getEmployees()
        {
            AllEmloyeesViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllEmloyeesViewModel) as AllEmloyeesViewModel;
            if (workspace == null)
            {
                workspace = new AllEmloyeesViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void getCustomers()
        {
            AllCustomersViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllCustomersViewModel) as AllCustomersViewModel;
            if (workspace == null)
            {
                workspace = new AllCustomersViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void getOrders()
        {
            AllOrdersViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllOrdersViewModel) as AllOrdersViewModel;
            if (workspace == null)
            {
                workspace = new AllOrdersViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void getSuppliers()
        {
            AllSuppliersViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllSuppliersViewModel) as AllSuppliersViewModel;
            if (workspace == null)
            {
                workspace = new AllSuppliersViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }


        // this is the standard method for adding setting bookmark active
        private void setActiveWorkspace(WorkspaceViewModel workspace) 
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces); 
            if (collectionView != null) 
                collectionView.MoveCurrentTo(workspace); 
        }
        #endregion
    }
}
