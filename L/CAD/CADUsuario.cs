using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class CADUsuario
    {
        private string dbd;

        public CADUsuario()
        {
            dbd = ConfigurationManager.ConnectionStrings["Database1"].ToString();

        }

        public bool readUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);

            try
            {
                c.Open();
                String s = "Select * from usuario where dni = '" + en.dni.ToString() + "';";
                SqlCommand comando = new SqlCommand(s, c);
                SqlDataReader data = comando.ExecuteReader();

                if (data.Read())
                {
                    en.nombre = data["nombre"].ToString();
                    en.apellidos = data["apellidos"].ToString();
                    en.dni = data["dni"].ToString();
                    en.email = data["email"].ToString();
                    en.contraseña = data["contraseña"].ToString();
                  
                  
                    if (data["telefono"] != null)
                    {
                        en.tlf = Convert.ToInt32(data["telefono"]);//comprobar
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool readUsuarioEmail(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);

            try
            {
                c.Open();
                String s = "Select * from usuario where email = '" + en.email.ToString() + "';";
                SqlCommand comando = new SqlCommand(s, c);
                SqlDataReader data = comando.ExecuteReader();

                if (data.Read())
                {
                    en.nombre = data["nombre"].ToString();
                    en.apellidos = data["apellidos"].ToString();
                    en.dni = data["dni"].ToString();
                    en.email = data["email"].ToString();
                    en.contraseña = data["contraseña"].ToString();
                    if (data["telefono"] != null)
                    {
                        en.tlf = Convert.ToInt32(data["telefono"]);//comprobar
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool readUsuarioPago(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);

            try
            {
                c.Open();
                String s = "Select * from usuario where dni = '" + en.dni.ToString() + "';";
                SqlCommand comando = new SqlCommand(s, c);
                SqlDataReader data = comando.ExecuteReader();

                if (data.Read())
                {

                    if (data["tarjeta"].ToString() != "0")
                    {
                        en.numTarjeta = Convert.ToInt32(data["tarjeta"]);
                    }
                    else return false;
                    if (data["cvv_tarjeta"].ToString() != "0")
                    {
                        en.cvv = Convert.ToInt32(data["cvv_tarjeta"]);
                    }
                    else return false;
                    if (data["fecha_exp_tarjeta"].ToString() != "")
                    {
                        en.expTarjeta = data["fecha_exp_tarjeta"].ToString();
                    }
                    else return false;
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"EXCEPCION. Error: {0}", e.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }

        public bool deleteUsuario(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from usuario where dni='" + en.dni + "'", c);
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
        public bool createUsuario(ENUsuario en)
        {
            using (SqlConnection c = new SqlConnection(dbd))
            {
                using (SqlCommand comando = new SqlCommand("Insert into usuario(dni, nombre, apellidos, email, telefono, cvv_tarjeta, fecha_exp_tarjeta,tarjeta, contraseña) values('" + en.dni + "', '" + en.nombre + "', '" + en.apellidos + "', '" + en.email + "', " + en.tlf + ", " + en.cvv + ", '" + en.expTarjeta + "', '" + en.fechanac + "','" + en.contraseña + "' )", c))
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

        public bool updateUsuario(ENUsuario en)
        {
            using (SqlConnection c = new SqlConnection(dbd))
            {
                using (SqlCommand comando = new SqlCommand("Update usuario set tarjeta=" + en.numTarjeta + ",fecha_exp_tarjeta='" + en.expTarjeta + "',apellidos='" + en.apellidos + "', nombre='" + en.nombre + "', contraseña='" + en.contraseña + "', email='" + en.email + "',cvv_tarjeta = " + en.cvv + " , telefono = " + en.tlf + " where dni='" + en.dni + "'", c))
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


        public bool deletePedidoFromUsu(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from pedido where usuario='" + en.dni + "'", c);
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

        public bool deleteLinPedFromUsu(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from linPed where usuario='" + en.dni + "'", c);
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

        public bool deleteValUsu(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from valoracion where usuario='" + en.dni + "'", c);
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


        public bool deleteCestaUsu(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from cesta where usuario='" + en.dni + "'", c);
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

        public bool deleteDirEnvioUsu(ENUsuario en)
        {
            SqlConnection c = new SqlConnection(dbd);
            try
            {
                c.Open();
                SqlCommand comando;
                comando = new SqlCommand("Delete from dirEnvio where usuario='" + en.dni + "'", c);
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
    }
}
