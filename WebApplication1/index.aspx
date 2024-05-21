<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GableWeb.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles/index.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row align-content-center" style="text-align: center;">
            <asp:HyperLink id="most_sold" Text="Más vendidos" NavigateUrl="#sec1" CssClass="col-xs-12 col-sm-4 py-2 btn-sugerencias" runat="server"/>
            <asp:HyperLink id="most_valued" Text="Mejor valorados" NavigateUrl="#sec2" CssClass="col-xs-12 col-sm-4 py-2 btn-sugerencias" runat="server"/>
            <asp:HyperLink id="recommended" Text="Recomendados" NavigateUrl="#sec3" CssClass="col-xs-12 col-sm-4 py-2 btn-sugerencias" runat="server"/>
        </div>
    </div>
    
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-1" style="background-color:#e0e0e0!important"></div>
            <div class="col-xs-12 col-sm-10" style="background-color:white; border-left: 1px solid #75777d!important; border-right: 1px solid #75777d!important;">
              <section id="sec1">
                <br />
                <h2>MAS VENDIDOS</h2>
                <asp:DataList ID="gv1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="2" Width="100%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div class="card btn-outline-dark" style="width: 18rem;">
                            <asp:ImageButton CssClass="card-img-top w-100" runat="server" CommandArgument='<%#Eval("id_producto") %>' style="height: 200px; width: 200px;" ImageUrl='<%# Eval("imagen") %>' />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("nombre") %></h5>
                                <p class="card-text"><strong><%# Eval("precio") %>€</strong></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </section>
                <section id="sec2">
                    <br />
                    <h2>MEJOR VALORADOS</h2>
                    <asp:DataList ID="gv3" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="2" Width="100%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="card btn-outline-dark" style="width: 18rem;">
                                <asp:ImageButton CssClass="card-img-top w-100" runat="server" CommandArgument='<%#Eval("id_producto") %>' style="height: 200px; width: 200px;" ImageUrl='<%# Eval("imagen") %>' />
                                    <div class="card-body">
                                     <h5 class="card-title"><%#Eval("nombre") %></h5>
                                        <p class="card-text"><strong><%#Eval("precio") %>€</strong></p>
                                    </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </section>
                <section id="sec3">
                    <br />
                    <h2>RECOMENDADOS</h2>
                    <asp:DataList ID="gv2" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="2" Width="100%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="card btn-outline-dark" style="width: 18rem;">
                                <asp:ImageButton CssClass="card-img-top w-100" runat="server" CommandArgument='<%#Eval("id_producto") %>' style="height: 200px; width: 200px;" ImageUrl='<%# Eval("imagen") %>' />
                                    <div class="card-body">
                                     <h5 class="card-title"><%#Eval("nombre") %></h5>
                                        <p class="card-text"><strong><%#Eval("precio") %>€</strong></p>
                                    </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </section>
            </div>
            <div class="col-sm-1" style="background-color:#e0e0e0!important"></div>
        </div> 
    </div>
</asp:Content>