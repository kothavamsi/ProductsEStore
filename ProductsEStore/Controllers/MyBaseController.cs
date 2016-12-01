using System.Web.Mvc;
using ProductsEStore.Models;

namespace ProductsEStore.Controllers
{
    public class MyBaseController : Controller
    {
        public ViewModelBase BaseModel;
        public MyBaseController()
        {
            BaseModel = new ViewModelBase();
        }
    }
}
