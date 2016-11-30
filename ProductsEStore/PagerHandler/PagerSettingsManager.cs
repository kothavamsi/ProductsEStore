using System.Configuration;

namespace ProductsEStore.PagerHandler.Config
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
        }
    }
}

