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
    public class RaceController : ControllerBase
    {
        // GET: api/Race
        [HttpGet]
        public List<FormulaOneDLL.Models.Race> Get()
        {
            return Utils.GetTableRace();
        }

        // GET: api/Race/5
        [HttpGet("id/{id}")]
        public FormulaOneDLL.Models.Race Get(int id)
        {
            return Utils.GetTableRaceByCode(Convert.ToInt32(id));
        }

        [HttpGet("name/{id}")]
        public List<FormulaOneDLL.Models.Race> Get(string name)
        {
            return Utils.GetTableRaceByStrParam("raceName", name.ToUpper());
        }

        // POST: api/Race
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Race/5
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
