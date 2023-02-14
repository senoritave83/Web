<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="reportlist.aspx.vb" Inherits="reports_reportlist" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="XMReportControls" namespace="XMSistemas.Web.UI.WebControls.ReportControls" tagprefix="xmreports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel runat='server' ID='pnlNavigate'>
    <div class='Filtro'>
        <div class='FiltroItem'>Relat&oacute;rios dispon&iacute;veis<br>
            </div> <br class='cb' />
        <div class='FiltroOpcaoRelatorio'>
            <asp:Button runat='server' ID='btnVisualizar' Text='Visualizar' Visible='false' />
            <asp:GridView ID="GridView1" runat="server" DataSourceID="XMReportDataSource1" 
                EnableModelValidation="True"
                AutoGenerateColumns='false'
                >
                <Columns>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <a href='relatorio.aspx?path=<%# Server.HtmlEncode(EVal("Path")) %>'><%# Eval("Name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>	
    </asp:Panel>
    <asp:Panel runat='server' ID='pnlErro' Visible='False'>
        <p style='margin-top:30px;'>
            <asp:Label runat='server' ID='lblError'>Não foi possível conectar-se ao servidor de relatórios.</asp:Label>
            <asp:Literal runat='server' ID='ltrSource'></asp:Literal>
        </p>
    </asp:Panel>
    <xmreports:XMReportDataSource ID="XMReportDataSource1" runat="server">
    </xmreports:XMReportDataSource>
</asp:Content>

