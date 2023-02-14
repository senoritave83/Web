<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="LOGs.aspx.vb" Inherits="Pages.Cadastros.LOGs" title="Untitled Page" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
                <div class='FiltroItem'>
					<asp:Label runat="server" id="lblUsuario">Usu&aacute;rio</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtUsuario' CssClass="formulario" />
				</div>
				<div class='FiltroItem' style="width:148px;">
					<asp:Label runat="server" id="lblModulo">M&oacute;dulo</asp:Label>
					<br>
					<asp:DropDownList runat="server" id="cboModulo" DataTextField="Modulo" DataValueField="Modulo" Width="148px" CssClass="Select"/>
                    <asp:CompareValidator runat='server' ControlToValidate='cboModulo' ValueToCompare="0" Type="String" Operator='NotEqual' ErrorMessage="Selecione um m&oacute;dulo" Display='Dynamic' ForeColor="Red" Font-Bold="false"></asp:CompareValidator>
				</div>
                <div class='FiltroItem'>
					<asp:Label runat="server" id="lblDataInicial">Data Inicial</asp:Label>
					<br>
					<asp:TextBox onkeypress="return FormatarData(this, event);" onblur="VerificaData(this);" Runat="server" MaxLength="10" ID='txtDataInicial' CssClass="formulario" />
                    <asp:RequiredFieldValidator ID="req1" runat='server' ControlToValidate='txtDataInicial' ErrorMessage="Informe a data inicial" Display='Dynamic' ForeColor="Red" Font-Bold="false"></asp:RequiredFieldValidator>
				</div>
                <div class='FiltroItem'>
					<asp:Label runat="server" id="lblDataFinal">Data Final</asp:Label>
					<br>
					<asp:TextBox onkeypress="return FormatarData(this, event);" onblur="VerificaData(this);" Runat="server" MaxLength="10" ID='txtDataFinal' CssClass="formulario" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat='server' ControlToValidate='txtDataFinal' ErrorMessage="Informe a data final" Display='Dynamic' ForeColor="Red" Font-Bold="false"></asp:RequiredFieldValidator>
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' CellPadding="1" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="" DataNavigateUrlFormatString="LOG.aspx?" DataTextField="Usuario" HeaderText="Usuario" SortExpression="Usuario"  />
                        <asp:BoundField HeaderText="M�dulo" DataField="Modulo" SortExpression="Modulo" />
                        <asp:TemplateField HeaderText="A��o" SortExpression="Acao">
                            <ItemTemplate>
                                <%# fncQuebraLinha(Eval("Acao") & "")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Data" DataField="Data" SortExpression="Data" />
                        <asp:BoundField HeaderText="Permiss�o Atual" DataField="permissaoatual" SortExpression="Permiss�o Atual" />
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
                <xm:Paginate ID="Paginate1" runat="server" />
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

            Function fncQuebraLinha(ByVal texto As String) As String
                Dim strReturn As String = ""
                Dim i As Integer = 0
                Do While Len(texto) > 0
                    If strReturn <> "" Then strReturn &= "<BR>"
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

