using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrurura.Interfaces
{
    public interface IAdministrador
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}