<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="ProdutoFotos.aspx.vb" Inherits="Cadastros_ProdutoFotos" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat='server' ID='ScriptManager1'></asp:ScriptManager>
    <div class='EditArea'>
	    <table id='tblEditArea'>
		    <tr class="trEditHeader">
		        <td colspan='2'>&nbsp;</td>
		    </tr>
		    <tr class='trEditSpace'>
		        <td colspan='2'>&nbsp;</td>
		    </tr>
		    <tr class='trField'>
			    <td class='tdFieldHeader'>
			        <asp:Label runat='server' ID='lblTextoCodigo'>
					    C&oacute;digo:
				    </asp:Label> 
			    </td>
			    <td class='tdField'>
				    <asp:Label runat='server' ID='lblCodigo' />
			    </td>
		    </tr>
		    <tr class='trField'>
			    <td class='tdFieldHeader'>
			        <asp:Label runat='server' ID='lblTextoDescricao'>
					    Descri&ccedil;&atilde;o:
				    </asp:Label> 
			    </td>
			    <td class='tdField'>
				    <asp:Label runat='server' ID='lblDescricao' />
			    </td>
		    </tr>
	    </table>
    </div> 
	<asp:Panel runat='server' ID='pnlPrincipal'>
	    <asp:DataList runat='server' ID='rptFotos' RepeatColumns='4' RepeatLayout='Table' CellSpacing='10' OnItemCommand='rptFotos_ItemCommand1' DataKeyField='IDProdutoFoto' >
	        
	        <ItemTemplate>
	            <div class='foto'>
	                <table style="background-color:#ececec;border:solid 1px grey" cellpadding=0 cellspacing=0>
	                    <thead style="background-color:White;">
	                        <tr>
	                            <th align='left'><asp:RadioButton runat='server'  ID='radCapa' Checked='<%#Eval("Capa") %>' OnCheckedChanged='Checked_Change' Text='Foto de Capa' GroupName='radCapa' name='Capa' AutoPostBack='true' /></th>
	                            <th align='right'><asp:ImageButton runat='server' ImageUrl="../imagens/Excluir.gif" CommandName='Apagar' CommandArgument='<%#Eval("IDProdutoFoto") %>' /></th>
	                        </tr>
	                    </thead>
	                    <tbody>
	                        <tr>
	                            <td colspan='2'>
	                                <a href='produtofoto.aspx?idproduto=<%#EVal("IDProduto") %>&idprodutofoto=<%#EVal("IDProdutofoto") %>&from=fotos'>
	                                    <img src='../thumbnail.ashx?width=200&filename=~/imagens/produtos/<%#Eval("Nome") %>' />	           
	                                </a>     
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
	    <br />
	    <br />
	    <table style="background-color:#ececec;border:solid 1px grey" >
	        <tr>
	            <td>
	                <h3>Subir Arquivo</h3>
	                <br />
            	    <asp:FileUpload runat='server' ID='filUpload' />
	            </td>
	        </tr>
	        <tr>
	            <td>
            	    <asp:Button runat='server' ID='btnSubir' Text='Subir' />
	            </td>
	        </tr>
	    </table>
	</asp:Panel>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' />
    </div>
</asp:Content>

