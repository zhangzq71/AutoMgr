using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AutoMgrWP.Resources;
using System.Data.Services.Client;

namespace AutoMgrWP
{
    public partial class MainPage : PhoneApplicationPage
    {
        DataServiceCollection<AutoMgrSvc.inventory> inventories;
        DataServiceCollection<AutoMgrSvc.goods> goodses;
        AutoMgrSvc.AutoMgrDbEntities ctx;

        private OpticalReaderLib.IProcessor _processor = null;
        private OpticalReaderLib.OpticalReaderTask _task = null;
        private OpticalReaderLib.OpticalReaderResult _taskResult = null;


        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            //db();

            ctx = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));
        }

        async void db()
        {
            ctx = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));

            //AutoMgrSvc.inventory inventory = new AutoMgrSvc.inventory();
            //var goods = from g in ctx.goods where g.id < 100 select g;
            //foreach (var gg in goods)
            //{
            //    if (gg.id == 1100)
            //        break;
            //}

            //inventories = new DataServiceCollection<AutoMgrSvc.inventory>();
            //inventories.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(complete);
            //var query = from inv in ctx.inventory select inv;
            //inventories.LoadAsync(query);
            ////inventories.Load(from inv in ctx.inventory select inv);
            ////foreach (var inv in inventories)
            ////{
            ////    int i = inv.id;
            ////}

            goodses = new DataServiceCollection<AutoMgrSvc.goods>();
            //goodses.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(goods_complete);
            var qry = (from goods in ctx.goods.Expand("shelf") select goods).Skip(1).Take(10);
            await goodses.AsyncQuery(qry);
            //goodses.LoadAsync(qry);
            foreach (var goods in goodses)
            {
                int i = goods.id;
            }
        }

        private void goods_complete(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (goodses.Continuation != null)
                {
                    goodses.LoadNextPartialSetAsync();
                }
                else
                {
                    foreach (var goods in goodses)
                    {
                        if (goods.id == 9999)
                            break;
                    }
                }
            }
        }

        private void complete(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (inventories.Continuation != null)
                {
                    inventories.LoadNextPartialSetAsync();
                }
                else
                {
                    foreach (var inv in inventories)
                    {
                        if (inv.id == 1000)
                            break;
                    }
                }
            }
        }


        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            try
            {
                if (_taskResult != null)
                {
                    var bg = new DataServiceCollection<AutoMgrSvc.barcode_goods>();
                    bg.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e1) => 
                    { 
                        if (e1.Error == null)
                        {
                            if (bg.Count > 0)
                                goods.Text = bg[0].goods.name;
                        }
                    });

                    var query = from bgs in ctx.barcode_goods.Expand("goods") where bgs.barcode == _taskResult.Text select bgs;
                    bg.LoadAsync(query);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (_task != null)
            {
                _task.Completed -= _task_Completed;
                _task.Dispose();
                _task = null;
            }

            _processor = new Helpers.CustomProcessor();

            _task = new OpticalReaderLib.OpticalReaderTask()
            {
                Processor = _processor,
                ShowDebugInformation = false,
                FocusInterval = new TimeSpan(0, 0, 0, 0, 1000),
                ObjectSize = new Windows.Foundation.Size(90, 90),
                RequireConfirmation = false
            };

            _task.Completed += _task_Completed;
            _task.Show();
        }

        void _task_Completed(object sender, OpticalReaderLib.OpticalReaderResult e)
        {
            _taskResult = e;

            System.Diagnostics.Debug.WriteLine(e.Text);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}