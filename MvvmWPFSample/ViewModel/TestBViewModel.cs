using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MvvmWPFSample.CustomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWPFSample.ViewModel
{
    public class TestBViewModel : ViewModelBase
    {
        private string result;
        public string Result { get { return this.result; } set { this.result = value; this.RaisePropertyChanged("Result"); } }
        public TestBViewModel()
        {
            Messenger.Default.Register<TestBResults>(this, results =>
            {
                this.Result = results.Result;
            });
        }
    }
}
