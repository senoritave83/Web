<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="pasta.aspx.vb" Inherits="home_pasta" title="Gestor de O.S" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
	<table width="101%" align="center">
        <tr class='Header1'> 
            <td>
                <input name="chkSel" onclick="selectAll(this.form.chkSelected, this.form.chkSel.checked);" title="Selecionar Todos" type="checkbox" /> 
                <strong>Selecionar Todas</strong>
            </td>
        </tr> 
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" alt=""/></td>
        </tr>
	    <tr>
		    <td>
				<asp:GridView BorderStyle="None" BorderWidth="0" Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass="GridView">					
					<HeaderStyle cssclass='barra_tit' />
					<Columns>
						<asp:TemplateField ItemStyle-Width="20">
							<ItemTemplate>
								<input type='checkbox' name='chkSelected' value='<%# Databinder.Eval(Container.DataItem,"ors_OrdemServico_int_PK")%>'/>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText='<%$Settings: Caption, Pasta.os, "#OS" %>' SortExpression='Numero' ItemStyle-Width="50" ItemStyle-HorizontalAlign="Left">
							<ItemTemplate>
								<%# Eval("ors_OrdemServico_chr")%>    
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField='cli_Cliente_chr' HeaderText='<%$Settings: Caption, Pasta.cliente, "Cliente" %>' SortExpression='Cliente' ItemStyle-HorizontalAlign="Left" />
						<asp:BoundField ItemStyle-Width='150' DataField='ors_Inclusao_dtm' HeaderText='<%$Settings: Caption, Pasta.Criado, "Criado em" %>' SortExpression='Inclusao'  ItemStyle-HorizontalAlign="Left" />
						<asp:TemplateField HeaderText='<%$Settings: Caption, Pasta.Responsaveis,"Responsaveis" %>'  ItemStyle-Width='150' SortExpression='Radio'  ItemStyle-HorizontalAlign="Left">
							<ItemTemplate>
								<%# Databinder.Eval(Container.DataItem,"rsp_Responsavel_chr") %>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
		    </td>
	    </tr>
        <tr>
            <td>
                <xm:Paginate ID="Paginate1" runat="server" />
            </td>
        </tr>
        <tr class="Footer1"> 
            <td style="color:#766A62; font-weight:normal;">
                Filtrar por:
            </td>
        </tr>							
	    <tr>            
	        <td align="left">
                <br />
                Mensagens armazenadas para: <asp:DropDownList cssClass='formulario' id="cboResponsavel" runat="server" AutoPostBack="True" DataValueField="IDResponsavel" DataTextField="Responsavel" />
            </td>            	    
	    </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr class="Footer2"> 
            <td>                
                <img width="1" height="25" src="../images/transpa.gif" alt="" />
            </td>
        </tr>							
    </table>    
</asp:Content>

<asp:Content runat='server' ID='Content3' ContentPlaceHolderID='Botoes'>        
	<asp:ImageButton id="btnApagar" runat="server" ImageUrl="../images/buttons/btn_apagar.png"></asp:ImageButton>
    <asp:ImageButton id="btnEnviar" runat="server" ImageUrl="../images/buttons/btn_enviar.png" CssClass="botao"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><a href="default.aspx">Lista de O.S.</a></dt>
    <dd><a href="#" onclick='fncExportar();'>Exportar</a></dd>
    <dd><asp:HyperLink ID="hplRecados" runat="server" NavigateUrl="recados.aspx?&">Recados</asp:HyperLink></dd>
    <dd class="last"><asp:HyperLink ID="hplResumo" runat="server" NavigateUrl="resumo.aspx?&">Resumo</asp:HyperLink></dd>
    <dt><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt class="current"><a href="pasta.aspx">Pastas</a></dt>
    </dl>
</asp:Content>


<asp:Content runat='server' ID='Content2' ContentPlaceHolderID='Ajuda'>   
	<b>Enviar:</b> Envie a(s) Ordem(ns) de Servi&ccedil;o criada(s) diretamente para o(s) respons&aacute;vel(eis) da sua equipe de campo.
    <br />
    &bull;<b>Obs:</b> Estas mensagens n&atilde;o est&atilde;o programadas para envio autom&aacute;tico.<br />
</asp:Content>

