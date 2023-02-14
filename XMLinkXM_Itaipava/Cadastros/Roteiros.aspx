<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Roteiros.aspx.vb" Inherits="Pages.Cadastros.Roteiros" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript">
        function verificaSelecao(oSrc, args) {
            args.IsValid = false;
            $('input[id*="chkDias"]').each(function (i) {
                if (this.checked == true) {
                    args.IsValid = true;
                }
            });

            $('input[id*="rdpDias"]').each(function (i) {
                if (this.checked == true) {
                    args.IsValid = true;
                }
            });
        }
    /*
        function verificaSelecao(oSrc, args) {

            var iBox = 0; // our collection index
            var bChecked = false; // the switch to flip when we get a checked box

            var sCheckBoxID = args.Value;  //value in the textbox
            alert('Validando');
            while (document.getElementById(sCheckBoxID + iBox) && !bChecked) {

                // only stay in the loop while we have additional boxes but no checks yet
                if (document.getElementById(sCheckBoxID + iBox).checked) { bChecked = true; }

                iBox++;

            }

            args.IsValid = bChecked;

        }

        $(function() {
            function checkBoxClicked() {
                //Get the total of selected CheckBoxes
                var n1 = $("#list1 input:checked").length;
                var n2 = $("#list2 input:checked").length;
                //Set the value of the txtCheckbox control
                $("input:#txtCheckbox").val(n1 == 0 ? "" : n1);
                $("input:#txtCheckbox2").val(n2 == 0 ? "" : n2);
            }

            //intercept any check box click event inside the #list Div
            $("#list1 :checkbox").click(checkBoxClicked);
            $("#list2 :checkbox").click(checkBoxClicked);
        });
        */
    </script>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem' style="width:400px;">Data<br>
						<asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" />
						<asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
						<cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
                		<asp:ImageButton runat='server' ID='imgCalendarDataInicial' ImageUrl="~/imagens/Calendario.png" />
		        		at&eacute;
						<asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" />
						<cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataFinal" Format="dd/MM/yyyy" />
						<asp:CompareValidator runat='server'  ID='valCompDataFinal' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
                		<asp:ImageButton runat='server' ID='imgCalendarDataFinal' ImageUrl="~/imagens/Calendario.png" />
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
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='Data, IdVendedor'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
					    <asp:ButtonField ButtonType='Link' DataTextField='Data' DataTextFormatString='{0:d}' CommandName='Editar' HeaderText="Data" SortExpression="Data" />
						<asp:BoundField HeaderText="Dia da Semana" DataField="DiaSemana" SortExpression="" />
						<asp:BoundField HeaderText="Responsavel" DataField="Responsavel" SortExpression="Responsavel" />
                        <asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:TemplateField HeaderText="Excluir">
						    <ItemTemplate>
                                <asp:ImageButton ID="imgRot" runat='server' OnClientClick="return confirm('Deseja realmente excluir esse roteiro ?');" CommandName="Excluir" CommandArgument='<%# Eval("IdRoteiro") %>' ImageUrl="~/imagens/Excluir.gif" />
						    </ItemTemplate>
						</asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; Roteiros cadastrados para o periodo selecionado!
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
	</div>
	<asp:PlaceHolder runat='server' ID='plhAdicionar'>
	    <asp:UpdatePanel runat='server' ID='updEditar'>
	        <ContentTemplate>
	            <div id='divRoteiro'>
	                Data:
		            <asp:TextBox runat='server' ID='txtData' MaxLength="10" ValidationGroup='Adicionar' />
                    <asp:CompareValidator runat='server'  ID='CompareValidator1' Display='None' ErrorMessage='Data inv&aacute;lida' ControlToValidate='txtData' Operator='DataTypeCheck' Type='Date' />
		            <cc1:CalendarExtender  ID="CalendarExtender1" runat="server" TargetControlID="txtData" PopupPosition="Right" PopupButtonID="imgCalendarData" Format="dd/MM/yyyy" />
		            <asp:ImageButton runat='server' ID='imgCalendarData' ImageUrl="~/imagens/Calendario.png" />
                    <asp:RequiredFieldValidator Display="None" runat='server' ID='RequiredFieldValidator1' ErrorMessage='Por favor selecione a data do roteiro' Text='*' ControlToValidate='txtData' ValidationGroup='Adicionar'></asp:RequiredFieldValidator>
	                Vendedor:
		            <asp:DropDownList runat='server' ID='drpIdVendedor' DataTextField="Vendedor" DataValueField="IdVendedor" ValidationGroup='Adicionar'></asp:DropDownList>
		            <br /><br />
		            <span>Dia da Semana:</span>
                    <asp:RadioButtonList runat='server' ID='rdpDias' RepeatDirection='Horizontal' ValidationGroup='Adicionar'>
                        <asp:ListItem Value='1'>Segunda-Feira</asp:ListItem>
                        <asp:ListItem Value='2'>Ter&ccedil;a-Feira</asp:ListItem>
                        <asp:ListItem Value='4'>Quarta-Feira</asp:ListItem>
                        <asp:ListItem Value='8'>Quinta-Feira</asp:ListItem>
                        <asp:ListItem Value='16'>Sexta-Feira</asp:ListItem>
                        <asp:ListItem Value='32'>S&aacute;bado</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:CheckBoxList runat='server' ID='chkDias' RepeatDirection='Horizontal' ValidationGroup='Adicionar'>
                        <asp:ListItem Value='1'>Segunda-Feira</asp:ListItem>
                        <asp:ListItem Value='2'>Ter&ccedil;a-Feira</asp:ListItem>
                        <asp:ListItem Value='4'>Quarta-Feira</asp:ListItem>
                        <asp:ListItem Value='8'>Quinta-Feira</asp:ListItem>
                        <asp:ListItem Value='16'>Sexta-Feira</asp:ListItem>
                        <asp:ListItem Value='32'>S&aacute;bado</asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:CustomValidator
                        ID="RequiredFieldValidator3" 
                        Display="None" 
                        ErrorMessage="Selecione o dia da semana do roteiro"
                        runat="server" 
                        ValidationGroup="Adicionar" 
                        ClientValidationFunction="verificaSelecao" >*</asp:CustomValidator>
                    <asp:Button runat='server' ID='btnGravar' Text='Gravar' ValidationGroup='Adicionar'/>
                    <asp:ValidationSummary ID="ValidationSummary1" runat='server' ValidationGroup='Adicionar' />
	            </div>
	        </ContentTemplate>
	    </asp:UpdatePanel>
	</asp:PlaceHolder>
	
    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='../pedidos/default.aspx'" />
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

