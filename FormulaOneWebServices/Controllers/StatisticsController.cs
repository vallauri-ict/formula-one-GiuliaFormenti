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
    public class StatisticsController : ControllerBase
    {
        // GET: api/TeamResult
        [HttpGet]
        public List<FormulaOneDLL.Models.Statistics> Get()
        {
            List<int> driverCodes = Utils.GetDriverCodes();
            return Utils.GetTableStatistics(driverCodes);
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
