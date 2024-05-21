using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
	public class CADTipoProducto
	{
		private string constring { get; set; }
		public CADTipoProducto()
		{
			constring = ConfigurationManager.ConnectionStrings["Database1"].ToString();

		}

		public bool createTipoProducto(ENTipoProducto tip)
		{
			bool retorno = false;
			using (SqlConnection c = new SqlConnection(constring))
			{
				try
				{
					c.Open();
					SqlCommand comprobar = new SqlCommand("Select * from tipo_producto where tipo_producto = '" + tip.tipo_producto + "')", c);
					SqlDataReader data = comprobar.ExecuteReader();
					if (data.Read()) return false;
					data.Close();

					SqlCommand com = new SqlCommand("Insert into tipo_producto (tipo_producto) values ('" + tip.tipo_producto + "')", c);
					com.ExecuteNonQuery();
					retorno = true;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Can't Create tipo_producto. Process Failed. Error : {0}", e.Message);
					return false;
				}
				finally
				{
					c.Close();
				}

			}
			return retorno;
		}
		public bool readTipoProducto(ENTipoProducto tip)
		{
			bool retorno = false;
			using (SqlConnection c = new SqlConnection(constring))
			{
				try
				{
					c.Open();
					SqlCommand com = new SqlCommand("Select * from tipo_producto where tipo_producto = '" + tip.tipo_producto + "'", c);
					SqlDataReader data = com.ExecuteReader();

					while (data.Read())
					{
						tip.tipo_producto = data["tipo_producto"].ToString();
					}

					data.Close();
					retorno = true;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Can't Read tipo_producto. Process Failed. Error : {0}", e.Message);
					return false;
				}
				finally
				{
					c.Close();
				}
			}
			return retorno;
		}
		public bool updateTipoProducto(ENTipoProducto tip)
		{
			bool retorno = false;
			using (SqlConnection c = new SqlConnection(constring))
			{
				try
				{
					c.Open();
					SqlCommand com = new SqlCommand("Update tipo_producto from tipo_producto set tipo_producto = '" + tip.tipo_producto + "'", c);
					com.ExecuteNonQuery();
					retorno = true;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Can't Update tipo_producto. Process Failed. Error : {0}", e.Message);
					return false;
				}
				finally
				{
					c.Close();
				}
			}
			return retorno;
		}

		public bool deleteTipoProducto(ENTipoProducto tip)
		{
			bool retorno = false;
			using (SqlConnection c = new SqlConnection(constring))
			{
				try
				{
					c.Open();
					SqlCommand com = new SqlCommand("Delete * from tipo_producto where tipo_producto = '" + tip.tipo_producto + "'", c);
					com.ExecuteNonQuery();
					retorno = true;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Can't Delete tipo_producto. Process Failed. Error : {0}", e.Message);
					return false;
				}
				finally
				{
					c.Close();
				}
			}
			return retorno;
		}
	}
}
