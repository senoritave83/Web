<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Relatorios.aspx.vb" Inherits="Relatorios_Relatorios" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <script language="javascript" type="text/javascript">
    function fncExibir()
	{
	
        var vDataInicial = document.getElementById("<%= txtDataInicial.ClientID%>");
        var vDataFinal = document.getElementById("<%= txtDataFinal.ClientID%>");
	    var vTipo = document.getElementById("<%= cboRelatorio.ClientID%>");
	
		if (isDate(vDataInicial.value) == false){
	        alert("Por favor preencha a data inicial do periodo desejado!");
	        vDataInicial.focus();
	        return false;
	    }
		if (isDate(vDataFinal.value) == false){
	        alert("Por favor preencha a data final do periodo desejado!");
	        vDataFinal.focus();
	        return false;
	    }
	
		var vUrl = vTipo[vTipo.selectedIndex].value + '_det.aspx?' + 
				'&di=' + vDataInicial.value + 
				'&df=' + vDataFinal.value;
	
		var frame = document.getElementById("<%=frmRelatorio.clientID %>")
		
		frame.src = vUrl;
	}
	</script>
    <div class='Filtro'>
        <div class='FiltroItem'>
            Relat&oacute;rio
            <asp:DropDownList runat='server' ID='cboRelatorio'>
                <asp:ListItem Value='status' Selected='True'>Pedidos por Status</asp:ListItem> 
                <asp:ListItem value="vendedor">Vendas por Vendedor</asp:ListItem> 
                <asp:ListItem value="produtos">Velocidade de Vendas</asp:ListItem> 
            </asp:DropDownList>
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
            <asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Intervalo de datas inválido' Display="None" CssClass="TextDefault" Type="Date" Operator="GreaterThan" ControlToCompare='txtDataInicial' />
            <br>
            <asp:TextBox Runat="server" ID='txtDataFinal' MaxLength=10 />
        </div> 
        <div class='FiltroBotao'>
            <input runat='server' type='button' ID='btnExibir' Class="Botao" Value="Exibir" alt='Exibe o relatório selecionado' />
        </div> 
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <asp:UpdatePanel runat='server' ID='updFrame'>
        <ContentTemplate>
            <iframe id='frmRelatorio' frameborder='0' width='100%' runat='server' />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID='btnExibir' EventName='ServerClick' />
        </Triggers>
    </asp:UpdatePanel>
    <div class='AreaAjuda'>
		<ul class='TextDefault'>
			<li>
				<b>Exibir:</b> Exibe o relatório de acordo com o período selecionado pelo operador.</li>
			<li>
				<b>OBS: </b>Se você deseja criar relatórios personalizados, basta exportar os 
				dados para o seu computador. </li>
		</ul>
	</div> 
</asp:Content>

