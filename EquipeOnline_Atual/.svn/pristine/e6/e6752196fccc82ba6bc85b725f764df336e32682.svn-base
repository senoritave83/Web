<%@ Page Language="VB" MasterPageFile="../ajuda.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="ajuda_Default" title="Equipe Online" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<asp:ScriptManager runat='server' ID='ScriptManager1'></asp:ScriptManager>
<asp:XmlDataSource ID="XmlDataSource1" Runat="server" DataFile="~/ajuda/ajuda.xml">
</asp:XmlDataSource>
<asp:UpdatePanel runat='server' ID='updAjuda'>
	<ContentTemplate>
		<table width="101%" align="center" bgcolor="#a09d96;" >
            <tr>
                <td style="border:5px solid #a09d96;width:200px;height:15px;background-color:#a09d96;">
                </td>
                <td rowspan="2" class="help" style="vertical-align:middle;">
                    <iframe style="border:none" runat='server' id='frmHelp' frameborder="1" width="100%" height="527px">
					</iframe>
                </td>
            </tr>
            <tr>                    
                <td class="help" style="width: 200px">
                    <asp:TreeView ID="TreeView1" EnableClientScript='true' runat="server" ImageSet="Simple" NodeIndent="10" ExpandDepth='1' DataSourceID='XmlDataSource1' ShowLines="True">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" HorizontalPadding="0px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                        <DataBindings>
                            <asp:TreeNodeBinding  DataMember="help" ValueField="ID" TextField="Name" />
                        </DataBindings>
                    </asp:TreeView>
                </td>
			</tr>                
		</table>
	</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton Runat="server" id="btnVoltar" AlternateText="Voltar" ImageUrl="../images/buttons/btn_voltar.png" runat="server" BorderWidth="0" CausesValidation="false" CssClass="botao_voltar_ajuda"></asp:ImageButton>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

