<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BlocoNoticias.ascx.vb" Inherits="ITC.BlocoNoticias" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
	<tr>
		<td width="1" height="2" valign="top"><img src="ponta_tabela.gif" width="1" height="2" border="0"></td>
		<td width="100%" style="border-top: solid 1px black;" height="2"><img src="imagens/invisivel.gif" width="1" height="1" border="0"></td>
		<td width="1" height="2" valign="top"><img src="imagens/ponta_tabela.gif" width="1" height="2" border="0"></td>
	</tr>
	<tr>
		<td colspan="3" height="13" style="border-left: solid 1px black; border-right: solid 1px black;" bgcolor="#003C6E" class="f7 b w">&nbsp;&nbsp;ATENÇÃO</td>
	</tr>
	<tr>
		<td colspan="3" style="border: solid 1px black;" valign="top" bgcolor="#ffffff"><table width="100%" height="100%" cellpadding="0" cellspacing="5" border="0">
				<tr>
					<td valign="top" align="center" class="f8">
						<img src='imagens/cursoseventos.jpg' border="0">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<br>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
	<tr>
		<td width="1" height="2" valign="top"><img src="ponta_tabela.gif" width="1" height="2" border="0"></td>
		<td width="100%" style="border-top: solid 1px black;" height="2"><img src="imagens/invisivel.gif" width="1" height="1" border="0"></td>
		<td width="1" height="2" valign="top"><img src="imagens/ponta_tabela.gif" width="1" height="2" border="0"></td>
	</tr>
	<tr>
		<td colspan="3" height="13" style="border-left: solid 1px black; border-right: solid 1px black;" bgcolor="#003C6E" class="f7 b w">&nbsp;&nbsp;BUSCA</td>
	</tr>
	<tr>
		<td colspan="3" style="border: solid 1px black;" valign="top" bgcolor="#ffffff"><table width="100%" height="100%" cellpadding="0" cellspacing="5" border="0">
				<tr>
					<td valign="top" class="f8">
						<SCRIPT>
					function verificaBusca() {
						if (document.frmBusca.Palavras.value == '') {
							alert('Você precisa digitar algo na Busca.');
							document.frmBusca.Palavras.focus();
							return false;
						} else if (document.frmBusca.Palavras.value.length < 3) {
							alert('Sua busca deve conter no mínimo 3 caracteres.');
							document.frmBusca.Palavras.focus();
							return false;				
						}
					}

					</SCRIPT>

						<TABLE cellSpacing=0 cellPadding=0 border=0>
							<FORM name=frmBusca onsubmit="return verificaBusca();" 
							action=/resultado_busca.asp method=get>
							<TBODY>
							<TR vAlign=top height=25>
							<TD><INPUT class=f7 style="WIDTH: 122px" maxLength=25 size=8 
								name=Palavras></TD></TR>
							<TR>
							<TD><SELECT class=f7 style="WIDTH: 122px"><OPTION value=AND 
								selected>Todas palavras</OPTION> <OPTION value=OR>Qualquer 
								palavra</OPTION></SELECT></TD></TR>
							<TR>
							<TD align=right>
								<SCRIPT>Inv(5,5)</SCRIPT>
								<BR><INPUT class=f7 type=image 
								src="IMAGENS/procurar.gif" 
							value=ok></TD></TR></FORM></TBODY></TABLE>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
