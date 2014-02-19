using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AutoMgrW8.Helpers;

namespace AutoMgrW8.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            _navigationService = navigationService;
        }

        public RelayCommand<string> FeatureCommand
        {
            get
            {
                if (_FeatureCommand == null)
                {
                    _FeatureCommand = new RelayCommand<string>(feature =>
                    {
                        switch (feature)
                        {
                            case "Repair":
                                _navigationService.Navigate(typeof(Pages.RepairFtyPage));
                                break;

                            case "Reposity":
                                _navigationService.Navigate(typeof(Pages.ReposityMgrPage));
                                break;
                        }
                    });
                }

                return _FeatureCommand;
            }
        }

        RelayCommand<string> _FeatureCommand;
        
    }
}