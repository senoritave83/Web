<%@ Page Language="vb" AutoEventWireup="false" EnableViewState="false" Codebehind="RelatorioEmpresas.aspx.vb"  ValidateRequest="False" Inherits="ITC.RelatorioEmpresas"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body MS_POSITIONING="GridLayout">
            <script language='javascript'>
            
                var bUnload = true;

                function xmRefresh() {
                    bUnload = false;
                    location.reload(true);
                }
                        			
	        </script>
	    <form id="Form1" method="post" runat="server">
			<asp:Literal ID="CodigoHTML" Runat="server" Text=""></asp:Literal>
		</form>
	</body>
</HTML>
