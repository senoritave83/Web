<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="integracao_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<table class="Configen" width="101%">
		<tr class='Header2'> 
            <td colspan="2">
                Integra&ccedil;&atilde;o dos dados
            </td>
        </tr>
		<tr>
			<td colspan="2"  style="padding:5px 0px 10px 10px; font-size: 10px; height: 25px;" width="50%">
                Nesta &aacute;rea voc&ecirc; poder&aacute; importar arquivos de texto com as O.S. a serem enviadas. Alem de fazer o download de um programa para envio autom&aacute;tico.
                <br />
            </td>
		</tr>
		<tr>			
            <td style="text-align:left; width: 1%;">
                <a href="importar.aspx">
				<img src='../images/bullet_espiralgde.gif' border='0' alt="" style="font-size: 10px; width: 8px;" /></a><span style="font-size: 10px">
				</span>
            </td>
            <td style="padding:0px 0px 10px 0px;">
                <a id="A1" class='Menu' href="importar.aspx" runat='server' style="font-size: 11px">Importar arquivos de O.S.</a>
                <br style="font-size: 10px" />
                <span style="font-size: 10px">Selecione essa op&ccedil;&atilde;o para enviar arquivos
            	</span>
            </td>	                    
        </tr>
	    <tr>
	        <td style="text-align:left; width: 1%;"><a href="#">
                <img src='../images/bullet_espiralgde.gif' border='0' alt="" style="font-size: 10px"/></a><span style="font-size: 10px">
			</span>
            </td>
	        <td style="padding:0px 0px 10px 0px;">
                <a id="A5" class='Menu' href="app/Layout_EOL_v16.doc" runat='server' style="font-size: 11px">Documenta&ccedil;&atilde;o do layout.</a>
                <br style="font-size: 10px" />
	            <span style="font-size: 10px">Documenta&ccedil;&atilde;o do layout utilizado pelo EOL.
	        	</span>
	        </td>	                    
        </tr>
        <asp:PlaceHolder runat='server' ID='plhComIntegracao'>
        <tr>
            <td align="left">
                <a href="#"><img src='../images/bullet_espiralgde.gif' border='0' alt="" /></a>
            </td>
            <td style="padding:0px 0px 10px 0px;" >
                <a id="A2" class='Menu' href="app/eolint20.zip" runat='server'>EOL Integrator vers&atilde;o 2.0</a>
                <br />
                Download do programa de envio e recebimento autom&aacute;tico.
            </td>	                    
        </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat='server' ID='plhSemIntegracao'>
        <tr>
            <td colspan='2' align="left" >
                <br />
                <p style="font-size:11px; text-align:justify; width:auto">
                    O Equipe On Line 2.0 pode tamb&eacute;m funcionar de forma integrada &agrave; sistemas internos existentes em sua empresa (via arquivos XML ou TXT), automatizando o envio e recebimento das OS's entre seu sistema e a equipe em campo equipada com Nextel. Para isto basta adquirir a licen&ccedil;a e fazer o download do rob&ocirc;t integrador do EOL 2.0.
                </p>
                <p style="font-size:11px; text-align:justify; width:auto">
                    Atrav&eacute;s desta integra&ccedil;&atilde;o, a abertura de um chamado digitada em seu sistema interno &eacute; diretamente exportada (ou disparada) para o equipamento Nextel que, ap&oacute;s ser lida e respondida pelo portador do aparelho m&oacute;vel, etapa por etapa, com registro de hora, status, tarefa realizada e demais informa&ccedil;&otilde;es pr&eacute;-cadastradas no site do Equipe on Line, &eacute; automaticamente importada (ou retornada) para seu sistema interno, dando baixa autom&aacute;tica das OS's disparadas.
                </p>
                <p style="font-size:11px; text-align:justify; width:auto">
                    Para saber mais sobre as funcionalidades desta ferramenta, em como adquirir ou integrar ao seu sistema interno, entre em contato com a Nextel via fone 1050 ou com a empresa XM Sistemas via e-mail (<a href='mailto:comercial@xmsistemas.com.br'>comercial@xmsistemas.com.br</a>).   
                </p>
            </td>
        </tr>
        </asp:PlaceHolder>
        <tr class='Footer1'> 
            <td colspan="2" style="height: 25px">
			<img width="1" height="25" src="../images/transpa.gif" alt="" style="font-size: 10px"/></td>
        </tr>	
	</table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
</asp:Content>
<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><a href="/home/calendario.aspx">Calend&aacute;rio</a></dt>
    <dt><a href="/home/agendamentos.aspx">Agendamento</a></dt>
    <dt><span lang="pt-br"><a href="/home/agendamento.aspx">Nova O.S programada</a> </span></dt>
    <dt class="current"><span lang="pt-br"><a href="../integracao/default.aspx">Integra&ccedil;&atilde;o</a> </span></dt>
    </dl>    
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

