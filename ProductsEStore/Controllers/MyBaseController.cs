using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.WebsiteSettings;
using ProductsEStore.Core;

namespace ProductsEStore.Controllers
{
    public class MyBaseController : Controller
    {
        public ViewModelBase BaseModel;
        public MyBaseController()
        {
            BaseModel = new ViewModelBase();
        }

        public ProductsViewLayout GetProductsViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp)
        {
            ProductsViewLayout productsViewLayout = null;
            ProductsEStore.WebsiteSettings.ViewType viewType = GetViewType(reqCriteria);
            if (viewType == WebsiteSettings.ViewType.list)
            {
                productsViewLayout = new ListViewLayout(reqCriteria, repoResp);
            }
            if (viewType == WebsiteSettings.ViewType.grid)
            {
                productsViewLayout = new GridViewLayout(reqCriteria, repoResp);
            }
            return productsViewLayout;
        }

        private WebsiteSettings.ViewType GetViewType(RequestCriteria reqCriteria)
        {
            WebsiteSettings.ViewType viewType = WebsiteSettings.ViewType.list;
            switch (reqCriteria.RequestMode)
            {
                case RequestMode.HomePageProducts:
                    viewType = BaseModel.Configuration.DisplaySettings.HomePage.Layout.ViewType;
                    break;
                case RequestMode.GetItemsInCategory:
                    viewType = BaseModel.Configuration.DisplaySettings.CategoryPage.Layout.ViewType;
                    break;
                case RequestMode.MostReviews:
                    viewType = BaseModel.Configuration.DisplaySettings.MostReviewsPage.Layout.ViewType;
                    break;
                case RequestMode.NewReleases:
                    viewType = BaseModel.Configuration.DisplaySettings.NewReleasesPage.Layout.ViewType;
                    break;
                case RequestMode.SearchKeyWord:
                    viewType = BaseModel.Configuration.DisplaySettings.SearchPage.Layout.ViewType;
                    break;
                case RequestMode.Monthly:
                    viewType = BaseModel.Configuration.DisplaySettings.ProductByYearMonthPage.Layout.ViewType;
                    break;
            }
            return viewType;
        }
    }
}
