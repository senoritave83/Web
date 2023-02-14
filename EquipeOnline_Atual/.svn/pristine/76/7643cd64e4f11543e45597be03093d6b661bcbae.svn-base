<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="OrdemServico.aspx.vb" Inherits="home_OrdemServico" title="Equipe Online" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center">
        <tr class='Header1'> 
            <td>
                Ordem de Servi&ccedil;o
            </td>
        </tr> 
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" alt=""/></td>
        </tr>
        <tr class="Header2">
            <td>            	
                	Dados da O.S.
            </td>
        </tr>
	    <tr>
		    <td>	
			    <table width="98%" style="text-align:left;">
				    <tr valign="top" class="Header">
					    <td class="cinza1">
                            <br />
						    O.S.:&nbsp;<asp:label id="lblOS" Runat="server"></asp:label>
					    </td>
				    </tr>
				    <tr>
					    <td class="cinza1">
                            Cliente:&nbsp;<asp:label id="lblCliente" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
				    <tr>
					    <td class="cinza1">R&aacute;dio:
						    <asp:label id="lblResponsavel" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
                    <tr>
					    <td class="cinza1">Prioridade:
						    <asp:label id="lblPrioridade" Runat="server" CssClass="cinza1"></asp:label>
                            <asp:CompareValidator id="compPrioridade" Runat="server" ControlToValidate="cboPrioridade" Display="Dynamic" ErrorMessage='Por favor selecione a Prioridade' ValidationGroup='valPrioridade' ValueToCompare="0" Operator="GreaterThan">*</asp:CompareValidator>
                            <asp:LinkButton ID="btnAlterar" runat="server" Text="Alterar" />
                            <asp:DropDownList  CssClass="ui-select" ID="cboPrioridade" runat='server' Visible="false" Width="110px">
                                <asp:ListItem Selected='True' Text='Selecione...' Value='0'></asp:ListItem>
                                <asp:ListItem Text='Baixa' Value='3'></asp:ListItem>
                                <asp:ListItem Text='Média' Value='2'></asp:ListItem>
                                <asp:ListItem Text='Alta' Value='1'></asp:ListItem>
                            </asp:DropDownList>
                            <asp:ImageButton Runat="server" id="btnOk" Visible="false" ValidationGroup='valPrioridade' ImageUrl="../images/buttons/btn_ok.png" runat="server" ></asp:ImageButton>
                            <asp:ImageButton Runat="server" id="btnCancelar" Visible="false" ImageUrl="../images/buttons/btn_cancelar.png" runat="server" ></asp:ImageButton>
                        </td>
				    </tr>
                    <tr>
					    <td class="cinza1"><asp:literal runat="server" ID="ltEnderecoCaption">Endereço:</asp:literal>
						    <asp:label id="lblEndereco" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
                    <tr runat="server" id="trEnderecoDestino">
					    <td class="cinza1">Endereço de Destino:
						    <asp:label id="lblEnderecoDestino" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
				    <tr>                        
					    <td class="cinza1" colspan="2">
                            <br />
                            Descri&ccedil;&atilde;o
                            <br />
						    <asp:textbox id="txtDescricao" Runat="server" CssClass="Caixa" ReadOnly="true" Rows="4" TextMode="MultiLine" Width="100%"></asp:textbox>
                        </td>
				    </tr>
				    <tr>
					    <td class="cinza1">
                            <br />
                            Agendada em:
						    <asp:label id="lblAgendada" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
				    <tr>
					    <td class="cinza1">
                            Inicio do servi&ccedil;o:&nbsp;<asp:label id="lblInicio" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
				    <tr>
					    <td class="cinza1">
                            Termino do Servi&ccedil;o:&nbsp;<asp:label id="lblTermino" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
				    <tr>
					    <td class="cinza1">
                            Status Atual:&nbsp;<asp:label id="lblStatus" Runat="server" CssClass="cinza1"></asp:label>
                        </td>
				    </tr>
			    </table>
                <br />
            </td>
        </tr> 
        <asp:PlaceHolder runat='server' ID='plhEtapas'>
            <tr class='Header1'> 
                <td>
                    <strong>&nbsp;Etapas Realizadas</strong>
                </td>
            </tr> 
            <tr>
                <td>
                    <table width='100%'>
                        <asp:Repeater runat='server' ID='rptEtapasTitulos'>
                            <HeaderTemplate>
                                <tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <td style="background-color:<%#Eval("Color") %>;" ><%#Eval("Etapa")%></td>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tr>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater runat='server' ID='rptEtapasDados'>
                            <HeaderTemplate>
                                <tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <td <%#IIf(IsDBNull(Eval("Data")), "", "bgcolor='" & Eval("Color") & "'")%> ><%#IIf(IsDBNull(Eval("Data")), "", Eval("Data"))%>&nbsp;</td>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tr>
                            </FooterTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </asp:PlaceHolder> 
        <asp:PlaceHolder runat='server' ID='plhHistorico'>
            <tr class='Header1'> 
                <td>
                    <strong>&nbsp;Hist&oacute;rico</strong>
                </td>
            </tr> 
            <tr> 
                <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
            </tr>
	        <tr>
		        <td>	
			        <asp:TreeView runat='server' ID='trvRespostas' ImageSet="Simple2" NodeIndent="10" ShowLines="true" Width='100%' CssClass="TreeView">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" />
                        <NodeStyle ForeColor="Black" />
                        <Nodes>
                            <asp:TreeNode Text="asda" />
                        </Nodes>
			        </asp:TreeView>
		        </td>
	        </tr>
	    </asp:PlaceHolder> 
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" /></td>
        </tr>							
    </table>
</asp:Content>
<asp:Content runat='server' ID='Content2' ContentPlaceHolderID='Botoes'>
	<asp:ImageButton Runat="server" id="btnVoltar" ImageUrl="../images/buttons/btn_voltar.png" runat="server" CausesValidation=False></asp:ImageButton>
    <asp:ImageButton Runat="server" id="btnApagar" ImageUrl="../images/buttons/btn_excluir.png" runat="server" CausesValidation=False></asp:ImageButton>
    <asp:ImageButton Runat="server" id="btnReenviar" ImageUrl="../images/buttons/btn_encaminhar.png" runat="server" CausesValidation=False></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content3' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><a href="default.aspx">Lista de O.S.</a></dt>
    <dt><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt><a href="pasta.aspx">Pastas</a></dt>
    </dl>
</asp:Content>


