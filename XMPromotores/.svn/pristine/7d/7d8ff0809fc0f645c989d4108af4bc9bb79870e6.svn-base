<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Pesquisa.aspx.vb" Inherits="Pages.Cadastros.Pesquisa" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../controls/Roteiro.ascx" TagName="Roteiro" TagPrefix="uc2" %>
<%@ Register src="../controls/Segmentacao.ascx" tagname="Segmentacao" tagprefix="uc1" %>
<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc3" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="margin:10px 10px 10px 10px;">
		<table class="EditArea" style="margin-bottom:20px; padding:8px; padding:50px\9;  margin-left:9px; margin-right:9px;">
			<tr class='trField' id='trCodigo' runat='server'>
				<td class='tdFieldHeader' style="width: 150px;">
					&nbsp;&nbsp;<a>C&oacute;digo:</a>
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCodigo' />
				</td>
			</tr>	
			<tr class='trField'>
				<td class='tdFieldHeader' style="width: 150px;">
				 &nbsp;&nbsp;<a>Pesquisa:</a>
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtPesquisa' MaxLength='50' Width='65%' CssClass="formulario" />
					<asp:RequiredFieldValidator runat='server' ID='valReqPesquisa' Display='None' ErrorMessage='Pesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPesquisa' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader' style="width: 150px;">
					&nbsp;&nbsp;<a>Concorrente:</a>
				</td>
				<td class='tdField'>
					<asp:DropDownList runat='server' ID='cboConcorrente' CssClass="Select" >
					    <asp:ListItem Value='0'>N&atilde;o</asp:ListItem>
					    <asp:ListItem Value='1'>Sim</asp:ListItem>
					    <asp:ListItem Value='2' Selected="True">Todos</asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader' style="width: 150px;">
					&nbsp;&nbsp;<a>Criado:</a>
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader' style="width: 150px;">
					&nbsp;&nbsp;<a>Pesquisa de:</a>
				</td>
				<td class='tdField'>
                    <asp:UpdatePanel runat="server" ID='updTipoPesquisa'>
                    <ContentTemplate>
                        <table id='tblEditAcao' style="width:52%" border='0'>
				            <tr>
				                <td style="width:25%;">
				                    <asp:CheckBox runat='server' ID='chkEstoque' AutoPostBack="true"  /> Estoque 
				                </td>
				                <td style="width:25%;">
				                    <asp:CheckBox runat='server' ID='chkPreco' AutoPostBack="true" /> Pre&ccedil;o
				                </td>
				                <td style="width:25%;">
				                    <asp:CheckBox runat='server' ID='chkPerguntas' AutoPostBack="true" /> Perguntas
				                </td>
				                <td style="width:25%;" runat="server" id="tdAmostragem">
				                    <asp:CheckBox runat='server' ID='chkAmostragem' AutoPostBack="true" /> Amostragem
				                </td>
				            </tr>
				        </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader' style="width: 150px;">
					&nbsp;&nbsp;<a>Cargos permitidos:</a>
				</td>
				<td class='tdField'>
                    <asp:CheckBoxList RepeatDirection="Horizontal" runat="server" ID="chkCargosPermitidos" RepeatLayout=Flow>
                    </asp:CheckBoxList>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader' style="width: 150px;">
					&nbsp;&nbsp;<a>Ativo:</a>
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkAtivo' />
				</td>
			</tr>
		</table>
        <div id="divRoteiro1" runat="server" >
            <uc2:Roteiro ID="Roteiro1" runat="server" showSemanaMes='<%$Settings: Visible, Pesquisa.SemanaMes, "true"%>' />	
        </div>
	</div>
	<asp:PlaceHolder runat='server' ID='phlOpcoes'>
        <uc1:Segmentacao ID="Segmentacao1" runat="server">
            <Title>Exibir a pesquisa para a seguinte segmenta&ccedil;&atilde;o</Title>
            <EmptyDataText>
                 N&atilde;o h&aacute; segmenta&ccedil;&atilde;o cadastrada para essa pesquisa!
            </EmptyDataText>
        </uc1:Segmentacao>
        <uc3:Localizacao ID="Localizacao1" runat="server">
            <Title>Exibir a pesquisa para os seguintes crit&eacute;rios de lojas:</Title>
            <EmptyDataText>N&atilde;o h&aacute; crit&eacute;rios de lojas cadastradas para essa pesquisa!</EmptyDataText>
        </uc3:Localizacao>    
        <br class='cb' />
        <div id='AreaPerguntaPesquisa'>
            <asp:Panel runat='server' ID='Panel2'>
                <asp:UpdatePanel runat='server' ID='pnlUpdate'>
                    <ContentTemplate>                        
                        <table id='Table4' width='100%'>
			                <tr class='trField'>
			                	<td><h4>Exibir a pesquisa para as seguintes perguntas:</h4></td>
				                <td colspan='2' width='100%'>				                	
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="pnlUpdate" DisplayAfter='1000' DynamicLayout='false'>
                                        <ProgressTemplate>
                                            <asp:Image ID="Image13" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                                        </ProgressTemplate>
                                    </asp:UpdateProgress> 
				                </td>
			                </tr>
			                <tr class='trField'>
				                <td class='tdField' width='30%'>
					                <asp:TextBox runat="server" ID='txtBuscaPergunta' Width='100%' CssClass="formulario" ></asp:TextBox>
				                </td>
                                <td align="left">
                                    <asp:Button runat='server' ID='btnBuscaPergunta' Text='Buscar' Cssclass='BotaoAdicionar' />
                                </td>
                            </tr>
                        </table>
                        <div class='ListaItens'>
                            <asp:GridView runat='server' ID='grdPerguntas' Width='100%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDPergunta' CellPadding="1" CellSpacing="1">
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:BoundField DataField='Pergunta' HeaderText='Pergunta' />
                                    <asp:ButtonField  CommandName='RetirarPergunta' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir_ico.png"/>' />
                                </Columns>
                                <EmptyDataTemplate>
                                    N&atilde;o h&aacute; perguntas cadastrados para essa pesquisa!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div id='AdicionarPerguntaPesquisa' class="marginTop">
		                    <table id='Table5'>
			                    <tr class='trField'>
				                    <td colspan='3'>
					                    <h4>Adicionar uma nova pergunta</h4>
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdField'>
					                    <label>Pergunta:</label><br />
				                        <asp:DropDownList runat='server' ID='cboPergunta' DataTextField='Pergunta' DataValueField='IDPergunta' CssClass="Select" /> 
				                    </td>
                                </tr>
			                    <tr>
    		                        <td colspan='3'>
                                        <asp:Button runat='server' ID='btnAddPergunta' Text='Adicionar Pergunta' class='BotaoAdicionar' />
			                        </td>
			                    </tr>
		                    </table>
	                    </div>
                     </ContentTemplate> 
                </asp:UpdatePanel> 
            </asp:Panel>
        </div>
        <br class='cb' />
    </asp:PlaceHolder> 
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pesquisa.aspx?idpesquisa=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Pesquisas.aspx'" />
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

