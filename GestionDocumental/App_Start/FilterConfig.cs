using GestionDocumental.Filters;
using GestionDocumental.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GestionDocumental.Controllers;

namespace GestionDocumental
{
    public class FilterConfig
    {
        public static object Model { get; private set; }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Session());            
        }
    }
}
