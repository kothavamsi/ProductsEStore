using System.Collections.Generic;
using ProductsEStore.Models;
using ProductsEStore.Core;

namespace ProductsEStore.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Saves Contact Us Form Information into database
        /// </summary>
        /// <param name="contact"></param>
        void SaveContact(Contact contact);

        /// <summary>
        /// Gets All Products
        /// </summary>
        /// <returns></returns>
        //IList<Product> GetAllProducts();

        /// <summary>
        /// Gets Number of products per year,per month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        int GetProductCountForYearMonth(int year, int month);
        
        /// <summary>
        /// Gets Category ListMenu Items
        /// </summary>
        /// <returns>List of CategoryListItem</returns>
        IList<CategoryListItem> GetCategoryListItems();

        /// <summary>
        /// Gets SortBy ListMenu Items
        /// </summary>
        /// <returns>List of CategoryListItem</returns>
        IList<SortByListItem> GetSortByListItems();

        /// <summary>
        /// Gets Products that matches RequestCriteria
        /// </summary>
        /// <param name="requestCriteria">Selection Criteria for the type of products we want to include in response </param>
        /// <returns>Response that contains products matched to RequestCriteria</returns>
        RepositoryResponse GetProducts(RequestCriteria requestCriteria);
    }
}