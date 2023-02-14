<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Localizacao.ascx.vb" Inherits="controls_Localizacao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
.auto-style1 {
	margin-left: 40px;
}
</style>
<asp:Panel runat='server' ID='pnlLocalizacao'>
    <script language="javascript" type="text/javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdIdBandeira.ClientID %>";
            document.getElementById(hdnValueID).value = eventArgs.get_value();
            __doPostBack(hdnValueID, "");
        } 
    </script>
    <div id='AreaLocalizacao'>
        <asp:UpdatePanel runat='server' ID='pnlSegmentos'>
            <ContentTemplate>
                <h4><asp:Literal runat='server' ID='ltrTitle'>Exibir para os seguintes crit&eacute;rios de lojas:</asp:Literal></h4>
                <table id='Table3' width='100%'>
	                <tr class='trField'>
		                <td colspan='2' width='100%'>
			                <asp:RadioButtonList CellPadding='0' CellSpacing='5' runat="server" ID='tdTipoBuscaLoja' RepeatDirection='Horizontal'>
                                <asp:ListItem Text="Bandeira" Value='Bandeira' Selected='True'></asp:ListItem>
                                <asp:ListItem Text="Loja" Value='Loja'></asp:ListItem>
                                <asp:ListItem Text="Cidade" Value='Cidade'></asp:ListItem>
                                <asp:ListItem Text="UF" Value='UF'></asp:ListItem>
                            </asp:RadioButtonList>
		                </td>
	                </tr>
	                <tr class='trField'>
		                <td class='tdField' width='30%'>
			                <asp:TextBox runat="server" ID='txtBuscaLoja' Width='100%' CssClass="formulario"></asp:TextBox>
		                </td>
                        <td align="left">
                            <asp:Button runat='server' ID='btnBuscaLoja' Text='Buscar' Cssclass='BotaoAdicionar' BackColor="#CCCCCC" ForeColor="#666666" Height="27px" />
                        </td>
                    </tr>
                </table>
                <div class='ListaItens'>
                    <asp:GridView runat='server' ID='grdSegmentos' Width='100%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDLocalizacao'>
                        <HeaderStyle HorizontalAlign='Left' />
                        <Columns>
                            <asp:BoundField DataField='UF' HeaderText='UF' />
                            <asp:BoundField DataField='Cidade' HeaderText='Cidade' />
                            <asp:BoundField DataField='Cliente' HeaderText='Bandeira' />
                            <asp:BoundField DataField='Loja' HeaderText='Loja' />
                            <asp:BoundField DataField='Regiao' HeaderText='Regiao' />
                            <asp:BoundField DataField='TipoLoja' HeaderText='Tipo Loja' />
                            <asp:ButtonField  CommandName='RetirarSegmento' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir_ico.png"/>' />
                        </Columns>
                    </asp:GridView>
                </div> 
                <div id='AdicionarLocalizacao' align="left" >
                    <table id='tblAdicionarLocalizacao' align="left">
	                    <tr class='trField'>
		                     <td colspan='2' style="text-align:left; padding-top:10px; padding-right:0px; padding-bottom:0px; width: 192px;">
			                    <h4>Adicionar novo crit&eacute;rio</h4>
                                <asp:UpdateProgress ID="UpdateProgress23" runat="Server" AssociatedUpdatePanelID="pnlSegmentos" DisplayAfter='0' DynamicLayout='false' >
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/loading11.gif" alt='Aguarde por favor...' />
                                        </ProgressTemplate>
                                </asp:UpdateProgress> 
	                         </td>
	                    </tr>
	                    <tr>
		                    <td class='auto-style1' style="width: 200px; height: 26px;">
			                    <label>Cidade:</label>
			                    <asp:TextBox runat='server' Width="100%" ID='txtCidade' MaxLength='100' CssClass='txtCidade formulario' />
		                    </td>
		                 </tr>
	                    <tr class='trField'>
		                    <td class='tdFieldHeader' style="width: 200px; height: 26px;">
			                    <label>UF:</label>
			                    <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" ValidationGroup='AdicionarSegmento' AutoPostBack='true' CssClass="Select"  />
		                    </td>  
                        </tr>		                  
						<tr>
							<td class='tdFieldHeader' style="width: 200px">
			                    <label>Tipo de Loja:</label>
			                    <asp:DropDownList runat="server" ID="cboIDTipoLoja" DataTextField="TipoLoja" DataValueField="IDTipoLoja" AutoPostBack='true' CssClass="Select"  />
		                    </td>
						</tr>	                                         
                        <tr class='trField'>
		                    <td class='tdFieldHeader' style="width: 200px; height: 26px;">
			                    <label><asp:Literal ID="Literal1" runat="Server" Text='<%$Settings: Caption, Regiao, "Região"%>' />:</label>
			                    <asp:DropDownList runat="server" ID="cboIDRegiao" DataTextField="Regiao" DataValueField="IDRegiao" AutoPostBack='true' CssClass="Select"  />
		                    </td>
	                    </tr>
	                    <tr class='trField'>
		                    <td class='tdFieldHeader' colspan="2" style="width: 200px">
			                    <label>Bandeira:</label>
                                <asp:hiddenfield id="hdIdBandeira" Value="0" onvaluechanged="hdIdBandeira_ValueChanged" runat="server"/>
                                <asp:TextBox STYLE="width:100%" ID="txtBandeira" Width="100%" runat="server" CssClass="formulario"></asp:TextBox>
                                <cc1:AutoCompleteExtender 
                                    ServiceMethod="ProcurarBandeiras"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="30"
                                    TargetControlID="txtBandeira"
                                    onclientitemselected="OnContactSelected"
                                    ID="txtBandeira_AutoComplete" runat="server" FirstRowSelected = "true"></cc1:AutoCompleteExtender>
			                    <asp:DropDownList Visible="false" runat="server" ID="cboIDBandeira" DataTextField="Fantasia" DataValueField="IDCliente" AutoPostBack='true' CssClass="Select" style="float:none;" />
		                    </td>
	                    </tr>
	                    <tr class='trField'>
		                    <td class='tdFieldHeader' colspan="2" style="width: 200px">
			                    <label>Loja:</label>
			                    <asp:DropDownList CssClass="Select" STYLE="width:100%" Width="100%" runat="server" ID="cboIDLoja" DataTextField="Loja" DataValueField="IDLoja"  />
		                    </td>		                    
	                    </tr>
	                    <tr class='trField'>
	                        <td colspan='2'>
                                <asp:Button runat='server' ID='btnAdicionarSegmento' Text='Adicionar sele&ccedil;&atilde;o' class='BotaoAdicionar' style="float:right; " />
	                        </td>
	                    </tr>
                    </table>
                </div>
             </ContentTemplate> 
        </asp:UpdatePanel> 
    </div> 
</asp:Panel>