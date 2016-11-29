using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Models;
using ProductsEStore.Repository.DataBase;
using System.Web.Caching;

namespace ProductsEStore.Core
{
    public class DatabaseRepository : IRepository
    {
        ProductStoreEntities dbContext;
        ICacheService cacheService;
        public DatabaseRepository()
        {
            dbContext = new ProductStoreEntities();
            cacheService = new InMemoryCache();
        }

        public IList<CategoryListItem> GetCategoryListItems()
        {
            return cacheService.GetOrSet("GetCategoryListItems", () => GetCategoryListItemsFromDB());
        }

        private IList<CategoryListItem> GetCategoryListItemsFromDB()
        {
            var r = from category in dbContext.Categories
                    where category.Rank > 1 && category.Enabled 
                    orderby category.Rank descending
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
            return cacheService.GetOrSet("GetSortByListItems", () => GetSortByListItemsFromDB());
        }

        private IList<SortByListItem> GetSortByListItemsFromDB()
        {
            var r = from menuItem in dbContext.SortByMenuItems
                    where menuItem.Enabled == true
                    orderby menuItem.Rank descending
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

        public IList<IProduct> GetAllProducts()
        {
            return cacheService.GetOrSet("GetAllProducts", () => GetAllProductsFromDB());
        }

        public IList<IProduct> GetAllProductsFromDB()
        {
            return null;
        }

        public IList<IProduct> GetProductsByYearMonth(int year, int month)
        {
            throw new NotImplementedException();
        }

        public Response GetProducts(RequestCriteria requestCriteria)
        {
            throw new NotImplementedException();
        }

        public void SaveContact(ProductsEStore.Models.Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}