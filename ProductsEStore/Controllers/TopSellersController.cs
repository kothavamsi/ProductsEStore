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
            BaseModel.PageTitle = BaseModel.TitleTemplate.Replace("{{TITLE}}", "Top Sellers");
            return View("index", BaseModel);
        }
    }
}
