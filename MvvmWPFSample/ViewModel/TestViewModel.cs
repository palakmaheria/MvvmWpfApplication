using DataAccessLayer.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MvvmWPFSample.CustomObjects;
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

        private TestAViewModel testAViewModel;

        private TestBViewModel testBViewModel;
        
        /// <summary>
        /// Constructor for test view model
        /// </summary>
        /// <param name="userRoles">User roles</param>
        public TestViewModel(IUserRoles userRoles, TestAViewModel testAViewModel, TestBViewModel testBViewModel)
        {
            this.userRoles = userRoles;
            this.testAViewModel = testAViewModel;
            this.testBViewModel = testBViewModel;
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

        public TestAViewModel TestAViewModel { get { return this.testAViewModel; } set { this.testAViewModel = value; this.RaisePropertyChanged("TestAViewModel"); } }
        public TestBViewModel TestBViewModel { get { return this.testBViewModel; } set { this.testBViewModel = value; this.RaisePropertyChanged("TestBViewModel"); } }

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
            Messenger.Default.Send<TestBResults>(new TestBResults { Result = "TestB zzd fs" });
        }

        /// <summary>
        /// Executes get names functionality
        /// </summary>
        private void ExecuteNamesCommand()
        {
            this.UserName = this.userRoles.GetUserName("");
            Messenger.Default.Send<TestAResults>(new TestAResults{ Result = "TestA fgsdfd fs"});
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
