using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Services.Client;

namespace AutoMgrW8
{
    public class IncrementalDbLoading<T>: IncrementalLoadingBase<T>
    {
        bool _hasMoreItems = true;
        AutoMgrSvc.AutoMgrDbEntities _context = new AutoMgrSvc.AutoMgrDbEntities(new Uri("http://192.168.0.101:23796/Service/AutoMgrDbSvc.svc/"));
        IQueryable<T> _query;

        public IncrementalDbLoading(IQueryable<T> query)
        {
            _query = query;
        }

        protected async override Task<IList<T>> LoadMoreItemsOverrideAsync(System.Threading.CancellationToken c, uint count)
        {
            DataServiceCollection<T> results = new DataServiceCollection<T>();
            await results.AsyncQuery(_query);
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

            _hasMoreItems = results.Count >= count ? true : false;

            return results;
        }

        protected override bool HasMoreItemsOverride()
        {
            return _hasMoreItems;
        }
    }
}
