using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> listado = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source = T480S-JMJ\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id as Id,A.Codigo,A.Nombre,A.Descripcion,A.ImagenUrl,A.Precio,C.Descripcion,M.Descripcion "
                                      + "FROM MARCAS as M "
                                      + "INNER JOIN ARTICULOS AS A ON M.Id = A.IdMarca "
                                      + "INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Categoria = new CategoriaDominio();
                    aux.Marca = new MarcaDominio();

                    aux.CodArticulo = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ImagenURL = (string)lector[4];
                    aux.Precio = (float)double.Parse(lector["Precio"].ToString());
                    aux.Categoria.Descripcion = (string)lector[6];
                    aux.Marca.Descripcion = (string)lector[7];
                    listado.Add(aux);
                }

                return listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void agregar(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "data source = T480S-JMJ\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenURL,Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenURL,@Precio)";
                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("IdMarca", nuevo.Marca.Id.ToString());
                comando.Parameters.AddWithValue("IdCategoria", nuevo.Categoria.Id.ToString());
                comando.Parameters.AddWithValue("@ImagenURL", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                comando.Connection = conexion;


                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public Articulo buscarPorCodigo(string idArticulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "data source = T480S-JMJ\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM ARTICULOS WHERE Codigo LIKE '" + idArticulo + "'";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                Articulo articulo = new Articulo();

                while (lector.Read())
                {
                    articulo.CodArticulo = lector.GetInt32(0);
                    articulo.Codigo = lector.GetString(1);
                    articulo.Nombre = lector.GetString(2);
                    articulo.Descripcion = lector.GetString(3);
                    articulo.ImagenURL = lector.GetString(6);
                    articulo.Precio = (float)lector.GetDecimal(7);
                }
                return articulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void modificar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "data source = LAPTOP-41LKJ1NF\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandText = "UPDATE ARTICULOS set ARTICULOS.Nombre = @Nombre, "
                + "ARTICULOS.Descripcion=@Descripcion,ARTICULOS.IdMarca=@IdMarca,"
                + "ARTICULOS.IdCategoria=@IdCategoria,ARTICULOS.ImagenURL=@ImagenURL,ARTICULOS.Precio=@Precio "
                + " WHERE ARTICULOS.Codigo = @Codigo";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("IdMarca", articulo.Marca.Id.ToString());
                comando.Parameters.AddWithValue("IdCategoria", articulo.Categoria.Id.ToString());
                comando.Parameters.AddWithValue("@ImagenURL", articulo.ImagenURL);
                comando.Parameters.AddWithValue("@Precio", articulo.Precio);
                comando.Connection = conexion;


                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void eliminar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "data source = LAPTOP-41LKJ1NF\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandText = "DELETE FROM ARTICULOS WHERE ARTICULOS.Codigo = @Codigo";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Articulo> buscar(Articulo articulo)
        {
            List<Articulo> listado = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source = LAPTOP-41LKJ1NF\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id as Id,A.Codigo,A.Nombre,A.Descripcion,A.ImagenUrl,A.Precio,C.Descripcion,M.Descripcion "
                                      + "FROM MARCAS as M "
                                      + "INNER JOIN ARTICULOS AS A ON M.Id = A.IdMarca "
                                      + "INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id "
                                      + "WHERE A.Id = @Codigo";
                comando.CommandType = System.Data.CommandType.Text;
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Categoria = new CategoriaDominio();
                    aux.Marca = new MarcaDominio();

                    aux.CodArticulo = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ImagenURL = (string)lector[4];
                    aux.Precio = (float)double.Parse(lector["Precio"].ToString());
                    aux.Categoria.Descripcion = (string)lector[6];
                    aux.Marca.Descripcion = (string)lector[7];
                    listado.Add(aux);
                }

                return listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
