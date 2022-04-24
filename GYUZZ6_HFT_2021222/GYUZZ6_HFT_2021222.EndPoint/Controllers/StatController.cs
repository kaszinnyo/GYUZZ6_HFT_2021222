using GYUZZ6_HFT_2021222.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GYUZZ6_HFT_2021222.EndPoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IRentLogic logic;

        public StatController(IRentLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<KeyValuePair<string,double>> BasePriceAverageByBrand()
        {
            return this.logic.BasePriceAverageByBrand();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> RentCountByModel()
        {
            return this.logic.RentCountByModel();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> RentsSumByDate()
        {
            return this.logic.RentsSumByDate();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> BrandCarCount()
        {
            return this.logic.BrandCarCount();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AverageRatingByModel()
        {
            return this.logic.AverageRatingByModel();
        }
    }
}
