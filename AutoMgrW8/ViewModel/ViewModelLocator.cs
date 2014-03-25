/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:AutoMgrW8"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using AutoMgrW8.Helpers;

namespace AutoMgrW8.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<INavigationService, Design.DesignNavigationService>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
                SimpleIoc.Default.Register<AutoMgrSvc.AutoMgrDbEntities>(() =>
                {
#if USE_SERVER
                    return new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.1.200:8123/Service/AutoMgrDbSvc.svc/"));
#else
                    return new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://localhost:23796/Service/AutoMgrDbSvc.svc/"));
#endif
                });

                //SimpleIoc.Default.Register<AutoMgrSvc.AutoMgrDbEntities>(() => new AutoMgrSvc.AutoMgrDbEntities(new System.Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/")));
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<VMReposityOutput>();
            SimpleIoc.Default.Register<VMGoodsSelection>();
            SimpleIoc.Default.Register<VMRepairFty>();
        }

        public VMRepairFty VMRepairFty
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMRepairFty>();
            }
        }

        public VMGoodsSelection VMGoodsSelection
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMGoodsSelection>();
            }
        }

        public VMReposityOutput VMReposityOutput
        {
            get
            {
                return ServiceLocator.Current.GetInstance<VMReposityOutput>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}