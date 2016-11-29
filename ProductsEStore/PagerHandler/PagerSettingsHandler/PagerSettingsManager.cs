using System.Configuration;
using ProductsEStore.LogHandler.Config;
using ProductsEStore.PagerHandler.Config;

namespace ProductsEStore.PagerHandler.PagerSettingsHandler
{
    public static class PagerSettingsManager
    {
        static PagerSettingsManager()
        {

        }

        public static void LoadSettings()
        {
            PagerManagerSection pms = (PagerManagerSection)ConfigurationManager.GetSection("pagerManager");
            PagerSettings.PagerDisplayLength = pms.PagerDisplayLength;
            PagerSettings.PageSize = pms.PageSize;
        }
    }
}

