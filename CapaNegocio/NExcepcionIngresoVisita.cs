using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NExcepcionIngresoVisita
    {
        //CREAR EXCEPCION
        public async Task<(DExcepcionIngresoVisita, string error)> CrearExcepcion(string excepcionIngreso)
        {
            IExcepcionIngresoVisitaDao excepcionIngresoVisitaDao = new ExcepcionIngresoVisitaDaoImpl();

            (DExcepcionIngresoVisita excepcionIngresoResponse, string errorResponse) = await excepcionIngresoVisitaDao.CrearExcepcionIngresoVisita(excepcionIngreso);

            return (excepcionIngresoResponse, errorResponse);
        }
        //FIN CREAR EXCEPCION..................................
                

        //LEVANTAR MANUAL PROHIBICION
        public async Task<(bool, string error)> LevantarManualProhibicion(int id, string dataLevantar)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.LevantarProhibicionVisita(id, dataLevantar);

            return (prohibicionResponse, error);
        }
        //FIN LEVANTAR MANUAL PROHIBICION..................................

        //PROHIBIR UNA PROHIBICION
        public async Task<(bool, string error)> ProhibirManualProhibicion(int id, string dataProhibir)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.ProhibirProhibicionVisita(id, dataProhibir);

            return (prohibicionResponse, error);
        }
        //FIN PROHIBIR UNA PROHIBICION..................................

        //ANULAR UNA PROHIBICION
        public async Task<(bool, string error)> AnularProhibicion(int id, string dataAnular)
        {
            IProhibicionVisitaDao prohibicionVisitaDao = new ProhibicinVisitaDaoImpl();

            (bool prohibicionResponse, string error) = await prohibicionVisitaDao.AnularProhibicionVisita(id, dataAnular);

            return (prohibicionResponse, error);
        }
        //FIN ANULAR UNA PROHIBICION..................................


        //LISTA EXCEPCIONES INGRESO POR CIUDADANO
        public async Task<(List<DExcepcionIngresoVisita>, string error)> RetornarListaExcepcionesIngreso(int idCiudadano)
        {
            IExcepcionIngresoVisitaDao excepcionIngresoVisitaDao = new ExcepcionIngresoVisitaDaoImpl();

            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await excepcionIngresoVisitaDao.RetornarExcepcionesIngresoXCiudadano(idCiudadano);


            return (listaExcepcionesIngreso, errorResponse);
        }
        //FIN LISTA EXCEPCIONES INGRESO POR CIUDADANO..................................
    }
}
