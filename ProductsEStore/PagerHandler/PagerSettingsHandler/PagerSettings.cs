using System.Collections.Generic;

namespace ProductsEStore.PagerHandler.PagerSettingsHandler
{
    public static class PagerSettings
    {
        public static int PagerDisplayLength { get; set; }
        public static int PageSize { get; set; }

        static PagerSettings()
        {
        }
    }
}

