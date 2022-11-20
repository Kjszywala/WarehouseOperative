using System;
using System.Windows.Input;

namespace WarehouseOperative.ViewModels
{
    //This class creating commands in left side menu.
    public class CommandViewModel : BaseViewModel
    {
        #region FieldsAndProperties
        //Name of the button
        public string DisplayName { get; set; }
        //Command for the button
        public ICommand Command { get; set; }
        public string IconURL { get; set; }
        #endregion
        #region Constructor
        public CommandViewModel(string DisplayName, ICommand Command, string iconURL)
        {
            if (Command == null)
                throw new ArgumentNullException("Errot: Command");
            this.DisplayName = DisplayName;
            this.Command = Command;
            IconURL = iconURL;
        }
        #endregion
    }
}
