using System.ComponentModel.DataAnnotations.Schema;

namespace REST_03_EF_ferramenta.Models
{
    [Table("Reparto")]
    public class Reparto
    {
        public int RepartoId { get; set; }
        public string? RepartoCOD { get; set; }
        public string Nome { get; set; } = null!;
        public string Fila { get; set; } = null!;
        public ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
    }
}
