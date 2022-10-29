using WarehouseOperative.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;

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
                return new BaseCommand(createInvoice);
            }
        }
        public ICommand AllInvoicesCommand
        {
            get
            {
                return new BaseCommand(showAllInvoices);
            }
        }
        public ICommand NewProductCommand
        {
            get
            {
                return new BaseCommand(createTowar);
            }
        }
        public ICommand AllProductsCommand
        {
            get
            {
                return new BaseCommand(showAllTowar);
            }
        }
        public ICommand AddToDatabase
        {
            get
            {
                return new BaseCommand(addToDatabase);
            }
        }
        public ICommand GetDatabase
        {
            get
            {
                return new BaseCommand(getDatabase);
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
                new CommandViewModel("New Product", new BaseCommand(createTowar)),
                new CommandViewModel("Products", new BaseCommand(showAllTowar)),
                new CommandViewModel("New Invoice", new BaseCommand(createInvoice)),
                new CommandViewModel("Invoices", new BaseCommand(showAllInvoices)),
                new CommandViewModel("Add to database", new BaseCommand(addToDatabase)),
                new CommandViewModel("Database", new BaseCommand(getDatabase))
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
        // This is function to open new bookmark.
        // This method each time it is called creating new bookmark.
        private void deleteBookmark()
        {
            if (Workspaces.Count>0)
            {
                Workspaces.RemoveAt(Workspaces.Count - 1);

            }
        }
        private void getInfo()
        {
            MessageBox.Show("Author: Kamil Szywala.\nThis program was made for\nWyzsza Szkola Biznesu - National Luis University\nin a purpose of end-semester project from\nC# Interfaces.");
        }
        private void getClose()
        {
            Application.Current.MainWindow.Close();
        }
        private void getDatabase()
        {
            AllCustomersViewModel database = new AllCustomersViewModel();
            this._Workspaces.Add(database);
            this.setActiveWorkspace(database);
        }
        private void addToDatabase()
        {
            AllEmloyeesViewModel database = new AllEmloyeesViewModel();
            this._Workspaces.Add(database);
            this.setActiveWorkspace(database);
        }
        private void createInvoice()
        {
            NewInvoiceViewModel newInvoiceViewModel = new NewInvoiceViewModel();
            this._Workspaces.Add(newInvoiceViewModel);
            this.setActiveWorkspace(newInvoiceViewModel);
        }
        private void createTowar()
        {
            // create new bookmark
            NewProductViewmodel workspace = new NewProductViewmodel();
            // add bookmark to active bookmark collection.
            this._Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        // This is function to open bookmark with all bookmarks.
        // This method when is called checks if bookmark exist, if exist making 
        // this bookmark active, if not creating a new one.
        private void showAllTowar()
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

        public event EventHandler RequestClose;
        private void OnRequestClose()
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
