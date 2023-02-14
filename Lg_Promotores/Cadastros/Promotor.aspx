<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Promotor.aspx.vb" Inherits="Pages.Cadastros.Promotor" title="XM Promotores - Yes Mobile" %>

<%@ Register Src="../controls/VerRoteiro.ascx" TagName="VerRoteiro" TagPrefix="uc2" %>
<%@ Register src="../controls/CamposAdicionais.ascx" tagname="CamposAdicionais" tagprefix="uc3" %>
<%@ Register src="../controls/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' ID='ScriptManager1' />
    <script>
        function funcBtnNovo() {
            location.href = 'Promotor.aspx?idpromotor=0';
        }
    </script>
    <div class='EditArea'>
		<table id='tblEditArea' border="0">
			<tr class="trEditHeader">
			    <td colspan='8'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Codigo:
				</td>
				<td class='tdField' colspan="3">
					<asp:TextBox runat='server' ID='txtCodigo' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Display='None' ErrorMessage='Codigo é um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</td>
				<td class='tdFieldHeader'>
					CPF:
				</td>
				<td class='tdField' colspan="3">
					<asp:TextBox runat='server' ID='txtCPF' MaxLength='20' validar='true' tipo='cpf' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCPF' Enabled='<%$Settings: Required, Promotor.CPF, true %>' Display='None' ErrorMessage='CPF &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCPF' />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Enabled='<%$Settings: Validate, Promotor.CPF, false %>' ClientValidationFunction="valida_CPFCNPJ" ControlToValidate="txtCPF" Display="None" ErrorMessage="CPF/CPNJ inválido." ForeColor="" SetFocusOnError="True">&nbsp;</asp:CustomValidator>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Promotor:
				</td>
				<td class='tdField' colspan="7">
					<asp:TextBox runat='server' ID='txtPromotor' MaxLength='100' Width="80%" />
					<asp:RequiredFieldValidator runat='server' ID='valReqPromotor' Display='None' ErrorMessage='Promotor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPromotor' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Login:
				</td>
				<td class='tdField' colspan="3">
					<asp:TextBox runat='server' ID='txtLogin' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLogin' Display='None' ErrorMessage='Login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLogin' />
				</td>
				<td class='tdFieldHeader'>
					Senha:
				</td>
				<td class='tdField' colspan="3">
				    <asp:UpdatePanel runat='server' id='pnlSenha'>
				        <ContentTemplate>
				            <asp:Label runat='server' ID='lblSenha' Visible='<%$Settings: Visible, Promotor.Senha, false %>' style="float:left;margin-right:10px;margin-top:5px"/>
        					<asp:TextBox runat='server' ID='txtSenha' MaxLength='10' TextMode='Password' />
        					<asp:Button runat='server' ID='btnNovaSenha' Text="Nova Senha" style="margin-left:0px;" />
				        </ContentTemplate>
				    </asp:UpdatePanel>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Endereco:
				</td>
				<td class='tdField' colspan="3">
					<asp:TextBox runat='server' ID='txtEndereco' MaxLength='100' Width="80%" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator3' Enabled='<%$Settings: Required, Promotor.Endereco, true %>' Display='None' ErrorMessage='Endere&ccedil;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEndereco' />
				</td>
				<td class='tdFieldHeader'>
					Numero:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtNumero' />
					<asp:RequiredFieldValidator runat='server' ID='valReqNumero' Enabled='<%$Settings: Required, Promotor.Numero, true %>' Display='None' ErrorMessage='Numero &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtNumero' />
				</td>
				<td class='tdFieldHeader'>
					Compl.:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtComplemento' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Bairro:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtBairro' />
					<asp:RequiredFieldValidator runat='server' ID='valReqBairro' Enabled='<%$Settings: Required, Promotor.Bairro, true %>' Display='None' ErrorMessage='Bairro &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtBairro' />
				</td>
				<td class='tdFieldHeader'>
					Cidade:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCidade' MaxLength='50' />
				</td>
				<td class='tdFieldHeader'>
					UF:
				</td>
				<td class='tdField'>
					<asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
					<asp:CompareValidator runat="server"  ID="valCompUF"  Enabled='<%$Settings: Required, Promotor.UF, true %>' Display="None" ErrorMessage="UF inv&aacute;lida" ControlToValidate="cboUF" Operator="NotEqual" ValueToCompare="" />
				</td>
				<td class='tdFieldHeader'>
					Cep:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCep' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCep' Enabled='<%$Settings: Required, Promotor.CEP, true %>' Display='None' ErrorMessage='Cep &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCep' />
				</td>
			</tr>
        	<tr class='trField'>
				<td class='tdFieldHeader'>
					Contato:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtContato' />
					<asp:RequiredFieldValidator runat='server' ID='valReqContato' Enabled='<%$Settings: Required, Promotor.Contato, true %>' Display='None' ErrorMessage='Contato &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtContato' />
				</td>
				<td class='tdFieldHeader'>
					Telefone:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtTelefone' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTelefone' Enabled='<%$Settings: Required, Promotor.Telefone, true %>' Display='None' ErrorMessage='Telefone &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTelefone' />
				</td>
				<td class='tdFieldHeader'>
					Celular:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCelular' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCelular' Display='None' Enabled='<%$Settings: Required, Promotor.Celular, true %>' ErrorMessage='Celular &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCelular' />
				</td>
				<td class='tdFieldHeader'>
                    <asp:Literal runat='server' ID='ltrFax' Text='<%$Settings: Caption, Promotor.Fax, "Fax" %>' />:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtFax' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Email:
				</td>
				<td class='tdField' colspan="7">
					<asp:TextBox runat='server' ID='txtEmail' Width="80%" />
					<asp:RequiredFieldValidator runat='server' ID='valReqEmail' Enabled='<%$Settings: Required, Promotor.Email, true %>' Display='None' ErrorMessage='Email &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEmail' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Cargo:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtCargo' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCargo' Enabled='<%$Settings: Required, Promotor.Cargo, true %>' Display='None' ErrorMessage='Cargo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCargo' />
				</td>
				<td class='tdFieldHeader'>
					Empresa:
				</td>
				<td class='tdField' colspan="3">
					<asp:TextBox runat='server' ID='txtEmpresa' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEmpresa' Enabled='<%$Settings: Required, Promotor.Empresa, true %>' Display='None' ErrorMessage='Empresa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEmpresa' />
				</td>
				<td class='tdFieldHeader'>
					Teste:
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkTeste' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					<asp:Literal ID="ltrLider" runat="server" Text='<%$Settings: caption, Promotor.FiltroLider, "Lider" %>' />:
				</td>
				<td class='tdField'  colspan="3">
					<asp:DropDownList DataTextField="Lider" DataValueField="IdLider" runat='server' ID='drpIdLider' />
					<asp:CompareValidator runat="server"  ID="compValidacaoLider" Enabled='<%$Settings: Required, Promotor.Lider, true %>' Display="None" ErrorMessage='ESTÁ SENDO SETADO NO CODEBEHIND' ControlToValidate="drpIdLider" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='reqValidacaolider' Enabled='<%$Settings: Required, Promotor.Lider, true %>' Display='None' ErrorMessage='ESTÁ SENDO SETADO NO CODEBEHIND' ControlToValidate='drpIdLider' />
				</td>
				<td class='tdFieldHeader'>
					Regi&atilde;o:
				</td>
				<td class='tdField'  colspan="3">
					<asp:DropDownList DataTextField="Regiao" DataValueField="IdRegiao" runat='server' ID='drpIdRegiao' />
					<asp:CompareValidator runat="server"  ID="CompareValidator2" Enabled='<%$Settings: Required, Promotor.Regiao, true %>' Display="None" ErrorMessage="Regi&aatilde;o inv&aacute;lida" ControlToValidate="drpIdRegiao" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' Enabled='<%$Settings: Required, Promotor.Regiao, true %>' Display='None' ErrorMessage='Regi&aatilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='drpIdRegiao' />
				</td>
		    </tr>
            <tr class='trField' runat="server" id="trSegmento" Visible="<%$Settings: Visible, Promotor.Segmento, false %>">
				<td class='tdFieldHeader'>
					Segmento:
				</td>
				<td class='tdField'  colspan="5">
					<asp:TextBox runat="server" ID="txtSegmento"></asp:TextBox>
				</td>
		    </tr>
		    <tr class='trField'>
				<td class='tdFieldHeader'>
					Status:
				</td>
				<td class='tdField' colspan='3'>
					<asp:RadioButtonList runat="server" ID='IdStatus'>
					    <asp:ListItem Text="Ativo" Value="1"></asp:ListItem>
					    <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
					    <asp:ListItem Text="Afastado" Value="2"></asp:ListItem>
					</asp:RadioButtonList>
				</td>
				<td colspan='4' align='right'>
			        <uc1:ImageUploader ID="ImageUploaderPromo" runat="server" VirtualPath='~/imagens/Promotor/' NoImage='noimage.png' Visible='<%$Settings: Visible, Promotor.Foto, false %>' />
			        &nbsp;
				</td>
			</tr>
            <tr class='trField' runat="server" id="trAcessoWeb" visible='<%$Settings: visualiza, Promotor.UsuarioWeb, false %>'>
                <td class='tdFieldHeader'>
	                AcessoWeb:
                </td>
                <td class='tdField'>
	                <asp:CheckBox AutoPostBack='true' runat="server" ID="chkAcessoWeb" />
                </td>
                <td colspan='4'>&nbsp;</td>
            </tr>
            <tr class='trField' runat="server" id="trUsuarioAcessoWeb" visible='<%$Settings: visualiza, Promotor.UsuarioWeb, false %>'>
                <td class='tdFieldHeader'>
                    Usuário:
                </td>
                <td class='tdField'>
                    <asp:DropDownList runat="server" ID="drpIdUsuario" DataTextField="Usuario" DataValueField="IdUsuario"></asp:DropDownList>
                </td>
                <td colspan='4'>&nbsp;</td>
            </tr>
            <tr class='trField'>
                <td class='tdFieldHeader' colspan='6'>
			        <uc3:CamposAdicionais width="100%" ID="CamposAdicionais1" runat="server" Entidade="Promotor" />
		        </td>
            </tr>
		</table>
	</div>
	<asp:PlaceHolder runat='server' ID='phlOpcoes'>
        <div id='AreaProdutoPromotor'>
            <asp:Panel runat='server' ID='pnlSegmentacao'>
                <asp:UpdatePanel runat='server' ID='pnlUpdate'>
                    <ContentTemplate>
                        <h4>Promotor atende a seguinte segmenta&ccedil;&atilde;o de produto:</h4>
                        <div class='ListaItens'>
                            <asp:GridView runat='server' ID='grdProdutos' Width='100%' SkinID='GridInterno' DataKeyNames='IDPromotorProduto' AutoGenerateColumns='false'>
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:BoundField DataField='Categoria' HeaderText='Segmentos' />
                                    <asp:BoundField DataField='SubCategoria' HeaderText='Categorias' />
                                    <asp:BoundField DataField='Produto' HeaderText='Produto' />
                                    <asp:ButtonField  CommandName='RetirarProduto' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                                </Columns>
                                <EmptyDataTemplate>
                                    N&atilde;o h&aacute; segmenta&ccedil;&atilde;o de produtos cadastrados para essa promotor!
                                    Ele atender&aacute; a todos os segmentos.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div id='AdicionarProdutoPromotor'>
		                    <table id='tblProduto'>
			                    <tr class='trField'>
				                    <td colspan='3'>
					                    <h4>Adicionar uma novo segmenta&ccedil;&atilde;o de produto</h4>
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdField'>
					                    Segmento:<br />
				                        <asp:DropDownList runat='server' ID='cboCategoria' DataTextField='Categoria' DataValueField='IDCategoria' AutoPostBack="true" /> 
				                    </td>
				                    <td class='tdField'>
					                    Categoria:<br />
				                        <asp:DropDownList runat='server' ID='cboSubCategoria' DataTextField='SubCategoria' DataValueField='IDSubCategoria' AutoPostBack="true" /> 
				                    </td>
				                    <td class='tdField'>
				                        Produto:<br />
				                        <asp:DropDownList runat='server' ID='cboProduto' DataTextField='Codigo' DataValueField='IDProduto' /> 
				                    </td>
			                    </tr>
			                    <tr>
    		                        <td colspan='3'>
                                        <asp:Button runat='server' ID='btnAddSegmentacao' Text='Adicionar produto' class='BotaoAdicionar' ValidationGroup="Segmentos" />
			                        </td>
			                    </tr>
		                    </table>
	                    </div>
                     </ContentTemplate> 
                </asp:UpdatePanel> 
            </asp:Panel>
        </div> 
    </asp:PlaceHolder> 	
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' Visible='<%$Settings: Visible, Promotor.BotaoGravar, true %>' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' Visible='<%$Settings: Visible, Promotor.BotaoApagar, true %>' />
        <asp:Button runat='server' ID='btnVerRoteiros' Text='Ver Roteiros' CausesValidation="false"  />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick='<%$Settings: onclick, Promotor.BotaoNovo, funcBtnNovo() %>' Visible='<%$Settings: Visible, Promotor.BotaoNovo, true %>' />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Promotores.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' ForeColor='White' style="margin-left:10px;" BulletStyle='Circle'  />
        <asp:ValidationSummary runat='server' ID='valSummary' />
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

