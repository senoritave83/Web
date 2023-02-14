<%@ Page Language="VB" MasterPageFile="~/basica.master" AutoEventWireup="false" CodeFile="esqueci.aspx.vb" Inherits="home_esqueci" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelp" runat="server">
	<p style="width: 385px">
    Se voc<span lang="pt-br">&ecirc;</span> esqueceu sua Senha, preencha os campos <span lang="pt-br">a seguir</span> para receber um e-mail com um C&oacute;digo de suporte e instru<span lang="pt-br">&ccedil;&otilde;es</span> 
	de como redefini<span lang="pt-br">-la</span>.
</p>
<a class="redBtn voltar"  href="inicio/login.aspx" style="width: 106px"></a> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" Runat="Server">
	<div class="fRight" style="width: 485px">
    <asp:PlaceHolder runat='server' ID='plhIdentificacao'>
    <p>
        <label for="identifica&ccedil;&atilde;o">Identifica&ccedil;&atilde;o (Digite com o ponto):<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' ControlToValidate='txtBscs'>*</asp:RequiredFieldValidator></label>
    </p>
    <p>
        <span><asp:TextBox id="txtBscs" runat='server' TabIndex="1" MaxLength="20" size="20" cssclass="formulario" /></span>
        <asp:ImageButton runat="server" id="btnOk" ImageUrl="~/images/buttons/btn_continuar.png" alt="" />
    </p>
    <div align="left" style="width:210px;">
    	O mesmo n&uacute;mero de Identifica&ccedil;&atilde;o utilizado para contratar o servi&ccedil;o 
		Equipe Online.
	</div>
    <p>
        <asp:Label runat='server' ID='Label1' cssclass="erro" Visible='false'></asp:Label>
    </p>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat='server' ID='plhMensagem' Visible='false'>
        <p>
            <label for="erro"><asp:Label runat='server' id="lblMensagem" Visible='false'/></label>
        </p>
        <p runat='server' id='trTrocar' visible='false'>
            <a href='alterar.aspx' class='alteraremail'>Alterar e-mail</a>
        </p>
    </asp:PlaceHolder>
</div>
</asp:Content>

