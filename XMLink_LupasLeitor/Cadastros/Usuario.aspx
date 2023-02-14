<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Usuario.aspx.vb" Inherits="Pages.Cadastros.Usuario" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoUsuario'>
						Nome:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='3'>
					<asp:TextBox runat='server' ID='txtUsuario' MaxLength='100' Width='50%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqUsuario' Display='None' ErrorMessage='Usuario &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtUsuario' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextologin'>
						login:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtlogin' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqlogin' Display='None' ErrorMessage='login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtlogin' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoEmail'>
						Email:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtEmail' MaxLength='256' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoSenha'>
						Senha:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <asp:UpdatePanel runat="server" id="pnlSenha">
				        <ContentTemplate>
        					<asp:TextBox runat="server" ID="txtSenha" MaxLength="20" TextMode="Password" />
        					<asp:Button runat="server" ID="btnNovaSenha" Text="Nova Senha" style="margin-left:0px;" />
				        </ContentTemplate>
				    </asp:UpdatePanel>
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoAdministrador'>
						Administrador:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkAdministrador' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoUltimoAcesso'>
						&Uacute;ltimo Acesso:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblUltimoAcesso' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCriado'>
						Data de cria&ccedil;&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
			</tr>
			<tr class='trField' >
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoObservacao'>
						observa&ccedil;&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='3'>
					<asp:TextBox runat='server' ID='txtObservacao' TextMode="Multiline" Rows="3" Width='50%'  />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan=2>&nbsp;</td>
			</tr>
		</table>
	</div>
	<div class='ListArea'>
	<asp:UpdatePanel runat='server' id='updRoles'>
	    <ContentTemplate>
		    <asp:GridView runat='server' id='grdRoles' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='Permissao'>
		        <HeaderStyle HorizontalAlign='Left' />
		        <Columns>
		            <asp:TemplateField HeaderText='Permissão'>
		                <ItemTemplate>
			                <%#Eval("Permissao")%>
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Usuario.aspx?idusuario=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Usuarios.aspx'" />
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

