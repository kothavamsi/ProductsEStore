using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsEStore.Models;

namespace ProductsEStore.Core
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
        IList<IProduct> GetAllProducts();

        /// <summary>
        /// Gets Number of products per year,per month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        IList<IProduct> GetProductsByYearMonth(int year, int month);

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
        Response GetProducts(RequestCriteria requestCriteria);
    }
}