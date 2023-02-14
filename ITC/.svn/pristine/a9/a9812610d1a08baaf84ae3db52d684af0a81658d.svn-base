<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AnaliseMensal.aspx.vb" ValidateRequest="False" Inherits="ITC.AnaliseMensal"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id="Tudo">
			
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Análise Mensal</h3>
				<br class=clear />
				
				<table cellspacing=0 cellpadding=0 width=100%>
					<tr>
						<td>
							<asp:DataGrid CssClass="Lista" id="dtgAnalise" runat="server" BackColor="White" CellPadding="3" GridLines=Horizontal AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Imagem" HeaderStyle-Width=35% HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="AnaliseMensalDet.aspx?IdAnalise=<%# DataBinder.Eval(Container.DataItem, "anm_analise_int_pk")%>">
												<img src="imagens/analise/<%# DataBinder.Eval(Container.DataItem, "anm_imagem_chr")%>" width=240 height=278/>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Título" HeaderStyle-Width=60% HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="AnaliseMensalDet.aspx?IdAnalise=<%# DataBinder.Eval(Container.DataItem, "anm_analise_int_pk")%>">
												<%# DataBinder.Eval(Container.DataItem, "anm_texto_chr")%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Visível" HeaderStyle-Width=10% HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<asp:Label><%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "anm_ativo_ind")=1, "Sim", "Não")%></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
					<tr>
						<td align="center" width="100%">
							<p align=center><asp:Button id="btnAddAnaliseMensal" Text="Incluir" Runat="server"></asp:Button></p>
						</td>
					</tr>
				</table>
							
   				<br class="clear" />
				    
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
