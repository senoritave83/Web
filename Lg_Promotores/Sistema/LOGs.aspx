<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="LOGs.aspx.vb" Inherits="Pages.Cadastros.LOGs" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
                <div class='FiltroItem'>
					<asp:Label runat="server" id="lblUsuario">Usuário</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtUsuario' />
				</div>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblModulo">Módulo</asp:Label>
					<br>
					<asp:DropDownList runat="server" id="cboModulo" DataTextField="Modulo" DataValueField="Modulo"/>
                    <asp:CompareValidator runat='server' ControlToValidate='cboModulo' ValueToCompare="0" Type="String" Operator='NotEqual' ErrorMessage="Selecione um módulo" Display='Dynamic'></asp:CompareValidator>
				</div>
                <div class='FiltroItem'>
					<asp:Label runat="server" id="lblDataInicial">Data Inicial</asp:Label>
					<br>
					<asp:TextBox onkeypress="return FormatarData(this, event);" onblur="VerificaData(this);" Runat="server" MaxLength="10" ID='txtDataInicial' />
                    <asp:RequiredFieldValidator ID="req1" runat='server' ControlToValidate='txtDataInicial' ErrorMessage="Informe a data inicial" Display='Dynamic'></asp:RequiredFieldValidator>
				</div>
                <div class='FiltroItem'>
					<asp:Label runat="server" id="lblDataFinal">Data Final</asp:Label>
					<br>
					<asp:TextBox onkeypress="return FormatarData(this, event);" onblur="VerificaData(this);" Runat="server" MaxLength="10" ID='txtDataFinal' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat='server' ControlToValidate='txtDataFinal' ErrorMessage="Informe a data final" Display='Dynamic'></asp:RequiredFieldValidator>
				</div>    
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
                <div>
                    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='0' DynamicLayout='false'>
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                    </ProgressTemplate>
                </asp:UpdateProgress> 
                </div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="" DataNavigateUrlFormatString="LOG.aspx?" DataTextField="Usuario" HeaderText="Usuario" SortExpression="Usuario"  />
                        <asp:BoundField HeaderText="Módulo" DataField="Modulo" SortExpression="Modulo" />
                        <asp:TemplateField HeaderText="Ação" SortExpression="Acao">
                            <ItemTemplate>
                                <%# fncQuebraLinha(Eval("Acao") & "")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Data" DataField="Data" SortExpression="Data" />
                        <asp:BoundField HeaderText="Permissão Atual" DataField="permissaoatual" SortExpression="Permissão Atual" />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; LOGs com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>
        
        <script type='text/javascript'>

            function FormatarData(obj, ev) {
                var param = ev.keyCode ? ev.keyCode : ev.which ? ev.which : ev.charCode;
                if (param < 31) return true;
                if ((param < 48) || (param > 57)) return false;
                else {
                    if ((param != 8) && (param != 47)) {
                        if (obj.value.length == 2) obj.value += '/';
                        if (obj.value.length == 5) obj.value += '/';
                    }
                    else if (x == 47) {
                        if (obj.value.length == 1) obj.value = '0' + obj.value;
                        if (obj.value.length == 4) obj.value = obj.value.substr(0, 3) + '0' + obj.value.substr(3, 1);
                    }
                }
            } 
        </script>
        		
        <script language='vbscript' runat='server'>

            Function fncQuebraLinha(ByVal texto As String)
                Dim strReturn As String = ""
                Dim i As Integer = 0
                Do While Len(texto) > 0
                    If strReturn <> "" then strReturn &= "<BR>"
                    If texto.Length > 50 Then
                        strReturn &= texto.Substring(0, 50)
                        texto = texto.Substring(50)
                    Else
                        strReturn &= texto
                        texto = ""
                    End If
                Loop
                Return strReturn
            End Function
        </script>
	</div>       

    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='LOGs.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

