<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Roteiro.aspx.vb" Inherits="Pages.Roteiros.Roteiro" title="" %>

<%@ Register Src="../controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc3" %>

<%@ Register Src="../controls/Roteiro.ascx" TagName="Roteiro" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class='EditArea'>
	    <table width='98%'>
		    <tr>
			    <td style="width:200" align='right'>
				    <b>Roteiro para o vendedor:</b>
			    </td>
			    <td>
				    <asp:Label runat='server' ID='lblVendedor' />
			    </td>
		    </tr>
		    <tr>
			    <td align='right'>
				    <b>Ativo:</b>
			    </td>
			    <td>
				    <asp:CheckBox runat='server' ID='chkAtivo' />
			    </td>
		    </tr>
		</table>
       <uc2:Roteiro ID="Roteiro1" runat="server" />
	</div>
	<asp:PlaceHolder runat='server' ID='plhLojas'>
        <div id='divLojasRoteiro'>
            <asp:ScriptManager runat='server' ID='ScriptManager1' />
            <asp:UpdatePanel runat='server' ID='pnlLojasUpdate'>
                <ContentTemplate>
                    <table>
                        <tr>
                            <td id='tdProcurar'>
                                <h4>Procurar clientes</h4>
                                <p>
                                    <asp:TextBox runat='server' ID='txtProcurarLoja' />
                                    <asp:Button runat='server' ID='btnProcurar' Text='Procurar loja' />
                                </p>
                                <br class='cb' />
                                <asp:GridView runat='server' ID='grdProcurar' Width='95%' SkinID='GridInterno' DataKeyNames='IDCliente' AutoGenerateColumns='false'>
                                    <HeaderStyle HorizontalAlign='Left' />
                                    <Columns>  
                                        <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                        <asp:BoundField HeaderText='Cliente' DataField='Cliente' />
                                        <asp:ButtonField CommandName='AdicionarLoja' ButtonType="Link" Text='<img class="imgBtnAdd" src="../imagens/set-pb.gif"/>' />
                                    </Columns>
                                </asp:GridView>
                                <uc3:Paginate ID="Paginate1" runat="server" />
                            </td>
                            <td id='tdListaLoja'>
                                <h4>Clientes no roteiro (<asp:Label runat='server' ID='lblNumeroLojas'></asp:Label>)</h4>
                                <asp:GridView runat='server' ID='grdLojasRoteiro' Width='95%' SkinID='GridInterno' DataKeyNames='IDCliente' AutoGenerateColumns='false'>
                                    <HeaderStyle HorizontalAlign='Left' />
                                    <Columns>  
                                        <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                        <asp:BoundField HeaderText='Cliente' DataField='Cliente' />
                                        <asp:ButtonField  CommandName='RetirarLoja' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress DisplayAfter="500" ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="pnlLojasUpdate">
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
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnNovo' Text="Novo" CssClass='Botao' />
        <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Gravar:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Apagar:</b>
				Apaga o registro atual.
		    </li> 
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

