<%@ page title="" language="VB" autoeventwireup="false" CodeFile="popup.aspx.vb"  inherits="hotsite_popup" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link rel="stylesheet" href="box_info_eol.css" type="text/css" />
<title>Informe EOL 2.0</title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scrManager"></asp:ScriptManager>
	    <div id="box" style="_heigth:500px">
	    <div id="topo_box"><span class="Título">Informe EOL 2.0</span></div>
	     <div id="box_info">
		    <p style="_margin-bottom:0px; margin-bottom:0px*">Olá,<br> 
		    você irá notar que o EOL 2.0 está com modificações desde seu último acesso.<br>
		    Pensando em melhor atendê-los, realizamos algumas alterações no sistema, tais como:<br>
		
		    <ul>
			    <li>Relatórios mais amigáveis;</li>
			    <li>Opção de exportar ou imprimir relatórios;</li>
			    <li>Opção de Prioridade para as OS;</li>
			    <li>Novas opções de filtros na página inicial;</li>
			    <li style="list-style:none;">Entre outras melhorias e ajustes.</li>
		    </ul>	
			
		    <p class="assinatura_1" style="margin /*\**/:0px;">Obrigado!
		        <br><span class="assinatura">EOL 2.0 - Nextel</span></br>
		    </p> 
            <p style="margin /*\**/:0px;">
            <asp:UpdatePanel runat="server" ID="updChkMostrar">
            <ContentTemplate>
                    <asp:CheckBox runat="server" id="chk_Mostrar" AutoPostBack="true" />
			        <a>Não exibir este pop up novamente.</a>
            </ContentTemplate>
            </asp:UpdatePanel>
            </p>
		    </p>
	     </div>
	    </div>
    </form>
</body>

</html>
