<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="MensagemDias.aspx.vb" Inherits="Pages.Cadastros.MensagemDias" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <div class='FiltroItem' style="width:200px">Periodo<br>
		        <asp:TextBox runat='server' ID='txtDataInicioInicial' MaxLength="10" Width='80px' />
		        <asp:CompareValidator runat='server'  ID='valCompDataInicioInicial' Display='None' ErrorMessage='DataInicio inicial inv&aacute;lida' ControlToValidate='txtDataInicioInicial' Operator='DataTypeCheck' Type='Date' />
		        at&eacute;
		        <asp:TextBox runat='server' ID='txtDataInicioFinal' MaxLength="10" Width='80px' />
		        <asp:CompareValidator runat='server'  ID='valCompDataInicioFinal' Display='None' ErrorMessage='DataInicio final inv&aacute;lida' ControlToValidate='txtDataInicioFinal' Operator='DataTypeCheck' Type='Date' />
        </div>
        <div class='FiltroItem'>Segmento<br>
            <asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
        </div>
        <div class='FiltroLetras'>
	        <uc2:Letras ID="Letras1" runat="server" />
        </div>
        <div class='FiltroBotao'>
            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
        </div>
    </div>	
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDMensagemDia" DataNavigateUrlFormatString="MensagemDia.aspx?IDMensagemDia={0}" DataTextField="Mensagem" HeaderText="Mensagem"  SortExpression="Mensagem" />
						<asp:BoundField HeaderText="Inicio" DataField="DataInicio" DataFormatString="{0:D}" SortExpression="DataInicio" />
						<asp:BoundField HeaderText="Fim" DataField="DataDim" DataFormatString="{0:D}" SortExpression="DataDim" />
						<asp:BoundField HeaderText="Segmento" DataField="Categoria" SortExpression="Categoria" />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; Mensagens com o filtro selecionado!
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
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='MensagemDia.aspx?idmensagemdia=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='MensagemDias.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Mensagem.Exportar, false %>' />
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

