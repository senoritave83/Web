<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Cargo.aspx.vb" Inherits="Pages.Cadastros.Cargo" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea' style="padding-left:10px;">
		<div class='divEditArea'>
		    <div>&nbsp;</div>
			<div class='trField cb' runat='server' id='trCargo'>
				<div class='tdFieldHeader fl'>
					Cargo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCargo' MaxLength='100' CssClass="formulario" />
					<asp:RequiredFieldValidator runat='server' ID='valReqCargo' Display='None' ErrorMessage='Cargo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCargo' />
				</div>
			</div>
			<div class='trField cb' runat='server' id='trIDSuperior'>
				<div class='tdFieldHeader fl'>
					Cargo Superior:
				</div>
				<div class='tdField fl'>
                    <asp:DropDownList runat='server' ID='cboSuperior' DataTextField='Cargo' DataValueField='IDCargo' CssClass="Select"></asp:DropDownList>
				</div>
			</div>
	        <div class='trField cb' runat='server' id='trModulos'>
		        <div class='tdFieldHeader fl'>
			        Permitir acesso ao:
		        </div>
		        <div class='tdField fl'>
                    <asp:CheckBoxList runat='server' ID='chkModulos' DataTextField='Modulo' DataValueField='IDModulo' Width='300px' cssclass='ListaModulos'>
                    </asp:CheckBoxList>
		        </div>
	        </div>
	        <div class='trField cb' id='trAdicionarLoja' runat='server'>
		        <div class='fl'>
			        Usu&aacute;rios desse cargo podem adicionar loja avulsa no seu roteiro:
                    <asp:DropDownList runat='server' ID='cboAdicionarLoja' CssClass="formulario">
                        <asp:ListItem Value='0'>No podem adicionar</asp:ListItem>
                        <asp:ListItem Value='1'>Podem adicionar somente lojas que j&aacute; existam em algum roteiro</asp:ListItem>
                        <asp:ListItem Value='2'>Podem adicionar qualquer loja</asp:ListItem>
                    </asp:DropDownList>
		        </div>
	        </div>
			<div class='trField cb' runat='server' id='trCriado'>
				<div class='tdFieldHeader fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<br class='cb' />
		</div>
	</div>
    <div class='ListArea'>
	<asp:UpdatePanel runat='server' id='updRoles'>
	    <ContentTemplate>
		    <asp:GridView runat='server' id='grdRoles' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDPermissao' CellPadding="1" CellSpacing="1">
		        <HeaderStyle HorizontalAlign='Left' />
		        <Columns>
		            <asp:TemplateField HeaderText='Permiss&atilde;o'>
		                <ItemTemplate>
			                <%#Eval("Permissao")%>
		                </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText='Possui a permiss&atilde;o' >
		                <ItemTemplate>
		                    <asp:CheckBox runat='server' ID='chk'/>
		                </ItemTemplate>
		            </asp:TemplateField>
		        </Columns>
			    <EmptyDataTemplate>
			        <div class='divEmptyRow'>
			            <div class='GridHeader'>&nbsp;</div>
			            <asp:Label runat='server' ID='lblNaoEncontrados'>
				            N&atilde;o h&aacute; permiss&otilde;es!
			            </asp:Label>
			        </div>
			    </EmptyDataTemplate>
		    </asp:GridView>
	    </ContentTemplate>
	</asp:UpdatePanel>
	</div>	

    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Cargo.aspx?idcargo=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Cargos.aspx'" />
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
    </div>
</asp:Content>

