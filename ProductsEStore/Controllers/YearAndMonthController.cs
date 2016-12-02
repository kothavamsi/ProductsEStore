using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;
using ProductsEStore.Repository;
using System.Linq;
using ProductsEStore.WebsiteSettings;
using ProductsEStore.WebApi;
using ProductsEStore.Repository.SqlServerDB;

namespace ProductsEStore.Controllers
{
    public class YearAndMonthController : MyBaseController
    {
        IRepository _repository;
        public YearAndMonthController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int Year, int Month, int pageNo = 1, string sort = "post-date")
        {
            SitePage sitePage = (from page in BaseModel.Configuration.DisplaySettings.SitePages
                                 where page.Name == PageName.YearlyMonthlyPage
                                 select page).First();
            int _pageSize = sitePage.Layout.PageSize;
            int _columns = sitePage.Layout.Columns;
            int _pagerSize = sitePage.Pager.Size;

            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestForPage = PageName.YearlyMonthlyPage,
                MonthlyYearly = new MonthlyYearly() { Month = Month, Year = Year },
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo,
                PageSize = _pageSize
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productsViewLayout = GetProductsViewLayout(reqCriteria, repoResp, _columns, _pageSize, _pagerSize, sitePage);

            string displayingXtoYBooks = string.Format(
            "Displaying {0} to {1} books",
            1 + (reqCriteria.PageNo - 1) * reqCriteria.PageSize,
            repoResp.CurrentPageProducts.Count + (reqCriteria.PageNo - 1) * reqCriteria.PageSize);

            productsViewLayout.LayoutHeader.Message = string.Format(
             "{0} Books Added on {1}{2} >> {3}",
             repoResp.ItemsCount,
             SiteMapData.MonthNames[reqCriteria.MonthlyYearly.Month],
             reqCriteria.MonthlyYearly.Year,
             displayingXtoYBooks);

            

            return View("DisplayResult", productsViewLayout);
        }
    }
}
