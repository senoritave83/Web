<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AssociadosDet.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.AssociadosDet" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
<script type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>
<HTML>
<head id="Head1" runat="server">
</head>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="center">
					<table cellSpacing="0" width="100%" bgcolor="#809eb7">
						<tr>
							<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="center">
					<form id="frmCad" action="AssociadosDet.aspx" runat="server">
                    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true" ></asp:ScriptManager>
                    <script language="javascript" type="text/javascript">

                        var vCNPJ = true;
                        

                        function CNPJ_OK(oSrc, args) {
                            if (vCNPJ == false)
                                return args.IsValid = false;
                            else
                                return args.IsValid = true;
                        }

                        function VerificaCNPJ() {

                            $("#divRunning").show();
                            var cnpj = $("#txtCNPJ").get(0).value;
                            var p_Retorno = valida_cnpj('txtCNPJ');
                            if(p_Retorno=='CNPJINVALIDO')
                            {
                                $("#imgStatus").attr("src", "Imagens/CNPJ_Invalido.png")
                                $("#imgStatus").show();
                                $("#divRunning").hide();
                                vCNPJ = false;
                                return;
                            }
                            $("#imgStatus").hide();
                            PageMethods.CNPJExiste(cnpj, <%=ViewState("IdAssociado") %>, OnSucceeded, OnFailed);
                        }

                        function OnSucceeded() {
                            vCNPJ = true;
                            $("#imgStatus").show();
                            $("#imgStatus").attr("src", "Imagens/Checked.png")
                            $("#divRunning").hide();
                        }

                        function OnFailed(error) {
                            $("#divRunning").hide();
                            $("#imgStatus").show();
                            $("#imgStatus").attr("src", "Imagens/CNPJ_Ja_Existe.png")
                        }

                         function valida_cnpj(campo){

                            var p_CNPJ = document.getElementById(campo).value;
                            var result = "OK";
                            var i;
                            var numero;
                            var situacao = '';

                            pri = p_CNPJ.substring(0,2);
                            seg = p_CNPJ.substring(3,6);
                            ter = p_CNPJ.substring(7,10);
                            qua = p_CNPJ.substring(11,15);
                            qui = p_CNPJ.substring(16,18);

                            numero = (pri+seg+ter+qua+qui);

                            s = numero;

                            c = s.substr(0,12);
                            var dv = s.substr(12,2);
                            var d1 = 0;

                            for (i = 0; i < 12; i++){
                            d1 += c.charAt(11-i)*(2+(i % 8));
                            }

                            if (d1 == 0){
                                result = "CNPJINVALIDO";
                            }
                            d1 = 11 - (d1 % 11);

                            if (d1 > 9) d1 = 0;

                            if (dv.charAt(0) != d1){
                                result = "CNPJINVALIDO";
                            }

                            d1 *= 2;
                            for (i = 0; i < 12; i++){
                            d1 += c.charAt(11-i)*(2+((i+1) % 8));
                            }

                            d1 = 11 - (d1 % 11);
                            if (d1 > 9) d1 = 0;

                            if (dv.charAt(1) != d1){
                                result = "CNPJINVALIDO";
                            }

                            return result;

                       }
                       /*

                       function valida_cpf(f,campo){
                             pri = eval("document."+f+"."+campo+".value.substring(0,3)");
                             seg = eval("document."+f+"."+campo+".value.substring(4,7)");
                             ter = eval("document."+f+"."+campo+".value.substring(8,11)");
                             qua = eval("document."+f+"."+campo+".value.substring(12,14)");

                             var i;
                             var numero;

                             numero = (pri+seg+ter+qua);

                             s = numero;
                             c = s.substr(0,9);
                             var dv = s.substr(9,2);
                             var d1 = 0;

                             for (i = 0; i < 9; i++){
                                d1 += c.charAt(i)*(10-i);
                             }

                             if (d1 == 0){
                                var result = "falso";
                             }

                             d1 = 11 - (d1 % 11);
                             if (d1 > 9) d1 = 0;

                             if (dv.charAt(0) != d1){
                                var result = "falso";
                             }

                             d1 *= 2;
                             for (i = 0; i < 9; i++){
                                d1 += c.charAt(i)*(11-i);
                             }

                             d1 = 11 - (d1 % 11);
                             if (d1 > 9) d1 = 0;

                             if (dv.charAt(1) != d1){
                                var result = "falso";
                             }

                             if (result == "falso") {
                                alert("CPF inválido!");
                                aux1 = eval("document."+f+"."+campo+".focus");
                                aux2 = eval("document."+f+"."+campo+".value = ''");

                             }
                       }
                       */


                    </script>
						<img src='imagens/TituloCadastroAssociados.jpg' border="0" width="443" height="40">
						<table cellspacing=0 cellpadding=0 width="90%" border=1 bordercolor=#003c6e>
							<tr>
								<td>
								<asp:table id="tblAssociadosDet" BackColor="#EFEFEF" runat="server" width="100%" CellPadding="1" CellSpacing="2" BorderWidth="0">
									<asp:TableRow backcolor="#003C6E">
										<asp:TableCell forecolor="#FFFFFF" HorizontalAlign="Center" CssClass="f8" Text="CADASTRO PRINCIPAL" ColumnSpan="4" />
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="C&oacute;digo"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Status"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboIdStatus" runat="server"></uc1:ComboBox>
										</asp:TableCell>
										<asp:TableCell HorizontalAlign="Right" CssClass="f8" Width="30%" Text="Vendedor(a)" Wrap="False"></asp:TableCell>
										<asp:TableCell HorizontalAlign="Left">
											<uc1:ComboBox id="cboIdVendedor" runat="server"></uc1:ComboBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Fantasia"></asp:TableCell>
										<asp:TableCell ColumnSpan="3" Wrap="False" HorizontalAlign="Left">
											<asp:TextBox runat="server" CssClass="f8" Width="300" ID="txtFantasia" MaxLength="255"></asp:TextBox>
											<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="*" ControlToValidate="txtFantasia"></asp:RequiredFieldValidator>
											&nbsp;&nbsp;
											<asp:label runat="server" CssClass="f8" ID="label">Módulo</asp:label>&nbsp;
											<asp:TextBox runat="server" CssClass="f8" Width="200" ID="txtModulo" MaxLength="27"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Razão Social"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtRazaoSocial" MaxLength="255"></asp:TextBox>
											<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="*" ControlToValidate="txtRazaoSocial"></asp:RequiredFieldValidator>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Tipo Pessoa"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboTipoPessoa" name="cboTipoPessoa" runat="server"></uc1:ComboBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Text="Data da Ativação"></asp:TableCell>
										<asp:TableCell HorizontalAlign="Left">
											<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" CssClass="f8" runat="server" Width="100" ID="txtDataAtivacao" MaxLength="10"></asp:TextBox>
											<asp:RequiredFieldValidator CssClass="f8" ControlToValidate="txtDataAtivacao" Runat="server" ErrorMessage="*" ID="Requiredfieldvalidator12"></asp:RequiredFieldValidator>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Ramo"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboIdRamo" runat="server"></uc1:ComboBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="Atividade"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboIdAtividade" runat="server"></uc1:ComboBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Text="Forma de Pagamento"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboIdFormaPagamento" runat="server"></uc1:ComboBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="Posição"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboIdPosicao" runat="server"></uc1:ComboBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="CPF / CNPJ">
                                            <div class="f8" id='divRunning' style='display:none;' runat="server">
                                                <img src="Imagens/ajax-loader.gif" alt="" />&nbsp;Verificando CNPJ. Aguarde...
                                            </div>
                                        </asp:TableCell>
     									<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtCNPJ" ValidationGroup="CNPJ" onChange="vCNPJ = false;" onblur="VerificaCNPJ();" onKeyDown="FormataCNPJ(this, event);" MaxLength="18"></asp:TextBox>
                                            <img src="Imagens/Checked.png" id='imgStatus' alt="" />
                                            <asp:CustomValidator runat="server" ID="valCNPJ" ValidationGroup="CNPJ" CssClass="f8" ControlToValidate="txtCNPJ" ClientValidationFunction="CNPJ_OK" ErrorMessage="CNPJ Inválido" Display="None"></asp:CustomValidator>
                                            <br />
											<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator7" Runat="server" ErrorMessage="*" ControlToValidate="txtCNPJ"></asp:RequiredFieldValidator>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="IE / RG"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtInscricaoEstadual" MaxLength="50"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Nº de Funcionários" Wrap="False"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtNumFunc" MaxLength="20"></asp:TextBox>
											<asp:CompareValidator Operator="DataTypeCheck" Type="Integer" Runat="server" CssClass="f8" ErrorMessage="*" ControlToValidate="txtNumFunc"></asp:CompareValidator>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="Primeiro Contrato" Wrap="False"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtContrato" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Text="Web Site"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtWebSite" MaxLength="150"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="E-Mail"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEmail" MaxLength="150"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Endereço Skype"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtSkype" MaxLength="35"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Início Plano"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8" runat="server" Width="100" ID="txtDataInicioPlano" MaxLength="10"></asp:TextBox>
											<asp:RequiredFieldValidator Runat=server ControlToValidate=txtDataInicioPlano></asp:RequiredFieldValidator>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="Fim Plano"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8" runat="server" Width="100" ID="txtDataFimPlano" MaxLength="10"></asp:TextBox>
											<asp:RequiredFieldValidator Runat=server ControlToValidate=txtDataFimPlano ID="Requiredfieldvalidator1"></asp:RequiredFieldValidator>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Prazo do Plano" />
										<asp:TableCell ColumnSpan="3">
											<asp:Label CssClass="f8" Runat="server" ID="lblObservacoes" ForeColor="#FF0000"></asp:Label>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Observações" />
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox ID="txtObservacoes" MaxLength="1000" TextMode="MultiLine" Runat="server" CssClass="f8" rows="2" Width="96%"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Imagem do Guia" />
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox ID="txtImagemGuia" MaxLength="100" Runat="server" CssClass="f8" rows="2" Width="96%"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow BackColor="#003C6E">
										<asp:TableCell forecolor="#FFFFFF" HorizontalAlign="Center" CssClass="f8" Text="ENDEREÇO DE ENTREGA" ColumnSpan="4" />
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Endere&ccedil;o"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEndereco" MaxLength="255"></asp:TextBox>
											<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator4" Runat="server" ErrorMessage="*" ControlToValidate="txtEndereco"></asp:RequiredFieldValidator>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Bairro"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplemento" MaxLength="255"></asp:TextBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="CEP"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtCEP" onKeyDown="javascript:FormataCEP(this, event);" MaxLength="9"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="UF"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" autopostback="true" id="cboIdEstado" runat="server"></uc1:ComboBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="Cidade"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboCidade" runat="server"></uc1:ComboBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow BackColor="#003C6E">
										<asp:TableCell forecolor="#FFFFFF" HorizontalAlign="Center" CssClass="f8" Text="ENDEREÇO DE COBRANÇA" ColumnSpan="4" />
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Text="Endere&ccedil;o"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox runat="server" CssClass="f8" Width="96%" ID="txtEnderecoCobranca" MaxLength="255"></asp:TextBox>
											<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator6" Runat="server" ErrorMessage="*" ControlToValidate="txtEnderecoCobranca"></asp:RequiredFieldValidator>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Bairro"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplementoCobranca" MaxLength="255"></asp:TextBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="CEP"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="200px" onKeyDown="javascript:FormataCEP(this, event);" ID="txtCEPCobranca" MaxLength="9"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="UF">
										</asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" autopostback="true" id="cboIdEstadoCobranca" runat="server"></uc1:ComboBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="Cidade"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboCidadeCobranca" runat="server"></uc1:ComboBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell>
										</asp:TableCell>
										<asp:TableCell>
										</asp:TableCell>
										<asp:TableCell>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" HorizontalAlign="center">
											<asp:Button CssClass="f8" ID="btnEnderecoEnt" Text="Utilizar mesmo endereço de Entrega" Runat="server" autopostback="True"></asp:Button>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow backcolor="#003C6E">
										<asp:TableCell forecolor="#FFFFFF" HorizontalAlign="Center" CssClass="f8" Text="ENDEREÇO DE FATURAMENTO" ColumnSpan="4" />
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Endere&ccedil;o"></asp:TableCell>
										<asp:TableCell ColumnSpan="3">
											<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEnderecoFaturamento" MaxLength="255"></asp:TextBox>
											<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator9" Runat="server" ErrorMessage="*" ControlToValidate="txtEnderecoFaturamento"></asp:RequiredFieldValidator>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="Bairro"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplementoFaturamento" MaxLength="255"></asp:TextBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="CEP"></asp:TableCell>
										<asp:TableCell>
											<asp:TextBox CssClass="f8" runat="server" Width="200px" onKeyDown="javascript:FormataCEP(this, event);" ID="txtCEPFaturamento" MaxLength="9"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Width="30%" Text="UF"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" autopostback="true" id="cboIdEstadoFaturamento" runat="server"></uc1:ComboBox>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" Width="30%" Text="Cidade"></asp:TableCell>
										<asp:TableCell>
											<uc1:ComboBox CssClass="f8" id="cboCidadeFaturamento" runat="server"></uc1:ComboBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell>
										</asp:TableCell>
										<asp:TableCell>
										</asp:TableCell>
										<asp:TableCell>
										</asp:TableCell>
										<asp:TableCell CssClass="f8" HorizontalAlign="center">
											<asp:Button CssClass="f8" ID="btnEnderecoCob" Text="Utilizar mesmo endereço de Cobrança" Runat="server" autopostback="True"></asp:Button>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow backcolor="#003C6E">
										<asp:TableCell forecolor="#FFFFFF" HorizontalAlign="Center" CssClass="f8" Text="PRODUTOS" ColumnSpan="4" />
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell CssClass="f8" Text="Descrição dos Produtos" Wrap="False"></asp:TableCell>
										<asp:TableCell ColumnSpan="3" Wrap="False" VerticalAlign="Middle" HorizontalAlign="left">
											<asp:TextBox CssClass="f8" ID="txtProduto" Runat="server" TextMode="MultiLine" Rows="3" Width="100%" ReadOnly="True"></asp:TextBox>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell Text="" ColumnSpan=4 HorizontalAlign=Right>
											<asp:ImageButton Runat="server" CssClass="f8" ImageUrl="Imagens/BotaoDadosAssinatura.gif" BorderStyle="None" ID="btnAssinatura" NAME="btnAssinatura"></asp:ImageButton>&nbsp;
											<asp:ImageButton Runat="server" CssClass="f8" ImageUrl="Imagens/BotaoEditarProdutos.gif" BorderStyle="None" ID="btnProdutos" NAME="btnProdutos"></asp:ImageButton>
										</asp:TableCell>
									</asp:TableRow>
									<asp:TableRow>
										<asp:TableCell text="" ColumnSpan="4">
											<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
										</asp:TableCell>
									</asp:TableRow>
								</asp:table>
								</td>
							</tr>
						</table>
						<br>
						<table cellspacing=0 cellpadding=0 width="90%" border=1 bordercolor=#003c6e>
							<tr>
								<td>
									<table cellspacing=0 cellpadding=0 width="100%" border=0 bgcolor="#003c6e">
										<tr>
											<td width="100%" align=center><font class=f8 color=#ffffff>Contatos</font></td>
											<td><asp:ImageButton CssClass="f8" ID="btnAdicionarContato" Runat="server" ImageUrl="Imagens/BotaoNovoContato.gif" BorderStyle="None" CausesValidation="False" /></td>
										</tr>
									</table>
									<asp:DataGrid id="dtgContatos" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
										<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText='Nome'>
												<ItemTemplate>
													<a href='contatoassociados.aspx?idcontato=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDContato"))%>&idassociado=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDAssociado"))%>'>
														<%# DataBinder.Eval(Container.DataItem, "NomeContato")%>
													</a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
											<asp:BoundColumn DataField='Funcao' HeaderText="Funcão" />
											<asp:BoundColumn DataField='CTelefone' HeaderText="Telefone" />
											<asp:BoundColumn DataField='CFax' HeaderText="Fax" />
                                            <asp:BoundColumn DataField='CCelular' HeaderText="Celular" />
											<asp:BoundColumn DataField='EMail' HeaderText="E-Mail" />
                                            <asp:BoundColumn DataField='Skype' HeaderText="Skype" />
										</Columns>
									</asp:DataGrid>
								</td>
							</tr>
						</table>
						<br>
						<table cellspacing=0 cellpadding=0 width="90%" border=1 bordercolor=#003c6e>
							<tr>
								<td>
									<table cellspacing=0 cellpadding=0 width="100%" border=0 bgcolor="#003c6e">
										<tr>
											<td width="100%" align=center><font class=f8 color=#ffffff>Usuários Cadatrados</font></td>
											<td><asp:ImageButton CssClass="f8" ID="btnAdicionarUsuario" Runat="server" ImageUrl="Imagens/BotaoNovoUsuario.gif" BorderStyle="None" CausesValidation="False" /></td>
										</tr>
									</table>
									<asp:DataGrid id="dtgUsuarios" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
										<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn HeaderText='Nome'>
												<ItemTemplate>
													<a href='usuariosdet.aspx?codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdVendedor"))%>&idassociado=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "EMP_IDEMPRESA_INT_FK"))%>'>
														<%# DataBinder.Eval(Container.DataItem, "Vendedor")%>
													</a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField='Usu_login_chr' HeaderText="Login" />
											<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
											<asp:BoundColumn DataField='Tipo' HeaderText="Tipo de Usuário" />
											<asp:TemplateColumn HeaderText='Situação'>
												<ItemTemplate>
													<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "USU_INDATIVO_IND") = 1, "Ativo", "Inativo")%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:DataGrid>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape id="Rodape1" runat="server"></uc1:Rodape>
		<script type="text/javascript">
			<!--
			function validapagina_data(source, arguments)
			{
				
				if(document.forms('frmCad').cboIdStatus_DropDownList1.value==2 || document.forms('frmCad').cboIdStatus_DropDownList1.value ==4)
				{
					arguments.IsValid=true;
				}
				else
					if(document.forms('frmCad').txtDataInicioPlano.value=='' || document.forms('frmCad').txtDataFimPlano.value=='')
					{
						document.forms('frmCad').txtDataInicioPlano.value = '01/01/1990';
						document.forms('frmCad').txtDataFimPlano.value = '01/01/1990';
					}
            }   

            $("#imgStatus").attr("src", "Imagens/invisivel.gif")
			-->
		</script>
		<script language="vbscript">
			Sub CPFValidate(source, arguments)
				
				Numero = arguments.value
				Numero = Replace(Replace(Replace(Numero, ".", ""), "-", ""), "/", "")
				
				if Numero = "00000000000000" or Numero = "00000000000" then
					arguments.IsValid = true
					exit sub
				end if
				
				CNPJ = (Len(Numero) = 14)
				Temp = Mid(Numero, 1, len(Numero) - 2)
				for j = 1 to 2 
					k = 2
					Soma = 0
					for i = Len(Temp) to 1 step -1
						Y = Cint(Mid(Temp, i, 1))
						Soma = Soma + (Y * k)
						k = k + 1
						if k > 9 and CNPJ then k = 2
					next
					Digito = 11 - (Soma mod 11)
					if Digito >= 10 then Digito = 0
					Temp = Temp & Digito
				next
				
				arguments.IsValid = (temp = Numero)		
				
			end sub			
		</script>
	</body>
</HTML>
