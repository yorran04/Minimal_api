using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.DTOs
{
    public record VeiculoDTO
    {
        public string Name { get; set; }

        public string Marca { get; set; }
    
        public int Ano { get; set; }
    }
}