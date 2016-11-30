using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;
using ProductsEStore.Repository.DataBase;
using ProductsEStore.WebApi;

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
            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.SearchKeyWord,
                SearchKeyWord = keyword,
                SortMode = SortMode.None,
                PageNo = pageNo,
                PageSize = 12
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            GridViewLayout gridViewLayout = new GridViewLayout(reqCriteria, repoResp, 6);
            gridViewLayout.NavigationBar = new NavigationBar(_repository);
            gridViewLayout.NavigationBar.RenderSortByListMenu = false;
           
            if (gridViewLayout.HasRenderableProducts)
            {
                new TagManager().PostPopularTag(new PopularTag().CreateTagInstance(keyword));
            }
            return View("result", gridViewLayout);
        }
    }
}
