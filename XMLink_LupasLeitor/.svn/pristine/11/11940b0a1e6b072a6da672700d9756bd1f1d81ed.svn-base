<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Relat.aspx.vb" Inherits="Relat_Relatorios" %>

<%@ Register assembly="XMReportControls" namespace="XMSistemas.Web.UI.WebControls.ReportControls" tagprefix="xmreports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellpadding="1" cellspacing="1">
	    <tr valign="middle" runat='server' id='trTopo'>
		    <td>
			    <img border="0" runat="server" id='imgImagem' alt="" src="~/imagens/reports.gif" />
		    </td>
		    <td width="100%">
			    <asp:Label Runat="server" ID='lblTituloRelatorio' SkinID='XMTitulo.Titulo'></asp:Label><br/>
			    <img src='../imagens/pt.gif' id='imgLinha' alt="" /><br/>
			    <asp:Label Runat="server" ID='lblDescricao' SkinID='XMTitulo.Descricao'></asp:Label>
		    </td>
	    </tr>
    </table>
    <xmreports:XMReportFilters ID="XMReportFilters1" runat="server" CssClass='XMReportFilters'>
    </xmreports:XMReportFilters>
    <asp:Button runat='server' ID='btnVisualizar' Text='Visualizar' />
    <asp:Button runat='server' ID='btnAgendar' Text='Agendar' />
    <asp:Button runat='server' ID='btnVoltar' Text='Voltar' Visible='false' CausesValidation='false'  />
    <asp:Button runat='server' ID='btnListagemRelatorios' Text='Listagem de Relatórios' Visible='true' CausesValidation='false' style="width:200px;" />
    <asp:Button runat='server' ID='btnGravar' Text='Gravar' Visible='false' />
</asp:Content>