using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RicePK
{
    public class Helper
    {
        public static string GetString()
        {

            //return "Data Source=202.163.87.3\ADVANCEERP,1434;Initial Catalog=DataRicePK;integrated security=True";
            // return "Data Source=DESKTOP-PICF7QA\\SQLEXPRESS;Initial Catalog=Data;integrated security=True";

            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["DataConn"].ConnectionString;

            return strcon;



        }
    }
}