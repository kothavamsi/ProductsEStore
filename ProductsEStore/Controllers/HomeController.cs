using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.WebApi;
using ProductsEStore.Core;
using ProductsEStore.Repository;

namespace ProductsEStore.Controllers
{
    public class HomeController : MyBaseController
    {
        IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string sort = "post-date", int pageNo = 1)
        {
            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.HomePageProducts,
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo,
                PageSize = BaseModel.Configuration.DisplaySettings.HomePage.Layout.PageSize
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productsViewLayout = GetProductsViewLayout(reqCriteria, repoResp);
            productsViewLayout.NavigationBar.RenderSortByListMenu = true;
            return View("DisplayResult", "_LayoutHome", productsViewLayout);
        }

        public ActionResult About()
        {
            return View("About", BaseModel);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            Contact contact = new Contact();
            return View("Contact", contact);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                return View("ContactSuccess", BaseModel);
            }
            else
            {
                _repository.SaveContact(contact);
                return View("Contact", contact);
            }
        }

        public ActionResult PrivacyPolicy()
        {
            return View("PrivacyPolicy", BaseModel);
        }

        public ActionResult FAQ()
        {
            return View("FAQ", BaseModel);
        }

        public ActionResult RSS()
        {
            return View("RSS", BaseModel);
        }

        public ActionResult DMCA()
        {
            return View("DMCA", BaseModel);
        }

        public ActionResult Donate()
        {
            return View("Donate", BaseModel);
        }

        public ActionResult Sitemap()
        {
            var siteMapData = new SiteMapData(_repository);
            return View("Sitemap", siteMapData);
        }
    }
}
