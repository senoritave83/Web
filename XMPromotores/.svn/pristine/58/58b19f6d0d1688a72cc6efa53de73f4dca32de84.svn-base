<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Permissoes.ascx.vb" Inherits="controls_Permissoes" %>
	<asp:UpdatePanel runat='server' id='updRoles'>
	    <ContentTemplate>
		    <asp:GridView runat='server' id='grdRoles' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDPermissao,Permissao' CellPadding="1" CellSpacing="1" >
		        <HeaderStyle HorizontalAlign='Left' />
		        <Columns>
		            <asp:TemplateField HeaderText='Permiss&atilde;o'>
		                <ItemTemplate>
			                <%#Eval("Permissao")%>
		                </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText='Possui a permiss&atilde;o' >
		                <ItemTemplate>
		                    <asp:CheckBox runat='server' ID='chk' AutoPostBack='true' />
		                </ItemTemplate>
		            </asp:TemplateField>
		        </Columns>
			    <EmptyDataTemplate>
			        <div class='divEmptyRow'>
			            <div class='GridHeader'>&nbsp;</div>
			            <asp:Label runat='server' ID='lblNaoEncontrados'>
				            N&atilde;o h&aacute; permiss&otilde;es!
			            </asp:Label>
			        </div>
			    </EmptyDataTemplate>
		    </asp:GridView>
	    </ContentTemplate>
	</asp:UpdatePanel>

