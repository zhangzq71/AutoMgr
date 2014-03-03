using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AutoMgrW8.Helpers;
using System.Data.Services.Client;

namespace AutoMgrW8.ViewModel
{
    public class MyData
    {
        public string name { get; set; }
    }

    public class VMReposityOutput : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        //private readonly AutoMgrSvc.AutoMgrDbEntities _context = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.1.200/Service/AutoMgrDbSvc.svc/"));
        private readonly AutoMgrSvc.AutoMgrDbEntities _context = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));

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

            GoodsOutput = new ObservableCollection<AutoMgrSvc.goods>();
        }

        public ObservableCollection<MyData> MyData
        {
            get
            {
                if (_mydata == null)
                {
                    _mydata = new ObservableCollection<MyData>();
                    _mydata.Add(new MyData() { name = "name1" });
                    _mydata.Add(new MyData() { name = "name2" });
                    _mydata.Add(new MyData() { name = "name3" });
                }

                return _mydata;
            }
        }
        private ObservableCollection<MyData> _mydata;

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string _barcode;

        public string GoodsName
        {
            get { return _goodsName; }
            set
            {
                if (_goodsName != value)
                {
                    _goodsName = value;
                    RaisePropertyChanged();

                    var query = from goods in _context.goods.Expand("shelf") where (goods.name.Contains(_goodsName) || goods.alias.Contains(_goodsName)) select goods;
                    Goodses = new IncrementalDbLoading<AutoMgrSvc.goods>(query);
                }
            }
        }
        private string _goodsName;

        public ObservableCollection<AutoMgrSvc.goods> GoodsOutput
        {
            get { return _goodsOutput; }
            set
            {
                _goodsOutput = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<AutoMgrSvc.goods> _goodsOutput;

        public IncrementalDbLoading<AutoMgrSvc.goods> Goodses
        {
            get
            {
                //if (_goodses == null)
                //{
                //    _goodses = new DataServiceCollection<AutoMgrSvc.goods>();

                //    var query = (from goods in _context.goods select goods).Skip(1000).Take(50);
                //    _goodses.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) =>
                //    {
                //        if (e.Error == null)
                //            RaisePropertyChanged("Goodses");
                //    });
                //    _goodses.LoadAsync(query);

                if (_goodses == null)
                {
                    var query = from goods in _context.goods.Expand("shelf") select goods;
                    //await _goodses.AsyncQuery(query);
                    _goodses = new IncrementalDbLoading<AutoMgrSvc.goods>(query);
                }

                return _goodses;
            }

            set
            {
                _goodses = value;
                RaisePropertyChanged();
            }
        }
        private IncrementalDbLoading<AutoMgrSvc.goods> _goodses;

        public RelayCommand<object> GoodsSelectionChanged
        {
            get
            {
                if (_goodsSelectionChanged == null)
                {
                    _goodsSelectionChanged = new RelayCommand<object>(param =>
                    {
                        if (param.GetType() == typeof(AutoMgrSvc.goods))
                        {
                            AutoMgrSvc.goods goods = param as AutoMgrSvc.goods;
                            GoodsOutput.Add(goods);
                        }
                    });
                }

                return _goodsSelectionChanged;
            }
        }
        private RelayCommand<object> _goodsSelectionChanged;
    }
}
