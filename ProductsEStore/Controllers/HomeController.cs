using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.WebApi;
using ProductsEStore.Core;
using ProductsEStore.Repository;
using ProductsEStore.WebsiteSettings;

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
            SitePage sitePage = (from page in BaseModel.Configuration.DisplaySettings.SitePages
                                 where page.Name == PageName.HomePage
                                 select page).First();
            int _pageSize = sitePage.Layout.PageSize;
            int _columns = sitePage.Layout.Columns;
            int _pagerSize = sitePage.Pager.Size;

            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestForPage = PageName.HomePage,
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo,
                PageSize = _pageSize
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productsViewLayout = GetProductsViewLayout(reqCriteria, repoResp, _columns, _pageSize, _pagerSize, sitePage);
            productsViewLayout.NavigationBar.RenderSortByListMenu = true;

            string displayingXtoYBooks = string.Format(
            "Displaying {0} to {1} books",
            1 + (reqCriteria.PageNo - 1) * reqCriteria.PageSize,
            repoResp.CurrentPageProducts.Count + (reqCriteria.PageNo - 1) * reqCriteria.PageSize);
            productsViewLayout.LayoutHeader.Message = string.Format("Found {0} books >> {1}", repoResp.ItemsCount, displayingXtoYBooks);
            productsViewLayout.PageTitle = string.Format("{0} - {1}", productsViewLayout.SiteName, productsViewLayout.SiteTagLine);
            
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
