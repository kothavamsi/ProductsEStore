using System.Xml.Serialization;

namespace ProductsEStore.WebsiteSettings
{
    [XmlRoot("configuration")]
    public class Configuration
    {
        [XmlElement("websiteSettings", Order = 1)]
        public WebsiteSettings WebsiteSettings { get; set; }

        [XmlElement("logManagerSettings", Order = 2)]
        public LogManagerSettings LogManagerSettings { get; set; }

        [XmlElement("displaySettings", Order = 3)]
        public DisplaySettings DisplaySettings { get; set; }

        public Configuration()
        {
        }
    }

    public class WebsiteSettings
    {
        [XmlElement("siteName", Order = 1)]
        public string SiteName { get; set; }

        [XmlElement("siteTagline", Order = 2)]
        public string SiteTagline { get; set; }

        [XmlElement("siteDomain", Order = 3)]
        public string SiteDomain { get; set; }

        [XmlElement("pageTitleTemplate", Order = 4)]
        public string PageTitleTemplate { get; set; }

        public WebsiteSettings()
        {

        }
    }

    public class LogManagerSettings
    {
        [XmlAttribute("enable")]
        public bool Enable { get; set; }

        [XmlAttribute("overWrite")]
        public bool Overwrite { get; set; }

        [XmlArrayItem("Listener")]
        public Listener[] Listeners;

        public LogManagerSettings()
        {

        }

    }


    public class Listener
    {
        [XmlAttribute("listenerType")]
        public ListenerType ListenerType { get; set; }

        [XmlAttribute("path")]
        public string Path { get; set; }

        public Listener()
        {
        }
    }

    public enum ListenerType
    {
        [XmlEnum("html")]
        html = 1,

        [XmlEnum("xml")]
        xml = 2
    }

    public class DisplaySettings
    {
        [XmlElement("homePage", Order = 1)]
        public HomePage HomePage { get; set; }

        [XmlElement("categoryPage", Order = 2)]
        public CategoryPage CategoryPage { get; set; }

        [XmlElement("mostReviewsPage", Order = 3)]
        public MostReviewsPage MostReviewsPage { get; set; }

        [XmlElement("newReleasesPage", Order = 4)]
        public NewReleasesPage NewReleasesPage { get; set; }

        [XmlElement("searchPage", Order = 5)]
        public SearchPage SearchPage { get; set; }

        [XmlElement("productByYearMonthPage", Order = 6)]
        public ProductByYearMonthPage ProductByYearMonthPage { get; set; }

        [XmlElement("sitemapPage", Order = 7)]
        public SiteMapPage SiteMapPage { get; set; }

        public DisplaySettings()
        {

        }
    }

    public class HomePage
    {
        [XmlElement("layout", Order = 1)]
        public LayOut Layout { get; set; }

        [XmlElement("pager", Order = 2)]
        public Pager Pager { get; set; }

        public HomePage()
        {
        }
    }

    public class CategoryPage
    {
        [XmlElement("layout")]
        public LayOut Layout { get; set; }

        [XmlElement("pager")]
        public Pager Pager { get; set; }

        public CategoryPage()
        {
        }
    }

    public class MostReviewsPage
    {
        [XmlElement("layout")]
        public LayOut Layout { get; set; }

        [XmlElement("pager")]
        public Pager Pager { get; set; }

        public MostReviewsPage()
        {
        }
    }

    public class NewReleasesPage
    {
        [XmlElement("layout")]
        public LayOut Layout { get; set; }

        [XmlElement("pager")]
        public Pager Pager { get; set; }

        public NewReleasesPage()
        {
        }
    }

    public class SearchPage
    {
        [XmlElement("layout")]
        public LayOut Layout { get; set; }

        [XmlElement("pager")]
        public Pager Pager { get; set; }

        public SearchPage()
        {
        }
    }

    public class ProductByYearMonthPage
    {
        [XmlElement("layout")]
        public LayOut Layout { get; set; }

        [XmlElement("pager")]
        public Pager Pager { get; set; }

        public ProductByYearMonthPage()
        {
        }
    }

    public class LayOut
    {
        [XmlAttribute("viewType")]
        public ViewType ViewType { get; set; }

        [XmlAttribute("columns")]
        public int Columns { get; set; }

        [XmlAttribute("pageSize")]
        public int PageSize { get; set; }
    }

    public enum ViewType
    {
        [XmlEnum("grid")]
        grid = 1,
        [XmlEnum("list")]
        list = 2
    }

    public class Pager
    {
        [XmlAttribute("size")]
        public int Size { get; set; }
    }

    public class SiteMapPage
    {
        [XmlElement("popularTags")]
        public PopularTags PopularTags { get; set; }

        [XmlElement("popularAuthorTags")]
        public PopularAuthorTags PopularAuthorTags { get; set; }

        [XmlElement("popularPublisherTags")]
        public PopularPublisherTags PopularPublisherTags { get; set; }

        [XmlElement("recentProducts")]
        public RecentProducts RecentProducts { get; set; }

        [XmlElement("productsByMonth")]
        public ProductsByMonth ProductsByMonth { get; set; }

        public SiteMapPage()
        {
        }
    }

    public class PopularTags
    {
        [XmlAttribute("totalItems")]
        public int TotalItems { get; set; }

        public PopularTags()
        {
        }
    }

    public class PopularAuthorTags
    {
        [XmlAttribute("totalItems")]
        public int TotalItems { get; set; }

        public PopularAuthorTags()
        {
        }
    }

    public class PopularPublisherTags
    {
        [XmlAttribute("totalItems")]
        public int TotalItems { get; set; }

        public PopularPublisherTags()
        {

        }
    }

    public class RecentProducts
    {
        [XmlAttribute("totalItems")]
        public int TotalItems { get; set; }

        public RecentProducts()
        {
        }
    }

    public class ProductsByMonth
    {
        [XmlElement("relative")]
        public Relative Relative { get; set; }

        [XmlElement("fixed")]
        public Fixed Fixed { get; set; }

        public ProductsByMonth()
        {

        }
    }

    public class Relative
    {
        [XmlAttribute("totalMonthsFromCurrent")]
        public int TotalMonthsFromCurrent { get; set; }

        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }

        public Relative()
        {
        }

    }

    public class Fixed
    {
        [XmlAttribute("fromYear")]
        public int FromYear { get; set; }

        [XmlAttribute("fromMonth")]
        public int FromMonth { get; set; }

        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }

        public Fixed()
        {

        }
    }


}