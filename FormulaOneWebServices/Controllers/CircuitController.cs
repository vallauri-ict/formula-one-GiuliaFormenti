using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;
using FormulaOneWebForm;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitController : ControllerBase
    {
        // GET: api/Circuit
        [HttpGet]
        public List<FormulaOneDLL.Models.Circuit> Get()
        {
            return Utils.GetTableCircuit();
        }

        // GET: api/Circuit/5
        [HttpGet("{id}")]
        public FormulaOneDLL.Models.Circuit Get(string id)
        {
            return Utils.GetTableCircuitByCode(Convert.ToInt32(id));
        }

        // POST: api/Circuit
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Circuit/5
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
