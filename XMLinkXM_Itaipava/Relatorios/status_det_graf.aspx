<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="status_det_graf.aspx.vb" Inherits="Relatorios_status_det_graf" %>

<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat='server' />
    <uc1:Filtro ID="Filtro1" runat="server" ShowDias='false' ShowGerenteVendas='false' ShowVendedor='false' ShowMapa='false'
                    ShowStatus='false' ShowCodigoCliente="false" ShowNomeCliente="false" ShowStatusVisita="false" 
                    StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
    <div class='ListArea'>
        <asp:Chart ID="Chart1" runat="server" Width="844px" Height="500px">
            <Legends>  
                <asp:Legend   
                    Name="Legend1"  
                    BackColor="AliceBlue"  
                    ForeColor="CadetBlue"  
                    BorderColor="LightBlue"  
                    Docking="Right"  
                    >  
                </asp:Legend>
            </Legends>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
	</div>
    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

