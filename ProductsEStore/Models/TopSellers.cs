﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;
using ProductsEStore.Repository;

namespace ProductsEStore.Models
{
    public class TopSellers : ViewModelBase
    {
        public string Title { get; set; }

        public TopSellers(IRepository repository)
        {
            Title = "vamsi topsellers";
        }
    }
}