using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Repository.DataBase;

namespace ProductsEStore.WebApi
{
    public static class TagExtenstions
    {
        public static PopularTag CreateTagInstance(this PopularTag tag, string keyWord)
        {
            PopularTag pt = new PopularTag()
            {
                Count = 1,
                CreatedOn = DateTime.Now,
                LastSearchedOn = DateTime.Now,
                Keyword = keyWord
            };
            return pt;
        }
    }
}