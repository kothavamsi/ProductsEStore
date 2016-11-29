using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace ProductsEStore.Repository.DataBase
{
    interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    }

    public class InMemoryCache : ICacheService
    {
        public int CACHE_DURATION = 10;
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(CACHE_DURATION));
            }
            return item;
        }
    }
}