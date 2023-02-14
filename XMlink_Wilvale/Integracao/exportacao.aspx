<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="exportacao.aspx.vb" Inherits="integracao_exportacao" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script language="javascript" type="text/javascript">
	
	function __EXPORTACAO()
		{
		    var filtro = document.getElementById("cboFiltro").value;
			var vUrl = 'exportacaodet.aspx?filtro=' + filtro;
			var win = window.open(vUrl, 'Exportacao', 'fullscreen=no,toolbar=no,status=yes,menubar=no,scrollbars=no,resizable=no,directories=no,location=no,width=400,height=250');
			win.focus();
		}		
	</script>
	<br />
	<br />
        Filtrar por: 
        <select id='cboFiltro'>
            <option value=''>Todos</option>
            <option value='MG'>MG</option>
            <option value='Outros'>Outros estados</option>
        </select>
    <div class='AreaBotoes'>
		<input class="Botao" onclick='location.href="default.aspx";' type="button" value="Voltar" title='Voltar para a tela de configurações' />
		<input class='Botao' type="button" name='btnExportar' id='btnExportar' runat="server" onclick="javascript:__EXPORTACAO();" value='Gerar Arquivo' title='Exportar os Pedidos armazenados no XMLink' />
    </div> 	
</asp:Content>

