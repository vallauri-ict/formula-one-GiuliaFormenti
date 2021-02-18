﻿using System;
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
    public class ResultController : ControllerBase
    {
        // GET: api/Result
        [HttpGet]
        public List<FormulaOneDLL.Models.Result> Get()
        {
            return Utils.GetTableResult();
        }

        // GET: api/Result/5
        [HttpGet("{id}")]
        public FormulaOneDLL.Models.Result Get(string id)
        {
            return Utils.GetTableResultByCode(Convert.ToInt32(id));
        }

        // POST: api/Result
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Result/5
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
