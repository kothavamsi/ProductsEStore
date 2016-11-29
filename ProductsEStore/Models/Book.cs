using System;

namespace ProductsEStore.Models
{
    public class Book : IProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN_10 { get; set; }
        public string ISBN_13 { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedDate { get; set; }
        public double SizeMB { get; set; }
        public string BookCategory { get; set; }
        public ProductType ProductType { get; set; }
    }
}
