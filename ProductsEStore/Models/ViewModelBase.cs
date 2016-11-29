using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Core;

namespace ProductsEStore.Models
{
    // This is StronglyTyped ViewModel For Layout
    public class ViewModelBase
    {
        public PopularTagData PopularTagData;
        public NavigationBar NavigationBar;

        public ViewModelBase()
        {
            PopularTagData = new PopularTagData();
        }

        // Dependency Injection
        IRepository _repository;
        public ViewModelBase(IRepository repository)
            : base()
        {
            _repository = repository;
            NavigationBar = new NavigationBar(_repository);
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
            _repository = repository;
            RenderSortByListMenu = true;
            Categories = _repository.GetCategoryListItems();
            SortByListItems = _repository.GetSortByListItems();
        }
    }
}