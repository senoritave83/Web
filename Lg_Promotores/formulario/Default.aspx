<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="formulario_Default" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server' />
                <div class='Filtro'>
                    <div class='FiltroItem'>Filtrar por<br>
                        <asp:TextBox Runat="server" ID='txtFiltro'/>
                    </div> 
                    <div class='FiltroItem'>Lider<br>
                        <asp:DropDownList runat="server" ID="cboIDLider" DataTextField="Lider" DataValueField="IDLider" />
                    </div>
                    <div class='FiltroLetras'>
                        <uc2:Letras ID="Letras1" runat="server" />
                    </div>
                    <div class='FiltroBotao'>
                        <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
                    </div>
                </div>	
	            <div class='ListArea'>
		            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
				            <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' DataKeyNames='IDPromotor' AllowSorting="true">
				                <HeaderStyle HorizontalAlign='Left' />
					            <columns>
					                <asp:HyperLinkField HeaderText='Promotor' DataTextField='Promotor' DataNavigateUrlFields='IDPromotor' NavigateUrl='roteiro.aspx?idpromotor={0}' DataNavigateUrlFormatString='roteiro.aspx?idpromotor={0}' SortExpression="Promotor" /> 
						            <asp:BoundField HeaderText='<%$Settings: caption, Promotor.FiltroCoordenador, "Coordenador" %>' DataField="Coordenador" SortExpression="Coordenador" />
						            <asp:BoundField HeaderText='<%$Settings: caption, Promotor.FiltroLider, "Lider" %>' DataField="Lider" SortExpression="Lider" />
						            <asp:BoundField HeaderText="Login" DataField="Login" SortExpression="Login" />
						            <asp:BoundField HeaderText="CPF" DataField="CPF" SortExpression="CPF" />
						            <asp:BoundField HeaderText="UF" DataField="UF" SortExpression="UF" />
						            <asp:BoundField HeaderText="regi&atilde;o" DataField="Regiao" SortExpression="Regiao" />
						            <asp:BoundField HeaderText="Tipo" DataField="Teste" SortExpression="Teste" />
					            </columns>
					            <EmptyDataTemplate>
					                <div class='divEmptyRow'>
					                    N&atilde;o h&aacute; Promotores com o Filtro selecionado!
					                </div>
					            </EmptyDataTemplate>
				            </asp:GridView>
                            <uc1:Paginate ID="Paginate1" runat="server" />
			            </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
                        </Triggers> 
                    </asp:UpdatePanel>		
	            </div>
</asp:Content>

