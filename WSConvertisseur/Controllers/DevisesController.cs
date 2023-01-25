using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase {
        /// <summary>
        /// Currencies' List.
        /// </summary>
        public List<Devise> LesDevises = new List<Devise> { new Devise(1,"Dollar", 1.08), new Devise(2, "Franc Suisse", 1.07), new Devise(3, "Yen", 120) };
        
        /// <summary>
        /// Constructor of Devise Controller.
        /// </summary>
        public DevisesController() {

        }

        /// <summary>
        /// Get the list of all currencies.
        /// </summary>
        // GET: api/<DevisesController>
        [HttpGet]
        [ProducesResponseType(200)]
        public IEnumerable<Devise> GetAll() {
            return LesDevises;
        }

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="idDevise">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // GET api/<DevisesController>/5
        [HttpGet("{idDevise}", Name = "GetDevise")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Devise> GetById(int idDevise) {
            Devise? devise = LesDevises.FirstOrDefault((d) => d.IDDevise == idDevise);
            if (devise == null) {
                return NotFound();
            }
            return devise;
        }

        /// <summary>
        /// Add a currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When the currency id is found</response>
        /// <response code="215">When the currency form is not correct</response>
        /// <response code="404">When the currency id is not found</response>
        // POST api/<DevisesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Devise> Post([FromBody] Devise devise) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            LesDevises.Add(devise);
            return CreatedAtAction("GetById", new { idDevise = devise.IDDevise }, devise);
        }

        /// <summary>
        /// Modify a currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="idDevise">The id of the currency</param>
        /// <param name="devise">The Devise as an object</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="215">When the currency form is not correct or the id is not the same in the request</response>
        /// <response code="404">When the currency id is not found</response>
        // PUT api/<DevisesController>/5
        [HttpPut("{idDevise}")]
        public ActionResult Put(int idDevise, [FromBody] Devise devise) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (idDevise != devise.IDDevise) {
                return BadRequest();
            }
            int index = LesDevises.FindIndex((d) => d.IDDevise == idDevise);
            if (index < 0) {
                return NotFound();
            }
            LesDevises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Delete a currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="idDevise">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="215">When the currency form is not correct</response>
        /// <response code="404">When the currency id is not found</response>
        // DELETE api/<DevisesController>/5
        [HttpDelete("{idDevise}")]
        public ActionResult<Devise> Delete(int idDevise) {
            Devise? devise = LesDevises.FirstOrDefault((d) => d.IDDevise == idDevise);
            if (devise == null) {
                return NotFound();
            }
            LesDevises.Remove(devise);
            return devise;
        }
    }
}
