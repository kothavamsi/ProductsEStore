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

        public ProductsViewLayout GetProductsViewLayout(RequestCriteria reqCriteria, RepositoryResponse repoResp, int columns, int pageSize, int pagerSize, SitePage sitePage)
        {
            ProductsViewLayout productsViewLayout = null;
            if (sitePage.Layout.ViewType == WebsiteSettings.ViewType.grid)
            {
                productsViewLayout = new GridViewLayout(reqCriteria, repoResp, columns, pageSize, pagerSize);
            }
            if (sitePage.Layout.ViewType == WebsiteSettings.ViewType.list)
            {
                productsViewLayout = new ListViewLayout(reqCriteria, repoResp, pageSize, pagerSize);
            }
            return productsViewLayout;
        }
    }
}
