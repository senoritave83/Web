<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Login.ascx.vb" Inherits="ITC.Login" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<%@ Register TagPrefix="uc1" TagName="Login" Src="Login1.ascx" %>
<LINK href="styles.css" type="text/css" rel="stylesheet">
<form id="frmLogin">
	<table cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td>
				<table cellSpacing="0" cellpadding="0" border="0" width="100%">
					<tr>
						<td nowrap width="11" height="11"><img src='imagens/borda_login_esquerda.gif' border="0"></td>
						<td width="100%" bgcolor="#edf0f2" nowrap></td>
						<td nowrap width="11" height="11"><img src='imagens/borda_login_direita.gif' border="0"></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<table bgcolor="#edf0f2" id="tblLogin" cellpadding="0" cellspacing="0" width="100%" align="left" runat="server" border="0">
					<tr>
						<td noWrap valign="center">
							<table cellpadding="2" cellspacing="0" border="0">
								<tr>
									<td nowrap><asp:label id="Label1" CssClass="menu1" Runat="server">Login: </asp:label></td>
									<td><asp:textbox CssClass="f8" size="10" id="txtLogin" Runat="server" MaxLength="20"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" Runat="server" CssClass="f8" ErrorMessage="*" ControlToValidate="txtLogin"></asp:requiredfieldvalidator></td>
								</tr>
								<tr>
									<td nowrap><asp:label CssClass="menu1" id="Label2" Runat="server">Senha: </asp:label></td>
									<td><asp:textbox CssClass="f8" size="10" id="txtSenha" Runat="server" MaxLength="10" TextMode="Password"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" CssClass="f8" Runat="server" ErrorMessage="*" ControlToValidate="txtSenha"></asp:requiredfieldvalidator></td>
								</tr>
							</table>
						</td>
						<td valign="middle" align="center"><asp:imagebutton CssClass="f8" id="btnLogin" Runat="server" ImageUrl="botaook.gif" BorderStyle="None" CausesValidation="True"></asp:imagebutton></td>
					</tr>
					<tr>
						<td colspan="2"><asp:label CssClass="f8" id="lblMensagem" Runat="server"></asp:label></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<table cellSpacing="0" cellpadding="0" border="0" width="100%">
					<tr>
						<td nowrap width="11" height="11"><img src='imagens/borda_login_esquerda2.gif' border="0"></td>
						<td width="100%" bgcolor="#edf0f2" nowrap></td>
						<td nowrap width="11" height="11"><img src='imagens/borda_login_direita2.gif' border="0"></td>
					</tr>
				</table>
				<table cellSpacing="0" cellpadding="5" border="0" width="100%" bgcolor="#edf0f2">
					<tr align="center" valign="top">
						<td bgcolor="#809eb7" nowrap> <iframe src="imagens/demo.swf" width="155" height="55" frameborder="0" scrolling="no"></iframe> </td>
					</tr>
				</table>
<table cellSpacing="0" cellpadding="0" border="0" width="100%">
	<tr>
		<td nowrap width=11 height=11><img src='imagens/borda_login_esquerda.gif' border=0></td><td width=100% bgcolor="#edf0f2" nowrap></td><td nowrap width=11 height=11><img src='imagens/borda_login_direita.gif' border=0></td>
	</tr>
</table>
<TABLE cellSpacing="5" width="100%" border="0" bgcolor="#edf0f2">
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(1);" onmouseout="this.className='menu1'" noWrap>HOME</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(2);" onmouseout="this.className='menu1'" noWrap>EMPRESA</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(3);" onmouseout="this.className='menu1'" noWrap>TIPOS 
			DE OBRAS</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(20);" onmouseout="this.className='menu1'" noWrap>ITC 
			INFORMA</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(4);" onmouseout="this.className='menu1'" noWrap>NOTÍCIAS</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(6);" onmouseout="this.className='menu1'" noWrap>GUIA 
			DE FORNECEDORES</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(7);" onmouseout="this.className='menu1'" noWrap>CURSOS 
			E EVENTOS</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(9);" onmouseout="this.className='menu1'" noWrap>ASSOCIE-SE</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(10);" onmouseout="this.className='menu1'" noWrap>CADASTRE 
			SUA OBRA</TD>
	</TR>
	<TR height="25">
		<TD><IMG src="imagens/seta_azul.gif"></TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="javascript:ITC_GO(11);" onmouseout="this.className='menu1'" noWrap>CADASTRE 
			SUA EMPRESA</TD>
	</TR>
	<TR height="25">
		<TD>
			<P><IMG src="imagens/seta_azul.gif"></P>
		</TD>
		<TD class="menu1" onmouseover="this.className='menu2'" onclick="document.location='mailto:suporte@itc.etc.br'" onmouseout="this.className='menu1'" noWrap>FALE 
			CONOSCO</TD>
	</TR>
</TABLE>
<table cellSpacing="0" cellpadding="0" border="0" width="100%">
	<tr>
		<td nowrap width=11 height=11><img src='imagens/borda_login_esquerda2.gif' border=0></td><td width=100% bgcolor="#edf0f2" nowrap></td><td nowrap width=11 height=11><img src='imagens/borda_login_direita2.gif' border=0></td>
	</tr>
</table>
<table bgcolor="#809eb7"  borderColor="#e8dea0" cellSpacing="0" width="100%" border="0">
	<tr>
		<td vAlign="center" align="middle"><!--a href='Demonstracao1.aspx'><IMG src="imagens/demonstracao.jpg" border="0"></a-->&nbsp;</td>
	</tr>
</table>
<script language="javascript">
	function ITC_GO(Tipo)
	{
		switch(Tipo)
		{
			case 1: //HOME
				window.location.href = 'default.aspx';
				break;
			case 2: //EMPRESA
				window.location.href = 'apresentacaoempresa.aspx';
				break;
			case 3: //TIPOS DE OBRAS
				window.location.href = 'tiposdeobras.aspx';
				break;
			case 4: //NOTÍCIAS
				window.location.href = 'noticias.aspx';
				break;
			case 6: //GUIA DE FORNECEDORES
				window.location.href = 'guiafornecedoresnovo.aspx';
				break;				
			case 7: //DEMONSTRAÇÃO
				window.location.href = 'eventos.aspx';

				break;				
			case 8: //DEMONSTRAÇÃO
				window.location.href = 'demonstracao1.aspx';
				break;
			case 9: //ASSOCIE-SE
				window.location.href = 'associar.aspx';
				break;
			case 10: //CADASTRE SUA OBRA
				window.location.href = 'cadastresuaobra.aspx';
				break;
			case 11: //CADASTRE SUA EMPRESA
				window.location.href = 'cadastresuaempresa.aspx';
				break;
			case 20: //CUB
				window.location.href = 'cub.aspx';
				break;
			default:
				window.location.href = 'Default.aspx';
				break;
		}
	}
</script>
			</td>
		</tr>
	</table>
</form>