<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="ConfigGerais.aspx.vb" Inherits="configuracoes_ConfigGerais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center" class="config-campos">                    
        <tr class="Header2">
            <td style="height: 20px; padding-left:10px">Configura&ccedil;&atilde;o de campos de endere&ccedil;o.<br /></td>
        </tr>	                
        <tr>
            <td align="center" style="height:50px;">
				<table width="100%">
					<tr> 
					    <td style="padding-left:10px;" align="left">
						    <asp:RadioButtonList runat="server" ID="radMostrarOrigemDestino">
                                <asp:ListItem Value="0" Text="Mostrar apenas endereço de origem"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Mostrar endereços de origem e destino" Selected="True" ></asp:ListItem>
                            </asp:RadioButtonList>
					    </td>
					</tr>
				</table>
            </td>
		</tr>	
        <tr class="Header2">
            <td style="height: 20px; padding-left:10px">Selecionar modo de c&oacute;pia do endereço na tela de envio de ordem de serviço.</td>
        </tr>	
		<tr>
			<td style="text-align:justify;padding:10px 10px 0px 10px; font-size: 9pt; height: 15px; line-height:16px">					
				Ao selecionar um cliente na lista de clientes o EOL pode, automaticamente, copiar o endere&ccedil;o para os campos
                "Endere&ccedil;o de Origem" ou "Endere&ccedil;o de Destino".
		</td>
        </tr>
        <tr>
            <td align="center">
				<table width="100%">
					<tr> 
					    <td style="padding:6px 0 0 10px;" align="left">
						    <asp:RadioButtonList runat="server" ID="radCopiarEndereco">
                                <asp:ListItem Value="1" Text="Não copiar"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Copiar endereço e referência para o campo de origem" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="3" Text="Copiar endereço e referência para o campo de destino" ></asp:ListItem>
                            </asp:RadioButtonList>
					    </td>
					</tr>
				</table>
            </td>
		</tr>			
	</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
    <asp:ImageButton Runat="server" ID="btnSalvar" ImageUrl="../images/buttons/btn_salvar2.png" CssClass="botao"></asp:ImageButton>
	<asp:ImageButton id='btnVoltar' Runat='server' onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('btnVoltar','','../images/bt_voltar_over.gif',1)" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar_ajuda" ></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">

</asp:Content>