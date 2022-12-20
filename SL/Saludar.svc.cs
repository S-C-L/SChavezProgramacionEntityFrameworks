using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Saludar" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Saludar.svc or Saludar.svc.cs at the Solution Explorer and start debugging.
    public class Saludar : ISaludar
    {
        public void DoWork()
        {
        }

        public  string Saludo(string nombre)
        {
            return "Hola " +nombre;
        }
    }
}
