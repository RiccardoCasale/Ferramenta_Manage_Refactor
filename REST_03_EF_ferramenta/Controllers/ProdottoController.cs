using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Services;

namespace REST_03_EF_ferramenta.Controllers
{
    [ApiController]
    [Route("api/prodotto")]
    public class ProdottoController : Controller
    {
        private readonly ProdottoService _service;

        public ProdottoController(ProdottoService service)
        {
            _service = service;
        }

        //CERCA PRODOTTO BY CODICE

        [HttpGet("{varCodice}")]
        public ActionResult<ProdottoDTO?> CercaPerCodice(string varCodice)
        {
            ProdottoDTO prodotto = _service.CercaProdottoPerCod(varCodice);
            if (prodotto != null)
                return Ok(prodotto);
            else
                return NotFound();
        }

        //PRENDI PRODOTTI DA REPARTO

        [HttpGet("getByReparto/{Id}")]
        public ActionResult<List<ProdottoDTO>> CercaProdottiPerCodReparto(int Id)
        {
            List<ProdottoDTO?> prodotti;

            prodotti = _service.CercaProdottiPerRepartoId(Id);

            if (!prodotti.IsNullOrEmpty())
            {
                return Ok(prodotti);
            }
            else
            {
                return BadRequest();
            }
        }

        //ELIMINA PRODOTTO

        [HttpDelete("cancellaProdotto")]
        public ActionResult<bool> DeleteProdotto(int id)
        {
            return _service.DeleteProdotto(id);
        }

        //INSERISCI NUOVO PRODOTTO

        [HttpPost]
        public ActionResult<bool> InserisciProdotto(ProdottoDTOInsert objProd)
        {
            if (string.IsNullOrWhiteSpace(objProd.Nom) || objProd.Rif < 1)
                return BadRequest();

            bool risultato = _service.InserisciProdotto(objProd);

            if (risultato)
                return Ok();

            return BadRequest();
        }

        //AGGIORNA UN PRODOTTO ESISTENTE

        [HttpPut("aggiorna")]
        public ActionResult<bool> aggiornaProdotto(ProdottoDTOUpdate prodModifiche)
        {
            if (string.IsNullOrWhiteSpace(prodModifiche.Nom) && string.IsNullOrWhiteSpace(prodModifiche.Des) && prodModifiche.Pre < 1)
                return BadRequest();

            bool risultato = _service.aggiornaProdotto(prodModifiche);

            if (risultato)
                return Ok();

            return BadRequest();
        }
    }
}