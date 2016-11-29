using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyEBooks.Models;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using MyEBooks.BookRepository.FileSystem.BooksLocationSettingsHandler;

namespace MyEBooks.Core
{
    public class FileSystemRepository : IRepository
    {
        public Response GetProducts(RequestCriteria requestCriteria)
        {
            var response = new Response();
            response.ProductCount = 30;
            if (requestCriteria.RequestMode == RequestMode.SearchKeyWord)
            {
                response.ViewProducts = GetProductsBySearchKeyword(requestCriteria.SearchKeyWord).Take(10).ToList();
            }
            if (requestCriteria.RequestMode == RequestMode.GetItemsInCategory)
            {
                response.ViewProducts = GetProductsByCategory(requestCriteria.SeoFriendlyCategoryName).Take(10).ToList();
            }
            return response;
        }

        public IList<IProduct> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public IList<IProduct> GetProductsByYearMonth(int year, int month)
        {
            List<IProduct> foundBooks = new List<IProduct>();
            foundBooks = FindBooks(string.Format("{0}", year));
            return foundBooks;
        }

        public IList<CategoryListItem> GetCategoryListItems()
        {
            IList<CategoryListItem> categoryLstItems = new List<CategoryListItem>();
            categoryLstItems.Add(new CategoryListItem()
            {
                Id = 1,
                ParentId = 0,
                Rank = 2,
                Weight = 1,
                Enabled = true,
                Name = "Wcf Technologies",
                SEOFriendlyText = "WCF",
                BackEndPurposeText = "WCF"
            });

            categoryLstItems.Add(new CategoryListItem()
            {
                Id = 2,
                ParentId = 0,
                Rank = 1,
                Weight = 2,
                Enabled = true,
                Name = "LINQ Technologies",
                SEOFriendlyText = "LINQ",
                BackEndPurposeText = "LINQ"
            });
            categoryLstItems.Add(new CategoryListItem()
            {
                Id = 3,
                ParentId = 0,
                Rank = 3,
                Weight = 2,
                Enabled = true,
                Name = "ASP .NET",
                SEOFriendlyText = "AspDotNet",
                BackEndPurposeText = "AspDotNet"
            });
            categoryLstItems.Add(new CategoryListItem()
            {
                Id = 4,
                ParentId = 0,
                Rank = 3,
                Weight = 2,
                Enabled = true,
                Name = "C#",
                SEOFriendlyText = "CSharp",
                BackEndPurposeText = "CSharp"
            });
            return categoryLstItems;
        }

        public IList<SortByListItem> GetSortByListItems()
        {
            IList<SortByListItem> sortByLstItems = new List<SortByListItem>();
            sortByLstItems.Add(new SortByListItem()
            {
                Id = 1,
                Enabled = true,
                Rank = 2,
                Weight = 1,
                Name = "upload(default)",
                SeoFriendlyName = "upload",
                BackEndPurposeText = "upload"
            });

            sortByLstItems.Add(new SortByListItem()
            {
                Id = 2,
                Enabled = true,
                Rank = 3,
                Weight = 1,
                Name = "Publication Date",
                SeoFriendlyName = "publication-date",
                BackEndPurposeText = "publicationdate"
            });
            sortByLstItems.Add(new SortByListItem()
            {
                Id = 3,
                Enabled = true,
                Rank = 1,
                Weight = 1,
                Name = "Avg. User Review",
                SeoFriendlyName = "avg-user-review",
                BackEndPurposeText = "avgUserReview"
            });

            return sortByLstItems;
        }

        private IList<IProduct> GetProductsBySearchKeyword(string keyword)
        {
            IList<IProduct> books = new List<IProduct>();
            books = FindBooks(keyword);
            return books;
        }

        private IList<IProduct> GetProductsByCategory(string categoryName)
        {
            List<IProduct> foundBooks = new List<IProduct>();
            string categoryLocationTemplate;
            if (BooksLocationSettings.categories.TryGetValue(categoryName, out categoryLocationTemplate))
            {
                var categoryLocations = categoryLocationTemplate.Split(';');
                foreach (var categoryLocation in categoryLocations)
                {
                    string[] files = Directory.GetFiles(categoryLocation, "*.*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        var book = MapFileToBook(file);
                        foundBooks.Add(book);
                    }
                }
            }
            return foundBooks;
        }

        private static List<IProduct> FindBooks(string keyword)
        {
            List<IProduct> foundBooks = new List<IProduct>();
            foreach (var path in BooksLocationSettings.Locations)
            {
                var r = FindBooksAtPath(keyword, path);
                foundBooks.AddRange(r);
            }
            return foundBooks;
        }

        private static List<Book> FindBooksAtPath(string keyword, string path)
        {
            List<Book> foundBooks = new List<Book>();
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            var foundFiles = files.Select(f => new { FileNameOrginalCase = f, FileNameLowerCase = f.ToLower() }).Where(f => FileNameContains(f.FileNameLowerCase, keyword)).Select(f => f.FileNameOrginalCase).ToList();
            foreach (string file in foundFiles)
            {
                var book = MapFileToBook(file);
                foundBooks.Add(book);
            }
            return foundBooks;
        }

        private static Book MapFileToBook(string file)
        {
            FileInfo fi = new FileInfo(file);
            double fileLength = fi.Length;
            double kbFileLength = fileLength / 1024;
            double mbFileLength = kbFileLength / 1024;
            return new Book() { Title = fi.Name, SizeMB = mbFileLength, PublishedDate = fi.CreationTime };
        }

        private static bool FileNameContains(string searchString, string keyword)
        {
            var retVal = false;
            Regex regEx = new Regex(keyword);
            retVal = regEx.IsMatch(searchString);
            return retVal;
        }




        public void SaveContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}