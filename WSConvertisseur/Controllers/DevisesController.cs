using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase {
        public List<Devise> LesDevises = new List<Devise> { new Devise(1,"Dollar", 1.08), new Devise(2, "Franc Suisse", 1.07), new Devise(3, "Yen", 120) };
        public DevisesController() {

        }
        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll() {
            return LesDevises;
        }

        // GET api/<DevisesController>/5

        [HttpGet("{idDevise}", Name = "GetDevise")]
        public ActionResult<Devise> GetById(int idDevise) {
            Devise? devise = LesDevises.FirstOrDefault((d) => d.IDDevise == idDevise);
            if (devise == null) {
                return NotFound();
            }
            return devise;
        }

        // POST api/<DevisesController>
        [HttpPost]
        public ActionResult<Devise> Post([FromBody] Devise devise) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            LesDevises.Add(devise);
            return CreatedAtAction("GetById", new { idDevise = devise.IDDevise }, devise);
        }

        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
