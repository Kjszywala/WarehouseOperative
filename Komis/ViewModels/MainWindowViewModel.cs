﻿using KomisSamochodowy.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KomisSamochodowy.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// It will include collections of commends from left menu and 
        /// collection of bookmarks.
        /// </summary>
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
                new CommandViewModel("Products", new BaseCommand(showAllTowar)),
                new CommandViewModel("New Product", new BaseCommand(createTowar))
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
        private void createTowar()
        {
            // create new bookmark
            NowyTowarViewModel workspace = new NowyTowarViewModel();
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
            WszystkieTowaryViewModel? workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;
            // If there is no bookmarks like this, then we creating a new one.
            if(workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }
            // Bookmark activation.
            this.setActiveWorkspace(workspace);
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
