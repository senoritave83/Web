<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Permissao.aspx.vb" Inherits="Pages.Cadastros.Permissao" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea'>
		<div class='divEditArea' style="padding-left:10px;">
		    <div>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trPermissao' visible='<%$Settings: visible, Permissao.Permissao, true %>' >
				<div class='tdFieldHeader fl'>
					<a style="padding-right:8px;">Permissao:</a>
					<asp:TextBox runat='server' ID='txtPermissao' MaxLength='256' CssClass="formulario" />
					<asp:RequiredFieldValidator runat='server' ID='valReqPermissao' Display='None' ErrorMessage='Permissao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPermissao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Permissao.Criado, true %>' >
				<div class='tdFieldHeader fl'>
					<a>Data de cria&ccedil;&atilde;o:</a>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField fr' runat='server' id='trAcoes'>
				<div class='tdField fl'>
					<a href='permissaoacao.aspx?idpermissao=<%=ViewState(VW_IDPERMISSAO) %>'>Ver a&ccedil;&otilde;es permitidas</a>
				</div>
				
			</div>			
            <br class='cb'/>
		</div>
	</div>
	<asp:PlaceHolder runat='server' ID='plhUsers'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="Filtro">
                <table cellspacing="0" cellpadding="5" class="Grid" width="80%" id='tblFiltroPermissao' >
                    <tbody>
                        <tr>
                            <td class="GridHeader">
            				    <asp:Label runat='server' ID='lblBuscaUsuario'>
                                   <h3>Buscar usu&aacute;rios</h3> 
                                </asp:Label> 
                            </td>
                        </tr>
                        <tr >
                            <td>
                                <asp:Label runat='server' ID='lblProcurar'>
                                    <span>Procurar em</span>
                                </asp:Label>
                                <asp:DropDownList runat='server' ID='cboSearchType' CssClass="Select">
                                    <asp:ListItem Value='username'>User name</asp:ListItem>
                                    <asp:ListItem Value='email'>E-mail</asp:ListItem>
                                </asp:DropDownList>
                                por:
                                <asp:TextBox runat='server' ID='txtFiltro' style="width:11em;" CssClass="formulario" />
                                &nbsp;
                                <asp:Button runat='server' ID='btnProcurar' Text='Procurar' style="float:none;"/>
                                <br />
                                <asp:Label runat='server' ID='lblProcurarObservacao'>
                                    Caracteres como * and ? s&atilde;o permitidos.
                                </asp:Label>
                                <br/>
                                <span class="FiltroLetras">
                                <xm:Letras ID="Letras1" runat="server" />
                                </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
                <br />
        	<div class='ListArea'>
				<asp:GridView runat='server' id='grdUsersInRole' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='UserName' CellPadding="1" CellSpacing="1" >
				    <HeaderStyle HorizontalAlign='Left' />
				    <Columns>
				        <asp:TemplateField HeaderText='Usu&aacute;rio'>
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
        <br class="cb" />
		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
        	    <div class='ListArea'>
				    <asp:GridView runat='server' id='grdCargos' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDCargo' CellPadding="1" CellSpacing="1">
				        <HeaderStyle HorizontalAlign='Left' />
				        <Columns>
				            <asp:TemplateField HeaderText='Cargo'>
				                <ItemTemplate>
    				                <%#Eval("Cargo")%>
				                </ItemTemplate>
				            </asp:TemplateField>
				            <asp:TemplateField HeaderText='Possui a permiss&atilde;o' >
				                <ItemTemplate>
				                    <asp:CheckBox runat='server' ID='chk' AutoPostBack='true' OnCheckedChanged='chk_OnCheckedChangeCargo'  />
				                </ItemTemplate>
				            </asp:TemplateField>
				        </Columns>
					    <EmptyDataTemplate>
					        <div class='divEmptyRow'>
					            <div class='GridHeader'>&nbsp;</div>
					            <asp:Label runat='server' ID='lblNaoEncontrados'>
        				            N&atilde;o h&aacute; cargos!
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

