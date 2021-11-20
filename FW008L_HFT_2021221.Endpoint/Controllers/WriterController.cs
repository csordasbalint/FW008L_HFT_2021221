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
    public class WriterController : ControllerBase
    {
        IWriterLogic wl;

        public WriterController(IWriterLogic wl)
        {
            this.wl = wl;
        }


        // GET: /writer
        [HttpGet]
        public IEnumerable<Writer> Get()
        {
            return wl.ReadAll();
        }


        // GET /writer/5
        [HttpGet("{id}")]
        public Writer Get(int id)
        {
            return wl.Read(id);
        }


        // POST /writer
        [HttpPost]
        public void Post([FromBody] Writer value)
        {
            wl.Create(value);
        }


        // PUT /writer
        [HttpPut]
        public void Put([FromBody] Writer value)
        {
            wl.Update(value);
        }


        // DELETE writer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            wl.Delete(id);
        }
    }
}
