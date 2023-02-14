<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="etapas.aspx.vb" Inherits="configuracoes_Etapas" title="Gestor de O.S" %>
<%@ Register src="../include/xmcolor.ascx" tagname="xmcolor" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center">
    <tr class='Header1'> 
        <td>
            Etapas configuradas
        </td>
    </tr>
    <tr> 
        <td class='Linha1'>
            <img src="../images/transpa.gif" height="1" />
        </td>
    </tr>                
	<tr>
		<td>	
			<!-- INICIO CONTE&#65533;DO -->
			<table width="100%" border="0" cellspacing="0" cellpadding="2">
			    <tr class='Header2'>
			        <td style="width:10%;padding-left:10px;text-align:left;">N&uacute;mero</td>
					<td style="width:80%;padding-left:10px;text-align:left;">Etapa</td>
					<td>Cor</td>
			    </tr>
                <tr>
		            <asp:Repeater runat='server' ID='rptEtapas'>
			            <ItemTemplate>
			                <tr>
			                    <td style="text-align:center;" class="fdo_cinza">
                                    <%#Eval("IDEtapa")%>
                                </td>
			                    <td style="text-align:left;">
			                        <asp:TextBox runat='server' ID='txtEtapa' Text='<%#Eval("Etapa")%>' MaxLength='50' Width='90%'></asp:TextBox>
			                    </td>
			                    <td>
                                    <uc1:xmcolor id="clrEtapa" runat="server" Color='<%#Eval("Color") %>'></uc1:xmcolor>
                                </td>
			                </tr>
			            </ItemTemplate>
		            </asp:Repeater>			    
			    </tr>
			</table>
			<script type='text/javascript'>
			    function changeColor(vObject) {
			        var newwindow = null;
			        if (newwindow != null) {
			            newwindow.close();
			        }
			        newwindow = window.open('../include/getcolor.aspx?tn=1&cor=' + vObject.value + '&field=' + vObject.id, 'csel', 'width=230,height=250,resizable=no,statusbar=no;');
			        newwindow.focus();
			    }
			    function setCor(vColor, vField) {
			        eval('document.forms[0].' + vField + '.value = "' + vColor + '";');
			        eval(vField.replace('ColorName', 'ColorCell') + '.style.backgroundColor="' + vColor + '"');
			    }
			</script>
		</td>
	</tr>
    <tr class='Footer1'> 
        <td>
            <img width="1" height="25" src="../images/transpa.gif" alt="" />
        </td>
    </tr>							
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">    
	<asp:ImageButton runat='server' id='btnVoltar' CausesValidation="False" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar"></asp:ImageButton>
    <asp:ImageButton id="btnSalvar" Runat="server" ImageUrl="../images/buttons/btn_salvar.png"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>