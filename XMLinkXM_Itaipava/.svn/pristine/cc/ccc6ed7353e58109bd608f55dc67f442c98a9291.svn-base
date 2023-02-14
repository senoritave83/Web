<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" title="XM XMLink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div align="center" id="divLogin">
    	<asp:Login ID="Login1" runat="server">
			<LabelStyle/>
		</asp:Login>
		<div id="divMensagens">   	
			<div id="fdo_msg">
				<asp:Repeater runat='server' id='rptMensagens'>
			        <ItemTemplate>
			                <h4><%#Eval("Titulo")%></h4>
			                <div id="data">
			               	 <%#Eval("Data")%>
			                </div>
			                <div style="clear:both; font-size:1px; height:1px;">&nbsp;</div>
			                	<div id="msg">
					               <p><%#Eval("Mensagem")%></p> 			                
			                	</div>
			            </ItemTemplate>
			    </asp:Repeater>
			</div>
		</div>
    </div>
</asp:Content>

