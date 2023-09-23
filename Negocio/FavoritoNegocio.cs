using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Negocio
{
    public class FavoritoNegocio
    {
        AccesoDatos datos;
        public void establecerConexion()
        {
            datos = new AccesoDatos();
        }

        public bool EvaluarFavorito(Favorito seleccionado)
        {
            int cantidad;
            cantidad = 0;
            try
            {
                establecerConexion();
                datos.setearConsulta("Select count(id) favo from favoritos where IdUser = @idUser and idArticulo = @IdArt");
                datos.setearParametro("@idUser", seleccionado.idUser);
                datos.setearParametro("@idArt", seleccionado.idArticulo);
                datos.ejecutarLector();

                while (datos.Lector.Read())
                {
                    cantidad = (int)datos.Lector["favo"];
                }

                if (cantidad > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AgregoFavorito(Favorito nuevo)
        {
            establecerConexion();

            try
            {
                datos.setearConsulta("insert into Favoritos (idUser,idArticulo) values (@idUser, @idArticulo)");
                datos.setearParametro("@idUser", nuevo.idUser);
                datos.setearParametro("@idArticulo", nuevo.idArticulo);
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
        public void BorroFavorito(Favorito nuevo)
        {
            establecerConexion();

            try
            {
                datos.setearConsulta("Delete Favoritos where idUser = @idUser and idArticulo = @idArticulo");
                datos.setearParametro("@idUser", nuevo.idUser);
                datos.setearParametro("@idArticulo", nuevo.idArticulo);
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
    }
    
}
