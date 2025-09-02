﻿using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NRegistroDiario
    {        

        //RETORNAR LISTA POR CIUDADANO
        public async Task<(List<DRegistroDiario>, string error)> RetornarListaXCiudadano(int idCiudadano)
        {
            IRegistroDiarioDao registroDiarioDao = new RegistroDiarioDaoImpl();

            (List<DRegistroDiario> listaRegsitroDiario, string errorResponse) = await registroDiarioDao.ListaXCiudadano(idCiudadano);


            return (listaRegsitroDiario, errorResponse);
        }
        //FIN RETORNAR LISTA POR CIUDADANO..................................
    }
}
