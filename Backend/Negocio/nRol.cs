using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using EasyPark.Backend.Datos;
using EasyPark.Backend.Entidad;

namespace EasyPark.Backend.Negocio
{
    public class nRol
    {
        //object
        dRol voRol = new dRol();

        public List<eRol> obtenerRoles()
        {
            return voRol.obtenerRoles();
        }

        //ejemplo de la capa de negocios

        /*
         //insert
        public void n_insertClient(eClient Client)
        { 
            voClient.insertClient(Client);
        }
         */


    }
}