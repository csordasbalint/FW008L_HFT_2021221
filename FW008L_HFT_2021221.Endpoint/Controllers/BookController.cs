using FW008L_HFT_2021221.Logic;
using FW008L_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FW008L_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        IBookLogic bl;

        public BookController(IBookLogic bl)
        {
            this.bl = bl;
        }


        // GET: /book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bl.ReadAll();
        }


        // GET /book/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return bl.Read(id);
        }


        // POST /book
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bl.Create(value);
        }


        // PUT /book
        [HttpPut]
        public void Put([FromBody] Book value)
        {
            bl.Update(value);
        }


        // DELETE book/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Delete(id);
        }
    }
}
