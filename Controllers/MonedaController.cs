using Microsoft.AspNetCore.Mvc;
using WebAPIPrueba.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private static readonly List<Moneda> monedas = new List<Moneda>();

        // GET: api/Moneda
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(monedas);
        }

        // GET api/Moneda/Dolar
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            foreach(Moneda x in monedas)
            {
                if(x.Nombre.Equals(nombre))
                {
                    return Ok(x);
                }
            }
            return NotFound("Moneda no registrada!");
        }

        // POST api/Moneda
        [HttpPost]
        public IActionResult Post([FromBody] Moneda value)
        {
            if (value == null || string.IsNullOrEmpty(value.Nombre))
                return BadRequest("Error: datos incorrectos!");

            monedas.Add(value);
            return Ok(value);
       
        }

        // PUT api/<MonedaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MonedaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
