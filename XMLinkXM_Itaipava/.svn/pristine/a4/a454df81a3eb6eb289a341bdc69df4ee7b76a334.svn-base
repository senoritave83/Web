<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FarolDesVendedor.aspx.vb" Inherits="Enquetes_FarolDesVendedor" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
                <uc1:Filtro ID="Filtro1" runat="server" PermitirTodasEmpresas="false" ShowPesquisas="1" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
                    ShowDataInicial="true" ShowDataFinal="true" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
	    </ContentTemplate>
	</asp:UpdatePanel> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat="server" ID="grdFarolDesempenhoEnquetes" AutoGenerateColumns="false" AllowSorting="true">
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Data da Coleta">
                            <ItemTemplate>
                                <a href="faroldesvendedordet.aspx?e=<%#Container.DataItem.Item("IdEnquete")%>&ie=<%#Container.DataItem.Item("IdEmpresa")%>&s=<%#Container.DataItem.Item("IdSupervisor")%>&v=<%#Container.DataItem.Item("IdVendedor")%>&dt=<%#Container.DataItem.Item("DataColeta")%>&f=<%=Filtro1.IdGerente & "|_|" & Filtro1.IdSupervisor & "|_|" & Filtro1.IdVendedor & "|_|" & Filtro1.DataInicial & "|_|" & Filtro1.DataFinal%>"><%#FormatDateTime(Container.DataItem.Item("DataColeta"),DateFormat.ShortDate)%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Supervisor" HeaderText="Supervisor"  SortExpression="Supervisor"  />
                        <asp:BoundField DataField="Vendedor" HeaderText="Vendedor"  SortExpression="Vendedor"  />
                    </Columns>
                </asp:GridView>
			</ContentTemplate>
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes' runat="server" id="divAreaBotoes">
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div class='AreaAjuda' runat="server" id="divAreaAjuda">
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

