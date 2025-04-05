using Dexian.Application.Dtos;
using Dexian.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dexian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
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
        public async Task<IActionResult> Save([FromBody] UsuarioDto usuario)
        {
            try
            {

                var result = await _service.Save(usuario);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UsuarioDto usuario)
        {

            try
            {
                
                var result = await _service.Login(usuario);
                return Ok( new { token = result });

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
