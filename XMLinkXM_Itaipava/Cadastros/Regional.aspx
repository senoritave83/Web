<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Regional.aspx.vb" Inherits="Pages.Cadastros.Regional" title="Untitled Page" %>


<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' />
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trRegional' visible='<%$Settings: visible, Regional.Regional, true %>' >
				<div class='tdFieldHeader cb fl'>
					Regional:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtRegional' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqRegional' Enabled='<%$Settings: Required, Regional.Regional, true %>' Display='None' ErrorMessage='Regional &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtRegional' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trIDSuperior' visible='<%$Settings: visible, Regional.IDSuperior, true %>' >
				<div class='tdFieldHeader cb fl'>
					Regional Superior:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat='server' ID='cboIDSuperior' DataTextField='Regional' DataValueField='IDRegional'></asp:DropDownList>
				</div>
			</div>
		</div>
	</div>
	<asp:PlaceHolder runat='server' ID='plhRegionaisSubordinadas'>
        <div class='ListArea'>
            <asp:GridView runat='server' id='grdRegionaisSubordinadas' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDRegional'>
                <HeaderStyle HorizontalAlign='Left' />
                <Columns>
                    <asp:HyperLinkField DataTextField='Regional' HeaderText='Regionais Subordinadas' DataNavigateUrlFields='IDRegional' DataNavigateUrlFormatString='regional.aspx?idregional={0}' />
                    <asp:BoundField DataField='Nivel' HeaderText='Nivel' />
                </Columns> 
            </asp:GridView> 
        </div> 
	</asp:PlaceHolder>
	<br />
	<asp:PlaceHolder runat='server' ID='plhRevendas'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="5" class="Grid" width="100%" id='tblFiltroPermissao' />
                    <tbody>
                        <tr>
                            <td class="GridHeader">
            				    <asp:Label runat='server' ID='lblBuscaRevenda'>
                                     Buscar revendas dessa regional
                                </asp:Label> 
                            </td>
                        </tr>
                        <tr >
                            <td>
                                <asp:Label runat='server' ID='lblProcurar'>
                                    Procurar por:
                                </asp:Label>
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
		            <asp:GridView runat='server' id='grdEmpresas' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDEmpresa'>
		                <HeaderStyle HorizontalAlign='Left' />
		                <Columns>
		                    <asp:TemplateField HeaderText='Revenda'>
		                        <ItemTemplate>
			                        <%#Eval("Empresa")%>
		                        </ItemTemplate>
		                    </asp:TemplateField>
		                    <asp:TemplateField HeaderText='Pertence a regional' >
		                        <ItemTemplate>
		                            <asp:CheckBox runat='server' ID='chk' AutoPostBack='true' OnCheckedChanged='chk_OnCheckedChange'  />
		                        </ItemTemplate>
		                    </asp:TemplateField>
		                </Columns>
			            <EmptyDataTemplate>
			                <div class='divEmptyRow'>
			                    <div class='GridHeader'>&nbsp;</div>
			                    <asp:Label runat='server' ID='lblNaoEncontrados'>
				                    N&atilde;o h&aacute; revendas!
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
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Regional.aspx?idregional=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Regionais.aspx'" />
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

