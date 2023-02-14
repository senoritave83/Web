<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="relatorio_roteiro.aspx.vb" Inherits="Relatorios_relatorio_roteiro" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class='Filtro'>
        <div class='FiltroItem' runat='server' id='divEmpresa'>
            Empresa
            <br />
			<asp:DropDownList runat='server' ID='cboEmpresa' DataTextField='Empresa' DataValueField='IDEmpresa'></asp:DropDownList>
        </div>
        <div class='FiltroItem'>
            Vendedor
            <br />
			<asp:DropDownList runat='server' ID='cboVendedor' DataTextField='Vendedor' DataValueField='IDVendedor'></asp:DropDownList>
        </div>
        <div class='FiltroItem'>
	        De
	        <asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='txtDataInicial' ErrorMessage='Por favor selecione a data inicial' Display="None" CssClass="TextDefault" />
	        <asp:CompareValidator Runat="server" ID='valCompInicio' ControlToValidate='txtDataInicial' ErrorMessage='Data inicial inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
	        <br>
	        <asp:TextBox Runat="server" ID="txtDataInicial" MaxLength=10 />
        </div> 
        <div class='FiltroItem'>
            Até
            <asp:RequiredFieldValidator Runat="server" ID="valReqFinal" ControlToValidate='txtDataFinal' ErrorMessage='A data final é obrigatória' Display="None" CssClass="TextDefault" />
            <asp:CompareValidator Runat="server" ID="varCompFinal" ControlToValidate='txtDataFinal' ErrorMessage='Data final inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
            <asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Intervalo de datas inválido' Display="None" CssClass="TextDefault" Type="Date" Operator="GreaterThanEqual" ControlToCompare='txtDataInicial' />
            <br>
            <asp:TextBox Runat="server" ID='txtDataFinal' MaxLength=10 />
        </div> 
        <div class='FiltroBotao'>
            <input runat='server' type='button' ID='btnExibir' Class="Botao" Value="Exibir" alt='Exibe o relatório selecionado' />
			<asp:Button runat='server' ID='btnExportar' Text='Exportar' CssClass='Botao'  />
			<asp:Button runat='server' ID='btnImprimir' Text='Imprimir' CssClass='Botao'  />
        </div> 
    </div>
    <iframe id='frmRelatorio' frameborder='0' width='100%' runat='server' height='60%' />
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
		<ul class='TextDefault'>
			<li>
				<b>Exibir:</b> Exibe o relatório de acordo com o período selecionado pelo operador.</li>
		</ul>
	</div> 
</asp:Content>

