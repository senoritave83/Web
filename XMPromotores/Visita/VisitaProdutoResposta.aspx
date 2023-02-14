<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="VisitaProdutoResposta.aspx.vb" Inherits="Pages.Visita.VisitaProdutoResposta" title="XM Promotores - Yes Mobile" %>

<%@ Register src="../controls/pergunta.ascx" tagname="pergunta" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea'>
		<table id='tblEditArea'>
			<tr>
			    <td colspan='3'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='2'>&nbsp;</td>
			    <td rowspan='4'>
			        <table style="BORDER-RIGHT:0px; BORDER-LEFT:0px; BORDER-BOTTOM:0px;" runat="server" id="tblFotos">
			            <tr class='trField'>
			                <td align="center"><asp:Image Width="148" Height="181" ID="imgLider" runat="server" /></td>
			            </tr>
			            <tr class='trField' style="height:'60px';">
			                <td class='tdFieldHeader' style="width:auto;text-align:center;">    
			                    <asp:Label runat='server' ID='lblNomeLider'/></br>
			                </td>
			            </tr>
			            <tr class='trField'>
			                <td align="center"><asp:Image Width="148" Height="181" ID="imgPromotor" runat="server" /></td>
			            </tr>
			            <tr class='trField' style="height:'60px';">
			                <td class='tdFieldHeader' style="width:auto;text-align:center;">    
			                    <asp:Label runat='server' ID='lblNomePromotor'/></br>
			                    <asp:Label runat='server' ID='lblTelefonePromotor'/></br>
			                </td>
			            </tr>
			            <tr class='trField'>
			                <td align="center"><asp:Image Width="148" Height="181" ID="imgContatoLoja" runat="server" /></td>
			            </tr>
			            <tr class='trField' style="height:'60px';" >
			                <td class='tdFieldHeader' style="width:auto;text-align:center;">
			                    <asp:Label runat='server' ID='lblContatoLoja'/></br>
			                    <asp:Label runat='server' ID='lblTelContatoLoja'/></br>
			                </td>
			            </tr>
			        </table>
                </td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoResposta'>
				        <p style="margin-bottom:7px;">Pergunta:</p>
				        <p>Resposta:</p>
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <uc1:pergunta ID="pergunta1" runat="server" />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan=2>&nbsp;</td>
			</tr>
		</table>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnEditar' Text="Editar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="fncVoltar()" />
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
	    <script type='text/javascript'>
	        function fncVoltar(){
	            location.href='Visitaproduto.aspx?idvisita=<%=ViewState(VW_IDVISITA)%>&idproduto=<%=ViewState(VW_IDPRODUTO)%>';
	        }
	    </script>
    </div>
</asp:Content>

