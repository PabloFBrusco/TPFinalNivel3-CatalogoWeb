using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos datos;
        public void establecerConexion()
        {
            datos = new AccesoDatos();
        }
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            establecerConexion();   
            try
            {

                datos.setearConsulta("select id, descripcion from categorias order by descripcion");
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

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
        public void agregar(Categoria nuevo)
        {
            establecerConexion();

            try
            {
                datos.setearConsulta("insert into categorias (Descripcion) values (@Descripcion)");
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

        public void modificar(Categoria categoria)
        {
            establecerConexion();
            try
            {
                datos.setearConsulta("update Categorias set Descripcion = @Descripcion Where Id = @id");
                datos.setearParametro("@Descripcion", categoria.descripcion);
                datos.setearParametro("@Id", categoria.id);

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
                datos.setearConsulta("delete from categorias where id = @id");
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
                datos.setearConsulta("Select count(codigo) cantidad from articulos where idCategoria = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    cantidad = (int)datos.Lector["cantidad"];
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
