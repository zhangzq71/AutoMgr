using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMgrW8.ViewModel
{
    public class UIItem
    {
        public UIItem(string controlType)
        {
            ControlType = controlType;
        }
        public string ControlType { get; set; }
    }

    public class UIItemGroup
    {
        public string Title { get; set; }
        public ObservableCollection<UIItem> Items { get; set; }
    }

    public class UIData
    {
        private static UIData _uiData = new UIData();

        public static IEnumerable<UIItemGroup> GetReposityMgrUIData()
        {
            ObservableCollection<UIItemGroup> rtn = new ObservableCollection<UIItemGroup>();

            ObservableCollection<UIItem> apply = new ObservableCollection<UIItem>();        // 出仓
            ObservableCollection<UIItem> income = new ObservableCollection<UIItem>();       // 入仓
            ObservableCollection<UIItem> invertory = new ObservableCollection<UIItem>();    // 盘点

            apply.Add(new UIItem("出仓"));
            income.Add(new UIItem("入仓"));
            invertory.Add(new UIItem("盘点"));

            rtn.Add(new UIItemGroup() { Title = "出仓", Items = apply, });
            rtn.Add(new UIItemGroup() { Title = "入仓", Items = income, });
            rtn.Add(new UIItemGroup() { Title = "盘点", Items = invertory, });

            return rtn;
        }
    }
}
