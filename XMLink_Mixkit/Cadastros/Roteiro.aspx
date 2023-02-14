<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Roteiro.aspx.vb" Inherits="Pages.Cadastros.Roteiro" title="Untitled Page" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo'>
				<div class='tdFieldHeader fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDescricao'>
				<div class='tdFieldHeader fl'>
					Descrição:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDescricao' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqDescricao' Display='None' ErrorMessage='Descricao &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDescricao' />
				</div>
			</div>
		    <div class='trField cb' runat='server' id='divVendedorUnico'>
			    <div class='tdFieldHeader fl'>
				    Vendedor:
			    </div>
			    <div class='tdField fl'>
				    <asp:DropDownList runat="server" ID="cboIDVendedor" DataTextField="Vendedor" DataValueField="IDVendedor" />
				    <asp:CompareValidator runat="server"  ID="valCompVendedorUnico" Display="None" ErrorMessage="Vendedor inv&aacute;lido" ControlToValidate="cboIDVendedor" Operator="GreaterThan" ValueToCompare="0" />
				    <asp:RequiredFieldValidator runat='server' ID='valReqVendendorUnico' Display='None' ErrorMessage='O Vendedor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDVendedor' />
			    </div>
		    </div>
			<br class='cb' />
			<xm:DateSelectionPanel runat='Server' ID='dspRoteiro' Width='100%' cellpadding='4' cellspacing='2' />
			<asp:PlaceHolder runat='server' ID='plhVendedores'>
                <div id='divVendedoresRoteiro'>
			        <asp:GridView runat='server' ID='grdVendedores' DataKeyNames='IDVendedor' AutoGenerateColumns='false'>
			            <HeaderStyle HorizontalAlign='Left' />
                        <Columns>  
                            <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                            <asp:BoundField HeaderText='Vendedor' DataField='Vendedor' />
                            <asp:ButtonField  CommandName='RetirarVendedor' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                        </Columns>
			        </asp:GridView>
			        Adicionar Vendedor:
			        <asp:DropDownList runat='server' ID='cboNovoVendedor' DataTextField='Vendedor' DataValueField='IDVendedor'></asp:DropDownList>
			        <asp:Button runat='server' ID='btnAdicionarVendedor' Text='Adicionar' />
			    </div> 
			</asp:PlaceHolder>
		</div>
	</div>
	<asp:PlaceHolder runat='server' ID='plhClientes'>
        <div id='divClientesRoteiro'>
            <asp:ScriptManager runat='server' ID='ScriptManager1' />
            <asp:UpdatePanel runat='server' ID='pnlClientesUpdate'>
                <ContentTemplate>
                    <table>
                        <tr>
                            <td id='tdProcurar'>
                                <h4>Procurar clientes</h4>
                                <p>
                                    <asp:TextBox runat='server' ID='txtProcurarCliente' />
                                    <asp:Button runat='server' ID='btnProcurar' Text='Procurar Cliente' />
                                </p>
                                <br class='cb' />
                                <asp:GridView runat='server' ID='grdProcurar' Width='95%' SkinID='GridInterno' DataKeyNames='IDCliente' AutoGenerateColumns='false'>
                                    <Columns>  
                                        <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                        <asp:BoundField HeaderText='Cliente' DataField='Cliente' />
                                        <asp:ButtonField CommandName='AdicionarCliente' ButtonType="Link" Text='<img class="imgBtnAdd" src="../imagens/set-pb.gif"/>' />
                                    </Columns>
                                </asp:GridView>
                                <xm:Paginate ID="Paginate1" runat="server" />
                            </td>
                            <td id='tdListaCliente'>
                                <h4>Clientes no roteiro (<asp:Label runat='server' ID='lblNumeroClientes'></asp:Label>)</h4>
                                <asp:GridView runat='server' ID='grdClientesRoteiro' Width='95%' SkinID='GridInterno' DataKeyNames='IDCliente' AutoGenerateColumns='false'>
                                    <Columns>  
                                        <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                        <asp:BoundField HeaderText='Cliente' DataField='Cliente' />
                                        <asp:ButtonField  CommandName='RetirarCliente' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress DisplayAfter="500" ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="pnlClientesUpdate">
            <ProgressTemplate>
                <div class="progress">
                    <img src="../imagens/ajax-loader.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                </div>
            </ProgressTemplate>
            </asp:UpdateProgress>
        </div> 
        <br class='cb' />
	</asp:PlaceHolder>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Roteiro.aspx?idroteiro=0&idvendedor=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Roteiros.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'>
			        <b>Novo:</b>
				    Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

