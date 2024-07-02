using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_auth.data;
using api_auth.models;
using Microsoft.AspNetCore.Mvc;

namespace api_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SqliteContext _contexto;

        public AuthController(SqliteContext contexto)
        {
            _contexto = contexto;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var users = _contexto.Usuarios.ToList();

            var user = _contexto.Usuarios.FirstOrDefault(x => x.Nome == request.Nome && x.Senha == request.Senha);
            if (user != null)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
        
    }
}