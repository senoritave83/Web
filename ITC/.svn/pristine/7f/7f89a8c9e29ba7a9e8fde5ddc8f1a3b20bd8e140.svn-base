<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SaibaMais.aspx.vb"  ValidateRequest="False" Inherits="ITC.SaibaMais"%>
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
				<h3>Cadastro de Saiba Mais</h3>
				<br class=clear />
				
				<table cellspacing=0 cellpadding=0 width=100%>
					<tr>
						<td>
							<asp:DataGrid CssClass="Lista" id="dtgSaibaMais" runat="server" BackColor="White" CellPadding="3" GridLines=Horizontal AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Imagem e Texto Descritivo" HeaderStyle-Width=100% HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="SaibaMaisDet.aspx?IdSaibaMais=<%# DataBinder.Eval(Container.DataItem, "sbm_registro_int_pk")%>">
												<img src="imagens/saibamais/<%# DataBinder.Eval(Container.DataItem, "sbm_imagem_chr")%>" class="FloatLeft" style="MARGIN:3px" width=100 height=80/>
												<%# DataBinder.Eval(Container.DataItem, "sbm_texto_chr")%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Visível" HeaderStyle-Width=10% HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<asp:Label><%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "sbm_ativo_ind")=1, "Sim", "Não")%></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
					<tr>
						<td align="center" width="100%">
							<p align=center><asp:Button id="btnAddSaibaMais" Text="Incluir" Runat="server"></asp:Button></p>
						</td>
					</tr>
				</table>
							
   				<br class="clear" />
				    
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
