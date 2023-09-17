using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos(string servidor, string basedatos, string usuario, string contrasena)
        {
            //conexion = new SqlConnection("server= PC-BEJERMAN\\SQLEXPRESS; database= catalogo_db; user= sa; password=sabejerman");
            conexion = new SqlConnection("server= " + servidor + "; database=" + basedatos + " ; user=" + usuario + "; password=" + contrasena);
            comando = new SqlCommand();
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server= .\\SQLEXPRESS; database= catalogo_Web_db; user= sa; password=sabejerman");
            //string servidor, basedatos, usuario, pasword;
            //servidor = ConfigurationManager.AppSettings["server"];
            //basedatos = ConfigurationManager.AppSettings["db"];
            //usuario = ConfigurationManager.AppSettings["user"];
            //pasword = ConfigurationManager.AppSettings["pass"];
            //conexion = new SqlConnection("server= " + servidor + "; database=" + basedatos + " ; user=" + usuario + "; password=" + pasword);
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void ejecutarLector()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ejecutarVerificacion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteReader();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void probarConexion()
        {
            try
            {
                conexion.Open();
                conexion.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
    }
}
