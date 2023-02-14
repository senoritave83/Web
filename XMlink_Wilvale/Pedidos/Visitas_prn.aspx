<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visitas_prn.aspx.vb" Inherits="Visitas_Visitas_prn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório de Visitas <%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %></title>
</head>
<body>
    <script>
        window.print();
    </script>
    <form id="form1" runat="server">
    <asp:Label ID="lblError" runat="server" Text="" style="font-size:18px; color:Red; font-style:italic;" />
    <div id="divBody" runat='server'>
        <div id='MainArea'>
            <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width='20%' align='center'><img src='../imagens/LogoXM.jpg' border='0' /></td>
                    <td class='MainHeader' align='right'>
                        <img src="../imagens/Logo_small.png" border='0' />
                    </td>
                </tr>
            </table>
        </div>
        <div class='ListArea'>
            <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false'>
			    <HeaderStyle/>
			    <columns>
                    <asp:BoundField HeaderText="Visita" DataField="IDVisita" HeaderStyle-HorizontalAlign='left' />
					<asp:BoundField HeaderText="Cliente" DataField="Cliente" HeaderStyle-HorizontalAlign='left' />
					<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" HeaderStyle-HorizontalAlign='left' />
					<asp:BoundField HeaderText="Data" DataField="Data" HeaderStyle-HorizontalAlign='left' />
					<asp:BoundField HeaderText="Justificativa" DataField="Justificativa" HeaderStyle-HorizontalAlign='left' />
			    </columns>
			    <EmptyDataTemplate>
				    <div class='GridHeader'>&nbsp;</div>					    
				    <div class='divEmptyRow'>
					    <asp:Label runat='server' ID='lblNaoEncontrados'>
						    N&atilde;o h&aacute; Visitas com o filtro selecionado!
					    </asp:Label>
				    </div>
			    </EmptyDataTemplate>
		    </asp:GridView>
        </div>
        <div>
            <asp:Label runat="server" ID="lblQtdRegistros" Font-Bold="true" />
        </div>
        <div style="width:100%;" id='MainFooter'>&copy;<%=Year(now)%> XM Sistemas Distribu&iacute;dos Ltda. Todos os direitos reservados.</div>
    </div>
    </form>
</body>
</html>
