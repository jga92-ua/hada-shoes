using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace GableWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ENCesta cesta;

        protected void Page_Load(object sender, EventArgs e)
        {
            cesta = new ENCesta();
            if (Session["dni"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack && CheckIfSomeItem())
            {
                ShowBasketItems();
            }
        }
    
    private void ShowBasketItems()
        {
         /*   DataTable linCestData = cesta.ShowBasketItems(Session["dni"].ToString());
            itemsCesta.DataSource = linCestData;
            itemsCesta.DataBind();

            double finalPrice = linCestData.Select().Sum(p => Convert.ToDouble(p["TotalPrice"]));
            totalPrice.Text = finalPrice.ToString() + "€";

            itemsCesta.Visible = linCestData.Rows.Count > 0;  */
        }

        protected void ItemQuery(object sender, CommandEventArgs e)
        {
            string[] args = e.CommandArgument.ToString().Split(',');
            int numCesta = -1, linea = -1;
            try
            {
                numCesta = Convert.ToInt32(args[0]);
                linea = Convert.ToInt32(args[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {0}", ex.Message);
            }

            if (CheckIfItemExists(numCesta, linea))
            {
                ENLineaCesta lc = new ENLineaCesta(numCesta, linea);
                switch (e.CommandName)
                {
                    case "RemoveItemFromBasket":
                        if (lc.removeItem())
                            Response.Redirect("Cesta.aspx");
                        break;
                    case "SubstractItemQuantity":
                        if (lc.substrUnit())
                            Response.Redirect("Cesta.aspx");
                        break;
                    case "AddItemQuantity":
                        if (lc.addUnit())
                            Response.Redirect("Cesta.aspx");
                        break;
                }
            }
        }
        protected void ProceedToBuy(object sender, CommandEventArgs e)
            {
                /*int numCesta = 0;
                try {
                    numCesta = Convert.ToInt32(e.CommandArgument.ToString());
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"error: {0}", ex.Message);
                }

                if (Session["dni"] != null)
                {
                    if (CheckIfHaveBuyData(numCesta))
                    {
                        InsertItemsIntoOrders(numCesta);
                        DeleteItemsFromBasket(numCesta);
                        Response.Redirect("index.asp");
                    } else
                    {
                        Response.Redirect("DatosPago.aspx"); // Add data to buy
                    }
                } else
                {
                    Response.Redirect("Login.aspx");
                }*/

                if (Session["dni"] != null)
                {
                    ENUsuario usu = new ENUsuario();
                    usu.dni = Session["dni"].ToString();
                    if (usu.readUsuario() && usu.readUsuarioPago())
                    {
                        ENCesta cest = new ENCesta();
                        int numCest = cest.getBasketByDNI(usu.dni);
                        InsertItemsIntoOrders(numCest);
                        DeleteItemsFromBasket(numCest);
                        Response.Redirect("AreaPersonal_ped.aspx");
                    }
                    else
                    {
                        Response.Redirect("DatosPago.aspx");
                    }


                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

            private void InsertItemsIntoOrders(int numCesta)
            {
                cesta.InsertItemsIntoOrders(numCesta);
            }

            private void DeleteItemsFromBasket(int numCesta)
            {
                cesta.DeleteItemsFromBasket(numCesta);
            }

            private bool CheckIfSomeItem()
            {
                return cesta.CheckIfSomeItem();
            }

            private bool CheckIfItemExists(int numCesta, int linea)
            {
                return cesta.CheckIfItemExists(numCesta, linea);
            }

            private bool CheckIfHaveBuyData(int numCesta)
            {
                ENCesta c = new ENCesta(numCesta);
                return c.CheckIfHaveBuyData(numCesta);
            }
        }
}