using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsEStore.Repository.DataBase
{
    public interface ICacheService
    {
        string GetMessageFromCache();
    }

    public class InMemoryCache : ICacheService
    {
        public string GetMessageFromCache()
        {
            return "hello From Cache Service..";
        }
    }
}