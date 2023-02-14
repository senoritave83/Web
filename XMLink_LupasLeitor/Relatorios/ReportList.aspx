<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ReportList.aspx.vb" Inherits="Relatorios_ReportList" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="XMReportControls" namespace="XMSistemas.Web.UI.WebControls.ReportControls" tagprefix="xmreports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel runat='server' ID='pnlNavigate'>
    <div Style="width:99%;background-color:#EFF3FB;border-color:#6699cc;border-style:solid;border-width:thin; margin-bottom:10px;padding: 10px 10px 10px 20px;">
        <div class='FiltroItem'><b>Relat&oacute;rios dispon&iacute;veis</b><br>
            </div> <br class='cb' />
        <div class='FiltroBotao'>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="XMReportDataSource1" EnableModelValidation="True" AutoGenerateColumns='false'>
                <Columns>
                    <asp:TemplateField HeaderStyle-BackColor="#EFF3FB">
                        <ItemTemplate>
                            <a href='relat.aspx?path=<%# Server.HtmlEncode(EVal("Path")) %>'><%# Eval("Name")%></a>
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
    <div class='FiltroBotao'>
        <input runat='server' type='button' ID='btnRelatoriosAgendados' Class="Botao" onclick="location.href='schedule.aspx'" Value="Relatórios Agendados" alt='Exibe os relatório agendados' />
    </div>
</asp:Content>

