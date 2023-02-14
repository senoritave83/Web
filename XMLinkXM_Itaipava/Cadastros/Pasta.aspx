<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pasta.aspx.vb" Inherits="Pages.Cadastros.Pasta" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Roteiro.ascx" tagname="Roteiro" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trIDVendedor' visible='<%$Settings: visible, Pasta.IDVendedor, true %>' >
				<div class='tdFieldHeader cb fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboIDVendedor" DataTextField="Vendedor" DataValueField="IDVendedor" />
					<asp:CompareValidator runat="server"  ID="valCompIDVendedor" Display="None" ErrorMessage="Vendedor inv&aacute;lido" ControlToValidate="cboIDVendedor" Operator="GreaterThan" ValueToCompare="0" Enabled='false' />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDVendedor' Display='None' ErrorMessage='Vendedor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDVendedor' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDescricao' visible='<%$Settings: visible, Pasta.Descricao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Descricao:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='30' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Enabled='<%$Settings: Required, Pasta.Descricao, true %>' Display='None' ErrorMessage='Descricao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDias' visible='<%$Settings: visible, Pasta.Dias, true %>' >
				<div class='tdFieldHeader cb fl'>
					Dias:
				</div>
				<div class='tdField fl'>
					<uc1:Roteiro ID="Roteiro1" runat="server" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Pasta.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
		</div>
	</div>
    <div class='EditArea'>
		<div class='divEditArea'>
	        <div class='ListArea'>
                <asp:GridView runat='server' id='grdClientes' AutoGenerateColumns='false'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDCliente" DataNavigateUrlFormatString="Cliente.aspx?IDCliente={0}" DataTextField="Cliente" HeaderText="Clientes cadastrados na pasta" SortExpression="Cliente"  />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; Clientes cadastrados na pasta!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <uc1:paginate ID="Paginate1" runat="server" />
             </div>
        </div>
    </div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pasta.aspx?idpasta=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Pastas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar' Text="			        &lt;b&gt;Gravar:&lt;/b&gt;
				    Grava as altera&amp;ccedil;&amp;otilde;es efetuadas no banco.
		        "></asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar' Text="			        &lt;b&gt;Apagar:&lt;/b&gt;
				    Apaga o registro atual.
		        "></asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo' Text="			        &lt;b&gt;Novo:&lt;/b&gt;
				    Abre para edi&amp;ccedil;&amp;atilde;o um novo registro, fechando o atual sem gravar as altera&amp;ccedil;&amp;otilde;es.
		        "></asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar' Text="			        &lt;b&gt;Voltar:&lt;/b&gt; Volta para o menu anterior.
		        "></asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

