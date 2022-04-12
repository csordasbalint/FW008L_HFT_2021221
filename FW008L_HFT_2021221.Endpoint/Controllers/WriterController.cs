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
    public class WriterController : ControllerBase
    {
        IWriterLogic wl;
        IHubContext<SignalRHub> hub;

        public WriterController(IWriterLogic wl, IHubContext<SignalRHub> hub)
        {
            this.wl = wl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("WriterCreated", value);
        }


        // PUT /writer
        [HttpPut]
        public void Put([FromBody] Writer value)
        {
            wl.Update(value);
            this.hub.Clients.All.SendAsync("WriterUpdated", value);
        }


        // DELETE writer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var writerToDelete = wl.Read(id);
            wl.Delete(id);
            this.hub.Clients.All.SendAsync("WriterDeleted", writerToDelete);
        }
    }
}
