using ApiGuitarras.Entidades;
using ApiGuitarras.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ApiGuitarras.Controllers
{
    [ApiController]
    [Route("api/tiendas")]
    public class TiendasController: ControllerBase 
    { 
        private readonly ApplicationDbContext dbContext;
        
        public TiendasController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Tienda>>> GetAll()
        {
            return await dbContext.Tiendas.ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Tienda>> GetById(int id)
        {
            return await dbContext.Tiendas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult> Post(Tienda tienda)
        {
            var existeGuitarra = await dbContext.Guitarras.AnyAsync(x => x.Id == tienda.Id);

            //if (!existeGuitarra)
            //{
                //return BadRequest($"No existe la guitarra con el ID: {tienda.Id}");
            //}

            dbContext.Add(tienda);
            await dbContext.SaveChangesAsync();
            return Ok(tienda);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Tienda tienda, int id)
        {
            var exist = await dbContext.Tiendas.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("La Tienda especificada no existe. ");
            }

            if(tienda.Id != id)
            {
                return BadRequest("El id de la tienda no coincide con el establecido en la url");
            }

            dbContext.Update(tienda);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Tiendas.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("No se encontró la tienda especificada ");
            }

            dbContext.Remove(new Tienda { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        

    }
}
