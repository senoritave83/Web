<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="recados.aspx.vb" Inherits="home_recados" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
			<table width="101%" cellpadding='0' cellspacing='0' style="background-color:white;">
                <tr class='Header1'> 
                    <td>
                        <strong>Recados Enviados</strong>
                    </td>
                </tr> 
                <tr> 
                    <td class='Linha1'><img src="../images/transpa.gif" height="1" alt="" /></td>
                </tr>                
                <tr valign="top">
					<td>                        
						<asp:DataList id="dtgGrid" BorderStyle="None" BorderWidth="0" Width="100%" Runat="server" CellPadding='0' CellSpacing='0'>
                            <ItemStyle CssClass="cinza1" />
						    <AlternatingItemStyle CssClass="cinza1" />
							<HeaderTemplate>						    
                            <table cellspacing="0" cellpadding="1" width="100%" border="0">
							    <tr class='Header2'>
								    <td width='100' style="border-radius:0px;">Enviado</td>
								    <td width='150' style="border-radius:0px;">Destinat&aacute;rio</td>
								    <td width='250' style="border-radius:0px;">Mensagem</td>
								    <td style="border-radius:0px;">Enviado por</td>
							    </tr>
							</HeaderTemplate>
							<ItemTemplate>
								<tr valign="top" align="left">
									<td width="100"><%#FormatDatetime(Databinder.Eval(Container.DataItem,"rec_Enviado_dtm"), 2)%></td>
									<td width="150"><%#Databinder.Eval(Container.DataItem,"rec_Destinatario_chr")%></td>
									<td width="250"><%#Databinder.Eval(Container.DataItem,"rec_Recado_chr")%></td>
									<td><%#Databinder.Eval(Container.DataItem,"usu_Usuario_chr")%></td>
								</tr>
							</ItemTemplate>
							<AlternatingItemTemplate>
								<tr valign="top" align="left">
									<td width="100"><%#FormatDatetime(Databinder.Eval(Container.DataItem,"rec_Enviado_dtm"), 2)%></td>
									<td width="150"><%#Databinder.Eval(Container.DataItem,"rec_Destinatario_chr")%></td>
									<td width="250"><%#Databinder.Eval(Container.DataItem,"rec_Recado_chr")%></td>
									<td><%#Databinder.Eval(Container.DataItem,"usu_Usuario_chr")%></td>
								</tr>
							</AlternatingItemTemplate>
							<FooterTemplate>
								</table>
							</FooterTemplate>
						</asp:DataList>
						<table width="100%" cellpadding="0" cellspacing="0">
							<tr align="right" class="Footer2">
								<td style="background-color:#fff;">
									<asp:LinkButton CommandName="Paginate" CommandArgument='0' OnCommand='rptGrid_ItemCommand' ID="lnkPrevious" Runat="server"  style="color:#766A62;">
									<img src="../images/buttons/btn_anterior.png"/>
									</asp:LinkButton>
									&nbsp;
									<asp:LinkButton CommandName="Paginate" CommandArgument='1' OnCommand='rptGrid_ItemCommand' ID="lnkNext" Runat="server" style="color:#766A62;">
									<img src="../images/buttons/btn_proxima.png"/>
									</asp:LinkButton>
								</td>
							</tr>
							<tr align="right" class="Footer2">
								<td>
									&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr valign="top">
					<td>
						<table cellpadding="1" width="100%" style=" padding-left:5px;">
							<tr valign="top">
								<td>
									<table width="100%" border="0" style= "background-color:#eeece7;">
										<tr>
											<td style="text-align:left;">
                                                <br />
                                                <font class="cinza1">Selecione o Respons&aacute;vel ou Grupo</font>
                                                <br />
												<asp:dropdownlist CssClass="formulario" id="cboDestinatario" runat="server" AutoPostBack="False"></asp:dropdownlist>
												<img src='../images/help.gif' alt='Respons&#65533;vel ou Grupo que ir&#65533; receber o Recado Digital' align="bottom" />
											</td>
										</tr>
										<tr valign="top" style="text-align:left;">
											<td style="height: 22px">
                                                <br />
                                                <asp:Label runat="server" ID="lblMessage1">Mensagem</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
											    <asp:textbox id="txtMensagem" CssClass="formulario" TextMode="MultiLine" Runat="server" Width="98%" Rows="8" onKeyDown='return checkSize();' onBlur='Trim();'></asp:textbox>
                                            </td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr class='Footer1' style="background-color:#d7d2cb;">
				    <td>
				        <table width='100%'>
						    <tr>
							    <td width='50%'>Caracteres dispon&iacute;veis: <i><span id='spSize'>300</span></i></td>
							    <td width='50%'>
                                    <i>Limite M&aacute;ximo: 300 caracteres.</i>
								    <asp:label id="lblMensagem" Runat="server" CssClass="cinza1" Visible="False">N&atilde;o foi poss&#65533;vel enviar o recado!</asp:label>
                                </td>
						    </tr>
					    </table>
				    </td>
				</tr>
			</table>
			<script type='text/javascript'>
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
				        txtMensagem.value = txtMensagem.value.substring(0, 300);
				    } 
				}				
            </script>
			<!-- FIM CONTE&#65533;DO -->

            <table width="100%" cellpadding="0" cellspacing="0">
				<tr>
					<td valign="top" align="right">
                        <br />
						<asp:ImageButton id="btnEnviar" Runat="server" ImageUrl="../images/buttons/btn_enviar.png" onmouseover="MM_swapImage('btnEnviar','','../images/bt_enviar2.gif',1)" onmouseout="MM_swapImgRestore()" ></asp:ImageButton>
					</td>					
				</tr>
			</table>
</asp:Content>

<asp:Content runat='server' ID='Content2' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current" style="border-bottom:none;"><a href="default.aspx">Lista de OS</a></dt>
    <dd><a href="exportar.aspx"'>Exportar</a></dd>
    <dd class="current"><asp:HyperLink ID="hplRecados" runat="server" NavigateUrl="recados.aspx?&">Recados</asp:HyperLink></dd>
    <dd class="last"><asp:HyperLink ID="hplResumo" runat="server" NavigateUrl="resumo.aspx?&">Resumo</asp:HyperLink></dd>
    </dl>
    <dt style="border-top:1px #D7D2CB solid;"><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt><a href="pasta.aspx">Pastas</a></dt>

</asp:Content>

<asp:Content runat='server' ID='Content3' ContentPlaceHolderID="Ajuda">
</asp:Content>