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
            //_context = context;

            GoodsOutput = new ObservableCollection<AutoMgrSvc.goods>();
        }

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

        public AutoMgrSvc.staff ApplyStaff
        {
            get { return _applyStaff; }
            set
            {
                _applyStaff = value;
                RaisePropertyChanged();
            }
        }
        private AutoMgrSvc.staff _applyStaff;

        /// <summary>
        /// 确定命令
        /// </summary>
        public RelayCommand CommandOk
        {
            get
            {
                if (_commandOk == null)
                    _commandOk = new RelayCommand(() =>
                    {
                        foreach (var goods in GoodsOutput)
                        {
                            AutoMgrSvc.shelf_io sio = goods.shelf[0].shelf_io[0];
                            sio.shelf = goods.shelf[0];
                            sio.shelf_id = sio.shelf.id;

                            _context.AddObject("shelf_io", sio);
                        }

                        _context.BeginSaveChanges(result => {
                            _context.EndSaveChanges(result);
                        }, null);

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

        public RelayCommand CommandSelectGoods
        {
            get
            {
                if (_commandSelectGoods == null)
                    _commandSelectGoods = new RelayCommand(() =>
                        {
                            _navigationService.Navigate(typeof(Pages.GoodsSelectionPage), GoodsOutput);
                        });

                return _commandSelectGoods;
            }
        }
        private RelayCommand _commandSelectGoods;
    }
}
