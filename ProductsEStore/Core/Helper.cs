using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Models;

namespace ProductsEStore.Core
{
    public  class Helper
    {
        public static ProductListViewResult GetProductListViewResult(RequestCriteria requestCriteria, Response response,IRepository repository)
        {
            ProductListViewResult catergoryViewResult;
            //if (!IsSearchCategoryValid(categoryName))
            //{
            //    return new SearchResult() { SearchKeyword = categoryName, PageNo = pageNo, FoundResult = false };
            //}
            //if (!IsPageNumberInValidRange(pageNo, categoryName))
            //{
            //    throw new Exception(string.Format("The Page No:{0} Is NotValid", pageNo));
            //}

            catergoryViewResult = new ProductListViewResult(repository)
            {
                ViewProducts = response.ViewProducts,
                FoundResult = response.ViewProducts.Count > 0 ? true : false,
                ProductCount = response.ProductCount,
                
                Pager = new Pager(response.ProductCount, requestCriteria.PageNo)
            };
            return catergoryViewResult;
        }
    }
}