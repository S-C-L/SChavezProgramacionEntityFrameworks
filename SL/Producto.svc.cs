using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ML;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        /*   public void DoWork()
           {
           }/*/



        public ML.Result AddEF(ML.Producto producto) //Agregar WCF
        {
            ML.Result result = BL.Producto.Add(producto);
            return result;

            //return new SL.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };

        }

        public ML.Result ProductoGetAllEF() // Buscar WCF GetALl
        {
            ML.Result result = BL.Producto.ProductoGetAllEF();
            return result;
        }

        public ML.Result ProductoGetByIdEF(int IdProducto) 
        {
            ML.Result result = BL.Producto.ProductoGetByIdEF(IdProducto);
            return result;

        }
        public ML.Result ProductoUpdateEF(ML.Producto producto) 
            {
            ML.Result result = BL.Producto.ProductoUpdateEF(producto);
            return result;
            }

        public ML.Result ProductoDeleteEF(ML.Producto producto) 
         {
             ML.Result result= BL.Producto.ProductoDeleteEF(producto);
             return result;
         }

    }
}
