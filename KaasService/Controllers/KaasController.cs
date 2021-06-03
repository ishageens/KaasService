using KaasService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaasService.Controllers
{
    [Route("kazen")]
    [ApiController]
    public class KaasController : ControllerBase
    {
        private readonly IKaasRepository repository;
        public KaasController(IKaasRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult FindAll() => base.Ok(repository.FindAll());

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var kaas = repository.FindById(id);
            if (kaas == null)
            {
                return base.NotFound();
            }
            return base.Ok(kaas);
        }

        [HttpGet("smaken")]
        public ActionResult FindBySmaak(string smaak) => base.Ok(repository.FindBySmaak(smaak));
    }
}
