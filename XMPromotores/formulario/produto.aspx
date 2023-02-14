<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" ValidateRequest='False' CodeFile="produto.aspx.vb" Inherits="formulario_produto" title="XM Promotores - Yes Mobile" %>

<%@ Register src="../controls/pergunta.ascx" tagname="pergunta" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class='EditArea'>
        <table id='tblEditArea' border="0">
            <tr class="trEditHeader">
                <td colspan='2'>&nbsp;</td>
            </tr>
            <tr class='trField'>
	            <td class='tdFieldHeader'>
		            Promotor:
	            </td>
	           <td class='tdField'>
	                <asp:Label runat='server' ID='lblPromotor' />        
	           </td>
	        </tr>
            <tr class='trField'>
	            <td class='tdFieldHeader'>
		            Loja:
	            </td>
	           <td class='tdField'>
	                <asp:Label runat='server' ID='lblLoja' />
	           </td>
	        </tr>
            <tr class='trField'>
	            <td class='tdFieldHeader'>
		            Data:
	            </td>
	           <td class='tdField'>
	                <asp:Label runat='server' ID='lblData' />
	           </td>
	        </tr>
            <tr class='trField'>
	            <td class='tdFieldHeader'>
		            Produto:
	            </td>
	           <td class='tdField'>
	                <asp:Label runat='server' ID='lblProduto' />
	           </td>
	        </tr>
	    </table>
	</div> 
	
	<div id='FormularioVisita'>

	            <div style="height:300px">
	                <asp:Panel runat='server' ID='pnlInicio'>
                        <asp:Label runat='server' ID='lblTexto'></asp:Label>
	                </asp:Panel>
	                <asp:Panel runat='server' ID='pnlEncontrado' Visible='false'>
	                    Produto encontrado?
	                    <br />
	                    <asp:RadioButton runat='server' ID='chkNao' Text='Não' GroupName='Encontrado' /><br />
	                    <asp:RadioButton runat='server' ID='chkSim' Text='Sim' GroupName='Encontrado' />
	                </asp:Panel>
	                <asp:Panel runat='server' ID='pnlPreco'>
	                    <asp:PlaceHolder runat='server' ID='plhPrecoSugerido'>Preço sugerido: <asp:Label runat='server' ID='lblPrecoSugerido' /> <br /></asp:PlaceHolder>
	                    <asp:PlaceHolder runat='server' ID='plhPrecoMinimo'>Preço Mínimo: <asp:Label runat='server' ID='lblPrecoMin' /><br /></asp:PlaceHolder>
	                    <asp:PlaceHolder runat='server' ID='plhPrecoMaximo'>Preço Máximo: <asp:Label runat='server' ID='lblPrecoMax' /><br /></asp:PlaceHolder>
	                    <br />
                        Informe o preço<br />
                        <asp:TextBox runat='server' ID='txtPreco' />
	                </asp:Panel>
	                <asp:Panel runat='server' ID='pnlEstoque'>
	                    Visualizou Estoque? <br />
	                    <asp:RadioButton runat='server' ID='chkVisualizouSim' Text='Sim' GroupName='Visualizou' AutoPostBack='true' /><br />
	                    <asp:RadioButton runat='server' ID='chkVisualizouNao' Text='Não' GroupName='Visualizou' AutoPostBack='true' /><br />
	                    <asp:RadioButton runat='server' ID='chkVisualizouNaoPermitido' Text='Não permitido' GroupName='Visualizou' AutoPostBack='true' /><br />
	                    <asp:Panel runat='server' ID='pnlQtdEstoque'>
	                        <br />
	                        Quantidade no estoque<br />
	                        <asp:TextBox runat='server' id='txtEstoque'></asp:TextBox>
	                    </asp:Panel>
	                </asp:Panel>
	                <asp:Panel runat='server' ID='pnlPergunta'>
	                    <uc1:pergunta ID="pergunta1" runat="server" />
	                </asp:Panel>
	                <br />
	                <asp:Label runat='server' ID='lblValidate' ForeColor='Red'>teste</asp:Label>
	            </div>
	            <asp:Button ID='btnVoltarVisita' runat='server' Text='Tela de Visita' />
	            <asp:Button ID='btnVoltar' runat='server' Text='Voltar' />
	            <asp:Button ID='btnAvancar' runat='server' Text='Avançar' />
	            <asp:Button ID='btnAnteriorPerg' runat='server' Text='Voltar' Visible='False' />
	            <asp:Button ID='btnProximaPerg' runat='server' Text='Avançar' Visible='False' />

	    <asp:UpdatePanel runat='server' ID='updFormulario'>
	        <ContentTemplate>
	        </ContentTemplate>
	    </asp:UpdatePanel>
	</div>
</asp:Content>

