using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Encapsular;
using System.Configuration;
using Npgsql;
using NpgsqlTypes;

namespace Datos
{
    public class Da_Motobombas
    {
        public DataTable insertarProducto(e_producto user)
        {
            DataTable Producto = new DataTable();
            NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("agregar.agregar_producto", conectar);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.Add("_url_imagen", NpgsqlDbType.Varchar).Value = user.Url_imagen;
                dataAdapter.SelectCommand.Parameters.Add("_marca", NpgsqlDbType.Varchar).Value = user.Marca;
                dataAdapter.SelectCommand.Parameters.Add("_referencia", NpgsqlDbType.Varchar).Value = user.Referencia;
                dataAdapter.SelectCommand.Parameters.Add("_valor", NpgsqlDbType.Integer).Value = user.Valor;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer).Value = user.Cantidad;
                dataAdapter.SelectCommand.Parameters.Add("_id_categoria", NpgsqlDbType.Integer).Value = user.Id_categoria;
                dataAdapter.SelectCommand.Parameters.Add("_proveedor_producto", NpgsqlDbType.Integer).Value = user.Proveedor_producto;





                conectar.Open();
                dataAdapter.Fill(Producto);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conectar != null)
                {
                    conectar.Close();
                }
            }
            return Producto;
        }
    }
}
