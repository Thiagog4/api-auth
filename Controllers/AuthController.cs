using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_auth.data;
using api_auth.models;
using api_auth.services;
using Microsoft.AspNetCore.Mvc;

namespace api_auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SqliteContext _contexto;

        private readonly IConfiguration _configuration;

        public AuthController(SqliteContext contexto, IConfiguration configuration)
        {
            _contexto = contexto;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var users = _contexto.Usuarios.ToList();

            var user = _contexto.Usuarios.FirstOrDefault(x => x.Nome == request.Nome && x.Senha == request.Senha);
            if (user != null)
            {
                var token = TokenService.GenerateToken(user, _configuration);
                
                return Ok(new { token });
            }
            else
            {
                return Unauthorized();
            }
        }
        
    }
}