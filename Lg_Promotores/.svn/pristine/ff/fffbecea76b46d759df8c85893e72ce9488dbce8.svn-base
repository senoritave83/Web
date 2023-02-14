<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="roteiro.aspx.vb" Inherits="formulario_roteiro" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                
    <div class='EditArea'>
        <table id='tblEditArea' border="0">
            <tr class="trEditHeader">
                <td colspan='3'>&nbsp;</td>
            </tr>
            <tr class='trField'>
	            <td class='tdFieldHeader'>
		            Promotor:
	            </td>
	           <td class='tdField' colspan='3'>
	                <asp:Label runat='server' ID='lblPromotor' /> 
	           </td>
	        </tr>
            <tr class='trField'>
	            <td class='tdFieldHeader'>
		            Data:
	            </td>
	           <td class='tdField'>
	                <asp:TextBox runat='server' ID='txtData' AutoPostBack='true' />
	                <asp:RequiredFieldValidator runat='server' ID='valCompData' ControlToValidate='txtData' ErrorMessage='Informe a data' ValidationGroup='ValidaData' />
	                <asp:CompareValidator runat='server' ID='CompareValidator1' ControlToValidate='txtData' ErrorMessage='Data inválida' Operator='DataTypeCheck' Type='Date' ValidationGroup='ValidaData'></asp:CompareValidator>
	           </td>
	           <td class='tdField'>
	                <asp:Button runat='server' ID='btnAtualizarData' Text='Atualizar' ValidationGroup='ValidaData' />
	           </td>
	        </tr>
	        <tr>
	            <td colspan='3'>
                    <asp:Panel runat='server' ID='pnlExistente'>
                        <br />
                        <br />
                        <asp:Label runat='server' ID='lblMensagem' />
                        <br />
                        <br />
                        <asp:Button runat='server' ID='btnUtilizarVisitaAberta' Text='Sim' />
                        <asp:Button runat='server' ID='btnNaoUtilizarVisitaAberta' Text='Não' />
                    </asp:Panel>
	            </td>
	        </tr>
        </table> 
    </div> 
	<div class='ListArea'>
                <asp:GridView runat='server' ID='grdLojasRoteiro' DataKeyNames='IDLoja' AutoGenerateColumns='false'>
                    <HeaderStyle HorizontalAlign='Left' />
                    <Columns>
                        <asp:BoundField DataField='Loja' HeaderText='Loja' />
                        <asp:CommandField ShowSelectButton='true' ButtonType='Link' SelectText='Selecionar' />
                    </Columns>
                </asp:GridView>
    </div> 
</asp:Content>

