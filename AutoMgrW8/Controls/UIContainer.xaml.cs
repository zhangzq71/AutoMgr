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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AutoMgrW8.Controls
{
    public sealed partial class UIContainer : UserControl
    {
        public UIContainer()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty ControlTypeProperty =
            DependencyProperty.Register("ControlType", typeof(string), typeof(UIContainer), new PropertyMetadata("", SelectedText_PropertyChangedCallback));

        private static void SelectedText_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string val = e.NewValue as string;

            switch (val)
            {
                case "出仓":
                    ((UIContainer)d).placeHolder.Content = new Controls.ReposityOut();
                    break;

                case "入仓":
                    ((UIContainer)d).placeHolder.Content = new Controls.ReposityIn();
                    break;

                case "盘点":
                    ((UIContainer)d).placeHolder.Content = new Controls.ReposityInventory();
                    break;
            }
        }

        public string ControlType
        {
            get { return (string)GetValue(ControlTypeProperty); }
            set { SetValue(ControlTypeProperty, value); }
        }
    }
}
