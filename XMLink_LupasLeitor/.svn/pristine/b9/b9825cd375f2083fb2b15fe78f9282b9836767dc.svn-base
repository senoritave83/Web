<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Relatorios.aspx.vb" Inherits="Relatorios_Relatorios" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
   <script language="javascript" type="text/javascript">

       function fncExibir(show) {

           var vUrl = "";
           var vDataInicial = document.getElementById("<%= txtDataInicial.ClientID%>");
           var vDataFinal = document.getElementById("<%= txtDataFinal.ClientID%>");
           var vIdVendedor = document.getElementById("<%= lstVendedores.ClientID%>");
           var vIdCliente = document.getElementById("<%= lstClientes.ClientID%>");
           var vTipo = document.getElementById("<%= cboRelatorio.ClientID%>");
           var vAcao = document.getElementById("<%= cboAcao.ClientID%>");

           vUrl = vTipo[vTipo.selectedIndex].value + '_det.aspx?';

           if (vDataInicial != null) {
               if (isDate(vDataInicial.value) == false) {
                   alert("Por favor preencha a data inicial do periodo desejado!");
                   vDataInicial.focus();
                   return false;
               }
               else {
                   vUrl += '&di=' + vDataInicial.value;
               }
           }

           if (vDataFinal != null) {
               if (isDate(vDataFinal.value) == false) {
                   alert("Por favor preencha a data final do periodo desejado!");
                   vDataFinal.focus();
                   return false;
               }
               else {
                   vUrl += '&df=' + vDataFinal.value;
               }
           }
           if (vIdVendedor != null) {
               vUrl += '&ven=' + listVendedores();
           }
           if (vIdCliente != null) {
               vUrl += '&cli=' + listClientes();
           }


           if (vAcao != null) {
               vUrl += '&acao=' + vAcao.value;
           }
           var frame = document.getElementById("<%=frmRelatorio.clientID %>")

           if (show == 'print') {
               vUrl_p = vUrl + '&print=true'
               window.open(vUrl_p, 'IMPRIMIR_RELATORIO_FECHAMENTO', 'width=850, height=500,status=no,scrollbars=yes,toolbar=no,top=20,left=20');
           }

           frame.src = vUrl;
       }

       function listVendedores() {
           var p_IdVendedor = '';
           for (var i = 0; i < document.getElementById("<%= lstVendedores.ClientID%>").options.length; i++) {
               if (document.getElementById("<%= lstVendedores.ClientID%>").options[i].selected == true) {

                   if (document.getElementById("<%= lstVendedores.ClientID%>").options[i].value == 0) {
                       p_IdVendedor = 0;
                       break;
                   }
                   else {
                       p_IdVendedor += document.getElementById("<%= lstVendedores.ClientID%>").options[i].value + ',';
                   }
               }
           }
           if (p_IdVendedor == '') {
               for (var i = 0; i < document.getElementById("<%= lstVendedores.ClientID%>").options.length; i++) {
                   p_IdVendedor += document.getElementById("<%= lstVendedores.ClientID%>").options[i].value + ',';
               }
           }
           if (p_IdVendedor == '') p_IdVendedor = '0';
           return p_IdVendedor;
       }

       function listClientes() {
           var p_IdCliente = '';
           for (var i = 0; i < document.getElementById("<%= lstClientes.ClientID%>").options.length; i++) {
               if (document.getElementById("<%= lstClientes.ClientID%>").options[i].selected == true) {

                   if (document.getElementById("<%= lstClientes.ClientID%>").options[i].value == 0) {
                       p_IdCliente = 0;
                       break;
                   }
                   else {
                       p_IdCliente += document.getElementById("<%= lstClientes.ClientID%>").options[i].value + ',';
                   }
               }
           }
           if (p_IdCliente == '') p_IdCliente = '0';
           return p_IdCliente;
       }
	</script>
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updFiltro" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel runat='server' ID='updFiltro'>
        <ContentTemplate>
            <div class='Filtro'>
                <div class='FiltroItem'>
                    Relat&oacute;rio
                    <asp:DropDownList runat='server' ID='cboRelatorio' AutoPostBack="true">
                    </asp:DropDownList>
                </div>

                
                <div class='FiltroItem' runat='server' id='FiltroItem_Calendario'>Data<br>
                        <asp:Label runat="server" ID="lblData" Text="De" />
						<asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" />   
						<asp:CompareValidator runat='server'  ID='valCompInicio' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
						<ajaxToolkit:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                        </span>
                        <span style="float:left">
                            at&eacute;
                        </span>
                        <span style="float:left;margin-left:10px;">
					    <asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" />
					    <ajaxToolkit:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
					    <asp:CompareValidator runat='server'  ID='varCompFinal' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
                     </span>
		        </div>





                <br class="cb" />
                <div class='FiltroItem' runat='server' id='divVendedores' visible="false">
                    Vendedores
                    <br />
                    <asp:ListBox AutoPostBack="true" runat='server' ID='lstVendedores' DataTextField="Vendedor" DataValueField="IDVendedor" SelectionMode="Multiple" style="width:300px;" />
                    <asp:RequiredFieldValidator Enabled=false ControlToValidate='lstVendedores' runat="server" Display="None" ErrorMessage="Selecione o(s) vendedor(es)!" />
                </div> 
                <div class='FiltroItem' runat='server' id='divClientes' visible="false">
                    Clientes
                    <br />
                    <asp:ListBox runat='server' ID='lstClientes' DataTextField="Cliente" DataValueField="IDCliente" SelectionMode="Multiple" style="width:300px;"/>
                    <asp:RequiredFieldValidator Enabled=false ControlToValidate='lstClientes' runat="server" Display="None" ErrorMessage="Selecione o(s) Cliente(s)!" />
                </div> 
                <div class='FiltroItem' runat='server' id='divAcao' visible="false">
                    A&ccedil;&atilde;o
                    <br />
                    <asp:DropDownList runat='server' ID='cboAcao' >
                        <asp:ListItem Selected="True" Text="Todos" Value="0" />
                        <asp:ListItem Text="Reposi&ccedil;&atilde;o" Value="1" />
                        <asp:ListItem Text="Retorno" Value="2" />
                    </asp:DropDownList>
                </div>
                <div class='FiltroBotao'>
                    <input type='button' ID='btnExibir' Class="Botao" Value="Exibir" alt='Exibe o relatório selecionado' onclick="fncExibir('frame');" />
                    <input type='button' ID='btnImprimir' Class="Botao" Value="Imprimir" alt='Imprime o relatório selecionado'  onclick="fncExibir('print');" />
                </div> 
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat='server' ID='updFrame'>
        <ContentTemplate>
            <iframe id='frmRelatorio' frameborder='0' height='300px' width='100%' runat='server' />
        </ContentTemplate>
    </asp:UpdatePanel>
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

