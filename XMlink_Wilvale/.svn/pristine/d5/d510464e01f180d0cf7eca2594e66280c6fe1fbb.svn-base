<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PermissaoAcao.aspx.vb" Inherits="sistema_PermissaoAcao" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server' />
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trPermissao' >
				<div class='tdFieldHeader fl'>
					Permissao:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblPermissao' />
				</div>
			</div>
		</div>
	</div>
	<div class='AcaoArea'>
	    <asp:UpdatePanel runat='server' ID='updPermissoes'>
	        <ContentTemplate>
	            <asp:Repeater runat='server' ID='rptSecoes'>
	                <ItemTemplate>
	                    <div class='Secao'><div class='SecaoHeader'><%#Eval("Secao")%></div>
	                        <div class='Acoes'>
	                            <asp:GridView runat='server' AutoGenerateColumns='false' Width="100%" DataSource='<%# ListaAcoes(Eval("Secao")) %>' ShowHeader='false' EnableTheming='false' DataKeyNames='IDAcao' >
	                                <Columns>
	                                    <asp:TemplateField>
	                                        <ItemTemplate>
	                                            <div class='Acao'><asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("Selecionado")%>' Text='<%#Eval("Acao")%>' AutoPostBack='true' OnCheckedChanged="chk_OnCheckedChange" /></div>
	                                        </ItemTemplate>
	                                    </asp:TemplateField>
	                                </Columns>
	                            </asp:GridView>
	                        </div>
	                    </div>
	                </ItemTemplate>
	            </asp:Repeater>
	        </ContentTemplate>
	    </asp:UpdatePanel>
	</div>
	<br class='cb' />
	<br />
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnVoltar' Text=' Voltar ' />
    </div>
</asp:Content>

