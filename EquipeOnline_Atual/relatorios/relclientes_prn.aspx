<%@ Page Language="VB" MasterPageFile="~/Imprimir.master" AutoEventWireup="false" CodeFile="relclientes_prn.aspx.vb" Inherits="relatorios_relclientes_prn"  title="Equipe Online" %>
<%@ Register Assembly="Xceed.Chart.Server, Version=4.2.100.0, Culture=neutral, PublicKeyToken=ba83ff368b7563c6" Namespace="Xceed.Chart.Server" TagPrefix="xceedchart" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cphConteudo" Runat="Server">

        <table width="101%" style="vertical-align:top;" align="left" cellpadding="0" cellspacing="0">
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
				<!-- relat&#65533;rio -->
			</td>
		</tr>
        <tr>
		    <td>
		        <asp:GridView runat='server' ShowFooter='true' ID='grdRelatorio' AutoGenerateColumns='false' Width='100%' CssClass="GridView" >
		            <HeaderStyle CssClass="Header2" />
		            <RowStyle HorizontalAlign='Left' />
		            <FooterStyle Font-Bold='true' />
		            <Columns>
		                <asp:TemplateField HeaderText='Cliente' HeaderStyle-HorizontalAlign="Left">
		                    <ItemTemplate>
                                <%#Eval("Cliente")%>
		                    </ItemTemplate>
		                </asp:TemplateField>
		                <asp:BoundField DataField='Qtd' HeaderText='Qtd' HeaderStyle-HorizontalAlign="Left"/>
		            </Columns>
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

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelp" runat="server">
</asp:Content>
