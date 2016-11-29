using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.LogHandler;
using ProductsEStore.Models;
using System.Linq;
using ProductsEStore.PagerHandler.PagerSettingsHandler;
using System;

namespace ProductsEStore.Controllers
{
    public class CategoryController : MyBaseController
    {
        public ActionResult Index(string seoFriendlyCategoryName, string sort = "post-date", int pageNo = 1)
        {
            RequestCriteria requestCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.GetItemsInCategory,
                SeoFriendlyCategoryName = seoFriendlyCategoryName,
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo
            };

            Response response = _repository.GetProducts(requestCriteria);

            // Dependency Injection
            var productListViewResult = Helper.GetProductListViewResult(requestCriteria, response, _repository);
            string headerMessage = string.Format("Found {0} Books Under {1} Category", response.ProductCount, requestCriteria.GetUserFriendlyCategoryName(requestCriteria.SeoFriendlyCategoryName));
            productListViewResult.Header = new ProductListViewResultHeader()
            {
                Message = headerMessage
            };
            return View("Result", productListViewResult);
        }


        //private CatergoryViewResult GetCategoryViewResult(RequestCriteria rc, Response response)
        //{
        //    SearchResult searchResult;
        //    if (!IsSearchCategoryValid(categoryName))
        //    {
        //        return new SearchResult() { SearchKeyword = categoryName, PageNo = pageNo, FoundResult = false };
        //    }
        //    if (!IsPageNumberInValidRange(pageNo, categoryName))
        //    {
        //        throw new Exception(string.Format("The Page No:{0} Is NotValid", pageNo));
        //    }

        //    var books = new BookManager().GetBooksByCategory(categoryName);
        //    int totalBooks = books.Count;
        //    var displayedBooks = books.Skip((pageNo - 1) * PagerSettings.PageSize).Take(PagerSettings.PageSize).ToList();
        //    var pager = new Pager().GetPager(totalBooks, pageNo);
        //    var foundResult = books.Count > 0 ? true : false;

        //    searchResult = new SearchResult()
        //    {
        //        Books = books,
        //        DisplayedBooks = displayedBooks,
        //        PageNo = pageNo,
        //        Pager = pager,
        //        SearchKeyword = categoryName,
        //        FoundResult = foundResult
        //    };
        //    return searchResult;
        //}


        //private bool IsSearchCategoryValid(string categoryName)
        //{
        //    return !string.IsNullOrEmpty(categoryName);
        //}

        //private bool IsPageNumberInValidRange(int pageNo, string categoryName)
        //{
        //    var totalPages = GetTotalPages(categoryName);
        //    var retVal = (pageNo == 1 || pageNo > 1 && pageNo <= totalPages);
        //    return retVal;
        //}

        //private int GetTotalPages(string categoryName)
        //{
        //    var books = new BookManager().GetBooksByCategory(categoryName);
        //    var totalPages = new Pager().GetPageCount(books.Count);
        //    return totalPages;
        //}
    }
}
