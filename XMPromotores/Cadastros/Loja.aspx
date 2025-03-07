<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Loja.aspx.vb" Inherits="Pages.Cadastros.Loja" title="XM Promotores - Yes Mobile" %>

<%@ Register src="../controls/Shopping.ascx" tagname="Shopping" tagprefix="uc1" %>
<%@ Register src="../controls/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>
<%@ Register src="../controls/CamposAdicionais.ascx" tagname="CamposAdicionais" tagprefix="uc2" %>
<%@ Register src="../controls/Segmentacao.ascx" tagname="Segmentacao" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language=javascript type="text/javascript">
    function MascaraCNPJ(cnpj) {
        if (mascaraInteiro(cnpj) == false) {
            event.returnValue = false;
        }
        return formataCampo(cnpj, '00.000.000/0000-00', event);
    }
    function mascaraInteiro() {
        if (event.keyCode < 48 || event.keyCode > 57) {
            event.returnValue = false;
            return false;
        }
        return true; 
    }
    function formataCampo(campo, Mascara, evento) 
    {         
        var boleanoMascara;                 
        var Digitato = evento.keyCode;        
        exp = /\-|\.|\/|\(|\)| /g        
        campoSoNumeros = campo.value.toString().replace( exp, "" );            
        var posicaoCampo = 0;            
        var NovoValorCampo="";        
        var TamanhoMascara = campoSoNumeros.length;;
        if (Digitato != 8) 
        { // backspace                 
            for(i=0; i<= TamanhoMascara; i++) 
            {
                boleanoMascara = ((Mascara.charAt(i) == "-") ||
                                    (Mascara.charAt(i) == ".") || 
                                    (Mascara.charAt(i) == "/"))
                boleanoMascara = boleanoMascara || 
                                        ((Mascara.charAt(i) == "(") ||
                                         (Mascara.charAt(i) == ")") ||
                                         (Mascara.charAt(i) == " ")
                                        )
                if (boleanoMascara) {
                    NovoValorCampo += Mascara.charAt(i);
                    TamanhoMascara++;
                }
                else {
                    NovoValorCampo += campoSoNumeros.charAt(posicaoCampo);
                    posicaoCampo++;
                }
            }
            campo.value = NovoValorCampo;
            return true;
           }
        else {
            return true;
            }
        }
        
		function Formatadata(Campo, teclapres)
		{
			var tecla = teclapres.keyCode;
			var vr = new String(Campo.value);
			vr = vr.replace("-", "");
			tam = vr.length + 1;
			if (tecla != 8)
			{
				if (tam == 6)
					Campo.value = vr.substr(0, 5) + '-' + vr.substr(5, 5);
			}
		}
		</script>

    </script>
    <div class='EditArea' style="height:auto; padding-top:10px;">
        <div class='divEditArea' border='0' style="min-width:800px;" runat="server" id="trVerificaCNPJ">
	        <div class='trField' style="padding-left:10px;" runat='server' id='Div1' visible='<%$Settings: visible, Loja.CNPJ, true %>' >
		        <div class='tdFieldHeader cb fl' style='width:133px;'>
			        Digite o CNPJ:
		        </div>
		        <div class='tdField fl' style='width:560px;'>
			        <asp:TextBox onkeypress="MascaraCNPJ(this);" runat='server' ID='txtVerificaCNPJ' validar='true' tipo='cnpj' Width='130px' />
			        <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, Loja.CNPJ, true %>' Display='None' ErrorMessage='CNPJ � um campo obrigat&oacute;rio!' ControlToValidate='txtVerificaCNPJ' />
                    <asp:CustomValidator ID="customValidaCNPJ" runat="server" Enabled='<%$Settings: ValidaCNPJ, Loja.CNPJ, true %>'  ClientValidationFunction="valida_CPFCNPJ" ControlToValidate="txtVerificaCNPJ" Display="None" ErrorMessage="CNPJ inv�lido." SetFocusOnError="True">&nbsp;</asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Enabled='true' OnServerValidate="CNPJValidation" ControlToValidate="txtVerificaCNPJ" Display="None" ErrorMessage="CNPJ j� existe." SetFocusOnError="True">&nbsp;</asp:CustomValidator>
		        </div>
	        </div>
        </div>
		<div class='divEditArea' border='0' style="min-width:800px; padding-left:21px;" runat="server" id="trMainCadastro">
            <ul style="margin-right:0px;">
                <li runat='server' id='trCodigo' visible='<%$Settings: visible, Loja.Codigo, true %>' >
	                <label style="clear:left; width:20px;">Codigo:</label>
	                <asp:TextBox runat='server' ID='txtCodigo' CssClass="formulario" style="display:block;" />
	                <asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Loja.Codigo, true %>' Display='None' ErrorMessage='Codigo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
                    <asp:CustomValidator runat='server' ID='CustomValidator4' Display="Dynamic" ErrorMessage='Codigo j&aacute; existe!' ControlToValidate='txtCodigo' OnServerValidate="ValidarCodigo" />
                </li>
                <li runat='server'  id='trCNPJ' visible='<%$Settings: visible, Loja.CNPJ, true %>' >
                <label style="clear:right;">CNPJ:</label>
                <asp:TextBox runat='server' ID='txtCNPJ' validar='true' tipo='cnpj' Width='140px' CssClass="formulario" style="display:block;"></asp:TextBox>
	                <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator3' Enabled='<%$Settings: Required, Loja.CNPJ, true %>' Display='None' ErrorMessage='CNPJ &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCNPJ' />
                    <asp:CustomValidator ID="CustomValidator2" runat="server" Enabled='true' ClientValidationFunction="valida_CPFCNPJ" ControlToValidate="txtCNPJ" Display="None" ErrorMessage="CNPJ inv&aacute;lido." ForeColor="" SetFocusOnError="True">&nbsp;</asp:CustomValidator>
                    <asp:CustomValidator runat='server' ID='CustomValidator3' Enabled='<%$Settings: Required, Loja.CNPJ, true %>' Display='None' ErrorMessage='CNPJ &eacute; j&aacute; existe!' ControlToValidate='txtCodigo' OnServerValidate="CNPJValidation" />
                </li>
                <li runat='server'  id='trIE' visible='<%$Settings: visible, Loja.IE, true %>'>
                <label style="clear:right; width:190px;">IE:</label>
	                <asp:TextBox runat='server' ID='txtIE' Width='190px' CssClass="formulario" style="display:block;" />
	                <asp:RequiredFieldValidator runat='server' Enabled='<%$Settings: Required, Loja.IE, true %>' ID='valReqIE' Display='None' ErrorMessage='IE &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtIE' />
                </li>
            </ul>
            <br class='cb' />	
            <ul style="margin-right:0px;">
                <li runat='server'  id='trLoja' visible='<%$Settings: visible, Loja.Loja, true %>' >
                    <label style="clear:right; width:300px;">Loja:</label>
	                <asp:TextBox runat='server' Width="300px" ID='txtLoja' MaxLength='200' CssClass="formulario" style="display:block;" />
	                <asp:RequiredFieldValidator runat='server' ID='valReqLoja' Display='None' ErrorMessage='Loja &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLoja' />			 	
                </li>
                <li runat='server'  id='trRazaoSocial' visible='<%$Settings: visible, Loja.RazaoSocial, false %>'>
	                <label style="clear:right; width:300px;">Raz&atilde;o Social:</label>
	                <asp:TextBox runat='server' ID='txtRazaoSocial' MaxLength='200' Width='300px' CssClass="formulario" style="display:block;" />
	                <asp:RequiredFieldValidator runat='server' ID='valReqRazaoSocial' Enabled='<%$Settings: Required, Loja.RazaoSocial, false %>' Display='None' ErrorMessage='Raz&atilde;o Social &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtRazaoSocial' />
                </li>
            </ul>
           <br class='cb' />	
            <ul style="margin-right:0px;">
			     <li runat='server'  id='trEndereco' visible='<%$Settings: visible, Loja.Endereco, true %>'>
			        <label style="clear:right;">Endereco:</label>
					    <asp:TextBox Width="620px" runat='server' ID='txtEndereco' CssClass="formulario" style="display:block;" />
					    <asp:RequiredFieldValidator runat='server' ID='valReqEndereco' Enabled='<%$Settings: Required, Loja.Endereco, true %>' Display='None' ErrorMessage='Endereco &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEndereco' />
			     </li>			 
            </ul>
           
            <ul style="margin-right:0px;">
			     <li runat='server' style="width:100px" id='trNumero' visible='<%$Settings: visible, Loja.Numero, true %>'>
			      <label style="clear:right;">Numero:</label>
					    <asp:TextBox runat='server' ID='txtNumero' Width='100px' CssClass="formulario" style="display:block;" />
					    <asp:RequiredFieldValidator runat='server' ID='valReqNumero' Enabled='<%$Settings: Required, Loja.Numero, true %>' Display='None' ErrorMessage='Numero &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtNumero' />			  
			     </li>
			     <li runat='server' style="width:180px"  id='trComplemento' visible='<%$Settings: visible, Loja.Complemento, true %>'>
			      <label style="clear:right;">Compl.:</label>
					    <asp:TextBox runat='server' ID='txtComplemento' Width='180px' CssClass="formulario" style="display:block;" />			  
			     </li>
			     <li runat='server'  id='trBairro' visible='<%$Settings: visible, Loja.Bairro, true %>'>
			 	    <label style="clear:right;">Bairro:</label>
					    <asp:TextBox runat='server' ID='txtBairro' Width='190px' MaxLength='100' CssClass="formulario" style="display:block;" />
					    <asp:RequiredFieldValidator runat='server' ID='valReqBairro' Enabled='<%$Settings: Required, Loja.Bairro, true %>' Display='None' ErrorMessage='Bairro &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtBairro' />			 	
			     </li>
             </ul>
             <br class='cb' />
             <ul style="margin-right:0px;">
			     <li runat='server'  id='trCidade' visible='<%$Settings: visible, Loja.Cidade, true %>'>
			 	    <label style="clear:right;">Cidade:</label>
					    <asp:TextBox runat='server' Width="300px" ID='txtCidade' CssClass="formulario" style="display:block;" />
					    <asp:RequiredFieldValidator runat='server' ID='valReqCidade' Enabled='<%$Settings: Required, Loja.Cidade, true %>' Display='None' ErrorMessage='Cidade &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCidade' />			 	
			     </li>
			     <li style="width:80px;" runat='server'  id='trUF' visible='<%$Settings: visible, Loja.UF, true %>'>
			 	    <label style="clear:right;">UF:</label>
				    <asp:DropDownList DataTextField="UF"  Width='80px' DataValueField="UF" runat='server' ID='drpIdUF' CssClass="select" style="display:block;"></asp:DropDownList>
				    <asp:CompareValidator runat='server'  ID='CompareValidator1' Enabled='<%$Settings: Required, Loja.UF, true %>' Display='None' ErrorMessage='UF inv&aacute;lida' ControlToValidate='drpIdUF' Operator="NotEqual" ValueToCompare="0" />			 	
			     </li>
			     <li style="width:190px;" runat='server'  id='trCEP' visible='<%$Settings: visible, Loja.CEP, true %>'>
			  	    <label style="clear:right; width:190px;">Cep:</label>
				    <asp:TextBox runat='server' ID='txtCep' Width='150px' maxlength="9" onkeyup="Formatadata(this,event)" CssClass="formulario" style="display:block;"/>
				    <asp:RequiredFieldValidator runat='server' ID='valReqCep' Display='None' Enabled='<%$Settings: Required, Loja.CEP, true %>' ErrorMessage='Cep &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCep' />			  
			     </li>
             </ul>
              <br class='cb' />	
              <ul style="margin-right:0px;">
               <li runat="server" id='trLatitude'>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                 <ContentTemplate>
                    <div class='trField cb' >
                        <div class='tdFieldHeader fl' >
					        Latitude:
				        </div>			
                        <div>
                            <asp:TextBox runat="server" ID="txtLatitude"></asp:TextBox>
                        </div>
                    </div>
                  <div class='trField fl' >
                        <div class='tdFieldHeader fl' >
					        Longitude:
				        </div>			
                        <div>
                            <asp:TextBox runat="server" ID="txtLongitude"></asp:TextBox>
                            <asp:Button runat="server" ID="btnVerificarPosicao" CausesValidation="false" Text="Verificar Posi��o" CssClass='Botao' />
                            <asp:Label ID="lblEnderecoVazio" runat="server" Text=""></asp:Label>
                        </div>
                    </div>                    
                </ContentTemplate>
            </asp:UpdatePanel>
             </li>
                 </ul>



             <br class='cb' />
             <ul style="margin-right:0px;">
			     <li runat='server'  id='trFilial' visible='<%$Settings: visible, Loja.Filial, false %>'>
			 	    <label style="clear:right;">Filial</label>
				    <asp:TextBox runat='server' ID='txtFilial' MaxLength='100' Width='300px' CssClass="formulario" style="display:block;"/>
				    <asp:RequiredFieldValidator runat='server' ID='valReqFilial' Enabled='<%$Settings: Required, Loja.Filial, false %>' Display='None' ErrorMessage='Filial &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtFilial' />
			     </li>
			     <li style="width:154px;" runat='server'  id='trRevenda' visible='<%$Settings: visible, Loja.Revenda, true %>' >
				    <label style="clear:right;"><asp:Literal ID="ltrRevenda" runat="server" Text='<%$ Settings: caption, Loja.FiltroRevenda, "Revenda" %>' />:</label>
				    <asp:DropDownList runat='server' ID='drpIDCliente' style="width:300px;" DataTextField="Fantasia" DataValueField="IdCliente" CssClass="Select"></asp:DropDownList>
				    <asp:CompareValidator runat='server'  ID='valCompIDCliente' Enabled='<%$Settings: Required, Loja.Cliente, true %>' Display='None' ErrorMessage='EST  SENDO SETADO NO CODEBEHIND' ControlToValidate='drpIDCliente' Operator="GreaterThan" ValueToCompare="0" />								 	
			     </li>
             </ul>
             <br class='cb' />
             <ul style="margin-right:0px;">
			     <li runat='server'  id='trRegiao' visible='<%$Settings: visible, Loja.Regiao, true %>'>
			 	    <label style="clear:right;"><asp:Literal ID="Literal1" runat="Server" Text='<%$Settings: Caption, Regiao, "Regi&atilde;o"%>'></asp:Literal>:</label>
				    <asp:DropDownList DataTextField="Regiao" Width='150px' DataValueField="IdRegiao" runat='server' ID='drpIDRegiao' CssClass="Select"></asp:DropDownList>
				    <asp:CompareValidator runat='server'  ID='valCompIDRegiao' Enabled='<%$Settings: Required, Loja.Regiao, true %>' Display='None' ErrorMessage='Regiao inv&aacute;lida' ControlToValidate='drpIDRegiao' Operator="GreaterThan" ValueToCompare="0" />
			     </li>
			     <li style="width:150px;" runat='server'  id='trTipoLoja' visible='<%$Settings: visible, Loja.TipoLoja, true %>' >
          		    <label style="clear:right;"><asp:Literal ID="ltrTipoLoja" runat="server" Text='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' />:</label>		
	        	    <asp:DropDownList DataTextField="TipoLoja" Width='150px' DataValueField="IdTipoLoja" runat='server' ID='drpIDTipoLoja' CssClass="Select"></asp:DropDownList>
				    <asp:CompareValidator runat='server'  ID='valCompIDTipoLoja' Display='None' ErrorMessage='EST  SENDO SETADO NO CODEBEHIND' ControlToValidate='drpIDTipoLoja' Operator="GreaterThan" ValueToCompare="0" />          			 
			     </li>
			     <li runat='server'  id='trStatus' visible='<%$Settings: visible, Loja.Status, true %>'>
			 	    <label style="clear:right;">Status:</label>
			 	    <asp:DropDownList runat='server' ID='drpIdStatus' CssClass="Select" Width="102px"></asp:DropDownList>
			     </li>
			     <li runat='server'  id='trLocalLoja' visible='<%$Settings: visible, Loja.LocalLoja, true %>'>
			      <label style="clear:right;">Local da Loja:</label>
			            <asp:UpdatePanel ID="UpdatePanel1" runat="Server">
			            <ContentTemplate>
			                <uc1:Shopping ID="tljTipoLoja" runat="server" ></uc1:Shopping>
			            </ContentTemplate>
			            </asp:UpdatePanel>			  
			     </li>
             </ul>
             <br class='cb' />
             <ul style="margin-right:0px;">
			     <li runat='server'  id='trEmail' visible='<%$Settings: visible, Loja.Email, true %>'>
			      <label style="clear:right;">Email:</label>
			      <asp:TextBox runat='server' ID='txtEmail' Width='620px' CssClass="formulario" style="display:block;" />
			     </li>
             </ul>
             <br class='cb' />
             <ul style="margin-right:0px;">
			     <li runat='server'  id='Div2' visible='<%$Settings: visible, Loja.GerenteLoja, true %>'>
			 	    <label style="clear:right;">Gerente da Loja:</label>
					    <asp:TextBox runat='server' ID='txtGerenteLoja' Width='250px' MaxLength='100' CssClass="formulario" style="display:block;" />
					    <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' Enabled='<%$Settings: Required, Loja.GerenteLoja, false %>' Display='None' ErrorMessage='Gerente da Loja &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtGerenteLoja' />			 	
			     </li>
			     <li runat='server'  id='trTelefone' visible='<%$Settings: visible, Loja.Telefone, true %>'>
			 	    <label style="clear:right;">Tel.:</label>
			 	    <asp:TextBox runat='server' ID='txtTelefone' Width='102px' CssClass="formulario" style="display:block;"/>
			     </li>
			     <li runat='server'  id='trCelular' visible='<%$Settings: visible, Loja.Celular, true %>' >
			      <label style="strMessageclear:right;">Cel.:</label>
			      <asp:TextBox runat='server' ID='txtCelular' Width='102px' CssClass="formulario" style="display:block;" />
			     </li>
			     <li runat='server'  id='trFAX' visible='<%$Settings: visible, Loja.FAX, true %>'>
			 	    <label style="clear:right;">Fax:</label>
			 	    <asp:TextBox runat='server' ID='txtFax' Width='102px' CssClass="formulario" style="display:block;" />
			     </li>
			     <li runat='server'  id='trFoto' Visible='<%$Settings: Visible, Loja.Foto, true %>' >
			      <label style="clear:right;">Foto:</label>
			 	    <uc1:ImageUploader ID="ImageUploaderLoja" runat="server" VirtualPath='~/imagens/Contato_Loja/' NoImage='noimage.png' />
			     </li>
                 <li runat='server' class="cb" id='Li1' visible='<%$Settings: visible, Loja.OBS, true %>'>
			 	    <label style="clear:right;">Observa&ccedil;&otilde;es:</label><br>
			 	    <asp:TextBox runat='server' ID='txtObservacao' TextMode="MultiLine" Rows="5" Columns="20" CssClass="formulario" style="width:620px;height:200px" />
			     </li>
			</ul>
			<div>		
			<uc2:CamposAdicionais width="100%" ID="CamposAdicionais1" runat="server" Entidade="Loja" />
			<br class='cb' />
			<br class='cb' />
			<br class='cb' />
			</div>	
		</div>
	</div>
	<asp:PlaceHolder runat='server' ID='phlOpcoes'>
	    <uc3:Segmentacao ID="Segmentacao1" runat="server" Style='width:90%; width:78%; margin-left:20px;'>
            <Title>A loja trabalha com os seguintes produtos</Title>
            <EmptyDataText>
                 N&atilde;o h&aacute; segmenta&ccedil;&atilde;o cadastrada para essa loja!
            </EmptyDataText>
        </uc3:Segmentacao>
    </asp:PlaceHolder> 	
    <div class='AreaBotoes' runat='server' id='trBotoesMain'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Loja.aspx?idloja=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Lojas.aspx'" />
    </div>
    <div class='AreaBotoes' runat='server' id='trBotoesCNPJ'>
        <asp:Button runat='server' ID='btnValidarCNPJ' Text="Verificar CNPJ" CssClass='Botao'/>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Lojas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' SkinID='valSummary' />
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

