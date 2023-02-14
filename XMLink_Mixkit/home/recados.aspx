<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="recados.aspx.vb" Inherits="home_recados" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
                <asp:Panel runat="Server" ID="pnlFiltro" Visible="false">
		        <div class='FiltroItem' style="visibility:hidden;width:400px">Filtro<br>
		            <asp:TextBox runat="server" Width='390' ID="txtVendedor" />
		        </div></asp:Panel>
		        <div class='FiltroItem' style="width:200px;">Data<br>
						<asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" Width='80' />
						<asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
						<cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		        		até
						<asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" Width='80' />
						<cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
						<asp:CompareValidator runat='server'  ID='valCompDataFinal' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
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
    <asp:UpdatePanel runat='server' ID='UpdatePanel2'>
        <ContentTemplate>
	        <div class='ListArea'>
		        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
				        <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				            <HeaderStyle HorizontalAlign='Left' />
					        <columns>
						        <asp:BoundField HeaderText="Enviado" DataField="Enviado" SortExpression="Enviado" />
						        <asp:BoundField HeaderText="Destinatário" DataField="Destinatario" SortExpression="Destinatario" />
						        <asp:BoundField HeaderText="Mensagem" DataField="Recado" SortExpression="Recado" />
						        <asp:BoundField HeaderText="Enviado por" DataField="Usuario"/>
					        </columns>
					        <EmptyDataTemplate>
				                <div class='GridHeader'>&nbsp;</div>					    
					            <div class='divEmptyRow'>
							        <asp:Label runat='server' ID='lblNaoEncontrados'>
								        N&atilde;o h&aacute; Recados com o filtro selecionado!
							        </asp:Label>
					            </div>
					        </EmptyDataTemplate>
				        </asp:GridView>
                        <xm:Paginate ID="Paginate1" runat="server" />
			        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
                    </Triggers> 
                </asp:UpdatePanel>		
	        </div>
	        <br />
	        <asp:Panel ID='pnlMensagem' runat="server" Visible='false'>
                <div id='div1'>
                    <div id='div2' runat='server' class='Destinatario' style='width:50%'>
                        <font style='color:Red;font-size:14px'>Mensagens agendadas para envio</font>
                    </div>
                </div>
	        </asp:Panel>
	        <asp:UpdatePanel runat='server' ID='updEnvio'>
	            <ContentTemplate>
	                Enviar novo Recado
	                <div id='divNovoRecado'>
                        <div class='Destinatario'  style='width:50%'>
                            Selecione o(s) Destinatário(s)
                            <asp:CustomValidator ID="CustomValidator1"  runat='SERVER' ValidationGroup='Envio' ClientValidationFunction="verificaListaDestinatarios" Display=Dynamic ErrorMessage="Selecione os destinatários" Text="*"></asp:CustomValidator>
			                <asp:ListBox CssClass=formulario id="cboDestinatario" Rows='6' DataTextField='Nome' DataValueField="IDDEST" runat="server" AutoPostBack="False" SelectionMode='Multiple' Width="95%" />
                        </div><br /><br class='cb' />
                        <div class='Mensagem'  style='width:100%'>
                            Mensagem
                            <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' ControlToValidate='txtMensagem' ValidationGroup='Envio' ErrorMessage='O texto da mensagem é obrigatório' Text='*'></asp:RequiredFieldValidator>
                            <br />
                            <asp:textbox id="txtMensagem" CssClass='formulario' TextMode="MultiLine" Runat="server" Width="95%" Rows="6" onKeyDown='return checkSize();' onBlur='Trim();'></asp:textbox><br class='cb' />
                            Limite de Caracteres: <i>300</i><br />
                            Caracteres disponíveis: <i><span id='spSize'>300</span></i>
                            <asp:label id="lblMensagem" Runat="server" CssClass="cinza1" Visible="False">Não foi possível enviar o recado!</asp:label>
                            <asp:ValidationSummary ID="ValidationSummary1" runat='server' EnableTheming='false' ShowMessageBox='false'  ForeColor='White'  ValidationGroup='Envio' />
                            <asp:ValidationSummary ID="ValidationSummary2" runat='server' EnableTheming='false' ShowMessageBox='false'  ForeColor='White'  ValidationGroup='RevendaRegional' />
                        </div>
	                </div>
	            </ContentTemplate>
	        </asp:UpdatePanel>
            <div class='AreaBotoes' style="padding-right:0px;">
                <input type="button" class="Botao" value=" Voltar "  onclick="location.href='../pedidos/default.aspx'" />
                <asp:Button runat='server' ID='btnNovoEnvio' Text='Novo Envio' Visible='false'   />
                <asp:Button runat='server' ID='btnEnviar' Text='Enviar Mensagem'  ValidationGroup='Envio'  style="float:right;" />                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id='divErros'>
        <asp:ValidationSummary runat='server' ID='valSum'  HeaderText="Informe corretamente os campos abaixo:" ValidationGroup="Envio" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <b>Enviar Mensagem:</b> Enviar a mensagem de acordo com os destinatários selecionados.
			</li>
			<li>
                <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
    <script type='text/javascript'>
        function selAll(selStr) {
            var selObj = document.getElementById(selStr);
            for (var i = 0; i < selObj.options.length; i++) {
                selObj.options[i].selected = true;
            }
        }
        function checkSize() {
            var txtMensagem = document.getElementById('<%=txtMensagem.clientID%>')
            var i = txtMensagem.value.length;
            if (i < 300) {
                spSize.innerHTML = 300 - i;
                return true;
            }
            else {
                spSize.innerHTML = 0;
                if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 39 && event.keyCode != 38 && event.keyCode != 37 && event.keyCode != 40)
                    return false;
            }
        }
        function Trim() {
            var txtMensagem = document.getElementById('<%=txtMensagem.clientID%>')
            if (txtMensagem.value.length > 300) {
                txtMensagem.value = txtMensagem.value.substring(0, 300);
            }
        }

        function verificaListaDestinatarios(source, value) {

            var leng = document.getElementById("<%= cboDestinatario.ClientID%>").length;

            if (leng == 0) {
                value.IsValid = false;
            }
            else {
                value.IsValid = true;
            }
        }
			    
        </script>
					        
</asp:Content>

