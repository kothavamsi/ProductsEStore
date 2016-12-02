using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;
using ProductsEStore.Repository;

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
            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.GetItemsInCategory,
                SeoFriendlyCategoryName = seoFriendlyCategoryName,
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo,
                PageSize = BaseModel.Configuration.DisplaySettings.CategoryPage.Layout.PageSize
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productsViewLayout = GetProductsViewLayout(reqCriteria, repoResp);
            productsViewLayout.NavigationBar.RenderSortByListMenu = true;
            return View("DisplayResult", productsViewLayout);
        }
    }
}
