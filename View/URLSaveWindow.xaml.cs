using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using URLSaving.Model;
using URLSaving.ViewModel;

namespace URLSaving.View
{
    /// <summary>
    /// URLSaveWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class URLSaveWindow : Window
    {
        public URLSaveWindow()
        {
            InitializeComponent();
            this.DataContext = new URLSaveViewModel();
        }

        //public NotifyIcon notify;
        //public URLSaveWindow()
        //{
        //    InitializeComponent();
        //    this.DataContext = new URLSaveViewModel();
        //    this.Loaded += URLSaveWindow_Loaded;
        //    //this.Closing += URLSaveWindow_Closing;
        //}

        ////private void URLSaveWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        ////{
        ////    notify.Visible = true;
        ////    this.Visibility = Visibility.Collapsed;
        ////    e.Cancel = true;
        ////    return;
        ////}
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    e.Cancel = true;
        //    this.Hide();
        //    base.OnClosing(e);
        //}
        //protected override void OnStateChanged(EventArgs e)
        //{
        //    if(WindowState.Minimized.Equals(WindowState))
        //    {
        //        this.Hide();
        //    }
        //    base.OnStateChanged(e);
        //}

        //private void URLSaveWindow_Loaded(object sender, RoutedEventArgs e)
        //{

        //    try
        //    {
        //        System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
        //        notify = new NotifyIcon();
        //        //notify.Icon = new System.Drawing.Icon(@"logo.ico");
        //        notify.ContextMenu = menu;
        //        notify.Text = "URLSave";
        //        //notify.DoubleClick += Notify_DoubleClick;

        //        System.Windows.Forms.MenuItem item1 = new System.Windows.Forms.MenuItem();
        //        menu.MenuItems.Add(item1);
        //        item1.Index = 0;
        //        item1.Text = "프로그램 종료";
        //        item1.Click += delegate (object click, EventArgs args)
        //        {
        //            System.Windows.Application.Current.Shutdown();
        //            //notify.Dispose();
        //        };

        //        System.Windows.Forms.MenuItem item2 = new System.Windows.Forms.MenuItem();
        //        menu.MenuItems.Add(item2);
        //        item1.Index = 0;
        //        item2.Text = "프로그램 설정";
        //        item2.Click += delegate (object click, EventArgs args)
        //        {
        //            this.Show();
        //            this.WindowState = WindowState.Normal;
        //        };

        //        this.Close();

        //    } 
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex + DateTime.Now.ToLongTimeString());
        //    }
        //}

        //private void Notify_DoubleClick(object sender, EventArgs e)
        //{
        //    this.Show();
        //    this.WindowState = WindowState.Normal;
        //    this.Visibility = Visibility.Visible;
        //}
        //NotifyIcon ni = new NotifyIcon();

        //public MainWindow()
        //{
        //    InitializeComponent();

        //    System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();    // Menu 객체

        //    System.Windows.Forms.MenuItem item1 = new System.Windows.Forms.MenuItem();    // Menu 객체에 들어갈 각각의 menu
        //    item1.Index = 0;
        //    item1.Text = "Menu01";    // menu 이름

        //    item1.Click += delegate (object click, EventArgs eClick)    // menu 의 클릭 이벤트 등록
        //    {
        //        Method1();
        //    }
        //    System.Windows.Forms.MenuItem item2 = new System.Windows.Forms.MenuItem();    // menu 객체에 들어갈 각 menu
        //    item2.Index = 1;
        //    item2.Text = "Menu02";    // menu 이름
        //    item2.Click += delegate (object click, EventArgs eClick)    // menu의 클릭 이벤트 등록
        //    {
        //        Method2();
        //    }


        //    menu.MenuItems.Add(item1);    // Menu 객체에 각각의 menu 등록
        //    menu.MenuItems.Add(item2);    // Menu 객체에 각각의 menu 등록

        //    //ni.Icon = new System.Drawing.Icon(new Uri("path"));    // 아이콘 등록 1번째 방법
        //    //ni.Icon = Properties.Resources.SampleIcon;    // 아이콘 등록 2번째 방법
        //    ni.Visible = true;
        //    ni.DoubleClick += delegate (object senders, EventArgs args)    // Tray icon의 더블 클릭 이벤트 등록
        //    {
        //        DoubleMethod();
        //    };
        //    ni.ContextMenu = menu;    // Menu 객체 등록
        //    ni.Text = "WPF";    // Tray icon 이름

        //}
    }
}
