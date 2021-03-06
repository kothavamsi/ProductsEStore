﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.WebApi;
using ProductsEStore.Core;

namespace ProductsEStore.Controllers
{
    public class HomeController : MyBaseController
    {
        public ActionResult Index(string sort = "post-date", int pageNo = 1)
        {
            RequestCriteria requestCriteria = new RequestCriteria()
            {
                RequestMode = RequestMode.All,
                SortMode = SortModeMappings.GetSortMode(sort),
                PageNo = pageNo
            };

            Response response = _repository.GetProducts(requestCriteria);

            // Dependency Injection
            var productListViewResult = Helper.GetProductListViewResult(requestCriteria, response, _repository);
            string headerMessage = string.Format("Total {0} Books", response.ProductCount, requestCriteria.SeoFriendlyCategoryName);
            productListViewResult.Header = new ProductListViewResultHeader()
            {
                Message = headerMessage
            };
            return View("Index", productListViewResult);
        }

        public ActionResult About()
        {
            this.ViewModelBaseObj.NavigationBar.RenderSortByListMenu = false;
            return View("About", this.ViewModelBaseObj);
        }

        public ActionResult Contact()
        {
            // Dependency Injection
            Contact contact = new Contact(_repository);
            contact.NavigationBar.RenderSortByListMenu = false;
            return View("Contact", contact);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            // Dependency Injection made manually as Contact object is created by MVC framework 
            // by calling zero argument constructor but our dependency is injected using one argument constructor
            contact.NavigationBar = new NavigationBar(_repository);

            if (ModelState.IsValid)
            {
                this.ViewModelBaseObj.NavigationBar.RenderSortByListMenu = false;
                return View("ContactSuccess", this.ViewModelBaseObj);
            }
            else
            {
                _repository.SaveContact(contact);
                contact.NavigationBar.RenderSortByListMenu = false;
                return View("Contact", contact);
            }
        }

        public ActionResult PrivacyPolicy()
        {
            this.ViewModelBaseObj.NavigationBar.RenderSortByListMenu = false;
            return View("PrivacyPolicy", this.ViewModelBaseObj);
        }

        public ActionResult FAQ()
        {
            this.ViewModelBaseObj.NavigationBar.RenderSortByListMenu = false;
            return View("FAQ", this.ViewModelBaseObj);
        }

        public ActionResult RSS()
        {
            this.ViewModelBaseObj.NavigationBar.RenderSortByListMenu = false;
            return View("RSS", this.ViewModelBaseObj);
        }

        public ActionResult DMCA()
        {
            this.ViewModelBaseObj.NavigationBar.RenderSortByListMenu = false;
            return View("DMCA", this.ViewModelBaseObj);
        }

        public ActionResult Donate()
        {
            this.ViewModelBaseObj.NavigationBar.RenderSortByListMenu = false;
            return View("Donate", this.ViewModelBaseObj);
        }

        public ActionResult Sitemap()
        {
            // Dependency Injection
            var siteMapData = new SiteMapData(_repository);
            siteMapData.NavigationBar.RenderSortByListMenu = false;
            return View("Sitemap", siteMapData);
        }
    }
}
