<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="agenda.aspx.vb" Inherits="home_agenda" title="Equipe Online" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellpadding='0' cellspacing='0' height="100%">
        <tr class='Header1'> 
            <td>
                <strong>O.S. agendadas para o dia abaixo</strong>
            </td>
        </tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>
		<tr valign="top" bgcolor="white">
			<td height="100%">
				<table width="100%" cellpadding="0" cellspacing="0">
					<tr class="Header2">
						<td align="left" width="30%">
							&nbsp;
							<asp:LinkButton Runat="server" ID='lnkPrevious'>
								<font color="White">&lt; &lt; Anterior</font></asp:LinkButton>
						</td>
						<td align="middle">
							<asp:Label Runat="server" ID='lblData'></asp:Label>
						</td>
						<td align="right" width="30%">
							<asp:LinkButton Runat="server" ID="lnkNext">
								<font color="White">Próximo &gt; &gt;</font></asp:LinkButton>&nbsp;
						</td>
					</tr>
				</table>
				<asp:DataList Runat="server" ID='lstAgenda' Width="100%" BackColor="LightGrey" CellSpacing="1" Height="80%">
					<ItemStyle BackColor="White" VerticalAlign="Top" Width="14%"></ItemStyle>
					<ItemTemplate>
						<b class='TextDefault'>
							<%# CDate(Databinder.Eval(Container.DataItem,"Date_time")).toString("HH:mm")%>
						</b>
						<br>
						<asp:datagrid id=Datagrid1 runat="server" ShowHeader=False DataSource='<%# GetTarefas(Databinder.Eval(Container.DataItem,"Date_time"), 60)%>' BorderWidth="0" GridLines="None" Width="100%" AutoGenerateColumns=False Font-Name=Verdana Font-Size=8pt >
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										OS# <a href='ordemservico.aspx?idos=<%# Databinder.Eval(Container.DataItem,"ors_OrdemServico_int_PK")%>'><b class='TextDefault'>
												<%# Databinder.Eval(Container.DataItem,"ors_OrdemServico_chr")%>
											</b></a>enviada para
										<%# Databinder.Eval(Container.DataItem,"rsp_Responsavel_chr")%>
										referente
										<%# Databinder.Eval(Container.DataItem,"cli_Cliente_chr")%>
										(<%# Format(Databinder.Eval(Container.DataItem,"ors_Agendar_dtm"),"HH:mm")%>)
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					</ItemTemplate>
				</asp:DataList>
			</td>
		</tr>
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" /></td>
        </tr>							
	</table>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><a href="calendario.aspx">Calend&aacute;rio</a></dt>
    <dt><a href="agendamentos.aspx">Agendamento</a></dt>
    <dt class="current"><span lang="pt-br"><a href="agendamento.aspx">Nova O.S programada</a> </span></dt>
    <dt><span lang="pt-br"><a href="../integracao/default.aspx">Integra&ccedil;&atilde;o</a> </span></dt>
    </dl>    
    
</asp:Content>
