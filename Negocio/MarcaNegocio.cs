using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {

        AccesoDatos datos;
        public void establecerConexion()
        {
            datos = new AccesoDatos();
        }
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            establecerConexion();
            //AccesoDatos datos = new AccesoDatos(servidor, basedatos, usuario, pasword);
            try
            {

                datos.setearConsulta("select id, descripcion from marcas order by descripcion");
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.id = (int)datos.Lector["id"];
                    aux.descripcion = (string)datos.Lector["descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Marca nuevo)
        {
            establecerConexion();

            try
            {
                datos.setearConsulta("insert into marcas (Descripcion) values (@Descripcion)");
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Marca marca)
        {
            establecerConexion();
            try
            {
                datos.setearConsulta("update Marcas set Descripcion = @Descripcion Where Id = @id");
                datos.setearParametro("@Descripcion", marca.descripcion);
                datos.setearParametro("@Id", marca.id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            try
            {
                establecerConexion();
                datos.setearConsulta("delete from marcas where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int VerificarArticulos(int id)
        {
            int cantidad;
            cantidad = 0;
            try
            {
                establecerConexion();
                datos.setearConsulta("Select count(codigo) marca from articulos where Idmarca = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    cantidad = (int)datos.Lector["marca"];
                }
                


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cantidad;
        }
    }
}
