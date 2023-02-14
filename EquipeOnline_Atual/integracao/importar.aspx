<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="importar.aspx.vb" Inherits="integracao_importar" %>
<%@ Register Src="~/include/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager runat='server' ID='ScriptManager1'></asp:ScriptManager>
    <table width="101%" border="0" align="center" cellpadding="0" cellspacing="0" style="border:1px #D7D2CB solid; border-top:0px;">
        <tr class='Header1'> 
            <td>
                <strong>Importar arquivo de O.S.</strong>
            </td>
        </tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>
        <tr>
	        <td>	
				<asp:GridView runat='server' id='GridView1' Width='100%' AutoGenerateColumns='false' AllowSorting='true' ShowHeader="True" BorderStyle='None' BorderWidth='0' CssClass='GridView'>
			        <HeaderStyle  CssClass='Header2' HorizontalAlign='Left' />
				    <RowStyle cssclass="griditem" />
					<columns>
						<asp:HyperLinkField Target='_blank' DataNavigateUrlFields="Arquivo" DataNavigateUrlFormatString="arquivo.aspx?file={0}" ItemStyle-Width='100px' DataTextField="Arquivo" HeaderText="Arquivo" SortExpression="Arquivo" HeaderStyle-HorizontalAlign='Left'  />
						<asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" ItemStyle-Width='70px' HeaderStyle-HorizontalAlign='Left' />
						<asp:BoundField HeaderText="Tipo" DataField="Tipo" SortExpression="Tipo" ItemStyle-Width='70px' HeaderStyle-HorizontalAlign='Left' />
						<asp:BoundField HeaderText="Data" DataField="DataInclusao" SortExpression="DataInclusao" ItemStyle-Width='100px' HeaderStyle-HorizontalAlign='Left' />
						<asp:TemplateField HeaderText='Tamanho' ItemStyle-Width='60px' HeaderStyle-HorizontalAlign='Left'>
						    <ItemTemplate>
						        <%# FormatBytes(Eval("Size")) %>
						    </ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText='Obs.' HeaderStyle-HorizontalAlign='Left'>
						    <ItemTemplate>
						        <%# Eval("Observacao") %>
						    </ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField ItemStyle-Width='100px' HeaderStyle-HorizontalAlign='Right'>
						    <ItemTemplate>
						        <asp:Button runat='server' ID='btnProcessar' CssClass="btn_importar" CommandName='Processar' CommandArgument='<%# Eval("Arquivo") %>' Visible='<%# IIF(Eval("IDStatus") = 1 OR Eval("IDStatus") = 2, true, False) %>' />
	                            <asp:ImageButton Runat="server" ID="btnEnviar" ImageUrl="../images/ico_sair.gif" CommandName='Excluir' CommandArgument='<%# Eval("Arquivo") %>'></asp:ImageButton>
						    </ItemTemplate>
						</asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow' style='text-align:center'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; arquivos gravados no sistema!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
            </td> 
        </tr> 
        <tr class='Header2'> 
            <td>
                Subir arquivo
            </td>
        </tr>
        <tr>
	        <td>	
	            <asp:PlaceHolder runat='server' ID='plhUpload'>
	                <table width='100%' border='0'>
                        <tr>
                            <td>
	                            <table width="100%" border="0" style="margin-left:3px;">
			                        <tr>
				                        <td class="cinza1" width='200' style="text-align:left;">
                                            Selecione o arquivo desejado:
                                            <asp:FileUpload runat='server' ID='txtArquivo' />
                                        </td>					                        
				                        <td style="padding-left:15px; text-align:left;">
                                            <br />
	                                        <asp:ImageButton Runat="server" ID="btnEnviar" ImageUrl="../images/buttons/btn_enviar.png"></asp:ImageButton>
				                        </td>
			                        </tr>
			                        <tr>
			                            <td colspan="2" style="text-align:left;">
		                                    Tamanho m&aacute;ximo do arquivo: <asp:Literal runat='server' ID='ltrTamanhoMaximo'></asp:Literal>
		                                </td>
                                    </tr>
                                    <tr>
		                                <td colspan='2' style="text-align:left;">
		                                    <asp:Label runat='server' ID='lblMessage' EnableViewState='false' Font-Bold='true' ForeColor='Red'></asp:Label>
			                            </td>
			                        </tr>
		                        </table>
                            </td>
                            <td rowspan='2' align='right' valign='top'>
                                <table class='Header1' cellspacing='0' width='150px'>
                                    <tr><td colspan='2' class='Header1' align='center'>Espa&ccedil;o dispon&iacute;vel</td></tr>
                                    <tr><td>Total: </td><td><asp:Literal runat='server' ID='ltrEspacoTotal' /></td></tr>
                                    <tr><td>Utilizado: </td><td><asp:Literal runat='server' ID='ltrEspacoUtilizado' /></td></tr>
                                    <tr><td>Livre: </td><td><asp:Literal runat='server' ID='ltrEspacoLivre' /></td></tr>
                                </table>
                            </td>
                        </tr>	          
	                </table>
                </asp:PlaceHolder>
                <!-- FIM CONTE&#65533;DO -->
	        </td>
        </tr>
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" /></td>
        </tr>							
    </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton CausesValidation="false" runat="server" id="btnVoltar" ImageUrl="../images/buttons/btn_voltar.png" ></asp:ImageButton>
</asp:Content>
<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><a href="/home/calendario.aspx">Calend&aacute;rio</a></dt>
    <dt><a href="/home/agendamentos.aspx">Agendamento</a></dt>
    <dt><span lang="pt-br"><a href="/home/agendamento.aspx">Nova O.S programada</a> </span></dt>
    <dt class="current"><span lang="pt-br"><a href="../integracao/default.aspx">Integra&ccedil;&atilde;o</a> </span></dt>
    </dl>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

