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
    public class Usuario
    {
        static public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "INSERT INTO [Usuario]([Nombre],[Apellido_paterno],[APellido_materno],[Edad],[Correo_electronico])VALUES(@Nombre,@Apellido_paterno,@Apellido_materno,@Edad,@Correo_electronico)";
                    SqlParameter[] collection = new SqlParameter[5];
                    // collection[0] = new SqlParameter("Nombre",Usuario.
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("Apellido_paterno", SqlDbType.VarChar);
                    /* collection[1].Value = usuario.Apellido_paterno;
                     collection[2] = new SqlParameter("Apellido_materno", SqlDbType.VarChar);
                     collection[2].Value = usuario.APellido_materno;
                     collection[3] = new SqlParameter("Edad", SqlDbType.Int);
                     collection[3].Value = usuario.Edad;
                     collection[4] = new SqlParameter("Correo_electronico", SqlDbType.VarChar);
                     collection[4].Value = usuario.Correo_electronico;*/

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        Console.WriteLine("Usuario Insertado");
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error al insertar usuario";
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
        //agrego Update
        static public ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;


                    cmd.CommandText = "UPDATE Usuario SET Nombre = @Nombre,Apellido_paterno =  @Apellido_paterno,APellido_materno = @APellido_materno,Edad =  @Edad,Correo_electronico = @Correo_electronico WHERE id_Usuario = @id_Usuario";

                    SqlParameter[] collection = new SqlParameter[6];
                    collection[0] = new SqlParameter("@id_Usuario", SqlDbType.Int);
                    collection[0].Value = usuario.id_Usuario;
                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("@Apellido_paterno", SqlDbType.VarChar);
                    /*   collection[2].Value = usuario.Apellido_paterno;
                       collection[3] = new SqlParameter("@Apellido_materno", SqlDbType.VarChar);
                       collection[3].Value = usuario.APellido_materno;
                       collection[4] = new SqlParameter("@Edad", SqlDbType.Int);
                       collection[4].Value = usuario.Edad;
                       collection[5] = new SqlParameter("@Correo_electronico", SqlDbType.VarChar);
                       collection[5].Value = usuario.Correo_electronico;*/

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        Console.WriteLine("Usuario Actualizado");
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error al Actualizar Usuario";
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



        //agrego Delete
        static public ML.Result Delete(ML.Usuario usuario) //cambia usuario por id
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    //DELETE FROM Usuario WHERE ID = @ID;
                    cmd.CommandText = "DELETE FROM Usuario WHERE id_Usuario= @id_Usuario";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@id_Usuario", SqlDbType.Int);
                    collection[0].Value = usuario.id_Usuario;


                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        Console.WriteLine("Usuario ELiminado");
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

        //agrego Select
        static public ML.Result GetAll() //Get All
        {
            ML.Result result = new ML.Result(); ;

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT id_Usuario, Nombre, Apellido_paterno,APellido_materno,Edad, Correo_electronico FROM Usuario;";

                    SqlDataAdapter da = new SqlDataAdapter(cmd); //Uso de Objeto SQLAdapter
                    DataTable tablausuario = new DataTable(); //datosusuario == tabla de usuario de la bd

                    da.Fill(tablausuario);

                    if (tablausuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in tablausuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.id_Usuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            /*    usuario.Apellido_paterno = row[2].ToString();
                                usuario.APellido_materno = row[3].ToString();
                                usuario.Edad = int.Parse(row[4].ToString());
                                usuario.Correo_electronico = row[5].ToString();*/

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error";
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

        //agrego Select(GetById)

        static public ML.Result GetById(int id_Usuario) //Get By Id
        {
            ML.Result result = new ML.Result(); ;

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    //cmd.CommandText = "UsuarioGetByid ";
                    cmd.CommandText = "SELECT id_Usuario, Nombre, Apellido_paterno,APellido_materno,Edad, Correo_electronico FROM Usuario WHERE id_Usuario=@id_Usuario;";
                    //SELECT id_Usuario, Nombre, Apellido_paterno,APellido_Materno,Edad, Correo_electronico FROM Usuario WHERE Id_Usuario =2;
                    //    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("id_Usuario", SqlDbType.Int);
                    collection[0].Value = id_Usuario;
                    SqlDataAdapter da = new SqlDataAdapter(cmd); //Uso de Objeto SQLAdapter
                    DataTable tablausuario = new DataTable(); //datosusuario == tabla de usuario de la bd

                    cmd.Parameters.AddRange(collection);

                    da.Fill(tablausuario);

                    if (tablausuario.Rows.Count > 0)
                    {
                        // result.Objects = new List<object>();

                        DataRow row = tablausuario.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.id_Usuario = int.Parse(row[0].ToString());
                        usuario.Nombre = row[1].ToString();
                        /*   usuario.Apellido_paterno = row[2].ToString();
                           usuario.APellido_materno = row[3].ToString();
                           usuario.Edad = int.Parse(row[4].ToString());
                           usuario.Correo_electronico = row[5].ToString();*/

                        result.Object = usuario; //BOXING
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error";
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

        //agrego Select(GetById) con store proceded

        static public ML.Result GetByIdSP(int id_Usuario) //Get By Id SP
        {
            ML.Result result = new ML.Result(); ;

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioGetByid ";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("id_Usuario", SqlDbType.Int);
                    collection[0].Value = id_Usuario;
                    SqlDataAdapter da = new SqlDataAdapter(cmd); //Uso de Objeto SQLAdapter
                    DataTable tablausuario = new DataTable(); //datosusuario == tabla de usuario de la bd

                    cmd.Parameters.AddRange(collection);

                    da.Fill(tablausuario);

                    if (tablausuario.Rows.Count > 0)
                    {

                        DataRow row = tablausuario.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.id_Usuario = int.Parse(row[0].ToString());
                        usuario.Nombre = row[1].ToString();
                        /*   usuario.Apellido_paterno = row[2].ToString();
                           usuario.APellido_materno = row[3].ToString();
                           usuario.Edad = int.Parse(row[4].ToString());
                           usuario.Correo_electronico = row[5].ToString();*/

                        result.Object = usuario; //BOXING
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error";
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

        //agrego Select(GetById) con store proceded

        static public ML.Result GetByIdSPA(int id_Usuario) //Get By Id SPActualizado
        {
            ML.Result result = new ML.Result(); ;

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioGetByIdStoreProcedure";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("id_Usuario", SqlDbType.Int);
                    collection[0].Value = id_Usuario;
                    /*  collection[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
                      collection[1].Value = UserName;

                      collection[2] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                      collection[2].Value = Nombre;*/

                    SqlDataAdapter da = new SqlDataAdapter(cmd); //Uso de Objeto SQLAdapter
                    DataTable tablausuario = new DataTable(); //datosusuario == tabla de usuario de la bd

                    cmd.Parameters.AddRange(collection);

                    da.Fill(tablausuario);

                    if (tablausuario.Rows.Count > 0)
                    {

                        DataRow row = tablausuario.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.id_Usuario = int.Parse(row[0].ToString());
                        usuario.UserName = row[1].ToString();
                        usuario.Nombre = row[2].ToString();
                        usuario.ApellidoPaterno = row[3].ToString();
                        usuario.ApellidoMaterno = row[4].ToString();
                        usuario.Email = row[5].ToString();
                        usuario.Password = row[6].ToString();
                        usuario.FechaNacimiento =  DateTime.Parse(row[7].ToString());
                        usuario.Sexo =row[8].ToString();
                        usuario.Telefono = row[9].ToString();
                        usuario.Celular = row[10].ToString();
                        usuario.CURP = row[11].ToString();




                        result.Object = usuario; //BOXING
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error";
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

        //agrego Select Get All SP
        static public ML.Result GetALlSPA() //Get All Store Procede Actualizado
        {
            ML.Result result = new ML.Result(); ;

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    //cmd.CommandText = "SELECT id_Usuario, Nombre, Apellido_paterno,APellido_materno,Edad, Correo_electronico FROM Usuario;";
                    cmd.CommandText = "UsuarioGetAllStoreProcedureA";
                    SqlDataAdapter da = new SqlDataAdapter(cmd); //Uso de Objeto SQLAdapter
                    DataTable tablausuario = new DataTable(); //datosusuario == tabla de usuario de la bd

                    da.Fill(tablausuario);

                    if (tablausuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in tablausuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.id_Usuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[7].ToString());
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();


                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error";
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
        //agrego ADd SP
        static public ML.Result AddSP(ML.Usuario usuario) //Agrego Agregar con Store Proceded
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    //  cmd.CommandText = "INSERT INTO [Usuario]([Nombre],[Apellido_paterno],[APellido_materno],[Edad],[Correo_electronico])VALUES(@Nombre,@Apellido_paterno,@Apellido_materno,@Edad,@Correo_electronico)";
                    cmd.CommandText = "UsuarioAddSP";

                    SqlParameter[] collection = new SqlParameter[12];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                    collection[3].Value = usuario.FechaNacimiento;
                    collection[4] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[4].Value = usuario.Celular;
                    collection[5] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[5].Value = usuario.Telefono;
                    collection[7] = new SqlParameter("CURP", SqlDbType.VarChar);
                    collection[7].Value = usuario.CURP;
                    collection[8] = new SqlParameter("Sexo", SqlDbType.VarChar);
                    collection[8].Value = usuario.Sexo;
                    collection[9] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[9].Value = usuario.Email;
                    collection[10] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[10].Value = usuario.Password;
                    collection[11] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[11].Value = usuario.UserName;


                    // Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Celular,Telefono,CURP,Sexo,Email,
                    // Password,Username

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        Console.WriteLine("Usuario Insertado");
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error al insertar usuario";
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

        //agrego Delete Store procedure
        static public ML.Result DeleteSP(ML.Usuario usuario) //cambia usuario por id
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    //DELETE FROM Usuario WHERE ID = @ID;
                    cmd.CommandText = "UsuarioDeleteSPA";

                    SqlParameter[] collection = new SqlParameter[13];
                    collection[0] = new SqlParameter("@id_Usuario", SqlDbType.Int);
                    collection[0].Value = usuario.id_Usuario;
                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        Console.WriteLine("Usuario ELiminado");
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

        //agrego Update
        static public ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;


                     cmd.CommandText = "Prueba9";
                    // cmd.CommandText = "UPDATE Usuario SET Nombre = @Nombre ,Password= @Password,ApellidoPaterno = @ApellidoPaterno,FechaNacimiento = @FechaNacimiento,Celular = @Celular,CURP = @CURP,Sexo = @Sexo,Telefono = @Telefono,Email = @Email,ApellidoMaterno = @APellidoMaterno,UserName = @UserName WHERE id_Usuario = @id_Usuario;";
                    //  cmd.CommandText = "UPDATE Usuario SET Nombre = @Nombre ,Password= @Password,ApellidoPaterno = @ApellidoPaterno,FechaNacimiento = @FechaNacimiento,Celular = @Celular, CURP = @CURP, Sexo =@Sexo,Telefono = @Telefono,Email = @Email  WHERE id_Usuario = @id_Usuario";
                    // cmd.CommandText = "UPDATE Usuario SET Nombre = @Nombre ,Password= @Password,ApellidoPaterno =@ApellidoPaterno, FechaNacimiento = @FechaNacimiento WHERE id_Usuario = @id_Usuario";

                    SqlParameter[] collection = new SqlParameter[1];
                   collection[0] = new SqlParameter("@id_Usuario", SqlDbType.Int);
                  collection[0].Value = usuario.id_Usuario;
                   collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                   // collection[2] = new SqlParameter("@Password", SqlDbType.VarChar);
                    //collection[2].Value = usuario.Password;
                   // collection[3] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                   // collection[3].Value = usuario.ApellidoPaterno;
                  //  collection[4] = new SqlParameter("@FechaNacimiento", SqlDbType.VarChar);
                  //  collection[4].Value = usuario.FechaNacimiento;
                 /*   collection[5] = new SqlParameter("@Celular", SqlDbType.VarChar);
                    collection[5].Value = usuario.Celular;
                    collection[6] = new SqlParameter("@CURP", SqlDbType.VarChar);
                    collection[6].Value = usuario.CURP;
                    collection[7] = new SqlParameter("@Sexo", SqlDbType.VarChar);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("@Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("@Email", SqlDbType.Char);
                    collection[9].Value = usuario.Email;
                    collection[10] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[10].Value = usuario.ApellidoMaterno;
                    collection[11] = new SqlParameter("@UserName", SqlDbType.VarChar);
                    collection[11].Value = usuario.UserName;*/


                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        Console.WriteLine("Usuario Actualizado");
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMesagge = "Error al Actualizar Usuario";
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

        //Agrega Add con Entuty framework.
        static public ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                {
                    /* var query = context.UsuarioAddEF(usuario.Nombre,usuario.ApellidoPaterno, usuario.ApellidoMaterno, 
                         usuario.FechaNacimiento,usuario.Sexo,usuario.Telefono,usuario.Celular,usuario.CURP,usuario.Email,
                         usuario.UserName,usuario.Password,usuario.IdRol);*/

                    var query = context.UsuarioAddEF(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                        usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Email,
                        usuario.UserName, usuario.Password, usuario.IdRol);

                    //Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,Telefono,Celular,CURP,Email,UserName,Password,IdRol) 

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

        //metodo GetById Entity  Framework.

        static public ML.Result GetByIdEF(int id_Usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                {
                    var objUsuario = context.UsuarioGetByIdEF(id_Usuario).Single();


                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        ML.Rol rol = new ML.Rol();
                        usuario.id_Usuario = objUsuario.id_Usuario;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.Value;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;
                        usuario.Email = objUsuario.Email;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Password = objUsuario.Password;
                      //  usuario.Rol.Nombre = objUsuario.Nombre;


                        //Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,Telefono,Celular,CURP,Email,UserName,Password,IdRol) 

                        result.Object = usuario;

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

        //Metodo GetAll Entity Framework
          static public ML.Result GetAllEF()
          
        {
              ML.Result result = new ML.Result();
              try
              {

                  using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                  {
                    var query = context.UsuarioGetAllEF().ToList();
               
                    if (query != null)
                      {
                          result.Objects = new List<object>();
                      //    ML.Usuario usuario = new ML.Usuario();

                     
                            foreach (var objUsuario in query)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.id_Usuario = objUsuario.id_Usuario;
                                usuario.Nombre = objUsuario.Nombre;
                                usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                                usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                                usuario.FechaNacimiento = objUsuario.FechaNacimiento.Value;
                                usuario.Sexo = objUsuario.Sexo;
                                usuario.Telefono = objUsuario.Telefono;
                                usuario.Celular = objUsuario.Celular;
                                usuario.CURP = objUsuario.CURP;
                                usuario.Email = objUsuario.Email;
                                usuario.UserName = objUsuario.UserName;
                                usuario.Password = objUsuario.Password;
                              
                              //usuario.Rol = new ML.Rol();
                              //  usuario.Rol = objUsuario.IdRol.Value;


                                //Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,Telefono,Celular,CURP,
                                //Email,UserName,Password,IdRol) 

                                result.Objects.Add(usuario);
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

       /*    static public ML.Result AddLINQ(ML.Usuario usuario)
           {
               ML.Result result = new ML.Result();
               try
               {
                using (DL_EF.SChavezProgramacionNCapasDiciembreEntities context = new DL_EF.SChavezProgramacionNCapasDiciembreEntities())
                {
                       DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();
                       usuarioLINQ.Nombre = usuario.Nombre;
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;


                    // usuarioLINQ.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture); // MM/dd/yyyy dd-MM-yyy
                    usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento.ToString()); // MM/dd/yyyy dd-MM-yyy
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.Celular = usuario.Celular;
                    usuarioLINQ.CURP = usuario.CURP;
                    usuarioLINQ.Email = usuario.Email;
                    usuarioLINQ.UserName = usuario.UserName;

                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.IdRol = usuario.IdRol;


                    //Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Sexo,Telefono,Celular,CURP,
                    //Email,UserName,Password,IdRol) 


                    context.UsuarioAdd.Add(usuarioLINQ);
                     context.SaveChanges();





                }
            }
               catch (Exception ex)
               {
                   result.ErrorMesagge = ex.Message;
                   result.Correct = false;
                   result.Ex = ex;
               }
               return result;
           }*/

    }
}
  

   

   

