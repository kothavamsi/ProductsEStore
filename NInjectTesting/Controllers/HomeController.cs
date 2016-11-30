using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Core;

namespace NInjectTesting.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        IRepository _iRepository;
        public HomeController(IRepository iRepository)
        {
            _iRepository = iRepository;
        }

        public string Index()
        {
            return _iRepository.GetMessageFromRepository();
        }

    }
}
