using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsEStore.Models
{
    public class ProductsView
    {
        public int ColumnCount { get; set; }
        public IList<Product> CurrentPageProducts { get; set; }
        public int RowCount { get; set; }
        public int lg_col { get; set; }
        public int md_col { get; set; }
        public int sm_col { get; set; }
        public int xs_col { get; set; }

        public ProductsView(int columns, IList<Product> currentPageProducts)
        {
            ColumnCount = columns;
            CurrentPageProducts = currentPageProducts;
            RowCount = (CurrentPageProducts.Count / ColumnCount) + (CurrentPageProducts.Count % ColumnCount > 0 ? 1 : 0);
            lg_col = 12 / ColumnCount;
            md_col = ((12 / ColumnCount) * 2) > 12 ? 12 : ((12 / ColumnCount) * 2);
            sm_col = ((12 / ColumnCount) * 3) > 12 ? 12 : ((12 / ColumnCount) * 3);
            xs_col = 12;
        }

    }
}