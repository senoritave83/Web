<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="justificar.aspx.vb" Inherits="pedidos_justificar" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel runat='server' ID='pnlJustificar'>
        <div class='box'>
            Por favor informe a justificativa
            <asp:RequiredFieldValidator runat='server' ID='valreqOpcao' ControlToValidate='lstJustificativa' ErrorMessage='por favor selecione a justificativa' Text='*' /><br />
            <asp:RadioButtonList runat='server' ID='lstJustificativa' DataTextField='Justificativa' DataValueField='IDJustificativa'>
            </asp:RadioButtonList>
        </div>
        <br class='cb' />
        <br />
        <div class='AreaBotoes'>
            <asp:Button runat='server' ID='btnVoltar' Text='Voltar' CausesValidation='false' />
            <asp:Button runat='server' ID='btnGravar' Text='Gravar' />
        </div>
    </asp:Panel>
    <asp:Panel runat='server' ID='pnlMensagem' Visible='false'>
        <table width='100%' height='50%'>
            <tr valign='bottom'>
                <td align='center'>
                    A Justificativa foi gravada com sucesso!
                </td>
            </tr>
            <tr valign='top'>
                <td align='center'>
                    <asp:Button runat='server' ID='btnOK' Text='OK' style="float:none;" CausesValidation='false' />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
</asp:Content>

