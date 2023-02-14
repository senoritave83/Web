<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="performancelog_det.aspx.vb" Inherits="Relatorios_performancelog_det" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:Repeater runat='server' ID='grdRelatorio'>
	        <HeaderTemplate>
                <div class="scrollTableContainer">
                <table class="dataTable" cellspacing="0" cellpadding="4" border="1" style="border-style:None;width:100%;border-collapse:collapse;">
                    <thead>
		                <tr class="GridHeader" align="left">
			                <th scope="col">&#160;Placa - Rota</th>
			                <th scope="col">Performance </th>
			                <th align="center" scope="col">Progr</th>
			                <th align="center" scope="col"> Real.</th>
			                <th align="center" scope="col">Receb</th>
			                <th align="center" scope="col">Não Entreg</th>
			                <th align="right" scope="col"> R$</th>
			                <th align="right" scope="col"> Cheq</th>
			                <th align="right" scope="col"> Bol</th>
			                <th align="right" scope="col"> Valor NF</th>
		                </tr>
		            </thead>
		            <tbody>
	        </HeaderTemplate>
	        <ItemTemplate>
                <tr style="background-color:White;">
			        <td style="white-space:nowrap;"><%#Eval("PlacaRota") & "&nbsp;-&nbsp;" & FormataPasta(Eval("Pasta") & "")%></td>
			        <td style="height:20px;width:200px;"><uc1:progresso ID="progresso1" runat="server" MaxValue='<%# Eval("Previsto") %>'  Value='<%# Eval("Realizado") %>' SecondValue='0' /></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("Previsto"), "Previsto"), 0)%></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("Realizado"), "Realizado"), 0)%></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("Entregue"), "Entregue"), 0)%></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("NaoEntregue"), "NaoEntregue"), 0)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("Dinheiro"), "Dinheiro"), 2)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("Cheque"), "Cheque"), 2)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("Boleto"), "Boleto"), 2)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("ValorNF"), "ValorNF"), 2)%></td>
                </tr>	    
	        </ItemTemplate>
	        <AlternatingItemTemplate>
                <tr style="background-color:#EFF3FB;">
                    <td style="white-space:nowrap;"><%#Eval("PlacaRota") & "&nbsp;-&nbsp;" & FormataPasta(Eval("Pasta") & "")%></td>
			        <td style="height:20px;width:200px;"><uc1:progresso ID="progresso1" runat="server" MaxValue='<%# Eval("Previsto") %>'  Value='<%# Eval("Realizado") %>' SecondValue='0' /></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("Previsto"), "Previsto"), 0)%></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("Realizado"), "Realizado"), 0)%></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("Entregue"), "Entregue"), 0)%></td>
			        <td align="center"><%#FormatNumber(Soma.Add(Eval("NaoEntregue"), "NaoEntregue"), 0)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("Dinheiro"), "Dinheiro"), 2)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("Cheque"), "Cheque"), 2)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("Boleto"), "Boleto"), 2)%></td>
			        <td align="right"><%#FormatCurrency(Soma.Add(Eval("ValorNF"), "ValorNF"), 2)%></td>
                </tr>	    
	        </AlternatingItemTemplate>
	        <FooterTemplate>
		            </tbody>
		            <tfoot>
                        <tr class="GridHeader">
			                <td>Total</td>
			                <td>&nbsp;</td>
			                <td align="center"><%#FormatNumber(Soma.Item("Previsto").Sum, 0)%></td>
			                <td align="center"><%#FormatNumber(Soma.Item("Visitas").Sum, 0)%></td>
			                <td align="center"><%#FormatNumber(Soma.Item("Entregue").Sum, 0)%></td>
			                <td align="center"><%#FormatNumber(Soma.Item("NaoEntregue").Sum, 0)%></td>
			                <td align="right"><%#FormatCurrency(Soma.Item("Dinheiro").Sum, 2)%></td>
			                <td align="right"><%#FormatCurrency(Soma.Item("Cheque").Sum, 2)%></td>
			                <td align="right"><%#FormatCurrency(Soma.Item("Boleto").Sum, 2)%></td>
			                <td align="right"><%#FormatCurrency(Soma.Item("ValorNF").Sum, 2)%></td>
		                </tr>
		            </tfoot>
	                </table>
	                </div>
		        </FooterTemplate>
	    </asp:Repeater>
</asp:Content>

