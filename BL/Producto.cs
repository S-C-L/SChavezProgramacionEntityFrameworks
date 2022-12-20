using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace BL
{
    public class Producto
    {
        //Agrega Producto Add con Entity Framework.
        static public ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
          
            
           
            try
            {
                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                {


                    var query = context.ProductoAddEF(producto.Nombre,((decimal)producto.PrecioUnitario),producto.Stock,
                      producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento,producto.Descripcion);

                    

                    //Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento,Descripcion

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error hubo algun error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesagge = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        //Metodo de producto GetAll Entity Framework
        static public ML.Result ProductoGetAllEF()

        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                {
                    var query = context.ProductoGetAllEF().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                       /* ML.Producto producto = new ML.Producto();

                        producto.Proveedor = new ML.Proveedor();
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.Area = new ML.Area();*/



                        foreach (var objProducto in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Proveedor = new ML.Proveedor();
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.Area = new ML.Area();

                            //usuario.id_Usuario = objUsuario.id_Usuario;
                            producto.IdProducto = objProducto.IdProducto;
                            producto.Nombre = objProducto.Nombre;
                            producto.PrecioUnitario = double.Parse(objProducto.PrecioUnitario.ToString());
                            producto.Stock = objProducto.Stock;
                            producto.Proveedor.NombreProveedor = objProducto.NombreProveedor;
                            producto.Proveedor.TelefonoProveedor = objProducto.TelefonoProveedor;
                            producto.Departamento.NombreDepartamento = objProducto.NombreDepartamento;
                            producto.Departamento.Area.NombreArea=objProducto.NombreArea;

                            result.Objects.Add(producto);
                        }

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesagge = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //metodo Producto GetById Entity  Framework.

        static public ML.Result ProductoGetByIdEF(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                {
                    var objProducto = context.ProductoGetByIdEF(IdProducto).Single();


                    if (objProducto != null)
                    {

                        ML.Producto producto = new ML.Producto(); //Instanciar la clase de producto       
                        producto.Proveedor = new ML.Proveedor(); //INstanciamos cada una de las clases que tengan su id
                        producto.Departamento = new ML.Departamento();/// CLase Proveedor, CLase departamento
                        producto.Departamento.Area = new ML.Area(); /// Clase Area

                        producto.IdProducto = objProducto.IdProducto;
                        producto.Nombre = objProducto.Nombre;
                        producto.PrecioUnitario = double.Parse(objProducto.PrecioUnitario.ToString());
                        producto.Stock = objProducto.Stock;
                        producto.Proveedor.NombreProveedor = objProducto.NombreProveedor;
                        producto.Proveedor.TelefonoProveedor = objProducto.TelefonoProveedor;
                        producto.Departamento.NombreDepartamento = objProducto.NombreDepartamento;             
                        producto.Departamento.Area.NombreArea = objProducto.NombreDelArea;
                        producto.Descripcion = objProducto.DescripcionProducto;


                        //IdProducto, Nombre,PrecioUNitario,Stock,NombreProveedor,TelefonoProveedor,
                        //NombreDepartamento,NOmbreARea,DescripcionProducto.



                        result.Object = producto;

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesagge = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //agrego Producto Delete Entity framework
        static public ML.Result ProductoDeleteEF(ML.Producto producto) //cambia usuario por id
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                //using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    var query = context.ProductoDeleteEF(producto.IdProducto);

                    //Idproducto,Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento,Descripcion

                    if (query > 0)
                    {
                        Console.WriteLine("Usuario ELiminado COrrectamente");
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error al ELiminar Usuario";
                    }

                }
                //Aqui termina llave de try
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesagge = ex.Message;
                result.Ex = ex;

            }
            return result;
        }


        //agrego Producto Update Entity framework
        static public ML.Result ProductoUpdateEF(ML.Producto producto) //cambia usuario por id
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                //using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    var query = context.ProductoUpdateEF(producto.IdProducto,producto.Nombre,double.Parse(producto.PrecioUnitario.ToString())
                        ,producto.Stock,producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento,producto.Descripcion);

                    //Idproducto,Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento,Descripcion ((decimal)producto.PrecioUnitario)

                    if (query > 0)
                    {
                        Console.WriteLine("Usuario Actualizado Correctamente");
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error al ELiminar Usuario";
                    }

                }
                //Aqui termina llave de try
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesagge = ex.Message;
                result.Ex = ex;

            }
            return result;
        }


    }
}
