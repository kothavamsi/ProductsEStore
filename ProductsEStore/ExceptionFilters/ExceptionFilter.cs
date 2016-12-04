using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.Controllers;
using ProductsEStore.Core;
using ProductsEStore.LogHandler;

namespace ProductsEStore.ExceptionFilters
{
    class RequestCriteriaException : Exception
    {
        public RequestCriteria RequestCriteria { get; set; }
        public RequestCriteriaException(RequestCriteria reqCriteria)
        {
            RequestCriteria = reqCriteria;
        }
    }

    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is RequestCriteriaException)
            {
                var msg = string.Format("Request Criteria Exception:{0}",
                    ((RequestCriteriaException)filterContext.Exception).RequestCriteria.SeoFriendlyCategoryName.ToString());
                LogManager.Write(msg);

                filterContext.Result = new ViewResult()
                {
                    ViewData = new ViewDataDictionary<ViewModelBase>(new Error(filterContext.Exception)),
                    ViewName = "Error"
                };
                filterContext.ExceptionHandled = true;
            }
            else
                if (!filterContext.ExceptionHandled && filterContext.Exception is Exception)
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewData = new ViewDataDictionary<ViewModelBase>(new Error(filterContext.Exception)),
                        ViewName = "Error"
                    };
                    filterContext.ExceptionHandled = true;
                }
        }
    }
}