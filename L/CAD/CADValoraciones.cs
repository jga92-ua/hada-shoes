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
    class CADValoraciones
    {
        private string constring;


        public CADValoraciones()
        {
            constring = ConfigurationManager.ConnectionStrings["Database1"].ToString();

        }

        public bool createValoraciones(ENValoraciones en)
        {
            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();

                if (exist(en, con))
                {
                    Console.WriteLine("Assessment operation failed. Error: Assessment already exist");
                    throw new Exception("ERROR: Ya hay una valoración del usuario sobre el mismo producto");
                }

                string query = "Insert into valoracion (usuario ,producto, texto, puntuación,estrella) values ('" + en.usuaro_id + "','" + en.producto_id + "','" + en.tex_val + "','" + en.pun_val + "'," + en.estr_val + "')";
                //  string query = "Insert into valoracion (usuario, producto, texto, puntuacion,estrella) values (" +en.usuaro_id+ "," +en.producto_id+ "," +en.tex_val+ ","+ en.pun_val+ "," +en.estr_val+ "')";
                SqlDataAdapter data = new SqlDataAdapter();
                data.InsertCommand = new SqlCommand(query, con);
                data.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Assessment operation failed. Error:{0}", ex.Message);
                throw new Exception("Assessment operation failed. Error: " + ex.Message);

            }
            finally
            {
                if (con != null) con.Close();
            }

            return true;
        }

        public bool readValoraciones(ENValoraciones en)
        {
            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();

                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand("Select usuario, texto, puntuación, estrella from valoracion where producto='" + en.producto_id + "'and usuario='" + en.usuaro_id + "'", con);
                SqlDataReader reader = data.SelectCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    en.usuaro_id = reader.GetString(0);
                    en.tex_val = reader.GetString(1);
                    en.pun_val = reader.GetInt32(2);
                    en.estr_val = reader.GetString(3);
                }
                else
                {
                    Console.WriteLine("Assessment operation failed. Error:Cant found the id");
                    throw new Exception("ERROR: Valoracion no encontrada ");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Assessment operation failed. Error:{0}", ex.Message);
                throw new Exception("Assessment operation failed. Error: " + ex.Message);

            }
            finally
            {
                if (con != null) con.Close();
            }


            return true;
        }

        internal DataTable getValo()
        {
            throw new NotImplementedException();
        }


        public bool readAuxValoraciones(ENValoraciones en)
        {

            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();

                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = new SqlCommand("Select usuario, texto, puntuación from valoracion where producto='" + en.producto_id + "'", con);
                SqlDataReader reader = data.SelectCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    en.usuaro_id = reader.GetString(0);
                    en.tex_val = reader.GetString(1);
                    en.pun_val = reader.GetInt32(2);
                }
                else
                {
                    Console.WriteLine("Assessment operation failed. Error:Cant found the id");
                    throw new Exception("ERROR: Valoracion no encontrada ");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Assessment operation failed. Error:{0}", ex.Message);
                throw new Exception("Assessment operation failed. Error: " + ex.Message);

            }
            finally
            {
                if (con != null) con.Close();
            }


            return true;
        }


        public bool deleteValoraciones(ENValoraciones en)
        {

            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();
                if (!exist(en, con))
                {
                    Console.WriteLine("Assessment operation failed. Error: Assessment already exist");
                    throw new Exception("ERROR: Ya hay una valoracion con el mismo id");
                }
                SqlDataAdapter data = new SqlDataAdapter();
                data.DeleteCommand = new SqlCommand("Delete valoracion where producto='" + en.producto_id + "'and usuario=" + en.usuaro_id + "'", con);
                data.DeleteCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Assessment operation failed. Error:{0}", ex.Message);
                throw new Exception("Assessment operation failed. Error: " + ex.Message);
            }
            finally
            {
                if (con != null) con.Close();
            }


            return true;
        }

        public bool updateValoraciones(ENValoraciones en)
        {

            SqlConnection con = new SqlConnection(constring);

            try
            {
                con.Open();
                if (!exist(en, con))
                {
                    Console.WriteLine("Assessment operation failed. Error: Assessment already exist");
                    throw new Exception("ERROR: Ya hay una valoracion con el mismo id");
                }
                SqlDataAdapter data = new SqlDataAdapter();
                data.UpdateCommand = new SqlCommand("Update valoracion set texto='" + en.tex_val + "',puntuacion=" + en.pun_val + "' where producto= " + en.producto_id + "'and usuario=" + en.usuaro_id + "'", con);
                data.UpdateCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Assessment operation failed. Error:{0}", ex.Message);
                throw new Exception("Assessment operation failed. Error: " + ex.Message);
            }
            finally
            {
                if (con != null) con.Close();
            }


            return true;
        }


        private bool exist(ENValoraciones en, SqlConnection con)
        {
            SqlDataAdapter data = new SqlDataAdapter();
            data.SelectCommand = new SqlCommand("Select * from valoracion where usuario='" + en.usuaro_id + "'and producto =" + en.producto_id, con);
            int i = data.SelectCommand.ExecuteNonQuery();
            return (null != data.SelectCommand.ExecuteScalar());
        }


        public DataTable showValo(ENValoraciones en)
        {
            SqlConnection con = new SqlConnection(constring);

            con.Open();
            try
            {

                string sqlquery = "select (select nombre from usuario where dni= v.usuario) as nombre,texto,estrella from valoracion v where producto='" + en.producto_id + "'";
                SqlCommand command = new SqlCommand(sqlquery, con);
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                DataTable tab = new DataTable();
                sqlda.Fill(tab);
                return tab;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Assessment operation failed. Error:{0}", ex.Message);
                throw new Exception("Assessment operation failed. Error: " + ex.Message);
            }
            finally
            {
                if (con != null) con.Close();
            }

        }

    }
}
