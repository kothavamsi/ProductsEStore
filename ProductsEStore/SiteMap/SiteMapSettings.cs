using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using privateClasses;

namespace privateClasses
{
    public class PopularTags
    {
        public int TagDisplayCount { get; set; }

        public PopularTags()
        {
            TagDisplayCount = 100;
        }

    }

    public class PopularAuthorTags
    {
        public int TagDisplayCount { get; set; }

        public PopularAuthorTags()
        {
            TagDisplayCount = 100;
        }
    }

    public class PopularPublisherTags
    {
        public int TagDisplayCount { get; set; }

        public PopularPublisherTags()
        {
            TagDisplayCount = 100;
        }
    }

    public class RecentBooks
    {
        public int TotalItems { get; set; }

        public RecentBooks()
        {
            TotalItems = 100;
        }
    }

    public class BooksByMonth
    {
        public Relative Relative;
        public Fixed Fixed;

        public BooksByMonth()
        {
            Relative = new Relative();
            Fixed = new Fixed();
        }
    }

    public class Relative
    {
        public int TotalMonthsFromCurrent { get; set; }
        public int FromYear { get; set; }
        public int FromMonth { get; set; }
        public bool Enabled { get; set; }

        public Relative()
        {
            Enabled = false;
            TotalMonthsFromCurrent = 48;
        }
        public void PopulateAbsoluteMonthYear()
        {
            FromYear = DateTime.Now.AddMonths(-TotalMonthsFromCurrent).Year;
            FromMonth = DateTime.Now.AddMonths(-TotalMonthsFromCurrent).Month;
        }
    }

    public class Fixed
    {
        public int FromYear { get; set; }
        public int FromMonth { get; set; }
        public bool Enabled { get; set; }

        public Fixed()
        {
            Enabled = false;
            FromYear = DateTime.Now.Year;
            FromMonth = 1;
        }
    }
}

namespace ProductsEStore.SiteMap
{
    public static class SiteMapSettings
    {
        public static PopularTags PopularTags;
        public static PopularAuthorTags PopularAuthorTags;
        public static PopularPublisherTags PopularPublisherTags;
        public static RecentBooks RecentBooks;
        public static BooksByMonth BooksByMonth;

        static SiteMapSettings()
        {
            PopularTags = new PopularTags();
            PopularAuthorTags = new PopularAuthorTags();
            PopularPublisherTags = new PopularPublisherTags();
            RecentBooks = new RecentBooks();
            BooksByMonth = new BooksByMonth();
        }
    }
}