using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public void DoWork()
        {
        }

        public int Sumar(int NumeroUno, int NumeroDos)
        {
            //return string.Format("You entered: {0}", value);
            return NumeroUno + NumeroDos;
        }

        public int Restar(int NumeroUno, int NumeroDos)
        {
            //return string.Format("You entered: {0}", value);
            return NumeroUno - NumeroDos;
        }

        public int Multiplicar(int NumeroUno, int NumeroDos)
        {
            //return string.Format("You entered: {0}", value);
            return NumeroUno * NumeroDos;
        }

        public int Dividir(int NumeroUno, int NumeroDos)
        {
            //return string.Format("You entered: {0}", value);
            return NumeroUno / NumeroDos;
           if (NumeroUno == 0)
            {
                Console.WriteLine("Error no se puede dividir entre 0");
            }
           if(NumeroDos == 0)
            {
                Console.WriteLine("Error no se puede dividir entre 0");
            }
        }
    }
}
