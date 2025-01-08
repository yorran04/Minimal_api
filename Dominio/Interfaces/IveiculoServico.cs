using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Dominio.Interfaces
{
    public interface IveiculoServico
    {
        List<Veiculo> Todos (int page = 1, string? nome = null, string? marca = null);
        Veiculo? BucarPorId(int id);
        void Incluir(Veiculo veiculo);
        void Atualizar (Veiculo veiculo);
        void Apagar (Veiculo veiculo);
    }
}