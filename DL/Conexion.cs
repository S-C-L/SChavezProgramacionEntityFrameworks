using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DL
{
  static  public class Conexion
    {
       static public string Get()
        {
            string conexion = "Data Source=LAPTOP-QQ07NK59;Initial Catalog=Datos;User ID=sa;Password=pass@word1";
            //Data Source=LAPTOP-QQ07NK59;Initial Catalog=Datos;User ID=sa;Password=***********
            return conexion;
        }
    }
}
