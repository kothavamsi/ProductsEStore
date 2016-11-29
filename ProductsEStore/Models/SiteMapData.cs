using System;
using System.Collections.Generic;
using System.Linq;
using ProductsEStore.Core;
using ProductsEStore.Repository.DataBase;
using ProductsEStore.SiteMap;
using ProductsEStore.WebApi;

namespace ProductsEStore.Models
{
    public class TagData
    {
        public string TagName { get; set; }
        public string Url { get; set; }
        public int Weight { get; set; }

        public TagData()
        {
        }
    }

    public class PopularTagData
    {
        public string Title { get; set; }
        public IEnumerable<TagData> PopularTags { get; set; }
        public int TotalTagsToGet { get; set; }

        public PopularTagData()
        {
            PopularTags = new List<TagData>();
            TotalTagsToGet = SiteMapSettings.PopularTags.TagDisplayCount;
        }
    }

    public class PopularAuthorData
    {
        public string Title { get; set; }
        public IEnumerable<TagData> PopularAuthorTags { get; set; }
        public int TotalTagsToGet { get; set; }
        public PopularAuthorData()
        {
            PopularAuthorTags = new List<TagData>();
            TotalTagsToGet = SiteMapSettings.PopularAuthorTags.TagDisplayCount;
        }
    }

    public class PopularPublisherData
    {
        public string Title { get; set; }
        public IEnumerable<TagData> PopularPublisherTags { get; set; }
        public int TotalTagsToGet { get; set; }
        public PopularPublisherData()
        {
            PopularPublisherTags = new List<TagData>();
            TotalTagsToGet = SiteMapSettings.PopularPublisherTags.TagDisplayCount;
        }
    }

    public class MonthlyTreeItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string DisplayValue { get; set; }
        public MonthlyTreeItem()
        {
        }
    }

    public class MonthlyData
    {
        public string Title { get; set; }
        public IList<MonthlyTreeItem> MonthlyTreeItems { get; set; }

        // Dependency Injection
        IRepository _repository;
        public MonthlyData(IRepository repository)
        {
            _repository = repository;
            MonthlyTreeItems = new List<MonthlyTreeItem>();
            LoadMonthlyData();
        }

        public void LoadMonthlyData()
        {
            int startMonth, startYear, endMonth, endYear;

            if (SiteMapSettings.BooksByMonth.Relative.Enabled == true)
            {
                startMonth = SiteMapSettings.BooksByMonth.Relative.FromMonth;
                startYear = SiteMapSettings.BooksByMonth.Relative.FromYear;
            }
            else
            {
                startMonth = SiteMapSettings.BooksByMonth.Fixed.FromMonth;
                startYear = SiteMapSettings.BooksByMonth.Fixed.FromYear;
            }

            endMonth = DateTime.Now.Month;
            endYear = DateTime.Now.Year;

            DateTime dt = new DateTime(endYear, endMonth, 1);
            while (!(dt.Month == startMonth && dt.Year == startYear))
            {
                MonthlyTreeItems.Add(
                new MonthlyTreeItem()
                {
                    DisplayValue = string.Format("{0} {1} ({2})", SiteMapData.MonthNames[dt.Month], dt.Year, _repository.GetProductsByYearMonth(dt.Year, dt.Month).Count),
                    Month = dt.Month,
                    Year = dt.Year
                });
                dt = dt.AddMonths(-1);
            }
        }
    }

    public class SiteMapData : ViewModelBase
    {
        public static string[] MonthNames = new string[] { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        new public PopularTagData PopularTagData;
        public PopularAuthorData PopularAuthorData;
        public PopularPublisherData PopularPublisherData;
        public MonthlyData MonthlyData;

        // Dependency Injection
        IRepository _repository;
        public SiteMapData(IRepository repository)
            : base(repository)
        {
            this._repository = repository;
            PopularTagData = new PopularTagData();
            PopularAuthorData = new PopularAuthorData();
            PopularPublisherData = new PopularPublisherData();
            MonthlyData = new MonthlyData(_repository);
            LoadSiteMapData();
        }

        public void LoadSiteMapData()
        {
            PopularTagData.PopularTags = MapDBPopularSearchTagToViewTagData(new TagManager().GetPopularTagsByRecent(SiteMapSettings.PopularTags.TagDisplayCount));
        }

        public IEnumerable<TagData> MapDBPopularSearchTagToViewTagData(IEnumerable<PopularTag> dbTags)
        {
            var tags = from dbTag in dbTags
                       select new TagData()
                       {
                           TagName = dbTag.Keyword,
                           Url = "",
                           Weight = dbTag.Count
                       };
            return tags;
        }

    }
}