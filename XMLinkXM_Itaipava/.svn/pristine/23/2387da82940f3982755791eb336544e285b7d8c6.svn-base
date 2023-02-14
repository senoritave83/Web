<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="LogAcessosUsuario.aspx.vb" Inherits="Pages.Sistema.LogAcessosUsuario" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updFiltro" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<asp:ScriptManager ID="ScriptManager1" runat="server" />
	    <asp:UpdatePanel ID="updFiltro" runat="server">
	        <ContentTemplate>
			    <div class='Filtro'>
				    <div class='FiltroItem'>
					    <asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					    <br>
					    <asp:DropDownList runat='server' ID='cboEmpresa' DataTextField='Empresa' DataValueField='IDEmpresa'></asp:DropDownList>
				    </div>
                    <div class='FiltroItem' style="padding-left:14px;">
                        <asp:Label runat="server" id="lblIdUsuario">Usuário</asp:Label>
                        <br>
                        <asp:DropDownList runat='server' ID='cboIdUsuario' DataTextField='Usuario' DataValueField='IDUsuario'></asp:DropDownList>
                    </div>
				    <br class='cb' />
		            <div class='FiltroItem' style="width:400px">Data<br>
						    <asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" Width='80' />
						    <asp:CompareValidator runat='server' ValueToCompare=""  ID='valCompDataInicial' Display="Dynamic" ErrorMessage='Data inicial inv&aacute;lida!' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate='txtDataInicial' ErrorMessage="*" Display="Dynamic" />
						    <cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		        		    at&eacute;
						    <asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" Width='80' />
						    <cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
						    <asp:CompareValidator runat='server'  ID='valCompDataFinal' Display='Dynamic' ErrorMessage='Data final inv&aacute;lida!' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate='txtDataFinal' ErrorMessage="*" Display="Dynamic" />
		            </div>
				    <div class='FiltroBotao'>
					    <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				    </div>
			    </div>
	            <div class='ListArea'>
				    <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				        <HeaderStyle HorizontalAlign='Left' />
					    <columns>
					        <asp:BoundField DataField='Usuario' HeaderText='Usuário' SortExpression="Usuario"  />
					        <asp:BoundField DataField='LoginUsuario' HeaderText='Login' SortExpression="LoginUsuario"  />
                            <asp:BoundField DataField='Data' HeaderText='Data do Acesso' SortExpression="Data" HeaderStyle-HorizontalAlign='Center' ItemStyle-HorizontalAlign='Center' />
                            <asp:BoundField DataField='DuracaoAcesso' HeaderText='Duração do Acesso' SortExpression="DuracaoAcesso" HeaderStyle-HorizontalAlign='Center' ItemStyle-HorizontalAlign='Center' />
                            <asp:BoundField DataField='PermissaoUsuario' HeaderText='Permissão do Usuário' SortExpression="PermissaoUsuario"  />
					    </columns>
					    <EmptyDataTemplate>
				            <div class='GridHeader'>&nbsp;</div>					    
					        <div class='divEmptyRow'>
							    <asp:Label runat='server' ID='lblNaoEncontrados'>
								    N&atilde;o h&aacute; dados com o filtro selecionado!
							    </asp:Label>
					        </div>
					    </EmptyDataTemplate>
				    </asp:GridView>		
	            </div>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>
    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

