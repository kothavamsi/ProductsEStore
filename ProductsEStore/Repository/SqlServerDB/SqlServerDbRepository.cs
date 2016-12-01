using System;
using System.Collections.Generic;
using System.Linq;
using ProductsEStore.Core;

namespace ProductsEStore.Repository.SqlServerDB
{
    public class SqlServerDbRepository : IRepository
    {
        ProductStoreEntities dbContext;
        ICacheService _cacheService;

        public SqlServerDbRepository(ICacheService cacheService)
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

        public RepositoryResponse GetProducts(RequestCriteria requestCriteria)
        {
            RepositoryResponse response = new RepositoryResponse();
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
                case RequestMode.MostReviews:
                    response = GetMostReviewedProducts(requestCriteria.PageNo, requestCriteria.PageSize, requestCriteria.SortMode);
                    break;
                case RequestMode.NewReleases:
                    response = GetNewReleasedProducts(requestCriteria.PageNo, requestCriteria.PageSize, requestCriteria.SortMode);
                    break;
            }
            return response;
        }

        private RepositoryResponse GetNewReleasedProducts(int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetNewReleasedProducts_{0}_{1}_{2}", pageNo, pageSize, sortMode.ToString()),
                () => GetNewReleasedProductsDB(pageNo, pageSize, sortMode));
        }

        // NEWRELEASES NOT IMPLEMENTED PROPERLY AS DATABASE HAS NO DATA FOR RELEASE DATES
        // TODO: SortMode Not Yet Implemented
        private RepositoryResponse GetNewReleasedProductsDB(int pageNo, int pageSize, SortMode sortMode)
        {
            var newReleasedProductsQuery = from dbProduct in dbContext.Products
                                           orderby dbProduct.Title
                                           select dbProduct;
            var pagedNewReleasedProductsQueryQuery = newReleasedProductsQuery.Skip((pageNo - 1) * pageSize).Take(pageSize);
            var MappedProductsQuery = from dbProduct in pagedNewReleasedProductsQueryQuery
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
            RepositoryResponse response = new RepositoryResponse()
            {
                ItemsCount = newReleasedProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }



        private RepositoryResponse GetMostReviewedProducts(int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetMostReviewedProducts_{0}_{1}_{2}", pageNo, pageSize, sortMode.ToString()),
                () => GetMostReviewedProductsFromDB(pageNo, pageSize, sortMode));
        }

        // MOSTREVIEW NOT IMPLEMENTED PROPERLY AS DATABASE HAS NO DATA FOR REVIEW RATING
        // TODO: SortMode Not Yet Implemented
        private RepositoryResponse GetMostReviewedProductsFromDB(int pageNo, int pageSize, SortMode sortMode)
        {
            var mostReviewedProductsQuery = from dbProduct in dbContext.Products
                                            orderby dbProduct.Title
                                            select dbProduct;
            var pagedmostReviewedProductsQuery = mostReviewedProductsQuery.Skip((pageNo - 1) * pageSize).Take(pageSize);
            var MappedProductsQuery = from dbProduct in pagedmostReviewedProductsQuery
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
            RepositoryResponse response = new RepositoryResponse()
            {
                ItemsCount = mostReviewedProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }


        private RepositoryResponse GetAllProducts(int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetAllProducts_{0}_{1}_{2}", pageNo, pageSize, sortMode.ToString()),
                () => GetAllProductsFromDB(pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private RepositoryResponse GetAllProductsFromDB(int pageNo, int pageSize, SortMode sortMode)
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
            RepositoryResponse response = new RepositoryResponse()
            {
                ItemsCount = allProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }

        private RepositoryResponse GetProductItemsInCategory(string seoFriendlyCategoryName, int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetProductItemsInCategory_{0}_{1}_{2}_{3}", seoFriendlyCategoryName, pageNo, pageSize, sortMode.ToString()),
                () => GetProductItemsInCategoryFromDB(seoFriendlyCategoryName, pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private RepositoryResponse GetProductItemsInCategoryFromDB(string seoFriendlyCategoryName, int pageNo, int pageSize, SortMode sortMode)
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


            RepositoryResponse response = new RepositoryResponse()
            {
                ItemsCount = categoryProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }

        private RepositoryResponse GetProductItemsBySearchKeyWord(string searchKeyWord, int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetProductItemsBySearchKeyWord_{0}_{1}_{2}_{3}", searchKeyWord, pageNo, pageSize, sortMode.ToString()),
                () => GetProductItemsBySearchKeyWordFromDB(searchKeyWord, pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private RepositoryResponse GetProductItemsBySearchKeyWordFromDB(string searchKeyWord, int pageNo, int pageSize, SortMode sortMode)
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
            RepositoryResponse response = new RepositoryResponse()
            {
                ItemsCount = keywordProductsQuery.Count(),
                CurrentPageProducts = MappedProductsQuery.ToList()
            };
            return response;
        }

        private RepositoryResponse GetProductsByYearMonth(int year, int month, int pageNo, int pageSize, SortMode sortMode)
        {
            return _cacheService.GetOrSet(string.Format("GetProductsByYearMonth_{0}_{1}_{2}_{3}_{4}", year, month, pageNo, pageSize, sortMode.ToString()),
                () => GetProductsByYearMonthFromDB(year, month, pageNo, pageSize, sortMode));
        }

        // TODO: SortMode Not Yet Implemented
        private RepositoryResponse GetProductsByYearMonthFromDB(int year, int month, int pageNo, int pageSize, SortMode sortMode)
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
            RepositoryResponse response = new RepositoryResponse()
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