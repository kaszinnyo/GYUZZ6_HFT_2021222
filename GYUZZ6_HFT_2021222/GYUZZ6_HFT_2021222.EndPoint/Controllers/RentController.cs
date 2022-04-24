using GYUZZ6_HFT_2021222.Logic.Interfaces;
using GYUZZ6_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GYUZZ6_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        IRentLogic logic;

        public RentController(IRentLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<RentController>/5
        [HttpPut]
        public void Update([FromBody] Rent value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<RentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
