using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.Core;
using ProductsEStore.Repository;
using ProductsEStore.WebsiteSettings;

namespace ProductsEStore.Controllers
{
    public class NewReleaseController : MyBaseController
    {
        IRepository _repository;
        public NewReleaseController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int pageNo = 1)
        {
            SitePage sitePage = (from page in BaseModel.Configuration.DisplaySettings.SitePages
                                 where page.Name == PageName.NewReleasePage
                                 select page).First();
            int _pageSize = sitePage.Layout.PageSize;
            int _columns = sitePage.Layout.Columns;
            int _pagerSize = sitePage.Pager.Size;

            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestForPage = PageName.NewReleasePage,
                SortMode = SortMode.None,
                PageNo = pageNo,
                PageSize = _pagerSize
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productsViewLayout = GetProductsViewLayout(reqCriteria, repoResp, _columns, _pageSize, _pagerSize, sitePage);

            string displayingXtoYBooks = string.Format(
            "Displaying {0} to {1} books",
            1 + (reqCriteria.PageNo - 1) * reqCriteria.PageSize,
            repoResp.CurrentPageProducts.Count + (reqCriteria.PageNo - 1) * reqCriteria.PageSize);
            productsViewLayout.LayoutHeader.Message = string.Format("New Released Books >> {2}", repoResp.ItemsCount, reqCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
            productsViewLayout.PageTitle = BaseModel.TitleTemplate.Replace("{{TITLE}}", "New Release");

            return View("DisplayResult", productsViewLayout);
        }
    }
}
