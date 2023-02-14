<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ajuda.aspx.vb" Inherits="xmlinkwm.ajuda" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<HTML>
<!-- #INCLUDE FILE='inc/inc_header.ascx' -->
<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
	<!-- #INCLUDE FILE='inc/inc_top.ascx' -->
	<table width="100%" cellpadding="0" cellspacing="0" height="100%">
		<tr>
			<td>
				<uc1:inc_menu id="Inc_menu1" runat="server"></uc1:inc_menu>
			</td>
			<td class='BackgrStripes' rowspan="2">&nbsp;</td>
		</tr>
		<tr height="100%">
			<td width="750" valign="top" align="middle">
				<!-- INICIO CONTEUDO -->
				<form id="Form1" method="post" runat="server" onsubmit='return false;'>
					<table height="100%" width="730">
						<tr vAlign="middle" height="60">
							<td>
							</td>
						</tr>
						<tr valign="top" height="100%">
							<td>
								<table border="0" cellpadding="2" cellspacing="3" width="100%" bgcolor="gray" height="100%">
									<tr>
										<td height="50">
											<table width="100%" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td colspan="2" class="TextRoxoBold">
														Procurar:<br>
													</td>
												</tr>
												<tr height="16">
													<td>
														<input type="text" ID='txtProcurar' Class="Caixa" onkeydown='if(event.keyCode == 13) {fncSearch();}'>
													</td>
													<td>
														<img src='imagens/go.gif' onclick='fncSearch();' style='CURSOR:hand' align="absBottom">
													</td>
												</tr>
											</table>
										</td>
										<td bgcolor='white' rowspan="2">
											<iframe name='frmHelp' src='inc_help.aspx' frameborder="no" height="100%" width="100%"></iframe>
										</td>
									</tr>
									<tr valign="top">
										<td class='fundo' width="20%">
											<div style="OVERFLOW: auto;HEIGHT: 100%">
												<asp:Literal ID="MyTree" Runat="server" />
											</div>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					<script type="text/javascript" language="javascript">
											/*<![CDATA[*/
											function toggle(node) {
										    
											var nextDIV = node.nextSibling;
										    
											while(nextDIV.nodeName != "DIV") {
												nextDIV = nextDIV.nextSibling;
											}
										    
											if (nextDIV.style.display == 'none') {
										    
												if (node.childNodes.length > 0) {
										    
												if (node.childNodes.item(0).nodeName == "IMG") {
													node.childNodes.item(0).src = getImgDirectory(node.childNodes.item(0).src) + "minus.gif";
												}
												}
												nextDIV.style.display = 'block';
											}
											else {
										    
												if (node.childNodes.length > 0) {
												if (node.childNodes.item(0).nodeName == "IMG") {
													node.childNodes.item(0).src = getImgDirectory(node.childNodes.item(0).src) + "plus.gif";
												}
												}
												nextDIV.style.display = 'none';
											}
											}
										    
											function getImgDirectory(source) {
												return source.substring(0, source.lastIndexOf('/') + 1);
											}
										    
											function selectLeaf(title, vId) {
												frmHelp.document.location.href = 'inc_help.aspx?idhelp=' + vId;
											}
											function fncSearch()
											{
												frmHelp.document.location.href = 'inc_help.aspx?search=' + escape(document.Form1.txtProcurar.value);
											}
										    
											/*]]>*/
					</script>
				</form>
				<!-- FIM CONTEUDO -->
			</td>
		</tr>
	</table>
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
</body> 
</html> 