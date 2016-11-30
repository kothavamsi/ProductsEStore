using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Models;

namespace ProductsEStore.Core
{
    public class Helper
    {
        public static GridDisplayLayout GetProductsDisplayLayout(RequestCriteria requestCriteria, Response response, IRepository repository, int columns)
        {
            // Dependency Injection
            GridDisplayLayout productListViewResult = new GridDisplayLayout(repository)
           {
               HasRenderableProducts = response.CurrentPageProducts.Count > 0 ? true : false,
               ItemsCount = response.ItemsCount,
               GridView = new GridView(columns, response.CurrentPageProducts, response.ItemsCount, requestCriteria.PageNo, requestCriteria.PageSize),
           };
            return productListViewResult;
        }

        public static bool IsValidateRequest(RequestCriteria requestCriteria)
        {
            bool retVal = false;

            return retVal;
        }
    }
}