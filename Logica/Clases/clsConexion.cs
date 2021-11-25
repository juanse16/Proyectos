using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Web.Clases
{
    public class clsConexion
    {
        public string stGetConexion()
        {
            return ConfigurationManager.ConnectionStrings["con"].ToString();
        }
    }
}