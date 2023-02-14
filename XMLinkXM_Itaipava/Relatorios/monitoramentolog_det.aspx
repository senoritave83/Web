<%@ Page Title="" Language="VB" MasterPageFile="~/Relatorios/relatorio.master" AutoEventWireup="false" CodeFile="monitoramentolog_det.aspx.vb" Inherits="Relatorios_monitoramentolog_det" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphRelatorio" Runat="Server">
	<asp:Repeater runat='server' ID='grdRelatorio' EnableViewState='false'>
	    <HeaderTemplate>
            <div class="scrollTableContainer">
            <table class="dataTable" cellspacing="0" cellpadding="4" border="0" style="border-style:None;width:100%;border-collapse:collapse;">
                <thead>
		            <tr class="GridHeader" align="left">
			            <th align="left" scope="col">&#160;Veículo</th>
			            <th align="center" scope="col">Rota</th>
			            <th align="center" scope="col">Nota Fiscal</th>
			            <th align="center" scope="col">Valor NF</th>
			            <th align="left" scope="col">Sit. Entrega</th>
			            <th align="left" scope="col">Situação Atual</th>
			            <th scope="col" align="left">Motorista</th>
			            <th align="center" scope="col">Data / Hora</th>
			            <th align="left" scope="col">Site Local</th>
		            </tr>
		        </thead>
		        <tbody>
	    </HeaderTemplate>
	    <ItemTemplate>
            <tr style="background-color:White;">
			    <td style="white-space:nowrap;" align='left'><%#Eval("Veiculo")%></td>
                <td style="white-space:nowrap;" align='center'><%#Eval("Rota")%></td>
                <td style="white-space:nowrap;" align='center'><%#Eval("NotaFiscal")%></td>
                <td style="white-space:nowrap;" align="center" ><%#FormatCurrency(Eval("ValorNF"), 2)%></td>
                <td style="white-space:nowrap;" align='left'><%#Eval("CondicaoRec")%></td>
                <td style="white-space:nowrap;" align='left'><%#Eval("Situacao")%></td>
                <td style="white-space:nowrap;" align="left"><%#Eval("Motorista")%></td>
                <td style="white-space:nowrap;" align='center'><%#Eval("Data") & IIf(Eval("HoraInicio") <> "", "<br>" & Eval("HoraInicio"), "") & IIf(Eval("HoraFim") <> "", "<br>" & Eval("HoraFim"), "")%></td>
                <td style="white-space:nowrap;" align='left'><a href='#' onclick="verMapa('<%#Eval("LatitudeInicio")%>', '<%#Eval("LongitudeInicio")%>', 'Localização', 'Mapa Início');">Mapa Início</a><br />
                                                                <a href='#' onclick="verMapa('<%#Eval("LatitudeInicio")%>', '<%#Eval("LongitudeFim")%>', 'Localização', 'Mapa Fim');">Mapa Fim</a></td>
            </tr>	    
	    </ItemTemplate>
	    <AlternatingItemTemplate>
            <tr style="background-color:#EFF3FB;">
			    <td style="white-space:nowrap;" align='left'><%#Eval("Veiculo")%></td>
                <td style="white-space:nowrap;" align='center'><%#Eval("Rota")%></td>
                <td style="white-space:nowrap;" align='center'><%#Eval("NotaFiscal")%></td>
                <td style="white-space:nowrap;" align="center" ><%#FormatCurrency(Eval("ValorNF"),2)%></td>
                <td style="white-space:nowrap;" align='left'><%#Eval("CondicaoRec")%></td>
                <td style="white-space:nowrap;" align='left'><%#Eval("Situacao")%></td>
                <td style="white-space:nowrap;" align="left"><%#Eval("Motorista")%></td>
                <td style="white-space:nowrap;" align='center'><%#Eval("Data") & IIf(Eval("HoraInicio") <> "", "<br>" & Eval("HoraInicio"), "") & IIf(Eval("HoraFim") <> "", "<br>" & Eval("HoraFim"), "")%></td>
                <td style="white-space:nowrap;" align='left'><a href='#' onclick="verMapa('<%#Eval("LatitudeInicio")%>', '<%#Eval("LongitudeInicio")%>', 'Localização', 'Mapa Início');">Mapa Início</a><br />
                                                                <a href='#' onclick="verMapa('<%#Eval("LatitudeInicio")%>', '<%#Eval("LongitudeFim")%>', 'Localização', 'Mapa Fim');">Mapa Fim</a></td>
            </tr>	    
	    </AlternatingItemTemplate>
	    <FooterTemplate>
		        </tbody>
	            </table>
	            </div>
		    </FooterTemplate>
	</asp:Repeater>
</asp:Content>

