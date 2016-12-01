﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsEStore.Repository
{
    public interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    }
}