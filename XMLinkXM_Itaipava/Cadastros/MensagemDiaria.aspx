<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false"
    CodeFile="MensagemDiaria.aspx.vb" Inherits="Pages.Cadastros.MensagemDiaria" Title="Untitled Page" %>

<%@ Register Src="~/controls/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='EditArea'>
        <div class='divEditArea' style='height: 240px;'>
            <div class='divHeader'>
                Dados da Mensagem</div>
            <div class='trField cb'>
                <div class='tdFieldHeader cb fl'>
                    Mensagem:
                </div>
                <div class='tdField fl' style='width: 400px;'>
                    <asp:TextBox runat='server' ID='txtMensagem' MaxLength='5000' TextMode='MultiLine'
                        Rows='10' Width='100%' Style='width: 100%;' />
                    <asp:RequiredFieldValidator runat='server' ID='valReqMensagem' Display='None' ErrorMessage='Mensagem &eacute; um campo obrigat&oacute;rio!'
                        ControlToValidate='txtMensagem' />
                </div>
            </div>
            <div class='trField cb'>
                <div class='tdFieldHeader cb fl'>
                    DataInicio:
                </div>
                <div class='tdField fl'>
                    <asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" Width='80' />
                    <cc1:CalendarExtender ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial"
                        PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                </div>
            </div>
            <div class='trField cb'>
                <div class='tdFieldHeader cb fl'>
                    DataFim:
                </div>
                <div class='tdField fl'>
                    <asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" Width='80' />
                    <cc1:CalendarExtender ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal"
                        PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                </div>
            </div>
            <div class='trField cb'>
            </div>
            <div class='trField cb'>
                <div id="Div1" class='tdFieldHeader fl' runat='server'>
                    Subir Arquivo:
                    <asp:FileUpload runat='server' ID='filUpload' />
                </div>
                <div class='tdField cb fl' style="padding: 2px 2px 2px 10px;">
                    <asp:Button runat='server' ID='btnSubir' Text='Subir' />
                </div>
            </div>
            <div class='trField cb'>
             <div id="Div2" class='tdFieldHeader fl' runat='server' >
             Imagem
             </div>
                <div class='tdField cb fl'>
                         <div>                         
                                            
                        <asp:Image ID='ImagemFoto' runat="server" Height="134px" Width="130px" ImageUrl=""  />
                        </div>
                   </div>
           
          
        </div>
   
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='MensagemDiaria.aspx?idmensagemdiaria=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar "
            onclick="location.href='MensagensDiarias.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
        <ul class='TextDefault'>
            <li>
                <asp:Localize runat='server' ID='lclAjudaGravar'> <b>Gravar:</b> Grava as altera&ccedil;&otilde;es efetuadas no banco. </asp:Localize>
            </li>
            <li>
                <asp:Localize runat='server' ID='lclAjudaApagar'> <b>Apagar:</b> Apaga o registro atual. </asp:Localize>
            </li>
            <li>
                <asp:Localize runat='server' ID='lclAjudaNovo'> <b>Novo:</b> Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es. </asp:Localize>
            </li>
            <li>
                <asp:Localize runat='server' ID='lclAjudaVoltar'> <b>Voltar:</b> Volta para o menu anterior. </asp:Localize>
            </li>
        </ul>
    </div>
</asp:Content>
