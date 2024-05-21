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
    class CADCesta
    {
        private string constring;
        public CADCesta()
        {
            constring = ConfigurationManager.ConnectionStrings["Database1"].ToString();

        }

        public string getUserID(ENCesta c)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select usuario " +
                    "from cesta " +
                    "where numCesta = " + c.NumCesta +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);

                            if (linCestData.Rows.Count > 0)
                                return linCestData.Rows[0][0].ToString();
                            return null;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return null;
                        }
                    }
                }
            }
        }

        public bool AddNewBasketForUser(string dni)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select * " +
                    "from cesta " +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            con.Open();
                            DataTable cestData = new DataTable();
                            sda.Fill(cestData);
                            int maxIndex = 0;

                            foreach (DataRow row in cestData.Rows)
                            {
                                if (row.ToString() == dni)
                                    return false;

                                int linIndex = int.Parse(row[0].ToString());
                                if (linIndex > maxIndex)
                                    maxIndex = linIndex;
                            }

                            SqlCommand rowCmd = new SqlCommand("" +
                                "insert into cesta (numCesta, usuario) values (" +
                                (maxIndex + 1).ToString() + ",'" + dni + "')", con);

                            rowCmd.ExecuteNonQuery();

                            con.Close();

                            return true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return false;
                        }
                    }
                }
            }
        }

        public int getBasketByDNI(string dni)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select * " +
                    "from cesta " +
                    "where usuario = '" + dni + "'" +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable cestData = new DataTable();
                            sda.Fill(cestData);

                            if (cestData.Rows.Count <= 0)
                                return -1;
                            return int.Parse(cestData.Rows[0][0].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return -1;
                        }
                    }
                }
            }
        }

        public string getDNIByBasket(int basket)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select * " +
                    "from cesta " +
                    "where numCesta = " + basket.ToString() +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable cestData = new DataTable();
                            sda.Fill(cestData);

                            if (cestData.Rows.Count > 0)
                                return cestData.Rows[0][1].ToString();
                            return null;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return null;
                        }
                    }
                }
            }
        }

        public bool ProceedToBuy(ENCesta c) { return false; }

        public DataTable ShowBasketItems(string dni)
        {
            //string constring = ConfigurationManager.ConnectionStrings["bbdd"].ToString();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select p.nombre, p.imagen, lc.numCesta, lc.linea, " +
                    "lc.importe, lc.cantidad, lc.importe*lc.cantidad as total " +
                    "from linCest lc " +
                    "inner join producto p " +
                    "on lc.producto = p.id_producto " +
                    "inner join cesta c " +
                    "on c.numCesta = lc.numCesta and c.usuario = '" + dni + "'", con))
                // TO DO: Detect user session in c.usuario
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);
                            return linCestData;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return null;
                        }
                    }
                }
            }
        }

        public void InsertItemsIntoBasket(int numCesta, int producto, float importe, int cantidad)
        {
            //string constring = ConfigurationManager.ConnectionStrings["bbdd"].ToString();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select *" +
                    "from linCest " +
                    "where numCesta = " + numCesta +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);
                            int maxIndex = 0;

                            foreach (DataRow row in linCestData.Rows)
                            {
                                int linIndex = int.Parse(row[1].ToString());
                                if (linIndex > maxIndex)
                                    maxIndex = linIndex;
                            }

                            using (SqlCommand rowCmd = new SqlCommand("" +
                                "insert into linCest (numCesta, linea, producto, importe, cantidad) values (" +
                                numCesta.ToString() + "," + (maxIndex + 1).ToString() + "," + producto.ToString() +
                                "," + importe.ToString().Replace(',', '.') + "," + cantidad.ToString() + ")", con))
                            {
                                con.Open();
                                rowCmd.ExecuteNonQuery().ToString();
                                con.Close();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                        }

                    }
                }
            }
        }

        public void InsertItemsIntoOrders(int numCesta)
        {
            //string constring = ConfigurationManager.ConnectionStrings["bbdd"].ToString();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select *" +
                    "from linCest " +
                    "where numCesta = " + numCesta +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            con.Open();
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);

                            int numPed = GenerateOrder(getDNIByBasket(numCesta));

                            foreach (DataRow row in linCestData.Rows)
                            {
                                SqlCommand rowCmd = new SqlCommand("" +
                                    "insert into linPed values (" +
                                    numPed + "," + row[1] + "," + row[2] +
                                    "," + row[3] + "," + row[4], con);

                                rowCmd.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                        }
                    }
                }
            }
        }

        public void DeleteItemsFromBasket(int numCesta)
        {
            //string constring = ConfigurationManager.ConnectionStrings["bbdd"].ToString();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select *" +
                    "from linCest " +
                    "where numCesta = " + numCesta +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            con.Open();
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);

                            foreach (DataRow row in linCestData.Rows)
                            {
                                SqlCommand rowCmd = new SqlCommand("" +
                                    "delete from linCest " +
                                    "where numCesta = " + numCesta + " " +
                                    "and linea = " + row[1], con);

                                rowCmd.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                        }
                    }
                }
            }
        }

        public int GenerateOrder(string dni)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select * " +
                    "from pedido " +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable pedidoData = new DataTable();
                            sda.Fill(pedidoData);
                            int maxIndex = 0;

                            foreach (DataRow row in pedidoData.Rows)
                            {
                                int pedIndex = int.Parse(row[1].ToString());
                                if (pedIndex > maxIndex)
                                    maxIndex = pedIndex;
                            }

                            maxIndex++;

                            using (SqlCommand rowCmd = new SqlCommand("" +
                                "insert into pedido values (" +
                                maxIndex.ToString() + ",'" + dni + "', '" + DateTime.Today.ToString("YYYY/MM/DD") + "')", con))
                            {
                                con.Open();
                                rowCmd.ExecuteNonQuery().ToString();
                                con.Close();
                            }

                            return maxIndex;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return -1;
                        }
                    }
                }
            }
        }
        public bool CheckIfHaveBuyData(string userID, int numCesta)
        {
            bool hasBuyData = false;

            using (SqlConnection conn = new SqlConnection(constring))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Compras WHERE UserID = @UserID AND NumCesta = @NumCesta";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@NumCesta", numCesta);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            hasBuyData = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores apropiado (por ejemplo, loguear el error)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return hasBuyData;
        }
        public bool CheckIfSomeItem()
        {
            //string constring = ConfigurationManager.ConnectionStrings["bbdd"].ToString();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select * " +
                    "from linCest " +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);

                            return linCestData.Rows.Count > 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return false;
                        }
                    }
                }
            }
        }

        public bool CheckIfItemExists(int numCesta, int linea)
        {
            //string constring = ConfigurationManager.ConnectionStrings["bbdd"].ToString();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select * " +
                    "from linCest " +
                    "where numCesta = " + numCesta + " and linea = " + linea +
                    "", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);

                            return linCestData.Rows.Count > 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                            return false;
                        }
                    }
                }
            }
        }



    }

}
