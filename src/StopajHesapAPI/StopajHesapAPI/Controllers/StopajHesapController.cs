using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StopajHesapAPI.Models;
using StopajHesapAPI.Services;

namespace StopajHesapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class StopajHesapController : ControllerBase
    {
        readonly StopajHesapService _service;

        public StopajHesapController(StopajHesapService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult GetStopal(ParametersModels model) 
        {
            if(model == null)
            {
                return BadRequest("Eksik değer girmeyiniz");
            }

            double? sonuc = _service.Calculator(model);
            if(sonuc == null)
            {
                return BadRequest("Hatalı Tercih");
            }
            else
            {
                return Ok(sonuc);
            }
        }
    }
}
