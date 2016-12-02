using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsEStore.Settings
{
    public class Configuration
    {
        public WebsiteSettings WebsiteSettings { get; set; }
        public LogManager LogManager { get; set; }
        public DisplaySettings DisplaySettings { get; set; }

        public Configuration()
        {
        }
    }

    public class WebsiteSettings
    {
        public string SiteName { get; set; }
        public string SiteTagLine { get; set; }
        public string SiteDomain { get; set; }
        public string PageTitleTemplate { get; set; }

        public WebsiteSettings()
        {

        }
    }

    public class LogManager
    {
        public bool Enable { get; set; }
        public bool Overwrite { get; set; }
        IList<Listener> Listeners;
        public LogManager()
        {

        }

    }

    public class DisplaySettings
    {
        public HomePage HomePage { get; set; }
        public CategoriesPage CategoriesPage { get; set; }
        public MostReviewsPage MostReviewsPage { get; set; }
        public NewReleasesPage NewReleasesPage { get; set; }
        public SearchPage SearchPage { get; set; }
        public SiteMapPage SiteMapPage { get; set; }

        public DisplaySettings()
        {

        }
    }

    public class Listener
    {
        public string ListenerType { get; set; }
        public string Path { get; set; }

        public Listener()
        {
        }
    }

    public class HomePage
    {
        public LayOut Layout { get; set; }
        public Pager Pager { get; set; }

        public HomePage()
        {
        }
    }

    public class CategoriesPage
    {
        public LayOut Layout { get; set; }
        public Pager Pager { get; set; }

        public CategoriesPage()
        {
        }
    }

    public class MostReviewsPage
    {
        public LayOut Layout { get; set; }
        public Pager Pager { get; set; }

        public MostReviewsPage()
        {
        }
    }

    public class NewReleasesPage
    {
        public LayOut Layout { get; set; }
        public Pager Pager { get; set; }

        public NewReleasesPage()
        {
        }
    }

    public class SearchPage
    {
        public LayOut Layout { get; set; }
        public Pager Pager { get; set; }

        public SearchPage()
        {
        }
    }

    public class SiteMapPage
    {
        public LayOut Layout { get; set; }
        public Pager Pager { get; set; }

        public SiteMapPage()
        {
        }
    }

    public class PopularTags
    {
        public int TotalItems { get; set; }
        public PopularTags()
        {
        }
    }

    public class PopularAuthorTags
    {
        public int TotalItems { get; set; }
        public PopularAuthorTags()
        {
        }
    }

    public class PopularPublisherTags
    {
        public int TotalItems { get; set; }
        public PopularPublisherTags()
        {

        }
    }

    public class BooksByMonth
    {
        public Relative Relative { get; set; }
        public Fixed Fixed { get; set; }

        public BooksByMonth()
        {

        }
    }

    public class Relative
    {
        public int TotalMonthsFromCurrent { get; set; }
        public bool Enabled { get; set; }
        public Relative()
        {
        }

    }

    public class Fixed
    {
        public int FromYear { get; set; }
        public int FromMonth { get; set; }
        public bool Enabled { get; set; }
        public Fixed()
        {

        }
    }

    public class LayOut
    {
        public string ViewType { get; set; }
        public int Columns { get; set; }
        public int Products { get; set; }
    }

    public class Pager
    {
        public int Size { get; set; }
    }

}