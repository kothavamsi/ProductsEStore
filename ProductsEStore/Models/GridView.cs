using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsEStore.Models
{
    public class GridView
    {
        public int ColumnSize { get; set; }
        public IList<Product> CurrentPageProducts { get; set; }
        public int RowCount { get; set; }
        public int lg_col { get; set; }
        public int md_col { get; set; }
        public int sm_col { get; set; }
        public int xs_col { get; set; }
        public Pager Pager { get; set; }

        public GridView(int columns, IList<Product> currentPageProducts, int itemsCount, int currentPageNumber, int pageSize)
        {
            ColumnSize = columns;
            CurrentPageProducts = currentPageProducts;
            RowCount = (CurrentPageProducts.Count / ColumnSize) + (CurrentPageProducts.Count % ColumnSize > 0 ? 1 : 0);
            lg_col = 12 / ColumnSize;
            md_col = ((12 / ColumnSize) * 2) > 12 ? 12 : ((12 / ColumnSize) * 2);
            sm_col = ((12 / ColumnSize) * 3) > 12 ? 12 : ((12 / ColumnSize) * 3);
            xs_col = 12;
            Pager = new Pager(itemsCount,currentPageNumber,pageSize);
        }

    }
}