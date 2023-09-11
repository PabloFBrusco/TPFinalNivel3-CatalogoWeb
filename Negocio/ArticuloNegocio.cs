using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Configuration;
using System.Collections;
using System.Data.SqlTypes;

namespace Negocio
{
    public class ArticuloNegocio
    {
        AccesoDatos datos;
      
        public void establecerConexion()
        {
            datos = new AccesoDatos();
        }
        public void agregar(Articulo nuevo)
        {
            establecerConexion();

            try
            {
                datos.setearConsulta("insert into articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo,@Nombre,@Descripcion,@Marca,@Categoria,@Foto,@Precio)");
                datos.setearParametro("@Codigo", nuevo.codigo);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@Marca", nuevo.marca.id);
                datos.setearParametro("@Categoria", nuevo.categoria.id);
                datos.setearParametro("@Foto", nuevo.imagen);
                datos.setearParametro("@Precio", nuevo.precio);
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
        public void agregarsp(Articulo nuevo)
        {
            establecerConexion();

            try
            {
                datos.setearSP("stored_Alta_Articulo");
                datos.setearParametro("@Codigo", nuevo.codigo);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@Marca", nuevo.marca.id);
                datos.setearParametro("@Categoria", nuevo.categoria.id);
                datos.setearParametro("@Foto", nuevo.imagen);
                datos.setearParametro("@Precio", nuevo.precio);
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
        public void modificar(Articulo arti, int id)
        {
            establecerConexion();
            try
            {
                datos.setearConsulta("update Articulos set Codigo = @Codigo, Nombre = @nombre, Descripcion = @Descripcion, IdMarca = @Marca, IdCategoria = @Categoria, ImagenUrl = @Foto, Precio = @Precio Where Id = @id");
                datos.setearParametro("@Codigo", arti.codigo);
                datos.setearParametro("@Nombre", arti.nombre);
                datos.setearParametro("@Descripcion", arti.descripcion);
                datos.setearParametro("@Marca", arti.marca.id);
                datos.setearParametro("@Categoria", arti.categoria.id);
                datos.setearParametro("@Foto", arti.imagen);
                datos.setearParametro("@Precio", arti.precio);
                datos.setearParametro("@Id",id);

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

        public void modificarconsp(Articulo arti, int id)
        {
            establecerConexion();
            try
            {
                datos.setearSP("sp_Modificar_Articulo");
                datos.setearParametro("@Codigo", arti.codigo);
                datos.setearParametro("@Nombre", arti.nombre);
                datos.setearParametro("@Descripcion", arti.descripcion);
                datos.setearParametro("@Marca", arti.marca.id);
                datos.setearParametro("@Categoria", arti.categoria.id);
                datos.setearParametro("@Foto", arti.imagen);
                datos.setearParametro("@Precio", arti.precio);
                datos.setearParametro("@Id", id);

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
                datos.setearConsulta("delete from articulos where id = @id");
                datos.setearParametro("@id", id);
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

        public List<Articulo> listar_sp()
        {
            List<Articulo> lista = new List<Articulo>();
            establecerConexion();
            try
            {
                datos.setearSP("sp_catalogo");
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.imagen = (string)datos.Lector["imagenurl"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.precio = (float)(decimal)datos.Lector["precio"];
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

        public List<Articulo> filtrar(string consulta)
        {
            List<Articulo> lista = new List<Articulo>();
            establecerConexion();
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.imagen = (string)datos.Lector["imagenurl"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.precio = (float)(decimal)datos.Lector["precio"];
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
    }
}
