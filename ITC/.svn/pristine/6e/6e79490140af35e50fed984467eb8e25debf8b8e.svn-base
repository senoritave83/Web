<%@ Register TagPrefix="uc1" TagName="Menu" Src="inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/combobox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="inc/rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GrupoDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.GrupoDet" %>
<%@ Register TagPrefix="uc2" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table class="TableSup" id="tbl1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr height="100">
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#F1F1F1">
						<tr>
							<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr bgColor="#ffffff" height="*">
				<td vAlign="top" align="middle"><br>
					<form id="frmCad" action="gRUPODet.aspx" runat="server">
						<img src="imagens/TituloCadastroGrupos.jpg" border="0">
						<br>
						<table width="70%" border="0" bgcolor="#efefef">
							<tr bgColor="#003366">
								<td><asp:label id="lbl" runat="server" ForeColor="white" CssClass="f8" Text="Dados do Grupo"></asp:label></td>
							</tr>
							<tr>
								<td width="50%" nowrap>
									<asp:label id="lblGrupo" CssClass="f8" Runat="Server">Grupo</asp:label>
									<asp:textbox id="txtGrupo" CssClass="f8" runat="server" MaxLength="80" Width="75%" ReadOnly=True></asp:textbox>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td align="middle"><uc1:barrabotoes id="BarraBotoes" runat="server"></uc1:barrabotoes></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
						<br>
						<br>
						<table width="82%" bgColor="#003366">
							<tr>
								<td align="right"><asp:datagrid CssClass="f8" id="dtgGrid" runat="server" AutoGenerateColumns="False" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#999999" width="100%" DataKeyField="ACA_ACAO_INT_PK">
										<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
										<HeaderStyle ForeColor="White" BackColor="#003366"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<AlternatingItemStyle ForeColor="Black" BackColor="#FFFFFF"></AlternatingItemStyle>
										<Columns>
											<asp:TemplateColumn HeaderText='Habilitar'>
												<ItemTemplate>
													<asp:CheckBox Runat='server' id='chkPermissao' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMISSAO")=1, true, false)%>'>
													</asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText='Seção'>
												<ItemTemplate>
													<font class=f8 color="<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMISSAO")= 0, "#FF0000", "#000000") %>"><%# DataBinder.Eval(Container.DataItem, "aca_Secao_chr")%></font>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText='Ação'>
												<ItemTemplate>
													<font class=f8 color="<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMISSAO")= 0, "#FF0000", "#000000") %>"><%# DataBinder.Eval(Container.DataItem, "aca_Acao_chr")%></font>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:datagrid><asp:ImageButton CssClass="f8" Runat="server" ID="btnGravar" ImageUrl="Imagens/BotaoSalvarPermissoes.gif" BorderStyle="None" /></td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
			<tr vAlign="bottom" height="20">
				<td width="100%"><uc1:rodape id="Rodape1" runat="server"></uc1:rodape></td>
			</tr>
		</table>
	</body>
</HTML>
