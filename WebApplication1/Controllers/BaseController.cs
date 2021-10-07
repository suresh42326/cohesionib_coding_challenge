using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repos;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(string id)
        {
            var serviceRequest = await repository.Get(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            return serviceRequest;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, TEntity request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await repository.Update(request);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity request)
        {
            await repository.Add(request);
            return CreatedAtAction("Get", new { id = request.Id }, request);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(string id)
        {
            var request = await repository.Delete(id);
            if (request == null)
            {
                return NotFound();
            }
            return request;
        }

    }
}
