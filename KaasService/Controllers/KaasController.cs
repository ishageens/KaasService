using KaasService.Models;
using KaasService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

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

        [HttpGet("smaken")]
        public async Task<ActionResult> FindBySmaak(string smaak) => base.Ok(await repository.FindBySmaakAsync(smaak));

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
