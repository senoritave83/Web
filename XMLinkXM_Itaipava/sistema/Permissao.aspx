<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Permissao.aspx.vb" Inherits="Pages.Cadastros.Permissao" %>

<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trPermissao' visible='<%$Settings: visible, Permissao.Permissao, true %>' >
				<div class='tdFieldHeader cb fl'>
					Permissao:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPermissao' MaxLength='256' />
					<asp:RequiredFieldValidator runat='server' ID='valReqPermissao' Enabled='<%$Settings: Required, Permissao.Permissao, false %>' Display='None' ErrorMessage='Permissao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPermissao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Permissao.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField fr'>
				<div class='tdField fl'>
					<a href='permissaoacao.aspx?idpermissao=<%=ViewState(VW_IDPERMISSAO) %>'>Ver a&ccedil;&otilde;es permitidas</a>
				</div>
				
			</div>			
		</div>
	</div>
	<asp:PlaceHolder runat='server' ID='plhUsers'>
	    <asp:ScriptManager runat='server' ID='ScriptManager1' />
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="5" class="Grid" width="100%" id='tblFiltroPermissao' />
                    <tbody>
                        <tr>
                            <td class="GridHeader">
            				    <asp:Label runat='server' ID='lblBuscaUsuario'>
                                     Buscar usuários
                                </asp:Label> 
                            </td>
                        </tr>
                        <tr >
                            <td>
                                <asp:Label runat='server' ID='lblProcurar'>
                                    Procurar em
                                </asp:Label>
                                <asp:DropDownList runat='server' ID='cboSearchType'>
                                    <asp:ListItem Value='username'>User name</asp:ListItem>
                                    <asp:ListItem Value='email'>E-mail</asp:ListItem>
                                </asp:DropDownList>
                                por:
                                <asp:TextBox runat='server' ID='txtFiltro' style="width:11em;" />
                                &nbsp;
                                <asp:Button runat='server' ID='btnProcurar' Text='Procurar' />
                                <br />
                                <asp:Label runat='server' ID='lblProcurarObservacao'>
                                    Caracteres como * and ? s&atilde;o permitidos.
                                </asp:Label>
                                <br/>
                                <uc1:Letras ID="Letras1" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
        	<div class='ListArea'>
				<asp:GridView runat='server' id='grdUsersInRole' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='UserName'>
				    <HeaderStyle HorizontalAlign='Left' />
				    <Columns>
				        <asp:TemplateField HeaderText='Usuário'>
				            <ItemTemplate>
    				            <%#Eval("Usuario")%>
				            </ItemTemplate>
				        </asp:TemplateField>
				        <asp:TemplateField HeaderText='Login'>
				            <ItemTemplate>
    				            <%#Eval("UserName")%>
				            </ItemTemplate>
				        </asp:TemplateField>
				        <asp:TemplateField HeaderText='Possui a permiss&atilde;o' >
				            <ItemTemplate>
				                <asp:CheckBox runat='server' ID='chk' AutoPostBack='true' OnCheckedChanged='chk_OnCheckedChange'  />
				            </ItemTemplate>
				        </asp:TemplateField>
				    </Columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        <div class='GridHeader'>&nbsp;</div>
					        <asp:Label runat='server' ID='lblNaoEncontrados'>
        				        N&atilde;o h&aacute; usu&aacute;rios!
					        </asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
        	</div>
			</ContentTemplate>
        </asp:UpdatePanel>		
	</asp:PlaceHolder>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Permissao.aspx?idpermissao=0'" />
        <input type="button" runat='server' id='btnVoltar' class="Botao" value=" Voltar " onclick="location.href='Permissoes.aspx'" />
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

