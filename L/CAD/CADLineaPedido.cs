using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class CADLineaPedido
    {
        private string constring;
        public CADLineaPedido()
        {
            constring = ConfigurationManager.ConnectionStrings["Database1"].ToString();

        }

        public bool readLinPed(ENLineaPedido en)
        {
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();

                SqlDataAdapter data = new SqlDataAdapter();
                SqlCommand com1 = new SqlCommand("select * from linPed where num_pedido = '" + en.num_pedido.ToString() + "'" + en._linea.ToString() + "'", c);
                SqlDataReader reader = data.SelectCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    en.num_pedido = Convert.ToInt32(reader.GetString(0));
                    en._linea = reader.GetInt32(1);
                    en.id_producto = reader.GetInt32(2);
                    en._cantidad = reader.GetInt32(4);
                    double pre = reader.GetDouble(3);
                    en._importe = Convert.ToSingle(pre);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Create provincia failed. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
            return true;
        }

        public bool createLinPed(ENLineaPedido en)
        {
            using (SqlConnection c = new SqlConnection(constring))
            {
                using (SqlCommand comando = new SqlCommand("Insert into linPed(num_pedido, linea,producto,importe, cantidad ) values('" + en.num_pedido + "', '" + en._linea + "," + en.id_producto + "," + en._importe + "," + en._cantidad + "')", c))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(comando))
                    {
                        try
                        {
                            c.Open();
                            comando.ExecuteNonQuery();
                            c.Close();
                            return true;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public bool deleteLinPed(ENLineaPedido en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from linPed where num_pedido='" + en.num_pedido + "and linea=" + en._linea + "'", c);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPCION");
                return false;
            }
            finally
            {
                c.Close();
            }


        }

        public bool updateLinPed(ENLineaPedido en)
        {
            SqlConnection con = new SqlConnection(constring);

            try
            {

                con.Open();


                SqlDataAdapter data = new SqlDataAdapter();
                data.UpdateCommand = new SqlCommand("Update linPed set num_pedido='" + en.num_pedido + "',linea=" + en._linea + "', importe=" + en._importe + "',producto=" + en.id_producto + "',cantidad=" + en._cantidad + "where num_pedido=" + en.num_pedido + " and linea=" + en._linea + "'", con);
                data.UpdateCommand.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("LinPed operation failed. Error:{0}", ex.Message);
                throw new Exception("LinPed operation failed. Error: " + ex.Message);
            }
            finally
            {
                if (con != null) con.Close();
            }

            return true;


        }
    }
}
