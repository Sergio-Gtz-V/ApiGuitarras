using ApiGuitarras.Entidades;
using ApiGuitarras.Migrations;
using ApiGuitarras.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGuitarras.Controllers
{
    [ApiController]
    [Route("guitarras")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class GuitarrasController: ControllerBase

    {
        private readonly ApplicationDbContext dbContext;
        private readonly IServiceCollection service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ILogger<GuitarrasController> logger;

        private readonly IConfiguration configuration;

        public GuitarrasController(ApplicationDbContext dbContext,
            IService service,
            ServiceTransient serviceTransient,
            ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton,
            ILogger<GuitarrasController> logger,
            IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.service = (IServiceCollection)service;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.logger = logger;
            this.configuration = configuration;
        }
        

        [HttpGet("listadoGuitarras")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Guitarra>>> Get()
        {
            return await dbContext.Guitarras.Include(x => x.Tiendas).ToListAsync();

        }

        [HttpGet("primerGuitarra")]
        public async Task<ActionResult<Guitarra>> primerGuitarra()
        {
            return await dbContext.Guitarras.FirstOrDefaultAsync();
        }

        

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Guitarra>> Get(int id)
        {
            var guitarra = await dbContext.Guitarras.FirstOrDefaultAsync(x => x.Id == id);

            if(guitarra == null)
            {
                return NotFound();
            }

            return guitarra;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(Guitarra guitarra)
        {
            var existeGuitarraMismoNombre = await dbContext.Tiendas.AnyAsync(x => x.Nombre == guitarra.Name);

            if (existeGuitarraMismoNombre)
            {
                return BadRequest("Ya existe una guitarra con ese Nombre");
            }
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
