<%@ Page Title="" Language="VB" MasterPageFile="~/Imprimir.master" AutoEventWireup="false" CodeFile="relperiodo_prn.aspx.vb" Inherits="relatorios_relperiodo_prn" %>
<%@ Register Assembly="Xceed.Chart.Server, Version=4.2.100.0, Culture=neutral, PublicKeyToken=ba83ff368b7563c6" Namespace="Xceed.Chart.Server" TagPrefix="xceedchart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHelp" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" Runat="Server">
<table width="94%" border="0" align="left" cellpadding="0" cellspacing="0">
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>
        <tr class='Header2' align='left'> 
            <td>
                <asp:Literal runat=server ID='ltTitulo'></asp:Literal>&nbsp;<%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %>
            </td>
        </tr> 
		<tr valign="top" runat="server" id="repRow" visible="false" >
			<td align="center">
				<!-- relatório -->
			</td>
		</tr>
        <tr valign="top">
		    <td>
		        <asp:GridView runat='server' ShowFooter='true' ID='grdRelatorio' AutoGenerateColumns='true' Width='100%' CssClass="GridView">
		            <HeaderStyle CssClass="Header2" HorizontalAlign='Left' />
		            <RowStyle HorizontalAlign='Left' />
		            <FooterStyle Font-Bold='true' />
		        </asp:GridView>
		    </td>
	    </tr>
        <tr valign="top">
		    <td align="center">
                <xceedchart:ChartServerControl ID="chartEOL" runat="server"></xceedchart:ChartServerControl>
		    </td>
	    </tr>
        <tr class='Footer1'> 
            <td>
                <img width="1" height="25" src="../images/transpa.gif" />
            </td>
        </tr>							
    </table>
</asp:Content>

