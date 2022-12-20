using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
       static public void AddEF()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("-----------------Ingrese los datos del Producto--------------------");
            Console.WriteLine("Ingrese el Nombre del producto: ");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Precio Unitario: ");
            producto.PrecioUnitario = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Stock del producto: ");
            producto.Stock = int.Parse(Console.ReadLine());
            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingrese el Id del Proveedor: ");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el Id del Departamento: ");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());
           // producto.Departamento.IdDepartamento= int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Descripcion: ");
            producto.Descripcion = Console.ReadLine();




            //Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento,Descripcion

            ML.Result result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                Console.WriteLine("Usuario Insertado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar" + result.ErrorMesagge);
            }
            Console.ReadLine();
        }


        // Get All Entity Framework
        static public void ProductoGetAllEF()
        {
            ML.Result result = BL.Producto.ProductoGetAllEF();

            foreach (ML.Producto producto in result.Objects)
            {
 
                Console.WriteLine("El Id del Usuario es: " + producto.IdProducto);
                Console.WriteLine("El Nombre del producto es: " + producto.Nombre);
                Console.WriteLine("El precio es: " + producto.PrecioUnitario);
                Console.WriteLine("El Stock es: " + producto.Stock);
               // producto.Proveedor = new ML.Proveedor();
                Console.WriteLine("El Nombre del proovedor es: " + producto.Proveedor.NombreProveedor.ToString());
                Console.WriteLine("El Telefono del proovedor es: " + producto.Proveedor.TelefonoProveedor);
               // producto.Departamento = new ML.Departamento();
                Console.WriteLine("El Nombre del departamento es: " + producto.Departamento.NombreDepartamento);
                Console.WriteLine("El Nombre del area es: " + producto.Departamento.Area.NombreArea);
                Console.WriteLine("---------------------------------------------");
                Console.ReadLine();
            }
           Console.ReadLine();
        }

        static public void ProductoGetByIdEF() //Producto Get By Id Store Procedure 
        {

            Console.WriteLine("------------------Ingresa el Id de Producto que desee Buscar---------------");
            Console.WriteLine("IdProducto");
            int IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.ProductoGetByIdEF(IdProducto);

            if (result.Correct)
            {
                ML.Producto producto = (ML.Producto)result.Object; //Unboxing 
                Console.ReadLine();//---------------------------------------
                Console.WriteLine("El Id es: " + producto.IdProducto);
                Console.WriteLine("El Nombre del producto es: " + producto.Nombre);
                Console.WriteLine("El precio Unitario es: " + producto.PrecioUnitario);
                Console.WriteLine("El Stock del producto es: " + producto.Stock);
                Console.WriteLine("El Nombre del proveedor es: " + producto.Proveedor.NombreProveedor);
                Console.WriteLine("El Telefono del proveedor es: " + producto.Proveedor.TelefonoProveedor);
                Console.WriteLine("El Nombre del departamento es: " + producto.Departamento.NombreDepartamento);
                Console.WriteLine("La Nombre del area es: " + producto.Departamento.Area.NombreArea);
                Console.WriteLine("La descripcion del producto es: " + producto.Descripcion);
                Console.ReadLine();

                //IdProducto, Nombre,PrecioUNitario,Stock,NombreProveedor,TelefonoProveedor,
                //NombreDepartamento,NOmbreARea,DescripcionProducto.

            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMesagge);
            }

        }

        static public void ProductoDeleteEF() //Producto Get By Id Store Procedure 
        {     
            ML.Producto producto = new ML.Producto();
            Console.WriteLine("------------------Ingresa el Id de Producto que desee Eliminar---------------");
            Console.WriteLine("IdProducto");
            producto.IdProducto= int.Parse(Console.ReadLine());
            Console.ReadLine();
            BL.Producto.ProductoDeleteEF(producto);
        }

        static public void ProductoUpdateEF() //Metod Actualizar Usuario
        {
           // ML.Usuario usuario = new ML.Usuario();
            ML.Producto producto = new ML.Producto();
            producto.Proveedor = new ML.Proveedor(); //INstanciamos cada una de las clases que tengan su id
            producto.Departamento = new ML.Departamento();/// CLase Proveedor, CLase departamento
            producto.Departamento.Area = new ML.Area(); /// Clase Area
            Console.WriteLine("------------------Ingresa Id para Actualizar---------------");
            Console.WriteLine("IdProducto");
            producto.IdProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("------------------Actualizar Nuevos Datos del Producto---------------");
            Console.WriteLine("Nombre");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Precio Unitario");
            producto.PrecioUnitario = Convert.ToDouble(Console.ReadLine());
            //producto.PrecioUnitario = Console.ReadLine();
            Console.WriteLine("Stock");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Id del Proveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            Console.WriteLine("Id del Departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Descripcion");
            producto.Descripcion = Console.ReadLine();
            //Idproducto,Nombre,PrecioUnitario,Stock,IdProveedor,IdDepartamento,Descripcion

            Console.ReadLine();
            BL.Producto.ProductoUpdateEF(producto);

          //  BL.Usuario.UpdateSP(usuario);

        }
    }
}
