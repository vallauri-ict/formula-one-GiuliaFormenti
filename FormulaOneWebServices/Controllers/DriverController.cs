using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        // GET: api/Driver
        [HttpGet]
        public List<FormulaOneDLL.Models.Driver> Get()
        {
            return Utils.GetTableDriver();
        }

        // GET: api/Driver/5
        [HttpGet("{id}")]
        public FormulaOneDLL.Models.Driver Get(string id)
        {
            return Utils.GetTableDriverByCode(Convert.ToInt32(id));
        }

        // POST: api/Driver
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Driver/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
