<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Promotor_Roteiro.aspx.vb" Inherits="Pages.Cadastros.Promotor_Roteiro" title="XM Promotores - Yes Mobile" %>

<%@ Register Src="../controls/VerRoteiro.ascx" TagName="VerRoteiro" TagPrefix="uc2" %>
<%@ Register Src="../controls/Roteiro.ascx" TagName="Roteiro" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript">
        function Filtro() {
            var div = "divFiltro";
            if (document.getElementById(div).style.display == "block") {
                document.getElementById(div).style.display = "none";
                LinkFiltro.innerHTML = "Mostrar Op&ccedil;&otilde;es de Filtro";
            }
            else {
                document.getElementById(div).style.display = "block";
                LinkFiltro.innerHTML = "Ocultar Op&ccedil;&otilde;es de Filtro";
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
			</tr>
		</table>
	</div>
    <div>
        <div id="DivLinkFiltro" ><a id="LinkFiltro" href='javascript:Filtro();'>Ocultar Op&ccedil;&otilde;es de Filtro</a></div>
        <div id="divFiltro" style="display:block;" >
            <div style=" text-align:left; width:25%; margin-left:20px; margin-bottom:20px;"><h3>C&oacute;digo ou Nome da Loja</h3>
               <asp:TextBox ID="txtFiltro" runat="server" MaxLength="100" Width="85%" CssClass="formulario"></asp:TextBox>
	        </div>
            <div style="clear:both;">
                <uc2:Roteiro ID="rotFiltro" runat="server"/>
            </div>
            <div style="width:75%; margin:50px 0 10px 20px; margin:0\9; margin-left:8px\9"> 
               <asp:Button ID="btnFiltrar" runat="server" cssclass='Botao' Text='Filtrar'></asp:Button>
	        </div>
        </div>
    </div>
    <div style="clear:both;"></div>
	<div class='ListArea' style="padding-top:20px;">
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
                		            <uc2:VerRoteiro ID="VerRoteiro1" runat="server" Dia='<%# Eval("Dia") %>' Mes='<%# Eval("Mes") %>' DiaSemana='<%# Eval("DiaSemana") %>' SemanaMes='<%# Eval("SemanaMes")%>' UnicoPeriodo='<%# Eval("UnicoPeriodo") %>' />
		                        </td>
		                        <td align='right'>
                                    <input type='button' value=' Editar ' style="float:right;margin-right:0px" class='Botao' onclick='location.href="roteiro.aspx?idpromotor=<%# Eval("IDPromotor") %>&idroteiro=<%# Eval("IDRoteiro") %>";' <%=iif(plhLinkPeriodo.visible OR ViewState("IDSTATUSPROMOTOR") = 0, "disabled", "") %> />
		                            <asp:Button runat='server' ID='btnApagar' CommandArgument='<%# Eval("IDRoteiro") %>' CommandName='Apagar' style="float:right;margin-right:5px" cssclass='Botao' Text='Apagar' Visible='<%# Me.PermiteApagar()%>' />
		                        </td>
		                    </tr>
		                </table>
		                <br />
		                <asp:GridView runat='server' ID='dtgLojas' SkinID='GridInterno' Width='95%' DataSource='<%# GetLojasRoteiro(Eval("IDRoteiro")) %>' AutoGenerateColumns='false'>
		                    <HeaderStyle HorizontalAlign='Left' />
		                    <Columns>
                                <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                <asp:BoundField HeaderText='Loja' DataField='Loja' />
                                <asp:BoundField HeaderText='Endere&ccedil;o' DataField='ENDERECO' />
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
        <asp:Button runat='server' ID='btnAddRoteiro' Text=' Adicionar Roteiro ' CssClass='Botao' Width="143px" />
        <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
</asp:Content>

