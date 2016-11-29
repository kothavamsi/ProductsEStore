using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyEBooks.Models;

namespace MyEBooks.Core
{

    //public class BookManager
    //{
    //    public IRepository repository;
        
    //    public BookManager()
    //    {
    //        // default is FileSystemRepository
    //        this.repository = new FileSystemRepository();
    //    }

    //    public BookManager(IRepository repository)
    //    {
    //        this.repository = repository;
    //    }

    //    public IList<Book> GetBooksByKeyword(string keyword)
    //    {
    //        IList<Book> books = new List<Book>();
    //        books = repository.GetBooksByKeyword(keyword);
    //        return books;
    //    }

    //    internal IList<Book> GetBooksByCategory(string categoryName)
    //    {
    //         IList<Book> books = new List<Book>();
    //         books = repository.GetBooksByCategory(categoryName);
    //        return books;
    //    }

    //    internal IList<Book> GetBooksByYearMonth(int year, int month)
    //    {
    //        IList<Book> books = new List<Book>();
    //        books = repository.GetBooksByYearMonth(year,month);
    //        return books;
    //    }
    //}
}