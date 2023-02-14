<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="history.aspx.vb" Inherits="reports_history" %>
<%@ Register assembly="XMReportControls" namespace="XMSistemas.Web.UI.WebControls.ReportControls" tagprefix="xmreports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <xmreports:XMScheduleDataSource ID="XMScheduleDataSource1" runat="server" DataType='History' >
    </xmreports:XMScheduleDataSource>
    <br />
    <br />
	<div class='ListArea'>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns='false' 
            DataSourceID="XMScheduleDataSource1">
            <Columns>
                <asp:BoundField HeaderText='Data' DataField='Data' ItemStyle-Width='140px' />
                <asp:TemplateField HeaderText='Status' ItemStyle-Width='150px' ItemStyle-HorizontalAlign='Center'>
                    <ItemTemplate>
                        <%#GetStatus(Eval("Success"), Eval("DAta"))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText='Mensagem' DataField='Message' />
            </Columns>
        </asp:GridView>
    </div> 
</asp:Content>

