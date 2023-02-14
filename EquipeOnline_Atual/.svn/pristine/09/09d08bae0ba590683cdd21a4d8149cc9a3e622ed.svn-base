<%@ Page Title="" Language="VB" MasterPageFile="~/basica.master" AutoEventWireup="false" CodeFile="alterar.aspx.vb" Inherits="inicio_alterar" %>

<asp:Content ID="Content10" ContentPlaceHolderID="cphConteudo" Runat="Server">
		<div class="main mainMaster">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="right" valign="top" style="width: 420px">
                </td>
                <td>
                    <table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 345px">
                        <tr>
                          <td align="right" valign="top">
                           <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                       <td>
                                       <asp:PlaceHolder runat='server' ID='plhIdentificacao'>   
                                       
										<table width="450" style="float:right" border="0" cellspacing="0" cellpadding="0"class="TextDefault"  id="Table4">
											<tr>
												<td height="24" valign="top" class="texto" style="font-size:11.2px;" colspan="2">
													CONTA DO CLIENTE /IDENTIFICA&Ccedil;&Atilde;O: 
												</td>
												<td height="24" valign="top" class="texto" align="right" colspan="2" style="margin-left:10px;">
													SENHA MASTER:</td>
											</tr>
											<tr>
												<td width="184">
													<asp:TextBox runat="server" AutoCompleteType='None' id="txtCodigo" MaxLength="20" size="15" cssclass="formulario_2" Height="33px" Width="220px" />
													<br><span style="padding-right:12px\9; padding-right:12px*;">digite com ponto</span></br>                                                    
												</td>
												<td style="width: 4px;">
													<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' ControlToValidate='txtCodigo'>*</asp:RequiredFieldValidator>&nbsp;
												</td>
												<td width="184" style="margin-left:10px;">
													<asp:TextBox runat="server" AutoCompleteType='None' id="txtPin" TextMode='Password' cssclass="formulario_2" MaxLength='20' size="15"/>
												</td>
												<td style="width: 4px">
													<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' ControlToValidate='txtPin'>*</asp:RequiredFieldValidator>&nbsp;
												</td>
											</tr>
											<tr>
												<td style="height: 34px"></td>
												<td style="width: 4px; height: 34px;"></td>
												<td  valign="middle" class="texto" align="right" style="height: 34px">
													EMAIL:
												</td>
												<td style="width: 4px; height: 34px;"></td>
											</tr>
											<tr>
												<td>&nbsp;</td>
												<td style="width: 4px">&nbsp;</td>
												<td style="width: 184px">
													<asp:textbox class="formulario_2" id="txtEmail" runat="server" />	
												</td>
												<td style="width: 4px">
													<asp:RequiredFieldValidator runat='server' ID='valReqEmail' ControlToValidate='txtEmail'>*</asp:RequiredFieldValidator>&nbsp;
												</td>
											</tr>
											<tr>
												<td colspan="2" width="100">
												</td>
												<td height="40" align="right" style="padding-right:12px; padding-top:10px">
		 											<asp:ImageButton runat="server" id="btnOk" TabIndex="4" ImageUrl="../images/buttons/btn_ok.png" alt="" border="0"/>
												</td>
											</tr>
											<tr>
       											<td>&nbsp;</td>
       											<td align="left"><asp:Label runat='server' ID='Label1' cssclass="erro" Visible='false'></asp:Label></td>
      											<td align="left">&nbsp;</td>
    										</tr>
   											<tr>
      											<td height="30" width="200">&nbsp;</td>
    										</tr>		
									</table>                                                 
                                            </asp:PlaceHolder>
                                            <asp:PlaceHolder runat='server' ID='plhMensagem' Visible='false'>
                                                <table border="0" align="left" cellpadding="0" cellspacing="3" height='80px'>
                                                    <tr>
                                                        <td align="left"><span class="texto_brbold"><asp:Label runat='server' id="lblMensagem" CssClass='login' /></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href='login.aspx'><img src="../images/buttons/btn_voltar.png" border='0' /></a>
                                                        </td>
                                                    </tr>
                                                </table> 
                                            </asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
            <table width="760" border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="459" valign="top" class="texto_br" style="height: 10px"></td>
                    <td width="342" valign="top" class="texto_br" style="height: 10px"></td>
                </tr>
                <tr>
                    <td valign="top" class="texto_br">
                        <br>
                        <br>
                        <br>
                        <br>
                        Atendimento ao Cliente: *611 (ligue gr&aacute;tis do seu Nextel)<br>
                        &copy; 2004 Nextel Telecomunica&ccedil;&otilde;es Ltda. Todos os direitos reservados. Direitos Autorais.
                    </td>
                </tr>
            </table>
    <asp:Literal runat='server' ID='ltrScript' EnableViewState='false'></asp:Literal>
</asp:Content>

