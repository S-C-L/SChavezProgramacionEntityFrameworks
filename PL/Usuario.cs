using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PL
{
    public class Usuario
    {
        static public void Add() // Metodo AGregar Usuario
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("------------------Ingresa los datos del usuario a capturar---------------");
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Paterno");
            /*  usuario.Apellido_paterno = Console.ReadLine();
              Console.WriteLine("Apellido Materno");
              usuario.APellido_materno = Console.ReadLine();
              Console.WriteLine("Edad");
              usuario.Edad = int.Parse(Console.ReadLine());
              Console.WriteLine("Correo Electronico");
              usuario.Correo_electronico = Console.ReadLine();*/
           // ML.Result result = BL.Usuario.AddEF(usuario);
            Console.ReadLine();
            BL.Usuario.Add(usuario);
        }

        static public void Update() //Metod Actualizar Usuario
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("------------------Ingresa id para actualizar---------------");
            Console.WriteLine("id_Usuario");
            usuario.id_Usuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Paterno");
        /*    usuario.Apellido_paterno = Console.ReadLine();
            Console.WriteLine("Apellido Materno");
            usuario.APellido_materno = Console.ReadLine();
            Console.WriteLine("Edad");
            usuario.Edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Correo Electronico");
            usuario.Correo_electronico = Console.ReadLine();
            Console.ReadLine();*/
            BL.Usuario.Update(usuario);

        }

        static public void Delete() //Metodo ELiminar usuario
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("------------------Ingresa el id de usuario que desee Eliminar---------------");
            Console.WriteLine("id_Usuario");
            usuario.id_Usuario = int.Parse(Console.ReadLine());
            Console.ReadLine();
            BL.Usuario.Delete(usuario);

        }
        static public void GetAll() //Get All
        {
            ML.Result result = BL.Usuario.GetAll();
            foreach (ML.Usuario usuario in result.Objects)
            {
                Console.WriteLine("El Id es: " + usuario.id_Usuario);
                Console.WriteLine("El Nombre es: " + usuario.Nombre);
          /*      Console.WriteLine("El Apellido Paterno es: " + usuario.Apellido_paterno);
                Console.WriteLine("El Apellido Materno: " + usuario.APellido_materno);
                Console.WriteLine("La edad es:   " + usuario.Edad);
                Console.WriteLine("EL correo es: " + usuario.Correo_electronico);
                Console.WriteLine("---------------------------------------------");
                // BL.Usuario.Select(usuario);*/
            }
        }
        static public void GetById() //Get By Id
        {

            Console.WriteLine("------------------Ingresa el id de usuario que desee Buscar---------------");
            Console.WriteLine("id_Usuario");
           int id_Usuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetById(id_Usuario);

          

            if (result.Correct)
          {
              ML.Usuario usuario = (ML.Usuario) result.Object; //Unboxing 
                Console.ReadLine();//---------------------------------------
                Console.WriteLine("El Id es: " + usuario.id_Usuario);
                Console.WriteLine("El Nombre es: " + usuario.Nombre);
            /*    Console.WriteLine("El Apellido Paterno es: " + usuario.Apellido_paterno);
                Console.WriteLine("El Apellido Materno: " + usuario.APellido_materno);
                Console.WriteLine("La edad es:   " + usuario.Edad);
                Console.WriteLine("EL correo es: " + usuario.Correo_electronico);*/
             
            }
            else
          {
              Console.WriteLine("Ocurrio un error" + result.ErrorMesagge);
          }

        }

        static public void GetByIdSP() //Get By Id Store Procedure
        {

            Console.WriteLine("------------------Ingresa el id de usuario que desee Buscar---------------");
            Console.WriteLine("id_Usuario");
            int id_Usuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetById(id_Usuario);



            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object; //Unboxing 
                Console.ReadLine();//---------------------------------------
                Console.WriteLine("El Id es: " + usuario.id_Usuario);
                Console.WriteLine("El Nombre es: " + usuario.Nombre);
             /*   Console.WriteLine("El Apellido Paterno es: " + usuario.Apellido_paterno);
                Console.WriteLine("El Apellido Materno: " + usuario.APellido_materno);
                Console.WriteLine("La edad es:   " + usuario.Edad);
                Console.WriteLine("EL correo es: " + usuario.Correo_electronico);*/

            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMesagge);
            }

        }

        static public void GetByIdSPA() //Get By Id Store Procedure Actualizado
        {

            Console.WriteLine("------------------Ingresa el id de usuario que desee Buscar---------------");
            Console.WriteLine("id_Usuario");
            int id_Usuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdSPA(id_Usuario);



            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object; //Unboxing 
                Console.ReadLine();//---------------------------------------
                Console.WriteLine("El Id es: " + usuario.id_Usuario);
                Console.WriteLine("El UsserName es: " + usuario.UserName);
                Console.WriteLine("El Nombre es: " + usuario.Nombre);
                Console.WriteLine("El Apellido Paterno es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El Apellido Materno es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El Email es: " + usuario.Email);
                Console.WriteLine("El Password es: " + usuario.Password);
                Console.WriteLine("La Fecha de Nacimiento es: " + usuario.FechaNacimiento);
                Console.WriteLine("El Sexo es: " + usuario.Sexo);
                Console.WriteLine("El Telefono es: " + usuario.Telefono);
                Console.WriteLine("El Celular es: " + usuario.Celular);
                Console.WriteLine("El CURP es: " + usuario.CURP);


            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMesagge);
            }

        }

        static public void GetALlSPA() //Get All Store Procedure Actualizado
        {

            ML.Result result = BL.Usuario.GetALlSPA();
            foreach (ML.Usuario usuario in result.Objects)
            {
                Console.WriteLine("El Id es: " + usuario.id_Usuario);
                Console.WriteLine("El UsserName es: " + usuario.UserName);
                Console.WriteLine("El Nombre es: " + usuario.Nombre);
                Console.WriteLine("El Apellido Paterno es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El Apellido Materno es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El Email es: " + usuario.Email);
                Console.WriteLine("El Password es: " + usuario.Password);
                Console.WriteLine("La Fecha de Nacimiento es: " + usuario.FechaNacimiento);
                Console.WriteLine("El Sexo es: " + usuario.Sexo);
                Console.WriteLine("El Telefono es: " + usuario.Telefono);
                Console.WriteLine("El Celular es: " + usuario.Celular);
                Console.WriteLine("El CURP es: " + usuario.CURP);
                Console.ReadLine();//---------------------------------------

            }

        }

        static public void AddSP() // Metodo AGregar Usuario
        {
            ML.Usuario usuario = new ML.Usuario();
 
            Console.WriteLine("------------------Ingresa los datos del usuario a capturar---------------");
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Fecha de Nacimiento");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Telefono");
            usuario.Telefono= Console.ReadLine();
            Console.WriteLine("CURP");
            usuario.CURP= Console.ReadLine();
            Console.WriteLine("Sexo");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Password");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("User Name");
            usuario.UserName = Console.ReadLine();

            //Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Celular,Telefono,
            //CURP,Sexo,Email,Password,Username
            BL.Usuario.AddSP(usuario);
        }

        static public void DeleteSP() //Metodo ELiminar usuario con Store Procedure
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("------------------Ingresa el id de usuario que desee Eliminar---------------");
            Console.WriteLine("id_Usuario");
            usuario.id_Usuario = int.Parse(Console.ReadLine());
            Console.ReadLine();
            BL.Usuario.DeleteSP(usuario);

        }

        static public void UpdateSP() //Metod Actualizar Usuario
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("------------------Ingresa id para actualizar---------------");
            Console.WriteLine("id_Usuario");
            usuario.id_Usuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();
         //   Console.WriteLine("Password");
            //usuario.Password = Console.ReadLine();
           //  Console.WriteLine("Apellido paterno");
            //    usuario.ApellidoPaterno = Console.ReadLine();
            //    Console.WriteLine("Fecha de Nacimiento");
              //  usuario.FechaNacimiento = (Console.ReadLine());
            /*    Console.WriteLine("Celular");
                usuario.Celular = Console.ReadLine();
            Console.WriteLine("CURP");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Sexo");
            usuario.Sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Apellido materno");
            usuario.ApellidoMaterno= Console.ReadLine();
            Console.WriteLine("UserName");
            usuario.UserName = Console.ReadLine();*/
            Console.ReadLine();
       
            BL.Usuario.UpdateSP(usuario);

        }

        //Agrego Add con Store Procedure en entity framework
        static public void AddEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("-----------------Ingrese los datos del Usuario--------------------");
            Console.WriteLine("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el ApellidoPaterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el ApellidoMaterno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese la Fecha de Nacimiento: ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Sexo");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("CURP");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("UserName");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Password");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("IdRol");
            usuario.IdRol = int.Parse(Console.ReadLine());

            //Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,Telefono,Celular,CURP,Email,UserName,
            //Password,IdRol) 
           
            ML.Result result = BL.Usuario.AddEF(usuario);

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

        //Get By Id ENTITY FRAMEWORK.
        static public void GetByIdEF()
        {
            Console.WriteLine("Ingrese el id del Usuario a buscar");
            int id_Usuario = int.Parse(Console.ReadLine());
           
            ML.Result result = BL.Usuario.GetByIdEF(id_Usuario);

            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
         
                Console.WriteLine("El Id del Usuario es: " + usuario.id_Usuario);
                Console.WriteLine("El Nombre es: " + usuario.Nombre);
                Console.WriteLine("El Apellido Paterno es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El Apellido Materno es: " + usuario.ApellidoMaterno);
                Console.WriteLine("La Fecha de Nacimiento es: " + usuario.FechaNacimiento);
                Console.WriteLine("El Sexo es: " + usuario.Sexo);
                Console.WriteLine("El Telefono es: " + usuario.Telefono);
                Console.WriteLine("El Celular es: " + usuario.Celular);
                Console.WriteLine("El CURP es: " + usuario.CURP);
                Console.WriteLine("El Email es: " + usuario.Email);
                Console.WriteLine("El UserName es: " + usuario.UserName);
                Console.WriteLine("El Password es: " + usuario.Password);
               // Console.WriteLine("El Rol es: " + usuario.Rol.Nombre);
                Console.WriteLine("---------------------------------------------");
                //Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,Telefono,Celular,CURP,Email,
                //UserName,Password,IdRol) 
                Console.ReadLine();


            }

            else
            {
                Console.WriteLine("Error" +result.ErrorMesagge);
            }

          
        }

        // Get All Entity Framework
        static public void GetAllEF()
        {
            ML.Result result = BL.Usuario.GetAllEF();

            foreach (ML.Usuario usuario in result.Objects)
            {
            
                Console.WriteLine("El Id del Usuario es: " +usuario.id_Usuario);
                Console.WriteLine("El Nombre es: " +usuario.Nombre);
                Console.WriteLine("El Apellido Paterno es: " +usuario.ApellidoPaterno);
                Console.WriteLine("El Apellido Materno es: " +usuario.ApellidoMaterno);
                Console.WriteLine("La Fecha de Nacimiento es: " +usuario.FechaNacimiento);
                Console.WriteLine("El Sexo es: " +usuario.Sexo);
                Console.WriteLine("El Telefono es: " +usuario.Telefono);
                Console.WriteLine("El Celular es: " +usuario.Celular);
                Console.WriteLine("El CURP es: " +usuario.CURP);
                Console.WriteLine("El Email es: " +usuario.Email);
                Console.WriteLine("El UserName es: " +usuario.UserName);
                Console.WriteLine("El Password es: " +usuario.Password);
                // Console.WriteLine("El Rol es: " + usuario.Rol.Nombre);
                Console.WriteLine("---------------------------------------------");
              
            }
            Console.ReadLine();
        }



    }

}



