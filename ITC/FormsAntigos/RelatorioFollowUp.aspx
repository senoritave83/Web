<%@ Page Language="vb" AutoEventWireup="false" EnableViewState="false" Codebehind="RelatorioFollowUp.aspx.vb"  ValidateRequest="False" Inherits="ITC.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  MS_POSITIONING="GridLayout">
		<script>
			function breakeveryheader(tipo)
			{
				return true;
				if (!document.getElementById){
					alert("Verifique se seu navegador é Internet Explorer 5.0 ou superior")
					return
				}
				var thestyle=(tipo==1)? "always" : "auto";
				for (i=0; i<document.all.length; i++)
					document.getElementById("QUEBRADEPAGINA").style.pageBreakBefore=thestyle;
					document.all		
			}
		</script>
		<form id="Form1" method="post" runat="server">
			<asp:Literal EnableViewState="False" ID="CodigoHTML" Runat="server" Text=""></asp:Literal>
		</form>
	</body>
</HTML>
