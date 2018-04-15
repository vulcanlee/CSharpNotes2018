using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XamarinCore.Models;

namespace XamarinCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DatabaseContext _myDbContext = new DatabaseContext();

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //_myDbContext.Todos.Add(new Models.Todo()
            //{
            //    Title = "Title",
            //    HasCompleted = false
            //});
            //_myDbContext.SaveChanges();
            //var foo = _myDbContext.Todos.ToList().Select(x => x.Title);
            //return foo;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
