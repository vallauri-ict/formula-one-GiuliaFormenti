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
    public class TeamController : ControllerBase
    {
        // GET: api/Team
        [HttpGet]
        public List<FormulaOneDLL.Models.Team> Get()
        {
            return Utils.GetTableTeam();
        }

        // GET: api/Team/5
        [HttpGet("id/{id}")]
        [HttpGet("name/{name}")]
        public List<FormulaOneDLL.Models.Team> Get(string id, string name)
        {
            string param;
            string campi;
            if (id != null)
            {
                //tab = "Team";
                campi = "teamCode";
                param = id.ToUpper();
            }
            else
            {
                campi = "teamPowerUnit";
                param = name;
            }
            return Utils.GetTableTeamByStrParam(campi, param);
        }

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Team/5
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
