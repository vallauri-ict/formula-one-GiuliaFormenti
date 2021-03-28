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
        [HttpGet("id/{id}")]
        public FormulaOneDLL.Models.Circuit Get(int id)
        {
            return Utils.GetTableCircuitByCode(Convert.ToInt32(id));
        }

        [HttpGet("name/{name}")]
        [HttpGet("country/{country}")]
        public List<FormulaOneDLL.Models.Circuit> Get(string name, string country)
        {
            string param;
            string campi;
            if (name != null)
            {
                //tab = "Country";
                campi = "circuitName";
                param = name;
            }
            else
            {
                campi = "circuitCountry";
                param = country.ToUpper();
            }
            return Utils.GetTableCircuitByStrParam(campi, param);
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
