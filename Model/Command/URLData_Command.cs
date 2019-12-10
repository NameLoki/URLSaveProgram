using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLSaving.ViewModel;
using URLSaving.ViewModel.Commands;

namespace URLSaving.Model
{
    public partial class URLData
    {
        public BtnCommand PageLoadCommand { get; set; }
        public BtnCommand BookMarkCommand { get; set; }

        public URLData()
        {
            PageLoadCommand = new BtnCommand(PageLoad);
            BookMarkCommand = new BtnCommand(BookMarkSave);
        }

        private void PageLoad()
        {
            Process.Start(Url);
        }

        private void BookMarkSave()
        {
            URLSaveViewModel.UrlSave(this);
        }

    }
}
