﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Models
{
    public class ListViewLayout : ProductsViewLayout
    {
        public ListViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp)
            : base(reqCriteria, repoResp, 1)
        {
        }
    }
}