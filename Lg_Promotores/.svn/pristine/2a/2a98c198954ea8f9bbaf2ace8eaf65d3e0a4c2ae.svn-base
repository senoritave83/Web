<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PrecoProduto.ascx.vb" Inherits="controls_PrecoProduto" %>
<asp:Panel runat='server' ID='pnlRoteiro'>
    <asp:UpdatePanel runat=server>
        <ContentTemplate>
            <h2>Preços por UF</h2>
	        <asp:Panel runat='server' ID='pnlDia'>
                 <asp:GridView runat='server' ID='grdPrecos' Width='95%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames="UF">
                    <HeaderStyle HorizontalAlign='Left' />
                    <Columns>
                        <asp:BoundField DataField='UF' HeaderText='UF' />
                        <asp:TemplateField HeaderText="Preço Mínimo">
                            <ItemTemplate>
                                <%#FormatNumber(Eval("PrecoMinimo"),2)%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Preço Máximo">
                            <ItemTemplate>
                                <%#FormatNumber(Eval("PrecoMaximo"), 2)%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName='Excluir' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                    </Columns>
                    <EmptyDataTemplate>
                        N&atilde;o h&aacute; pre&ccedil;os cadastrados para este produto!
                    </EmptyDataTemplate>
                </asp:GridView>
	        </asp:Panel><br />
            <table class="form-preco">
		        <tr>
	                <td><asp:label id="Label13" Runat="server" >UF</asp:label><asp:CompareValidator ValidationGroup="PRECOPRODUTO" Display="Dynamic" ID="CompareValidator2" runat="server" ControlToValidate="drpUF" Operator="NotEqual" ValueToCompare="" Text="*" ErrorMessage="Selecione uma UF"></asp:CompareValidator></td>
                    <td><asp:label id="Label16" Runat="server" >Preço Mínimo</asp:label>
                        <asp:CompareValidator Display="Dynamic" runat="server" ValidationGroup="PRECOPRODUTO" ControlToValidate="txtPrecoMinimoSugerido" Type="Currency" Operator="DataTypeCheck" Text="*" ErrorMessage="Digite corretamente o preço mínimo. Ex 2,53"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ValidationGroup="PRECOPRODUTO" ID="CompareValidator3" Display="Dynamic" runat="server" ControlToValidate="txtPrecoMinimoSugerido" Text="*" ErrorMessage="Preço mínimo obrigatório."></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:label id="Label17" Runat="server" >Preço Máximo</asp:label>
                        <asp:CompareValidator ValidationGroup="PRECOPRODUTO" Display="Dynamic" ID="CompareValidator1" runat="server" ControlToValidate="txtPrecoMaximoSugerido" Type="Currency" Operator="DataTypeCheck" Text="*" ErrorMessage="Digite corretamente o preço máximo. Ex 2,54"></asp:CompareValidator>
                        <asp:CompareValidator ValidationGroup="PRECOPRODUTO" Display="Dynamic" ID="CompareValidator4" runat="server" ControlToValidate="txtPrecoMaximoSugerido" ControlToCompare="txtPrecoMinimoSugerido" Type="Currency" Operator="GreaterThan" Text="*" ErrorMessage="O preço mínimo deve ser menor que o preço máximo"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ValidationGroup="PRECOPRODUTO" ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ControlToValidate="txtPrecoMaximoSugerido" Text="*" ErrorMessage="Preço máximo obrigatório."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:DropDownList CssClass="formulario" ValidationGroup="PRECOPRODUTO" runat="server" ID="drpUF" DataTextField="UF" DataValueField="UF"  ></asp:DropDownList></td>
                    <td><asp:textbox id="txtPrecoMinimoSugerido" ValidationGroup="PRECOPRODUTO" Runat="server" CssClass="formulario" MaxLength="15"></asp:textbox></td>
                    <td><asp:textbox id="txtPrecoMaximoSugerido" ValidationGroup="PRECOPRODUTO" Runat="server" CssClass="formulario" MaxLength="15"></asp:textbox></td>
                    <td><input type=button ValidationGroup="PRECOPRODUTO" ID="btnIncluir" class='Botao' Runat="server" Value="adicionar"></td>                    
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>            
