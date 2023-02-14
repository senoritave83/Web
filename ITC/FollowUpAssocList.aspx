<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FollowUpAssocList.aspx.vb" Inherits="ITC.FollowUpAssocList"%>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
  <HEAD>
		<!-- #include file='inc/header.aspx' -->
		<script language="javascript">
			function VerificarSel()
			{
				for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name = 'chkIdFollowUp') && (e.type=='checkbox'))
							{
								if (e.checked) return true;
							}
					}
				return false;
			}
		</script>
	</HEAD>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id="Tudo">
			
				<uc1:Top id="Top1" runat="server"></uc1:Top>
				
				<h3>SIG's Cadastrados de Associados</h3>
				<a href="followupassoc.aspx" class="novo_follow" style="MARGIN:-22px 5px 0px 0px"><img src="img/follow_voltar.gif" style="MARGIN:0px 0px 2px" > Voltar</a>
				<p>&nbsp;</p>
				<p><asp:label Font-Bold=True Runat=server CssClass="FloatLeft" ID="lblNomeAssociado"></asp:label></p><br />
				
				<div class="FloatRight" style="MARGIN:-15px 0px 10px">
    				<asp:LinkButton Runat='server' ID="lnkApagar" CssClass='bt_follow'>Excluir</asp:LinkButton>
					<asp:LinkButton Runat='server' ID='lnkNovo' CssClass='bt_follow_novo'>Novo SIG</asp:LinkButton>
   				</div>
				
				<br >
				<table  class="TableResultPesquisa" width=100% runat=server id="tblListarFollowUp">
					<tr>
						<td>
							<asp:DataGrid CssClass="f9" id="dtlFollowUP" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" BorderColor="#999999" OnPageIndexChanged="doPaging" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle CssClass=Tit></HeaderStyle>
								<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<SelectedItemStyle BackColor=#0000ff></SelectedItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
										<ItemTemplate>
											<a href='followupassocdet.aspx?idAssociado=<%# CryptographyEncoded(ViewState("IdAssociado"))%>&idfollowup=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDFOLLOWUP"))%>&idx='><img src='imagens/botaoeditar.gif' border=0></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="50%" HeaderText="<b>Descrição</b>">
										<ItemTemplate>
											<font class="f8"><%# DataBinder.Eval(Container.DataItem, "DESCRICAO")%></font>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="18%" HeaderText="<b>Relator</b>">
										<ItemTemplate>
											<font class="f8"><%# DataBinder.Eval(Container.DataItem, "RELATOR")%></font>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="15%" HeaderText="<b>Data</b>">
										<ItemTemplate>
											<font class="f8"><%# Right("00" & Day(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("00" & Month(DataBinder.Eval(Container.DataItem, "Data")), 2) & "/" & Right("0000" & Year(DataBinder.Eval(Container.DataItem, "Data")), 4) & " " & Right("00" & Hour(DataBinder.Eval(Container.DataItem, "Data")), 2) & ":" & Right("00" & Minute(DataBinder.Eval(Container.DataItem, "Data")), 2)%></font>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="18%" HeaderText="<b>Agendamento</b>">
										<ItemTemplate>
											<font class="f8"><%# DataBinder.Eval(Container.DataItem, "DataAgenda") %></font>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Excluir">
										<ItemTemplate>
											<input type=checkbox id="chkIdFollowUp<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDFOLLOWUP"))%>" name="chkIdFollowUp" class="f8" value="<%# DataBinder.Eval(Container.DataItem, "IDFOLLOWUP")%>">
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Visible=true HorizontalAlign="Center" ForeColor=white PageButtonCount=10 BackColor=#cccccc  Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				
				<fieldset>
					<legend>Filtros especificos</legend>
				    
					<label>Agendamento</label>
					<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" CssClass="inputP" ID="txtDataAgendamento" Runat="server" MaxLength="10" Width="80px" onfocus="displayCalendar(document.forms[0].txtDataAgendamento,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataAgendamento,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataAgendamento,'dd/mm/yyyy',this)"/>
					<br >
				    
					<label>Cadastro Inicial</label>
					<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" CssClass="inputP" ID="txtInicial" Runat="server" MaxLength="10" Width="80px" onfocus="displayCalendar(document.forms[0].txtInicial,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtInicial,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtInicial,'dd/mm/yyyy',this)">
					<br >
				    
					<label>Cadastro Final</label>
					<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" CssClass="inputP" ID="txtDataFinal" Runat="server" MaxLength="10" Width="80px" onfocus="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" />	<img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)">
					<br >
				    
					<label>Descrição</label>
					<asp:TextBox CssClass="inputP" ID="txtDescricao" Runat="server" MaxLength="100" Width=70%></asp:TextBox>
					<br >
				    
					<label>&nbsp;</label>
					<asp:Button Runat='server' Text='Filtrar' ID="btnProcurar"></asp:Button>
				</fieldset>

				<uc1:Rodape id="Rodape" runat="server"></uc1:Rodape></div>
			</div>
		</form>
	</body>
</HTML>