<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="grupo_det.aspx.vb" Inherits="configuracoes_grupo_det" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type='text/javascript'>
        function fnConfirm(strTipo){
    				
					    if (strTipo == "E") {
						    return confirm("Confirma exclusão do Grupo?");
					    }
					    else if (strTipo == "N") {
						    return(confirm("Confirma cadastrar novo Grupo e perder as informações?")) //{
							    //window.location = 'w_nxt_grupos_det_br.aspx';
						    //}
					    }
    					
				    }
    </script>

	<table width="101%" align="center">
		<tr class='Header2'> 
			<td>
                Dados do Grupo
			</td>
		</tr>
		<tr>
			<td>
			    <p style="font-size:1.1em;font-weight:bold;font-family: Tahoma, Arial, Helvetica;">
                    Nome do Grupo
				    <asp:RequiredFieldValidator runat='server' ID='valReqGrupo' ErrorMessage='Por favor preencha o nome do grupo' ControlToValidate='txtNome'></asp:RequiredFieldValidator>
				    <span id="imgMensagem" style="VISIBILITY:hidden; COLOR:red">
					    <img src="../../images/exclam2.gif">
					    <span id="strMensagem"></span>
				    </span>
				    <asp:Image id="imgMsg" runat="server" EnableViewState="False" Visible="False" ImageUrl="../images/exclam2.gif"></asp:Image>
				    <asp:Label ID="lblMensagem" ForeColor="red" Runat="server" EnableViewState="False"></asp:Label>
				    <br />
				    <asp:TextBox id="txtNome" runat="server" Width="80%" MaxLength="50" class="formulario"></asp:TextBox>
			    </p>
            </td> 			
        </tr>
        <tr class="Header2">
            <td>
                Respons&aacute;veis
                <img src='../../images/help.gif' alt='Seleciona os Respons&aacute;veis da Equipe de Campo que irão participar do grupo.' />
            </td>
        </tr>
		<tr>
			<td align="left">
			    <asp:Repeater ID="rptResponsavel" Runat="server">
				    <HeaderTemplate>
				        <div style="height:250px;overflow:auto;width:100%">
					    <table id="lstResponsavel" width="70%" style="height:100px;">
				    </HeaderTemplate>
				    <ItemTemplate>
					    <tr>						    						    
						    <td style="padding-left:50px;">
							    <input type="checkbox" name="chkResponsavel" id="chkResponsavel" value='<%#Eval("rsp_responsavel_int_PK")%>' runat="server" />
							    <%#Eval("rsp_responsavel_chr")%>
						    </td>
					    </tr>
				    </ItemTemplate>
				    <FooterTemplate>
                        </table>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
			</td>
		</tr>
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../../images/transpa.gif" alt=""/></td>
        </tr>							
	</table>
</asp:Content>

<asp:Content runat='server' ID='Content2' ContentPlaceHolderID="Botoes">
	<asp:ImageButton id="btnVoltar" runat="server" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar" CausesValidation='false'></asp:ImageButton>
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


<asp:Content runat='server' id='Content3' ContentPlaceHolderID='Ajuda'>
	<b>Salvar:</b> Salva as alterações efetuadas no Grupo de Respons&aacute;veis.<br />
</asp:Content>