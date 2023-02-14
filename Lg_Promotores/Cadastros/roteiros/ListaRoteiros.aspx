<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="ListaRoteiros.aspx.vb" Inherits="Pages.Cadastros.roteiros.ListaRoteiros" %>
<%@ Register Src="../../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register src="../../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <div class='FiltroItem'>UF<br>
            <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
        </div>
        <div class='FiltroItem'>Tipo de promotor<br>
            <asp:DropDownList runat='server' ID='cboTeste'>
	            <asp:ListItem value="-1">Todos</asp:ListItem>
	            <asp:ListItem value="0">Normal</asp:ListItem>
	            <asp:ListItem value="1">Teste</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:UpdatePanel runat='server' ID='updCoordenador'>
            <ContentTemplate>
                <div class='FiltroItem'>
                    <asp:Literal ID="ltrCoordenador" runat="server" Text='<%$Settings: caption, Promotor.FiltroCoordenador, "Coordenador" %>' /><br>
                    <asp:DropDownList runat="server" ID="cboIDCoordenador" DataTextField="Coordenador" DataValueField="IDCoordenador" AutoPostBack='true' />
                </div>
                <div class='FiltroItem'>
                    <asp:Literal ID="ltrLider" runat="server" Text='<%$Settings: caption, Promotor.FiltroLider, "Lider" %>' /><br>
                    <asp:DropDownList runat="server" ID="cboIDLider" DataTextField="Lider" DataValueField="IDLider" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class='FiltroItem'>Regiao<br>
            <asp:DropDownList runat="server" ID="cboIDRegiao" DataTextField="Regiao" DataValueField="IDRegiao" />
        </div>
        <div class='FiltroItem'>Status<br>
            <asp:DropDownList runat="server" ID="cboIdStatus" >
                <asp:ListItem Text="Todos" Value="3"></asp:ListItem>
                <asp:ListItem Text="Ativo" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Inativo" Value="0"></asp:ListItem>
                <asp:ListItem Text="Afastado" Value="2"></asp:ListItem>
            </asp:DropDownList>
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
					    <asp:TemplateField HeaderText="Promotor" SortExpression="Promotor">
					        <ItemTemplate>
					            <a href="promotor_roteiro.aspx?idpromotor=<%#Eval("IdPromotor")%>"><%#Eval("Promotor")%></a>
					        </ItemTemplate>
					    </asp:TemplateField>
						<asp:BoundField HeaderText='<%$Settings: caption, Promotor.FiltroCoordenador, "Coordenador" %>' DataField="Coordenador" SortExpression="Coordenador" />
						<asp:BoundField HeaderText='<%$Settings: caption, Promotor.FiltroLider, "Lider" %>' DataField="Lider" SortExpression="Lider" />
						<asp:BoundField HeaderText="Login" DataField="Login" SortExpression="Login" />
						<asp:BoundField HeaderText="CPF" DataField="CPF" SortExpression="CPF" />
						<asp:BoundField HeaderText="UF" DataField="UF" SortExpression="UF" />
						<asp:BoundField HeaderText="regi&atilde;o" DataField="Regiao" SortExpression="Regiao" />
						<asp:BoundField HeaderText="Tipo" DataField="Teste" SortExpression="Teste" />
                        <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" />
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; Promotores cadastradas!
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
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='listaroteiros.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Promotor.Exportar, false %>' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

