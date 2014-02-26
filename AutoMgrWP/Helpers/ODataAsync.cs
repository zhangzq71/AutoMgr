using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Services.Client;

namespace AutoMgrWP
{
    public class SimpleAsyncResult : IAsyncResult, IDisposable
    {
        ManualResetEvent waitHandle = new ManualResetEvent(false);

        public void Finish()
        {
            IsCompleted = true;
            waitHandle.Set();
            waitHandle.Dispose();
        }

        public void Dispose() { waitHandle.Dispose(); }

        public bool IsCompleted { get; private set; }
        public object AsyncState { get; set; }
        public bool CompletedSynchronously { get; set; }

        public WaitHandle AsyncWaitHandle { get { return waitHandle; } }
    }

    public static class OData
    {
        public static Task<DataServiceCollection<T>> AsyncQuery<T>(
               this DataServiceCollection<T> data, IQueryable<T> query = null)
        {
            var asyncr = new SimpleAsyncResult();
            Exception exResult = null;
            data.LoadCompleted += delegate(object sender, LoadCompletedEventArgs e)
            {
                exResult = e.Error;
                asyncr.Finish();
            };

            if (query == null)
                data.LoadAsync();
            else
                data.LoadAsync(query);

            return Task<DataServiceCollection<T>>.Factory.FromAsync(asyncr
                , r =>
                {
                    if (exResult != null)
                        throw new AggregateException("Async call problem", exResult);
                    return data;
                }
            );
        }
    }
}
