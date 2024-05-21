using library;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace GableWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMostSold2();
                getBetteReviewed2();
                getRecommended2();
               // BindData();
            }
        }



        private void getRecommended2()
        {
            try
            {

                ENProductos p = new ENProductos();
                DataTable tab = p.getRecommended();

                string debugInfo = "";
                foreach (DataRow row in tab.Rows)
                {
                    debugInfo += $"ID: {row["id_producto"]}, Name: {row["nombre"]}, Price: {row["precio"]}<br />";
                }

                gv2.DataSource = tab;
                gv2.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error in getMostSold2: " + ex.Message);
            }
        }

        private void getMostSold2()
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("Entering getMostSold2");

                ENProductos p = new ENProductos();
                DataTable tab = p.getMostSold();

                System.Diagnostics.Trace.WriteLine("Data fetched in getMostSold2. Rows count: " + tab.Rows.Count);
                foreach (DataRow row in tab.Rows)
                {
                    System.Diagnostics.Trace.WriteLine($"ID: {row["id_producto"]}, Name: {row["nombre"]}, Price: {row["precio"]}");
                }

                gv1.DataSource = tab;
                gv1.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error in getMostSold2: " + ex.Message);
            }
        }

        private void getBetteReviewed2()
        {
            try
            {

                ENProductos p = new ENProductos();
                DataTable tab = p.getBetterReviewed();

                string debugInfo = "";
                foreach (DataRow row in tab.Rows)
                {
                    debugInfo += $"ID: {row["id_producto"]}, Name: {row["nombre"]}, Price: {row["precio"]}<br />";
                }

                gv3.DataSource = tab;
                gv3.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error in getMostSold2: " + ex.Message);
            }
        }

        protected void click_productos(object sender, CommandEventArgs e)
        {
            Response.Redirect("Productos.aspx?id_prod=" + e.CommandArgument);
        }

        protected void img_prueba(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}
