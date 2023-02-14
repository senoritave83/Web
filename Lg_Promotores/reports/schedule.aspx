<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="schedule.aspx.vb" Inherits="reports_schedule" %>

<%@ Register assembly="XMReportControls" namespace="XMSistemas.Web.UI.WebControls.ReportControls" tagprefix="xmreports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <xmreports:XMScheduleDataSource ID="XMScheduleDataSource1" runat="server">
    </xmreports:XMScheduleDataSource>
    <br />
    <br />
	<div class='ListArea'>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns='false' 
            DataSourceID="XMScheduleDataSource1" EnableModelValidation="True" DataKeyNames='IDSchedule'>
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="IDSchedule" DataNavigateUrlFormatString="relatorio.aspx?idschedule={0}" DataTextField="Name" HeaderText="Nome" ItemStyle-Width='150px'  />
                <asp:BoundField DataField='ReportName' HeaderText='Relatório' ItemStyle-Width='150px' />
                <asp:BoundField DataField='Execution' HeaderText='Execução'/>
                <asp:TemplateField HeaderText='Última execução' ItemStyle-Width='200px' ItemStyle-HorizontalAlign='Center'>
                    <ItemTemplate>
                        <a href='history.aspx?idschedule=<%#Eval("IDSchedule") %>'><%# GetStatus(Eval("LastStatus"), Eval("LastExecution"))%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType='Link' DeleteText='Excluir' ShowEditButton='false' ShowDeleteButton='true' />
             </Columns>
            <EmptyDataTemplate>
                N&atilde;o h&aacute; relat&oacute;rios agendados
            </EmptyDataTemplate>
        </asp:GridView>
    </div> 
</asp:Content>

