using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api_auth.Controllers
{
    public class BaseController : ControllerBase
    {
        
        [NonAction]
    protected int GetUsuarioIdToken()
    {
        var userId = User.FindFirst(ClaimTypes.Sid)?.Value;
        return userId == "" ? 0 : int.Parse(userId!);
    }

    [NonAction]
    protected int GetUsuarioNivelToken()
    {
        var nivel = User.FindFirst(ClaimTypes.Role)?.Value;
        return nivel == "" ? 0 : Convert.ToInt32(nivel);
    }

    protected JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };
    }
    }
}