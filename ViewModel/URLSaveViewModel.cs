using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;
using URLSaving.Model;
using URLSaving.ViewModel.Commands;
using URLSaving.ViewModel.Interface;

namespace URLSaving.ViewModel
{
    public partial class URLSaveViewModel : INotifyPropertyChanged
    {
        private const string OVERHEAD = ",&*^%@#";
        private const string CATEGORY_ALL = "모두";
        private const string CATEGORY_STAR = "즐겨찾기";
        private const string CATEGORY_NONE = "없음";

        public ObservableCollection<string> CategoryNames { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public URLSaveViewModel()
        {
            CATEGORY_FILE_PATH = @"Data\Category\";

            Start();
        }

        private void Start()
        {
            Setting();

            Load();

            URLValueClear();
            CategoryValueClear();
        }

        private void Setting()
        {
            urlDirectoryInfo = new DirectoryInfo(URL_FILE_PATH);
            categoryDirectoryInfo = new DirectoryInfo(CATEGORY_FILE_PATH);

            UrlAddCommand = new BtnCommand(UrlAdd, UrlCheck);
            CategoryAddCommand = new BtnCommand(AddCategory, CategoryCheck);
            SearchCategory = new BtnCommand(CategoryFilterCommand, CategoryFilterCheck);
            DeleteCategory = new BtnCommand(CategoryDelete, CategoryDeleteCheck);
            DeleteUrl = new BtnCommand(URLDelete, URLDeleteCheck);

            CategoryNames = new ObservableCollection<string>()
            {
                CATEGORY_NONE,
            };

            Categories = new ObservableCollection<Category>()
            {
                new Category(CATEGORY_ALL, ECategory.All),
                new Category(CATEGORY_STAR, ECategory.BookMark)
            };
            URLs = new ObservableCollection<URLData>();
        }
        private void Load()
        {
            URLLoad();
            CategoryLoad();
        }
        public void OnPropertyChanged(string s)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

    }
}
