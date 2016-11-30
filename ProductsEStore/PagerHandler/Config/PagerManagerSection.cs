using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ProductsEStore.PagerHandler.Config
{
    public class PagerManagerSection : ConfigurationSection
    {
        [ConfigurationProperty("pagerDisplayLength")]
        public int PagerDisplayLength
        {
            get { return (int)this["pagerDisplayLength"]; }
        }
    }
}