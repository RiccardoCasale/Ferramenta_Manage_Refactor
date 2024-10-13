using System.ComponentModel.DataAnnotations.Schema;

namespace REST_03_EF_ferramenta.Models
{
    [Table("Prodotto")]
    public class Prodotto
    {
        public int ProdottoId { get; set; }
        public string ProdottoCOD { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
        [ForeignKey("Reparto")]
        public int RepartoRif { get; set; }
        public virtual Reparto Reparto { get; set; } = null!;
    }
}
