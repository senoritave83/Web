<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Relatorios.aspx.vb" Inherits="Relatorios_Relatorios" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat='server' ID='updFiltro'>
        <ContentTemplate>
            <div class='Filtro'>
                <div class='FiltroItem'>
                    Relat&oacute;rio
                    <asp:DropDownList runat='server' ID='cboRelatorio' AutoPostBack='true'>
                        <asp:ListItem Value='status' Selected='True'>Pedidos por Status</asp:ListItem> 
                        <asp:ListItem value="vendedor">Vendas por Vendedor</asp:ListItem> 
                        <asp:ListItem value="produtos">Velocidade de Vendas</asp:ListItem> 
                        <asp:ListItem value="performance">Performance do Vendedor</asp:ListItem> 
                        <asp:ListItem value="Consolidado">Volume de Vendas</asp:ListItem> 
                        <asp:ListItem value="Justificado">Relatório de Justificativas</asp:ListItem> 
                        <asp:ListItem value="Positivacao">Relatório de Positivação</asp:ListItem> 
                        <asp:ListItem value="AcompPositivacao">Eficiência de Visitas</asp:ListItem> 
                        <asp:ListItem value="Relatorio_Roteiro">Roteiros</asp:ListItem>
                        <asp:ListItem value="Pedidos">Listagem de Pedidos</asp:ListItem>
                        <asp:ListItem value="Historico_Visitas">Histórico de Visitas ao Cliente</asp:ListItem>
                    </asp:DropDownList>
                </div> 
                <div class='FiltroItem' runat='server' id='divEmpresa' style="padding-left:5px;">
                    Empresa
                    <br />
	                <asp:DropDownList runat='server' ID='cboEmpresa' DataTextField='Empresa' DataValueField='IDEmpresa'></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' id='divIDCliente' visible='false' style="padding-left:5px;">
                    Código do Cliente
                    <br>
                    <asp:TextBox Runat="server" ID='txtIDCliente' MaxLength='20' />
                </div>
                <div class='FiltroItem' runat='server' id='divNomeCliente' visible='false' style="padding-left:5px;">
                    Nome do Cliente
                    <br>
                    <asp:TextBox Runat="server" ID='txtNomeCliente' MaxLength='50' />
                </div>
                <div class='FiltroItem' ID='divStatusVisita' runat='server' visible='false' style="padding-left:5px;">
                    Status da Visita<br />
		            <asp:DropDownList AutoPostBack='false' runat='server' ID='cboStatusVisita' DataTextField='Justificativa' DataValueField='IDjustificativa'></asp:DropDownList>
		        </div>
                <div class='FiltroItem' runat='server' id='divGerenteVendas' visible='false' style="padding-left:5px;">
                    Gerente de Vendas
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboGerenteVendas' DataTextField='GerenteVendas' DataValueField='IdGerenteVendas'></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' id='divSupervisor' style="padding-left:5px;">
                    Supervisor
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboSupervisor' DataTextField='Supervisor' DataValueField='IDSupervisor'></asp:DropDownList>
                </div>
                 <div class='FiltroItem' runat='server' id='divVendedor' visible='false' style="padding-left:5px;">
                    Vendedor
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboVendedor' DataTextField='Vendedor' DataValueField='IdVendedor'></asp:DropDownList>
                </div>
                <div class='FiltroItem' ID='divStatus' runat='server' visible='false' style="padding-left:5px;">
                    Status<br />
		            <asp:DropDownList AutoPostBack='false' runat='server' ID='cboStatus' DataTextField='Status' DataValueField='IdStatus'></asp:DropDownList>
		        </div>
                <div class='FiltroItem' runat='server' id='divDataInicial' style="padding-left:5px;">
                    <asp:label runat='server' ID='lblData' Text='De' />
                    <asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='txtDataInicial' ErrorMessage='Por favor selecione a data inicial' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID='valCompInicio' ControlToValidate='txtDataInicial' ErrorMessage='Data inicial inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
                    <cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                    <br />
                    <asp:TextBox Runat="server" ID="txtDataInicial" MaxLength='10' />
                </div> 
                <div class='FiltroItem' runat='server' id='divDataFinal' style="padding-left:5px;">
                    Até
                    <asp:RequiredFieldValidator Runat="server" ID="valReqFinal" ControlToValidate='txtDataFinal' ErrorMessage='A data final é obrigatória' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID="varCompFinal" ControlToValidate='txtDataFinal' ErrorMessage='Data final inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
                    <asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Intervalo de datas inválido' Display="None" CssClass="TextDefault" Type="Date" Operator="GreaterThanEqual" ControlToCompare='txtDataInicial' />
                    <cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataFinal" Format="dd/MM/yyyy" />
                    <br>
                    <asp:TextBox Runat="server" ID='txtDataFinal' MaxLength='10' />
                </div> 
                <div class='FiltroItem' runat='server' id='divDias' visible='false' style="padding-left:5px;">
                    Dias sem pedido
                    <asp:RequiredFieldValidator Runat="server" ID="RequiredFieldValidator1" ControlToValidate='txtDias' ErrorMessage='O Campo Dias é obrigatório' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID="Comparevalidator3" ControlToValidate='txtDias' ErrorMessage='Valor incorreto' Display="None" CssClass="TextDefault" Type="Integer" Operator="DataTypeCheck"  />
                    <asp:CompareValidator Runat="server" ID="Comparevalidator2" ControlToValidate='txtDias' ErrorMessage='Valor incorreto' Display="None" CssClass="TextDefault" Type="Integer" ValueToCompare="0" Operator="GreaterThan"  />
                    <br>
                    <asp:TextBox Runat="server" ID='txtDias' MaxLength='4' />
                </div>
                <div class='FiltroItem' ID='divMapa' runat='server' visible='false'>
                    Exibir Mapa<br />
		            <asp:CheckBox runat='server' ID='chkMapa' />
		        </div>
                <div class='FiltroBotao' style="padding-left:5px;">
                    <input runat='server' type='button' ID='btnExibir' Class="Botao" Value="Exibir" alt='Exibe o relatório selecionado' />
                    <input type='button' ID='btnImprimir' Value='Imprimir' Class='Botao' onclick='javascript:fncPrint()'  />
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
			        <li>
				        <b>OBS: </b>Se você deseja criar relatórios personalizados, basta exportar os 
				        dados para o seu computador. </li>
		        </ul>
	        </div> 
            <input type='hidden' id='hidPage' runat='server' value='' />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script language="javascript">
        function fncPrint() {
            var vURL = document.getElementById('<%=hidPage.ClientId %>').value;
            //alert(vURL);
            var wn = window.open(vURL, 'ImprimirRelatorio', 'height=600, width=800, resizable=1, toolbars=1, scrollbars=1')
        }

    </script>
</asp:Content>

