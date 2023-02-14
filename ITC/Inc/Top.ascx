<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Top.ascx.vb" Inherits="ITC.Top" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<link href="../css/layout.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../css/calendar.css?random=20051112" media="screen"></link>



<script language="javascript">
function vertical() { 

   var navItems = document.getElementById("nav").getElementsByTagName("li"); 
        
   for (var i=0; i< navItems.length; i++) { 
          if(navItems[i].className == "submenu") { 
                 navItems[i].onmouseover=function() {this.getElementsByTagName('ul')[0].style.display="block";} 
                 navItems[i].onmouseout=function() {this.getElementsByTagName('ul')[0].style.display="none";} 
          } 
   } 

} 

function horizontal() { 

   var navItems = document.getElementById("barra").getElementsByTagName("li"); 
        
   for (var i=0; i< navItems.length; i++) { 
          if((navItems[i].className == "menuvertical") || (navItems[i].className == "submenu")) 
          { 
                 if(navItems[i].getElementsByTagName('ul')[0] != null) 
                 { 
                        navItems[i].onmouseover=function() {this.getElementsByTagName('ul')[0].style.display="block";} 
                        navItems[i].onmouseout=function() {this.getElementsByTagName('ul')[0].style.display="none";} 
                 } 
          } 
   } 

} 
</script>
<div id="Topo">
	<a href="home.aspx">
		<h1>ITC net</h1>
	</a>
	
	<!-- 
    
    <ul>
    	<li><a href="home.asp">Home</a></li>
      	<li><a href="cadastros.asp">Cadastros</a></li>
      	<li><a href="javascript:void(0);">Pesquisas</a>
        	<ul>
            	<li><a href="pesquisa_empresas.asp">Empresas</a></li>
                <li><a href="pesquisa_obras.asp">Obras</a></li>
            </ul>
        </li>
      	<li><a href="follow.asp">Follow-UP</a></li>
      	<li><a href="relatorios.asp">Relatórios</a></li>
      	<li><a href="default.asp">Sair</a></li>
  	</ul>
    
    -->
	
	<ul id="barra" class="menubar">
    	<li class="menuvertical">	<a href="../Home.aspx">Home</a></li>
	<%

	'Dim strHTML as string = ""
		
		
	If typeof me.Page is ITC.XMWebPage Then 
		
		Dim objUsuario as Object = CType(Page, ITC.XMWebPage).Usuario
		
		'******************************
		'MENU DE CADASTROS
		'******************************
		'<%
		If objUsuario.IdEmpresa = -1 Then
	%>
			<li class="menuvertical"><a href='javascript:void(0);'>Cadastros</a>
				<ul id="nav" class="menu">
			
	<%
			'strHTML = ""
			If objUsuario.TipoArea = ITC.Usuario.Tipo_Area.Empresa_Obra Or objUsuario.TipoArea = ITC.Usuario.Tipo_Area.Associado_Empresa_Obra Or objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.MASTER Then
			%>
					<li><a href='empresas.aspx'>Empresas</a></li>
					<li><a href='obras.aspx'>Obras</a></li>
			<%
				'strHTML &= "<li>"
				'strHTML &= "<a href='empresas.aspx'>Empresas</a></li>"
				'strHTML &= "<li class='menuvertical'>"
				'strHTML &= "<a href='obras.aspx'>Obras</a></li>"
			End If
			
            If objUsuario.TipoArea = ITC.Usuario.Tipo_Area.Associado Or objUsuario.TipoArea = ITC.Usuario.Tipo_Area.Associado_Empresa_Obra Or objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.MASTER Then
			%>
					<li><a href='associados.aspx'>Associados</a></li>
			<%
				'strHTML &= "<li>"
				'strHTML &= "<a href='associados.aspx'>Associados</a></li>"
            End If
			
			If objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.MASTER Then
			%>
					<li><a href='usuariossistema.aspx'>Usuários</a></li>
					<li><a href='produtos.aspx'>Produtos</a></li>
					<li><a href='saibamais.aspx'>Saiba Mais</a></li>
					<li><a href='dicas.aspx'>Dicas</a></li>
					<li><a href='analisemensal.aspx'>Análise Mensal</a></li>
			<%
				'strHTML &= "<li>"
				'strHTML &= "<a href='produtos.aspx'>Produtos</a></li>"
				'strHTML &= "<li>"
				'strHTML &= "<a href='saibamais.aspx'>Saiba Mais</a></li>"
				'strHTML &= "<li>"
				'strHTML &= "<a href='dicas.aspx'>Dicas</a></li>"
				'strHTML &= "<li>"
				'strHTML &= "<a href='analisemensal.aspx'>Análise Mensal</a></li>"
			end if
			'if strHTML <> "" Then
			%> 
				</ul>
		</li>
			<%
				'strHTML = "<li class="menuvertical"><a href='javascript:void(0);'>Cadastros</a><ul>" & strHTML & "</ul></li>"
			'end if
			'Response.Write(strHTML)
			
		 End If

		'******************************
		'MENU DE PESQUISAS
		'******************************
        If objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.VENDEDOR Or objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.USUARIO Then
			%>
			
			<li class="menuvertical"><a href='javascript:void(0);'>Pesquisas</a>
				<ul id="nav" class="menu"> 
					<li><a href='pesquisaempresas.aspx'>Empresas</a></li>
					<li><a href='pesquisaobras.aspx'>Obras</a></li>
					
					<%
					'If objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.VENDEDOR Then
					'>
					'	<li><a href='controleassociados.aspx'>Monitoramento de Associados</a></li>
					'	<li><a href='controleusuarios.aspx'>Monitoramento de Usuários</a></li>
					'<%
					'end if
					
					If objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.GESTOR OR objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.MASTER Then
					%>
						<li><a href='controleassociados.aspx'>Monitoramento de Associados</a></li>
						<li><a href='controleusuarios.aspx'>Monitoramento de Usuários</a></li>
					<%
					end if
					If objUsuario.IdEmpresa = -1 Then 
					%>
						<li><a href='controleassociados.aspx'>Monitoramento de Associados</a></li>
						<li><a href='controleusuarios.aspx'>Monitoramento de Usuários</a></li>
						<li><a href='controleassociadosacesso.aspx'>Controle de Associados</a></li>
					<%
					end if 	
					
				%>
				
					<!--Submenu Tabelas-->
					<li class="submenu"><a href='javascript:void(0);'>Tabelas</a>
						<ul>
							<li><a href='pesquisatabelasfases.aspx'>Fases/Estágios</a></li>
							<li><a href='pesquisattabelatipoobras.aspx'>Segmentos</a></li>
							<li><a href='pesquisatabelaatividadesempresa.aspx'>Atividades</a></li>
						</ul>
						<!--Fim do Submenu Tabelas-->
					</li>
				</ul>
				
			</li>
			
			<%
			
        ElseIf objUsuario.TipoUsuario =ITC.ITC_Global.TIPO_USUARIO.GESTOR Or CheckPermission("Pesquisas", "VISUALIZAR") Then
        
			%>
			
			<li class="menuvertical"><a href='javascript:void(0);'>Pesquisas</a>
				<ul id="nav" class="menu">
					<%
						If CheckPermission("Pesquisas de Empresas", "VISUALIZAR") Or objUsuario.TipoUsuario =ITC.ITC_Global.TIPO_USUARIO.GESTOR Then
						%>
							<li><a href='pesquisaempresas.aspx'>Empresas</a></li>
						<%
						End If
						If CheckPermission("Pesquisas de Obras", "VISUALIZAR") Or objUsuario.TipoUsuario =ITC.ITC_Global.TIPO_USUARIO.GESTOR Then
						%>
							<li><a href='pesquisaobras.aspx'>Obras</a></li>
						<%
						End If
						%>
						<!--li><a href='controleassociados.aspx'>Monitoramento de Associados</a></li-->
						<li><a href='controleusuarios.aspx'>Monitoramento de Usuários</a></li>
						<%
						If objUsuario.IdEmpresa = -1 Then
							If CheckPermission("Controle de Acesso de Associados", "VISUALIZAR") Then
							%>
								<li><a href='controleassociados.aspx'>Monitoramento de Associados</a></li>
								<li><a href='controleassociadosacesso.aspx'>Controle de Associados</a></li>
							<%
							End If
						End If
						%>
						<!--Submenu Tabelas-->
						<li class="submenu"><a href='javascript:void(0);'>Tabelas</a>
							<ul>
								<li><a href='pesquisatabelasfases.aspx'>Fases/Estágios</a></li>
								<li><a href='pesquisattabelatipoobras.aspx'>Segmentos</a></li>
								<li><a href='pesquisatabelaatividadesempresa.aspx'>Atividades</a></li>
							</ul>
							<!--Fim do Submenu Tabelas-->
						</li>
				</ul>
			</li>
			<%
		
		ElseIf objUsuario.TipoUsuario =ITC.ITC_Global.TIPO_USUARIO.MASTER Then
			%>
			<li class="menuvertical"><a href='javascript:void(0);'>Pesquisas</a>
				<ul id="nav" class="menu">
					<li><a href='pesquisaempresas.aspx'>Empresas</a></li>
					<li><a href='pesquisaobras.aspx'>Obras</a></li>
					<!--li><a href='controleassociados.aspx'>Monitoramento de Associados</a></li-->
					<li><a href='controleusuarios.aspx'>Monitoramento de Usuários</a></li>
				<%
				    If objUsuario.IdEmpresa = -1 Then
				        If CheckPermission("Controle de Acesso de Associados", "VISUALIZAR") Then
					%>
						<li><a href='controleassociadosacesso.aspx'>Controle de Associados</a></li>
					<%
					End If
				End If

				%>
					<!--Submenu Tabelas-->
					<li class="submenu"><a href='javascript:void(0);'>Tabelas</a>
						<ul>
							<li><a href='pesquisatabelasfases.aspx'>Fases/Estágios</a></li>
							<li><a href='pesquisattabelatipoobras.aspx'>Segmentos</a></li>
							<li><a href='pesquisatabelaatividadesempresa.aspx'>Atividades</a></li>
						</ul>
						<!--Fim do Submenu Tabelas-->
					</li>
				</ul>
			</li>
			<%
        End If
		
		'******************************
		'MENU DO SIG
		'******************************
		if objUsuario.TipoUsuario <> ITC.ITC_Global.TIPO_USUARIO.USUARIO then 
			%>
			<li class="menuvertical"><a href='javascript:void(0);'>SIG</a>
				<ul id="nav" class="menu"> 
					<li><a href='followupempresa.aspx'>Empresas</a></li>
					<li><a href='followupobra.aspx'>Obras</a></li>
					<%
						If objUsuario.IdEmpresa = -1 Then
							%>
								<li><a href='followupassoc.aspx'>Associados</a></li>
							<%
						End If
					%>
								
					<!--Submenu Atribuições-->
					<%
					if objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.GESTOR or objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.MASTER  then 
					%>
					<li class="submenu"><a href='javascript:void(0);'>Atribuições</a>
						<ul>
							<li><a href='ControleVendObr.aspx'>Obras</a></li>
							<li><a href='ControleVendEmp.aspx'>Empresas</a></li>
						</ul>
						<!--Fim do Submenu Atribuições-->
					</li>
					<%
					end if
					%>	
				</ul>
			</li>
			<%
		end if
		
		'******************************
		'MENU DE RELATÓRIOS
		'******************************
        If  objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.VENDEDOR Or _
			objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.GESTOR Or _
			objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.MASTER Then
			%>
			<li class="menuvertical"><a href='javascript:void(0);'>Relatórios</a>
				<ul id="nav" class="menu">
				<%
					If objUsuario.IdEmpresa = -1 Then
						%>
						<li><a href='RelFAss.aspx'>SIG Associados</a></li>
						<%
		            End If
		            %>
						<li><a href='RelFEmp.aspx'>SIG Empresas</a></li>
						<li><a href='RelFObr.aspx'>SIG Obras</a></li>
					<%
					If objUsuario.IdEmpresa = -1 Then
						%>
						<li><a href='pesquisaassociados.aspx'>Associados</a></li>
						<%
						if objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.GESTOR or objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.MASTER  then 
							%>
							<li><a href='logusuarios.aspx'>Log de Usuários</a></li>
							<%
						End If
					End If
					%>
				</ul>
			</li>
			<%

        ElseIf objUsuario.TipoUsuario = ITC.ITC_Global.TIPO_USUARIO.USUARIO And objUsuario.IdEmpresa = -1 Then
        
			%>
			<li class="menuvertical"><a href='javascript:void(0);'>Relatórios</a>
				<ul id="nav" class="menu">
					<li><a href='pesquisaassociados.aspx'>Associados</a></li>
				</ul>
			</li>
			<%
        End If

	end if
	%>
		<li class="menuvertical"><a href="Default2.aspx">Sair</a></li>
	</ul>
	<br class="clear" />
	<br class="clear" />
	<p class="FloatLeft"><asp:Label Runat="server" ID="lblData"></asp:Label></p>
	<p class="FloatRight"><asp:Label Runat="server" ID="lblUserData"></asp:Label></p>
	<br class="clear" />
	<br class="clear" />
</div>
