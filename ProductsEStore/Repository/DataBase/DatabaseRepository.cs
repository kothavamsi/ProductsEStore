using System;
using System.Collections.Generic;
using System.Linq;
using ProductsEStore.Repository.DataBase;

namespace ProductsEStore.Core
{
    public class DatabaseRepository : IRepository
    {
        ProductStoreEntities dbContext;
        ICacheService _cacheService;

        public DatabaseRepository(ICacheService cacheService)
        {
            dbContext = new ProductStoreEntities();
            _cacheService = cacheService;
        }

        public IList<CategoryListItem> GetCategoryListItems()
        {
            return _cacheService.GetOrSet("GetCategoryListItems", () => GetCategoryListItemsFromDB());
        }

        private IList<CategoryListItem> GetCategoryListItemsFromDB()
        {
            var r = from category in dbContext.Categories
                    where category.Rank >= 1 && category.Enabled
                    orderby category.Rank ascending
                    select new CategoryListItem()
                    {
                        Enabled = category.Enabled,
                        Id = category.Id,
                        ParentId = category.ParentId,
                        Name = category.Name,
                        Rank = category.Rank,
                        SEOFriendlyName = category.SEOFriendlyName,
                        Weight = category.Weight
                    };
            return r.ToList();
        }

        public IList<SortByListItem> GetSortByListItems()
        {
            return _cacheService.GetOrSet("GetSortByListItems", () => GetSortByListItemsFromDB());
        }

        private IList<SortByListItem> GetSortByListItemsFromDB()
        {
            var r = from menuItem in dbContext.SortByMenuItems
                    where menuItem.Enabled == true
                    orderby menuItem.Rank ascending
                    select new SortByListItem()
                    {
                        Enabled = menuItem.Enabled,
                        Id = menuItem.Id,
                        Name = menuItem.Name,
                        Rank = menuItem.Rank,
                        SEOFriendlyName = menuItem.SEOFriendlyName,
                        Weight = menuItem.Weight
                    };
            return r.ToList();
        }

        public Response GetProducts(RequestCriteria requestCriteria)
        {
            Response response = new Response();
            switch (requestCriteria.RequestMode)
            {
                case RequestMode.GetItemsInCategory:
                    response = GetProductItemsInCategory(requestCriteria.SeoFriendlyCategoryName, requestCriteria.PageNo, requestCriteria.PageSize, requestCriteria.SortMode);
                    break;
                case RequestMode.SearchKeyWord:
                    response = GetProductItemsBySearchKeyWord(requestCriteria.SearchKeyWord, requestCriteria.PageNo, requestCriteria.PageSize, requestCriteria.SortMode);
                    break;
                case RequestMode.Monthly:
                    response = GetProductsByYearMonth(requestCriteria.MonthlyYearly.Year, requestCriteria.MonthlyYearly.Month, requestCriteria.PageNo, requestCriteria.PageSize, requestCriteria.SortMode);
                    break;
                case RequestMode.All:
                    response = GetAllProducts(requestCriteria.PageNo, requestCriteria.PageSize, requestCriteria.SortMode);
                    break;
            }
            return response;
        }

        private Response GetAllProducts(int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetAllProducts_{0}_{1}_{2}", pageNo, pageSize, sortMode.ToString()),
                () => GetAllProductsFromDB(pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private Response GetAllProductsFromDB(int pageNo, int pageSize, SortMode sortMode)
        {
            var allProductsQuery = from dbProduct in dbContext.Products
                                   orderby dbProduct.Title
                                   select dbProduct;
            var pagedAllProductsQuery = allProductsQuery.Skip((pageNo - 1) * pageSize).Take(pageSize);
            var MappedProductsQuery = from dbProduct in pagedAllProductsQuery
                                      select new ProductsEStore.Models.Product()
                                      {
                                          Title = dbProduct.Title,
                                          Author = dbProduct.Author,
                                          CategoryId = dbProduct.CategoryId,
                                          CoverPageUrl = dbProduct.CoverPageUrl,
                                          DetailPageUrl = dbProduct.DetailsPageUrl,
                                          Id = dbProduct.Id,
                                          ISBN_10 = dbProduct.ISBN10,
                                          ISBN_13 = dbProduct.ISBN13,
                                          Language = dbProduct.Language,
                                          Pages = dbProduct.Length ?? -1,
                                          Edition = dbProduct.Edition ?? -1,
                                          //PublishedDate = dbProduct.PublicationDate ?? DateTime.MinValue
                                      };
            Response response = new Response()
            {
                ItemsCount = allProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }

        private Response GetProductItemsInCategory(string seoFriendlyCategoryName, int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetProductItemsInCategory_{0}_{1}_{2}_{3}", seoFriendlyCategoryName, pageNo, pageSize, sortMode.ToString()),
                () => GetProductItemsInCategoryFromDB(seoFriendlyCategoryName, pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private Response GetProductItemsInCategoryFromDB(string seoFriendlyCategoryName, int pageNo, int pageSize, SortMode sortMode)
        {
            var categoryProductsQuery = from dbProduct in dbContext.Products
                                        where dbProduct.Category.SEOFriendlyName == seoFriendlyCategoryName
                                        orderby dbProduct.Title
                                        select dbProduct;

            var pagedcategoryProductsQuery = categoryProductsQuery.Skip((pageNo - 1) * pageSize).Take(pageSize);

            var MappedProductsQuery = from dbProduct in pagedcategoryProductsQuery
                                      select new ProductsEStore.Models.Product()
                                      {
                                          Title = dbProduct.Title,
                                          Author = dbProduct.Author,
                                          CategoryId = dbProduct.CategoryId,
                                          CoverPageUrl = dbProduct.CoverPageUrl,
                                          DetailPageUrl = dbProduct.DetailsPageUrl,
                                          Id = dbProduct.Id,
                                          ISBN_10 = dbProduct.ISBN10,
                                          ISBN_13 = dbProduct.ISBN13,
                                          Language = dbProduct.Language,
                                          Pages = dbProduct.Length ?? -1,
                                          Edition = dbProduct.Edition ?? -1,
                                          PublishedDate = dbProduct.PublicationDate ?? DateTime.MinValue
                                      };


            Response response = new Response()
            {
                ItemsCount = categoryProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }

        private Response GetProductItemsBySearchKeyWord(string searchKeyWord, int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetProductItemsBySearchKeyWord_{0}_{1}_{2}_{3}", searchKeyWord, pageNo, pageSize, sortMode.ToString()),
                () => GetProductItemsBySearchKeyWordFromDB(searchKeyWord, pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private Response GetProductItemsBySearchKeyWordFromDB(string searchKeyWord, int pageNo, int pageSize, SortMode sortMode)
        {
            var keywordProductsQuery = from dbProduct in dbContext.Products
                                       where dbProduct.Title.Contains(searchKeyWord)
                                       orderby dbProduct.Title
                                       select dbProduct;
            var pagedkeywordProductsQuery = keywordProductsQuery.Skip((pageNo - 1) * pageSize).Take(pageSize);

            var MappedProductsQuery = from dbProduct in pagedkeywordProductsQuery
                                      select new ProductsEStore.Models.Product()
                                      {
                                          Title = dbProduct.Title,
                                          Author = dbProduct.Author,
                                          CategoryId = dbProduct.CategoryId,
                                          CoverPageUrl = dbProduct.CoverPageUrl,
                                          DetailPageUrl = dbProduct.DetailsPageUrl,
                                          Id = dbProduct.Id,
                                          ISBN_10 = dbProduct.ISBN10,
                                          ISBN_13 = dbProduct.ISBN13,
                                          Language = dbProduct.Language,
                                          Pages = dbProduct.Length ?? -1,
                                          Edition = dbProduct.Edition ?? -1,
                                          PublishedDate = dbProduct.PublicationDate ?? DateTime.MinValue
                                      };
            Response response = new Response()
            {
                ItemsCount = keywordProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }

        private Response GetProductsByYearMonth(int year, int month, int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetProductsByYearMonth_{0}_{1}_{2}_{3}_{4}", year, month, pageNo, pageSize, sortMode.ToString()),
                () => GetProductsByYearMonthFromDB(year, month, pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private Response GetProductsByYearMonthFromDB(int year, int month, int pageNo, int pageSize, SortMode sortMode)
        {
            var MonthYearProductsQuery = from dbProduct in dbContext.Products
                                         where dbProduct.PublicationDate.Value.Month == month && dbProduct.PublicationDate.Value.Year == year
                                         orderby dbProduct.Title
                                         select dbProduct;
            var pagedMonthYearProductsQuery = MonthYearProductsQuery.Skip((pageNo - 1) * pageSize).Take(pageSize);

            var MappedProductsQuery = from dbProduct in pagedMonthYearProductsQuery
                                      select new ProductsEStore.Models.Product()
                                      {
                                          Title = dbProduct.Title,
                                          Author = dbProduct.Author,
                                          CategoryId = dbProduct.CategoryId,
                                          CoverPageUrl = dbProduct.CoverPageUrl,
                                          DetailPageUrl = dbProduct.DetailsPageUrl,
                                          Id = dbProduct.Id,
                                          ISBN_10 = dbProduct.ISBN10,
                                          ISBN_13 = dbProduct.ISBN13,
                                          Language = dbProduct.Language,
                                          Pages = dbProduct.Length ?? -1,
                                          Edition = dbProduct.Edition ?? -1,
                                          PublishedDate = dbProduct.PublicationDate ?? DateTime.MinValue
                                      };
            Response response = new Response()
            {
                ItemsCount = MonthYearProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }

        public int GetProductCountForYearMonth(int year, int month)
        {
            //return _cacheService.GetOrSet(string.Format("GetProductCountForYearMonth_{0}_{1}", year, month),
            //() => GetProductCountForYearMonthFromDB(year, month));
            return GetProductCountForYearMonthFromDB(year, month);
        }

        private int GetProductCountForYearMonthFromDB(int year, int month)
        {
            var query = from dbProduct in dbContext.Products
                        where dbProduct.PublicationDate.Value.Month == month && dbProduct.PublicationDate.Value.Year == year
                        select dbProduct;
            return query.Count();
        }

        public void SaveContact(ProductsEStore.Models.Contact modelContact)
        {

        }
    }
}