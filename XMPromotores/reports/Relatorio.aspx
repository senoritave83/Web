<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Relatorio.aspx.vb" Inherits="reports_Relatorio" %>

<%@ Register assembly="XMReportControls" namespace="XMSistemas.Web.UI.WebControls.ReportControls" tagprefix="xmreports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<div class="Filtro" style="height:150px;">
            <xmreports:XMReportFilters ID="XMReportFilters1" runat="server" CssClass='XMReportFilters'>
            </xmreports:XMReportFilters>
            <asp:Button runat='server' ID='btnVisualizar' Text='Visualizar' />
            <asp:Button runat='server' ID='btnAgendar' Text='Agendar' />
            <asp:Button runat='server' ID='btnVoltar' Text='Voltar' Visible='false' CausesValidation='false'  />
            <asp:Button runat='server' ID='btnListagemRelatorios' Text='Listagem de Relatórios' Visible='true' CausesValidation='false' style="width:200px;" />
            <asp:Button runat='server' ID='btnGravar' Text='Gravar' Visible='false' />
        </div>    
</asp:Content>

