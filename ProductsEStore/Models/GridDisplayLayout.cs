using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Models
{
    public class GridDisplayLayout : ViewModelBase, IDisplayLayout
    {
        public bool HasRenderableProducts { get; set; }
        public int ItemsCount { get; set; }

        public LayoutHeader Header { get; set; }
        public GridView GridView { get; set; }

        // Dependency Injection
        public GridDisplayLayout(IRepository repository)
            : base(repository)
        {
            HasRenderableProducts = false;
            Header = new LayoutHeader();
        }
    }

    public class LayoutHeader
    {
        public string Message { get; set; }
    }
}