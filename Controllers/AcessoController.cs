﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public ActionResult Get() 
        {
            return Ok("Acesso Permitido!");
        }
    }
}
