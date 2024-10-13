
namespace REST_03_EF_ferramenta.Models
{
    public class ProdottoDTOInsert
    {
        public string? Nom { get; set; } = null!;

        public string? Des { get; set; }

        public decimal? Pre { get; set; }

        public int? Qua { get; set; }

        public int Rif { get; set; }
    }
}

