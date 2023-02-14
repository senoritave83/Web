<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="mensagens.aspx.vb" Inherits="configuracoes_mensagens" title="Gestor de O.S" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!-- INICIO CONTE&#65533;DO -->
	<table width="101%" align="center">
        <tr class='Header1'> 
            <td>
                <strong><input type='checkbox' name='chkSel' onclick='selectAll(this.form.chkSelected, this.form.chkSel.checked);' title='Selecionar Todas' />Selecionar Todas</strong>
            </td>
        </tr>
        <tr> 
            <td class='Linha1'>
                <img src="../images/transpa.gif" height="1" />
            </td>
        </tr>                
        <tr>
			<td>
				<asp:GridView Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass="GridView">
					<HeaderStyle CssClass='Header2' />
					<AlternatingRowStyle BackColor='#FFFFFF' HorizontalAlign="Left" />
					<RowStyle BackColor='#FFFFFF' HorizontalAlign="Left" />
					<Columns>
						<asp:TemplateField ItemStyle-Width="20">
							<ItemTemplate>
								<input type='checkbox' name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "msp_mensagemPadrao_int_PK")%>' />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Nome" ItemStyle-Width="310" ItemStyle-Height="20" SortExpression='Nome'>
							<ItemTemplate>
								<a href="mensagemdet.aspx?idmensagem=<%# DataBinder.Eval(Container.DataItem, "msp_mensagemPadrao_int_PK")%>" class="cinza1"><%# DataBinder.Eval(Container.DataItem, "msp_Nome_chr")%></a>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField='msp_MensagemPadrao_chr' HeaderText='Texto' SortExpression='Texto'></asp:BoundField>
					</Columns>
				</asp:GridView>
			</td>
		</tr>
        <tr>
            <td>
                <xm:Paginate ID="Paginate1" runat="server" CausesValidation='False' />
            </td>
        </tr>
        <tr class="Header2">
            <td>
                Adicionar mensagem.
            </td>
        </tr>
        <tr>
			<td height="150">
				<table width="100%" style="text-align:left;">
					<tr>
						<td class='cinza1' colspan="4" style="padding:10px 0px 10px 0px;"><span class="cinza3">Nome da Mensagem</span>
							<asp:RequiredFieldValidator Runat="server" ID='valNome' ControlToValidate="txtNome" ErrorMessage='*' />
							<br />
							<asp:TextBox Runat="server" ID='txtNome' CssClass="formulario" size="70" MaxLength="50" />
						</td>
					</tr>
					<tr>
						<td class='cinza1' colspan="4"><span class="cinza3">Texto</span>
							<asp:RequiredFieldValidator Runat="server" ID="valMensagem" ControlToValidate="txtMensagem" ErrorMessage='*' />
							<br />
							<asp:TextBox Runat="server" ID="txtMensagem" CssClass="formulario" TextMode="MultiLine"	cols="69" rows="3" onKeyDown='return checkSize();' onBlur='Trim();' />
                    </tr>
                    <tr>
                        <td style="padding:10px 0px 10px 0px;">
                            <font class="cinza1" >Caracteres dispon&iacute;veis: <span id='spSize'>300</span></font>
                        </td>
                    </tr>
					<tr> 
						<td class="cinza1" colspan="4">
                            <asp:ImageButton Runat="server" ID='btnNovo' onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('btnNovo','','../images/bt_adicionar_over.gif',1)" ImageUrl="../images/buttons/btn_add_secundario.png" ></asp:ImageButton>
                        </td>
					</tr>
				</table>
                <br />
			</td>
		</tr>
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" alt="" /></td>
        </tr>							
	</table>

	<script type="text/javascript">
		function checkSize()
			{
			var txtMensagem = document.getElementById('<%=txtMensagem.clientID%>')
			var i = txtMensagem.value.length;
			if (i < 300)
				{
				spSize.innerHTML = 300 - i;
				return true;
				}
			else
				{
				spSize.innerHTML = 0;
				if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 39  && event.keyCode != 38  && event.keyCode != 37  && event.keyCode != 40)
					return false;
				}
			}
		function Trim()
			{
            var txtMensagem = document.getElementById('<%=txtMensagem.clientID%>')
			if(txtMensagem.value.length > 300){
				txtMensagem.value = txtMensagem.value.substring(0, 300);}}
	</script>

</asp:Content>

<asp:Content runat='server' ID='Content2' ContentPlaceHolderID='Botoes'>    
	<asp:ImageButton CausesValidation=False runat="server" id="btnVoltar" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar" ></asp:ImageButton>
    <asp:imageButton Runat="server" ID="btnApagar" CausesValidation="False" ImageUrl="../images/buttons/btn_excluir.png" CssClass="botao_excluir"></asp:imageButton>
</asp:Content>
<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>

<asp:Content runat='server' ID='Content3' ContentPlaceHolderID="Ajuda">
	<b>Adicionar:</b> Adicione uma nova mensagem &agrave; lista de Mensagens Padr&atilde;o.
    <br />
	<b>Excluir:</b> Exclua uma ou mais mensagens selecionadas pelas caixas de sele&ccedil;&atilde;o.    
</asp:Content>

