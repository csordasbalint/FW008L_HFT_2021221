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
    public class PersonController : ControllerBase
    {

        IPersonLogic pl;

        public PersonController(IPersonLogic pl)
        {
            this.pl = pl;
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
        }


        // PUT /person
        [HttpPut]
        public void Put([FromBody] Person value)
        {
            pl.Update(value);
        }


        // DELETE person/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
