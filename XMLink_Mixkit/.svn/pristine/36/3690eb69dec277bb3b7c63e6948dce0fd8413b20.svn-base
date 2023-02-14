<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Processos.aspx.vb" Inherits="Pages.Integracao.Processos" title="Untitled Page" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' />
				</div> 
		        <div class='FiltroItem'>
				        <font class="TextDefault">Data Inicial</font><br>
				        <asp:textbox id="txtDataInicial" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" CssClass="Caixa" Width="100" MaxLength="10" Runat="server"></asp:textbox>
		        </div> 
		        <div class='FiltroItem'>
				        <font class="TextDefault">Data Final</font><br>
				        <asp:textbox id="txtDataFinal" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" CssClass="Caixa" Width="100" MaxLength="10" Runat="server"></asp:textbox>
		        </div> 
		        <div class='FiltroItem'>Tipo<br>
		            <asp:DropDownList runat='server' ID='cboTipo'>
		            	<asp:ListItem value="0">Todos</asp:ListItem>
		            </asp:DropDownList>
		        </div>
		        <div class='FiltroItem'>Status<br>
		            <asp:DropDownList runat='server' ID='cboStatus'>
		            	<asp:ListItem value="0">Todos</asp:ListItem>
		            </asp:DropDownList>
		        </div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        	<div class='ListArea'>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="" DataNavigateUrlFormatString="Processo.aspx?" DataTextField="Arquivo" HeaderText="Arquivo" SortExpression="Arquivo"  />
						<asp:BoundField HeaderText="Tipo" DataField="Tipo" SortExpression="Tipo" />
						<asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" />
						<asp:BoundField HeaderText="Data" DataField="DataInclusao" SortExpression="DataInclusao" />
						<asp:TemplateField HeaderText='Obs.'>
						    <ItemTemplate>
						        <%# IIF(Eval("Observacao") <> "", "<img src=""../imagens/help.gif"" alt=""" & Eval("Observacao") & """ />", "") %>
						    </ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField>
						    <ItemTemplate>
						        <asp:Button runat='server' ID='btnProcessar' Text='Processar' CommandName='Processar' CommandArgument='<%# Eval("Arquivo") %>' />
						    </ItemTemplate>
						</asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; Processos com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <xm:Paginate ID="Paginate1" runat="server" />
        	</div>
		</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
        </Triggers> 
    </asp:UpdatePanel>		
    <div class='AreaBotoes'>
        <asp:FileUpload runat='server' ID='txtArquivo' />
		<asp:RequiredFieldValidator runat='server' ID='valReqFile' Display='None' ErrorMessage='Por favor selecione o arquivo a ser importado!' ControlToValidate='txtArquivo' ValidationGroup="NovoArquivo" />
        <asp:DropDownList runat='server' ID='cboTipoNovo' />
		<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Por favor selecione o tipo do arquivo!' ControlToValidate='cboTipoNovo' ValidationGroup="NovoArquivo" />
		<asp:CompareValidator runat='server' ID='RequiredFieldValidator2' Display='None' ErrorMessage='Por favor selecione o tipo do arquivo!' ControlToValidate='cboTipoNovo' Operator='GreaterThan' ValueToCompare='0' ValidationGroup="NovoArquivo" />
        <asp:Button runat='server' ID='btnEnviar' ValidationGroup="NovoArquivo" CssClass="Botao" Text='Enviar arquivo' />
    </div> 
    <asp:UpdatePanel runat='server' ID='updErros'>
        <ContentTemplate>
            <div id='divErros'>
                <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
                <asp:ValidationSummary runat='server' ID='valSummary' ValidationGroup='NovoArquivo' />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Processo.aspx'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

