<%@ Page Language="vb" AutoEventWireup="false" Codebehind="lista.aspx.vb" Inherits="xmlinkwm.lista"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Equipe Online</title>
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="styles.css" rel="StyleSheet" type="text/css">
		<script>
			function refresh() {document.Form1.submit();}
			setTimeout('refresh();',60000); 
		</script>
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0" scroll="no">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="380" cellpadding="0" cellspacing="0" border="0">
				<tr height="25">
					<td>
						<asp:Repeater ID='rptGrid' Runat="server">
							<HeaderTemplate>
								<table cellspacing="0" border="0" width="100%">
									<tr class="Header" style="color:White;">
										<td width="70">
											<asp:LinkButton CommandName="Order" CommandArgument='Numero' style="color:White;" OnCommand='rptGrid_ItemCommand' ID='lnlOS' Runat="server">#Pedido</asp:LinkButton>
										</td>
										<td><asp:LinkButton CommandName="Order" CommandArgument='Cliente' style="color:White;" OnCommand='rptGrid_ItemCommand' ID="Linkbutton4" Runat="server">Cliente</asp:LinkButton></td>
										<td width="70">Criada <img src='imagens/help4.gif' align="absmiddle" alt='Data de emissão do Pedido.'></td>
										<td width="200"><asp:LinkButton CommandName="Order" CommandArgument='Vendedor' style="color:White;" OnCommand='rptGrid_ItemCommand' ID="Linkbutton1" Runat="server">Vendedor</asp:LinkButton>
											<img src='imagens/help4.gif' align="absmiddle" alt='Vendedor que realizou o pedido.'></td>
										<td width="80"><asp:LinkButton CommandName="Order" CommandArgument='Status' style="color:White;" OnCommand='rptGrid_ItemCommand' ID="Linkbutton2" Runat="server">Status</asp:LinkButton>
											<img src='imagens/help4.gif' align="absmiddle" alt='Status atual do Pedido.'></td>
										<td width="80"><asp:LinkButton CommandName="Order" CommandArgument='Valor' style="color:White;" OnCommand='rptGrid_ItemCommand' ID="Linkbutton3" Runat="server">Valor</asp:LinkButton>
											<img src='imagens/help4.gif' align="absmiddle" alt='Valor Total do Pedido.'></td>
										</tr>
								</table>
					</td>
				</tr>
				<tr height="100%">
					<td>
						<div style="height: 100%; overflow: auto">
							<table width="100%">
								</HeaderTemplate>
								<ItemTemplate>
									<tr class="GridItem" style="height:10px;">
										<td style="width:70px;"><a href='pedido.aspx?idpedido=<%# Databinder.Eval(Container.DataItem,"ped_Pedido_int_PK")%>' target='_parent'><b class='GridItem'><%# Databinder.Eval(Container.DataItem,"ped_NumeroPedido_int")%></b></a>
											<%# iif(Databinder.Eval(Container.DataItem,"ped_Obs_ind") = 1, "<img src='imagens/obs_flag.gif' align='absmiddle' alt='Indica que o Pedido tem alguma observação.'>", "") %></td>
										<td><%#Databinder.Eval(Container.DataItem,"cli_Cliente_chr")%></td>
										<td style="width:70px;"><%# Format(Databinder.Eval(Container.DataItem,"ped_DataEmissao_dtm"),"dd/MM/yyyy")%></td>
										<td style="width:200px;"><%#Databinder.Eval(Container.DataItem,"ven_Vendedor_chr")%></td>
										<td style="width:80px;" valign="Top"><%# Databinder.Eval(Container.DataItem,"sta_StatusPedido_chr")%></td>
										<td style="width:80px;" valign="Top" align='right'>R$ <%# Format(Databinder.Eval(Container.DataItem,"ped_Total_cur"), "#,##0.00")%></td>
									</tr>
								</ItemTemplate>
								<FooterTemplate>
							</table>
						</div>
					</td>
				</tr>
				<tr height="20">
					<td>
						</FooterTemplate> </asp:Repeater>
						<table width="100%">
							<tr class="GridItem" align="Right" style="width:100%;">
								<td colspan="6">
									<asp:LinkButton CommandName="Paginate" CommandArgument='0' OnCommand='rptGrid_ItemCommand' ID="lnkPrevious" Runat="server">Anterior</asp:LinkButton>
									&nbsp;
									<asp:LinkButton CommandName="Paginate" CommandArgument='1' OnCommand='rptGrid_ItemCommand' ID="lnkNext" Runat="server">Próximo</asp:LinkButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
