using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Repositories;

namespace REST_03_EF_ferramenta.Services
{
    public class ProdottoService
    {
        private readonly ProdottoRepository _repository;
        private readonly RepartoService _repartoService;

        public ProdottoService(ProdottoRepository repository , RepartoService repartoService) 
        {
            _repository = repository;
            _repartoService = repartoService;
        }

        public ProdottoDTO? CercaProdottoPerCod(string varCodice)
        {
            ProdottoDTO? risultato = null;

            Prodotto? prod = _repository.CercaProdottoPerCod(varCodice);
            if(prod is not null)
            {
                risultato = new ProdottoDTO()
                {
                    Cod = prod.ProdottoCOD,
                    Des = prod.Descrizione,
                    Nom = prod.Nome,
                    Pre = prod.Prezzo,
                    Qua = prod.Quantita
                };
            }

            return risultato;
        }

        public List<ProdottoDTO> CercaProdottiPerRepartoId(int id)
        {
            List<Prodotto> risultato = new List<Prodotto>();
            List<ProdottoDTO> risultatoMappato = new List<ProdottoDTO>();

            risultato = _repository.GetByRepartoRif(id);

            foreach(Prodotto currentProdotto in risultato)
            {
                if(currentProdotto.RepartoRif == id)
                {
                    ProdottoDTO mappedProdotto = new ProdottoDTO();
                    mappedProdotto.Cod = currentProdotto.ProdottoCOD;
                    mappedProdotto.Nom = currentProdotto.Nome;
                    mappedProdotto.Des = currentProdotto.Descrizione;
                    mappedProdotto.Pre = currentProdotto.Prezzo;
                    mappedProdotto.Qua = currentProdotto.Quantita;
                    risultatoMappato.Add(mappedProdotto);
                }
            }

            return risultatoMappato;
        }

        //CANCELLA PRODOTTO

        public bool DeleteProdotto(int id)
        {
            bool result = _repository.DeleteProdotto(id);
            return result;
        }

        //INSERISCI NUOVO PRODOTTO
        public bool InserisciProdotto(ProdottoDTOInsert objProd)
        {
            Prodotto prodotto = new Prodotto()
            {
                ProdottoCOD = Guid.NewGuid().ToString(),
                Nome = objProd.Nom,
                Descrizione = objProd.Des,
                Prezzo = objProd.Pre ?? 0,
                Quantita = objProd.Qua ?? 0,
                RepartoRif = objProd.Rif
            };

            return _repository.Insert(prodotto);
        }

        //AGGIORNA UN PRODOTTO ESISTENTE
        public bool aggiornaProdotto(ProdottoDTOUpdate prodModifiche)
        {
            Prodotto prodDaModificare = _repository.CercaProdottoPerCod(prodModifiche.Cod);

            if (!prodModifiche.Nom.IsNullOrEmpty())
            {
                prodDaModificare.Nome = prodModifiche.Nom;
            }
            if (!prodModifiche.Des.IsNullOrEmpty())
            {
                prodDaModificare.Descrizione = prodModifiche.Des;
            }
            if (prodModifiche.Pre > 0)
            {
                prodDaModificare.Prezzo = prodModifiche.Pre ?? 0;
            }
            if (prodModifiche.Qua > 0)
            {
                prodDaModificare.Quantita = prodModifiche.Qua ?? 0;
            }
            
            return _repository.Update(prodDaModificare);
        }


    }
}
