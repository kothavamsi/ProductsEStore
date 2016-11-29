using System;
using System.Configuration;
using System.Globalization;
using ProductsEStore.LogHandler.LogSettingsHandler;

namespace ProductsEStore.LogHandler.Config
{
    public class LogManagerSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ListenerElementCollection))]
        public ListenerElementCollection Listeners
        {
            get { return (ListenerElementCollection)base[""]; }
        }

        [ConfigurationProperty("enable")]
        public bool Enable
        {
            get { return (bool)base["enable"]; }
        }

        [ConfigurationProperty("overwrite")]
        public bool Overwrite
        {
            get { return (bool)base["overwrite"]; }
        }
    }

    public class ListenerElement : ConfigurationElement
    {
        [ConfigurationProperty("listenerType", IsRequired = true)]
        public ListenerType ListenerType
        {
            get
            {
                return (ListenerType)Enum.Parse(typeof(ListenerType), this["listenerType"].ToString());
            }
        }

        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
        }
    }

    public class ListenerElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ListenerElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ListenerElement)element).ListenerType;
        }
        public new ListenerElement this[string key]
        {
            get { return (ListenerElement)BaseGet(key); }
        }
    }
}
