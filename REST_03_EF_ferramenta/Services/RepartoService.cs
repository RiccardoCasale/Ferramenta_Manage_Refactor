using Microsoft.IdentityModel.Tokens;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Repositories;

namespace REST_03_EF_ferramenta.Services
{
    public class RepartoService
    {
        private readonly RepartoRepository _repository;

        public RepartoService(RepartoRepository repository)
        {
            _repository = repository;
        }

        public RepartoService() { }

        //Elimina reparto
        public bool DeleteReparto(int id)
        {
            bool result = _repository.DeleteReparto(id);
            return result;
        }

        //CERCA REPARTO PER ID
        
        public RepartoDTO? CercaRepartoPerId(int id)
        {
            Reparto repartoEntity = null;
            RepartoDTO repartoDTO = null;
            repartoEntity = _repository.GetById(id);

            if (repartoEntity != null)
                repartoDTO = new RepartoDTO()
                {
                    Cod = repartoEntity.RepartoCOD,
                    Nom = repartoEntity.Nome,
                    Fil = repartoEntity.Fila
                };

            return repartoDTO;
        }

        //CERCA REPARTO PER CODICE

        public RepartoDTO? CercaRepartoPerCodice(string varCod)
        {
            Reparto repartoEntity = null;
            RepartoDTO repartoDTO = null;
            repartoEntity = _repository.GetByCodice(varCod);

            if(repartoEntity != null)
            repartoDTO = new RepartoDTO()
            {
                Cod = repartoEntity.RepartoCOD,
                Nom = repartoEntity.Nome,
                Fil = repartoEntity.Fila
            };

            return repartoDTO;
        }

        //PRENDI TUTTI I REPARTI

        public List<RepartoDTO> getAll()
        {
            List<Reparto> reparti = _repository.GetAll();
            List<RepartoDTO> repartiDTO = new List<RepartoDTO>();

            foreach (var currentReparto in reparti)
            {
                RepartoDTO currentRepartoDTO = new RepartoDTO()
                {
                    Cod = currentReparto.RepartoCOD,
                    Nom = currentReparto.Nome,
                    Fil = currentReparto.Fila
                };
                repartiDTO.Add(currentRepartoDTO);
            }
            return repartiDTO;
        }

        //INSERISCI REPARTO

        public bool InserisciReparto(RepartoDTO repaDto) 
        {

            Reparto reparto = new Reparto()
            {
                Fila = repaDto.Fil,
                RepartoCOD = repaDto.Cod is not null ? repaDto.Cod : Guid.NewGuid().ToString(),
                Nome = repaDto.Nom,
            };








            return _repository.Insert(reparto);

        }

        public bool aggiornaReparto(RepartoDTO repModifiche)
        {
            Reparto repDaModificare = _repository.GetByCodice(repModifiche.Cod);

            if (!repModifiche.Nom.IsNullOrEmpty())
            {
                repDaModificare.Nome = repModifiche.Nom;
            }
            if (!repModifiche.Fil.IsNullOrEmpty())
            {
                repDaModificare.Fila = repModifiche.Fil;
            }

            return _repository.Update(repDaModificare);
        }
    }
}
