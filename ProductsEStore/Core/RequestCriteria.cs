using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Core
{
    public enum RequestMode
    {
        None = 0,
        All = 1,
        SearchKeyWord = 2,
        GetItemsInCategory = 3,
        TopSeller = 4,
        MostReviews = 5,
        Monthly = 6
    }

    public enum SortMode
    {
        None = 0,
        PostDate = 1,
        UploadDate = 2,
        PublicationDate = 3,
        MostReviews = 4,
        AvgCustomerReview = 5,
        MostDownloads = 6
    }

    public class MonthlyYearly
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public MonthlyYearly()
        {

        }
    }

    public static class SortModeMappings
    {
        public static SortMode GetSortMode(string seoFriendlySortBy)
        {
            // TODO: MAP seoFriendlySortBy to SortMode
            return SortMode.PostDate;
        }
    }

    public class RequestCriteria
    {
        public RequestCriteria()
        {
            RequestMode = RequestMode.None;
            SortMode = SortMode.None;
            PageNo = 1;
        }

        public RequestMode RequestMode;
        public SortMode SortMode;
        public int PageNo;
        public string SearchKeyWord;
        public int CategoryId;
        public string SeoFriendlyCategoryName;
        public int TopSellerId;
        public string SeoFriendlyTopSeller;
        public int MostReviewsId;
        public string SeoFriendlyMostReviews;
        public MonthlyYearly MonthlyYearly;

        public string GetUserFriendlyCategoryName(string SeoFriendlyCategoryName)
        {
            //TODO: Map the SeoFriendlyCategoryName to UserFriendlyCategoryName
            return "xxxxxx";
        }
    }


}