<%@ Page EnableTheming="false" Language="VB" AutoEventWireup="false" CodeFile="rptLojasPromotoresDet.aspx.vb" Inherits="reports_rptLojasPromotoresDet" %>
<%@ Register Assembly="XMCrossRepeater" Namespace="XMSistemas.Web.UI.WebControls"    TagPrefix="xm" %>
<xhtml>
<html>
    <head runat="SERVER"></head>
    <style>
        #ColTit
        {
            
        }
    </style>
<body>
<asp:Literal runat='server' ID='ltrMessage' EnableViewState='false' />
<table border='1'>
<xm:XMCrossRepeater ID="xmCrossRptRoteiros" runat="server">
    <TopTemplates>
        <xm:XMCrossRepeaterTopTemplate>
            <TopLeftTemplate>
                <tr>
                    <td style='background-color:Red;color:White;width:200px'>Loja</td>
                    <td style='background-color:Red;color:White;width:200px'>Coordenador</td>
                    <td style='background-color:Red;color:White;width:200px'>Líder</td>
                    <td style='background-color:Red;color:White;width:200px'>Promotor</td>                    
                    <td style='background-color:Red;color:White;width:200px'>Razão Social</td>
                    <td style='background-color:Red;color:White;width:200px'>CNPJ</td>
                    <td style='background-color:Red;color:White;width:200px'>Endereço</td>
                    <td style='background-color:Red;color:White;width:50px'>Número</td>
                    <td style='background-color:Red;color:White;width:200px'>Complemento</td>
                    <td style='background-color:Red;color:White;width:200px'>Cep</td>
                    <td style='background-color:Red;color:White;width:200px'>Bairro</td>
                    <td style='background-color:Red;color:White;width:200px'>Cidade</td>
                    <td style='background-color:Red;color:White;width:50px'>UF</td>
                    <td style='background-color:Red;color:White;width:200px'>Segmento</td>
                    <td style='background-color:Red;color:White;width:200px'>Tipo de Loja</td>
                    <td style='background-color:Red;color:White;width:200px'>Local</td>
                    <td style='background-color:Red;color:White;width:200px'>Shopping</td>
            </TopLeftTemplate>
            <ColHeaderTemplate>
                    <td style='background-color:Red;color:White;' colspan='4'>
                        <%# getDayName(DatePart(DateInterval.Weekday, Container.DataItem.Item("Data")))%>&nbsp;
                        <%#Format(Container.DataItem.Item("Data"), "dd/MM/yyyy")%>
                    </td>
            </ColHeaderTemplate>
            <TopRightTemplate>
                    <td>&nbsp;</td>
                </tr>
            </TopRightTemplate>
        </xm:XMCrossRepeaterTopTemplate>
    </TopTemplates>
    <RowTemplate>
       <RowHeaderTemplate>
            <tr>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Loja")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Coordenador")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Lider")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Promotor")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("RazaoSocial")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("CNPJ")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Endereco")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Numero")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Complemento")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Cep")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Bairro")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Cidade")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("UF")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Segmento")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("TipoLoja")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Local")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Shopping")& "")%></td>
       </RowHeaderTemplate>
       <ItemTemplate>
            <asp:PlaceHolder runat='server' ID='plhNormal' Visible='<%# NOT Container.DataItem.Item("Folga") %>'>
			    <td style='background-color:#F5F5A0'>Entrada:&nbsp;<%# Container.DataItem.Item("HoraInicio")%></td>
                <td style='background-color:#F5F5A0'>Saída:&nbsp;<%# Container.DataItem.Item("HoraFim")%></td>
                <td style='background-color:#F5F5A0'><%# IIf(Container.DataItem.Item("HoraAlmocoInicio") = "", "", "Almoço Entrada:&nbsp;" & Container.DataItem.Item("HoraAlmocoInicio"))%></td>
                <td style='background-color:#F5F5A0'><%# IIf(Container.DataItem.Item("HoraAlmocoFim") = "", "", "Almoço Saída:&nbsp;" & Container.DataItem.Item("HoraAlmocoFim"))%></td>   		
            </asp:PlaceHolder>
            <asp:PlaceHolder runat='server' ID='pnlFolga' Visible='<%# Container.DataItem.Item("Folga") %>'>
                <td style='background-color:Lime' colspan='4'><%# Container.DataItem.Item("MotivoAusencia")%></td>
            </asp:PlaceHolder>
       </ItemTemplate>
       <EmptyItemTemplate>
                <td <%# IIF(VerificaDiaFolga(Format(Container.DataItem("Data"), "ddMMyyyy"), Container.DataItem("IdPromotor"))=True, "style='background-color:#CCFFCC'", "")%>>&nbsp;</td>
                <td <%# IIF(VerificaDiaFolga(Format(Container.DataItem("Data"), "ddMMyyyy"), Container.DataItem("IdPromotor"))=True, "style='background-color:#CCFFCC'", "")%>>&nbsp;</td>
                <td <%# IIF(VerificaDiaFolga(Format(Container.DataItem("Data"), "ddMMyyyy"), Container.DataItem("IdPromotor"))=True, "style='background-color:#CCFFCC'", "")%>>&nbsp;</td>
                <td <%# IIF(VerificaDiaFolga(Format(Container.DataItem("Data"), "ddMMyyyy"), Container.DataItem("IdPromotor"))=True, "style='background-color:#CCFFCC'", "")%>>&nbsp;</td>
       </EmptyItemTemplate>
       <RowFooterTemplate>
                <td>&nbsp;</td>
            </tr>
       </RowFooterTemplate>
    </RowTemplate>
</xm:XMCrossRepeater>
</table>
<table border='0'>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="border:1px solid black" colspan='2'>Legenda</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#F5F5A0'>Horário da Visita</td>
        <td style='border:1px solid black;background-color:#CCFFCC'>Folga</td>
    </tr>
</table>
</body>
</html>
</xhtml>