using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;
using ProductsEStore.Repository;
using ProductsEStore.WebsiteSettings;
using System.Linq;

namespace ProductsEStore.Controllers
{
    public class CategoryController : MyBaseController
    {
        IRepository _repository;
        public CategoryController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string seoFriendlyCategoryName, string sort = "post-date", int pageNo = 1)
        {
            SitePage sitePage = (from page in BaseModel.Configuration.DisplaySettings.SitePages
                                 where page.Name == PageName.CategoryPage
                                 select page).First();
            int _pageSize = sitePage.Layout.PageSize;
            int _columns = sitePage.Layout.Columns;
            int _pagerSize = sitePage.Pager.Size;


            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestForPage = PageName.CategoryPage,
                SeoFriendlyCategoryName = seoFriendlyCategoryName,
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo,
                PageSize = _pageSize
            };


            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productsViewLayout = GetProductsViewLayout(reqCriteria, repoResp, _columns, _pageSize, _pagerSize, sitePage.Layout.ViewType);
            productsViewLayout.NavigationBar.RenderSortByListMenu = true;


            string displayingXtoYBooks = string.Format(
            "Displaying {0} to {1} books",
            1 + (reqCriteria.PageNo - 1) * reqCriteria.PageSize,
            repoResp.CurrentPageProducts.Count + (reqCriteria.PageNo - 1) * reqCriteria.PageSize);

            productsViewLayout.LayoutHeader.Message = string.Format("{0} Books under {1} category >> {2}",
                repoResp.ItemsCount, reqCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
            productsViewLayout.PageTitle = BaseModel.TitleTemplate.Replace("{{TITLE}}", string.Format("Popular {0} Book Archives",
                reqCriteria.SeoFriendlyCategoryName));

            return View("DisplayResult", productsViewLayout);
        }
    }
}
