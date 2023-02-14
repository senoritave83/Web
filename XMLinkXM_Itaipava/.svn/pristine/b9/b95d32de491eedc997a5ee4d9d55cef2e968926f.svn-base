<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Evolucao_VolPre.aspx.vb" Inherits="Pesquisas_Evolucao_VolPre" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:Filtro ID="Filtro1" runat="server" PermitirTodasPesquisas="false" PermitirTodasEmpresas="false" ShowPesquisas="2" ModoExibicaoGrafico="true" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
            ShowFiltro="false" FiltroSize="300" ShowDataInicial="false" ShowDataFinal="false" StatusClass='FiltroItem'  DataInicialClass='FiltroItem' ></uc1:Filtro>
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