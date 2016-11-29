using System;
using System.Collections.Generic;
using ProductsEStore.Repository.DataBase;
using System.Linq;

namespace ProductsEStore.WebApi
{
    public enum FILTER
    {
        recent = 1,
        hit = 2
    }

    public class TagManager
    {
        ProductStoreEntities dbContext;
        public TagManager()
        {
            dbContext = new ProductStoreEntities();
        }

        public IEnumerable<PopularTag> GetAllPopularTags(string filterBy, int totalItems)
        {
            IEnumerable<PopularTag> tags = new List<PopularTag>();
            if (filterBy == "recent")
            {
                tags = (from pst in dbContext.PopularTags orderby pst.LastSearchedOn descending select pst).Take(totalItems);
            }
            else
            {
                tags = (from pst in dbContext.PopularTags orderby pst.Count ascending select pst).Take(totalItems); ;
            }
            return tags;
        }

        public IEnumerable<PopularTag> GetPopularTagsByHits(int totalItems)
        {
            IEnumerable<PopularTag> tags = GetAllPopularTags("hit", totalItems);
            return tags;
        }

        public IEnumerable<PopularTag> GetPopularTagsByRecent(int totalItems)
        {
            IEnumerable<PopularTag> tags = GetAllPopularTags("recent", totalItems);
            return tags;
        }

        public void PostPopularTag(PopularTag tag)
        {
            var popularTag = GetPopularTag(tag.Keyword);
            if (popularTag == null)
            {
                AddPopularTag(tag);
            }
            else
            {
                popularTag.Count += 1;
                popularTag.LastSearchedOn = DateTime.Now;
                UpdatePopularTag(popularTag.Id, popularTag);
            }
        }

        public void PutPopularTag(int id, PopularTag tag)
        {
            UpdatePopularTag(id, tag);
        }

        public void DeletePopularTag(PopularTag tag)
        {
            var popularTag = dbContext.PopularTags.Where(pst => pst.Id == tag.Id).Select(pst => pst).FirstOrDefault();
            dbContext.DeleteObject(popularTag);
            dbContext.SaveChanges();
        }

        private PopularTag GetPopularTag(string keyword)
        {
            var popularTag = from pst in dbContext.PopularTags where pst.Keyword == keyword select pst;
            return popularTag.FirstOrDefault();
        }

        private void AddPopularTag(PopularTag tag)
        {
            dbContext.AddToPopularTags(tag);
            dbContext.SaveChanges();
        }

        private void UpdatePopularTag(int id, PopularTag tag)
        {
            var popularTag = dbContext.PopularTags.Where(pst => pst.Id == id).Select(pst => pst).FirstOrDefault();
            popularTag.Id = tag.Id;
            popularTag.Keyword = tag.Keyword;
            popularTag.LastSearchedOn = DateTime.Now;
            popularTag.Count = tag.Count;
            popularTag.CreatedOn = DateTime.Now;
            dbContext.SaveChanges();
        }
    }
}