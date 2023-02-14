<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="pergunta.aspx.vb" Inherits="formulario_pergunta" title="Untitled Page" %>
<%@ Register src="../controls/pergunta.ascx" tagname="pergunta" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<br />
	<br />
    <asp:UpdatePanel ID="UpdatePanel1" runat='server'>
        <ContentTemplate>
	        <div id='FormularioVisita'>
	            <asp:UpdatePanel runat='server' ID='updFormulario'>
	                <ContentTemplate>
	                    <div style="height:300px">
	                    <uc1:pergunta ID="pergunta1" runat="server" />
                        </div>
	                </ContentTemplate>
	            </asp:UpdatePanel> 
                <asp:Button ID='btnVoltar' runat='server' Text='Tela de Visita' /><asp:Button ID='btnGravar' runat='server' Text='Gravar' />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
	<br />
	<br />
</asp:Content>

