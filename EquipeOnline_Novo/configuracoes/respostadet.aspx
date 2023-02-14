<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="respostadet.aspx.vb" Inherits="configuracoes_respostadet" %>

<%@ Register src="../include/FormatOption.ascx" tagname="FormatOption" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center">
		<tr class='Header2'> 
			<td colspan="3">
                Opções de observações na resposta
			</td>
		</tr>
		<tr>
			<td colspan="3" style="padding:10px 0px 10px 10px;text-align:left;">
		        <b>Resposta:&nbsp;</b><asp:Literal runat='server' ID='ltrResposta'></asp:Literal>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <table>
		            <tr>
                        <td ></td>
			            <td align="left">Preenchimento</td>
			            <td align="left">Formato</td>			
		            </tr>
		            <tr>
			            <td style="width:158px;padding:0px 0px 10px 10px;text-align:left;">Observa&ccedil;&atilde;o</td>
			            <td style="padding:0px 10px 0px 0px;text-align:left;">
		                    <asp:DropDownList runat='server' ID='cboOpcaoObs'>
		                        <asp:ListItem Selected='True' Value='0'>Opcional (padrão)</asp:ListItem>
		                        <asp:ListItem Value='1'>Obrigatória</asp:ListItem>
		                        <asp:ListItem Value='2'>Não disponível</asp:ListItem>
		                    </asp:DropDownList>
			            </td>
			            <td>
			                <uc1:FormatOption ID="ctrFormatoObs" runat="server" />	        
			            </td>
		            </tr>			                        
                </table>
            </td>
        </tr>
        <tr class="Header2">
            <td>
                Campos adicionais
            </td>
        </tr>
		<tr>
			<td>
			    <table>
			        <tr>
			            <td style="padding:10px 10px 0px 10px;text-align:left;">Texto</td>
			            <td align="left">Preenchimento</td>
			            <td align="left" style="padding-left:10px;">Formato</td>
			            <td></td>
			        </tr>
			        <asp:Repeater ID="rptAdicionais" Runat="server" >
				        <ItemTemplate>
					        <tr>
						        <td style="padding:0px 10px 0px 10px;text-align:left;">
						            <asp:TextBox runat='server' ID='txtTexto' Text='<%#Eval("texto") %>' />
						            <asp:HiddenField runat='server' ID='hidAdicional' Value='<%#Eval("IDRespostaAdicional") %>' />
						        </td>
						        <td>
		                            <asp:DropDownList runat='server' ID='cboOpcao'>
		                                <asp:ListItem Selected='True' Value='0'>Opcional (padrão)</asp:ListItem>
		                                <asp:ListItem Value='1'>Obrigatório</asp:ListItem>
		                            </asp:DropDownList>
						        </td>
						        <td style="padding:0px 10px 0px 10px;text-align:left;">
                                    <uc1:FormatOption ID="ctrFormato" runat="server" Formato='<%#Eval("Formato") %>' /></td>
						        <td>
						            <asp:ImageButton Runat="server" id='btnApagar' CommandName='Apagar' CommandArgument='<%#Eval("IDRespostaAdicional") %>' ImageUrl='../images/buttons/btn_apagar_secundario.png'/>
						        </td>
					        </tr>
				        </ItemTemplate>
                    </asp:Repeater>
			        <tr>
			            <td style="padding:0px 10px 0px 10px;text-align:left;"><asp:TextBox runat='server' ID='txtTextoNovo'></asp:TextBox></td>
			            <td>
		                    <asp:DropDownList runat='server' ID='cboOpcaoNovo'>
		                        <asp:ListItem Selected='True' Value='0'>Opcional (padrão)</asp:ListItem>
		                        <asp:ListItem Value='1'>Obrigatório</asp:ListItem>
		                    </asp:DropDownList>
			            </td>
			            <td style="padding:0px 10px 0px 10px;text-align:left;">
        			        <uc1:FormatOption ID="fopFormatoNovo" runat="server" />
			            </td>
			            <td>
			                <asp:ImageButton Runat="server" id='btnAdicionar' ImageUrl="~/images/buttons/btn_add_secundario.png"  />
			            </td>
                    </tr>
			    </table>
                <br />
                <script type='text/javascript'>
                    function fncChangeFormat(cbo, txt)  {
                        txt.value = cbo.options[cbo.selectedIndex].value;
                        txt.disabled = (cbo.selectedIndex != 8);
                    }
                    function fncFormatEdited(cbo, txt)  {
                        if (cbo.selectedIndex == 8) {
                            cbo.options[cbo.selectedIndex].value = txt.value;
                        }
                    }
    
    
                </script>
		</td>
	</tr>
    <tr class='Footer1'> 
        <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
    </tr>							
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">	
	<asp:ImageButton id="btnVoltar" runat="server" ImageUrl="../images/buttons/btn_voltar.png" CausesValidation='false'></asp:ImageButton>
    <asp:ImageButton id="btnSalvar" runat="server" ImageUrl="../images/buttons/btn_salvar.png"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

