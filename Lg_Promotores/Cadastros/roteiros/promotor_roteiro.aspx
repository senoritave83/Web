<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="promotor_roteiro.aspx.vb" Inherits="Pages.Cadastros.Roteiros.Cadastros_roteiros_promotor_roteiro" %>
<%@ Register Src="../../controls/VerRoteiro.ascx" TagName="VerRoteiro" TagPrefix="uc2" %>
<%@ Register Src="../../controls/Roteiro.ascx" TagName="Roteiro" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../../Js/jquery-1.6.4.min.js"></script>
    <asp:ScriptManager runat='server' ID='ScriptManager1' />
    <script type="text/javascript">
        var vFadeOut = false;
        function Filtro() {
            /*
            var div = "divFiltro";
            if (document.getElementById(div).style.display == "block") {
            document.getElementById(div).style.display = "none";
            LinkFiltro.innerHTML = "Mostrar Opções de Filtro";
            }
            else {
            document.getElementById(div).style.display = "block";
            LinkFiltro.innerHTML = "Ocultar Opções de Filtro";
            }
            */
            if (vFadeOut == true) {
                LinkFiltro.innerHTML = "Ocultar Opções de Filtro";
                $('#FiltroRoteiro').fadeIn(500, function () {
                    vFadeOut = false;
                });
            }
            else {
                LinkFiltro.innerHTML = "Mostrar Opções de Filtro";
                $('#FiltroRoteiro').fadeOut(500, function () {
                    vFadeOut = true;
                });

            }
        }
    </script>
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr>
				<td>
					<h2>Promotor:</h2><h5><asp:Label runat='server' ID='lblPromotor' /></h5>
					<asp:PlaceHolder runat='server' ID='plhLinkPeriodo' visible='<%$Settings: visible, Roteiro.AdicionarPeriodo, false %>' >
    					<a href="roteiro_periodo.aspx?idpromotor=<%=ViewState(VW_IDPROMOTOR) %>">Ver roteiro pelo periodo</a>
    		        </asp:PlaceHolder> 
				</td>
                <td>
                    <div style="text-align:right; width:100%"><a id="LinkFiltro" href='javascript:Filtro();'>Ocultar Opções de Filtro</a></div>
                </td>
			</tr>
		</table>
	</div>
    <div class='Filtro' id="FiltroRoteiro" >
        <div id="divFiltro" style="display:block;" >
            <div style="float:left; width:25%">Código ou Nome da Loja <br />
               <asp:TextBox ID="txtFiltro" runat="server" MaxLength="100" Width="85%"></asp:TextBox>
	        </div>
            <div style="float:left; width:75%"> <br />
               <asp:Button ID="btnFiltrar" runat="server" cssclass='Botao' Text='Filtrar'></asp:Button>
	        </div>
            <div >
                <uc2:Roteiro ID="rotFiltro" runat="server"/>
            </div>
        </div>
    </div>
	<div class='ListArea'>
	    <asp:Panel runat='server' ID='pnlRoteiros'>
		    <asp:Repeater runat='server' id='rptRoteiros'>
		        <ItemTemplate>
		            <asp:Panel runat='Server' ID='pnlRoteiro' CssClass='VerRoteiro'>
		                <table>
		                    <tr>
		                        <td>
            		                <b>Roteiro: </b><%# Eval("IDRoteiro") %>
		                        </td>
		                        <td width='200px;' align='right'>
		                            <b>Status: </b><%#IIf(Eval("Ativo"), "sim", "n&atilde;o")%>
		                        </td>
		                    </tr>
		                    <tr>
		                        <td>
                		            <uc2:VerRoteiro ID="VerRoteiro1" runat="server" Dia='<%# Eval("Dia") %>' Mes='<%# Eval("Mes") %>' DiaSemana='<%# Eval("DiaSemana") %>' SemanaMes='<%# Eval("SemanaMes") %>' Ano='<%# Eval("Ano") %>' />
		                        </td>
		                        <td align='right'>
		                            <input type='button' value=' Editar ' style="float:right;margin-right:0px" class='Botao' onclick='location.href="roteiro.aspx?idpromotor=<%# Eval("IDPromotor") %>&idroteiro=<%# Eval("IDRoteiro") %>";' <%=iif(plhLinkPeriodo.visible, "disabled", "") %> <%= IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", "") %>/>
		                            <asp:Button runat='server' ID='btnApagar' CommandArgument='<%# Eval("IDRoteiro") %>' CommandName='Apagar' style="float:right;margin-right:0px" cssclass='Botao' Text='Apagar' Visible='<%# Me.User.IsInRole("Supervisor de Cadastro")%>' />
		                        </td>
		                    </tr>
		                </table>
		                <br />
		                <asp:GridView runat='server' ID='dtgLojas' SkinID='GridInterno' Width='95%' DataSource='<%# GetLojasRoteiro(Eval("IDRoteiro")) %>' AutoGenerateColumns='false'>
		                    <HeaderStyle HorizontalAlign='Left' />
		                    <Columns>
                                <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                <asp:BoundField HeaderText='Loja' DataField='Loja' />
                            </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; lojas cadastradas neste roteiro!
                            </EmptyDataTemplate>
		                </asp:GridView>
		            </asp:Panel>
		        </ItemTemplate>
		    </asp:Repeater>
            <br />
	    </asp:Panel>
	</div>
    <div class='AreaBotoes'>
        <input type='button' value=' Adicionar Roteiro ' class='Botao' onclick='location.href="roteiro.aspx?idpromotor=<%= ViewState("IDPromotor") %>";' <%=iif(plhLinkPeriodo.visible, "disabled", "") %> <%= IIF(ViewState("IDSTATUSPROMOTOR") = 0, "disabled", "") %> <%=IIF(VerificaPermissao(SecaoAtual, ACAO_ADICIONAR) = false, "disabled", "") %>/>
        <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
</asp:Content>

