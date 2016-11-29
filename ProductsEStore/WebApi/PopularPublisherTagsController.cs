using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyEBooks.WebApi
{
    public class PopularPublisherTagsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<PopularPublisherTag> Get()
        {
            return new TagManager().GetAllPopularPublisherTags();
        }

        // GET api/<controller>/5
        public PopularPublisherTag Get(int id)
        {
            return new TagManager().GetPopularPublisherTag(id);
        }

        // POST api/<controller>
        public void Post([FromBody]PopularPublisherTag tag)
        {
            new TagManager().AddPopularPublisherTag(tag);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]PopularPublisherTag tag)
        {
            new TagManager().UpdatePopularPublisherTag(id, tag);
        }

        // DELETE api/<controller>/5
        public void Delete(PopularPublisherTag tag)
        {
            new TagManager().DeletePopularPublisherTag(tag);
        }
    }
}