using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Models
{
    public class GridViewLayout : ProductsViewLayout
    {
        public GridViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp, int columns)
            : base(reqCriteria, repoResp, columns)
        {
        }
    }
}