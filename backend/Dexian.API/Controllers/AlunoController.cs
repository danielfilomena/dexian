using Dexian.Application.Dtos;
using Dexian.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dexian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {


        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
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
        public async Task<IActionResult> Save([FromBody] AlunoDto aluno)
        {

            try
            {

                var result = await _service.Save(aluno);
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
