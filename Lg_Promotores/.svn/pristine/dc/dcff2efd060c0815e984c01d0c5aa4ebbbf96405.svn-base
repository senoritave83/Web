<%@ Page title="XM Promotores - Yes Mobile" Language="VB" AutoEventWireup="false" CodeFile="rptShowReport.aspx.vb" Inherits="reports_rptShowReport" %>
<%@ Register src="../controls/XMTitulo.ascx" tagname="XMTitulo" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatótios</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="stManager"></asp:ScriptManager>
        <div id='MainArea'>
            <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan='3' class='MainHeader'>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:XMTitulo ID="XMTitulo1" runat="server" Descricao="Gerador automático de relatórios" Titulo="Relatórios" Imagem='~/imagens/logo_default.png' ShowSiteMapPath='false' />
                        <asp:UpdatePanel runat="server" ID="updReport" >
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="pnlWaiting">
                                <table class='tblRelatorioSalvo' align='center' border='0' width='350'>
                                    <tr>
                                        <td rowspan='2'>
                                            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/ajax-loader.gif" alt='Aguarde por favor...' />
                                        </td>
                                     </tr>
                                     <tr>
                                        <td>
                                            <asp:Literal runat="server" id="ltMensagem"></asp:Literal>
                                        </td>
                                     </tr>
                                     <tr runat='server' id='trCancelarExecucao' visible='false'>
                                        <td>&nbsp;</td>
                                        <td style="height:120px;" align='center' width='100%'>
                                            <asp:Button ID='btnCancelar' OnClientClick="return confirm('Deseja realmente cancelar o relatório ?')" Text='Cancelar Execução do Relatório' style="width:300px;" runat='server' />
                                        </td>
                                        <td>&nbsp;</td>
                                     </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlCompleted" Visible="false">
                                <table class='tblRelatorioSalvo' align='center' border='0' width='300'>
                                    <tr>
                                        <td colspan='3'>
                                            <asp:Literal runat="server" id="ltFileLink"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width=100>&nbsp;</td>
                                        <td align=center>
                                            <input style='text-align:center' class='Botao' type='button' value="  Fechar  " onclick="window.close()" />
                                        </td>
                                        <td width=100>&nbsp;</td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlRelCancelado" Visible="false">
                                <table class='tblRelatorioSalvo' align='center' border='0' width='300'>
                                    <tr>
                                        <td colspan='3' align=center>Relatório cancelado</td>
                                    </tr>
                                    <tr>
                                        <td width=100>&nbsp;</td>
                                        <td align=center>
                                            <input style='text-align:center' class='Botao' type='button' value="  Fechar  " onclick="window.close()" />
                                        </td>
                                        <td width=100>&nbsp;</td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                <asp:Timer ID="Timer1" runat="server" Interval="10000"></asp:Timer>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
