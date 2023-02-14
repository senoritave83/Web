<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="grupos.aspx.vb" Inherits="configuracoes_grupos" title="Equipe Online" %>
<%@ Register src="../include/Paginate.ascx" tagname="Paginate" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type='text/javascript'>
        function fncOrdenacao(p_Sort) {
            var vUrl = 'grupos.aspx?Sort=' + p_Sort + '&Desc=<%=ViewState("Desc")%>';

            window.location.href = vUrl;
        }
        function fnExibe(strId) {
            var trDetails = document.getElementById('trDetails' + strId);
            var imgUp = document.getElementById('imgUp' + strId);
            var imgDown = document.getElementById('imgDown' + strId);
            trDetails.style.display = 'inline';
            imgUp.style.display = 'inline';
            imgDown.style.display = 'none';
        }
        function fnNExibe(strId) {
            var trDetails = document.getElementById('trDetails' + strId);
            var imgUp = document.getElementById('imgUp' + strId);
            var imgDown = document.getElementById('imgDown' + strId);
            trDetails.style.display = 'none';
            imgUp.style.display = 'none';
            imgDown.style.display = 'inline';
        }
    </script>
	<table width="101%" align="center">
        <tr class='Header1'> 
            <td>
                <strong><input type='checkbox' name='chkSel' onclick="selectAll(this.form.chkGrupo, this.form.chkSel.checked);" title="Selecionar Todos" />Selecionar Todos</strong>
            </td>
        </tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" alt=""/></td>
        </tr>
		<tr valign="top" bgcolor="white">
			<td>
				<asp:Repeater Runat="server" EnableViewState="False" id="rptGrupos">
					<HeaderTemplate>
						<table id="dtgGrid" width='100%'>
							<tr class="Header2">
							    <td>&nbsp;</td>
								<td colspan="2"><a href='javascript:void();' onclick="fncOrdenacao('grp_Grupo_chr')">Grupo</a></td>
								<td width='140px'><a href='javascript:void();' onclick="fncOrdenacao('grp_Criado_dtm')">Criado em</a></td>
							</tr>
					</HeaderTemplate>
					<ItemTemplate>
						<tr class="griditem">
							<td style="width:20px;">
                                <input type="checkbox" name="chkGrupo" value="<%#Eval("grp_Grupo_int_PK")%>">
                            </td>
							<td align="left">
                                <a href='grupo_det.aspx?idgrupo=<%#Eval("grp_Grupo_int_PK")%>' class="cinza1"><%#Eval("grp_Grupo_chr")%></a>
                            </td>
							<td>
							    <asp:PlaceHolder runat='server' ID='plhSetas'>
								    <img id="imgDown<%# Eval("grp_Grupo_int_PK")%>" src="../images/seta_baixo.gif" border="0" onclick="fnExibe('<%#Eval("grp_Grupo_int_PK")%>');" style="cursor:pointer;" >
								    <img id="imgUp<%# Eval("grp_Grupo_int_PK")%>" src="../images/seta_cima.gif" border="0" onclick="fnNExibe('<%#Eval("grp_Grupo_int_PK")%>');" style="Display:none;cursor:pointer;">
							    </asp:PlaceHolder>
							</td>
							<td align="left">
                                <%#Eval("grp_Criado_dtm")%>
                            </td>
						</tr>
						<tr class="griditem" id="trDetails<%#Eval("grp_Grupo_int_PK")%>" style="Display:none;">
							<td colspan="6">								
								<asp:Repeater ID="rptResponsaveis" Runat="server" EnableViewState="False" >
									<HeaderTemplate>
										<table width="100%" style='padding:2px 2px 2px 2px;'>
											<tr>															
											    <td width='75%'>&nbsp;</td>
												<td class="cinza1" align="left">
													<b>R&aacute;dios</b>
												</td>
											</tr>
									</HeaderTemplate> 
									<ItemTemplate>
											<tr>															
											    <td>&nbsp;</td>
												<td class="cinza1" align="left" style='padding:2px 2px 2px 2px;'>
													<%#DataBinder.Eval(Container.DataItem, "rsp_responsavel_chr")%>
												</td>
											</tr>
									</ItemTemplate>
					                <FooterTemplate>
					                    </table>
					                </FooterTemplate>
								</asp:Repeater>
							</td>
						</tr>
					</ItemTemplate>
					<FooterTemplate>
					    </table>
					</FooterTemplate>
				</asp:Repeater>
			</td>
		</tr>
        <tr>
            <td>
                <uc1:Paginate ID="Paginate1" runat="server" />	
            </td>
        </tr>        
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
        </tr>				
	</table>
              
</asp:Content>


<asp:Content runat="server" ID='Content2' ContentPlaceHolderID="Botoes">
	<asp:ImageButton ImageUrl="../images/buttons/btn_voltar.png" id="btnVoltar" runat="server" CssClass="botao_voltar"></asp:ImageButton>
    <asp:ImageButton ImageUrl="../images/buttons/btn_excluir.png" id="btnExcluir" runat="server" CssClass="botao_exclui_grupos"></asp:ImageButton>
    <asp:ImageButton ImageUrl="../images/buttons/btn_adicionar.png" id="btnAdicionar" runat="server" CssClass="botao"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content runat="server" ID='Content3' ContentPlaceHolderID="Ajuda">
	<b>Novo:</b> Adicione um novo grupo <span lang="pt-br">à </span>Lista de Grupos.<br />
	<b>Excluir:</b> Exclua os grupos selecionados pela caixa de sele&ccedil;&atilde;o.<br />
</asp:Content>
