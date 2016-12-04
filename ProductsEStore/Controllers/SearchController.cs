using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;
using ProductsEStore.Repository;
using ProductsEStore.Repository.SqlServerDB;
using ProductsEStore.WebApi;
using System.Linq;
using ProductsEStore.WebsiteSettings;

namespace ProductsEStore.Controllers
{
    public class SearchController : MyBaseController
    {
        IRepository _repository;
        public SearchController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult Index(string keyword)
        {
            return Redirect(string.Format("/{0}/{1}", "search", keyword));
        }

        [HttpGet]
        public ActionResult Index(string keyword, int pageNo = 1)
        {
            SitePage sitePage = (from page in BaseModel.Configuration.DisplaySettings.SitePages
                                 where page.Name == PageName.SearchPage
                                 select page).First();
            int _pageSize = sitePage.Layout.PageSize;
            int _columns = sitePage.Layout.Columns;
            int _pagerSize = sitePage.Pager.Size;


            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestForPage = PageName.SearchPage,
                SearchKeyWord = keyword,
                SortMode = SortMode.None,
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

            productsViewLayout.LayoutHeader.Message = string.Format("{0} Found >> {1}", repoResp.ItemsCount, displayingXtoYBooks);
            productsViewLayout.PageTitle = BaseModel.TitleTemplate.Replace("{{TITLE}}", string.Format("You searched for {0}", reqCriteria.SearchKeyWord));

            if (productsViewLayout.HasRenderableProducts)
            {
                new TagManager().PostPopularTag(new PopularTag().CreateTagInstance(keyword));

            }
            return View("DisplayResult", productsViewLayout);
        }
    }
}
