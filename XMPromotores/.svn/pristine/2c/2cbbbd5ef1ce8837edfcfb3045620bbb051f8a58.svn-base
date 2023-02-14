<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Produto.aspx.vb" Inherits="Pages.Cadastros.Produto" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../controls/CamposAdicionais.ascx" tagname="CamposAdicionais" tagprefix="uc2" %>

<%@ Register src="../controls/ProdutoConcorrente.ascx" tagname="ProdutoConcorrente" tagprefix="uc1" %>

<%@ Register src="../controls/PrecoProduto.ascx" tagname="PrecoProduto" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">      
    <div class='EditArea' style="padding:20px 0px 20px 20px;">
			<ul style="width:57%;">
			 <li class="tdFieldHeader" > 
			  <a>C&oacute;digo</a>
			  <span class="clear"> </span>
				<asp:TextBox runat='server' ID='txtCodigo' MaxLength='25' CssClass="formulario" Width="129px" />
				<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />  
			 </li>			  
			 <li class="tdFieldHeader">
			  <a>Criado:</a>
			  <span class="clear"> </span>
			  <span style="width:100px;">
			  <asp:Label runat='server' ID='lblCriado' Width="126px"  /></span>			  
			 </li>
			 <li class="tdFieldHeader cl">
			  <a>Descri&ccedil;&atilde;o:</a>
			  <span class="clear"> </span>
			  <asp:TextBox runat='server' ID='txtDescricao' MaxLength='60' Width="506px" CssClass="formulario" />
			  <asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Display='None' ErrorMessage='Descri&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
			 </li>
			 <li>
			 </li>
			 <li class="tdFieldHeader">
			  <a>Descri&ccedil;&atilde;o Resumida:</a>
			 	<span class="clear"> </span> 
			 	<asp:TextBox runat='server' ID='txtDescricaoResumida' MaxLength='60' Width="506px" CssClass="formulario" Height="44px" />                        
				<asp:RequiredFieldValidator runat='server' ID='valReqDescricaoResumida' Display='None' ErrorMessage='Descri&ccedil;&atilde;o Resumida &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricaoResumida' />
			 </li>
			 <li class="tdFieldHeader">
			  <a><asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal></a>
  			  <span class="clear"> </span>
			 	<asp:DropDownList AutoPostBack="true" runat="server" ID="cboIdCategoria" DataTextField="Categoria" DataValueField="IDCategoria" CssClass="Select" Height="19px"/>
				<asp:CompareValidator runat="server"  ID="compSegmento" Display="None" ControlToValidate="cboIdCategoria" Operator="GreaterThan" ValueToCompare="0" />
				<asp:RequiredFieldValidator runat='server' ID='reqSegmento' Display='None' ControlToValidate='cboIDCategoria' />
			 </li>
			 <li class="tdFieldHeader">
			  <a><asp:Literal ID="Literal2" runat="server" Text='<%$Settings: Caption, SubCategoria, "Categoria"%>'></asp:Literal>:</a>
			  <span class="clear"> </span>
			 	<asp:DropDownList runat="server" ID="cboIDSubCategoria" DataTextField="SubCategoria" DataValueField="IDSubCategoria" CssClass="Select" Height="19px" />
				<asp:CompareValidator runat="server"  ID="compCategoria" Display="None" ControlToValidate="cboIDSubCategoria" Operator="GreaterThan" ValueToCompare="0" />
				<asp:RequiredFieldValidator runat='server' ID='reqCategoria' Display='None' ControlToValidate='cboIDSubCategoria' />
			 </li>
			 <li class="tdFieldHeader">
			  <a><asp:Literal ID="Literal3" runat="server" Text='<%$Settings: Caption, Fornecedor, "Fornecedor"%>'></asp:Literal></a>
			  <span class="clear"> </span>
			 	<asp:DropDownList runat="server" ID="cboIDFornecedor" DataTextField="Fornecedor" DataValueField="IDFornecedor" CssClass="Select" Height="19px" />
				<asp:CompareValidator runat="server"  ID="compFornecedor" Display="None" ControlToValidate="cboIDFornecedor" Operator="GreaterThan" ValueToCompare="0" />
				<asp:RequiredFieldValidator runat='server' ID='reqFornecedor' Display='None' ControlToValidate='cboIDFornecedor' />
			 </li>				 
			</ul>			
			<ul id="ul_2" runat='server' visible='<%$Settings: Visible, Produto.PrecoSugerido, true %>'>
			 <li class="tdFieldHeader">
			 <a>Pre&ccedil;o Sugerido:</a>
			 <span class="clear"> </span>
			 					<asp:TextBox runat='server' ID='txtPrecoSugerido' MaxLength='60' CssClass="formulario" />
			                    <cc1:MaskedEditExtender TargetControlID="txtPrecoSugerido" 
			                        Mask="9,999,999.99"
			                        OnFocusCssClass="MaskedEditFocus" 
			                        OnInvalidCssClass="MaskedEditError"
			                        InputDirection="RightToLeft" 
			                        AcceptNegative="Left" 
			                        DisplayMoney="Left"
			                        ID="MaskedEditExtender3" runat="server" MaskType="Number">
			                    </cc1:MaskedEditExtender>
								<asp:RequiredFieldValidator runat='server' Enabled='<%$Settings: Required, Produto.PrecoSugerido, true %>' ID='RequiredFieldValidator2' Display='None' ErrorMessage='Pre&ccedil;o Sugerido &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPrecoSugerido' />
								<asp:CompareValidator runat='server'  ID='CompareValidator2' Display='None' ErrorMessage='Pre&ccedil;o Sugerido inv&aacute;lida' ControlToValidate='txtPrecoSugerido' Operator='DataTypeCheck' Type='Currency' />
			 </li>
			</ul>
			
			<ul id="ul_3" runat='server' visible='<%$Settings: Visible, Produto.PrecoMinimo, true %>'>
			 <li class="tdFieldHeader">
			 <a>Pre&ccedil;o M&iacute;nimo:</a>
			 <span class="clear"> </span>
						<asp:TextBox runat='server' ID='txtPrecoMinimo' MaxLength='60' CssClass="formulario" />
			                    <cc1:MaskedEditExtender TargetControlID="txtPrecoMinimo" 
			                        Mask="9,999,999.99"
			                        OnFocusCssClass="MaskedEditFocus" 
			                        OnInvalidCssClass="MaskedEditError"
			                        InputDirection="RightToLeft" 
			                        AcceptNegative="Left" 
			                        DisplayMoney="Left"
			                        ID="MaskedEditExtender2" runat="server" MaskType="Number">
			                    </cc1:MaskedEditExtender>
                                <span style="font-size:xx-small">(Digitado no aparelho)</span> 
								<asp:RequiredFieldValidator runat='server' Enabled='<%$Settings: Required, Produto.PrecoMinimo, true %>' ID='valReqPrecoMinimo' Display='None' ErrorMessage='Pre&ccedil;o M&iacute;nimo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPrecoMinimo' />
								<asp:CompareValidator runat='server'  ID='valCompPrecoMinimo' Display='None' ErrorMessage='Pre&ccedil;o M&iacute;nimo inv&aacute;lida' ControlToValidate='txtPrecoMinimo' Operator='DataTypeCheck' Type='Currency' />
			 </li>
			</ul>
			
			<ul id="ul_4" runat='server' Visible='<%$Settings: Visible, Produto.PrecoMaximo, true %>'>
			 <li class="tdFieldHeader">
			 <a>Pre&ccedil;o M&aacute;ximo:</a>
			 <span class="clear"> </span>
						<asp:TextBox runat='server' ID='txtPrecoMaximo' MaxLength='60' CssClass="formulario" />
			                    <cc1:MaskedEditExtender TargetControlID="txtPrecoMaximo" 
			                        Mask="9,999,999.99"
			                        OnFocusCssClass="MaskedEditFocus" 
			                        OnInvalidCssClass="MaskedEditError"
			                        InputDirection="RightToLeft" 
			                        AcceptNegative="Left" 
			                        DisplayMoney="Left"
			                        ID="MaskedEditExtender1" runat="server" MaskType="Number">
			                    </cc1:MaskedEditExtender>
                                <span style="font-size:xx-small">(Digitado no aparelho)</span> 
								<asp:RequiredFieldValidator runat='server' ID='valReqPrecoMaximo' Enabled='<%$Settings: Required, Produto.PrecoMaximo, true %>' Display='None' ErrorMessage='Pre&ccedil;o M&aacute;ximo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPrecoMaximo' />
								<asp:CompareValidator runat='server'  ID='valCompPrecoMaximo' Display='None' ErrorMessage='Pre&ccedil;o M&aacute;ximo inv&aacute;lida' ControlToValidate='txtPrecoMaximo' Operator='DataTypeCheck' Type='Currency' />
			 </li>
			</ul>
			<ul id="ul1" runat='server' Visible='<%$Settings: Visible, Produto.CodigoBarras, true %>'>
			 <li class="tdFieldHeader">
			 <a>C&oacute;digo de Barras</a>
				 <span class="clear"> </span>
				 <asp:TextBox runat='server' ID='txtCodigoBarras' MaxLength='60' Width="200" CssClass="formulario" />
			 </li>
			</ul>						
			<asp:UpdatePanel runat="server" ID="updSattus">
			  <ContentTemplate>
			        <ul id="ul_9" runat='server' Visible='<%$Settings: Visible, Produto.StatusComercio, false %>'>
			         <li class="tdFieldHeader">
			         <a>Status Com&eacute;rcio:</a>
			         <span class="clear"> </span>
                        <asp:RadioButtonList runat="server" ID="rdStatusComercio">
					        <asp:ListItem Text="Fora de Linha" Value="0"></asp:ListItem>
					        <asp:ListItem Text="Em linha" Value="1"></asp:ListItem>
					    </asp:RadioButtonList>
                        <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator4' Enabled='<%$Settings: Required, Produto.StatusPesquisa, false %>' Display='None' ErrorMessage='Status Com&eacute;rcio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='rdStatusComercio' />
			         </li>
			        </ul>
			
			        <ul id="ul_10" runat='server' Visible='<%$Settings: Visible, Produto.StatusPesquisa, false %>'>
			         <li class="tdFieldHeader">
			          <a>Status Pesquisa:</a>
			          <span class="clear"> </span>
				        <asp:RadioButtonList runat="server" ID="rdStatusPesquisa">
					        <asp:ListItem Text="N&atilde;o" Value="0"></asp:ListItem>
					        <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
					        </asp:RadioButtonList>
				        <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator3' Enabled='<%$Settings: Required, Produto.StatusPesquisa, false %>' Display='None' ErrorMessage='Status Pesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='rdStatusPesquisa' />
			         </li>
			        </ul>
			  </ContentTemplate>
			</asp:UpdatePanel>           
            <br class='cb' />
            <div id="Div11" class='trField fl' style='width:48%' runat='server'>
                <div class='tdField fl'>
                    <uc2:CamposAdicionais width="100%" ID="CamposAdicionais1" runat="server" Entidade="Produto" />
                </div>
            </div>            
		    
            <br class='cb' />
			
            <br class='cb' />			
            <div class='divBottom'>
			</div>
	</div>
    <div class='Filtro' id="PrecoPorEstado" runat="server">
        <uc3:PrecoProduto ID="PrecoProduto1" runat="server" />
    </div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Visible="false" Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Produto.aspx?idproduto=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Produtos.aspx'" />
    </div>
    <div id="divProdutoConcorrente" class='trField fl' runat='server' Visible='<%$Settings: visible, Produto.ProdutoConcorrente, false %>' >
        <uc1:ProdutoConcorrente ID="ProdutoConcorrente1" runat="server" />
    </div>
    <div id='divErros cb'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' ForeColor='Black' />
        <asp:ValidationSummary runat='server' ID='valSummary' ForeColor='Black' />
    </div>
    <div class='AreaAjuda cb'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Gravar:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

