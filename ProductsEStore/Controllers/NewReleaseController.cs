using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;

namespace ProductsEStore.Controllers
{
    public class NewReleaseController : MyBaseController
    {
        public ActionResult Index()
        {
            // Dependency Injection
            var newRelease = new NewRelease(_repository);
            newRelease.NavigationBar.RenderSortByListMenu = false;
            return View("Index", newRelease);
        }

    }
}
