﻿
namespace REST_03_EF_ferramenta.Models
{
    public class ProdottoDTOUpdate
    {
        public string? Cod { get; set; } = null!;

        public string? Nom { get; set; } = null!;

        public string? Des { get; set; }

        public decimal? Pre { get; set; }

        public int? Qua { get; set; }
    }
}
