<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Recados.aspx.vb" Inherits="Pages.Sistema.Recados" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<%@ Register src="../controls/FiltroSuperiorMultiplo.ascx" tagname="FiltroSuperiorMultiplo" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript"> 
        function fncFormatPhones(txt) {
            var p_Carac = '0123456789;';
            var p_Phones = '', p_PhonesNew = ';';
            p_Phones = txt.value;

            //Verifica o padrão do telefone. Ex: 1199887766
            var P_PhonesValid = p_Phones.split(';');
            for (i = 0; i < P_PhonesValid.length; i++) {
                if (P_PhonesValid[i].length != 0 && P_PhonesValid[i].length != 10) {
                    alert("O Telefone " + P_PhonesValid[i] + " não é válido pois a quantidade de digitos (DDD + Telefone) está fora do padrão.");                    
                }
            }

            for (i = 0; i <= p_Phones.length - 1; i++) {
                if (p_Carac.indexOf(p_Phones.substring(i, i + 1)) >= 0)
                    p_PhonesNew += p_Phones.substring(i, i + 1);
            }
            if (p_PhonesNew.substring(0, 1) == ';')
                p_PhonesNew = p_PhonesNew.substring(1);
            txt.value = p_PhonesNew;
        }
        function checkSize() {
            var i = document.getElementById('<%=txtMensagem.ClientID %>').value.length;
            if (i < 140) {
                document.getElementById('<%=spSize.ClientID %>').innerHTML = 140 - i;
                return true;
            }
            else {
                document.getElementById('<%=spSize.ClientID %>').innerHTML = 0;
                if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 39 && event.keyCode != 38 && event.keyCode != 37 && event.keyCode != 40)
                    return false;
            }
        }
        function Trim() {
            if (document.getElementById('<%=txtMensagem.ClientID %>').value.length > 140) {
                document.getElementById('<%=txtMensagem.ClientID %>').value = document.getElementById('<%=txtMensagem.ClientID %>').value.substring(0, 140);
            } 
        }
    </script>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' />
				</div> 
                <div class='FiltroItem'>
                    <asp:Label runat="server" id="Label4">Data do Envio</asp:Label>
					<br>
                    <asp:TextBox runat="Server" MaxLength="10" CssClass="form_text" id="txtDataEnvio" name="txtDataEnvio" onkeydown="FormataData(this, event);" onblur="VerificaData(this);"></asp:TextBox>
					<cc1:CalendarExtender  ID="cal_txtDataEnvio" runat="server" TargetControlID="txtDataEnvio" PopupPosition="Right" PopupButtonID="imgCalendarInicial"	Format="dd/MM/yyyy"/>
                </div>
		        <div class='FiltroItem'>Enviado por<br>
		            <asp:DropDownList runat="server" ID="cboIDusuario" DataTextField="usuario" DataValueField="IDusuario" />
		        </div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
                <br />
				<div class='FiltroLetras' style="text-align:'left';">
					<xm:Letras ID="Letras1" runat="server" />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
		        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
				        <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				            <HeaderStyle HorizontalAlign='Left' />
					        <columns>
						        <asp:BoundField DataField="Nextel" HeaderText="Celular" SortExpression="Nextel"  />
						        <asp:BoundField HeaderText="Mensagem" DataField="Texto" SortExpression="Texto" />
                                <asp:BoundField HeaderText="Data do Envio" DataField="DataEnviado" SortExpression="DataEnviado" />
                                <asp:BoundField HeaderText="Enviado por" DataField="usuario" SortExpression="usuario" />
					        </columns>
					        <EmptyDataTemplate>
				                <div class='GridHeader'>&nbsp;</div>					    
					            <div class='divEmptyRow'>
							        <asp:Label runat='server' ID='lblNaoEncontrados'>
								        N&atilde;o h&aacute; Recados com o filtro selecionado!
							        </asp:Label>
					            </div>
					        </EmptyDataTemplate>
				        </asp:GridView>
                        <xm:Paginate ID="Paginate1" runat="server" />
			        </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
                        <asp:AsyncPostBackTrigger ControlID='btnEnviar' EventName='Click'  />
                    </Triggers> 
                </asp:UpdatePanel>	
            <asp:Panel runat=server ID=pnlMensagem>
            <div class='Filtro'>
                <table width=100%>
                    <tr>
                        <td style="width:600px;">
                            <uc1:FiltroSuperiorMultiplo ID="FiltroSuperiorMultiplo1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width:600px;">
                                <asp:label  Runat="server" ID="Label6">Promotores</asp:label><br>			
                                <asp:ListBox SelectionMode=Multiple style="width:600px;HEIGHT:150PX;" runat="server" ID="LstPromotor" DataTextField="Usuario" DataValueField="Celular"></asp:ListBox>
		                    </div>
                        </td>
                    </tr>
                </table>
                <div>
		            <i>
			            <asp:label Runat="server" ID="Label1" Font-Bold="false">
				            <font color="#0066cc">
					            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Números no formato incorreto ou sem código de área, não serão enviados.<br/>	
					            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Utilize ";" (ponto e vírgula) para separar os números telefônicos.<br/>
					            <br/>
					            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font><font color="#6699cc">Exemplo: 
					            1199999999;1388888888;1266666666...</font>
                        </asp:label>
                    </i>
		        </div><br/>
		        <asp:label Runat="server" ID="Mensagem">Mensagem</asp:label>
		        <br/>
			
		        <asp:textbox id="txtMensagem" MaxLength="140" TextMode="MultiLine" Runat="server" Width="600" Rows="6" onKeyDown='return checkSize();' onBlur='Trim();'></asp:textbox>
		        <br/>
		        <br/>
		        <i>
			        <asp:label Runat="server" ID="Label3" Font-Bold="false">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;- Caracteres disponíveis: </asp:label>
			        <asp:label Runat="server" id='spSize'>140</asp:label>
                </i>
                </asp:Panel>
                <asp:Panel runat=server ID=pnlResult>
                    <div style="Width:'600px';text-align:'center';">
                        <table width=600>
                            <tr>
                                <td valign=top><asp:label Runat="server" id="lblSucesso" Visible="false"><font color="green">Recado enviado com sucesso!</font></asp:label></td>
                                <td valign=top><asp:label Runat="server" id="lblErro" Visible="false"><font color="red">Por favor, preencha adequadamente todos os campos!</font></asp:label></td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </div>
            <div class='AreaBotoes'>
		        <asp:Button id="btnEnviar" Runat="server" Text="Enviar" CssClass="Botao"></asp:Button>
		        <asp:Button id="btnLimpar" Runat="server" Text="Limpar" CssClass="Botao"></asp:Button>
                <asp:Button id="btnOk" Runat="server" Text="OK" Visible="false" CssClass="Botao"></asp:Button>
                <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Enviar:</b>
				Envia a Mensagem para os Destinat&aacute;rios digitados.
		    </li> 
            <li>
			    <b>Limpar:</b>
				Apaga o conte&uacute;do digitado em Destinat&aacute;rios e Mensagem.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

