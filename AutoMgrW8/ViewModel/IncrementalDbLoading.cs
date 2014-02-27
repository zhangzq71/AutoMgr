using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Services.Client;

namespace AutoMgrW8
{
    public class IncrementalDbLoading<T>: IncrementalLoadingBase
    {
        bool _hasMoreItems = true;
        AutoMgrSvc.AutoMgrDbEntities _context = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));
        IQueryable<T> _query;
        int _skip = 0;

        int _cnt = 0;

        public IncrementalDbLoading(IQueryable<T> query)
        {
            _query = query;
        }

        protected async override Task<IList<object>> LoadMoreItemsOverrideAsync(System.Threading.CancellationToken c, uint count)
        {
            DataServiceCollection<T> results = new DataServiceCollection<T>();
            await results.AsyncQuery(_query.Skip(_skip).Take((int)count));

            System.Diagnostics.Debug.WriteLine("count:{0}, cnt:{1}", count, _cnt);
            //results.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) => 
            //{ 
            //    if (e.Error == null)
            //    {
            //        if (results.Continuation != null)
            //        {
            //            results.LoadNextPartialSetAsync();
            //        }
            //    }
            //});
            //results.LoadAsync(_query);


            //var rtn = from j in results select j;

            _skip += (int)count;
            _hasMoreItems = results.Count >= count ? true : false;

            _cnt++;

            List<object> aa = new List<object>();
            foreach (var result in results)
                aa.Add(result);

            return aa;
        }

        protected override bool HasMoreItemsOverride()
        {
            return _hasMoreItems;
        }
    }
}
