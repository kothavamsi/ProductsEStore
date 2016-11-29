using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.Core;

namespace ProductsEStore.Controllers
{
    public class MyBaseController : Controller
    {
        public ViewModelBase ViewModelBaseObj;
        public IRepository _repository;
        public MyBaseController()
        {
            _repository = new DatabaseRepository();

            // Dependency Injection
            ViewModelBaseObj = new ViewModelBase(_repository);
        }
               
    }
}
