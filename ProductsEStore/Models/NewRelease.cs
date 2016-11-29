using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Models
{
    public class NewRelease : ViewModelBase
    {
        public string Title { get; set; }

        // Dependency Injection
        public NewRelease(IRepository repository)
            : base(repository)
        {
            Title = "vamsi NewRelease";
        }
    }
}