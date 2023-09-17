using Microsoft.Win32;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        AccesoDatos datos;

        public void establecerConexion()
        {
            datos = new AccesoDatos();
        }

        public int agregar(Usuario nuevo)
        {
            establecerConexion();

            try
            {
                datos.setearConsulta("insert into Users (email, pass, admin) output inserted.Id values (@email, @pass, 0)");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();

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

        public int validarExisteMail(Usuario actual)
        {
            int cantidad = 0;
            string email;
            try
            {
                establecerConexion();
                email = actual.Email;
                datos.setearConsulta("Select count (email) as Existe from users where email = @email ");
                datos.setearParametro("@email", actual.Email);
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    cantidad = (int)datos.Lector["Existe"];
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return cantidad;
        }

        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, email, pass, admin, nombre, apellido, urlimagenperfil, admin from users where email = @email and Pass = @password");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@password", usuario.Pass);

                datos.ejecutarLector();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)(datos.Lector["Admin"]);
                    if (!(datos.Lector["urlimagenperfil"] is DBNull))
                        usuario.UrlImagenPerfil = (string)(datos.Lector["urlimagenperfil"]);
                    return true;

                }
                return false;

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

        public void modificar(Usuario usuario)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Update Users set nombre = @nombre, apellido = @apellido, email = @email, urlimagenperfil = @imagenperfil where Id = @id");
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@imagenperfil", (object)usuario.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@id", usuario.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Usuario> listar(string id)
        {
            List<Usuario> lista = new List<Usuario>();
            establecerConexion();

            try
            {

                datos.setearConsulta("select id, nombre, apellido, email, urlimagenperfil from users where email = @email");
                datos.setearParametro("@email", id);
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.Id = (int)datos.Lector["id"];
                    aux.Email = (string)datos.Lector["email"];
                    aux.Apellido = (!(datos.Lector["Apellido"] is DBNull)) ? (string)datos.Lector["Apellido"] : "";
                    aux.Nombre = (!(datos.Lector["Nombre"] is DBNull)) ? (string)datos.Lector["Nombre"] : "";
                    aux.UrlImagenPerfil = (!(datos.Lector["urlimagenperfil"] is DBNull)) ? (string)datos.Lector["urlimagenperfil"] : "";

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
