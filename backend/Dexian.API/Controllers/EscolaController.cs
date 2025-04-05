using Dexian.Application.Dtos;
using Dexian.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dexian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {

        private readonly IEscolaService _service;

        public EscolaController(IEscolaService service)
        {

            _service = service;

        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int id)
        {

            try
            {

                var result = await _service.Get(id);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("list")]
        [Authorize]
        public async Task<IActionResult> List()
        {

            try
            {

                var result = await _service.List();
                return Ok(result);

            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Save([FromBody] EscolaDto escola)
        {

            try
            {

                var result = await _service.Save(escola);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {

            try
            {

                var result = await _service.Delete(id);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

    }
}
