using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrurura.Db;

namespace minimal_api.Dominio.Servicos
{
    public class VeiculoServico : IveiculoServico
    {
        private readonly DbContexto _contexto;
        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }
        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo? BucarPorId(int id)
        {
           return _contexto.Veiculos.Where(x => x.Id == id).FirstOrDefault();
            
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int page = 1, string nome = null, string marca = null)
        {
           var query= _contexto.Veiculos.AsQueryable();

           if(!string.IsNullOrEmpty(nome))
           {
                query = query.Where(v => EF.Functions.Like(v.Name.ToLower(), $"%{nome}%"));
           }
           
           int itensPorPaginas = 10;

           query = query.Skip((page - 1) * itensPorPaginas).Take(itensPorPaginas);

           return query.ToList();
        }

    }
}