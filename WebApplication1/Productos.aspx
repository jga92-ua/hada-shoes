<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="GableWeb.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="styles/Productos.css">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-1" style="background-color:#e0e0e0!important"></div>
            <div class="col-xs-12 col-sm-10" style="background-color:white; border-left: 1px solid #75777d!important; border-right: 1px solid #75777d!important; margin-top: 1px solid #75777d!important;">
               <div class="container-fluid px-5 py-5">
                   <div class="row">
                        <!--Imagen-->

                        <div class="col-xs-12 col-md-6">
                            <img src="src/zapas.png" Height="300" Width="300" />
                        </div>
                       <!--Titulo, precio, descripcion-->
                        <div class="col-xs-12 col-md-6">
                            <h2>Nike Air Max</h2>
                           <div class="form-group precio_elem row">
                               <label class="col-sm-3 form-control-lebel nopaddingtop">
                                   <font style="vertical-align:inherit;">
                                       <font style="vertical-align:inherit">Precio:</font>
                                   </font>
                               </label>
                               <div class="col-sm-8 col-md-9">
                                   <span class="precio-producto font-weight-bold" id="precio-producto">
                                       <font style="vertical-align:inherit;">
                                       <font style="vertical-align:inherit " >5.99</font>
                                        </font>
                                   </span>
                               </div>
                           </div>
                            <div class="form-row">
                                <label for="Cantidad" class="col-sm-3 col-md-3 form-control-label">Cantidad:</label>
                                <div class="col-sm-8 col-md-9">
                                    <input type="number" class="qty form-control" id="input-qty" name="qty" maxlength="5"value="1" />
                                </div>
                            </div>
                            <div class="form-group row visible">
                                <label class="col-sm-3 col-md-3 form-control-label"></label>
                                <div class="col-sm-8 col-sm-offset-3 col-md-9 col-md-offset-3">
                                    <asp:Button id="btnLogout"  runat="server" Text="Añadir al carrito" OnClick="carrito"  CssClass="btn btn-block btn-order" style="text-align:center; background-color:Highlight;border-top: 1px solid #75777d!important;"></asp:Button>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-3 col-md-3 form-control-label">Descripción:</label>
                                <div class="col-sm-8 col-md-9 descripcion">
                                    <p>Zapatillas Deportivas</p>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-3 form-control-label">Marca:</label>
                                <div class="col-sm-9 col-md-9">
                                    <p>Nike</p>
                                </div>
                            </div>
                            <!--Comentarios-->
                            <div class="form-group row">
                            <label class="col-sm-3 col-md-3 form-control-label"></label>
                            <div class="col-sm-8 col-sm-offset-3 col-md-9 col-md-offset-3">
                                
                                <div class="widget-area no-padding blank">
                                    <div class="status-upload">
                                        <form>
                                            <textarea placeholder="Comenta" cols="35"></textarea>
                                             <input type="number" class="qty form-control" id="input-qty" name="qty" maxlength="5"value="1" />
                                            <button type="submit" class="btn btn-success green"><i class="fa fa-share"></i> Comentar</button>
                                        </form>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>
                  
                   </div>
               </div>
            </div>
            <div class="col-sm-1" style="background-color:#e0e0e0!important"></div>
        </div>
    </div>
    
    
</asp:Content>

