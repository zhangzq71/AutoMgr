using System;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using AutoMgrW8.Helpers;
using System.Data.Services.Client;
using Windows.UI.Xaml.Data;
using Microsoft.Practices.ServiceLocation;

namespace AutoMgrW8.ViewModel
{
    public class VMRepairFty : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly AutoMgrSvc.AutoMgrDbEntities _context = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));

        public VMRepairFty(INavigationService navigationService)
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
                _navigationService = navigationService;

                RepairCatalog = new CollectionViewSource();
            }
        }

        public bool Isediting
        {
            get { return _isEditing; }
            private set
            {
                _isEditing = value;
                RaisePropertyChanged();
            }
        }
        private bool _isEditing;

        public CollectionViewSource RepairItems
        {
            get { return _repairItems; }
            private set
            {
                _repairItems = value;
                RaisePropertyChanged();
            }
        }
        private CollectionViewSource _repairItems;

        public CollectionViewSource RepairCatalog
        {
            get { return _repairCatalog; }
            set
            {
                _repairCatalog = value;
                RaisePropertyChanged("RepairCatalog");
            }
        }
        private CollectionViewSource _repairCatalog;

        public AutoMgrSvc.repair RepairDetail
        {
            get { return _repairDetail; }
            set
            {
                _repairDetail = value;
                RaisePropertyChanged();
            }
        }
        private AutoMgrSvc.repair _repairDetail;

        /// <summary>
        /// 维修单号
        /// </summary>
        public string RepairNum
        {
            get { return _repairNum; }
            private set
            {
                _repairNum = value;
                RaisePropertyChanged();
            }
        }
        private string _repairNum;

        /// <summary>
        /// 维修项目名称
        /// </summary>
        public string RepairItemName
        {
            get { return _repairItemName; }
            private set
            {
                _repairItemName = value;
                RaisePropertyChanged();
            }
        }
        private string _repairItemName;

        /// <summary>
        /// 维修时段，从
        /// </summary>
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            private set
            {
                _dateFrom = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _dateFrom;

        /// <summary>
        /// 维修时段，到
        /// </summary>
        public DateTime DateTo
        {
            get { return _dateTo; }
            private set
            {
                _dateTo = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _dateTo;

        /// <summary>
        /// 搜索命令
        /// </summary>
        public RelayCommand CommandFilter
        {
            get
            {
                if (_commandFilter == null)
                {
                    _commandFilter = new RelayCommand(() =>
                    {
                    });
                }

                return _commandFilter;
            }
        }
        private RelayCommand _commandFilter;

        public RelayCommand CommandRefresh
        {
            get
            {
                if (_commandRefresh == null)
                {
                    _commandRefresh = new RelayCommand(() =>
                    {
                        System.Diagnostics.Debug.WriteLine("REFRESH");
                        var catas = new DataServiceCollection<AutoMgrSvc.repair_cate>();
                        catas.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) =>
                        {
                            if (e != null)
                            {
                                RepairCatalog = new CollectionViewSource() { Source = catas };
                            }
                        });
                        var qry = from cata in _context.repair_cate.Expand("repair_cate_item/repair_item") select cata;
                        catas.LoadAsync(qry);

                        var repairItems = new DataServiceCollection<AutoMgrSvc.repair_item>();
                        repairItems.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) =>
                        {
                            if (e != null)
                            {
                                RepairItems = new CollectionViewSource() { Source = repairItems };
                            }
                        });
                        var qry1 = from item in _context.repair_item select item;
                        repairItems.LoadAsync(qry1);
                    });
                }

                return _commandRefresh;
            }
        }
        private RelayCommand _commandRefresh;

        public RelayCommand<string> CommandButton
        {
            get
            {
                if (_commandButton == null)
                {
                    _commandButton = new RelayCommand<string>((btnTitle) =>
                    {
                        switch (btnTitle)
                        {
                            case "修车接车":
                                RepairDetail = new AutoMgrSvc.repair()
                                {
                                    branch_id = 1,
                                    recv_stuff_id = 1,
                                    recv_date = DateTime.Now,
                                    quote_only = false,
                                    repair_price = 0,
                                    parts_price = 0,
                                    discount = 0,
                                    real_price = 0,
                                    vehicle = new AutoMgrSvc.vehicle() 
                                    { 
                                        car_num = "12345",
                                        engine_num = "54321",
                                        frame_num = "9876543",
                                        brand = "东风日产",
                                        model = "A100",
                                        customer = new AutoMgrSvc.customer() 
                                        {
                                            company = "第一运输公司",
                                            address = "广州市",
                                            phone = "13316161002",
                                        }, 
                                    },
                                };
                                Isediting = true;
                                break;

                            case "取消接车":
                                Isediting = false;
                                break;
                        }
                    });
                }

                return _commandButton;
            }
        }
        private RelayCommand<string> _commandButton;
    }
}
