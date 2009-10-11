using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lunchhunters.Model;

namespace lunchhunters
{
    public interface IPlacesRepository
    {
        IQueryable<PlaceRow> GetQuery();
        PlaceRow Create();
        void Save(PlaceRow row);
        void Delete(PlaceRow row);
    }
}
