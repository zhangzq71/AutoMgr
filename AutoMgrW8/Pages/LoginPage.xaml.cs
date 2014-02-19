using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AutoMgrW8.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        Helpers.RFCardReader _rfCardReader = null;

        string _cardId = string.Empty;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (_rfCardReader == null)
            {
                _rfCardReader = new Helpers.RFCardReader(() =>
                {
                    this.Frame.Navigate(typeof(MainPage));
                });
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (_rfCardReader != null)
            {
                _rfCardReader.Dispose();
                _rfCardReader = null;
            }
        }
    }
}
