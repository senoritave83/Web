<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GuiaFornecedoresDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.GuiaFornecedoresDet"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top2.ascx" %>
			<table cellSpacing="0" cellpadding=0 width="100%" border="0"><tr><td><uc1:top2 id="top" runat="server"></uc1:top2></td></tr></table>
			<table id="Table1" borderColor="#809eb7" cellpadding=0 cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#809eb7"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle"><IMG src="Imagens/TituloGuiaFornecedores.jpg" border="0"><br>
						<br>
						<asp:DataList Runat=server ID=dtlFornecedores CssClass=f8>
							<ItemTemplate>
								<table width="100%" height="60" border="0" align="center" cellpadding="1" cellspacing="1" bordercolorlight="#CCCCCC" bordercolordark="#FFFFFF" bgcolor="#000000">
									<tr> 
										<td bgcolor="#003C6E" width="10">&nbsp;</td>	   
										<td bgcolor="white" width="100" align="center"><img src="imagens/<%# iif(DataBinder.Eval(Container.DataItem, "ImagemGuia")<> "", DataBinder.Eval(Container.DataItem, "ImagemGuia"), "sem_imagem.gif")%>" alt="" ></td>
										<td bgcolor="#E6E6E6" width="500">
											<table width="100%" border="0" cellspacing="2" cellpadding="0">
												<tr>
													<td class="f8" colspan=4><b><a href='<%# DataBinder.Eval(Container.DataItem, "WebSite")%>'><%# Ucase(DataBinder.Eval(Container.DataItem, "Fantasia"))%></a></b></td>
												</tr>
												<tr> 
													<td class="f8" >ENDEREÇO:</td>
													<td class="f8" colspan=3><%# Ucase(DataBinder.Eval(Container.DataItem, "Endereco"))%></td>
												</tr>
												<tr> 
													<td class="f8" >CIDADE:</td>
													<td class="f8" ><%# Ucase(DataBinder.Eval(Container.DataItem, "Cidade"))%></td>
													<td class="f8" >UF:</td>
													<td class="f8" ><%# DataBinder.Eval(Container.DataItem, "DescricaoEstado")%></td>
												</tr>
												<tr> 
													<td class="f8" >TELEFONE:</td>
													<td class="f8" colspan=3><%# Ucase(DataBinder.Eval(Container.DataItem, "Telefone"))%></td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</ItemTemplate>
							<AlternatingItemTemplate>
								<table width="100%" height="60" border="0" align="center" cellpadding="1" cellspacing="1" bordercolorlight="#CCCCCC" bordercolordark="#FFFFFF" bgcolor="#000000">
									<tr> 
										<td bgcolor="#E6E6E6" width="500">
											<table width="100%" border="0" cellspacing="2" cellpadding="0">
												<tr>
													<td class="f8" colspan=4><b><a href='<%# DataBinder.Eval(Container.DataItem, "WebSite")%>'><%# Ucase(DataBinder.Eval(Container.DataItem, "Fantasia"))%></a></b></td>
												</tr>
												<tr> 
													<td class="f8" >ENDEREÇO:</td>
													<td class="f8" colspan=3 ><%# Ucase(DataBinder.Eval(Container.DataItem, "Endereco"))%></td>
												</tr>
												<tr> 
													<td class="f8" >CIDADE:</td>
													<td class="f8" ><%# Ucase(DataBinder.Eval(Container.DataItem, "Cidade"))%></td>
													<td class="f8" >UF:</td>
													<td class="f8" ><%# DataBinder.Eval(Container.DataItem, "DescricaoEstado")%></td>
												</tr>
												<tr> 
													<td class="f8" >TELEFONE:</td>
													<td class="f8" colspan=3 ><%# Ucase(DataBinder.Eval(Container.DataItem, "Telefone"))%></td>
												</tr>
											</table>
										</td>
										<td bgcolor="white" width="100" align="center"><img src="imagens/<%# iif(DataBinder.Eval(Container.DataItem, "ImagemGuia")<> "", DataBinder.Eval(Container.DataItem, "ImagemGuia"), "sem_imagem.gif")%>" alt="" ></td>
										<td bgcolor="#003C6E" width="10">&nbsp;</td>	   
									</tr>
								</table>
							</AlternatingItemTemplate>
							<SeparatorTemplate><br></SeparatorTemplate>
						</asp:DataList>
						<br>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
