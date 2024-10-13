using REST_03_EF_ferramenta.Models;

namespace REST_03_EF_ferramenta.Repositories
{
    public class RepartoRepository : IRepository<Reparto>
    {
        private readonly Context_Ferramenta _context;

        public RepartoRepository(Context_Ferramenta context)
        {
            _context = context;
        }

        public RepartoRepository() { }

        //CANCELLA REPARTO

        public bool DeleteReparto(int id)
        {
            bool risultato = false;

            try
            {
                Reparto reparto = _context.Repartos.Single(r => r.RepartoId == id);
                _context.Repartos.Remove(reparto);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                risultato = false;
            }
            return risultato;
        }

        //PRENDI TUTTI I REPARTI

        public List<Reparto> GetAll()
        {
            List<Reparto> reparti = new List<Reparto>();
            reparti = _context.Repartos.ToList();

            return reparti;
        }

        //PRENDI REPARTO PER ID

        public Reparto? GetById(int id)
        {
            Reparto result = null;
            try
            {
                result = _context.Repartos.First(r => r.RepartoId == id);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        //PRENDI REPARTO PER CODICE

        public Reparto? GetByCodice(string varCodice)
        {
            Reparto result = null;
            try
            {
                result = _context.Repartos.First(r => r.RepartoCOD == varCodice);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        //INSERIMENTO DI UN REPARTO

        public bool Insert(Reparto t)
        {
            bool result = false;

            try
            {
                _context.Repartos.Add(t);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }

            return result;
        }

        public bool Update(Reparto t)
        {
            bool result = false;
            try
            {
                Reparto repDaModificare = _context.Repartos.Single(r => r.RepartoCOD == t.RepartoCOD);
                repDaModificare.Nome = t.Nome;
                repDaModificare.Fila = t.Fila;
                _context.SaveChanges();
                result = true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

}

