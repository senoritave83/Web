<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="PermissaoAcao.aspx.vb" Inherits="sistema_PermissaoAcao" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server' />
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trPermissao' visible='<%$Settings: visible, Permissao.Permissao, true %>' >
				<div class='tdFieldHeader cb fl'>
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
	                        <asp:GridView runat='server' ID='grdPermissoes' AutoGenerateColumns='false' Width="100%" DataSource='<%# ListaAcoes(Eval("Secao")) %>' ShowHeader='false' EnableTheming='false' DataKeyNames='IDAcao' >
	                            <Columns>
	                                <asp:TemplateField>
	                                    <ItemTemplate>
	                                        <div class='Acao' id='divAcao' ><asp:CheckBox ID='CheckBox1' ForeColor='<%#iif(Eval("Selecionado"),Drawing.Color.Red, Drawing.Color.Black) %>' Visible="<%#fncPodeAlterar()%>" runat="server" Checked='<%#Eval("Selecionado")%>' Text='<%#Eval("Acao") %>' AutoPostBack='true' OnCheckedChanged='chk_OnCheckedChange' /><asp:Label runat="server" ID="lblAcao" Visible="<%# not fncPodeAlterar()%>" runat="server" Text='<%#Eval("Acao") %>'></asp:Label></div>
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

