using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;
using ProductsEStore.WebsiteSettings;

namespace ProductsEStore.Models
{
    public class Header
    {
        public string Message { get; set; }
    }

    public class Footer
    {
        public string Message { get; set; }
    }

    public class ProductsDisplay
    {
        public int ColumnCount { get; set; }
        public IList<Product> CurrentPageProducts { get; set; }
        public int RowCount { get; set; }
        public int lg_col { get; set; }
        public int md_col { get; set; }
        public int sm_col { get; set; }
        public int xs_col { get; set; }

        public ProductsDisplay(int columns, IList<Product> currentPageProducts)
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

    public abstract class ProductsViewLayout : ViewModelBase
    {
        public bool HasRenderableProducts { get; set; }
        public Header LayoutHeader { get; set; }
        public ProductsDisplay ProductsDisplay { get; set; }
        public Pager Pager { get; set; }
        public Footer LayoutFooter { get; set; }

        private RequestCriteria _reqestCriteria { get; set; }
        private RepositoryResponse _responseCriteria { get; set; }

        public ProductsViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp, int columns, int pageSize, int pagerSize)
        {
            this._reqestCriteria = reqCriteria;
            this._responseCriteria = repoResp;
            this.LayoutHeader = new Header();
            this.ProductsDisplay = new ProductsDisplay(columns, _responseCriteria.CurrentPageProducts);
            this.HasRenderableProducts = _responseCriteria.CurrentPageProducts.Count > 0 ? true : false;
            this.Pager = new Pager(_responseCriteria.ItemsCount, _reqestCriteria.PageNo, pageSize, pagerSize);
        }
    }
}
