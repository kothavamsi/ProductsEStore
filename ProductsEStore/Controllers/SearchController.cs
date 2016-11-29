using System.Web.Mvc;
using ProductsEStore.Core;
using ProductsEStore.LogHandler;
using ProductsEStore.Models;
using System.Collections.Generic;
using System.Linq;
using ProductsEStore.PagerHandler.PagerSettingsHandler;
using System;
using ProductsEStore.WebApi;
using ProductsEStore.Repository.DataBase;

namespace ProductsEStore.Controllers
{
    public class SearchController : MyBaseController
    {
        [HttpPost]
        public ActionResult Index(string keyword)
        {
            return Redirect(string.Format("/{0}/{1}", "search", keyword));
        }

        [HttpGet]
        public ActionResult Index(string keyword, int pageNo = 1)
        {
            RequestCriteria requestCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.SearchKeyWord,
                SearchKeyWord = keyword,
                SortMode = SortMode.None,
                PageNo = pageNo
            };

            Response response = _repository.GetProducts(requestCriteria);

            // Dependency Injection
            var productListViewResult = Helper.GetProductListViewResult(requestCriteria, response, _repository);
            string headerMessage = string.Format("Searched - {0} (Found {1} Books)", requestCriteria.SearchKeyWord, response.ProductCount);
            productListViewResult.Header = new ProductListViewResultHeader()
            {
                Message = headerMessage
            };

            productListViewResult.NavigationBar.RenderSortByListMenu = false;

            if (productListViewResult.FoundResult)
            {
                new TagManager().PostPopularTag(new PopularTag().CreateTagInstance(keyword));
            }
            return View("Result", productListViewResult);
        }

        //private SearchResult GetBookSearchResult(string keyword, int pageNo)
        //{
        //    SearchResult searchResult;
        //    if (!IsSearchKeywordValid(keyword))
        //    {
        //        return new SearchResult() { SearchKeyword = keyword, PageNo = pageNo, FoundResult = false };
        //    }
        //    if (!IsPageNumberInValidRange(pageNo, keyword))
        //    {
        //        throw new Exception(string.Format("The Page No:{0} Is NotValid", pageNo));
        //    }

        //    var books = new BookManager().GetBooksByKeyword(keyword);
        //    int totalBooks = books.Count;
        //    var displayedBooks = books.Skip((pageNo - 1) * PagerSettings.PageSize).Take(PagerSettings.PageSize).ToList();
        //    var pager = new Pager(totalBooks, pageNo);
        //    var foundResult = books.Count > 0 ? true : false;

        //    searchResult = new SearchResult()
        //    {
        //        Books = books,
        //        DisplayedBooks = displayedBooks,
        //        PageNo = pageNo,
        //        Pager = pager,
        //        SearchKeyword = keyword,
        //        FoundResult = foundResult,
        //        NavBar = new NavBar() { RenderSortByList = false }
        //    };
        //    return searchResult;
        //}

        //private bool IsSearchKeywordValid(string keyword)
        //{
        //    return !string.IsNullOrEmpty(keyword);
        //}

        //private bool IsPageNumberInValidRange(int pageNo, string keyword)
        //{
        //    var totalPages = GetTotalPages(keyword);
        //    var retVal = (pageNo == 1 || pageNo > 1 && pageNo <= totalPages);
        //    return retVal;
        //}

        //private int GetTotalPages(string keyword)
        //{
        //    var books = new BookManager().GetBooksByKeyword(keyword);
        //    var totalPages = new Pager().GetPageCount(books.Count);
        //    return totalPages;
        //}
    }
}
