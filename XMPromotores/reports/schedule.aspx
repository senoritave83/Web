<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="schedule.aspx.vb" Inherits="reports_schedule" %>

<%@ Register assembly="XMReportControls" namespace="XMSistemas.Web.UI.WebControls.ReportControls" tagprefix="xmreports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<xmreports:XMScheduleDataSource ID="XMScheduleDataSource1" runat="server">
    </xmreports:XMScheduleDataSource>
    <xmreports:XMReportDataSource ID="XMReportDataSource1" runat="server">
    </xmreports:XMReportDataSource>
    <br />
    <br />
    <div class='Filtro'>
            <div class='FiltroItem'>Relat&oacute;rio:<br/>
                <asp:DropDownList ID="cboNomeRelatorio" runat="server" DataTextField="Name" DataValueField="Name" />
            </div>
            <div class='FiltroItem'>&Uacute;ltima execu&ccedil;&atilde;o:<br/>
                <asp:DropDownList ID="cboStatusExecucao" runat="server" >
                    <asp:ListItem Text="Todos" Value="2" Selected="True" />
                    <asp:ListItem Text="Erro na execu&ccedil;&atilde;o" Value="0" />
                    <asp:ListItem Text="Executado com sucesso" Value="1" />
                </asp:DropDownList>
            </div>
		    <div class='FiltroBotao'>
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" />
            </div>
    </div>
	<div class='ListArea'>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns='false' 
                    EnableModelValidation="True" DataKeyNames='IDSchedule' CellPadding="1" CellSpacing="1">
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
                        <div class="divEmptyRow">N&atilde;o h&aacute; relat&oacute;rios agendados com o filtro selecionado!</div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div> 
</asp:Content>

