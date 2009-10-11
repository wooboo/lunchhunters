using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Samples.ServiceHosting.StorageClient;

namespace lunchhunters
{
    public abstract class BaseRepository<T> : IRepository<T> where T:TableStorageEntity
    {
        public BaseRepository()
        {
            Initialize();
        }
        #region Member variables and constants

        internal const int NumRetries = 3;

        // member variables shared between most providers
        private string _partition;
        private string _accountName;
        private string _sharedKey;
        private string _tableName;
        private string _tableServiceBaseUri;
        private TableStorage _tableStorage;
        private object _lock = new object();
        private RetryPolicy _tableRetry = RetryPolicies.RetryN(NumRetries, TimeSpan.FromSeconds(1));
        // private ProviderRetryPolicy _providerRetry = ProviderRetryPolicies.RetryN(NumRetries, TimeSpan.FromSeconds(1));

        #endregion

        #region Properties

        public string Partition
        {
            get { return _partition; }
            set
            {
                lock (_lock)
                {
                    _partition = value;
                }
            }
        }

        #endregion

        #region Public methods

        // RoleProvider methods
        public void Initialize()
        {

            // structure storage-related properties
            Partition = GetEntityPartition();// "LunchHunters";
            _tableName = GetTableName();//Utils.GetConfigSetting("placesTableName");

            StorageAccountInfo info = null;

            info = StorageAccountInfo.GetDefaultTableStorageAccountFromConfiguration(true);

            info.CheckComplete();
            _tableStorage = TableStorage.Create(info);
            _tableStorage.RetryPolicy = _tableRetry;
            if (_tableStorage.TryCreateTable(_tableName))
            {
                //var ctx = _tableStorage.GetDataServiceContext();

                //var place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.1"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.1"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.2"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.3"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.4"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.5"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.6"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.7"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.8"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.9"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //place1 = new PlaceRow(Group)
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "Some place no.10"
                //};
                //place1.EnsureValidity();
                //ctx.AddObject(_tableName, place1);
                //ctx.SaveChanges();

            }

        }
        protected abstract string GetTableName();
        protected abstract string GetEntityPartition();
        private TableStorageDataServiceContext CreateDataServiceContext()
        {
            return _tableStorage.GetDataServiceContext();
        }


        public IQueryable<T> GetQuery()
        {
            TableStorageDataServiceContext svc = CreateDataServiceContext();
            var queryObj = svc.CreateQuery<T>(_tableName);

            return queryObj;
        }

        #endregion

        #region IPlacesRepository Members


        public abstract T Create();

        public void Save(T row)
        {
            TableStorageDataServiceContext svc = CreateDataServiceContext();

            var res = GetQuery().Where(o => o.RowKey == row.RowKey && row.PartitionKey == row.PartitionKey).FirstOrDefault();
            if (res == null)
                svc.AddObject(_tableName, row);
            else
            {
                svc.AttachTo(_tableName, row, "*");
                svc.UpdateObject(row);

            }
            svc.SaveChangesWithRetries();
        }
        
        public void Delete(T row)
        {
            TableStorageDataServiceContext svc = CreateDataServiceContext();
            svc.AttachTo(_tableName, row,"*");
            svc.DeleteObject(row);
            svc.SaveChangesWithRetries();

        }

        #endregion
    }
}
