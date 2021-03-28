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
    public class DettaglioDriverController : ControllerBase
    {
        // GET: api/Driver
        [HttpGet]
        public List<FormulaOneDLL.Models.DettaglioDriver> Get()
        {
            return Utils.GetDettaglioDriver();
        }
    }
}
