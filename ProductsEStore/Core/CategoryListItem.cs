using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Core
{
    public class CategoryListItem
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string SEOFriendlyName { get; set; }

        public int Rank { get; set; }
        public bool Enabled { get; set; }
        public int Weight { get; set; }

        public CategoryListItem()
        {
        }
    }
}