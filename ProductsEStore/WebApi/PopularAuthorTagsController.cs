using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyEBooks.WebApi
{
    public class PopularAuthorTagsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<PopularAuthorTag> Get()
        {
            return new TagManager().GetAllPopularAuthorTags();
        }

        // GET api/<controller>/5
        public PopularAuthorTag Get(int id)
        {
            return new TagManager().GetPopularAuthorTag(id);
        }

        // POST api/<controller>
        public void Post([FromBody]PopularAuthorTag tag)
        {
            new TagManager().AddPopularAuthorTag(tag);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]PopularAuthorTag tag)
        {
            new TagManager().UpdatePopularAuthorTag(id, tag);
        }

        // DELETE api/<controller>/5
        public void Delete(PopularAuthorTag tag)
        {
            new TagManager().DeletePopularAuthorTag(tag);
        }
    }
}