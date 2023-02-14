<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Configuracoes.aspx.vb" Inherits="sistema_Configuracoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class='EditArea'>
		        <div class='divEditArea'>
		            <div class='divHeader'>&nbsp;</div>
			        <div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Condicao.AprovacaoManual, true %>' >
				        <span class='tdField fl'>				    
				        </span>
				        <div class='tdFieldHeader cb fl'>
				            <asp:CheckBox runat='server' ID='chkAceitaSomenteCondicoesCadastradas' />	Revenda aceita somente condições cadastradas no cliente
				        </div>				
			        </div>
			        <div class='trField cb' runat='server'  id='Div2' visible='<%$Settings: visible, Condicao.AguardaAprovacaoCondicaoCliente, true %>' >
				        <span class='tdField fl'>				    
				        </span>
				        <div class='tdFieldHeader cb fl'>
					        <asp:CheckBox runat='server' ID='chkAguardaAprovacaoCondicaoCliente' />
					        Aguardar para APROVAÇÃO MANUAL pedidos sem a condição de pagamento cadastrada para o cliente
				        </div>
			        </div>
			        <div class='trField cb' runat='server'  id='Div4' visible='<%$Settings: visible, Condicao.AguardaAprovacaoClienteDuplicataVencida, true %>' >
				        <span class='tdField fl'>				    
				        </span>
				        <div class='tdFieldHeader cb fl'>
					        <asp:CheckBox runat='server' ID='chkAguardaAprovacaoClienteDuplicata' />
					        Aguardar para APROVAÇÃO MANUAL pedidos de clientes com DUPLICATA(S) VENCIDA(S)
				        </div>
			        </div>
			        <div class='trField cb' runat='server'  id='Div3' visible='<%$Settings: visible, Roteiros.PermiteAcumuloRoteiros, true %>' >
				        <span class='tdField fl'>				    
				        </span>
				        <div class='tdFieldHeader cb fl'>
					        <asp:CheckBox runat='server' ID='chkPermiteAcumuloRoteiros' />
					        Revenda permite ACÚMULO DE ROTEIROS
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='Div5' visible='<%$Settings: visible, Condicao.AguardaAprovacaoCondicaoCliente, true %>' >
				        <span class='tdField fl'>				    
				        </span>
				        <div class='tdFieldHeader cb fl'>
					        <asp:CheckBox runat='server' ID='chkAguardaAprovacaoPedidosBonificados' />
					        Aguardar para APROVAÇÃO MANUAL pedidos que contenham itens bonificados
				        </div>
			        </div>
		        </div>
	        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
	<div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='../Cadastros'" />
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
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

