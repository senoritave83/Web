<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ObrasBrasil.aspx.vb" Inherits="ITC.ObrasBrasil"%>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>::: ITC :::</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Menu.css" rel="stylesheet">
		<LINK href="ITC_STYLES.css" type="text/css" rel="stylesheet">
<style>
.p {font-size: 12px; font-family: verdana, arial, helvetica;}
.teste {font-size: 12px; font-family: verdana, arial, helvetica;}
</style>
  </HEAD>
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top2.ascx" %>
			<table cellSpacing="0" cellpadding=0 width="100%" border="0"><tr><td><uc1:top2 id="top" runat="server"></uc1:top2></td></tr></table>
			<table id="Table1" borderColor="#F1F1F1" cellpadding=0 cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#F1F1F1"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle">

						<table width="100%" border="0">
							<tr>
								<td vAlign="top" align="middle">&nbsp;</td>
								<td width="95%" vAlign="top">
									<p style="TEXT-ALIGN:center"> &nbsp; <br>
										<strong> StopBank: a dire��o certa em estacionamentos </strong>
									</p>									
									<p style="TEXT-ALIGN:justify"> <img src="imagens/stopbank01.jpg" align="left">
										A StopBank � especializada na gest�o de estacionamentos para empresas privadas e oferece solu��es em gest�o operacional e administrativa de garagens.
									</p>
									<p style="TEXT-ALIGN:justify">
										A StopBank Estacionamentos atua desde 1996 na gest�o de estacionamentos e est� comprometida a garantir alto padr�o de qualidade de servi�o para seus clientes.
									</p>
									<p style="text-align:justify">
										Consiste na parceria com o cliente, em oferecer solu��es em gest�o operacional e administrativa das garagens e principalmente na expressiva rentabilidade e baixo custo operacional para o locador.
									</p>
									<p style="text-align:justify"> <img src="imagens/stopbank02.jpg" align="right">
										O trabalho da StopBank conta com m�o-de-obra treinada para atendimento dos usu�rios, consultoria e projeto para o melhor aproveitamento dos espa�os e acessos, melhorando a circula��o de ve�culos nos p�tios.
									</p>
									<p style="text-align:justify">
										A empresa atua tamb�m em parceria com fabricantes e importadores de equipamentos de automa��o e informatiza��o, aconselhando ao cliente quais os produtos mais indicados em cada situa��o. Na �rea de projetos, a StopBank tem parceria com um escrit�rio de arquitetura voltado a trabalhos exclusivos de estacionamentos h� quase 20 anos.
									</p>
									<p style="TEXT-ALIGN:left">
										Acesse: <a href="http://www.stopbank.com.br"><b>www.stopbank.com.br</b></a>. <br>&nbsp;
									</p>
								</td>
								<td vAlign="top" align="middle">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodap�1" runat="server"></uc1:rodape></form>
	</body>
</HTML>