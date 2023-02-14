<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Exportar.aspx.vb" Inherits="Relatorios_Exportar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class='Filtro'>
		<div class='FiltroItem'>Data<br/>
		    <div style="width:200px">
	            <asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='txtDataIni' ErrorMessage='Por favor selecione a data inicial' Display="None" CssClass="TextDefault" />
	            <asp:CompareValidator Runat="server" ID='valCompInicio' ControlToValidate='txtDataIni' ErrorMessage='Data inicial inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
				<asp:TextBox runat='server' ID='txtDataIni' MaxLength="10" Width='75px' />				
                <ajaxToolkit:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataIni" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		        até
                <asp:RequiredFieldValidator Runat="server" ID="valReqFinal" ControlToValidate='txtDataFin' ErrorMessage='A data final é obrigatória' Display="None" CssClass="TextDefault" />
                <asp:CompareValidator Runat="server" ID="varCompFinal" ControlToValidate='txtDataFin' ErrorMessage='Data final inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
                <asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFin' ErrorMessage='Intervalo de datas inválido' Display="None" CssClass="TextDefault" Type="Date" Operator="GreaterThan" ControlToCompare='txtDataIni' />           
               <asp:TextBox runat='server' ID='txtDataFin' MaxLength="10" Width='75px' />
                <ajaxToolkit:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFin" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		    </div>
		</div>
		<div class='FiltroItem'>Tipo<br/>
		    <asp:DropDownList runat="server" ID="cboIDTipoPedido">
		        <asp:ListItem Value='0'>Todos</asp:ListItem>
		        <asp:ListItem Value='1'>Pedidos Normais</asp:ListItem>
		        <asp:ListItem Value='2'>Consignados</asp:ListItem>
		    </asp:DropDownList>
		</div>
		<div class='FiltroBotao'>
			<asp:Button runat='server' ID='btnExportar' Text='Exportar' />
		</div><br /><br /><br />status
		<div class='FiltroItem'>Vendedores<br/>
		    <asp:ListBox runat="server" ID="lstVendedores" SelectionMode="Multiple" Rows="6" DataTextField="Vendedor" DataValueField="IDVendedor" AutoPostBack="true" />
		</div>
		<div class='FiltroItem'>Clientes<br/>
		    <asp:ListBox runat="server" ID="lstClientes" SelectionMode="Multiple" Rows="6" DataTextField="Cliente" DataValueField="IDCliente" />
		</div>
		<div class='FiltroItem'>Status<br/>
		    <asp:ListBox runat="server" ID="lstStatus" SelectionMode="Multiple" Rows="6" DataTextField="Status" DataValueField="IDStatus" />
		</div>
		<div class='FiltroItem'>Categorias<br/>
		    <asp:ListBox runat="server" ID="lstCategorias" SelectionMode="Multiple" Rows="6" DataTextField="Categoria" DataValueField="IDCategoria" AutoPostBack="true" />
		</div>
		<div class='FiltroItem'>Produtos<br/>
		    <asp:ListBox runat="server" ID="lstProdutos" SelectionMode="Multiple" Rows="6" DataTextField="Produto" DataValueField="IDProduto" />
		</div>
	</div>	
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
		<ul class='TextDefault'>
			<li>
				<b>Exportar:</b>Gera arquivo de acordo com o período e filtros selecionados pelo operador.</li>
			<li>
				<b>OBS: </b>O Relatório será gerado em formato Excel (xls). </li>
		</ul>
	</div> 
</asp:Content>
