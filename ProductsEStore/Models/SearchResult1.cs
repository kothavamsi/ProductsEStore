using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEBooks.Models
{
    public class SearchResult : ViewModelBase
    {
        public bool FoundResult { get; set; }
        public string SearchKeyword { get; set; }
        public IList<Book> Books { get; set; }
        public IList<Book> DisplayedBooks { get; set; }
        public int PageNo { get; set; }
        public Pager Pager { get; set; }
        public SearchResult()
        {
            Books = new List<Book>();
            DisplayedBooks = new List<Book>();
            SearchKeyword = "";
            PageNo = 1;
            Pager = new Pager();
            FoundResult = false;
        }
    }
}