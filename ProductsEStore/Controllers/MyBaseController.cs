using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.Core;
using ProductsEStore.Repository.DataBase;

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
