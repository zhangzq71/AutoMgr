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
        AutoMgrSvc.AutoMgrDbEntities ctx;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            db();
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

            inventories = new DataServiceCollection<AutoMgrSvc.inventory>();
            inventories.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(complete);
            var query = from inv in ctx.inventory.Expand("shelf_io/shelf/goods") select inv;
            inventories.LoadAsync(query);
            //inventories.Load(from inv in ctx.inventory select inv);
            //foreach (var inv in inventories)
            //{
            //    int i = inv.id;
            //}
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
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
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