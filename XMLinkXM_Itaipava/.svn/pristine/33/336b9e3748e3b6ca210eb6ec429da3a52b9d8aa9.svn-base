<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatoriosLog.aspx.vb" Inherits="Relatorios_RelatoriosLog" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class='Filtro'>
        <asp:UpdatePanel runat='server' ID='updFiltro'>
            <ContentTemplate>
                <div class='FiltroItem'>
                    Relat&oacute;rio
                    <asp:DropDownList runat='server' ID='cboRelatorio' AutoPostBack='true'>
                        <asp:ListItem value="performancelog">Performance</asp:ListItem> 
                        <asp:ListItem value="monitoramentolog">Monitoramento</asp:ListItem> 
                    </asp:DropDownList>
                </div> 
                <div class='FiltroItem' runat='server' id='divRegional' style="padding-left:5px;">
                    Regional:
                    <br />
	                <asp:DropDownList AutoPostBack=true runat='server' ID='cboRegional' DataTextField='Regional' DataValueField='IDRegional'></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' id='divEmpresa' visible=false style="padding-left:5px;">
                    Empresa
                    <br />
	                <asp:DropDownList runat='server' ID='cboEmpresa' DataTextField='Empresa' DataValueField='IDEmpresa'></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' id='div1' style="padding-left:5px;">
                    Veículo
                    <br />
	                <asp:DropDownList runat='server' ID='cboVeiculo' DataTextField='Veiculo' DataValueField='Placa'></asp:DropDownList>
                </div><br class='cb' />
                <div class='FiltroItem' runat='server' id='divDataInicial' style="padding-left:5px;">
                    De
                    <asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='txtDataInicial' ErrorMessage='Por favor selecione a data inicial' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID='valCompInicio' ControlToValidate='txtDataInicial' ErrorMessage='Data inicial inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
                    <cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                    <br>
                    <asp:TextBox Runat="server" ID="txtDataInicial" MaxLength=10 />
                </div> 
                <div class='FiltroItem' runat='server' id='divDataFinal' style="padding-left:5px;">
                    Até
                    <asp:RequiredFieldValidator Runat="server" ID="valReqFinal" ControlToValidate='txtDataFinal' ErrorMessage='A data final é obrigatória' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID="varCompFinal" ControlToValidate='txtDataFinal' ErrorMessage='Data final inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
                    <asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Intervalo de datas inválido' Display="None" CssClass="TextDefault" Type="Date" Operator="GreaterThanEqual" ControlToCompare='txtDataInicial' />
                    <cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataFinal" Format="dd/MM/yyyy" />
                    <br>
                    <asp:TextBox Runat="server" ID='txtDataFinal' MaxLength=10 />
                </div> 
                <div class='FiltroItem' runat=server id=divStatus>
                    Status
                    <asp:DropDownList runat='server' ID='cboStatus'>
                        <asp:ListItem value="0">Todos</asp:ListItem> 
                        <asp:ListItem value="1">Em Aberto</asp:ListItem> 
                        <asp:ListItem value="2">Em Andamento</asp:ListItem> 
                        <asp:ListItem value="3">Encerrado</asp:ListItem> 
                    </asp:DropDownList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class='FiltroBotao' style="padding-left:5px;">
            <input runat='server' type='button' ID='btnExibir' Class="Botao" Value="Exibir" alt='Exibe o relatório selecionado' />
            <asp:Button runat='server' ID='btnImprimir' Text='Imprimir' CssClass='Botao'  />
        </div> 
        <asp:Literal runat="server" ID="ltImprimir" Text=""></asp:Literal>
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
			<li>
				<b>OBS: </b>Se você deseja criar relatórios personalizados, basta exportar os 
				dados para o seu computador. </li>
		</ul>
	</div> 
</asp:Content>

