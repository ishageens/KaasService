using KaasService.Models;
using KaasService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
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

        [SwaggerOperation("Alle kazen")]
        [HttpGet]
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

        [SwaggerOperation("Kaas waarvan je de id kent")]
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var kaas = await repository.FindByIdAsync(id);
            if (kaas == null)
            {
                return base.NotFound();
            }
            return base.Ok(kaas);
        }

        [SwaggerOperation("Kazen waarvan je de smaak kent")]
        [HttpGet("smaken")]
        public async Task<ActionResult> FindBySmaak(string smaak) => base.Ok(await repository.FindBySmaakAsync(smaak));

        [SwaggerOperation("Brouwer wijzigen")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Kaas kaas)
        {
            if (ModelState.IsValid && kaas.Id == id)
            {
                try
                {
                    await repository.UpdateAsync(kaas);
                    return base.Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return base.NotFound();
                }
                catch
                {
                    return base.Problem();
                }
            }
            return base.BadRequest(this.ModelState);
        }
    }
}
