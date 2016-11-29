using System.Collections.Generic;
using System.Web.Http;
using ProductsEStore.Repository.DataBase;

namespace ProductsEStore.WebApi
{
    public class PopularTagsController : ApiController
    {
        // GET api/PopularSearchTags/recent
        // GET api/PopularSearchTags/hit
        public IEnumerable<PopularTag> Get(string filterBy, int totalItems)
        {
            return new TagManager().GetAllPopularTags(filterBy, totalItems);
        }

        // POST api/PopularSearchTags
        public void Post([FromBody]PopularTag tag)
        {
            new TagManager().PostPopularTag(tag);
        }

        // PUT api/PopularSearchTags/5
        public void Put(int id, [FromBody]PopularTag tag)
        {
            new TagManager().PutPopularTag(id,tag);
        }

        // DELETE api/PopularSearchTags/5
        public void Delete(PopularTag tag)
        {
            new TagManager().DeletePopularTag(tag);
        }
    }
}