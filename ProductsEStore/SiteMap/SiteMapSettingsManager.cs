using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.SiteMap.Config;
using System.Configuration;
using System.Web.Configuration;

namespace ProductsEStore.SiteMap
{
    public class SiteMapSettingsManager
    {
        static SiteMapSettingsManager()
        {

        }

        public static void LoadSettings()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            SiteMapSectionGroup siteMapData = (SiteMapSectionGroup)config.GetSectionGroup("siteMapData");

            SiteMapSettings.PopularTags.TagDisplayCount = siteMapData.PopularTags.TotalItems <= 0 ? 50 : siteMapData.PopularTags.TotalItems;
            SiteMapSettings.PopularAuthorTags.TagDisplayCount = siteMapData.PopularAuthorTags.TotalItems <= 0 ? 50 : siteMapData.PopularAuthorTags.TotalItems;
            SiteMapSettings.PopularPublisherTags.TagDisplayCount = siteMapData.PopularPublisherTags.TotalItems <= 0 ? 50 : siteMapData.PopularPublisherTags.TotalItems;
            SiteMapSettings.RecentBooks.TotalItems = siteMapData.RecentBooks.TotalItems <= 0 ? 25 : siteMapData.RecentBooks.TotalItems;

            SiteMapSettings.BooksByMonth.Fixed.Enabled = siteMapData.BooksByMonth.Fixed.Enabled;
            SiteMapSettings.BooksByMonth.Fixed.FromMonth = siteMapData.BooksByMonth.Fixed.FromMonth <= 0 ? 1 : siteMapData.BooksByMonth.Fixed.FromMonth;
            SiteMapSettings.BooksByMonth.Fixed.FromMonth = siteMapData.BooksByMonth.Fixed.FromMonth > 12 ? 12 : siteMapData.BooksByMonth.Fixed.FromMonth;
            SiteMapSettings.BooksByMonth.Fixed.FromYear = siteMapData.BooksByMonth.Fixed.FromYear <= 0 ? DateTime.Now.Year - 2 : siteMapData.BooksByMonth.Fixed.FromYear;
            SiteMapSettings.BooksByMonth.Fixed.FromYear = siteMapData.BooksByMonth.Fixed.FromYear > DateTime.Now.Year ? DateTime.Now.Year - 2 : siteMapData.BooksByMonth.Fixed.FromYear;

            SiteMapSettings.BooksByMonth.Relative.Enabled  = siteMapData.BooksByMonth.Relative.Enabled;
            SiteMapSettings.BooksByMonth.Relative.TotalMonthsFromCurrent = siteMapData.BooksByMonth.Relative.TotalMonthsFromCurrent <= 0 ? 48 : siteMapData.BooksByMonth.Relative.TotalMonthsFromCurrent;
            SiteMapSettings.BooksByMonth.Relative.PopulateAbsoluteMonthYear();
        }
    }
}