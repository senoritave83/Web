﻿<%@ Page Language="VB"  MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatorioPreco_det.aspx.vb" Inherits="Relatorios_RelatorioPreco_det" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat='server' />
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updRep" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	  <asp:UpdatePanel runat="server" ID="updRep">
        <ContentTemplate>
	        <uc1:Filtro ID="Filtro1" runat="server" ShowCategoriaPesquisa="true" ShowMarca="true" ShowProdutoPesquisa="true"   ShowSupervisor="false" StatusClass='FiltroItem' />
               <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
	        <asp:GridView Runat="server" ID='grdRelatorioPreco' Width="100%" AutoGenerateColumns="False" ShowFooter='true' SkinID='GridRelatorios'>
	                <HeaderStyle HorizontalAlign='Center' />
                    <RowStyle HorizontalAlign='Center' />
		            <Columns>
                        <asp:BoundField HeaderText="Categoria" DataField='Categoria' />
			            <asp:BoundField HeaderText="Marca" DataField='Marca' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign='Left'/>
                        <asp:BoundField HeaderText="Produto" DataField='Produto' />
                      <asp:TemplateField HeaderText="Preço Ponta" ItemStyle-Width="80">
				                                <ItemTemplate>
					                                <font class="TextDefault">
						                                <%# FormatCurrency(Eval("PrecoPonta"), 2)%>
					                                </font>
				                                </ItemTemplate>
			                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Preco Varejo">
				                                <ItemTemplate>
					                                <font class="TextDefault">
						                                <%# FormatCurrency(Eval("PrecoVarejo"), 2)%>
					                                </font>
				                                </ItemTemplate>
			                                </asp:TemplateField>
                        		            </Columns>
                    <EmptyDataTemplate>                   
                        Não há registros com o filtro selecionado!
                    </EmptyDataTemplate>
	            </asp:GridView>
            <div id='divEmpty' class='divEmptyRow' runat='server' visible='false' >
	            N&atilde;o h&aacute; registros com o filtro selecionado!
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>