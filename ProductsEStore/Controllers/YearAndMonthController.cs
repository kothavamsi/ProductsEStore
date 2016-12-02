using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;
using ProductsEStore.Repository;

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
            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.Monthly,
                MonthlyYearly = new MonthlyYearly() { Month = Month, Year = Year },
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo,
                PageSize = BaseModel.Configuration.DisplaySettings.ProductByYearMonthPage.Layout.PageSize
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productsViewLayout = GetProductsViewLayout(reqCriteria, repoResp);
            return View("DisplayResult", productsViewLayout);
        }
    }
}
