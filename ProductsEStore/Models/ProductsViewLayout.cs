using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;
using ProductsEStore.WebsiteSettings;

namespace ProductsEStore.Models
{
    public class LayoutHeader
    {
        public string Message { get; set; }
    }

    public class LayoutFooter
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

    public  abstract class ProductsViewLayout : ViewModelBase
    {
        public bool HasRenderableProducts { get; set; }
        public LayoutHeader LayoutHeader { get; set; }
        public ProductsDisplay ProductsDisplay { get; set; }
        public Pager Pager { get; set; }
        public LayoutFooter LayoutFooter { get; set; }

        private RequestCriteria _reqestCriteria { get; set; }
        private RepositoryResponse _responseCriteria { get; set; }

        public ProductsViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp)
        {
            this._reqestCriteria = reqCriteria;
            this._responseCriteria = repoResp;
            UpdateModelUsingConfiguration();
        }

        private void UpdateModelUsingConfiguration()
        {
            int columns = 4;
            int pageSize = 16;
            int PagerSize = 5;

            string headerMsg = "";
            string displayingXtoYBooks = string.Format(
            "Displaying {0} to {1} books",
            1 + (_reqestCriteria.PageNo - 1) * _reqestCriteria.PageSize,
            _responseCriteria.CurrentPageProducts.Count + (_reqestCriteria.PageNo - 1) * _reqestCriteria.PageSize);


            switch (_reqestCriteria.RequestMode)
            {
                case RequestMode.HomePageProducts:
                    columns = Configuration.DisplaySettings.HomePage.Layout.Columns;
                    pageSize = Configuration.DisplaySettings.HomePage.Layout.PageSize;
                    PagerSize = Configuration.DisplaySettings.HomePage.Pager.Size;
                    headerMsg = string.Format("Found {0} books >> {1}", _responseCriteria.ItemsCount, displayingXtoYBooks);
                    PageTitle = string.Format("{0} - {1}", SiteName, SiteTagLine);
                    break;
                case RequestMode.GetItemsInCategory:
                    columns = Configuration.DisplaySettings.CategoryPage.Layout.Columns;
                    pageSize = Configuration.DisplaySettings.CategoryPage.Layout.PageSize;
                    PagerSize = Configuration.DisplaySettings.CategoryPage.Pager.Size;
                    headerMsg = string.Format("{0} Books under {1} category >> {2}", _responseCriteria.ItemsCount, _reqestCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", string.Format("Popular {0} Book Archives", _reqestCriteria.SeoFriendlyCategoryName));
                    break;
                case RequestMode.MostReviews:
                    columns = Configuration.DisplaySettings.MostReviewsPage.Layout.Columns;
                    pageSize = Configuration.DisplaySettings.MostReviewsPage.Layout.PageSize;
                    PagerSize = Configuration.DisplaySettings.MostReviewsPage.Pager.Size;
                    headerMsg = string.Format("Most Reviewd Books >> {2}", _responseCriteria.ItemsCount, _reqestCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", "Most Reviews");
                    break;
                case RequestMode.NewReleases:
                    columns = Configuration.DisplaySettings.NewReleasesPage.Layout.Columns;
                    pageSize = Configuration.DisplaySettings.NewReleasesPage.Layout.PageSize;
                    PagerSize = Configuration.DisplaySettings.NewReleasesPage.Pager.Size;
                    headerMsg = string.Format("New Released Books >> {2}", _responseCriteria.ItemsCount, _reqestCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", "New Release");
                    break;
                case RequestMode.SearchKeyWord:
                    columns = Configuration.DisplaySettings.SearchPage.Layout.Columns;
                    pageSize = Configuration.DisplaySettings.SearchPage.Layout.PageSize;
                    PagerSize = Configuration.DisplaySettings.SearchPage.Pager.Size;
                    headerMsg = string.Format("{0} Found >> {1}", _responseCriteria.ItemsCount, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", string.Format("You searched for {0}", _reqestCriteria.SearchKeyWord));
                    break;
                case RequestMode.Monthly:
                    columns = Configuration.DisplaySettings.ProductByYearMonthPage.Layout.Columns;
                    pageSize = Configuration.DisplaySettings.ProductByYearMonthPage.Layout.PageSize;
                    PagerSize = Configuration.DisplaySettings.ProductByYearMonthPage.Pager.Size;
                    headerMsg = string.Format(
                 "{0} Books Added on {1}{2} >> {3}",
                 _responseCriteria.ItemsCount,
                 SiteMapData.MonthNames[_reqestCriteria.MonthlyYearly.Month],
                 _reqestCriteria.MonthlyYearly.Year,
                 displayingXtoYBooks);
                    break;
                case RequestMode.TopSeller:
                    headerMsg = "";
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", "Top Sellers");
                    break;
            }

            this.ProductsDisplay = new ProductsDisplay(columns, _responseCriteria.CurrentPageProducts);
            this.HasRenderableProducts = _responseCriteria.CurrentPageProducts.Count > 0 ? true : false;
            this.LayoutHeader = new LayoutHeader() { Message = headerMsg };
            this.Pager = new Pager(_responseCriteria.ItemsCount, _reqestCriteria.PageNo, pageSize, PagerSize);
        }
    }
}