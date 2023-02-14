<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Fotos.aspx.vb" Inherits="Pages.Sistema.Fotos" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type="text/javascript">

        function rotate(obj) {

            obj.style.visibility = "hidden";
            var img = document.getElementById('imgfoto_' + obj.foto);

            $.ajax({
                type: "POST",
                url: "Fotos.aspx/GirarFoto",
                data: "{'name':'" + img.foto + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    var src = img.src + "?dt=" + ($.now());
                    img.src = "";
                    img.src = src;

                    setTimeout(function () {
                        obj.style.visibility = "visible";
                    }, 700);
                },
                error: function (msg) {
                    alert("Ocorreu um erro ao tentar editar a seguinte foto:\n" + foto + "!");
                    /*var response = jQuery.parseJSON(msg.responseText);
                    alert("Error!\n\nMessage: " + response.Message);*/
                    setTimeout(function () {
                        obj.style.visibility = "visible";
                    }, 700);
                }
            });
        }


        Sys.Application.add_load(bindEvents);
        function bindEvents() {
            $('.abrir-fotos').click(function () {
                $(this).parent().children('.album').slideToggle("fast");
            });
        }

        function popup(img) {
            var url = "Foto_popup.aspx?src=" + img.src;
            url = url + "&name=" + img.foto;
            window.open(url, "Foto", "width=700, height=530, scrollbars=NO, status=no, menubar=no, toolbar=no, titlebar=no, location=no");
        }
    </script>
    <asp:Literal ID='ltrAlert' runat="server" />
    <asp:UpdatePanel ID="updFiltro" runat="server">
        <ContentTemplate>
            <div class="Filtro">
	            <div class="FiltroItem" style="float:none;">
		            <label for="Filtrar por">Filtrar por:</label><br/>
		            <asp:TextBox Runat="server" ID='txtFiltro' MaxLength='40' Width="400" />
	            </div><br />
                <div class="FiltroItem" style="float:none; width:auto;">
                    <label>Data</label><br/>
			        <asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" />
			        <cc1:CalendarExtender  ID="cal_txtDataInicial" 
										        runat="server" 
										        TargetControlID="txtDataInicial"
										        PopupPosition="Right"
										        PopupButtonID="imgCalendarInicial"
										        Format="dd/MM/yyyy" 
										        />
							        <asp:ImageButton ID="imgCalendarInicial" runat="server" ImageUrl="~/imagens/Calendario.png" ImageAlign="Top" />
			        <asp:CompareValidator runat='server'  ID='valCompDataInicioInicial' Display='None' ErrorMessage='DataInicio inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
		            at&eacute;
			        <asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" />
			        <cc1:CalendarExtender ID="cal_txtDataFinal" 
										        runat="server" 
										        TargetControlID="txtDataFinal"
										        PopupPosition="Right"
										        PopupButtonID="imgCalendarFinal"
										        Format="dd/MM/yyyy"
										        Animated="true"
										        /><asp:ImageButton ID="imgCalendarFinal" runat="server" ImageUrl="~/imagens/Calendario.png" />
			        <asp:CompareValidator runat='server'  ID='valCompDataInicioFinal' Display='None' ErrorMessage='DataInicio final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
                    <asp:CustomValidator Enabled=false Display="Dynamic" runat="server" ID="customDatas" OnServerValidate="verificaDatas" ErrorMessage="O per�odo entre datas deve ser no m�ximo de 3 dias."></asp:CustomValidator><br/>
                </div><br />
	            <div class="FiltroItem" style="float:none;">
		            <label>Filtro Detalhado</label><br/>
                    <asp:DropDownList runat="server" ID="cboFiltroDetalhado" AutoPostBack="true" Width="150" >
                        <asp:ListItem Value="1">Cargo/Usu&aacute;rio</asp:ListItem>
                        <asp:ListItem Value="3">Revenda</asp:ListItem>
                        <asp:ListItem Value="4">Tipo de Foto</asp:ListItem>
                    </asp:DropDownList>
	            </div>	
	            <div class="filtro-fotos">
                    <table id="tblFiltros" runat="server">
                        <tr>
                            <td id="trBuscaRevenda" runat="server" visible="false">
                                <label for="Revenda">Revenda</label><br/>
			                    <asp:DropDownList ID="cboIDRevenda" Width="200"  runat="server" DataTextField="Fantasia" DataValueField="IDCliente" />
                            </td>                           
                            <td class="FiltroItem" id="trCargo" runat="server" visible="false">
                                 <label>Cargo</label><br/>
                                 <asp:DropDownList ID="cboIDCargos" Width="200"  runat="server" AutoPostBack='true' DataTextField="Cargo" DataValueField="IDCargo" />
                            </td>
                            <td class="FiltroItem" id="trUsuario" runat="server" visible="false">
                                 <label>Usu&aacute;rio</label><br/>
                                <asp:DropDownList ID="lstUsuarios" Width="200"  Rows="5" SelectionMode='Multiple' AutoPostBack='true' runat="server" DataTextField="Usuario" DataValueField="IDUsuario" ></asp:DropDownList>
                            </td>
                            <td class="FiltroItem" id="trTipoFoto" runat="server" visible="false">
                                 <label>Tipo de foto</Label><br/>
                                <asp:DropDownList ID="lstTipoEntidade" Width="200"  Rows="5" SelectionMode="Single" runat="server" DataTextField='Entidade' DataValueField='IDEntidade' ></asp:DropDownList>
                            </td>   
                        </tr>
                    </table>
		    	    <div class='FiltroBotao'>
					    <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				    </div>
                    <div>
                        
                    </div>
	            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdFotos" runat="server">
        <ContentTemplate>
	        <div class="container-fotos">

                <asp:Repeater ID='rptVisita' runat="server" >
	                <ItemTemplate>
		                <h2><%# Eval("Detalhes")%></h2>
		                <ul class="listas">	
			                <li class="fotos">

                                <asp:Repeater ID='rptTipoEntidade' runat="server" DataSource='<%# BindRepeaterTipoEntidade(Eval("IDVisita"))%>'>
	                                <ItemTemplate>
				                        <a class="abrir-fotos"><%# Eval("TipoFoto")%></a>
                                        <input type='checkbox' name='chkEntidade' value='<%# Eval("IDVisita")%>|<%# Eval("TipoEntidade")%>' />
					                    <ul class="album">

                                            <asp:Repeater ID='rptFoto' runat="server" DataSource='<%# BindRepeaterFotos(Eval("IDVisita"), Eval("TipoEntidade"))%>'>
	                                            <ItemTemplate>
						                            <li class="figure">
							                            <img id='imgfoto_<%# Eval("NomeFoto")%>' foto='<%# Eval("NomeFoto")%>' src="<%= ViewState("PhotoPath") %><%# Eval("NomeFoto") & "?dt=" & Now.ToString("ddMMyyyyhhmmsstt")%>" onclick="javascript:popup(this);" />
							                            <b class="letreiro"><%# Eval("NomeFoto")%></b>
							                            <input id='imgRotate' runat='server' type="button" foto='<%# Eval("NomeFoto")%>' onclick='rotate(this);' class="rotate" alt="Rotacionar" />
						                            </li>				
                                                </ItemTemplate>
                                            </asp:Repeater>

					                    </ul>
                                    </ItemTemplate>
                                </asp:Repeater>

			                </li>
		                </ul>
                    </ItemTemplate>
                </asp:Repeater>
                <xm:Paginate ID="Paginate1" runat="server" />
		        <div id='trDownload' runat="server" class="botoes">
			        <asp:Button id="btnDownload" runat='server' Text="Download" class="botao"/>                    
		        </div>
                <div >
                    <asp:Label ID='lblEmpytResult' runat='server' Text='N&atilde;o h&aacute; fotos para o filtro selecionado!' Visible='false' />
                </div>
	        </div>    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
            <asp:PostBackTrigger ControlID='btnDownload' />
        </Triggers>
    </asp:UpdatePanel>    
</asp:Content>

