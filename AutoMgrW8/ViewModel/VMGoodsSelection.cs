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
using Microsoft.Practices.ServiceLocation;

namespace AutoMgrW8.ViewModel
{
    public class VMGoodsSelection : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly AutoMgrSvc.AutoMgrDbEntities _context;// = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));

        public VMGoodsSelection(INavigationService navigationService, AutoMgrSvc.AutoMgrDbEntities context)
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
            _context = context;

            GoodsOutput = new ObservableCollection<AutoMgrSvc.goods>();
        }

        public string GoodsName
        {
            get { return _goodsName; }
            set
            {
                if (_goodsName != value)
                {
                    _goodsName = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string _goodsName;

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
                            goods.shelf[0].shelf_io.Add(new AutoMgrSvc.shelf_io() { quantity = 10, datetime = System.DateTime.Now, });
                            //_context.BeginSaveChanges(result => {
                            //    _context.EndSaveChanges(result);
                            //}, null);
                            GoodsOutput.Add(goods);
                        }
                    });
                }

                return _goodsSelectionChanged;
            }
        }
        private RelayCommand<object> _goodsSelectionChanged;

        public RelayCommand CommandGoodsFilter
        {
            get
            {
                if (_commandGoodsFilter == null)
                {
                    _commandGoodsFilter = new RelayCommand(() =>
                    {
                        if (!string.IsNullOrEmpty(GoodsName))
                        {
                            var query = from goods in _context.goods.Expand("shelf") where (goods.name.Contains(_goodsName) || goods.alias.Contains(_goodsName)) select goods;
                            Goodses = new IncrementalDbLoading<AutoMgrSvc.goods>(query);
                        }
                        else
                        {
                            var query = from goods in _context.goods.Expand("shelf") select goods;
                            Goodses = new IncrementalDbLoading<AutoMgrSvc.goods>(query);
                        }
                    });
                }

                return _commandGoodsFilter;
            }
        }
        private RelayCommand _commandGoodsFilter;

        public RelayCommand CommandOk
        {
            get
            {
                if (_commandOk == null)
                    _commandOk = new RelayCommand(() =>
                    {
                        foreach (var goods in GoodsOutput)
                        {
                            ServiceLocator.Current.GetInstance<VMReposityOutput>().GoodsOutput.Add(goods);
                        }

                        GoodsOutput = new ObservableCollection<AutoMgrSvc.goods>();
                        _navigationService.GoBack();
                    });

                return _commandOk;
            }
        }
        private RelayCommand _commandOk;

        public RelayCommand CommandCancel
        {
            get
            {
                if (_commandCancel == null)
                    _commandCancel = new RelayCommand(() =>
                    {
                        GoodsOutput = new ObservableCollection<AutoMgrSvc.goods>();
                        _navigationService.GoBack();
                    });

                return _commandCancel;
            }
        }
        private RelayCommand _commandCancel;

        public RelayCommand<AutoMgrSvc.goods> CommandRemove
        {
            get
            {
                if (_commandRemove == null)
                    _commandRemove = new RelayCommand<AutoMgrSvc.goods>((goods) =>
                    {
                        GoodsOutput.Remove(goods);
                    });

                return _commandRemove;
            }
        }
        private RelayCommand<AutoMgrSvc.goods> _commandRemove;
    }
}
