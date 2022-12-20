using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int Sumar(int NumeroUno, int NumeroDos); //Interfaz del metodo Sumar

        [OperationContract]
        int Restar(int NumeroUno, int NumeroDos); //Interfaz del metodo Restar

        [OperationContract]
        int Multiplicar(int NumeroUno, int NumeroDos); //Interfaz del metodo Multiplicar

        [OperationContract]
        int Dividir(int NumeroUno, int NumeroDos); //Interfaz del metodo Dividir
    }
}
