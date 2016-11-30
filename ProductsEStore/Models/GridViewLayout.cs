using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Models
{
    public class LayoutHeader
    {
        public string Message { get; set; }
    }

    public class GridViewLayout : ViewModelBase
    {
        public LayoutHeader LayoutHeader { get; set; }
        public GridView GridView { get; set; }
        public bool HasRenderableProducts { get; set; }
        public Pager Pager { get; set; }

        private RequestCriteria reqCriteria { get; set; }
        private RepositoryResponse repoResp { get; set; }
        private int columns { get; set; }

        public GridViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp, int columns)
        {
            this.reqCriteria = reqCriteria;
            this.repoResp = repoResp;
            this.columns = columns;
            GridView = new GridView(columns, repoResp.CurrentPageProducts);
            HasRenderableProducts = repoResp.CurrentPageProducts.Count > 0 ? true : false;
            LayoutHeader = new LayoutHeader() { Message = GetLayoutHeaderMessage() };
            Pager = new Pager(repoResp.ItemsCount, reqCriteria.PageNo, reqCriteria.PageSize);
        }


        public string GetLayoutHeaderMessage()
        {
            string headerMsg = "";

            string displayingXtoYBooks = string.Format(
            "Displaying {0} to {1} books",
            1 + (reqCriteria.PageNo - 1) * reqCriteria.PageSize,
            repoResp.CurrentPageProducts.Count + (reqCriteria.PageNo - 1) * reqCriteria.PageSize);

            switch (reqCriteria.RequestMode)
            {
                case RequestMode.All:
                    headerMsg = string.Format("Found {0} books >> {1}", repoResp.ItemsCount, displayingXtoYBooks);
                    PageTitle = string.Format("{0} - {1}", SiteName, SiteTagLine);
                    break;
                case RequestMode.GetItemsInCategory:
                    headerMsg = string.Format("{0} Books under {1} category >> {2}", repoResp.ItemsCount, reqCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", string.Format("Popular {0} Book Archives", reqCriteria.SeoFriendlyCategoryName));
                    break;
                case RequestMode.TopSeller:
                    headerMsg = "";
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", "Top Sellers");
                    break;
                case RequestMode.MostReviews:
                    headerMsg = string.Format("Most Reviewd Books >> {2}", repoResp.ItemsCount, reqCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", "Most Reviews");
                    break;
                case RequestMode.NewReleases:
                    headerMsg = string.Format("New Released Books >> {2}", repoResp.ItemsCount, reqCriteria.SeoFriendlyCategoryName, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", "New Release");
                    break;
                case RequestMode.SearchKeyWord:
                    headerMsg = string.Format("{0} Found >> {1}", repoResp.ItemsCount, displayingXtoYBooks);
                    PageTitle = TitleTemplate.Replace("{{TITLE}}", string.Format("You searched for {0}", reqCriteria.SearchKeyWord));
                    break;
                case RequestMode.Monthly:
                    headerMsg = string.Format(
                    "{0} Books Added on {1}{2} >> {3}",
                    repoResp.ItemsCount,
                    SiteMapData.MonthNames[reqCriteria.MonthlyYearly.Month],
                    reqCriteria.MonthlyYearly.Year,
                    displayingXtoYBooks);
                    break;
            }
            return headerMsg;
        }
    }
}