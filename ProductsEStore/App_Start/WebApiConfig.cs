using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using ProductsEStore.WebApi;

namespace ProductsEStore
{
    //public class CustomJsonFormatter : JsonMediaTypeFormatter
    //{
    //    public CustomJsonFormatter()
    //    { 
    //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
    //        this.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    //    }

    //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    //    {
    //        base.SetDefaultContentHeaders(type, headers, mediaType);
    //        headers.ContentType = new MediaTypeHeaderValue("application/json");
    //    }
    //}
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "tagsUri",
                routeTemplate: "api/PopularTags/{filterBy}/{totalItems}",
                defaults: new { controller = "PopularTags", totalItems = RouteParameter.Optional }
            );

            //config.Formatters.Add(new TagSliceCustomJsonFormatter());
            //config.Formatters.Add(new CustomJsonFormatter());
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
