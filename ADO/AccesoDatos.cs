using System.Data;
using Microsoft.Data.SqlClient;
using Entidades;
using Entidades.Enumerados;
using System.Collections.Specialized;

namespace ADO
{
    public class AccesoDatos
    {
        #region Atributos

        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand? comando;
        private SqlDataReader? lector;

        #endregion

        #region Constructores

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.miConexion;
        }

        public AccesoDatos()
        {
            // CREO UN OBJETO SQLCONECTION
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }

        #endregion

        #region Métodos

        #region Probar conexión

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        #endregion

        #region Select

        public List<SistemaOperativo> ObtenerListaSistemas()
        {
            List<SistemaOperativo> lista = new List<SistemaOperativo>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT id, nombre, version, espacioGB, estadoSoporte, edicion, virtualizacionPermitida, distribucion, interfazGrafica, integracionIcloud, compatibleConProcesadorApple FROM tabla";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {

                    if ((int)lector["tipo"] == 0)
                    {
                        //windows
                        Windows sistema = new Windows();
                        sistema.Nombre = lector["nombre"].ToString();
                        sistema.Version = lector["version"].ToString();
                        sistema.EspacioGB = (float)lector["espacioGB"];
                        sistema.Soporte = (EEstadoSoporte)lector["estadoSoporte"];
                        sistema.Edicion = (EEdicionWindows)lector["edicion"];
                        sistema.VirtualizacionPermitida = (bool)lector["virtualizacionPermitida"];
                        lista.Add(sistema);
                    }
                    else if ((int)lector["tipo"] == 1)
                    {
                        //mac
                        MacOS sistema = new MacOS();
                        sistema.Nombre = lector["nombre"].ToString();
                        sistema.Version = lector["version"].ToString();
                        sistema.EspacioGB = (float)lector["espacioGB"];
                        sistema.Soporte = (EEstadoSoporte)lector["estadoSoporte"];
                        sistema.CompatibleConProcesadorApple = (bool)lector["compatibleConProcesadorApple"];
                        sistema.IntegracionIcloud = (bool)lector["integracionIcloud"];
                        lista.Add(sistema);
                    }
                    else if ((int)lector["tipo"] == 2) 
                    { 
                        //linux
                        Linux sistema = new Linux();
                        sistema.Nombre = lector["nombre"].ToString();
                        sistema.Version = lector["version"].ToString();
                        sistema.EspacioGB = (float)lector["espacioGB"];
                        sistema.Soporte = (EEstadoSoporte)lector["estadoSoporte"];
                        sistema.Distribucion = (EDistribucionLinux)lector["distribucion"];
                        sistema.InterfazGrafica = (bool)lector["interfazGrafica"];
                        lista.Add(sistema);
                    }
                }
                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        #endregion

        #region Insert

        public bool AgregarDato(SistemaOperativo sistema)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();
                string sql;

                this.comando.Parameters.AddWithValue("@nombre", sistema.Nombre);
                this.comando.Parameters.AddWithValue("@version", sistema.Version);
                this.comando.Parameters.AddWithValue("@espacioGB", sistema.EspacioGB);
                this.comando.Parameters.AddWithValue("@estadoSoporte", (int)sistema.Soporte);
                sql = "INSERT INTO tabla (nombre, version, espacioGB, estadoSoporte) VALUES (@nombre, @version, @espacioGB, @estadoSoporte)";

                if (sistema.GetType() == typeof(Windows))
                {
                    Windows windows = (Windows)sistema;
                    this.comando.Parameters.AddWithValue("@edicion", (int)windows.Edicion);
                    this.comando.Parameters.AddWithValue("@virtualizacionPermitida", windows.VirtualizacionPermitida);

                    sql = "INSERT INTO tabla (nombre, version, espacioGB, estadoSoporte, edicion, virtualizacionPermitida) VALUES (@nombre, @version, @espacioGB, @estadoSoporte, @edicion, @virtualizacionPermitida)";

                }
                else if(sistema.GetType() == typeof(Linux))
                {
                    Linux linux = (Linux)sistema;
                    this.comando.Parameters.AddWithValue("@distribucion", (int)linux.Distribucion);
                    this.comando.Parameters.AddWithValue("@interfazGrafica", linux.InterfazGrafica);

                    sql = "INSERT INTO tabla (nombre, version, espacioGB, estadoSoporte, distribucion, interfazGrafica) VALUES (@nombre, @version, @espacioGB, @estadoSoporte, @distribucion, @interfazGrafica)";

                }
                else if (sistema.GetType() == typeof(MacOS))
                {
                    MacOS mac = (MacOS)sistema;
                    this.comando.Parameters.AddWithValue("@integracionIcloud", mac.IntegracionIcloud);
                    this.comando.Parameters.AddWithValue("@compatibleConProcesadorApple", mac.CompatibleConProcesadorApple);

                    sql = "INSERT INTO tabla (nombre, version, espacioGB, estadoSoporte, integracionIcloud, compatibleConProcesadorApple) VALUES (@nombre, @version, @espacioGB, @estadoSoporte, @integracionIcloud, @compatibleConProcesadorApple)";

                }

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        //#endregion

        //#region Update

        ///// <summary>
        ///// Modifica un elemento de la DB por ID, si el id no existe o por algun otra razon no modificó el elemento, retorna false
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //public bool ModificarDato(Dato param)
        //{
        //    bool rta = true;

        //    try
        //    {
        //        this.comando = new SqlCommand();

        //        this.comando.Parameters.AddWithValue("@id", param.id);
        //        this.comando.Parameters.AddWithValue("@cadena", param.cadena);
        //        this.comando.Parameters.AddWithValue("@entero", param.entero);
        //        this.comando.Parameters.AddWithValue("@flotante", param.flotante);

        //        string sql = "UPDATE dato ";
        //        sql += "SET cadena = @cadena, entero = @entero, flotante = @flotante ";
        //        sql += "WHERE id = @id";

        //        this.comando.CommandType = CommandType.Text;
        //        this.comando.CommandText = sql;
        //        this.comando.Connection = this.conexion;

        //        this.conexion.Open();

        //        int filasAfectadas = this.comando.ExecuteNonQuery();

        //        if (filasAfectadas == 0)
        //        {
        //            rta = false;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        rta = false;
        //    }
        //    finally
        //    {
        //        if (this.conexion.State == ConnectionState.Open)
        //        {
        //            this.conexion.Close();
        //        }
        //    }

        //    return rta;
        //}

        //#endregion

        //#region Delete

        //public bool EliminarDato(int id)
        //{
        //    bool rta = true;

        //    try
        //    {
        //        this.comando = new SqlCommand();

        //        this.comando.Parameters.AddWithValue("@id", id);

        //        string sql = "DELETE FROM dato ";
        //        sql += "WHERE id = @id";

        //        this.comando.CommandType = CommandType.Text;
        //        this.comando.CommandText = sql;
        //        this.comando.Connection = this.conexion;

        //        this.conexion.Open();

        //        int filasAfectadas = this.comando.ExecuteNonQuery();

        //        if (filasAfectadas == 0)
        //        {
        //            rta = false;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        rta = false;
        //    }
        //    finally
        //    {
        //        if (this.conexion.State == ConnectionState.Open)
        //        {
        //            this.conexion.Close();
        //        }
        //    }

        //    return rta;
        //}

        #endregion

        #endregion
    }
}
