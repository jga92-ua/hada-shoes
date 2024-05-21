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
    class CADLineaCesta
    {
        private string constring;
        public CADLineaCesta()
        {
            constring = ConfigurationManager.ConnectionStrings["Database1"].ToString();

        }

        public bool setUnit(ENLineaCesta lc, int units)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "update linCest " +
                    "set cantidad = " + units + " " +
                    "where numCesta = " + lc.NumCesta + " and linea = " + lc.Linea, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
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

        public int getUnits(ENLineaCesta lc)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "select cantidad " +
                    "from linCest " +
                    "where numCesta = " + lc.NumCesta + " and linea = " + lc.Linea, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            DataTable linCestData = new DataTable();
                            sda.Fill(linCestData);

                            if (linCestData.Rows.Count > 0)
                                return Convert.ToInt32(linCestData.Rows[0][0].ToString());
                            return -1;
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

        public bool removeItem(ENLineaCesta lc)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("" +
                    "delete from linCest " +
                    "where numCesta = " + lc.NumCesta + " and linea = " + lc.Linea, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
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
    }
}
