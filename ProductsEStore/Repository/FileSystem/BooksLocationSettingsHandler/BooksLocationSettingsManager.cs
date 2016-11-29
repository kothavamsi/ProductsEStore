using System.Configuration;
using System.IO;
using MyEBooks.BookRepository.FileSystem.BooksLocationSettingsHandler;
using MyEBooks.BookRepository.FileSystem.Config;

namespace MyEBooks.LogHandler.LogSettingsHandler
{
    public static class BooksLocationSettingsManager
    {
        static BooksLocationSettingsManager()
        {

        }

        public static void LoadSettings()
        {
            BooksLocationManagerSection blms = (BooksLocationManagerSection)ConfigurationManager.GetSection("booksLocationManager");
            foreach (LocationElement le in blms.Locations)
            {
                BooksLocationSettings.Locations.Add(le.Location);
            }

            foreach (var location in BooksLocationSettings.Locations)
            {
                var categoryLocations = Directory.GetDirectories(location);
                foreach(string categoryLocation in categoryLocations)
                {
                    var categoryInfo  = new DirectoryInfo(categoryLocation);
                    string categoryName = categoryInfo.Name.ToLower();
                    string categoryPath = categoryInfo.FullName;
                    string oldCategoryPath;
                    if (BooksLocationSettings.categories.TryGetValue(categoryName, out oldCategoryPath))
                    {
                        categoryPath = oldCategoryPath + ";" + categoryPath;
                    }
                    BooksLocationSettings.categories[categoryName] = categoryPath.ToLower();
                }
            }
        }
    }
}
