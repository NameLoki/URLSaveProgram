using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLSaving.ViewModel.Commands;

namespace URLSaving.Model
{
    public partial class URLData
    {
        public BtnCommand PageLoadCommand { get; set; }
        public BtnCommand DeleteURLCommand { get; set; }
        public URLData()
        {
            //DeleteURLCommand = new BtnCommand();
            PageLoadCommand = new BtnCommand(PageLoad);
        }

        private void PageLoad()
        {
            Process.Start(Url);
        }

        
    }
}
