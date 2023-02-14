<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="formulario_Default" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<%@ Register src="../controls/FiltroSuperior.ascx" tagname="FiltroSuperior" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <div class='Filtro'>
                    <div class='FiltroItem'>Filtrar por<br>
                        <asp:TextBox Runat="server" ID='txtFiltro'/>
                    </div> 
                    <uc1:FiltroSuperior ID="FiltroSuperior1" runat="server" />
                    <div class='FiltroLetras'>
                        <xm:Letras ID="Letras1" runat="server" />
                    </div>
                    <div class='FiltroBotao'>
                        <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
                    </div>
                </div>	
	            <div class='ListArea'  style="margin-left:10px; margin-right:10px; width:80%\9;">
		            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <div>
				            <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' DataKeyNames='IDUsuario' AllowSorting="true" CellPadding="5" CellSpacing="1" style="width:100%;">
				                <HeaderStyle HorizontalAlign='Left' />
					            <columns>
					                <asp:HyperLinkField HeaderText='Usuário' DataTextField='Usuario' DataNavigateUrlFields='IDUsuario' NavigateUrl='roteiro.aspx?idpromotor={0}' DataNavigateUrlFormatString='roteiro.aspx?idpromotor={0}' SortExpression="Usuario" /> 
						            <asp:BoundField HeaderText="Login" DataField="Login" SortExpression="Login" />
						            <asp:BoundField HeaderText="CPF" DataField="CPF" SortExpression="CPF" />
						            <asp:BoundField HeaderText="UF" DataField="UF" SortExpression="UF" />
						            <asp:BoundField HeaderText="Tipo" DataField="Teste" SortExpression="Teste" />
					            </columns>
					            <EmptyDataTemplate>
					                <div class='divEmptyRow'>
					                    N&atilde;o h&aacute; Promotores com o Filtro selecionado!
					                </div>
					            </EmptyDataTemplate>
				            </asp:GridView>
				         </div>   
                            <xm:Paginate ID="Paginate1" runat="server" />
			            </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
                        </Triggers> 
                    </asp:UpdatePanel>		
	            </div>
</asp:Content>

