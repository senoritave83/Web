<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="sars.aspx.vb" Inherits="Pages.Pedidos.Sars" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem'>Filtro<br>
		            <asp:TextBox runat='server' ID='txtFiltro' />
		        </div>
		        <div class='FiltroItem'>Vendedor<br>
		            <asp:TextBox runat='server' ID='txtVendedor' />
		        </div>
		        <div class='FiltroItem'>Cliente<br>
		            <asp:TextBox runat='server' ID='txtCliente' />
		        </div>
		        <div class='FiltroItem'>Data<br>
		            <div style="width:200px">
						<asp:TextBox runat='server' ID='txtDataEmissaoInicial' MaxLength="10" Width='75px' />
						<asp:CompareValidator runat='server' SkinID='Data' ID='valCompDataEmissaoInicial' Display='None' ErrorMessage='DataEmissao inicial inv&aacute;lida' ControlToValidate='txtDataEmissaoInicial' Operator='DataTypeCheck' Type='Date' />
		        		at&eacute;
						<asp:TextBox runat='server' ID='txtDataEmissaoFinal' MaxLength="10" Width='75px' />
						<asp:CompareValidator runat='server' SkinID='Data'  ID='valCompDataEmissaoFinal' Display='None' ErrorMessage='DataEmissao final inv&aacute;lida' ControlToValidate='txtDataEmissaoFinal' Operator='DataTypeCheck' Type='Date' />
		            </div>
		        </div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDVisita" DataNavigateUrlFormatString="Sar.aspx?IDVisita={0}" HeaderText="Cod. Cliente" DataTextField="CodigoCliente" SortExpression="CodigoCliente"  />
						<asp:BoundField HeaderText="Nome do Cliente" DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderText="Contato" DataField="Contato" SortExpression="Contato" />
						<asp:BoundField HeaderText="SAR" DataField="Sar" SortExpression="Sar" />
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Visita" DataField="Visita" SortExpression="Visita" />
						<asp:BoundField HeaderText="Enviado" DataField="Enviado" SortExpression="Enviado" />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; SARS com o filtro selecionado!
							</asp:Label>
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

