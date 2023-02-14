<%@ Control Language="VB" AutoEventWireup="false" CodeFile="os_editor.ascx.vb" Inherits="include_os_editor" %>
<script type="text/javascript">
	function fncSelCliente()
		{
		var vFiltro = document.getElementById('<%=txtCliente.ClientId %>').value;
		var newwindow = null;
		if ( newwindow != null ) 
			{
			newwindow.close();
			}
			newwindow = window.open('selcliente.aspx?filtro=' + encodeURI(vFiltro), 'nsel', 'width=350,height=360,resizable,statusbar;');
			newwindow.focus();
		}
	function fncVolta(vNome, vEndereco, vReferencia)
	{
		document.getElementById("<%=txtCliente.ClientID%>").value = vNome;
		document.getElementById("<%=txtEndereco.ClientID%>").value = vEndereco;
		document.getElementById("<%=txtReferencia.ClientID%>").value = vReferencia;
	}
	
	function fncAddMsg()
		{
		var cbo = document.getElementById("<%=cboMensagens.ClientID%>");
		var txtCliente = document.getElementById("<%=txtCliente.ClientID%>");
		var txtEndereco = document.getElementById("<%=txtEndereco.ClientID%>");
		var txtReferencia = document.getElementById("<%=txtReferencia.ClientID%>");
		var txtObservacao = document.getElementById("<%=txtObservacao.ClientID%>");

		if (cbo.selectedIndex > -1) {

		    if (txtObservacao.value != '') {
		        if (confirm("Deseja limpar o conteudo da mensagem antes de incluir uma nova mensagem padrão?"))
		            txtObservacao.value = '';
		    }
		
			var i;
			i = txtCliente.value.length + txtEndereco.value.length + txtReferencia.value.length + txtObservacao.value.length;
			if (cbo.options[cbo.selectedIndex].value.length + i > 500)
				{
				if (i < 500)
					txtObservacao.value += cbo.options[cbo.selectedIndex].value.substring(1, 500 - i);
				}
			else
				{
				txtObservacao.value += cbo.options[cbo.selectedIndex].value;
				}
			checkSize();
		}}
	function checkSize()
	{
		var i;
		var txtCliente = document.getElementById("<%=txtCliente.ClientID%>");
		var txtEndereco = document.getElementById("<%=txtEndereco.ClientID%>");
		var txtReferencia = document.getElementById("<%=txtReferencia.ClientID%>");
		var txtObservacao = document.getElementById("<%=txtObservacao.ClientID%>");
		
		i = txtCliente.value.length + txtEndereco.value.length + txtReferencia.value.length + txtObservacao.value.length;
		if (i > 500)
			i = 500;
			
		spSize.innerHTML = (500 - i);
		if (i < 500)
			{return true;}
		else
			{
			if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 39  && event.keyCode != 38  && event.keyCode != 37  && event.keyCode != 40)
				return false;
			}
    }
    function hora(v) {

        v = v.replace(/\D/g, "") //Remove tudo o que não é dígito
        //v = v.replace(/^[^012]/, "") //valida o primeiro dígito #
        //v = v.replace(/^([2])([^0-3])/, "$1") //valida o segundo dígito ##
        v = v.replace(/^([\d]{2})([^0-5])/, "$1")//valida o terceiro dígito ###
        v = v.replace(/(\d{2})(\d)/, "$1:$2") //Coloca dois ponto entre o segundo e o terceiro dígitos ##:##
        v = v.substr(0, 5) //Remove digitos extras (aceita no max 5 caracteres(contando o ':' no meio) )
        document.getElementById('<%=txtTempoLimite.clientID%>').value = v

    }
</script>
                <table border="0" cellpadding='3' cellspacing='2' align="left" style="*float:left;">
					<tr>
						<td class="cinza1" align="right">Cliente:<asp:RequiredFieldValidator id="valCliente" Runat="server" ControlToValidate="txtCliente">*</asp:RequiredFieldValidator></td>
						<td height="20" width='360' class="cinza1"><asp:TextBox id="txtCliente" Runat="server" Width="350" onkeyup="return checkSize();"></asp:TextBox></td>
						<td style="width:33px; vertical-align:bottom;"><a class="TextDefault" href="javascript:fncSelCliente();"><img height="25" alt="Procurar o cliente com o nome indicado" src="../images/lupa.gif" border="0"></a></td>
					</tr>
					<tr>
						<td class="cinza1" align='right'>Endere&ccedil;o: </td>
						<td height="20" class="cinza1"><asp:TextBox id="txtEndereco" onkeyup="return checkSize();" Runat="server" width="350"></asp:TextBox></td>
						<td rowspan='6' style="width: 33px">&nbsp;</td>
					</tr>
					<tr>
						<td class="cinza1" align='right'>Local de Referencia:</td>
						<td height="20" class="cinza1"><asp:TextBox id="txtReferencia" onkeyup="return checkSize();" Runat="server" Width="350"></asp:TextBox></td>
					</tr>
					<tr>
						<td class="cinza1" align='right'>Responsável:
							<asp:RequiredFieldValidator id="regresp" Runat="server" ControlToValidate="cboResponsavel" Display="Dynamic" ErrorMessage='Por favor selecione o responsável'>*</asp:RequiredFieldValidator>
						<asp:CompareValidator id="compresp" Runat="server" ControlToValidate="cboResponsavel" Display="Dynamic" ErrorMessage='Por favor selecione o responsável'
								ValueToCompare="0" Operator="NotEqual">*</asp:CompareValidator></td>
						<td align="left" height="20" class="cinza1"><asp:DropDownList CssClass="ui-select" id="cboResponsavel" Runat="server" DataValueField="IDDestinatario" DataTextField="Destinatario"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="cinza1"  align='right'>Prioridade:</td>
                        <td align="left" class="cinza1">
							<asp:DropDownList  CssClass="ui-select" ID="cboPrioridade" runat='server' Width="110px">
                                <asp:ListItem Selected='True' Text='Selecione...' Value='0'></asp:ListItem>
                                <asp:ListItem Text='Baixa' Value='3'></asp:ListItem>
                                <asp:ListItem Text='Média' Value='2'></asp:ListItem>
                                <asp:ListItem Text='Alta' Value='1'></asp:ListItem>
                            </asp:DropDownList>
                        </td>
					</tr>
		        </table> 
                <table width="100%" border="0" cellpadding='2'>
					<tr>
						<td align="left" class="cinza1" id="tdDsc"  runat="server" width='480px'>Descrição<br />
						<asp:TextBox id="txtObservacao" onkeyup="return checkSize();" Runat="server" CssClass="formulario"
								Width="455" Rows="4" TextMode="MultiLine"></asp:TextBox>
						</td>
						<td class="cinza1" id="tdMsg" runat="server" align="left">Mensagens Padrão<br />
						<asp:DropDownList CssClass="ui-select" id="cboMensagens" Runat="server" DataValueField="msp_MensagemPadrao_chr" DataTextField="msp_Nome_chr"></asp:DropDownList>
							<br />
							<input style="background-image:url('../images/buttons/btn_adicionar2.png'); background-repeat:no-repeat; height:26px; width: 90px; border:0; margin-top:9px;" id="btnAddMensagem" title="Adicionar na O.S. a mensagem selecionada"
								onclick="fncAddMsg();" type="button" value="&nbsp;" />
						</td>
					</tr>
					<tr>
						<td colspan="2" align="left"><font class="cinza1">Caracteres: <i><span class="cinza1" id="spSize"><asp:Literal runat='server' ID='ltrCaracteres'>500</asp:Literal></span></i></font></td>
					</tr>
					<tr>
						<td class="cinza1" align="right">Tempo Limite de Atendimento (minutos):</td>
						<td align="left">
							<asp:TextBox id="txtTempoLimite" Runat="server" CssClass="formulario" Width="50" MaxLength="5" onKeyUp='hora(this.value);'></asp:TextBox><img alt="Tempo mínimo para atender esta Ordem de Serviço." src="../images/help.gif" align="bottom" /> <asp:RequiredFieldValidator id="valRequiredTime" Runat="server" ControlToValidate="txtTempoLimite" Display="Dynamic"
								CssClass="cinza1"><img src='../images/exclam2.gif' alt="">Campo Obrigatório</asp:RequiredFieldValidator>
					    </td>
					</tr>
				</table>