<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="exportacao.aspx.vb" Inherits="integracao_exportacao" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script language="javascript" type="text/javascript">

    function __EXPORTACAO()
		{			            
			var vUrl = 'exportacaodet.aspx';
			window.open(vUrl, 'ExportacaoDet', 'fullscreen=no,toolbar=no,status=yes,menubar=no,scrollbars=no,resizable=no,directories=no,location=no,width=400,height=250');
            return false;			    													  
		}		
	</script>
	<div class='Filtro'>
		<div class='FiltroBotao'>
			<input class='Botao' visible='True' type="button" name='btnExportar' id='btnExportar' runat="server" onclick="javascript:__EXPORTACAO();" value='Gerar Arquivo' title='Exportar os Pedidos armazenados no XMLink' /><input class="Botao" onclick='location.href="default.aspx";' type="button" value="Voltar" />
		</div> 
	</div> 
    <div class='AreaBotoes'>
		<input class="Botao" onclick='location.href="default.aspx";' type="button" value="Voltar" title='Voltar para a tela de configurações' />
    </div> 	
</asp:Content>

