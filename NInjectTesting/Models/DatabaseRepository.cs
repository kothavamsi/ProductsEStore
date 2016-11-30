using System;
using System.Collections.Generic;
using System.Linq;
using ProductsEStore.Repository.DataBase;

namespace ProductsEStore.Core
{
    public interface IRepository
    {
        string GetMessageFromRepository();
    }

    public class DatabaseRepository : IRepository
    {
        ICacheService _iCacheService;
        public DatabaseRepository(ICacheService cacheService)
        {
            _iCacheService = cacheService;
        }

        public string GetMessageFromRepository()
        {
            if (DateTime.Now.Second % 2 == 0)
            {
                return "hello from database..";
            }
            else
            {
                return _iCacheService.GetMessageFromCache();
            }
        }
    }
}