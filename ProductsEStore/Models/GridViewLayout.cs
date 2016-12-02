using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;
using ProductsEStore.WebsiteSettings;

namespace ProductsEStore.Models
{
    public class GridViewLayout : ProductsViewLayout
    {
        public GridViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp, int columns, int pageSize, int pagerSize)
            : base(reqCriteria, repoResp, columns, pageSize, pagerSize)
        {
        }
    }
}