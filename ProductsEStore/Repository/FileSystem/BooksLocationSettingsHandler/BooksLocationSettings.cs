using System.Collections.Generic;

namespace MyEBooks.BookRepository.FileSystem.BooksLocationSettingsHandler
{
    public static class BooksLocationSettings
    {
        public static List<string> Locations { get; set; }
        public static Dictionary<string,string> categories{ get; set; }
        static BooksLocationSettings()
        {
            Locations = new List<string>();
            categories = new Dictionary<string, string>();
        }
    }
}

