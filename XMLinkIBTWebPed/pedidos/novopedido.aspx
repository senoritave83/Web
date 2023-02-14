<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="novopedido.aspx.vb" Inherits="pedidos_novopedido" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server' />
    <asp:Panel runat='server' ID='pnlCopiar' Visible='false'>
        <asp:UpdatePanel runat='server' ID='updCopia'>
            <ContentTemplate>
                <asp:Panel runat='server' ID='pnlOpcaoCopia'>
                    <div class='Box' style="width:100%">
                        <h4>Por favor selecione se deseja criar o pedido copiando de um já existente</h4><br />
                        <asp:LinkButton runat='server' ID='lnkCopiarPedido'>Copiar pedido</asp:LinkButton><br />  
                        <asp:LinkButton runat='server' ID='lnkCopiarItens'>Copiar os itens sem quantidade</asp:LinkButton>  <br />                  
                        <asp:LinkButton runat='server' ID='lnkNaoCopiar'>N&atilde;o copiar, gerar em branco</asp:LinkButton>     <br />               
                    </div>
                </asp:Panel>
                <asp:Panel runat='server' ID='pnlCopiaPedidos' Visible='false'>
                    <div class='Box' style="width:100%">
                        <h4>De qual pedido copiar?</h4><br />
                        <asp:LinkButton runat='server' ID='lnkCopiaUltimo'>Copiar do último pedido</asp:LinkButton>  <br />                  
                        <asp:LinkButton runat='server' ID='lnkcopiaListar'>Listar últimos pedidos</asp:LinkButton>   <br />                 
                        <asp:LinkButton runat='server' ID='lnkcopiaInformar'>Informar número do pedido</asp:LinkButton>    <br />                
                    </div> 
                </asp:Panel>
                <asp:Panel runat='server' ID='pnlCopiaLista' Visible='false'>
                    <asp:GridView runat='server' ID='grdUltimosPedidos' AutoGenerateColumns='False' DataKeyNames='NumeroPedido'>
                        <HeaderStyle HorizontalAlign='Left' />
                        <Columns>
                            <asp:BoundField DataField='NumeroPedido' HeaderText='Nº Pedido' />
                            <asp:BoundField DataField='DataEmissao' HeaderText='Data' />
                            <asp:ButtonField ButtonType='Link' Text='Copiar' CommandName='Copiar'  />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Panel runat='server' ID='pnlCopiaInformar' Visible='false'>
                    <div class='Box' style="width:100%">
                        Número do pedido<br />
                        <asp:TextBox runat='server' ID='txtNumeroPedido' />
                        <asp:RequiredFieldValidator runat='server' ID='valReqNumeroPedido' ControlToValidate='txtNumeroPedido' ValidationGroup='Informar' ErrorMessage='Por favor informe o número do pedido desejado.' />
                        <asp:CompareValidator runat='server' ID='valCompNumeroPedido' ControlToValidate='txtNumeroPedido' ValidationGroup='Informar' ErrorMessage='Por favor informe o número do pedido desejado.' Operator='DataTypeCheck' Type='Integer' /><br />
                        <asp:Label runat='server' ID='lblMensagem' ></asp:Label>
                        <asp:Button  runat='server' ID='btnProcurar' ValidationGroup="Informar" Text='Procurar pedido' />
                    </div> 
                </asp:Panel>
                <asp:Panel runat='server' ID='pnlCopiaResultado' Visible='false'>
                    <asp:Label runat='server' ID='lblCopiaResultado'></asp:Label>
                    <a href='produtos.aspx' runat='server' ID='lnkResultadoOk'>OK</a>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger  ControlID='btnCopiarVoltar' />
            </Triggers>
        </asp:UpdatePanel>
        <br class='cb' />
        <br />
        <div class='AreaBotoes'>
            <asp:Button runat='server' ID='btnCopiarVoltar' Text='Voltar' />
        </div> 
    </asp:Panel>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
</asp:Content>

