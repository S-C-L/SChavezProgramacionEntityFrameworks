using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducto" in both code and config file together.
    [ServiceContract]
    public interface IProducto
    {
     /*   [OperationContract]
        void DoWork();*/

        [OperationContract]
        ML.Result AddEF(ML.Producto producto); //Add WCF

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))] //GetAll WCF
        ML.Result ProductoGetAllEF();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))] //GetbyId WCF
        ML.Result ProductoGetByIdEF(int IdProducto);

        [OperationContract]
        ML.Result ProductoUpdateEF(ML.Producto producto); //Update WCF

          [OperationContract]
           ML.Result ProductoDeleteEF(ML.Producto producto); // Delete WCF

        

    }
}
