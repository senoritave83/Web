<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Roteiro.aspx.vb" Inherits="Pages.Cadastros.Roteiro" title="XM Promotores - Yes Mobile" %>

<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<%@ Register Src="../controls/Roteiro.ascx" TagName="Roteiro" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div style="width:90%">
	    <table width='98%' style="padding:20px 0px 20px 3px; margin-top:20px;">
		    <tr>
			    <td style="width:167px; height: 23px;" align='right'>
				    <b>Roteiro para o promotor:</b>
			    </td>
			    <td style="height: 23px" align='left'>
				    <asp:Label runat='server' ID='lblPromotor' />
			    </td>
		    </tr>
            <tr>
			    <td align='right'>
				    <b>&Uacute;nico no per&iacute;odo:</b>
			    </td>
			    <td>
				    <asp:checkbox id="chkUnicoPeriodo" Runat="server" Width="80%" RepeatDirection="Horizontal" RepeatColumns="5" />
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
            <asp:UpdatePanel runat='server' ID='pnlLojasUpdate'>
                <ContentTemplate>
                    <table width=80%>
                        <tr>
                            <td id='tdProcuraLoja' width=50%>
                                <h4>Procurar lojas</h4>
                                <p>
                                    <asp:TextBox runat='server' ID='txtProcurarLoja' CssClass="formulario"  />
                                    <asp:Button runat='server' ID='btnProcurar' Text='Procurar loja' />
                                </p>
                                <br class='cb' />
                                <asp:GridView runat='server' ID='grdProcurar' Width='95%' SkinID='GridInterno' DataKeyNames='IDLoja' AutoGenerateColumns='false'>
                                    <Columns>  
                                        <asp:TemplateField HeaderText='Pesquisar' ItemStyle-HorizontalAlign='Center' >
                                            <ItemTemplate>
                                                <asp:CheckBox runat='server' ID='chkPesquisar' Checked="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                        <asp:BoundField HeaderText='Loja' DataField='Loja' />
                                        <asp:BoundField HeaderText='Endere&ccedil;o' DataField='Endereco' />
                                        <asp:ButtonField CommandName='AdicionarLoja' ButtonType="Link" Text='<img class="imgBtnAdd" src="../imagens/set-pb.gif"/>' />
                                    </Columns>
                                </asp:GridView>
                                <xm:Paginate ID="Paginate1" runat="server" />
                            </td>
                            <td id='tdListaLoja' width=50%>
                                <h4>Lojas no roteiro (<asp:Label runat='server' ID='lblNumeroLojas'></asp:Label>)</h4>
                                <asp:GridView runat='server' ID='grdLojasRoteiro' Width='95%' SkinID='GridInterno' DataKeyNames='IDLoja' AutoGenerateColumns='false'>
                                    <Columns>  
                                        <asp:TemplateField HeaderText='Pesquisar' ItemStyle-HorizontalAlign='Center' >
                                            <ItemTemplate>
                                                <asp:ImageButton runat='server' ID='ImageAlternar' ImageUrl='../imagens/Checked.gif'  AlternateText='Pesquisar na loja' CommandName='AlternarPesquisa' CommandArgument='<%# Eval("IDLoja") & "|" & Eval("Pesquisar") %>'  />
                                            </ItemTemplate>
                                        </asp:TemplateField>  
                                        <asp:BoundField HeaderText='C&oacute;digo' DataField='Codigo' />
                                        <asp:BoundField HeaderText='Loja' DataField='Loja' />
                                        <asp:BoundField HeaderText='Endere&ccedil;o' DataField='Endereco' />
                                        <asp:ButtonField  CommandName='RetirarLoja' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir_ico.png"/>' />
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

