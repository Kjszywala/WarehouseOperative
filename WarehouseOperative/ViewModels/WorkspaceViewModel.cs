using WarehouseOperative.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WarehouseOperative.ViewModels
{
    //All bookmark ViewModels will extend this class 
    public class WorkspaceViewModel : BaseViewModel
    {
        #region FieldsAndProperties
        //All bookmarks have minimum display name and close button
        //DisplayName - here we store bookmark name
        //_CloseComand - this is a service to close bookmark 
        public string DisplayName { get; set; }
        private BaseCommand _CloseCommand; 
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    //This command will start closing bookmark function
                    _CloseCommand = new BaseCommand(() => this.OnRequestClose());
                return _CloseCommand;
            }
        }
        #endregion
        #region RequestClose [evant]
        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if(handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion
    }
}
