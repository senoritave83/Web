<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="exportacao.aspx.vb" Inherits="integracao_exportacao" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script language="javascript" type="text/javascript">
	
	function __EXPORTACAO(vTipo)
		{
			var _DataInicial, _DataFinal;
            var txtDataInicial = document.getElementById("<%=txtDataInicial.ClientID%>");
            var txtDataFinal = document.getElementById("<%=txtDataFinal.ClientID%>");
            var chkStatus = document.getElementById("<%=chkTransito.ClientID %>");
            
			_DataInicial = txtDataInicial.value;
			_DataFinal = txtDataFinal.value;
			
			if (isDate(_DataInicial) == false){
			    alert("Por favor preencha a data inicial do periodo desejado!");
			    txtDataInicial.focus();
			    return false;
			}
			if (isDate(_DataFinal) == false){
			    alert("Por favor preencha a data final do periodo desejado!");
			    _DataFinal.focus();
			    return false;
			}
			
			var vUrl = 'exportacaodet.aspx?dtini=' + _DataInicial + 
										  '&dtfn=' + _DataFinal;

            
            if (vTipo == 1)
            {
                vUrl += (chkStatus.checked?'&sta=3':'&sta=0');
    			window.open(vUrl, 'ExportacaoDet', 'fullscreen=no,toolbar=no,status=yes,menubar=no,scrollbars=no,resizable=no,directories=no,location=no,width=400,height=250');
            }
			if (vTipo == 2)
			{
			    vUrl = 'exportacaorpt.aspx?dtini=' + _DataInicial + 
										  '&dtfn=' + _DataFinal;

                vUrl += (chkStatus.checked?'&sta=3':'&sta=0');
    			window.open(vUrl, 'ExportacaoRpt', 'fullscreen=no,toolbar=yes,status=yes,menubar=no,scrollbars=no,resizable=yes,directories=no,location=no,width=800,height=600');
            }
            return false;			    			
										  
		}		
	</script>
	<div class='Filtro'>
		<div class='FiltroItem'>
				Data Inicial<br />
				<asp:textbox id="txtDataInicial" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);"
					CssClass="Caixa" Width="100" MaxLength="10" Runat="server"></asp:textbox>
		</div> 
		<div class='FiltroItem'>
				Data Final<br />
				<asp:textbox id="txtDataFinal" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);"
					CssClass="Caixa" Width="100" MaxLength="10" Runat="server"></asp:textbox>
		</div> 
		<div class='FiltroItem' style="width:300px;">
				Exportar apenas pedidos em trânsito<br />
				<asp:CheckBox runat='server' ID='chkTransito' Checked='true' />
		</div> 
		<div class='FiltroBotao'>
			<input class='Botao' visible='True' type="button" name='btnExportar' id='btnExportar' runat="server" onclick="javascript:__EXPORTACAO(1);" value='Gerar Arquivo' title='Exportar os Pedidos armazenados no XMLink' />
			<input class='Botao' type="button" name='btnExportar' id='btnExportar2' runat="server" onclick="javascript:__EXPORTACAO(2);" value='Abrir para impressão' title='Exportar os Pedidos armazenados no XMLink' />
			<input class="Botao" onclick='location.href="default.aspx";' type="button" value="Voltar" />
		</div> 
	</div> 
    <div class='AreaBotoes'>
		<input class="Botao" onclick='location.href="default.aspx";' type="button" value="Voltar" title='Voltar para a tela de configurações' />
    </div> 	
</asp:Content>

