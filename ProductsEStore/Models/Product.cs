using System;

namespace ProductsEStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CoverPageUrl { get; set; }
        public string DetailPageUrl { get; set; }
        public int Edition { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN_10 { get; set; }
        public string ISBN_13 { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
