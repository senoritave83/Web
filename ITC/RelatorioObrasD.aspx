<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RelatorioObrasD.aspx.vb" EnableViewState="false" ValidateRequest="False" Inherits="ITC.RelatorioEmpresaD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<!--API Google Maps para ITC
	<script tagmaps="LOCALHOST" src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAej965xw1l_plv6ITgkVwsBSMvkepoiJl53LGitqG4nkAo4BIehSBIAD9B7P_sG8t-qFKsWomC0Y_yA" type="text/javascript"></script>
	-->
	<script tagmaps="LOCALHOST"  src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAE29-yn7OYyuNeX4JF1bF4BRmPqHl7uXWU5xYPu41Ch2Zod2Z9RRAZVgcPkoHVXS9LaurG-KWbnO5rw" type="text/javascript"></script>
	
	<body MS_POSITIONING="GridLayout">

		<script language='javascript'>
		
			var countDiv = 0;
			
			function setDivCount(p_Value)
			{
				countDiv = p_Value;
			}
		
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
			
			function fncLoadPageBreak()
			{
			
				var j = 0, i = 0, y = 0;
				while(j < countDiv)
				{
					var e = document.getElementById('pHide' + j);
					i = i + (e.style.display != 'none' ? 1 : 0);
					j += 1;
				}
				j = 0;
				while(j < countDiv)
				{
					var e = document.getElementById('pHide' + j);
					//alert((e.style.display != 'none'));
					if (e.style.display != 'none')
					{
						//alert(y + ' - ' + (i -1));
						if( y < (i - 1))
							e.style.pageBreakAfter = 'always';
						else e.style.pageBreakAfter = '';
						y += 1;
					}
					else e.style.pageBreakAfter = '';
					//alert('Page Break ' + e.style.pageBreakAfter);
					j += 1;
				}
			
			}
			
			function fncXMHide(p)
			{
				
				obj = document.getElementById(p);
				//alert(obj.style.display);
				obj.style.display = 'none';
				//faz o loop através dos objetos da pagina para 
				//mudar o style das tag's
				
				fncLoadPageBreak();
				
			}

			/*
			var icon = new GIcon();
			icon.image = "http://labs.google.com/ridefinder/images/mm_20_red.png";
			icon.shadow = "http://labs.google.com/ridefinder/images/mm_20_shadow.png";
			icon.iconSize = new GSize(12, 20);
			icon.shadowSize = new GSize(22, 20);
			icon.iconAnchor = new GPoint(6, 20);
			icon.infoWindowAnchor = new GPoint(5, 1);
						
			function addAddressToMap(response, map) 
			{
				if (response && response.Status.code == 200) 
				{
				place = response.Placemark[0];
				point = new GLatLng(place.Point.coordinates[1],place.Point.coordinates[0]);
				marker = new GMarker(point, icon);
				map.addOverlay(marker);
				map.setCenter(new GLatLng(place.Point.coordinates[1],place.Point.coordinates[0]), 14);
				}
			}
			*/
			
			function openPopUp(url, name, features)
			{
				//alert(url);
				//return;
				var win = window.open(url, name, 'width=552, height=215, scrollbars=no, resizable=no')
			}
			
			
		</script>
		<form id="Form1" method="post" runat="server">
			<asp:Literal EnableViewState="False" ID="CodigoHTML" Runat="server" Text=""></asp:Literal>
		</form>
	</body>
</HTML>
