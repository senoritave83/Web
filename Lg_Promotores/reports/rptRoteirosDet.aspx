<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptRoteirosDet.aspx.vb" Inherits="reports_rptRoteirosDet" %>
<%@ Register Assembly="XMCrossRepeater" Namespace="XMSistemas.Web.UI.WebControls"    TagPrefix="xm" %>
<xhtml>
<html>
    <head id="Head1" runat="SERVER"></head>
    <style>
        #ColTit
        {
            
        }
    </style>
<body>
<asp:Literal runat='server' ID='ltrMessage' EnableViewState='false' />
<table border='1'>
    
    <asp:Repeater runat='server' ID='rptRelatorio'>
       
       <HeaderTemplate>
            <tr>
                <td style='background-color:Red;color:White;width:200px'>Loja</td>
                <td style='background-color:Red;color:White;width:200px'>CNPJ</td>
                <td style='background-color:Red;color:White;width:200px'>Coordenador</td>
                <td style='background-color:Red;color:White;width:200px'>Líder</td>
                <td style='background-color:Red;color:White;width:200px'>Promotor</td>                    
                <td style='background-color:Red;color:White;width:200px'>Razão Social</td>
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
                <td style='background-color:Red;color:White;width:200px'>Data</td>
                <td style='background-color:Red;color:White;width:200px'>Entrada</td>
                <td style='background-color:Red;color:White;width:200px'>Saída</td>
                <td style='background-color:Red;color:White;width:200px'>Almoço Entrada</td>
                <td style='background-color:Red;color:White;width:200px'>Almoço Saída</td>
            </tr>
       </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Loja")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("CNPJ")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Coordenador")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Lider")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("Promotor")& "")%></td>
                <td><%#Server.HtmlEncode(Container.DataItem.Item("RazaoSocial")& "")%></td>
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
                <td style='background-color:#E0FFFF'>
                    <%#Format(Container.DataItem.Item("Data"), "dd/MM/yyyy")%>
                </td>
            <asp:PlaceHolder runat='server' ID='plhNormal' Visible='<%# NOT Container.DataItem.Item("Folga") %>'>
                <td style='background-color:#F5F5A0'><%#Container.DataItem.Item("HoraInicio")%></td>
                <td style='background-color:#F5F5A0'><%#Container.DataItem.Item("HoraFim")%></td>
                <td style='background-color:#F5F5A0'><%# IIf(Container.DataItem.Item("HoraAlmocoInicio") = "", "", Container.DataItem.Item("HoraAlmocoInicio"))%></td>
                <td style='background-color:#F5F5A0'><%# IIf(Container.DataItem.Item("HoraAlmocoFim") = "", "", Container.DataItem.Item("HoraAlmocoFim"))%></td>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat='server' ID='pnlFolga' Visible='<%# Container.DataItem.Item("Folga") %>'>
                <td style='background-color:Lime' colspan='4'><%# Container.DataItem.Item("MotivoAusencia")%></td>
            </asp:PlaceHolder>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<table border='0'>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="border:1px solid black" colspan='3'>Legenda</td>
    </tr>
    <tr>
        <td style='border:1px solid black;background-color:#E0FFFF'>Dias da Semana</td>
        <td style='border:1px solid black;background-color:#F5F5A0'>Horário da Visita</td>
        <td style='border:1px solid black;background-color:#CCFFCC'>Folga</td>
    </tr>
</table>
</body>
</html>
</xhtml>