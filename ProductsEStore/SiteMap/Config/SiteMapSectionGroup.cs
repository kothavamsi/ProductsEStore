using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ProductsEStore.SiteMap.Config
{
    public class SiteMapSectionGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty("popularTags")]
        public PopularTagsSection PopularTags
        {
            get { return (PopularTagsSection)Sections["popularTags"]; }
        }

        [ConfigurationProperty("popularAuthorTags")]
        public PopularAuthorTagsSection PopularAuthorTags
        {
            get { return (PopularAuthorTagsSection)Sections["popularAuthorTags"]; }
        }

        [ConfigurationProperty("popularPublisherTags")]
        public PopularPublisherTagsSection PopularPublisherTags
        {
            get { return (PopularPublisherTagsSection)Sections["popularPublisherTags"]; }
        }

        [ConfigurationProperty("recentBooks")]
        public RecentBooksSection RecentBooks
        {
            get { return (RecentBooksSection)Sections["recentBooks"]; }
        }

        [ConfigurationProperty("booksByMonth")]
        public BooksByMonthSectionGroup BooksByMonth
        {
            get { return (BooksByMonthSectionGroup)SectionGroups["booksByMonth"]; }
        }

    }

    public class PopularTagsSection : ConfigurationSection
    {
        [ConfigurationProperty("totalItems")]
        public int TotalItems
        {
            get { return (int)this["totalItems"]; }
        }
    }

    public class PopularAuthorTagsSection : ConfigurationSection
    {
        [ConfigurationProperty("totalItems")]
        public int TotalItems
        {
            get { return (int)this["totalItems"]; }
        }
    }

    public class PopularPublisherTagsSection : ConfigurationSection
    {
        [ConfigurationProperty("totalItems")]
        public int TotalItems
        {
            get { return (int)this["totalItems"]; }
        }
    }

    public class RecentBooksSection : ConfigurationSection
    {
        [ConfigurationProperty("totalItems")]
        public int TotalItems
        {
            get { return (int)this["totalItems"]; }
        }
    }

    public class BooksByMonthSectionGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty("relative")]
        public BooksByMonthRelativeSection Relative
        {
            get { return (BooksByMonthRelativeSection)Sections["relative"]; }
        }

        [ConfigurationProperty("fixed")]
        public BooksByMonthFixedSection Fixed
        {
            get { return (BooksByMonthFixedSection)Sections["fixed"]; }
        }
    }

    public class BooksByMonthRelativeSection : ConfigurationSection
    {
        [ConfigurationProperty("totalMonthsFromCurrent")]
        public int TotalMonthsFromCurrent
        {
            get { return (int)this["totalMonthsFromCurrent"]; }
        }

        [ConfigurationProperty("enabled")]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
        }
    }

    public class BooksByMonthFixedSection : ConfigurationSection
    {
        [ConfigurationProperty("fromYear")]
        public int FromYear
        {
            get { return (int)this["fromYear"]; }
        }

        [ConfigurationProperty("fromMonth")]
        public int FromMonth
        {
            get { return (int)this["fromMonth"]; }
        }

        [ConfigurationProperty("enabled")]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
        }
    }
}