using REST_03_EF_ferramenta.Models;

namespace REST_03_EF_ferramenta.Repositories
{
    public class ProdottoRepository : IRepository<Prodotto>
    {
        private readonly Context_Ferramenta _context;

        public ProdottoRepository(Context_Ferramenta context)
        {
            _context = context;
        }

        //CANCELLA PRODOTTO

        public bool Delete(int id)
        {
            bool risultato = false;

                try
                {
                Prodotto prodotto = _context.Prodottos.Single(p => p.ProdottoId == id);
                _context.Prodottos.Remove(prodotto);
                _context.SaveChanges();
                risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                risultato =false;
                }

            return risultato;
        }

        //PRENDI PRODOTTO PER ID

        public Prodotto? GetById(int id)
        {
            return _context.Prodottos.Single(p =>p.ProdottoId == id);
        }

        //CERCA PRODOTTO PER CODICE

        public Prodotto? CercaProdottoPerCod(string varCodice)
        {
            try
            {
                return _context.Prodottos.Single(p => p.ProdottoCOD == varCodice);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return null;
        }

        //PRENDI PRODOTTI DA REPARTO

        public List<Prodotto> GetByRepartoRif(int rif)
        {
            List<Prodotto> risultato = new List<Prodotto>();
            try
            {
                risultato = _context.Prodottos.ToList();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        //INSERISCI NUOVO PRODOTTO

        public bool Insert(Prodotto t)
        {
            bool result = false;

            {
                try
                {
                    _context.Prodottos.Add(t);
                    _context.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = false;
                }
            }

            return result;
        }

        public bool DeleteProdotto(int id)
        {
            bool risultato = false;

            try
            {
                Prodotto prodotto = _context.Prodottos.Single(p => p.ProdottoId == id);
                _context.Prodottos.Remove(prodotto);
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

        //AGGIORNA PRODOTTO

        public bool Update(Prodotto t)
        {
            bool result = false;
            try
            {
                Prodotto prodDaModificare = _context.Prodottos.Single(p => p.ProdottoCOD == t.ProdottoCOD);
                prodDaModificare.Nome = t.Nome;
                prodDaModificare.Descrizione = t.Descrizione;
                prodDaModificare.Prezzo = t.Prezzo;
                prodDaModificare.Quantita = t.Quantita;

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


        public List<Prodotto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
