<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Filtro.ascx.vb" Inherits="Relatorios_Filtro" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
            <div class='Filtro'>
                <div class='FiltroItem' runat='server' id='divEmpresa' style="padding-right:5px;">
                    Empresa
                    <br />
	                <asp:DropDownList runat='server' AutoPostBack="true" ID='cboEmpresa' DataTextField='Empresa' DataValueField='IDEmpresa'></asp:DropDownList>
                    <asp:CompareValidator Enabled="false" Runat="server" ID='compEmpresa' ControlToValidate='cboEmpresa' ErrorMessage='Selecione uma revenda na lista' Display="Dynamic" CssClass="TextDefault" Type="Integer" Operator="GreaterThan" ValueToCompare="0" />
                </div>
                <div class='FiltroItem' runat='server' id='divPesquisas' style="padding-right:5px" visible="false">
                    Pesquisas
                    <br />
	                <asp:DropDownList runat='server' ID='cboPesquisas' DataTextField='Pesquisa' DataValueField='IDPesquisa'></asp:DropDownList>
                    <asp:CompareValidator Enabled="false" Runat="server" ID='compPesquisa' ControlToValidate='cboPesquisas' ErrorMessage='Selecione uma pesquisa na lista' Display="Dynamic" CssClass="TextDefault" Type="Integer" Operator="GreaterThan" ValueToCompare="0" />
                </div>
                <div class='FiltroItem' runat='server' id='divFiltro' visible='false' style="padding-left:5px;">
                    Filtro
                    <br>
                    <asp:TextBox Runat="server" ID='txtFiltro' MaxLength='200' />
                </div>
                <div class='FiltroItem' runat='server' id='divIDCliente' visible='false' style="padding-left:5px;">
                    Código do Cliente
                    <br>
                    <asp:TextBox Runat="server" ID='txtIDCliente' MaxLength='20' onkeypress='SoNumeros()' />
                </div>
                <div class='FiltroItem' runat='server' id='divNomeCliente' visible='false' style="padding-left:5px;">
                    Nome do Cliente
                    <br>
                    <asp:TextBox Runat="server" ID='txtNomeCliente' MaxLength='50' />
                </div>
                <div class='FiltroItem' ID='divStatusVisita' runat='server' visible='false' style="padding-left:5px;">
                    Status da Visita<br />
		            <asp:DropDownList AutoPostBack='false' runat='server' ID='cboStatusVisita' DataTextField='Justificativa' DataValueField='IDjustificativa'></asp:DropDownList>
		        </div>
                <div class='FiltroItem' runat='server' id='divGerenteVendas' visible='false'>
                    Gerente de Vendas
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboGerenteVendas' DataTextField='GerenteVendas' DataValueField='IdGerenteVendas'></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' id='divSupervisor' style="padding-left:5px;">
                    Supervisor
                    <br />
	                <asp:DropDownList AutoPostBack='true' runat='server' ID='cboSupervisor' DataTextField='Supervisor' DataValueField='IDSupervisor'></asp:DropDownList>
                </div>
                 <div class='FiltroItem' runat='server' id='divVendedor' visible='false' style="padding-left:5px;">
                    Vendedor
                    <br />
	                <asp:DropDownList AutoPostBack='false' runat='server' ID='cboVendedor' DataTextField='Vendedor' DataValueField='IdVendedor'></asp:DropDownList>
                </div>
                <div class='FiltroItem' ID='divStatus' runat='server' visible='false' style="padding-left:5px;">
                    Status<br />
		            <asp:DropDownList AutoPostBack='true' runat='server' ID='cboStatus' DataTextField='Status' DataValueField='IdStatus'></asp:DropDownList>
		        </div>
                <div class='FiltroItem' runat='server' id='divDataInicial' style="padding-left:5px;">
                    <asp:label runat='server' ID='lblData' Text='De' />
                    <asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='txtDataInicial' ErrorMessage='Por favor selecione a data inicial' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID='valCompInicio' ControlToValidate='txtDataInicial' ErrorMessage='Data inicial inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
                    <cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                    <br />
                    <asp:TextBox Runat="server" ID="txtDataInicial" MaxLength='10' AutoPostBack="false" />
                </div> 
                <div class='FiltroItem' runat='server' id='divDataFinal' style="padding-left:5px;">
                    Até
                    <asp:RequiredFieldValidator Runat="server" ID="valReqFinal" ControlToValidate='txtDataFinal' ErrorMessage='A data final é obrigatória' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID="varCompFinal" ControlToValidate='txtDataFinal' ErrorMessage='Data final inválida' Display="None" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
                    <asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Intervalo de datas inválido' Display="None" CssClass="TextDefault" Type="Date" Operator="GreaterThanEqual" ControlToCompare='txtDataInicial' />
                    <cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataFinal" Format="dd/MM/yyyy" />
                    <br>
                    <asp:TextBox Runat="server" ID='txtDataFinal' MaxLength='10' AutoPostBack="false" />
                </div>
                <div class='FiltroItem' runat='server' id='divDias' visible='false' style="padding-left:5px;">
                    Dias sem pedido
                    <asp:RequiredFieldValidator Runat="server" ID="RequiredFieldValidator1" ControlToValidate='txtDias' ErrorMessage='O Campo Dias é obrigatório' Display="None" CssClass="TextDefault" />
                    <asp:CompareValidator Runat="server" ID="Comparevalidator3" ControlToValidate='txtDias' ErrorMessage='Valor incorreto' Display="None" CssClass="TextDefault" Type="Integer" Operator="DataTypeCheck"  />
                    <asp:CompareValidator Runat="server" ID="Comparevalidator2" ControlToValidate='txtDias' ErrorMessage='Valor incorreto' Display="None" CssClass="TextDefault" Type="Integer" ValueToCompare="0" Operator="GreaterThan"  />
                    <br>
                    <asp:TextBox Runat="server" ID='txtDias' MaxLength='4' />
                </div>
                <div class='FiltroItem' ID='divMapa' runat='server' style="width:270px;" visible='false'>
                    Exibir Mapa<br />
		            <asp:CheckBox runat='server' ID='chkMapa' />
                    <asp:label runat="server" ID="lblmapa" Class="ErrorLbl" Visible="false" Text="- Selecione um vendedor para exibir o mapa!" />
		        </div>
                <asp:label runat="server" ID="lblAlertDate" Class="ErrorLbl" Visible="false" Text="- Selecione um período inferior a 62 dias!" />
                <div class='FiltroBotao' style="padding-left:5px;">
                    <input runat='server' type='button' ID='btnExibir' Class="Botao" Value="Exibir" alt='Exibe o relatório selecionado' />
                    <input type='button' ID='btnImprimir' Value='Imprimir' Class='Botao' onclick='javascript:fncPrint()'  />
                </div>
                <div class='FiltroItem' runat='server' ID='divCatPesquisa' style="clear:left;" visible='false'>
                    Tipo da Pesquisa
                    <asp:DropDownList runat="server" AutoPostBack="true" ID="cboCatPesquisa" DataTextField="Categoria" DataValueField="IDCategoriaPesquisa" Width="175px"></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' ID='divCategoriaProd' style="clear:left;" visible='false'>
                    Categoria Produto
                    <asp:DropDownList AutoPostBack='true' runat='server' ID='cboCategoriaProd' DataTextField='Categoria' DataValueField='IDCategoria' Width="175px"></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' ID='divProduto' style="padding-left:5px;" visible='false'>
                    Produto
                    <asp:DropDownList runat='server' ID='cboProduto' DataTextField='Descricao' DataValueField='IDProduto' Width="240px"></asp:DropDownList>
                </div>             
                <div class='FiltroItem' ID='divEmbalagem' runat='server' visible='false' style="padding-left:5px;">
                    Embalagem<br />
		            <asp:DropDownList AutoPostBack='false' runat='server' ID='cboIdEmbalagem' DataTextField='Linha' DataValueField='IDLinha' Width="235px"></asp:DropDownList>
		        </div>
                <div class='FiltroItem' ID='divProdutoPesquisa' runat='server' visible='false' style="padding-left:5px;">
                    Embalagem <!--Produto da Pesquisa-->
                    <asp:DropDownList runat="server" ID="cboProdutoPesquisa" DataTextField="ProdutoPesquisa" DataValueField="IdProdutoPesquisa" Width="235px"></asp:DropDownList>
                </div>
                <div class='FiltroItem' runat='server' ID='divMarca' style="padding-left:5px;" visible='false'>
                    Marca
                    <asp:ListBox runat="server" ID="lstMarca" DataTextField="Marca" DataValueField="IDMarca" SelectionMode='Multiple' Width="250px"></asp:ListBox>
                </div> 
                 <div class='FiltroItem' runat='server' id='divModoExibicaoGrafico' style="padding-right:5px" visible="false">
                    Modo de Exibição
                    <br />
	                <asp:RadioButtonList runat="server" ID="rdlModoExibicaoGrafico" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Diário" Selected="True" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Mensal" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <input type='hidden' id='hidPage' runat='server' value='' />  
            </div>
            <asp:Literal ID="ltrMsgBox" Runat="server" />
            
            <script language="javascript" type="text/javascript">
                function SoNumeros()
                {
                    var carCode = event.keyCode;
                    if ((carCode < 48) || (carCode > 57))
                    { 
                        alert('- Por favor digite apenas números');
                        event.cancelBubble = true
                        event.returnValue = false;
                    }

                }

                function fncPrint() 
                {
                    var vURL = document.getElementById('<%=hidPage.ClientId %>').value;
                    var wn = window.open(vURL, 'ImprimirRelatorio', 'height=600, width=800, resizable=1, scrollbars=1, toolbar=1')
                }
                           

            </script>