<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmailPedido.aspx.vb" Inherits="ITCOffLine.EmailPedido" %>
<HTML>
	<HEAD>
		<script language='javascript'>
			function fncValida()
			{
				if(document.getElementById('<%=txtmail.ClientId%>').value=='')
				{
					alert('Digite o e-mail do destinatário!');
					return false;
				}
			}
			function FecharJanela()
			{
				window.close();
			}
		</script>
		<style>
    .f8h { FONT-FAMILY: verdana, tahoma, arial; COLOR: #000000; FONT-SIZE: 10px; CURSOR: default; FONT-WEIGHT: bold }
    .f10 { FONT-FAMILY: verdana, tahoma, arial; COLOR: #ffffff; FONT-SIZE: 13px; CURSOR: default; FONT-WEIGHT: bold }
    .botao { BORDER-BOTTOM: #dddddd 1px solid; BORDER-LEFT: #dddddd 1px solid; BACKGROUND-COLOR: #ff9933; FONT: bold 12px verdana, arial, helvetica; COLOR: #000000; BORDER-TOP: #dddddd 1px solid; BORDER-RIGHT: #dddddd 1px solid }
		</style>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="frmveja" runat="server">
			<Table id="tblMain" runat="server" bgcolor="#efefef" width="400" height="200" align="center"
				cellpadding="0" cellspacing="0" border="0">
				<TR bgcolor="#003c6e">
					<TD ColSpan="2" Align="center"><font class="f10" color="#ffffff"><b>Envie um e-mail do 
								pedido n&ordm; <%= ViewState("IdPed") %></b></font></TD>
				</TR>
				<TR>
					<TD align="right" width='80'>
						<asp:Label class="f8h" id="lblEmail" runat="server" text="Para:&nbsp;"></asp:Label>
					</TD>
					<TD nowrap>
						<asp:TextBox id="txtmail" runat="server" Width="280" MaxLength="500" size=''></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD align="right" width='80'>
						<asp:Label class="f8h" id="lblCc" runat="server" text="Cc:&nbsp;"></asp:Label>
					</TD>
					<TD nowrap>
						<asp:TextBox id="txtCc" runat="server" Width="280" MaxLength="500"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD align="right" width='80'>
						<asp:Label class="f8h" id="lblCco" runat="server" text="Cco:&nbsp;"></asp:Label>
					</TD>
					<TD nowrap>
						<asp:TextBox id="txtCco" runat="server" Width="280" MaxLength="500"></asp:TextBox>
					</TD>
				</TR>
				<tr>
					<td align="center" colspan="2">
						<asp:Button id="btnEnviar" runat="server" Text="Enviar"></asp:Button>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label class="f8h" id="lblMensagem" style="VISIBILITY: hidden" runat="server"></asp:Label>
					</td>
				</tr>
			</Table>
			<Table id="tblResult" runat="server" bgcolor="#efefef" width="400" height="200" visible="false"
				align="center" cellpadding="0" cellspacing="0" border="0">
				<TR bgcolor="#003c6e">
					<TD Align="center">
						<font class="f10" color="#ffffff"><b>Resultado do Envio</b></font>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<font class="f8h" color="#000000">E-Mail Enviado</font>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<input type='button' onclick='javascript:FecharJanela();' value='Fechar'>
					</TD>
				</TR>
			</Table>
		</form>
	</body>
</HTML>
