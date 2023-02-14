<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="numeracao.aspx.vb" Inherits="configuracoes_numeracao" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="100%" align="center">
        <tr class='Header1'> 
            <td>
                <strong>Formata&ccedil;&atilde;o do numero da O.S.</strong>
            </td>
        </tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" alt="" /></td>
        </tr>                
        <tr class="Header2">
            <td>
                Escolha o formato desejado para as O.S.
            </td>
        </tr>						
		<tr> 
			<td>
				<table width="100%" style="text-align:left;">
					<tr>
						<td width="248" class='Cinza1'>
                            Prefixo
                        </td>
						<td width="288" height="20" class="cinza1">
							<asp:TextBox Runat="server" ID='txtPrefixo' CssClass="formulario" size="45" MaxLength="4" onKeyUp='exibir();' />
						</td>
						<td width="164" class="cinza1">
                            (At&eacute; 4 caracteres)
                        </td>
					</tr>
					<tr>
						<td class='Cinza1' width="35%">
						    Formato de Numera&ccedil;&atilde;o</td>
						<td>
							<asp:TextBox Runat="server" ID="txtFormato" CssClass="formulario" size="45" MaxLength="10" onKeyUp='exibir();' />
						</td>
						<td class='Cinza1'>(At&eacute; 10 caracteres)</td>
					</tr>
					<tr>
						<td class='Cinza1' width="35%">
						    N&uacute;mero Inicial
                        </td>
						<td>
							<asp:TextBox Runat="server" ID="txtNumeroInicial" CssClass="formulario" size="45" MaxLength="8"	onKeyUp='exibir();' />
						</td>
						<td class='Cinza1'>
                            (At&eacute; 8 caracteres)
                        </td>
					</tr>
					<tr>
						<td class='Cinza1' width="35%">
						    Fator de incremento</td>
						<td>
							<asp:TextBox Runat="server" ID="txtIncremento" CssClass="formulario" size="45" MaxLength="2" onKeyUp='exibir();' />
						</td>
						<td class='Cinza1'>
                            (At&eacute; 2 caracteres)
                        </td>
					</tr>
					<tr>
						<td class='Cinza1' width="35%">
						    Tempo Limite de Atendimento</td>
						<td>
							<asp:TextBox Runat="server" ID="txtTempoLimite" CssClass="formulario" size="45" MaxLength="5" onKeyUp='hora(this.value);' />
                            <asp:RequiredFieldValidator ID="ReqValTempoLimite" runat='server' ControlToValidate='txtTempoLimite' Display="Dynamic" Text='*' ErrorMessage="*"></asp:RequiredFieldValidator>
						</td>
						<td class='Cinza1'>
                            (Formato hh:mm)
                        </td>
					</tr>
				</table>
			</td>
		</tr>		
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" alt="" /></td>
        </tr>							
	</table>


</asp:Content>

<asp:Content runat='server' ID='Content3' ContentPlaceHolderID='Botoes'>
	<asp:ImageButton runat="server" id="btnVoltar" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar"></asp:ImageButton>
    <asp:ImageButton id="btnSalvar" Runat="server" ImageUrl="../images/buttons/btn_salvar.png"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content2' ContentPlaceHolderID='Ajuda'>
	Seu formato de numera&ccedil;&atilde;o da primeira OS enviada ser&aacute; <b><span id='spOS'>ABC0001</span></b> com tempo limite de <b><span id='spTempo'>
	<br />
	60</span></b> hora(s)
    <br />
    <br />
    <b>Salvar:</b> Salve as altera&ccedil;&otilde;es realizadas nos campos acima. </div></td>
			
	<script type='text/javascript'>
		function exibir()
			{
			var Form1 = document.aspnetForm;
			spTempo.innerHTML = document.getElementById('<%=txtTempoLimite.clientID%>').value;
			spOS.innerHTML = Formatar(Math.round(document.getElementById('<%=txtNumeroInicial.ClientID%>').value) + Math.round(document.getElementById('<%=txtIncremento.ClientID%>').value), document.getElementById('<%=txtPrefixo.ClientID%>').value, document.getElementById('<%=txtFormato.ClientID%>').value);
			}
		function Formatar(vData, vPrefixo, vFormat)
			{
			var vValue = vData + '';
			var vRight = '';
			for(var k=vFormat.length; k >= 1; --k)
				{
				var F = vFormat.substring(vFormat.length - 1, vFormat.length);
				if (F == "0" || F == "#")
					{
					k = 1;
					break;
					}
				else
					{
					vRight = F + vRight;
					};
				vFormat = vFormat.substring(0, vFormat.length - 1);
				}
			var vTemp = '';
			for(var i = vFormat.length; i >= 0; --i)
				{
				var F = vFormat.substring(vFormat.length - 1, vFormat.length); //right
				vFormat = vFormat.substring(0, vFormat.length - 1); //left
				if (F == "0" || F == "#")
					{
					if (vValue.length > 0)
						{
						vTemp = vValue.substring(vValue.length - 1, vValue.length) + vTemp;
						vValue = vValue.substring(0, vValue.length - 1);
						}
					else
						{
						if (F == '0') 
							{
							vTemp = '0' + vTemp;
							};
						};
					}
				else
					{
					vTemp = F + vTemp;
					};
				}
				return vPrefixo + vValue + vTemp + vRight;
			}
			exibir();

			function hora(v) {
			    
			    v = v.replace(/\D/g, "") //Remove tudo o que não é dígito
			    //v = v.replace(/^[^012]/, "") //valida o primeiro dígito #
			    //v = v.replace(/^([2])([^0-3])/, "$1") //valida o segundo dígito ##
			    v = v.replace(/^([\d]{2})([^0-5])/, "$1")//valida o terceiro dígito ###
			    v = v.replace(/(\d{2})(\d)/, "$1:$2") //Coloca dois ponto entre o segundo e o terceiro dígitos ##:##
			    v = v.substr(0, 5) //Remove digitos extras (aceita no max 5 caracteres(contando o ':' no meio) )
			    document.getElementById('<%=txtTempoLimite.clientID%>').value = v

			    exibir();
			}
	</script>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>
