using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<CategoriaDominio> listar()
        {
            List<CategoriaDominio> listado = new List<CategoriaDominio>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "data source = T480S-JMJ\\SQLEXPRESS; initial catalog = CATALOGO_DB;integrated security = sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Descripcion from CATEGORIAS";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while(lector.Read())
                {
                    CategoriaDominio aux = new CategoriaDominio();
                    aux.Descripcion = lector.GetString(0);
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
