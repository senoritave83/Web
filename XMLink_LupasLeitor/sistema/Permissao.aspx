<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Permissao.aspx.vb" Inherits="Pages.Cadastros.Permissao" %>

<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr>
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoPermissao'>
    					Permiss&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtPermissao' MaxLength='256' Width='200px' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCriado'>
					    Criado:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='2'>&nbsp;</td>
			</tr>
            <tr class='tdField fl'>
			    <td><a href='permissaoacao.aspx?idpermissao=<%=ViewState(VW_IDPERMISSAO) %>'>Ver a&ccedil;&otilde;es permitidas</a></td>
		    </tr>
		</table>
	</div>    
	<asp:PlaceHolder runat='server' ID='plhUsers'>
	    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="5" class="Grid" width="100%" id='tblFiltroPermissao' />
                    <tbody>
                        <tr>
                            <td class="GridHeader">
            				    <asp:Label runat='server' ID='lblBuscaUsuario'>
                                     Buscar vendedores
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
				        <asp:TemplateField HeaderText='Vendedor'>
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

