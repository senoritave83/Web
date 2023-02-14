<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ApresentacaoEmpresa.aspx.vb"  ValidateRequest="False" Inherits="ITC.ApresentacaoEmpresa"%>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top22.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>::: ITC :::</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="ITC_STYLES.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top22.ascx" %>
			<table cellSpacing="0" cellpadding=0 width="100%" border="0"><tr><td><uc1:top2 id="top" runat="server"></uc1:top2></td></tr></table>
			<table id="Table1" borderColor="#809eb7" cellpadding=0 cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#809eb7"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="center">
						<img src='imagens/tituloaempresa.jpg' border="0"><br>
						<table width="95%" align="left" border="0" align="center">
							<tr>
								<td vAlign="top" align="left" width="2%">&nbsp;
								</td>
								<td vAlign="top" align="left" width="98%">
									<p class="f10">O ITC oferece a seus associados uma consultoria de obras e empresas 
										eficiente e dinâmica.
									</p>
									<p class="f10">Acompanha há mais de 25 anos a evolução do setor da construção em 
										todo Brasil. Através de pesquisas de novos empreendimentos, o ITC divulga <b>diariamente</b>
										obras nos segmentos residencial, comercial e industrial, com amplo 
										detalhamento.
									</p>
									<p class="f10">O ITC conta com uma equipe treinada para obter os dados de acordo 
										com os segmentos de mercado oferecidos. São técnicos das áreas de engenharia, 
										edificações, administração e marketing, que fazem levantamentos de obras de 
										todas as regiões do país.
									</p>
									<p class="f10">As informações são obtidas através de:
										<br>
										<ul>
											<li class="f10">
											empresas de arquitetura, engenharia, consultoria e construtoras;
											<li class="f10">
											a mídia impressa e a internet são pontos de partida para algumas pesquisas;
											<li class="f10">
											os orgãos públicos em geral são grandes parceiros do ITC;
											<li class="f10">
												a pesquisa em campo é feita nas principais capitais do país.
											</li>
										</ul>
									<P></P>
									<p class="f10">Informamos a descrição completa da obra com estágio atual, 
										localização, cronograma, valores de investimento, área construída, cadastro de 
										empresas vinculadas as obras e executivos participantes.
									</p>
									<p class="f10">Com essas informações você formará um Banco de Dados exclusivo, com 
										rápido acesso e que permitirá fazer filtros específicos do seu interesse, ou 
										seja, será possível filtrar obras pelo estágio, endereço, empresa ou até mesmo 
										pela área construída. Você pode ainda emitir listagens resumidas de dados, 
										enviar mala direta, acompanhar o andamento dos contatos comerciais através do 
										follow-up e exportar os dados para o Excel.
									</p>
									<p class="f10">O acompanhamento da obra é feito desde sua entrada no Banco de Dados 
										até sua conclusão, com atualizações periódicas.
									</p>
									<p class="f10">
										O associado terá divulgação gratuita de seus produtos e serviços no Guia de 
										Fornecedores do ITC; terá dicas de como otimizar o uso do sistema - <b>ITC Dicas</b>; 
										e ainda um levantamento semestral dos dados divulgados
									</p>
									<p class="f10">
										O acompanhamento do suporte técnico e do DAC (Departamento de Atendimento ao 
										Cliente) são permanentes e podem auxiliá-lo sempre.
									</p>
									<p class="f10">
										Para mais informações ou sugestões sobre o ITC, entre em contato conosco pelo 
										e-mail <a href="mailto:itc@itc.etc.br" class="f10">itc@itc.etc.br</a> ou pelo 
										telefone (11)3825-7511.
									</p>
									<p class="f10">
										<STRONG>Rua Conselheiro Brotero, 589 - Sobreloja 02<br>
											Barra Funda - São Paulo - SP<br>
											Cep: 01154-001<br>
											Site: www.itc.etc.br<br>
											E-mail: itc@itc.etc.br<br>
											Telefone/Fax: (11)3825-7511 </STRONG>
									</p>
									<br>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
