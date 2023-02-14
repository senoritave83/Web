<%@ Page Language="VB" MasterPageFile="~/basica.master" AutoEventWireup="false" CodeFile="registro.aspx.vb" Inherits="inicio_registro" title="Equipe Online" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" Runat="Server">
<div class="main mainMaster">
    <!--inicio do código-->
    <table>
        <tr style="height:30px;">
            <th colspan="4">
                Por favor digite os dados cadastrais da sua empresa:
                <asp:label id="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:label>
            </th>
        </tr>            
        <tr style="height:30px;">
            <td style="width:300px;">
                *Nome de sua Empresa
            </td>
            <td colspan="2" style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtEmpresa" runat="server" MaxLength="100" Width="350px"></asp:textbox>
            </td>
            <td style="width:200px;">
                <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtEmpresa" ErrorMessage="* O nome da empresa é obrigatório."></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>
                *Nome do usu&aacute;rio administrador
            </td>
            <td colspan="2" style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtNome" runat="server" MaxLength="100"></asp:textbox>
            </td>
            <td>
                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtNome" ErrorMessage="* O nome do usuário administrador é obrigatório."></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>
                *Login do usu&aacute;rio administrador
            </td>
            <td style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtUsuario" runat="server" MaxLength="20" onKeyPress="fncPermitirUS()" onpaste="return false;" onselectstart="return false;" />
            </td>
            <td style="width:250px;">
                Deve iniciar com uma letra e pode conter letras e n&uacute;meros, mas sem espa&ccedil;os.
            </td>
            <td>
                <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtUsuario" ErrorMessage="* O login do usuário administrador é obrigatório."></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>
                *Senha
            </td>
            <td style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtSenha" runat="server" MaxLength="20" TextMode="Password" onKeyPress="fncPermitirUS()" onpaste="return false;" onselectstart="return false;" />
            </td>
            <td>
                A senha deve conter uma combina&ccedil;&atilde;o de pelo menos 7 letras e n&uacute;meros.
            </td>
            <td>
                <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtSenha" ErrorMessage="* A senha do usuário administrador é obrigatório."></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>
                *Redigitar a senha
            </td>
            <td colspan="2" style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtSenha2" runat="server" TextMode="Password" />
            </td>
            <td>
                <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtSenha2" ErrorMessage="* Redigite a senha do administrador."></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>
                *Correio Eletr&ocirc;nico para envio de Informa&ccedil;&otilde;es
            </td>
            <td colspan="2" style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtEmail" runat="server" Width="350px" onpaste="return false;" onselectstart="return false;" style="width:350px;" />
            </td>
            <td>
                <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="* O e-mail do usuário administrador é obrigatório."></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>
                *Redigite Correio Eletr&ocirc;nico
            </td>
            <td colspan="2" style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtEmail2" runat="server" Width="350px" />
            </td>
            <td>
                <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtEmail2" ErrorMessage="* Redigite o e-mail do administrador."></asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr style="height:30px;">
            <td>
                Favor inserir um n&uacute;mero de telefone Nextel caso deseje receber suas informa&ccedil;&otilde;es
                de chave, login e senha via SMS, direto em seu aparelho Nextel
            </td>
            <td colspan="2" style="padding:0px 5px 0px 5px;">
                <asp:textbox class="formulario" id="txtTelefone" runat="server" Width="150px" onKeyPress="fncPermitirNumeros()" style="width:150px;" />&nbsp;
                (1178010101)
            </td>
        </tr>
        <tr style="height:30px;">
            <td colspan="4" style="padding:10px 5px 10px 5px;">
                *Informa&ccedil;&atilde;o necess&aacute;ria.
            </td>
        </tr>        
    </table>

    <table>
        <tr>
            <td style="padding:0px 15px 10px 15px;">
                <asp:button id="btnOk" runat="server" cssclass="BtnFormulario" Text="Ok" Width='100px'></asp:button>
            </td>
            <td>
                <input type="button" name="btnApagar" value="Apagar as mudanças" onclick="this.form.reset();" class="BtnFormulario" />
            </td>
        </tr>
    </table>
    
    <table id="table4" width="100%">
		<tr>
			<td><asp:comparevalidator id="CompareValidator1" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtSenha2" ErrorMessage="* As senhas estão diferentes." ControlToCompare="txtSenha"></asp:comparevalidator></td>
		</tr>
		<tr>
			<td><asp:comparevalidator id="CompareValidator2" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtEmail2" ErrorMessage="* Os e-mails estão diferentes." ControlToCompare="txtEmail"></asp:comparevalidator></td>
		</tr>
		<tr>
			<td><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="textDefault" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="* E-mail Inválido." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></td>
		</tr>
	</table>

    <!-- fim do código-->
</div>
</asp:Content> 
