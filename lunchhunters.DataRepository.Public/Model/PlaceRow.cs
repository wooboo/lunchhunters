using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Samples.ServiceHosting.StorageClient;
using System.Data.Services.Client;

namespace lunchhunters.Model
{
    /// <summary>
    /// This class allows DevtableGen to generate the correct table (named 'Membership') 
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
        Justification = "Class is used by devtablegen to generate database for the development storage tool")]
    public class PlacesDataServiceContext : TableStorageDataServiceContext
    {
        public IQueryable<PlaceRow> Places
        {
            get
            {
                return base.CreateQuery<PlaceRow>("Places");
            }
        }
    }
    [CLSCompliant(false)]
    public class PlaceRow : TableStorageEntity
    {
        public PlaceRow(string group)
        {
            Group = group;
        }
        public string Group 
        {
            get
            {
                return PartitionKey;
            }
            set
            {
                PartitionKey = value;
            }
        }
        private Guid _id;
        public Guid ID { get
        {
            return _id;
        }
            set
            {
                _id = value;
                RowKey = _id.ToString();
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // applicationName + userName is partitionKey
        // roleName is rowKey

        public PlaceRow()
            : base()
        {

        }
       
    }




   


}
