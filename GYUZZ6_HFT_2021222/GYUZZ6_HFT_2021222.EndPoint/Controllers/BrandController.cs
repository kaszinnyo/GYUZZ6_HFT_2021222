using GYUZZ6_HFT_2021222.Logic.Interfaces;
using GYUZZ6_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GYUZZ6_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;

        public BrandController(IBrandLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return this.logic.ReadAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logic.Create(value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
