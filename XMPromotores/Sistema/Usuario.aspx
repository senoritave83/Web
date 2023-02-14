<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Usuario.aspx.vb" Inherits="Pages.Cadastros.Usuario" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<%@ Register src="../controls/CamposAdicionais.ascx" tagname="CamposAdicionais" tagprefix="uc3" %>
<%@ Register src="../controls/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>
<%@ Register Src="../controls/VerRoteiro.ascx" TagName="VerRoteiro" TagPrefix="uc2" %>
<%@ Register src="../controls/Segmentacao.ascx" tagname="Segmentacao" tagprefix="uc5" %>


<%@ Register src="../controls/Permissoes.ascx" tagname="Permissoes" tagprefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea_Acesso'>
		 <div runat='server' id='trFoto' align="left">
            <span>
    	        <uc1:ImageUploader CausesValidation="false" ID="ImageUploaderUsuario" runat="server" VirtualPath='~/imagens/usuario/' NoImage="imagens/noimage.png" />
		    </span> 
		</div> 
        <div id="dados_acesso"> 
        <h2>Dados de Acesso</h2>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
     	        <ul style="margin-right:0px\9; padding-left:0px;">
                    <li runat='server' id='liAtivo' style="clear:both; width:100px; float:none;"><br/>
      		            <label class='MsgUsuarioInativo'>INATIVO</label>
      		        </li>     	    
     		        <li style="margin-right:12px">
     			        <label>Usuario:</label>
     			        <span class="clear"></span>
     			        <span>
					        <asp:TextBox runat='server' ID='txtUsuario' MaxLength='100' cssclass="InputField" Width="223px" />
			            </span>
					    <asp:RequiredFieldValidator runat='server' ID='valReqUsuario' Enabled='<%$Settings: Required, Usuario.Usuario, true %>' Display='None' ErrorMessage='Usuario &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtUsuario' />
     		        </li>
      		        <li runat='server' id='trCodigo' visible='<%$Settings: visible, Usuario.Codigo, true %>'  style="margin-right:10px; width:130px;">
      			        <label>C&oacute;digo:</label>
      			        <span class="clear"></span>
		      	        <span>
		      	            <asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' cssclass="InputField" Width="125px" />
		      	        </span>
				        <asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Usuario.Codigo, false %>' Display='None' ErrorMessage='Codigo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
      		        </li>
      		        <li runat='server' id='trlogin' style="margin-right:10px; width:149px;">
      			        <label>login:</label>
      			        <span class="clear"></span>
			            <span>
					        <asp:TextBox runat='server' ID='txtlogin' MaxLength='20' cssclass="InputField" Width="144px" />
			            </span> 
				        <asp:RequiredFieldValidator runat='server' ID='valReqlogin' Display='None' ErrorMessage='login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtlogin' />
      		        </li>
      		        <li runat='server'  id='trSenha' style="margin-right:10px;width:143px; width:110px\9;">   
     			        <label>Senha:</label>
     			        <span class="clear"></span>
        		        <span id="ctl00_ContentPlaceHolder1_pnlSenha">
        					    <asp:TextBox runat="server" ID="txtSenha" MaxLength="20" TextMode="Password" cssclass="InputField" width="143px" />
        					    <asp:Button CausesValidation="false" runat="server" ID="btnNovaSenha" Text="Nova Senha" style="margin:8px 0 10px; width:100px;" />
        					    <ajax:PasswordStrength runat='server' ID='ajaxPassword' TargetControlID='txtSenha' />
      			        </span>
					    <asp:RequiredFieldValidator runat='server' ID='valReqSenha' Display='None' ErrorMessage='Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSenha' />
      		        </li>
      		        <li runat='server' id='trEmail' style="margin-right:13px; width:314px;">
       		            <label>E-mail:</label>
       		            <span class="clear"></span>
      		            <span>
    					    <asp:TextBox runat='server' ID='txtEmail' MaxLength='256' cssclass="InputField" Width="312px"  style="width:312px; width:223\9px; "/>
      			        </span>
					    <asp:RequiredFieldValidator runat='server' ID='valReqEmail' Enabled='<%$Settings: Required, Usuario.Email, false %>' Display='None' ErrorMessage='Email &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEmail' />
                    </li>      		    
	                <li style="margin-right:10px; width:150px; width:130px\9;" >
                            <div runat='server'  id='trCargo'>
      			                <label>Cargo:</label>  
      			                <span class="clear"></span> 
      			                <span>
					                <asp:DropDownList runat='server' id='cboIDCargo' DataValueField='IDCargo' DataTextField='Cargo' AutoPostBack='True' cssclass="formulario" Width="144px" style="margin-top:7px; width:125px\9;" />
		                        </span>
				                <asp:CompareValidator runat='server' ID='valCompCargo' ControlToValidate='cboIDCargo' ValueToCompare='0' Operator='GreaterThan' Display='None' ErrorMessage='Por favor selecione o cargo!' />
      		                </div>
      		        </li>
      		        <li runat='server' id='trSuperior'>
			                <label><asp:Literal runat='server' ID='ltrCargoSuperior'>Superior:</asp:Literal></label>  
			                <span class="cb"></span> 
			                <span>
	    				        <asp:DropDownList runat='server' id='cboIDSuperior' DataValueField='IDUsuario' DataTextField='Usuario' cssclass="formulario" Style="width:150px; margin-top:7px;"/>
	                        </span>
			                <asp:CompareValidator runat='server' ID='valReqSuperior' ControlToValidate='cboIDSuperior' ValueToCompare='0' Operator='GreaterThan' Display='None' ErrorMessage='Por favor selecione o usu&aacute;rio superior!' />     		    
      		        </li>                  
      		        <li runat='server'  id='trCriado' visible='<%$Settings: visible, Usuario.Criado, true %>' style="width:120px\9; margin-left:10px\9;">
      			        <label>Data de cria&ccedil;&atilde;o:</label>
      			        <span class="clear"></span>
  				        <span class="tdField">
  					        <asp:Label runat='server' ID='lblCriado' />
  				        </span>
      		        </li>    		
     	        </ul>
            </ContentTemplate>
        </asp:UpdatePanel>
         </div>
         <br class='cb' />
         <div style="border-bottom:1px #E8E8E8 solid; height:1px; width:98%; margin-top:1px; margin-left:11px;">&nbsp;</div>
         <div id="dados_pessoais">
          <h2 style="margin-left:20px;">Dados Pessoais</h2>
          <ol>
      	    <ul style="list-style:none;">
      		    <li>
      		        <label>CPF:</label>
      		        <span class="clear"></span>
      		        <span>
                        <asp:TextBox runat='server' ID='txtCPF' MaxLength='11' cssclass="InputField" />
      		        </span>
				    <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, Usuario.CPF, true %>' Display='None' ErrorMessage='CPF &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCPF' />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Enabled='<%$Settings: Validate, Usuario.CPF, false %>' ControlToValidate="txtCPF" ClientValidationFunction="valida_CPFCNPJ" Display="None" ErrorMessage="CPF inv&aacute;lido." ForeColor="" SetFocusOnError="True">&nbsp;</asp:CustomValidator>
      		    </li>
      		    <li runat='server' id='trEndereco'>
      		        <label>Endere&ccedil;o</label>
      		        <span class="clear"></span>
      		        <span>
    					<asp:TextBox runat='server' ID='txtEndereco' MaxLength='100' cssclass="InputField" />
      		        </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqEndereco' Enabled='<%$Settings: Required, Usuario.Endereco, false %>' Display='None' ErrorMessage='Endere&ccedil;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEndereco' />
      		    </li>      	     	
	      	    <li runat='server' id='trNumero'>
	      		    <label>Numero:</label>
	      		    <span class="clear"></span>
	      		    <span>
    					<asp:TextBox runat='server' ID='txtNumero' MaxLength='50' cssclass="InputField" />
	      		    </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqNumero' Enabled='<%$Settings: Required, Usuario.Numero, false %>' Display='None' ErrorMessage='Numero &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtNumero' />
	      	    </li>      	
	      	    <li runat='server' id='trComplemento'>
	      		    <label>Complemento:</label>
	      		    <span class="clear"></span>
	      		    <span>
    					<asp:TextBox runat='server' ID='txtComplemento' MaxLength='20' cssclass="InputField" />
	      		    </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqComplemento' Enabled='<%$Settings: Required, Usuario.Complemento, false %>' Display='None' ErrorMessage='Complemento &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtComplemento' />
	      	    </li>		
			    <li runat='server' id='trBairro'>			    
				    <label>Bairro:</label>
				    <span class="clear"></span>
				    <span>
    					<asp:TextBox runat='server' ID='txtBairro' MaxLength='50' cssclass="InputField" />
     			    </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqBairro' Display='None' Enabled='<%$Settings: Required, Usuario.Bairro, false %>' ErrorMessage='Bairro &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtBairro' />
			    </li>
			    <li runat='server' id='trCep'>
				    <label>Cep:</label>
				    <span class="clear"></span>
				    <span>
    					<asp:TextBox runat='server' ID='txtCep' MaxLength='50' cssclass="InputField" />
				    </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqCep' Display='None'  Enabled='<%$Settings: Required, Usuario.Cep, false %>' ErrorMessage='Cep &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCep' />
			    </li>
			    <li runat='server' id='trCidade'>
				    <label>Cidade:</label>
				    <span class="clear"></span>
				    <span>
					    <asp:TextBox runat='server' ID='txtCidade' MaxLength='50' cssclass="InputField" />
				    </span>
				    <asp:RequiredFieldValidator runat='server' ID='valReqCidade' Display='None' Enabled='<%$Settings: Required, Usuario.Cidade, false %>' ErrorMessage='Cidade &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCidade' />
			    </li>	
			    <li runat='server' id='trUF'>
				    <label>UF:</label>
				    <span class="clear"></span>
				    <span>
    					<asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" cssclass="InputField" />
				    </span>
					<asp:CompareValidator runat="server"  ID="valCompUF" Display="None" ErrorMessage="UF inv&aacute;lida"  Enabled='<%$Settings: Required, Usuario.UF, false %>' ControlToValidate="cboUF" Operator="NotEqual" ValueToCompare="" />
			    </li>
		    </ul> 
          </ol>
          <ul>
			    <li runat='server' id='trContato'>
				    <label>Contato:</label>
				    <span class="clear"></span>
				    <span>
					    <asp:TextBox runat='server' ID='txtContato' MaxLength='100' cssclass="InputField" />
				    </span>
				    <asp:RequiredFieldValidator runat='server' ID='valReqContato' Display='None' Enabled='<%$Settings: Required, Usuario.Contato, false %>' ErrorMessage='Contato &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtContato' />
			    </li>
			    <li runat='server' id='trTelefone'>
				    <label>Telefone:</label>
				    <span class="clear"></span>
				    <span> 
					    <asp:TextBox runat='server' ID='txtTelefone' MaxLength='10' cssclass="InputField" />
				    </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqTelefone' Display='None' Enabled='<%$Settings: Required, Usuario.Telefone, false %>' ErrorMessage='Telefone &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTelefone' />
			    </li>
			    <li runat='server' id='trCelular'>
				    <label>Celular:</label>
				    <span class="clear"></span>
				    <span>
    					<asp:TextBox runat='server' ID='txtCelular' MaxLength='10' cssclass="InputField" />
				    </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqCelular' Display='None' Enabled='<%$Settings: Required, Usuario.Celular, false %>' ErrorMessage='Celular &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCelular' />
			    </li>	
			    <li runat='server' id='trFax'>
				    <label>Fax:</label>
				    <span class="clear"></span>
				    <span>
					    <asp:TextBox runat='server' ID='txtFax' MaxLength='10' cssclass="InputField" />
				    </span>
				    <asp:RequiredFieldValidator runat='server' ID='valReqFax' Display='None' Enabled='<%$Settings: Required, Usuario.FAX, false %>' ErrorMessage='Fax &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtFax' />
			    </li>
			    <li runat='server' id='trTeste'>
				    <label>Teste:</label>
				    <span class="clear"></span>
				    <span>
					    <asp:CheckBox runat='server' ID='chkTeste' />
				    </span>
			    </li>	 
			    <li runat='server' id='trAdministrador' visible='<%$Settings: visible, Usuario.Administrador, false %>'>
				    <label>Administrador:</label>
				    <span class="clear"></span>
				    <span>
    					<asp:CheckBox runat='server' ID='chkAdministrador' Enabled='false' />
				    </span>
			    </li>	 			    
			    <li runat='server'  id='trObservacao' visible='<%$Settings: visible, Usuario.Observacao, true %>' style="margin-right:0px; width:593px;">
				    <label>observa&ccedil;&atilde;o:</label>
				    <span class="clear"></span>
				    <span>
    					<asp:TextBox runat='server' ID='txtObservacao' TextMode="Multiline" Rows="3" Width='98%' cssclass="InputField" Height="69px" />
				    </span>
					<asp:RequiredFieldValidator runat='server' ID='valReqObservacao' Enabled='<%$Settings: Required, Usuario.Observacao, false %>' Display='None' ErrorMessage='observa&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtObservacao' />
			    </li>          
                <li class='trField cb' id='trAdicionarLoja' runat='server' style="margin-right:0px; width:593px;">
                    <label>Usu&aacute;rio pode adicionar loja avulsa no seu roteiro:</label> 
		            <span class="clear"></span>
		            <span>
                        <asp:DropDownList runat='server' ID='cboAdicionarLoja' CssClass="formulario">
                            <asp:ListItem Value='3'>Segue o padr&atilde;o selecionado no cargo</asp:ListItem>
                            <asp:ListItem Value='0'>N&atilde;o pode adicionar</asp:ListItem>
                            <asp:ListItem Value='1'>Pode adicionar somente lojas que j&aacute; existam em algum roteiro</asp:ListItem>
                            <asp:ListItem Value='2'>Pode adicionar qualquer loja</asp:ListItem>
                        </asp:DropDownList>
                    </span>
                </li>
          </ul>
          <uc3:CamposAdicionais width="100%" ID="CamposAdicionais1" runat="server" Entidade="Usuario" />
     </div>
     <div style="border-bottom:1px #E8E8E8 solid; height:1px; width:98%; margin-top:1px; margin-left:11px;">&nbsp;</div>
    </div>   
     <div class="cb"></div>           
     <div class=ListArea>
	    <uc5:Segmentacao ID="Segmentacao1" runat="server">
            <Title>O usu&aacute;rio trabalha com os seguintes produtos</Title>
            <EmptyDataText>
                 N&atilde;o h&aacute; segmenta&ccedil;&atilde;o cadastrada para esse usu�rio!
            </EmptyDataText>
        </uc5:Segmentacao>
        <div style="width:78%; margin-left:10px;">
    	    <uc4:Permissoes ID="Permissoes1" runat="server" />
        </div>
 	 </div>
    <br class='cb' />
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnRoteiro' Text="Ver Roteiro" CssClass='Botao' CausesValidation="false" />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='usuario.aspx?idusuario=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Usuarios.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'>
			        <b>Novo:</b>
				    Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

