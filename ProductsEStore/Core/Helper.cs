using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Models;

namespace ProductsEStore.Core
{
    public class Helper
    {
        public static ProductListViewResult GetProductListViewResult(RequestCriteria requestCriteria, Response response, IRepository repository, int ColumnSize = 4)
        {
            ProductListViewResult productListViewResult;

            // Dependency Injection
            productListViewResult = new ProductListViewResult(repository)
            {
                FoundResult = response.ViewProducts.Count > 0 ? true : false,
                ProductCount = response.ProductCount,
                GridView = new GridView(ColumnSize, response.ViewProducts),
                Pager = new Pager(response.ProductCount, requestCriteria.PageNo)
            };
            return productListViewResult;
        }
    }
}