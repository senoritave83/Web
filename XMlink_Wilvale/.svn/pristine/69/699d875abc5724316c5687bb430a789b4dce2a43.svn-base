<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="CatalogoProduto.aspx.vb" Inherits="Pages.Cadastros.CatalogoProduto"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
	    <div class="divEditArea" style="height:70px;"> 
		    <div class='divHeader'>&nbsp;</div>
            <div runat="server" id="trProdutoFoto" >
                <div class='trField cb' runat='server' id='trProcCodProduto' visible="false">
                    <div class='tdFieldHeader cb fl' runat='server' >
                        Codigo do Produto:
                    </div>
                    <div class='tdField fl'>
                        <asp:TextBox runat="server" ID="txtProcurarProduto" />
                    </div>
                    <div class='tdField fl'>
                        <asp:Button runat="server" Text="Procurar" ID="btnProcurar" CssClass='Botao' />
                    </div>
                </div>
                <div class='trField cb' runat='server' id='trInfoProduto' visible="false">
                    <div class='tdFieldHeader cb fl'>
                        Nome do Produto:
                    </div>
                    <div class='tdField fl'>                    
                        <asp:Label runat="server" ID="lblProduto"   />
                    </div>
                </div>
            </div>
	    </div>
    </div>
    <div class='EditArea' runat="server" ID="trPrincipal">
	    <div class="divEditArea"> 
		<div class='divHeader'>&nbsp;</div>
            <asp:Panel runat='server'>
                <div class='trField cb'>
	                <div class='tdFieldHeader fl' runat='server' >
	                    Subir Arquivo:
                        <asp:FileUpload runat='server' ID='filUpload' />
	                </div>
	                <div class='tdField cb fl' style="padding:2px 2px 2px 10px;">
                        <asp:Button runat='server' ID='btnSubir' Text='Subir' />
	                </div>
	            </div>
                <br class="cb" />
	            <asp:DataList runat='server' ID='rptFotos' RepeatColumns='3' RepeatLayout='Table' CellSpacing='10' OnItemCommand='rptFotos_ItemCommand1' DataKeyField='IDProdutoFoto' >
	                <ItemTemplate>
	                    <div>
	                        <table style="border:solid 1px grey" cellpadding="0" cellspacing="0">
	                            <thead>
	                                <tr>
	                                    <th align='left'><asp:RadioButton runat='server'  ID='radCapa' Checked='<%#Eval("Capa") %>' OnCheckedChanged='Checked_Change' Text='Foto de Capa' GroupName='radCapa' name='Capa' AutoPostBack='true' /></th>
	                                    <th align='right'><asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="return confirm('Confirma a exclusão da foto?')" ImageUrl="../imagens/Excluir.gif" CommandName='Apagar' CommandArgument='<%#Eval("Nome") & "," & Eval("IdProdutoFoto") %>' /></th>
	                                </tr>
	                            </thead>
	                            <tbody>
	                                <tr>
	                                    <td colspan='2' class="figure">
	                                        <img src='../thumbnail.ashx?width=350&height=350&filename=~/imagens/fotos/<%#Eval("Nome") %>' />
	                                    </td>
	                                </tr>
	                            </tbody>
	                            <tfoot>
	                                <tr>
	                                    <td colspan='2'>
                                            <asp:TextBox runat='server' ID='txtComentario' TextMode="MultiLine" Width='100%' Rows='3' Text='<%#Eval("Comentario") %>'></asp:TextBox><br />
                                            <asp:Button runat='server' ID='btnGravar' Text='Gravar' CommandArgument='<%#Eval("IDProdutoFoto") %>' CommandName='Gravar' />
	                                    </td>
	                                </tr>
	                            </tfoot>
	                        </table>
	                    </div>
	                </ItemTemplate>
	            </asp:DataList>
	        </asp:Panel>
	    </div>	
    </div>    
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='CatalogoProduto.aspx?idproduto=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='CatalogoProdutos.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
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

