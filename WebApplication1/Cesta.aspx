<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cesta.aspx.cs" Inherits="GableWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles/index.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-0 col-sm-1" style="background-color:#e0e0e0!important"></div>
            <div class="col-12 col-sm-10" style="background-color:white; border-left: 1px solid #75777d!important; border-right: 1px solid #75777d!important;">
                <div class="container-fluid px-5 py-5" style="min-height: 80vh!important;">
                    <div class="row">
                        <div class="col-12 col-lg-8 px-0 px-lg-2">
                            <div class="row">
                                <div class="col-6 font-weight-bold text-left" style="color: #5e5e5e!important;">ARTÍCULO</div>
                                <div class="col-2 font-weight-bold text-center" style="color: #5e5e5e!important;">PRECIO</div>
                                <div class="col-2 font-weight-bold text-center" style="color: #5e5e5e!important;">UNIDADES</div>
                                <div class="col-2 font-weight-bold text-center" style="color: #5e5e5e!important;">TOTAL</div>
                            </div>
                            <!-- Producto 1 -->
                            <div class="row py-3 align-items-center">
                                <div class="col-2"><asp:ImageButton id="game_img" runat="server" ImageUrl="src/adidasForum.png" Height="187.5" Width="150"/></div>
                                <div class="col-4 font-weight-bold" style="color: black; text-align:right; padding-right: 20px;">Nike Dunk Low gris</div>
                                <div class="col-2" style="color: #5e5e5e!important; text-align:center;">179,98€</div>
                                <div class="col-2" style="color: #5e5e5e!important; text-align:center;">x2</div>
                                <div class="col-2" style="color: #5e5e5e!important; text-align:center;">359,96€</div>
                            </div>
                            <!-- Producto 2 -->
                            <div class="row py-3 align-items-center">
                                <div class="col-2"><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="src/adidasForum.png" Height="150" Width="150"/></div>
                                <div class="col-4 font-weight-bold" style="color: black; text-align:right; padding-right: 20px;">Nike Air Force 1 blancas</div>
                                <div class="col-2" style="color: #5e5e5e!important; text-align:center;">110,98€</div>
                                <div class="col-2" style="color: #5e5e5e!important; text-align:center;">x1</div>
                                <div class="col-2" style="color: #5e5e5e!important; text-align:center;">110,98€</div>
                            </div>
                        </div>
                        <div class="col-12 col-lg-4 leftborder-lg pl-0 pl-lg-5 pt-3 pt-lg-0">
                            <div class="row">
                                <div class="col-4 col-lg-12 px-0"></div>
                            </div>
                        </div>
                    </div>
                    <hr style="border-top: 1px solid #000; margin-top: 20px;"/>
                    <div class="row">
                        <div class="col-12 text-right">
                            <asp:Button id="btnLogout"  runat="server" Text="Realizar pedido" CssClass="btn btn-block btn-order"></asp:Button>
                            <p class="h4 font-weight-bold" style="color:black!important;">TOTAL: <span id="total_price" style="color:#5e5e5e!important;">470,94€</span></p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-0 col-sm-1" style="background-color:#e0e0e0!important"></div>
        </div> 
    </div>
</asp:Content>
