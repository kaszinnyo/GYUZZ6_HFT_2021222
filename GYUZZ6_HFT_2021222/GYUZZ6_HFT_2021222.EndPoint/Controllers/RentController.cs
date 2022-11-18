using GYUZZ6_HFT_2021222.EndPoint.Services;
using GYUZZ6_HFT_2021222.Logic.Interfaces;
using GYUZZ6_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GYUZZ6_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        IRentLogic logic;
        IHubContext<SignalRHub> hub;

        public RentController(IRentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<RentController>
        [HttpGet]
        public IEnumerable<Rent> Get()
        {
            return this.logic.ReadAll();
        }

        // GET api/<RentController>/5
        [HttpGet("{id}")]
        public Rent Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<RentController>
        [HttpPost]
        public void Create([FromBody] Rent value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("RentCreated", value);
        }

        // PUT api/<RentController>/5
        [HttpPut]
        public void Update([FromBody] Rent value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("RentUpdated", value);
        }

        // DELETE api/<RentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rentDeleted = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("RentDeleted", rentDeleted);
        }
    }
}
