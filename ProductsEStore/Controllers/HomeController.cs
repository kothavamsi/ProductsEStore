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
                RequestMode = RequestMode.All,
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo,
                PageSize = 24
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productViewLayout = new ProductsViewLayout(reqCriteria, repoResp, 6);
            productViewLayout.NavigationBar.RenderSortByListMenu = true;
            return View("ProductGridViewResult", "_HomeLayout", productViewLayout);
        }

        public ActionResult About()
        {
            BaseModel.NavigationBar.RenderSortByListMenu = false;
            return View("About", BaseModel);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            Contact contact = new Contact();
            contact.NavigationBar.RenderSortByListMenu = false;
            return View("Contact", contact);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {

            if (ModelState.IsValid)
            {
                BaseModel.NavigationBar.RenderSortByListMenu = false;
                return View("ContactSuccess", BaseModel);
            }
            else
            {
                _repository.SaveContact(contact);
                contact.NavigationBar.RenderSortByListMenu = false;
                return View("Contact", contact);
            }
        }

        public ActionResult PrivacyPolicy()
        {
            BaseModel.NavigationBar.RenderSortByListMenu = false;
            return View("PrivacyPolicy", BaseModel);
        }

        public ActionResult FAQ()
        {
            BaseModel.NavigationBar.RenderSortByListMenu = false;
            return View("FAQ", BaseModel);
        }

        public ActionResult RSS()
        {
            BaseModel.NavigationBar.RenderSortByListMenu = false;
            return View("RSS", BaseModel);
        }

        public ActionResult DMCA()
        {
            BaseModel.NavigationBar.RenderSortByListMenu = false;
            return View("DMCA", BaseModel);
        }

        public ActionResult Donate()
        {
            BaseModel.NavigationBar.RenderSortByListMenu = false;
            return View("Donate", BaseModel);
        }

        public ActionResult Sitemap()
        {
            var siteMapData = new SiteMapData(_repository);
            siteMapData.NavigationBar.RenderSortByListMenu = false;
            return View("Sitemap", siteMapData);
        }
    }
}
