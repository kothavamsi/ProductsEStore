using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.Core;
using ProductsEStore.Repository;

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
            RequestCriteria reqCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.NewReleases,
                SortMode = SortMode.None,
                PageNo = pageNo,
                PageSize = 12
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            ProductsViewLayout productViewLayout = new ProductsViewLayout(reqCriteria, repoResp, 4);
            productViewLayout.NavigationBar.RenderSortByListMenu = false;
            return View("ProductListViewResult", productViewLayout);
        }
    }
}
