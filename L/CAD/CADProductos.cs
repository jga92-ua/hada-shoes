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
    class CADProductos
    {
        private string constring;

        public CADProductos()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();

        }
        public bool readProductos(ENProductos en)
        {
            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();

                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand("Select nombre, descripción,tipo_producto, precio, imagen,categoria,id_producto from producto where id_producto='" + en.id_producto + "'", con);
                SqlDataReader reader = data.SelectCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    en.nom_producto = reader.GetString(0);
                    en.desc_producto = reader.GetString(1);
                    en.tipo_producto = reader.GetString(2);
                    en.ImageLocation = reader.GetString(4);
                    en.id_producto = reader.GetInt32(6);
                    en.categoria = reader.GetString(4);

                    double pre = reader.GetDouble(3);
                    en.pre_producto = Convert.ToSingle(pre);
                }
                else
                {

                    Console.WriteLine("Product operation has failed. Error:Cant found the id");
                    throw new Exception("ERROR:El id del producto no ha sido encontrado" + en.id_producto);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {

                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                throw new Exception("Product operation has failed. Error: {0}" + ex.Message);
            }
            finally
            {
                if (con != null) con.Close();
            }

            return true;
        }

        public bool createProductos(ENProductos en)
        {
            using (SqlConnection c = new SqlConnection(constring))
            {
                using (SqlCommand comando = new SqlCommand("Insert into producto(id_producto ,nombre, descripción, precio, imagen, tipo_producto, categoria) values(" + en.id_producto + ", '" + en.nom_producto + "', '" + en.desc_producto + "', " + en.pre_producto + ", '" + en.ImageLocation + "', '" + en.tipo_producto + "', '" + en.categoria + "')", c))
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

        public bool deleteProductos(ENProductos en)
        {
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from producto where id_producto='" + en.id_producto + "'", c);
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

        public bool updateProductos(ENProductos en)
        {
            bool devolver;
            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();
                SqlCommand comando = new SqlCommand("Update producto set nombre='" + en.nom_producto + "',descripción='" + en.desc_producto + "', precio=" + en.pre_producto + ",imagen='" + en.ImageLocation + "',tipo_producto='" + en.tipo_producto + "', categoria='" + en.categoria + "' where id_producto= " + en.id_producto, con);
                comando.ExecuteNonQuery();
                devolver = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Brand operation failed");
                devolver = false;
            }
            finally
            {
                if (con != null) con.Close();
            }

            return devolver;
        }
        private bool exist(ENProductos en, SqlConnection con)
        {
            SqlDataAdapter data = new SqlDataAdapter();
            data.SelectCommand = new SqlCommand("Select * from producto where id='" + en.id_producto + "'", con);
            int i = data.SelectCommand.ExecuteNonQuery();
            return (null != data.SelectCommand.ExecuteScalar());
        }

        public DataTable getMostSold()
        {
            String conn = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(conn);
            try
            {
                string sqlquery = "select top 6 p.id_producto, p.nombre, p.precio, p.imagen, sum(l.cantidad) from producto p, linPed l where l.producto=p.id_producto group by p.id_producto, p.nombre, p.precio, p.imagen order by sum(cantidad) desc";
                sqlconn.Open();
                SqlCommand command = new SqlCommand(sqlquery, sqlconn);
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                DataTable tab = new DataTable();
                sqlda.Fill(tab);
                return tab;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fallo en el programa, ha saltado excepción...");
                DataTable tab1 = new DataTable();
                return tab1;
            }
            finally
            {
                sqlconn.Close();
            }
        }
    }
}
