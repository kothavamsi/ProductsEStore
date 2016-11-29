using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;

namespace ProductsEStore.Controllers
{
    public class MostReviewsController : MyBaseController
    {
        //
        // GET: /MostReviews/

        public ActionResult Index()
        {
            // Dependency Injection
            var mostReviews = new MostReviews(_repository);
            mostReviews.NavigationBar.RenderSortByListMenu = false;
            return View("Index", mostReviews);
        }

    }
}
