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
    public class PersonController : ControllerBase
    {

        IPersonLogic pl;
        IHubContext<SignalRHub> hub;

        public PersonController(IPersonLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
        }


        // GET: /person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return pl.ReadAll();
        }


        // GET /person/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return pl.Read(id);
        }


        // POST /person
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            pl.Create(value);
            this.hub.Clients.All.SendAsync("PersonCreated", value);
        }


        // PUT /person
        [HttpPut]
        public void Put([FromBody] Person value)
        {
            pl.Update(value);
            this.hub.Clients.All.SendAsync("PersonUpdated", value);
        }


        // DELETE person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var personToDelete = pl.Read(id);
            pl.Delete(id);
            this.hub.Clients.All.SendAsync("PersonDeleted", personToDelete);
        }
    }
}
