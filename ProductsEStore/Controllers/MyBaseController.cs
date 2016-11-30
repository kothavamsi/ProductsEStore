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
        public ViewModelBase ViewModelBaseObj;

        public IRepository _repository;
        public ICacheService _inMemoryCache;
        public MyBaseController()
        {
            _inMemoryCache = new InMemoryCache();

             //Dependency Injection
            _repository = new DatabaseRepository(_inMemoryCache);

             //Dependency Injection
            ViewModelBaseObj = new ViewModelBase(_repository);
        }

    }
}
