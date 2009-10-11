using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using lunchhunters.Models.Location;
using lunchhunters.Model;

namespace lunchhunters.Controllers
{
    public partial class LocationController : Controller
    {
        private IRepository<PlaceRow> _placesRepository;
        //
        // GET: /Location/

        public LocationController()
            : this(new PlacesCloudRepository("LunchNunters"))
        {

        }
        public LocationController(IRepository<PlaceRow> placesRepository)
        {
            _placesRepository = placesRepository;
        }
        public virtual ActionResult Index(int? size, string partition, string row)
        {
            var model = new IndexViewModel();
            model.Places = new PagedResults<PlaceRow>(_placesRepository.GetQuery(), size ?? 10, partition, row);
            return View(model);
        }

        public virtual ActionResult Details(Guid id, bool editing)
        {
            var model = new DetailsViewModel();
            model.Place = _placesRepository.GetQuery().Where(o => o.ID == id).FirstOrDefault();
            if (editing)
                return View(MVC.Location.Views.Edit, model);
            else
                return View(MVC.Location.Views.Details, model);
        }
        public virtual ActionResult Create()
        {
            var model = new DetailsViewModel();
            model.Place = _placesRepository.Create();
            return View(MVC.Location.Views.Edit, model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Save(Guid id)
        {
            
            var item =  _placesRepository.GetQuery().Where(o => o.ID == id).FirstOrDefault();
            if (item == null)
                item = new PlaceRow("LunchHunters")
                {
                    ID = id,
                };
            item.Name = Request.Form["name"];
            item.Latitude = Request.Form["lat"];
            item.Longitude = Request.Form["lng"];
            _placesRepository.Save(item);
            return RedirectToAction(MVC.Location.Details(id, false));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Delete(Guid id)
        {
            var item =  _placesRepository.GetQuery().Where(o => o.ID == id).FirstOrDefault();
            _placesRepository.Delete(item);
            return RedirectToAction(MVC.Location.Index());
        }

    }
}
