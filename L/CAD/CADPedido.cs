using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADPedido
    {
        private string dbd;
        public CADPedido()
        {
            dbd = ConfigurationManager.ConnectionStrings["Database1"].ToString();

        }
        public bool readPedido(ENPedido en)
        {
            bool devolver = false;
            using (SqlConnection c = new SqlConnection(dbd))
            {
                c.Open();
                String s = "Select * from pedido";
                SqlCommand comando = new SqlCommand(s, c);
                SqlDataReader data = comando.ExecuteReader();
                while (data.Read())
                {
                    if ((int)data["numPedido"] == en.numPedido)
                    {
                        en.dni = data["dni"].ToString();
                        en.fecha = data["fecha"].ToString();
                        devolver = true;
                        break;
                    }
                }
            }
            return devolver;
        }

        public bool deletePedido(ENPedido en)
        {
            SqlConnection c = new SqlConnection(dbd);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from pedido where numPedido=" + en.numPedido, c);
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
        public bool createPedido(ENPedido en)
        {
            using (SqlConnection c = new SqlConnection(dbd))
            {
                using (SqlCommand comando = new SqlCommand("Insert into pedido(numPedido, dni, fecha) values(" + en.numPedido + ", '" + en.dni + "', '" + en.fecha + "')", c))
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

        public bool modifyPedido(ENPedido en)
        {
            bool devolver;
            SqlConnection con = new SqlConnection(dbd);

            try
            {
                con.Open();
                SqlCommand comando = new SqlCommand("Update pedido set numPedido=" + en.numPedido + ", dni='" + en.dni + "', fecha='" + en.fecha + " where numPedido=" + en.numPedido, con);
                comando.ExecuteNonQuery();
                devolver = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pedido operation failed");
                devolver = false;
            }
            finally
            {
                if (con != null) con.Close();
            }

            return devolver;
        }

        public DataTable getPedidos(string dni)
        {
            SqlConnection c = new SqlConnection(dbd);
            c.Open();
            DataTable data = new DataTable();
            try
            {
                /*SqlCommand com = new SqlCommand("select numPedido, fecha, sum(importe*cantidad) " +
                                                "from pedido, linPed " +
                                                "where linPed.num_pedido == pedido.numPedido and usuario = '" + dni + "'" +
                                                "group by numPedido, fecha " +
                                                "order by fecha DESC", c);*/
                SqlCommand com = new SqlCommand("select numPedido, fecha, sum(importe*cantidad) as total from pedido, linPed where linPed.num_pedido = pedido.numPedido and usuario = '" + dni + "' group by numPedido, fecha order by fecha DESC;", c);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(data);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción en getPedidos. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }
            return data;
        }
    }
}
