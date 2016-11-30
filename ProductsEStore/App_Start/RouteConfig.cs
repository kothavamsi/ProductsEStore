using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductsEStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SearchWithPaging",
                url: "search/{keyword}/page/{pageNo}",
                defaults: new { controller = "Search", action = "Index" }
            );

            routes.MapRoute(
                name: "Search",
                url: "search/{keyword}",
                defaults: new { controller = "Search", action = "Index" }
             );

            routes.MapRoute(
                name: "CategoryWithPaging",
                url: "category/{seoFriendlyCategoryName}/page/{pageNo}",
                defaults: new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                name: "Category",
                url: "category/{seoFriendlyCategoryName}",
                defaults: new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                name: "YearAndMonth",
                url: "{Year}/{Month}/page/{pageNo}",
                defaults: new { controller = "YearAndMonth", action = "Index" },
                constraints: new { Year = @"\d{4}", Month = @"\d{1,2}" }
            );

            routes.MapRoute(
                name: "YearAndMonthWithPaging",
                url: "{Year}/{Month}",
                defaults: new { controller = "YearAndMonth", action = "Index" },
                constraints: new { Year = @"\d{4}", Month = @"\d{1,2}" }
            );

            routes.MapRoute(
                name: "TopSellers",
                url: "top-sellers/",
                defaults: new { controller = "TopSellers", action = "Index" }
            );

            routes.MapRoute(
                name: "MostReviews",
                url: "most-reviews/",
                defaults: new { controller = "MostReviews", action = "Index" }
            );
            routes.MapRoute(
               name: "MostReviewsWithPaging",
               url: "most-reviews/page/{pageNo}",
               defaults: new { controller = "MostReviews", action = "Index" }
           );

            routes.MapRoute(
                name: "NewRelease",
                url: "new-release/",
                defaults: new { controller = "NewRelease", action = "Index" }
            );
            routes.MapRoute(
               name: "NewReleaseWithPaging",
               url: "new-release/page/{pageNo}",
               defaults: new { controller = "NewRelease", action = "Index" }
           );

            routes.MapRoute(
               name: "DefaultWithPaging",
               url: "page/{pageNo}",
               defaults: new { controller = "Home", action = "Index" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

        }
    }
}