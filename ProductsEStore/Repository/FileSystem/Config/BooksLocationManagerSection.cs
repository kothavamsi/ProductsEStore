using System;
using System.Configuration;
using System.Globalization;
using MyEBooks.LogHandler.LogSettingsHandler;

namespace MyEBooks.BookRepository.FileSystem.Config
{
    public class BooksLocationManagerSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(LocationElementCollection))]
        public LocationElementCollection Locations
        {
            get { return (LocationElementCollection)base[""]; }
        }
    }

    public class LocationElement : ConfigurationElement
    {
        [ConfigurationProperty("location")]
        public string Location
        {
            get { return (string)this["location"]; }
        }
    }

    public class LocationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LocationElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LocationElement)element).Location;
        }
        public new LocationElement this[string key]
        {
            get { return (LocationElement)BaseGet(key); }
        }
    }
}
