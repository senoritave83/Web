<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="pedidos_Default" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat=server></asp:ScriptManager>
   <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    Data: 
				</td>
				<td class='tdField'>
                    <asp:Label runat='server' ID='lblData' />    
				</td>
				<td class='tdFieldHeader'>
			        Status:
				</td>
			    <td class='tdField'>
				    <asp:Label runat='server' ID='lblStatus' />
			    </td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
    Atendimentos em andamento
	<div class='ListArea'>
    <asp:UpdatePanel runat='server' ID='updClientes'>
        <ContentTemplate>
            <asp:GridView runat='server' ID='grdClientesAtendimento' AutoGenerateColumns='false'>
                <HeaderStyle HorizontalAlign='Left'  />
                <Columns>
                    <asp:HyperLinkField HeaderText="C&oacute;digo" DataNavigateUrlFields='IDCliente' DataNavigateUrlFormatString='cliente.aspx?idcliente={0}' DataTextField='Codigo' />
                    <asp:BoundField HeaderText="Cliente" DataField='Cliente' />
                    <asp:BoundField HeaderText="Status" DataField='Status' />
                </Columns>
                <EmptyDataTemplate>
                    Não há clientes com atendimentos gravados.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div> 
    
    <asp:Label runat='server' ID='lblMessage' />


    
    <br class='cb' />
    
    <div class='box' style="width:100%">
        <h4>Adicionar o seguinte cliente no atendimento</h4>
        <br />
        <asp:Panel runat='server' ID='pnlProcurar'>
            <table>
                <tr>
                    <td align='right'>C&oacute;digo:</td>
                    <td>
                        <asp:TextBox runat='server' id='txtCliente' AUTOCOMPLETE=OFF></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan='2'>
                        <asp:Label runat='server'  id='lblProcurarMensagem' SkinID='LabelMensagem' />
                    </td>
                </tr>
            </table>
            
            <br />
            <asp:Button runat='server' ID='btnProcurar' Text='Procurar' />
        </asp:Panel>
        <asp:Panel runat='server' ID='pnlAdicionar' Visible='False'>
            <b>C&oacute;digo:</b> <asp:Label runat='server' ID='lblCodigo' /><br />
            <b>Cliente:</b> <asp:Label runat='server' ID='lblCliente' /><br />
            <b>CNPJ:</b> <asp:Label runat='server' ID='lblCNPJ' /><br />
            <asp:Button runat='server' ID='btnCancelarCliente' Text="Voltar" />
            <asp:Button runat='server' ID='btnAdicionarCliente' Text="Adicionar cliente" />
        </asp:Panel>
    </div>
    <asp:PlaceHolder runat='server' ID='plhFinalizar' Visible='false'>
    <div class='AreaBotoes'>
        <asp:UpdatePanel runat='server' ID='updBotoes'>
            <ContentTemplate>
                <asp:Button runat='server' id='btnFinalizarRoteiro' Text='Finalizar Roteiro' />    
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </asp:PlaceHolder> 
</asp:Content>

