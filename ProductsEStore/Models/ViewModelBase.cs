using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;
using ProductsEStore.Repository.DataBase;

namespace ProductsEStore.Models
{
    // This is StronglyTyped ViewModel For Layout
    public class ViewModelBase
    {
        //public PopularTagData PopularTagData;
        public NavigationBar NavigationBar;
        public string PageTitle { get; set; }
        public string SiteName { get; set; }
        public string SiteTagLine { get; set; }
        public string SiteDomain { get; set; }
        public string TitleTemplate { get; set; }

        public ViewModelBase()
        {
            //PopularTagData = new PopularTagData();
            SiteName = "MyeBook";
            SiteDomain = "www.myebook.net";
            SiteTagLine = "free eBooks Store";
            TitleTemplate = "{{TITLE}} - " + SiteName;
            NavigationBar = new NavigationBar(new DatabaseRepository(new InMemoryCache()));
        }
    }

    public class NavigationBar
    {
        public bool RenderSortByListMenu { get; set; }
        public IList<CategoryListItem> Categories { get; set; }
        public IList<SortByListItem> SortByListItems { get; set; }

        // Dependency Injection
        IRepository _repository;
        public NavigationBar(IRepository repository)
        {
            RenderSortByListMenu = true;
            _repository = repository;
            Categories = _repository.GetCategoryListItems();
            SortByListItems = _repository.GetSortByListItems();
        }
    }
}