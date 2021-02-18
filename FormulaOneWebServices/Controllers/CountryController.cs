using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;
using System.Data;

namespace FormulaOneWebServices
{
    //api/Country
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // GET: api/Country
        [HttpGet]
        public List<FormulaOneDLL.Models.Country> Get()
        {
            return Utils.GetTableCountry();
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public FormulaOneDLL.Models.Country Get(string id)
        {
            return Utils.GetTableCountryByCode(id.ToUpper());
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/5
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