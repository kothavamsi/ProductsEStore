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
                name: "SearchPage",
                url: "search/{keyword}/page/{pageNo}",
                defaults: new { controller = "Search", action = "Index" }
            );

            routes.MapRoute(
                name: "Search",
                url: "search/{keyword}",
                defaults: new { controller = "Search", action = "Index" }
             );

            routes.MapRoute(
                name: "CategoryPage",
                url: "category/{seoFriendlyCategoryName}/page/{pageNo}",
                defaults: new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                name: "Category",
                url: "category/{categoryName}",
                defaults: new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                name: "YearAndMonth",
                url: "{Year}/{Month}/page/{pageNo}",
                defaults: new { controller = "YearAndMonth", action = "Index" },
                constraints: new { Year = @"\d{4}", Month=@"\d{1,2}" }
            );

            routes.MapRoute(
                name: "YearAndMonthPage",
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
               name: "MostReviewsPage",
               url: "most-reviews/page/{pageNo}",
               defaults: new { controller = "MostReviews", action = "Index" }
           );
            routes.MapRoute(
                name: "NewRelease",
                url: "new-release/",
                defaults: new { controller = "NewRelease", action = "Index" }
            );
            routes.MapRoute(
               name: "NewReleasePage",
               url: "new-release/page/{pageNo}",
               defaults: new { controller = "NewRelease", action = "Index" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}