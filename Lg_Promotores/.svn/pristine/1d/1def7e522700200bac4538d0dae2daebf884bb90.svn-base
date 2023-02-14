<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Produto.aspx.vb" Inherits="Pages.Cadastros.Produto" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../controls/CamposAdicionais.ascx" tagname="CamposAdicionais" tagprefix="uc2" %>

<%@ Register src="../controls/produtoconcorrente.ascx" tagname="produtoconcorrente" tagprefix="uc1" %>
<%@ Register src="../controls/PrecoProduto.ascx" tagname="PrecoProduto" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="Server" ID="sctManagerProduto"></asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb fl' style='width:48%'>
				<div class='tdFieldHeader fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='25' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField fl'>
				<div class='tdFieldHeader fl'>
					Criado:
				</div>
				<div class='tdField fl' style='margin-top:3px;'>
					<asp:Label runat='server' ID='lblCriado'  />
				</div>
			</div>
			<div class='trField cb fl' style='width:100%'>
				<div class='tdFieldHeader fl'>
					Descri&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='60' Width="498px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Display='None' ErrorMessage='Descri&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</div>
			</div>
			<div class='trField cb fl' style='width:100%'>
				<div class='tdFieldHeader fl'>
					Descri&ccedil;&atilde;o Resumida:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricaoResumida' MaxLength='60' 
                        Width="496px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricaoResumida' Display='None' ErrorMessage='Descri&ccedil;&atilde;o Resumida &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricaoResumida' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb fl' style='width:48%'>
				<div class='tdFieldHeader fl'>
					Segmento:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList AutoPostBack="true" runat="server" ID="cboIdCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
					<asp:CompareValidator runat="server"  ID="CompareValidator1" Display="None" ErrorMessage="Segmento inv&aacute;lido" ControlToValidate="cboIdCategoria" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Segmento &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDCategoria' />
				</div>
			</div>
			<div class='trField fl'>
				<div class='tdFieldHeader fl'>
					Categoria:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboIDSubCategoria" DataTextField="SubCategoria" DataValueField="IDSubCategoria" />
					<asp:CompareValidator runat="server"  ID="valCompIDSubCategoria" Display="None" ErrorMessage="Categoria inv&aacute;lida" ControlToValidate="cboIDSubCategoria" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDSubCategoria' Display='None' ErrorMessage='Categoria &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDSubCategoria' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb fl' style='width:48%'>
				<div class='tdFieldHeader fl'>
					Marca:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboIDFornecedor" DataTextField="Fornecedor" DataValueField="IDFornecedor" />
					<asp:CompareValidator runat="server"  ID="valCompIDFornecedor" Display="None" ErrorMessage="Marca inv&aacute;lida" ControlToValidate="cboIDFornecedor" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDFornecedor' Display='None' ErrorMessage='Marca &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDFornecedor' />
				</div>
			</div>
			<br class='cb' />
			<div id="Div2" class='trField cb fl' runat='server' Visible='<%$Settings: Visible, Produto.PrecoSugerido, true %>'>
				<div class='tdFieldHeader fl'>
					Pre&ccedil;o Sugerido:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoSugerido' MaxLength='60' />
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
				</div>
			</div>
			<br class='cb' />
			<div id="Div3" class='trField fl cb' runat='server' Visible='<%$Settings: Visible, Produto.PrecoMinimo, true %>'>
				<div class='tdFieldHeader fl'>
					Pre&ccedil;o M&iacute;nimo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoMinimo' MaxLength='60' />
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
				</div>
			</div>
			<br class='cb' />
			<div id="Div4" class='trField fl cb' runat='server' Visible='<%$Settings: Visible, Produto.PrecoMaximo, true %>'>
				<div class='tdFieldHeader fl'>
					Pre&ccedil;o M&aacute;ximo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPrecoMaximo' MaxLength='60' />
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
				</div>
			</div>
			<br class='cb' />
            <div id="Div1" class='trField cb fl' runat='server' Visible='<%$Settings: Visible, Produto.PrecoMaximoPoliticaPreco, false %>'>
				<div class='tdFieldHeader fl'>
					Pol&iacute;tica de Pre&ccedil;os - M&aacute;ximo :
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPoliticaMaximo' MaxLength='60' />
                    <cc1:MaskedEditExtender TargetControlID="txtPoliticaMaximo" 
                        Mask="9,999,999.99"
                        OnFocusCssClass="MaskedEditFocus" 
                        OnInvalidCssClass="MaskedEditError"
                        InputDirection="RightToLeft" 
                        AcceptNegative="Left" 
                        DisplayMoney="Left"
                        ID="MaskedEditExtender4" runat="server" MaskType="Number">
                    </cc1:MaskedEditExtender>
					<asp:RequiredFieldValidator runat='server' Enabled='<%$Settings: Required, Produto.PrecoSugerido, true %>' ID='RequiredFieldValidator4' Display='None' ErrorMessage='Pre&ccedil;o Sugerido &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPoliticaMaximo' />
					<asp:CompareValidator runat='server'  ID='CompareValidator3' Display='None' ErrorMessage='Pre&ccedil;o Sugerido inv&aacute;lida' ControlToValidate='txtPoliticaMaximo' Operator='DataTypeCheck' Type='Currency' />
				</div>
			</div>
			<div id="Div5" class='trField fl' runat='server' Visible='<%$Settings: Visible, Produto.PrecoMinimoPoliticaPreco, false %>'>
				<div class='tdFieldHeader fl'>
					Pol&iacute;tica de Pre&ccedil;os - M&iacute;nimo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPoliticaMinimo' MaxLength='60' />
                    <cc1:MaskedEditExtender TargetControlID="txtPoliticaMinimo" 
                        Mask="9,999,999.99"
                        OnFocusCssClass="MaskedEditFocus" 
                        OnInvalidCssClass="MaskedEditError"
                        InputDirection="RightToLeft" 
                        AcceptNegative="Left" 
                        DisplayMoney="Left"
                        ID="MaskedEditExtender5" runat="server" MaskType="Number">
                    </cc1:MaskedEditExtender>
					<asp:RequiredFieldValidator runat='server' Enabled='<%$Settings: Required, Produto.PrecoMinimo, true %>' ID='RequiredFieldValidator5' Display='None' ErrorMessage='Pre&ccedil;o M&iacute;nimo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPoliticaMinimo' />
					<asp:CompareValidator runat='server'  ID='CompareValidator4' Display='None' ErrorMessage='Pre&ccedil;o M&iacute;nimo inv&aacute;lida' ControlToValidate='txtPoliticaMinimo' Operator='DataTypeCheck' Type='Currency' />
				</div>
			</div>
			<br class='cb' />
            <asp:UpdatePanel runat=server ID="updSattus">
                <ContentTemplate>
                    <div id="Div9" class='trField fl' style='width:48%' runat='server' Visible='<%$Settings: Visible, Produto.StatusComercio, false %>'>
				        <div class='tdFieldHeader fl'>
					        Status Com&eacute;rcio:
				        </div>
				        <div class='tdField fl'>
					        <asp:DropDownList runat="server" ID="cboStatusComercio" AutoPostBack=true>
					            <asp:ListItem Text="Fora de linha" Value="0"></asp:ListItem>
					            <asp:ListItem Text="Em linha" Value="1"></asp:ListItem>
					        </asp:DropDownList>
				        </div>
			        </div>
			        <div id="Div10" class='trField fl' style='width:48%' runat='server' Visible='<%$Settings: Visible, Produto.StatusPesquisa, false %>'>
				        <div class='tdFieldHeader fl'>
					        Status Pesquisa:
				        </div>
				        <div class='tdField fl'>
					        <asp:RadioButtonList runat="server" ID="rdStatusPesquisa" RepeatDirection='Horizontal'>
					            <asp:ListItem Text="N&atilde;o" Value="0"></asp:ListItem>
					            <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
					        </asp:RadioButtonList>
					        <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator3' Enabled='<%$Settings: Required, Produto.StatusPesquisa, false %>' Display='None' ErrorMessage='Status Pesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='rdStatusPesquisa' />
				        </div>
			        </div>
                </ContentTemplate>
            </asp:UpdatePanel>            
            <br class='cb' />
            
            <div id="Div11" class='trField fl' style='width:48%' runat='server'>
                <div class='tdField fl'>
                    <uc2:CamposAdicionais width="100%" ID="CamposAdicionais1" runat="server" Entidade="Produto" />
                </div>
            </div>            
		    
            <br class='cb' />
			
            <div class='divBottom'>
			</div>
	   </div> 
	</div>    
    <div class='form-field' id="PrecoPorEstado" runat="server">
        <uc3:PrecoProduto ID="PrecoProduto1" runat="server" />
    </div>	
    <uc1:produtoconcorrente ID="produtoconcorrente1"  runat="server" />
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Produto.aspx?idproduto=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Produtos.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' ForeColor='Black' />
        <asp:ValidationSummary runat='server' ID='valSummary' ForeColor='Black' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Gravar:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Apagar:</b>
				Apaga o registro atual.
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

