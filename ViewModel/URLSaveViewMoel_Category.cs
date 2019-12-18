using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using URLSaving.Model;
using URLSaving.ViewModel.Interface;

namespace URLSaving.ViewModel
{
    public partial class URLSaveViewModel : ICategoryManager
    {
        public ObservableCollection<Category> Categories { get; private set; }

        public DirectoryInfo categoryDirectoryInfo;
        private const string CATEGORY_FILE_NAME = "_category.txt";
        private readonly string CATEGORY_FILE_PATH;

        private string selectCategory;
        public string SelectCategory
        {
            get
            {
                return selectCategory;
            }
            set
            {
                selectCategory = value;
                CategoryFilterCommand();
            }
        }

        private string name;
        public string Name 
        { 
            get 
            {
                return name;
            } 
            set 
            {
                name = value;
                OnPropertyChanged(nameof(this.Name));
            }
        }

        public void AddCategory()
        {
            CategoryValuePush();
            CategoryValueClear();
        }

        public bool CategoryCheck(object obj)
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                return false;
            }
            if (Categories.Any(x => x.Name.Equals(this.Name)))
            {
                return false;
            }
            return true;
        }
        private void CategoryValueClear()
        {
            Name = null;
            //SelectCategory = CATEGORY_ALL;
        }
        private void CategoryValuePush()
        {
            Category category = new Category
            {
                Name = Name,
                Kind = ECategory.Other
            };

            Categories.Add(category);
            CategorySave(category);
            CategoryNames.Add(Name);
        }

        private void CategoryFilterCommand()
        {
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(URLs);

            cv.Filter = new Predicate<object>(CategoryFilter);
        }
        private bool CategoryFilter(object item)
        {
            URLData category = item as URLData;

            if (SelectCategory.Equals(CATEGORY_ALL))
            {
                return true;
            }
            if((category.BookMark == true) && (SelectCategory.Equals(CATEGORY_STAR)))
            {
                return true;
            }

            if(category.CategoryName.Equals(SelectCategory))
            {
                return true;
            }

            category.SelectThis = false;
            return false;
        }

        private bool CategoryFilterCheck(object item)
        {
            if(SelectCategory == null)
            {
                return false;
            }
            return true;
        }

        private bool CategoryDeleteCheck(object obj)
        {
            if(SelectCategory == null)
            {
                return false;
            }
            if(SelectCategory.Equals(CATEGORY_ALL))
            {
                return false;
            }
            else if(SelectCategory.Equals(CATEGORY_STAR))
            {
                return false;
            }
            return true;
        }

        private void CategorySave(Category category)
        {
            using StreamWriter streamWriter = new StreamWriter(CATEGORY_FILE_PATH + category.Name + CATEGORY_FILE_NAME, false);
            streamWriter.Write(category.Name + OVERHEAD);
            streamWriter.Write(category.Kind);
        }

        private void CategoryDelete()
        {
            string selete = SelectCategory;
            FileInfo fileInfo = new FileInfo(CATEGORY_FILE_PATH + selete + CATEGORY_FILE_NAME);
            if(fileInfo.Exists)
            {
                fileInfo.Delete();
                Categories.Remove(Categories.Where(x => x.Name.Equals(selete)).Single());
                CategoryNames.Remove(CategoryNames.Where(x => x.Equals(selete)).Single());
            }
        }

        private void CategoryLoad()
        {
            string text;
            string[] items;
            string[] splits = new string[1];
            splits[0] = OVERHEAD;

            try
            {
                foreach (var txtFile in categoryDirectoryInfo.GetFiles())
                {
                    text = File.ReadAllText(CATEGORY_FILE_PATH + txtFile);
                    items = text.Split(splits, StringSplitOptions.RemoveEmptyEntries);

                    Category category = new Category
                    {
                        Name = items[0],
                        Kind = (ECategory)Enum.Parse(typeof(ECategory), items[1])
                    };

                    
                    Categories.Add(category);
                    CategoryNames.Add(category.Name);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex + DateTime.Now.ToLongTimeString());
            }
        }
    }
}
