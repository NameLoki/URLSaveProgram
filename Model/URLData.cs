using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLSaving.ViewModel;
using URLSaving.ViewModel.Commands;

namespace URLSaving.Model
{
    public partial class URLData
    {
        private bool? vpn = null;
        public bool? Vpn
        {
            get
            {
                return vpn;
            }
            set
            {
                vpn = value;
            }
        }

        private string categoryName;
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }

        private string title = string.Empty;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        private string url = string.Empty;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        private bool? bookMark;
        public bool? BookMark
        {
            get
            {
                return bookMark;
            }
            set
            {
                bookMark = value;
            }
        }

        private bool? selectThis;
        public bool? SelectThis
        {
            get
            {
                return selectThis;
            }
            set
            {
                selectThis = value;
            }
        }
    }
}
