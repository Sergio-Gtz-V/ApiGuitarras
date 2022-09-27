using ApiGuitarras.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGuitarras.Controllers
{
    [ApiController]
    [Route("guitarras")]
    public class GuitarrasController: ControllerBase

    {
        private readonly ApplicationDbContext dbContext;

        public GuitarrasController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Guitarra>>> Get()
        {
            return await dbContext.Guitarras.Include(x => x.Tiendas).ToListAsync();

        }

        [HttpPost]

        public async Task<ActionResult> Post(Guitarra guitarra)
        {
            dbContext.Add(guitarra);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Guitarra guitarra, int id)
        {
            if(guitarra.Id != id)
            {
                return BadRequest("El id de la guitarra no coincide con el establecido en la url.");

            }

            dbContext.Update(guitarra);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Guitarras.AnyAsync(x => x.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            dbContext.Remove(new Guitarra()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
