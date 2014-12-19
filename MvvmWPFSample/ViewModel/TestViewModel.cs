using DataAccessLayer.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWPFSample.ViewModel
{
    /// <summary>
    /// Represents view model for Test view
    /// </summary>
    public class TestViewModel : ViewModelBase, IDisposable
    {
        /// <summary>
        /// User roles
        /// </summary>
        private IUserRoles userRoles;

        /// <summary>
        /// user name
        /// </summary>
        private string userName;
        
        /// <summary>
        /// Constructor for test view model
        /// </summary>
        /// <param name="userRoles">User roles</param>
        public TestViewModel(IUserRoles userRoles)
        {
            this.userRoles = userRoles;
            Messenger.Default.Register<string>(this, msg =>
            {
                this.UserName = msg;
            });
        }

        /// <summary>
        /// Destructor for test view model
        /// </summary>
        ~TestViewModel()
        {
            this.Dispose();
        }

        /// <summary>
        /// Gets or sets user name
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                this.userName = value;
                this.RaisePropertyChanged("userName");
            }
        }

        /// <summary>
        /// Relay command associated with get names function
        /// </summary>
        public RelayCommand GetNamesCommand
        {
            get
            {
                return new RelayCommand(() => ExecuteNamesCommand());
            }
            
        }

        /// <summary>
        /// Relay command associated with udpate names function
        /// </summary>
        public RelayCommand UpdateNamesCommand
        {
            get
            {
                return new RelayCommand(() => ExecuteUpdateNamesCommand());
            }

        }

        /// <summary>
        /// Executes update name functionality
        /// </summary>
        private void ExecuteUpdateNamesCommand()
        {
            Messenger.Default.Send("hello");
        }

        /// <summary>
        /// Executes get names functionality
        /// </summary>
        private void ExecuteNamesCommand()
        {
            this.UserName = this.userRoles.GetUserName("");
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Messenger.Default.Unregister<string>(this);
        }
    }
}
