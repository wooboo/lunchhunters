using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Client;

namespace lunchhunters
{
    public class PagedResults<T> : List<T>
    {
        private string _nextPartition;
        public string NextPartition
        {
            get { return _nextPartition; }
        }

        private string _nextRow;
        public string NextRow
        {
            get { return _nextRow; }
        }
        public bool NextAvailable { get; set; }
        public bool BackAvailable { get; set; }
        public PagedResults(IQueryable<T> query, int pageSize, string partitionKey, string rowKey)
        {
            var dsquery = query as DataServiceQuery<T>;
            //dsquery = dsquery.AddQueryOption("inlinecount", "allpages");
            if (partitionKey != null && rowKey != null)
            {
                dsquery = dsquery.AddQueryOption(
                    "NextPartitionKey", partitionKey).AddQueryOption(
                    "NextRowKey", rowKey);
            }
            var res = ((DataServiceQuery<T>)dsquery.Take(pageSize)).Execute();
            var qor = (QueryOperationResponse)res;

            qor.Headers.TryGetValue("x-ms-continuation-NextPartitionKey",
                out _nextPartition);
            qor.Headers.TryGetValue("x-ms-continuation-NextRowKey",
                out _nextRow);
            AddRange(res);
            if (partitionKey == null || rowKey == null)
                BackAvailable = false;
            else
                BackAvailable = true;

            if (_nextPartition == null || _nextRow == null)
                NextAvailable = false;
            else
                NextAvailable = true;
        }
    }
}
