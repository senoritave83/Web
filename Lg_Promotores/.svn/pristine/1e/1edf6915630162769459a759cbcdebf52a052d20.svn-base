<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Loja.aspx.vb" Inherits="Pages.Cadastros.Loja" title="XM Promotores - Yes Mobile" %>

<%@ Register src="../controls/Shopping.ascx" tagname="Shopping" tagprefix="uc1" %>
<%@ Register src="../controls/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>
<%@ Register src="../controls/CamposAdicionais.ascx" tagname="CamposAdicionais" tagprefix="uc2" %>

<%@ Register assembly="XMGMapControl" namespace="XMSistemas.Web.XMGMapControl" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="http://maps.google.com/maps/api/js?sensor=false" 
           type="text/javascript"></script> 
    <script type="text/javascript" src="../Js/jquery-1.6.4.min.js"></script>
    <asp:ScriptManager runat='server' ID='ScriptManager1' />
    <script language="javascript" type="text/javascript">
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
    /*
    function recuperarPosicao() {

        $(document).ready(function () {

            var url = "http://maps.googleapis.com/maps/api/geocode/json?address=";
            var query = 'Alameda%20Casa%20branca+806+São%20Paulo+SP';
            var sensor = "&sensor=true";
            alert(url + query + sensor); ;
            //query = $("#query").val();
            $.getJSON(url + query + sensor, function (json) {

                alert(json);
                //$('#results').append('<p>Latitude : ' + json.results.geometry.location.lat + '</p>');
                //$('#results').append('<p>Longitude: ' + json.results.geometry.location.lng + '</p>');
                alert('Posição Lat :' + json.results.geometry.location.lat +
                        ' - Lon : ' + json.results.geometry.location.lng);

            });
        });
    }
    */

    </script>
    <div class='EditArea'>
        <div class='divEditArea' border='0' style="width:800px;" runat="server" id="trVerificaCNPJ">
	        <div class='trField fr' runat='server' id='Div1' visible='<%$Settings: visible, Loja.CNPJ, true %>' >
		        <div class='tdFieldHeader cb fl' style='width:40px;'>
			        Digite o CNPJ:
		        </div>
		        <div class='tdField fl' style='width:560px;'>
			        <asp:TextBox onkeypress="MascaraCNPJ(this);" runat='server' ID='txtVerificaCNPJ' validar='true' tipo='cnpj' Width='130px' />
			        <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, Loja.CNPJ, true %>' Display='None' ErrorMessage='CNPJ é um campo obrigat&oacute;rio!' ControlToValidate='txtVerificaCNPJ' />
                    <asp:CustomValidator ID="customValidaCNPJ" runat="server" Enabled='<%$Settings: ValidaCNPJ, Loja.CNPJ, true %>'  ClientValidationFunction="valida_CPFCNPJ" ControlToValidate="txtVerificaCNPJ" Display="None" ErrorMessage="CNPJ inválido." SetFocusOnError="True">&nbsp;</asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Enabled='true' OnServerValidate="CNPJValidation" ControlToValidate="txtVerificaCNPJ" Display="None" ErrorMessage="CNPJ já existe." SetFocusOnError="True">&nbsp;</asp:CustomValidator>
		        </div>
	        </div>
        </div>
		<div class='divEditArea' border='0' style="width:800px;" runat="server" id="trMainCadastro">
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' visible='<%$Settings: visible, Loja.Codigo, true %>' >
				<div class='tdFieldHeader fl'>
					Codigo:
				</div>
				<div class='tdField fl' style="width:190px;">
					<asp:TextBox runat='server' ID='txtCodigo' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Enabled='<%$Settings: Required, Loja.Codigo, true %>' Display='None' ErrorMessage='Codigo é um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<br class='cb' />	
			<div class='trField cb fl' runat='server'  id='trLoja' visible='<%$Settings: visible, Loja.Loja, true %>' >
				<div class='tdFieldHeader cb fl'>
					Loja:
				</div>
				<div class='tdField fl' style='width:460px;'>
					<asp:TextBox runat='server' Width="100%" ID='txtLoja' MaxLength='200' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLoja' Display='None' ErrorMessage='Loja é um campo obrigat&oacute;rio!' ControlToValidate='txtLoja' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trCNPJ' visible='<%$Settings: visible, Loja.CNPJ, true %>' >
				<div class='tdFieldHeader cb fl' style='width:40px;'>
					CNPJ:
				</div>
				<div class='tdField fl' style='width:130px;'>
					<asp:TextBox runat='server' ID='txtCNPJ' validar='true' tipo='cnpj' Width='100%' ></asp:TextBox>
			        <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator3' Enabled='<%$Settings: Required, Loja.CNPJ, true %>' Display='None' ErrorMessage='CNPJ é um campo obrigat&oacute;rio!' ControlToValidate='txtCNPJ' />
                    <asp:CustomValidator ID="CustomValidator2" runat="server" Enabled='true' ClientValidationFunction="valida_CPFCNPJ" ControlToValidate="txtCNPJ" Display="None" ErrorMessage="CNPJ inválido." ForeColor="" SetFocusOnError="True">&nbsp;</asp:CustomValidator>
				</div>
			</div>
			<br class='cb' />	
			<div class='trField cb fl' runat='server'  id='trRazaoSocial' visible='<%$Settings: visible, Loja.RazaoSocial, false %>' >
				<div class='tdFieldHeader fl'>
					Raz&atilde;o Social:
				</div>
				<div class='tdField fl' style='width:460px;'>
					<asp:TextBox runat='server' ID='txtRazaoSocial' MaxLength='200' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqRazaoSocial' Enabled='<%$Settings: Required, Loja.RazaoSocial, false %>' Display='None' ErrorMessage='Raz&atilde;o Social &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtRazaoSocial' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trIE' visible='<%$Settings: visible, Loja.IE, true %>' >
				<div class='tdFieldHeader fl' style='width:40px;'>
					IE:
				</div>
				<div class='tdField fl' style='width:130px;'>
					<asp:TextBox runat='server' ID='txtIE' Width='100%' />
					<asp:RequiredFieldValidator runat='server' Enabled='<%$Settings: Required, Loja.IE, true %>' ID='valReqIE' Display='None' ErrorMessage='IE é um campo obrigat&oacute;rio!' ControlToValidate='txtIE' />
				</div>
			</div>
			<br class='cb' />	
			<div class='trField fl cb' runat='server'  id='trRevenda' visible='<%$Settings: visible, Loja.Revenda, true %>' >
				<div class='tdFieldHeader'>
					<asp:Literal ID="ltrRevenda" runat="server" Text='<%$ Settings: caption, Loja.FiltroRevenda, "Revenda" %>' />:
				</div>
				<div class='tdField fl' style="width:460px;">
					<asp:DropDownList runat='server' ID='drpIDCliente' style="width:100%;" DataTextField="Fantasia" DataValueField="IdCliente"></asp:DropDownList>
					<asp:CompareValidator runat='server'  ID='valCompIDCliente' Enabled='<%$Settings: Required, Loja.Cliente, true %>' Display='None' ErrorMessage='ESTÁ SENDO SETADO NO CODEBEHIND' ControlToValidate='drpIDCliente' Operator="GreaterThan" ValueToCompare="0" />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trFilial' visible='<%$Settings: visible, Loja.Filial, false %>' >
				<div class='tdFieldHeader cb fl' style="width:40px;">
					Filial:
				</div>
				<div class='tdField fl' style="width:130px;">
					<asp:TextBox runat='server' ID='txtFilial' MaxLength='100' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqFilial' Enabled='<%$Settings: Required, Loja.Filial, false %>' Display='None' ErrorMessage='Filial &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtFilial' />
				</div>
			</div>
			<br class='cb' />			
			<div class='trField cb' runat='server'  id='trEndereco' visible='<%$Settings: visible, Loja.Endereco, true %>' >
				<div class='tdFieldHeader cb fl'>
					Endereco:
				</div>
				<div class='tdField fl' style="width:360px">
					<asp:TextBox Width="100%" runat='server' ID='txtEndereco' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEndereco' Enabled='<%$Settings: Required, Loja.Endereco, true %>' Display='None' ErrorMessage='Endereco é um campo obrigat&oacute;rio!' ControlToValidate='txtEndereco' />
				</div>
			</div> 
			<div class='fr' style="width:272px;">
			    <div class='trField fl' runat='server' style="width:140px" id='trNumero' visible='<%$Settings: visible, Loja.Numero, true %>' >
				    <div class='tdFieldHeader' style="width:60px;">
					    Numero:
				    </div>
				    <div class='tdField fl' style="width:70px">
					    <asp:TextBox runat='server' ID='txtNumero' Width='100%' />
					    <asp:RequiredFieldValidator runat='server' ID='valReqNumero' Enabled='<%$Settings: Required, Loja.Numero, true %>' Display='None' ErrorMessage='Numero é um campo obrigat&oacute;rio!' ControlToValidate='txtNumero' />
				    </div>
			    </div>
			    <div class='trField fl' runat='server' style="width:130px"  id='trComplemento' visible='<%$Settings: visible, Loja.Complemento, true %>' >
				    <div class='tdFieldHeader' style="width:50px;">
					    Compl.:
				    </div>
				    <div class='tdField fl' style="width:80px">
					    <asp:TextBox runat='server' ID='txtComplemento' Width='100%' />
				    </div>
			    </div>
			</div>
			<br class='cb' />			
			<div class='trField cb' runat='server'  id='trBairro' visible='<%$Settings: visible, Loja.Bairro, true %>' >
				<div class='tdFieldHeader'>
					Bairro:
				</div>
				<div class='tdField fl' style="width:160px;"> 
					<asp:TextBox runat='server' ID='txtBairro' Width='100%' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqBairro' Enabled='<%$Settings: Required, Loja.Bairro, true %>' Display='None' ErrorMessage='Bairro é um campo obrigat&oacute;rio!' ControlToValidate='txtBairro' />
				</div>
			</div>
			<div class='trField fl' runat='server'  id='trCidade' visible='<%$Settings: visible, Loja.Cidade, true %>' >
				<div class='tdFieldHeader' style="width:80px;">
					Cidade:
				</div>
				<div class='tdField fl' style="width:160px;">
					<asp:TextBox runat='server' Width="100%" ID='txtCidade' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCidade' Enabled='<%$Settings: Required, Loja.Cidade, true %>' Display='None' ErrorMessage='Cidade é um campo obrigat&oacute;rio!' ControlToValidate='txtCidade' />
				</div>
			</div>
			<div class='trField fl' runat='server'  id='trUF' visible='<%$Settings: visible, Loja.UF, true %>' >
				<div class='tdFieldHeader' style="width:30px;">
					UF:
				</div>
				<div class='tdField fl' style="width:80px;">
					<asp:DropDownList DataTextField="UF"  Width='100%' DataValueField="UF" runat='server' ID='drpIdUF'></asp:DropDownList>
					<asp:CompareValidator runat='server'  ID='CompareValidator1' Enabled='<%$Settings: Required, Loja.UF, true %>' Display='None' ErrorMessage='UF inv&aacute;lida' ControlToValidate='drpIdUF' Operator="NotEqual" ValueToCompare="0" />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trCEP' visible='<%$Settings: visible, Loja.CEP, true %>' >
				<div class='tdFieldHeader' style="width:30px;">
					Cep:
				</div>
				<div class='tdField fl' style="width:80px;">
					<asp:TextBox runat='server' ID='txtCep' Width='100%' maxlength="9" onkeyup="Formatadata(this,event)"/>
					<asp:RequiredFieldValidator runat='server' ID='valReqCep' Display='None' Enabled='<%$Settings: Required, Loja.CEP, true %>' ErrorMessage='Cep é um campo obrigat&oacute;rio!' ControlToValidate='txtCep' />
				</div>
			</div>
			<br class='cb' />	
			<div class='trField cb' runat='server'  id='trRegiao' visible='<%$Settings: visible, Loja.Regiao, true %>' >
				<div class='tdFieldHeader'>
					Regi&atilde;o:
				</div>
				<div class='tdField fl' style="width:140px;">
					<asp:DropDownList DataTextField="Regiao" Width='100%' DataValueField="IdRegiao" runat='server' ID='drpIDRegiao'></asp:DropDownList>
					<asp:CompareValidator runat='server'  ID='valCompIDRegiao' Enabled='<%$Settings: Required, Loja.Regiao, true %>' Display='None' ErrorMessage='Regiao inv&aacute;lida' ControlToValidate='drpIDRegiao' Operator="GreaterThan" ValueToCompare="0" />
				</div>
			</div>
			<div class='trField fl' runat='server'  id='trTipoLoja' visible='<%$Settings: visible, Loja.TipoLoja, true %>' >
				<div class='tdFieldHeader' style="width:150px;">
                    <asp:Literal ID="ltrTipoLoja" runat="server" Text='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' />:
				</div>
				<div class='tdField fl' style="width:140px;">
			        <asp:DropDownList DataTextField="TipoLoja" Width='100%' DataValueField="IdTipoLoja" runat='server' ID='drpIDTipoLoja'></asp:DropDownList>
					<asp:CompareValidator runat='server'  ID='valCompIDTipoLoja' Display='None' ErrorMessage='ESTÁ SENDO SETADO NO CODEBEHIND' ControlToValidate='drpIDTipoLoja' Operator="GreaterThan" ValueToCompare="0" />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trStatus' visible='<%$Settings: visible, Loja.Status, true %>' >
				<div class='tdFieldHeader'>
					Status:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat='server' ID='drpIdStatus'></asp:DropDownList>
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb' runat='server'  id='trLocalLoja' visible='<%$Settings: visible, Loja.LocalLoja, true %>' >
				<div class='tdFieldHeader'>
                    Local da Loja:
				</div>
				<div class='tdField fl'>
			        <asp:UpdatePanel ID="UpdatePanel1" runat="Server">
			        <ContentTemplate>
			            <uc1:Shopping ID="tljTipoLoja" runat="server" ></uc1:Shopping>
			        </ContentTemplate>
			        </asp:UpdatePanel>
			    </div>
			</div>
			<br class='cb' />
			<div class='trField cb' runat='server'  id='trEmail' visible='<%$Settings: visible, Loja.Email, true %>' >
				<div class='tdFieldHeader'>
					Email:
				</div>
				<div class='tdField fl' style="width:400px;">
					<asp:TextBox runat='server' ID='txtEmail' Width='100%' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' runat='server'  id='Div2' visible='<%$Settings: visible, Loja.GerenteLoja, true %>' >
				<div class='tdFieldHeader'>
					<asp:Literal runat='server' ID='ltrGerente' Text='<%$Settings: Caption, Loja.GerenteLoja, "Gerente da Loja" %>' />:
				</div>
				<div class='tdField fl' style="width:400px">
					<asp:TextBox runat='server' ID='txtGerenteLoja' Width='100%' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' Enabled='<%$Settings: Required, Loja.GerenteLoja, false %>' Display='None' ErrorMessage='Gerente da Loja &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtGerenteLoja' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trTelefone' visible='<%$Settings: visible, Loja.Telefone, true %>' >
				<div class='tdFieldHeader' >
					Telefone:
				</div>
				<div class='tdField fl' style="width:100px">
					<asp:TextBox runat='server' ID='txtTelefone' Width='100%' />
				</div>
			</div>
			<div class='trField cb' style="width:400px;" runat='server'  id='trCelular' visible='<%$Settings: visible, Loja.Celular, true %>' >
				<div class='tdFieldHeader'>
					Celular:
				</div>
				<div class='tdField fl' style="width:100px">
					<asp:TextBox runat='server' ID='txtCelular' Width='100%' />
				</div>
			</div>
			<div class='trField cb' style="width:400px;" runat='server'  id='trFAX' visible='<%$Settings: visible, Loja.FAX, true %>' >
				<div class='tdFieldHeader'>
					Fax:
				</div>
				<div class='tdField fl' style="width:100px">
					<asp:TextBox runat='server' ID='txtFax' Width='100%' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trFoto' Visible='<%$Settings: Visible, Loja.Foto, true %>' >
			    <div class='tdFieldHeader fl' >
					Foto:
				</div>			
			    <div>
		            <uc1:ImageUploader ID="ImageUploaderLoja" runat="server" VirtualPath='~/imagens/Contato_Loja/' NoImage='noimage.png' />
		        </div>
            </div>
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
                            <asp:Button runat="server" ID="btnVerificarPosicao" CausesValidation="false" Text="Verificar Posição" CssClass='Botao' />
                        </div>
                    </div>                    
                </ContentTemplate>
            </asp:UpdatePanel>
			<uc2:CamposAdicionais width="100%" ID="CamposAdicionais1" runat="server" Entidade="Loja" />
			<br class='cb' />
			<br class='cb' />
			<br class='cb' />

            
		</div>
	</div>
	<asp:PlaceHolder runat='server' ID='phlOpcoes'>
        <div id='AreaProdutoPromotor'>
            <asp:Panel runat='server' ID='pnlSegmentacao'>
                <asp:UpdatePanel runat='server' ID='pnlUpdate'>
                    <ContentTemplate>
                        <h4>Produtos cadastrados na loja:</h4>
                        <div class='ListaItens'>
                            <asp:GridView runat='server' ID='grdProdutos' Width='100%' SkinID='GridInterno' DataKeyNames='IDSegmentacao' AutoGenerateColumns='false'>
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:BoundField DataField='Categoria' HeaderText='Segmentos' />
                                    <asp:BoundField DataField='SubCategoria' HeaderText='Categorias' />
                                    <asp:BoundField DataField='DescricaoProduto' HeaderText='Produto' />
                                    <asp:ButtonField  CommandName='Retirar' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                                </Columns>
                                <EmptyDataTemplate>
                                    N&atilde;o h&aacute; produtos cadastrados para essa loja!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div id='AdicionarProdutoPromotor'>
		                    <table id='tblProduto'>
			                    <tr class='trField'>
				                    <td colspan='3'>
					                    <h4>Adicionar uma novo segmenta&ccedil;&atilde;o de produto na loja</h4>
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
				                        <asp:DropDownList runat='server' ID='cboProduto' DataTextField='Descricao' DataValueField='IDProduto' /> 
				                    </td>
			                    </tr>
			                    <tr>
    		                        <td colspan='3'>
                                        <asp:Button runat='server' CausesValidation="false" ID='btnAddSegmentacao' Text='Adicionar produto' class='BotaoAdicionar' />
			                        </td>
			                    </tr>
		                    </table>
	                    </div>
                     </ContentTemplate> 
                </asp:UpdatePanel> 
            </asp:Panel>
        </div> 
    </asp:PlaceHolder> 	
    <div class='AreaBotoes' runat='server' id='trBotoesMain'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Loja.aspx?idloja=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Lojas.aspx'" />
    </div>
    <div class='AreaBotoes' runat='server' id='trBotoesCNPJ'>
        <asp:Button runat='server' ID='btnValidarCNPJ' Text="Verificar CNPJ" CssClass='Botao' />
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

