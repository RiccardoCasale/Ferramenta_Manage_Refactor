using Microsoft.AspNetCore.Mvc;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Services;

namespace REST_03_EF_ferramenta.Controllers
{
    [ApiController]
    [Route("api/reparto")]
    public class RepartoController : Controller
    {
        private readonly RepartoService _service;

        public RepartoController(RepartoService service)
        {
            _service = service;
        }

        //INSERISCI NUOVO REPARTO

        [HttpPost]
        public IActionResult InserisciReparto(RepartoDTO objDto)
        {
            if(string.IsNullOrWhiteSpace(objDto.Nom) || string.IsNullOrWhiteSpace(objDto.Fil))
                return BadRequest();

            bool risultato = _service.InserisciReparto(objDto);

            if (risultato)
                return Ok();

            return BadRequest();
        }

        //CERCA REPARTO PER CODICE

        [HttpGet("getByCode/{varCodice}")]
        public ActionResult<RepartoDTO?> CercaRepartoPerCod(string varCodice)
        {
            RepartoDTO result = _service.CercaRepartoPerCodice(varCodice);
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        //CERCA REPARTO PER ID

        [HttpGet("getById/{id}")]

        public ActionResult<RepartoDTO?> CercaRepartoPerId(int id)
        {
            
            RepartoDTO result = _service.CercaRepartoPerId(id);
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        //CANCELLA REPARTO

        [HttpDelete("cancellaReparto")]
        public ActionResult<bool> DeleteReparto(int id)
        {
            return _service.DeleteReparto(id);
        }

        //PRENDI TUTTI I REPARTI

        [HttpGet("reparto")]
        public ActionResult<List<RepartoDTO>> getAll()
        {
            return _service.getAll();
        }




        //MODIFICA NOME O FILA DI UN REPARTO ESISTENTE

        [HttpPut("aggiorna")]
        public ActionResult<bool> aggiornaReparto(RepartoDTO repModifiche)
        {
            if (string.IsNullOrWhiteSpace(repModifiche.Nom) && string.IsNullOrWhiteSpace(repModifiche.Fil) && string.IsNullOrWhiteSpace(repModifiche.Cod))
                return BadRequest();

            bool risultato = _service.aggiornaReparto(repModifiche);

            if (risultato)
                return Ok();

            return BadRequest();
        }

    }
}
