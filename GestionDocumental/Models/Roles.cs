using GestionDocumental.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDocumental.Models
{
    public enum Roles
    {
        Administrador = 1,
        Funcionario = 2,
        Radicador = 3
    }
    //public class ListRol
    //{
    //    public string[] Rol { get; set; } 
    //}
    public class ListRol
    {
        public string[] Rol = new string[] {"Administrador","Funcionario","Radicador"};
    }
}