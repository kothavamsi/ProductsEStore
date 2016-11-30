using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.Core;

namespace ProductsEStore.Controllers
{
    public class TopSellersController : MyBaseController
    {
        public ActionResult Index()
        {
            BaseModel.NavigationBar.RenderSortByListMenu = false;
            return View("index", BaseModel);
        }
    }
}
