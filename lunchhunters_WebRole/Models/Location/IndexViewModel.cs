using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lunchhunters.Model;

namespace lunchhunters.Models.Location
{
    public class IndexViewModel
    {
        public PagedResults<PlaceRow> Places { get; set; }
    }
}
