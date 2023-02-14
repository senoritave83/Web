<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="responsavel_det.aspx.vb" Inherits="configuracoes_responsavel_det" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type="text/javascript">
       function fncConfirm() {
           if (confirm("Tem certeza que deseja excluir o responsável do sistema?") == true)
               return true
           else
               return false
       }
   </script>
    <table width="101%" align="center">                        
        <tr class="Header2">
            <td>Dados do Responsável.</td>
        </tr>
        <tr>
	    <td align="left">
		    <table width="90%" cellpadding="2" cellspacing="0" border="0" style="margin-left:10px">
			    <tr>
				    <td colspan='2' width="35%">
					        <b>Nome</b>
                            <asp:RequiredFieldValidator Runat="server" ID='valNome' ControlToValidate="txtNome" ErrorMessage='<img src="../images/exclam2.gif"> Campo obrigatório!' />
					        <br />
						    <asp:textbox class="formulario" id="txtNome" runat="server" MaxLength="30" Width='250px'></asp:textbox>
				    </td>
			    </tr>
			    <tr>
				    <td width="35%" height="16">
                        <b>Telefone</b>&nbsp;<font style="color:gray;">(Formato: 1177777777)</font>
                        <asp:RequiredFieldValidator Runat="server" ID='RequiredFieldValidator1' ControlToValidate="txtTelefone" ErrorMessage='<img src="../images/exclam2.gif"> Campo obrigatório!' />
                        <br />
						<asp:textbox class="formulario" id="txtTelefone" runat="server" MaxLength="10" Width='250px'></asp:textbox>
					</td>
				    <td width="35%" height="16">
				        <b>ID</b>&nbsp;<font style="color:gray;">(Formato: 55*111*111)</font>
                        <asp:RequiredFieldValidator Runat="server" ID='RequiredFieldValidator2' ControlToValidate="txtID" ErrorMessage='<img src="../images/exclam2.gif"> Campo obrigatório!' />
						<br />
						<asp:textbox class="formulario" id="txtID" runat="server" MaxLength="20" Width='250px'></asp:textbox>
					</td>
			    </tr>
                <tr runat="server" id="trDadosUsuario" height="50">
				    <td width="35%" height="16" valign="bottom">
                        <br />
				        <b>Login</b>&nbsp;<font style="color:gray;">(Acesso ao módulo Mobile)</font>
						<br />
						<asp:textbox class="formulario" id="txtLogin" runat="server" MaxLength="20" Width='250px'></asp:textbox>
					</td>
				    <td width="35%" height="16" valign="bottom">
                        <br />
				        <b>Senha</b>&nbsp;<font style="color:gray;">(Acesso ao módulo Mobile)</font>
						<br />
						<asp:textbox class="formulario" id="txtSenha" runat="server" MaxLength="20" Width='250px' TextMode="Password"></asp:textbox>
        			    <asp:Button CausesValidation="false" CssClass="botao_nova_senha" runat="server" ID="btnNovaSenha" style="width:100px" Text="Nova Senha"/>
					</td>
                </tr>
			    <tr>
				    <td colspan='2' class="TextDefault" width="35%" height="16">
                        <br />
				        <b>Observação</b>
				        <br />
				        <asp:textbox class="formulario" id="txtObs" runat="server" Rows="4" TextMode="MultiLine" MaxLength="2000" Width='95%' ></asp:textbox>                            
				    </td>
			    </tr>
            </table>
            <br />
        </td>
    </tr>
        <tr class="Header2">
            <td>
                Grupos
                <img src='../images/help.gif' alt='Determina a qual grupo este usuário irá pertencer.' align="bottom" />
            </td>
        </tr>
        <tr>
            <td>                                                    
                <table>
			        <tr>
				        <td class="TextDefault" width="35%" height="16">
                            <asp:repeater id="rptGrupo" Runat="server">
                                <HeaderTemplate>                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>                                        
                                        <td width="15" style="padding-left:50px;">
                                            <input type="checkbox" name="chkGrupo" value='<%#DataBinder.Eval(Container.DataItem, "grp_Grupo_int_PK")%>' id="chkGrupo" runat="server" />
                                        </td>
                                        <td align="left">
                                            <%#DataBinder.Eval(Container.DataItem, "grp_Grupo_chr")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>							        
	                            </FooterTemplate>
	                        </asp:repeater>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr> 
        <tr class='Footer1'> 
            <td>                
                <img width="1" height="25" src="../images/transpa.gif" alt=""/>
            </td>
        </tr>							
        <asp:PlaceHolder runat='server' ID='plhErro' Visible='false'>
            <tr>
                <td>                                                    
                    <asp:BulletedList runat='server' ID='lstErros' ForeColor="Red">
                    </asp:BulletedList>
                </td> 
            </tr> 
            <tr class='Footer1'> 
                <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
            </tr>							
        </asp:PlaceHolder>
     </table> 
						                 
						                     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton id="btnVoltar" runat="server" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar" CausesValidation='False'></asp:ImageButton>
    <asp:ImageButton id="btnNovo" runat="server" ImageUrl="../images/buttons/btn_novo.png" CssClass="botao"></asp:ImageButton>
    <asp:ImageButton id="btnExcluir" runat="server" ImageUrl="../images/buttons/btn_excluir.png" CssClass="botao"></asp:ImageButton>
    <asp:ImageButton id="btnSalvar" runat="server" ImageUrl="../images/buttons/btn_salvar.png" CssClass="botao"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	<asp:PlaceHolder runat="server" ID='plhNovo'><b>Novo:</b>  Cadastre um novo responsável. <br /></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID='plhSalvar'><b>Salvar:</b>  <asp:Literal runat="server" ID='ltrSalvar'>Salva o registro atual na Lista de Responsáveis. </asp:Literal> <br /></asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID='plhExcluir'><b>Excluir:</b> Exclua este registro da Lista de responsáveis.</asp:PlaceHolder>
</asp:Content>
