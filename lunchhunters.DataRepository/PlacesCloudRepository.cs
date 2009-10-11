using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Samples.ServiceHosting.StorageClient;
using System.Data.Services.Client;
using lunchhunters.Model;

namespace lunchhunters
{
    public class PlacesCloudRepository : BaseRepository<PlaceRow>, IRepository<PlaceRow>
    {
        string _partitionName;
        public PlacesCloudRepository(string partitionName):base()
        {
            _partitionName = partitionName;
        }

        public override PlaceRow Create()
        {
            return new PlaceRow(Partition)
            {
                ID = Guid.NewGuid()
            };
        }

        protected override string GetTableName()
        {
            return Utils.GetConfigSetting("placesTableName");
        }

        protected override string GetEntityPartition()
        {
            return _partitionName;
        }
    }
}

