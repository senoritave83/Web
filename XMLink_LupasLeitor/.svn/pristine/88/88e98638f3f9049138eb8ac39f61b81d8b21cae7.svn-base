<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="HorarioFuncionamentos.aspx.vb" Inherits="Pages.Cadastros.HorarioFuncionamentos" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
	<div class='ListArea'>
		<asp:Repeater Runat="server" ID='rptGrid'>
			<HeaderTemplate>
				<table width=100% align=center class="GridHeader">
					<tr>
						<td align=center>00:00</td>
						<td align=center>03:00</td>
						<td align=center>06:00</td>
						<td align=center>09:00</td>
						<td align=center>12:00</td>
						<td align=center>15:00</td>
						<td align=center>18:00</td>
						<td align=center>21:00</td>
						<td align=center>24:00</td>
					</tr>
				</table>
			</HeaderTemplate>
			<ItemTemplate>
				<table width=100% cellpadding=0 cellspacing=0>
					<tr>
						<td width=6%>
						    <asp:ImageButton runat='server' CommandArgument='<%# Eval("IDHorarioFuncionamento") %>' CommandName='Excluir' ImageUrl="~/imagens/Excluir.gif" />
						</td>
						<td width=88%>
							<table width=100% class='TextDefault' align=center border=0 cellpadding=0 cellspacing=0>
								<tr>
									<td align=center width='<%# (DataBinder.Eval(Container.DataItem, "HorarioInicial") * 100 / 2400) %>%'><img src='../imagens/pt.gif'></td>
									<td align=center bgcolor="Red" width='<%# ((DataBinder.Eval(Container.DataItem, "HorarioFinal") - DataBinder.Eval(Container.DataItem, "HorarioInicial")) * 100 / 2400)%>%'>&nbsp;</td>
									<td align=center width='<%# 100 - (DataBinder.Eval(Container.DataItem, "HorarioFinal") * 100 / 2400)%>%'><img src='../imagens/pt.gif'></td>
								</tr>
								<tr>
									<td colspan=3 align=center>
										<%# DataBinder.Eval(Container.DataItem, "Horario")%> das 
										<%# Cint(DataBinder.Eval(Container.DataItem, "HorarioInicial")).toString("00:00")%> at&eacute; as 
										<%# Cint(DataBinder.Eval(Container.DataItem, "HorarioFinal")).toString("00:00")%>
									</td>
								</tr>
							</table>
						</td>
						<td>&nbsp;</td>
					</tr>
				</table>
			</ItemTemplate>
			<SeparatorTemplate>
				<table width=100% class='GridHeader' align=center>
					<tr>
						<td align=center>00:00</td>
						<td align=center>03:00</td>
						<td align=center>06:00</td>
						<td align=center>09:00</td>
						<td align=center>12:00</td>
						<td align=center>15:00</td>
						<td align=center>18:00</td>
						<td align=center>21:00</td>
						<td align=center>24:00</td>
					</tr>
				</table>
			</SeparatorTemplate>
		</asp:Repeater>
	</div>
    <div class='AreaBotoes'>
        <asp:UpdatePanel runat='server' ID='updAdicionar'>
            <ContentTemplate>
                <asp:PlaceHolder runat='server' ID='plhAdicionar' Visible='False'>
	                <table width="100%" id='tblAddHorario'>
		                <tr>
			                <td colspan="2">Descri&ccedil;&atilde;o
				                <asp:RequiredFieldValidator Runat="server" ID='valRequired' ControlToValidate='txtNome' ErrorMessage='Descrição do horário é obrigatório!' Display="None" />
				                <br>
				                <asp:TextBox Runat="server" ID='txtNome' CssClass="Caixa" Width="100%" />
			                </td>
			                <td>Das
				                <asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator1" ControlToValidate='cboInicio' ErrorMessage='Hora de início é obrigatório!' Display="None" />
				                <br>
				                <asp:DropDownList runat="server" ID='cboInicio'></asp:DropDownList>
			                </td>
			                <td>At&eacute;
				                <asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator2" ControlToValidate='cboFinal' ErrorMessage='Hora final é obrigatório!' Display="None" />
				                <br>
				                <asp:DropDownList runat="server" ID="cboFinal"></asp:DropDownList>
			                </td>
		                </tr>
	                </table>
                </asp:PlaceHolder>
		        <asp:Button runat='server' id='btnNovo' cssclass="Botao" Text=" Novo " />
		        <asp:Button runat='server' id='btnGravar' cssclass="Botao" Text=" Gravar " Visible='False' />
		        <asp:Button runat='server' ID='btnCancelar' CssClass="Botao" Text=" Cancelar " Visible='False' CausesValidation='false' />
		        <asp:Button Runat="server" ID="btnApagar" Text='Excluir' CssClass="Botao" CausesValidation="False" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>


