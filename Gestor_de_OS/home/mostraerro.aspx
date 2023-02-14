<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="mostraerro.aspx.vb" Inherits="home_mostraerro" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    												<table width="100%" cellpadding="3" cellspacing="0" height='200px'>
													<tr>
														<td width="31" valign="top"><img src='../images/erro.gif'></td>
														<td align="center">
															<b><font face='Verdana' color="#990000">Ocorreu um erro no sistema!</font></b>
														</td>
														<td width="31">&nbsp;</td>
													</tr>
													<tr>
														<td align="center" colspan="3">
															<asp:Label Runat="server" ID='lblMessage' CssClass="TextDefault" />
														</td>
													</tr>
													<tr>
														<td align="right" colspan="3">
															<asp:HyperLink Runat="server" ID='lnkError' CssClass='TextDefault' NavigateUrl='faq.aspx?id=1'>[Saiba Mais]</asp:HyperLink>
														</td>
													</tr>
													<tr>
														<td colspan="3" align="center">
															<asp:Button Runat="server" ID='btnVoltar' Text=' OK ' CssClass="Botao" />
														</td>
													</tr>
												</table>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

