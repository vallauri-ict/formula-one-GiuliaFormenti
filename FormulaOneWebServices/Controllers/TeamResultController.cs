using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;
using System.Data;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamResultController : ControllerBase
    {
        // GET: api/TeamResult
        [HttpGet]
        public List<FormulaOneDLL.Models.TeamResult> Get()
        {
            return Utils.GetTableTeamResult();
        }

        // GET: api/TeamResult/5
        [HttpGet("{id}")]
        public FormulaOneDLL.Models.TeamResult Get(string id)
        {
            return Utils.GetTableTeamResultByCode(Convert.ToInt32(id));
        }

        // POST: api/TeamResult
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TeamResult/5
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
