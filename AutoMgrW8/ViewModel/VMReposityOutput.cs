using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AutoMgrW8.Helpers;

namespace AutoMgrW8.ViewModel
{
    public class VMReposityOutput : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public VMReposityOutput(INavigationService navigationService)
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
    }
}
