<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="VendedorRoteiros.aspx.vb" Inherits="Pages.Roteiros.VendedorRoteiros" title="" %>

<%@ Register Src="../controls/VerRoteiro.ascx" TagName="VerRoteiro" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr>
				<td>
					<h2>Vendedor:</h2><h5><asp:Label runat='server' ID='lblVendedor' /></h2>
				</td>
			</tr>
		</table>
	</div>
	<div class='ListArea'>
	    <asp:Panel runat='server' ID='pnlRoteiros'>
		    <asp:Repeater runat='server' id='rptRoteiros'>
		        <ItemTemplate>
		            <asp:Panel runat='Server' ID='pnlRoteiro' CssClass='VerRoteiro'>
		                <table>
		                    <tr>
		                        <td>
            		                <b>Roteiro: </b><%# Eval("IDRoteiro") %>
		                        </td>
		                        <td width='200px;' align='right'>
		                            <b>Status: </b><%#IIf(Eval("Ativo"), "sim", "n&atilde;o")%>
		                        </td>
		                    </tr>
		                    <tr>
		                        <td>
                		            <uc2:VerRoteiro ID="VerRoteiro1" runat="server" Dia='<%# Eval("Dia") %>' Mes='<%# Eval("Mes") %>' DiaSemana='<%# Eval("DiaSemana") %>'  />
		                        </td>
		                        <td align='right'>
		                            <input type='button' value=' Editar ' style="float:right;margin-right:0px" class='Botao' onclick='location.href="roteiro.aspx?idvendedor=<%# Eval("IDVendedor") %>&idroteiro=<%# Eval("IDRoteiro") %>";' />
		                            <asp:Button runat='server' ID='btnApagar' CommandArgument='<%# Eval("IDRoteiro") %>' CommandName='Apagar' style="float:right;margin-right:0px" cssclass='Botao' Text='Apagar' Visible='<%# Me.User.IsInRole("Supervisor de Cadastro")%>' />
		                        </td>
		                    </tr>
		                </table>
		                <br />
		                <asp:GridView runat='server' ID='dtgLojas' SkinID='GridInterno' Width='95%' DataSource='<%# GetLojasRoteiro(Eval("IDRoteiro")) %>' AutoGenerateColumns='false'>
		                    <HeaderStyle HorizontalAlign='Left' />
		                    <Columns>
                                <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                <asp:BoundField HeaderText='Cliente' DataField='Cliente' />
                            </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; clientes cadastradas neste roteiro!
                            </EmptyDataTemplate>
		                </asp:GridView>
		            </asp:Panel>
		        </ItemTemplate>
		    </asp:Repeater>
            <br />
	    </asp:Panel>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnAddRoteiro' Text='Adicionar roteiro' />
        <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
</asp:Content>

