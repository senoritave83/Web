<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="contingencia.aspx.vb" Inherits="configuracoes_contingencia" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center">                    
        <tr class="Header2">
            <td style="height: 20px; padding-left:10px">Selecionar modo de envio de mensagens</td>
        </tr>	                
		<tr>
			<td style="text-align:justify;padding:10px 10px 10px 10px; font-size: 9pt; height: 90px; line-height:16px">					
				O modo de conting&ecirc;ncia 
				&eacute; uma seguran&ccedil;a para a opera&ccedil;&atilde;o da sua empresa. Caso 
				exista alguma manuten&ccedil;&atilde;o ou problemas de rede, sua empresa 
				continua operando com um modo de backup. &Eacute; a seguran&ccedil;a para 
				eventuais problemas t&eacute;cnicos que possam ocorrer na rede de 
				transmiss&atilde;o de dados que podem limitar 
				o acesso ao microbrowser do aparelho. Quando o modo de
				conting&ecirc;ncia estiver ativo, os 
				respons&aacute;veis das Equipes de Campo ir&atilde;o apenas receber Recados Digitais 
				informativos, no formato de SMS, limitados a 120 caracteres, e 
				sem possibilidade de respostas. &Eacute; o backup do sistema para sua 
				opera&ccedil;&atilde;o.
		</td>
        </tr>
        <tr>
            <td align="center" style="padding-left:10px; padding-top:21px; height:91px;">
				<table>
					<tr> 
					<td style="padding-right:10px;">
						<asp:ImageButton Runat="server" ID="btnNormal" ImageUrl="../images/buttons/bt_modonormal.png" CausesValidation="False" onmouseout="MM_swapImgRestore()" ></asp:ImageButton>
					</td>
					<td>
						<asp:ImageButton Runat="server" ID="btnContingencia" ImageUrl="../images/buttons/bt_contingencia.png" CausesValidation="False" onmouseout="MM_swapImgRestore()" ></asp:ImageButton>
					</td>
					</tr>
				</table>
            </td>
		</tr>			
        <tr class='Footer1'> 
            <td>
                <b>Status: 
					<asp:Label Runat="server" ID='lblNormal' CssClass="cinza1" Font-Bold="True" Text='Modo de envio Normal' />
					<asp:Label Runat="server" ID="lblContingencia" CssClass="cinza1" Font-Bold="True" Text='Modo de conting&ecirc;ncia!' />
				</b>
            </td>
        </tr>						
	</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton id='btnVoltar' Runat='server' onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('btnVoltar','','../images/bt_voltar_over.gif',1)" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar_ajuda" ></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	<b>Modo de envio Normal:</b> utiliza o servi&ccedil;o 
	WAP da Nextel para o envio de mensagens, possibilitando 
	o uso de todas as funcionalidades do sistema.
    <br />
    <br />
	<b>Modo de conting&ecirc;ncia:</b> deve ser utilizado 
	apenas quando o usu&aacute;rio n&atilde;o est&aacute; conseguindo enviar 
	mensagens, isto &eacute;, as mensagens n&atilde;o est&aacute;o chegando 
	nos equipamentos em campo. N&atilde;o se esque&ccedil;a de entrar 
	em contato com a nossa central de atendimento para 
	notificar o problema com o envio normal. 
</asp:Content>