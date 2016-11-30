using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsEStore.Models
{
    public class Grid
    {
        public int ColumnSize { get; set; }
        public IList<Product> Products { get; set; }
        public int RowCount { get; set; }
        public int lg_col { get; set; }
        public int md_col { get; set; }
        public int sm_col { get; set; }
        public int xs_col { get; set; }

        public Grid(int columnSize, IList<Product> products)
        {
            ColumnSize = columnSize;
            Products = products;
            RowCount = (Products.Count / ColumnSize) + (Products.Count % ColumnSize > 0 ? 1 : 0);
            lg_col = 12 / ColumnSize;
            md_col = ((12 / ColumnSize) * 2) > 12 ? 12 : ((12 / ColumnSize) * 2);
            sm_col = xs_col = 12;
        }

    }
}