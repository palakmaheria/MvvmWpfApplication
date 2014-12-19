using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWPFSample.CustomObjects
{
    public class TestBResults
    {
        private string result;

        public string Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }
    }
}
