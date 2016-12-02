using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace ProductsEStore.WebsiteSettings
{
    public class MyConfigurationManager
    {
        public Configuration GetConfiguration()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Configuration));
            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(@"~\WebsiteSettings\Configuration.xml"));
            Configuration configuration = (Configuration)xs.Deserialize(sr);
            sr.Close();
            return configuration;
        }
    }
}