using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace AutoMgrW8.Helpers
{
    public class RFCardReader : IDisposable
    {
        DispatcherTimer _timer = new DispatcherTimer();
        Action _action;

        public RFCardReader(Action action)
        {
            _action = action;

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            _timer.Tick += new EventHandler<object>((sender, eventArgs) =>
                {
                    //if (_cardId.Length < 8)
                    //    _cardId = string.Empty;
                    //else
                    //{
                    //    System.Diagnostics.Debug.WriteLine(_cardId);
                    //    action();
                    //    _cardId = string.Empty;
                    //}

                    _timer.Stop();
                });

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if (!_timer.IsEnabled)
                _timer.Start();

            switch (args.VirtualKey)
            {
                case Windows.System.VirtualKey.Number0:
                    _cardId += '0';
                    break;

                case Windows.System.VirtualKey.Number1:
                    _cardId += '1';
                    break;

                case Windows.System.VirtualKey.Number2:
                    _cardId += '2';
                    break;

                case Windows.System.VirtualKey.Number3:
                    _cardId += '3';
                    break;

                case Windows.System.VirtualKey.Number4:
                    _cardId += '4';
                    break;

                case Windows.System.VirtualKey.Number5:
                    _cardId += '5';
                    break;

                case Windows.System.VirtualKey.Number6:
                    _cardId += '6';
                    break;

                case Windows.System.VirtualKey.Number7:
                    _cardId += '7';
                    break;

                case Windows.System.VirtualKey.Number8:
                    _cardId += '8';
                    break;

                case Windows.System.VirtualKey.Number9:
                    _cardId += '9';
                    break;

                case Windows.System.VirtualKey.Enter:
                    _action();
                    break;
            }

            //switch (e.Key)
            //{
            //    case Windows.System.VirtualKey.Number0:
            //    case Windows.System.VirtualKey.Number1:
            //    case Windows.System.VirtualKey.Number2:
            //    case Windows.System.VirtualKey.Number3:
            //    case Windows.System.VirtualKey.Number4:
            //    case Windows.System.VirtualKey.Number5:
            //    case Windows.System.VirtualKey.Number6:
            //    case Windows.System.VirtualKey.Number7:
            //    case Windows.System.VirtualKey.Number8:
            //    case Windows.System.VirtualKey.Number9:
            //        _cardId += e.Key.ToString().Last();
            //        break;
            //}
        }

        public string CardID
        {
            get { return _cardId; }
            private set
            {
                _cardId = value;
            }
        }
        string _cardId = string.Empty;

        public void Dispose()
        {
            System.Diagnostics.Debug.WriteLine("RFCardReader Dispose...");

            Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
        }
    }
}
