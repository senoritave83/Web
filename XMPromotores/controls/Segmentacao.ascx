<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Segmentacao.ascx.vb" Inherits="controls_Segmentacao" %>
<asp:Panel runat='server' ID='pnlSegmentacao'>
    <div id='AreaSegmentacao' style="<%=me.Style%>" >
        <asp:UpdatePanel runat='server' ID='pnlUpdate'>
            <ContentTemplate>
                <h4><asp:Literal runat='server' ID='ltrTitle'>Segmenta&ccedil;&atilde;o:</asp:Literal></h4>
                <div id='AreaLista'>
                    <div class='Filtragem'>
                        <table id='tblSegmentacao' width='100%'>
		                    <tr class='trField'>
			                    <td colspan='2' width='100%'>
				                    <asp:RadioButtonList CellPadding='0' CellSpacing='0' runat="server" ID='rdTipoBusCaProduto' RepeatDirection='Horizontal' AutoPostBack='true'>
                                        <asp:ListItem Text="Linha" Value='Linha'></asp:ListItem>
                                        <asp:ListItem Text='<%$Settings: Caption, Categoria, "Segmento"%>' Value='Categoria'></asp:ListItem>
                                        <asp:ListItem Text='<%$Settings: Caption, SubCategoria, "Categoria"%>' Value='SubCategoria'></asp:ListItem>
                                        <asp:ListItem Text='<%$Settings: Caption, Produto, "Produto"%>' Value='Produto' Selected='True'></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="pnlUpdate" DisplayAfter='1000' DynamicLayout='false'>
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...</ProgressTemplate>
                                    </asp:UpdateProgress> 
			                    </td>
		                    </tr>
		                    <tr class='trField'>
			                    <td class='tdField' width='30%'>
                                    <asp:TextBox runat="server" ID='txtBuscaProduto' Width='100%' CssClass="formulario" Height="25px"></asp:TextBox>
			                    </td>
                                <td>
                                    <asp:Button runat='server' ID='btnBuscarProdutos' Text='Buscar' CssClass="Botao" Height="27px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class='ListaItens'>
                        <asp:GridView runat='server' ID='grdSegmentacao' Width='95%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDSegmentacao'>
                            <HeaderStyle HorizontalAlign='Left' />
                            <Columns>
                                <asp:BoundField DataField='Concorrente' HeaderText='Concorrente' />
                                <asp:TemplateField HeaderText='<%$Settings: Caption, Fornecedor, "Marca"%>'>
                                    <ItemTemplate>
                                         <%#Eval(SettingsExpression.GetProperty("datafield", "Segmentacao.Fornecedor", "Fornecedor"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='<%$Settings: Caption, Categoria, "Segmento"%>'>
                                    <ItemTemplate>
                                         <%#Eval(SettingsExpression.GetProperty("datafield", "Segmentacao.Categoria", "Categoria"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='<%$Settings: Caption, SubCategoria, "Categoria"%>'>
                                    <ItemTemplate>
                                         <%#Eval(SettingsExpression.GetProperty("datafield", "Segmentacao.SubCategoria", "SubCategoria"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText='<%$Settings: Caption, Produto, "Produto"%>'>
                                    <ItemTemplate>
                                         <%#Eval(SettingsExpression.GetProperty("datafield", "Segmentacao.Produto", "Produto"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField  CommandName='RetirarProduto' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir_ico.png"/>' />
                            </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o h&aacute; segmenta&ccedil;&atilde;o cadastrada!
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
                <div id='AdicionarSegmento'>
                    <table id='tblSegmento'>
	                    <tr class='trField'>
		                    <td>
			                    <h4>Adicionar segmenta&ccedil;&atilde;o</h4>
		                    </td>
	                    </tr>
	                    <tr class='trField' runat='server' id='trConcorrente'>
		                    <td class='tdField'>
			                    Concorrente:<br />
		                        <asp:DropDownList runat='server' ID='cboConcorrente' AutoPostBack="true" CssClass="formulario">
		                            <asp:ListItem Value='2' Selected='True'>Todas</asp:ListItem>
		                            <asp:ListItem Value='0'>Própria</asp:ListItem>
		                            <asp:ListItem Value='1'>Concorrente</asp:ListItem>
		                        </asp:DropDownList>
		                    </td>
                        </tr>
                        <tr class='trField' runat='server' id='trMarca'>
		                    <td class='tdField'>
			                    Marca:<br />
		                        <asp:DropDownList runat='server' ID='cboIDMarca' DataTextField='Fornecedor' DataValueField='IDFornecedor' AutoPostBack="true" CssClass="formulario" /> 
		                    </td>
                        </tr>
                        <tr class='trField' runat='server' id='trCategoria'>
		                    <td class='tdField'>
			                    <asp:Literal runat="server" Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal>:<br />
		                        <asp:DropDownList runat='server' ID='cboIDCategoria' DataTextField='Categoria' DataValueField='IDCategoria' AutoPostBack="true" CssClass="formulario" /> 
		                    </td>
                        </tr>
                        <tr class='trField' runat='server' id='trSubCategoria'>
		                    <td class='tdField'>
			                    <asp:Literal ID="Literal1" runat="server" Text='<%$Settings: Caption, SubCategoria, "Categoria"%>'></asp:Literal>:<br />
		                        <asp:DropDownList runat='server' ID='cboIDSubCategoria' DataTextField='SubCategoria' DataValueField='IDSubCategoria' AutoPostBack="true" CssClass="formulario"/> 
		                    </td>
                        </tr>
                        <tr class='trField'>
		                    <td class='tdField'>
		                        <asp:Literal ID="Literal2" runat="server" Text='<%$Settings: Caption, Produto, "Produto"%>'></asp:Literal>:<br />
		                        <asp:DropDownList runat='server' ID='cboIDProduto' DataTextField='Descricao' DataValueField='IDProduto' CssClass="formulario" /> 
		                    </td>
	                    </tr>
	                    <tr>
	                        <td>
                                <asp:Button runat='server' ID='btnAddSegmentacao' Text='Adicionar produto' class='BotaoAdicionar' ValidationGroup='AdicionarSegmento' />
	                        </td>
	                    </tr>
                    </table>
                </div>
             </ContentTemplate> 
        </asp:UpdatePanel> 
    </div> 
</asp:Panel>
