using FW008L_HFT_2021221.Endpoint.Services;
using FW008L_HFT_2021221.Logic;
using FW008L_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public BookController(IBookLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("BookCreated",value);
        }


        // PUT /book
        [HttpPut]
        public void Put([FromBody] Book value)
        {
            bl.Update(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);
        }


        // DELETE book/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookToDelete = bl.Read(id);
            bl.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", bookToDelete);
        }
    }
}
