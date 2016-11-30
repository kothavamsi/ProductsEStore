using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;

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
                PageSize = 12
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            GridViewLayout gridViewLayout = new GridViewLayout(reqCriteria, repoResp, 6);
            gridViewLayout.NavigationBar = new NavigationBar(_repository);
            gridViewLayout.NavigationBar.RenderSortByListMenu = false;
            return View("ProductGridViewResult", gridViewLayout);
        }
    }
}
