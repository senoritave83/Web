<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pesquisa.aspx.vb" Inherits="Pages.Pesquisas.Pesquisa" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
            <div class='trField cb' runat='server'  id='trPesquisa' visible='<%$Settings: visible, Pesquisa.Pesquisa, true %>' >
				<div class='tdFieldHeader cb fl'>
					Pesquisa:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPesquisa' MaxLength="50" Width="80%" />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Enabled='<%$Settings: Required, Pesquisa.Pesquisa, true %>' Display='None' ErrorMessage='Pesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPesquisa' />                    
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDataInicio' visible='<%$Settings: visible, Pesquisa.DataInicio, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data Inicio:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDataInicio' MaxLength="10" />
					<asp:RequiredFieldValidator runat='server' ID='valReqDataInicio' Enabled='<%$Settings: Required, Pesquisa.DataInicio, true %>' Display='None' ErrorMessage='DataInicio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDataInicio' />					
                    <asp:CustomValidator runat="server" ID="valCustomValidDateInicio" Display="None" ErrorMessage="Data Inicio inv&aacute;lida" ControlToValidate="txtDataInicio" OnServerValidate="dateValidator" Enabled="true" />
                    <cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicio" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDataFim' visible='<%$Settings: visible, Pesquisa.DataFim, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data Fim:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtDataFim' MaxLength="10" />
					<asp:RequiredFieldValidator runat='server' ID='valReqDataFim' Enabled='<%$Settings: Required, Pesquisa.DataFim, true %>' Display='None' ErrorMessage='Data Fim &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtDataFim' />
                    <asp:CustomValidator runat="server" ID="valCustomValidDateFim" Display="None" ErrorMessage="Data Fim inv&aacute;lida" ControlToValidate="txtDataFim" OnServerValidate="dateValidator" Enabled="true" />
                    <cc1:CalendarExtender  ID="CalendarExtender1" runat="server" TargetControlID="txtDataFim" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trVisitasMes' visible='<%$Settings: visible, Pesquisa.VisitasMes, true %>' >
				<div class='tdFieldHeader cb fl'>
					Visitas Mes:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtVisitasMes' />
					<asp:RequiredFieldValidator runat='server' ID='valReqVisitasMes' Enabled='<%$Settings: Required, Pesquisa.VisitasMes, true %>' Display='None' ErrorMessage='Visitas Mes &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtVisitasMes' />
                    <asp:CompareValidator runat="server" ID="valGreaterVistasMes" Enabled="true" ErrorMessage="Visitas Mes precisa ser maior que zero" ControlToValidate="txtVisitasMes" ValueToCompare="0" Type="Integer" Operator="GreaterThan" ></asp:CompareValidator>
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Pesquisa.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Pesquisa.VisitasMes, true %>' >
				<div class='tdFieldHeader cb fl'>
					Pricing:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkPricing' />
				</div>
			</div>
		</div>
        <div class='divLista' style="width:45%; float:left;" runat="server" id="divMarcas">            
			<div class='tdField fl'>
				<asp:GridView runat="server" ID="grdMarca" AutoGenerateColumns="false" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <FooterStyle />
                    <RowStyle />
                    <Columns>
                        <asp:TemplateField HeaderText="Marcas">
                            <ItemTemplate>
                                <input type='checkbox' id='chkMarca_<%# Eval("IDMarca") %>' name='Marca' value='<%# Eval("IDMarca") %>' <%# IIF(cls.Marcas.Contains(Eval("IDMarca")), "checked", "") %> />
                                <label for='chkMarca_<%# Eval("IDMarca") %>'><%# Eval("Marca") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
			</div>
        </div>
        <div class='divLista' style="width:45%; float:right;" runat="server" id="divProdutos">            
			<div class='tdField fl'>
				<asp:GridView runat="server" ID="grdProdutos" AutoGenerateColumns="false" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <FooterStyle />
                    <RowStyle />
                    <Columns>
                        <asp:TemplateField HeaderText="Produtos">
                            <ItemTemplate>
                                <input type='checkbox' id='chkProduto_<%# Eval("IdProdutoPesquisa") %>' name='Produto' value='<%# Eval("IdProdutoPesquisa") %>' <%# IIF(cls.Produtos.Contains(Eval("IdProdutoPesquisa")), "checked", "") %> />
                                <label for='chkProduto_<%# Eval("IdProdutoPesquisa") %>'><%# Eval("ProdutoPesquisa") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>
                </asp:GridView>
			</div>
        </div>
        <div class='divLista' style="clear:both;" runat="server" id="divEmpresas">
            <div class='tdField fl'>
				    <asp:GridView runat="server" ID="grdEmpresas" AutoGenerateColumns="false" PageSize="10" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterStyle />
                        <RowStyle />
                        <Columns>
                            <asp:TemplateField HeaderText="Revendas">
                                <ItemTemplate>
                                    <input type='checkbox' id='chkEmpresa_<%# Eval("IDEmpresa") %>' name='Empresa' value='<%# Eval("IDEmpresa") %>' <%# IIF(cls.Empresas.Contains(Eval("IDEmpresa")), "checked", "") %> <%# iif( Me.User.IDEmpresa <> 0 and Eval("IDEmpresa") <> Me.User.IDEmpresa, "disabled" , "" ) %>  />
                                    <label for='chkEmpresa_<%# Eval("IDEmpresa") %>'><%# Eval("Empresa") %></label>
                                </ItemTemplate>
                            </asp:TemplateField>                        
                        </Columns>
                    </asp:GridView>
			    </div>
        </div>
	</div>
    
            
    <div id="divBotoes" class='AreaBotoes' style="clear:both;">
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />        
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pesquisa.aspx?idpesquisa=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Pesquisas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize>
		    </li> 
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
    <asp:CustomValidator runat="server" ID="valCustomGravar" Display="None" ErrorMessage="Data fim precisa ser maior ou igual data inicio" ControlToValidate="txtDataFim" ClientValidationFunction="checkDates" Enabled="true" />
    <script type="text/javascript" language="javascript">
        function checkDates(sender, args) {
            var data1 = document.getElementById("<%= txtDataInicio.ClientID %>").value;
            var data2 = document.getElementById("<%= txtDataFim.ClientID %>").value;

            data1 = data1.split("/");
            data2 = data2.split("/");

            if (data1[1] > data2[1]) {
                args.IsValid = false;
            }
            else if ((data1[1] == data2[1]) && (data1[0] > data2[0])) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
</asp:Content>