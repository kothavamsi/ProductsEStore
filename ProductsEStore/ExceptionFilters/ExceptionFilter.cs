using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsEStore.Models;
using ProductsEStore.Controllers;

namespace ProductsEStore.ExceptionFilters
{
    class RequestCriteriaException : Exception
    {
        public RequestCriteriaException()
        {

        }
    }

    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is RequestCriteriaException)
            {
                filterContext.Result = new ViewResult()
                {
                    ViewData = new ViewDataDictionary<ViewModelBase>(new MyBaseController().ViewModelBaseObj),
                    ViewName = "error"
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}