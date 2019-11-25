using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using URLSaving.Model;
using URLSaving.ViewModel.Interface;

namespace URLSaving.ViewModel
{
    public partial class URLSaveViewModel : IURLManager
    {
        public ObservableCollection<URLData> URLs { get; private set; }

        public DirectoryInfo urlDirectoryInfo;
        private const string URL_FILE_NAME = "_urldata.txt";
        //private const string URL_FILE_PATH = @"..\..\Data\URL\";
        private const string URL_FILE_PATH = @"Data\URL\";

        private string title;
        private string category;
        private string url;
        private bool? vpn;
        private bool? bookMark;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof(this.Title));
            }
        }
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                OnPropertyChanged(nameof(this.Category));
            }
        }
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                OnPropertyChanged(nameof(this.Url));
            }
        }
        public bool? Vpn
        {
            get
            {
                return vpn;
            }
            set
            {
                vpn = value;
                OnPropertyChanged(nameof(this.Vpn));
            }
        }
        public bool? BookMark
        {
            get
            {
                return bookMark;
            }
            set
            {
                bookMark = value;
                OnPropertyChanged(nameof(this.BookMark));
            }
        }
        private void UrlSave(URLData url)
        {
            using StreamWriter streamWriter = new StreamWriter(URL_FILE_PATH + url.Title + URL_FILE_NAME, false);
            streamWriter.Write(url.BookMark + OVERHEAD);
            streamWriter.Write(url.Vpn + OVERHEAD);
            streamWriter.Write(url.Title + OVERHEAD);
            streamWriter.Write(url.Url + OVERHEAD);
            streamWriter.Write(url.CategoryName);
        }

        public void UrlAdd()
        {
            URLData urlData = new URLData
            {
                Title = this.Title,
                Url = this.Url,
                Vpn = this.Vpn,
                CategoryName = Category,
                BookMark = false,
                SelectThis = false,
            };

            URLs.Add(urlData);
            UrlSave(urlData);

            URLValueClear();
        }

        public void URLLoad()
        {
            string text;
            string[] items;
            string[] splits = new string[1];
            splits[0] = OVERHEAD;

            try
            {
                foreach (var txtFile in urlDirectoryInfo.GetFiles())
                {
                    text = File.ReadAllText(URL_FILE_PATH + txtFile);
                    items = text.Split(splits, StringSplitOptions.RemoveEmptyEntries);

                    URLData url = new URLData
                    {
                        BookMark = Convert.ToBoolean(items[0]),
                        Vpn = Convert.ToBoolean(items[1]),
                        Title = items[2],
                        Url = items[3],
                        CategoryName = items[4],
                        SelectThis = false,
                    };
                    URLs.Add(url);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + DateTime.Now.ToLongTimeString());
            }
        }
        public bool UrlCheck(object obj)
        {
            if (String.IsNullOrWhiteSpace(Title) || String.IsNullOrWhiteSpace(Url))
            {
                return false;
            }
            if (!Uri.TryCreate(this.Url, UriKind.Absolute, out Uri uri))
            {
                return false;
            }
            if (URLs.Any(x => x.Title.Equals(this.Title) || x.Url.Equals(this.Url)))
            {
                return false;
            }
            return true;
        }
        private void URLValueClear()
        {
            Vpn = false;
            Category = CategoryNames[0];
            Title = null;
            Url = null;
        }
        private void URLDelete()
        {
            foreach (var url in URLs.Where(x => x.SelectThis == true))
            {
                FileInfo file = new FileInfo(URL_FILE_PATH + url.Title + URL_FILE_NAME);

                if (file.Exists)
                {
                    file.Delete();
                }
            }
            URLs.Clear();
            URLLoad();

        }
        private bool URLDeleteCheck(object obj)
        {
            //if(!URLs.Any(x => x.SelectThis == true)) {
            //    return false;
            //}
            return true;
        }
    }
}