﻿using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.Models;

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
                PageSize = 12
            };

            RepositoryResponse repoResp = _repository.GetProducts(reqCriteria);
            GridViewLayout gridViewLayout = new GridViewLayout(reqCriteria, repoResp, 1);
            gridViewLayout.NavigationBar.RenderSortByListMenu = true;
            return View("ProductListViewResult", gridViewLayout);
        }
    }
}
