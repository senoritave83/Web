<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="resumo.aspx.vb" Inherits="home_resumo" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width='100%' style="background-color:white;">
        <tr class='Header1'> 
            <td>Resumo</td>
        </tr> 
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>
		<tr valign="top">
			<td>
				<asp:DataGrid ShowHeader='true' Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False" CssClass="GridView" Height="91px">
					<HeaderStyle CssClass='Header2' />
					<ItemStyle CssClass="Rows1" HorizontalAlign="Left" />
					<AlternatingItemStyle CssClass="Rows2" HorizontalAlign="Left" />
					<Columns>
						<asp:BoundColumn ItemStyle-Width='100' DataField='Total' HeaderText='Total' >
<ItemStyle Height="20" Width="100px"></ItemStyle>
						</asp:boundcolumn>
						<asp:BoundColumn ItemStyle-Width='150' DataField='Status' HeaderText='Status' >
<ItemStyle Width="150px"></ItemStyle>
						</asp:boundcolumn>
					</Columns>
				</asp:DataGrid>
			</td>
		</tr>
        <tr class='Footer1'> 
            <td>&nbsp;<asp:Label Runat="server" id='lblMessage' CssClass="cinza1" /></td>
        </tr>
	</table>            
	<!-- FIM CONTE&#65533;DO -->
</asp:Content>


<asp:Content runat='server' ID='Content2' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current" style="border-bottom:none;"><a href="default.aspx">Lista de OS</a></dt>    
    <dd><a href="exportar.aspx">Exportar</a></dd>
    <dd><asp:HyperLink ID="hplRecados" runat="server" NavigateUrl="recados.aspx?&">Recados</asp:HyperLink></dd>
    <dd class="current last"><asp:HyperLink ID="hplResumo" runat="server" NavigateUrl="resumo.aspx?&">Resumo</asp:HyperLink></dd>
    </dl>
    <dt style="border-top:1px #D7D2CB solid;"><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt><a href="pasta.aspx">Pastas</a></dt>
    
</asp:Content>

