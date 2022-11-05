using GestionDocumental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionDocumental.Login
{
    public class Login
    {
        public ListViewLogin ValidUser(string usuario, string clave)
        {
            ListViewLogin Login = new ListViewLogin();//Instanciamos
            proyecto_radicadoEntities1 __ConnectBD = new proyecto_radicadoEntities1();//Instanciamos

            //Login usuario = new Login().ValidUser();
            string query = "select usuario, clave, Id_Rol from persona where usuario = @usuario and clave = @clave";
            //SqlCommand cmd = new SqlCommand(query, __ConnectBD);


            var user = __ConnectBD.persona.FirstOrDefault(e => e.usuario == usuario && e.clave == clave);

            Login = new ListViewLogin()
            {
                usuario = user.usuario,
                clave = user.clave,
                Id_Rol = user.Id_Rol
            };
            //using (SqlDataReader dr = cmd.)
            return Login;
        }

    }
}