using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstASPNETCoreWebApp.Filter;
using FirstASPNETCoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstASPNETCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomerExceptionFilter]
    public class DefaultController : ControllerBase
    {
        private ForumContext context;
        public DefaultController(ForumContext context)
        {
            this.context = context;
        }

        // GET: api/Default
        [HttpGet]
        public IEnumerable<string> Get()
        {
            this.context.Topics.Add(new Topic()
            {
                Content = "test",
                CreateTime = DateTime.Now,
                Title = "hello"
            });
            context.SaveChanges(true);
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            throw new Exception("Get操作发生了异常");
            return "value";
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] Topic model)
        {
            this.context.Topics.Add(new Topic()
            {
                Content = model.Content,
                CreateTime = DateTime.Now,
                Title = model.Title
            });
            context.SaveChanges();
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
