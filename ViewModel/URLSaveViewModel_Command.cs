using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using URLSaving.ViewModel.Commands;

namespace URLSaving.ViewModel
{
    public partial class URLSaveViewModel
    {
        public BtnCommand SearchCategory { get; set; }
        public BtnCommand DeleteCategory { get; set; }

        public BtnCommand DeleteUrl { get; set; }
        public BtnCommand UrlAddCommand { get; set; }
        public BtnCommand CategoryAddCommand { get; set; }
    }
}
