using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_auth.models
{
    public class LoginRequest
    {
            public required string Nome { get; set; }
            public required string Senha { get; set; }
    }
}