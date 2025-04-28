using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SparkMarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        // GET: api/<SiparisController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SiparisController>/5
        [HttpGet("{id}")]
       // [Route("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SiparisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {



        }

        // PUT api/<SiparisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {


        }

        // DELETE api/<SiparisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {



        }
    }
}
