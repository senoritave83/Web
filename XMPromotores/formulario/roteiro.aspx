<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="roteiro.aspx.vb" Inherits="formulario_roteiro" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                
    <div class='EditArea'>
        <table id='tblEditArea' border="0">
            <tr>
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
	           <td class='tdField' >
	                <asp:TextBox runat='server' ID='txtData' AutoPostBack='true' Width="78px" />
	                <asp:RequiredFieldValidator runat='server' ID='valCompData' ControlToValidate='txtData' ErrorMessage='Informe a data' ValidationGroup='ValidaData' />
	                <asp:CompareValidator runat='server' ID='CompareValidator1' ControlToValidate='txtData' ErrorMessage='Data inválida' Operator='DataTypeCheck' Type='Date' ValidationGroup='ValidaData'></asp:CompareValidator>
	           </td>
	           <td class='tdField'>
	                <asp:Button runat='server' ID='btnAtualizarData' Text='Atualizar' ValidationGroup='ValidaData' Width="100px" BackColor="#CCCCCC"  Forecolor="#303030" BorderStyle="None" height="25px"  />
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
                <asp:GridView runat='server' ID='grdLojasRoteiro' DataKeyNames='IDLoja' AutoGenerateColumns='false' CellPadding="1" CellSpacing="1">
                    <HeaderStyle HorizontalAlign='Left' />
                    <Columns>
                        <asp:BoundField DataField='Loja' HeaderText='Loja' />
                        <asp:CommandField ShowSelectButton='true' ButtonType='Link' SelectText='Selecionar' />
                    </Columns>
                </asp:GridView>
    </div> 
    <asp:PlaceHolder runat='server' id='plhAdicionarLoja'>
        <div id='divLojasRoteiro'>
            <table width='100%'>
                <tr>
                    <td id='tdProcuraLoja' width='100%'>
                        <h4>Procurar lojas</h4>
                        <p>
                            <asp:TextBox runat='server' ID='txtProcurarLoja' CssClass="formulario"  />
                            <asp:Button runat='server' ID='btnProcurar' Text='Procurar loja' />
                        </p>
                        <br class='cb' />
                        <asp:GridView runat='server' ID='grdProcurar' Width='100%' SkinID='GridInterno' DataKeyNames='IDLoja' AutoGenerateColumns='false'>
                            <Columns>  
                                <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                <asp:BoundField HeaderText='Loja' DataField='Loja' />
                                <asp:BoundField HeaderText='Endere&ccedil;o' DataField='Endereco' />
                                <asp:ButtonField CommandName='AdicionarLoja' ButtonType="Link" Text='<img class="imgBtnAdd" src="../imagens/set-pb.gif"/>' />
                            </Columns>
                        </asp:GridView>
                        <xm:Paginate ID="Paginate1" runat="server" />
                    </td>
                </tr>
            </table>
        </div> 
    </asp:PlaceHolder>
</asp:Content>

