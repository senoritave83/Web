<%@ Page Language="vb" autoeventwireup="false" validaterequest="False" %>
<%@ import Namespace="System.Data" %>
<%@ import Namespace="System.Web.Security" %>
<%@ import Namespace="System.Data.SqlClient" %>
<%@ import Namespace="System.Web.UI.WebControls.Label" %>
<%@ import Namespace="System.Web.UI.WebControls.TextBox" %>
<script runat="server">

    Sub Page_Load(sender As Object, e As EventArgs)
            If Not IsPostBack Then
            txtBuscaPrd.TabIndex = 4
            btnBuscaPrd.TabIndex = 5
            txtBuscaEmp.TabIndex = 6
            btnBuscaEmp.TabIndex = 7
            End If
    End Sub
    
         Dim sqldr As SqlDataReader
         Dim eita
         'função que exibe os produtos na lista'
          Private Function Produto()
    
              Dim sql
              sql="Select * from TB_PRODUTOS_PRD  where DESCRICAOPRODUTO like '%'+@Produto+'%' Order By DESCRICAOPRODUTO"
    
              Dim sConn As String
              Dim conn As SqlConnection
              Dim cmd As New SqlCommand
              'Dim dr As SqlDataReader
    
              sConn = ConfigurationSettings.AppSettings("ConnectionString")
              conn = New SqlConnection(sConn)
    
              cmd.Connection=conn
    
              cmd.Parameters.Clear()
              cmd.Parameters.Add(New SqlParameter("@Produto", SqlDbType.Varchar)).Value = txtBuscaPrd.Text
              cmd.CommandText = sql
              cmd.CommandType = CommandType.Text
    
              conn.Open()
    
              sqldr = cmd.ExecuteReader()
    
             If sqldr.HasRows Then
                 BindList() 'chama a função BindList() - Listar o BD'
             Else
                 Response.Redirect("guianenhum.aspx")
             End If
    
              sqldr.close()
              conn.close()
              conn.dispose()
    
              txtBuscaPrd.Text = ""
              txtBuscaEmp.Text = ""
    
          End Function
    
         Function BindList()
             dltProdutos.Datasource=sqldr
             dltProdutos.DataBind()
             lbllista.visible=true
             resultado.visible=true
         End Function 'BindList
    
         Sub BindList2()
             Dim sql
                 sql="SELECT * FROM TB_ASSOCIADOS_ASS LEFT JOIN TB_PRODUTOS_ASSOCIADOS_PAS ON TB_ASSOCIADOS_ASS.CODIGO=TB_PRODUTOS_ASSOCIADOS_PAS.IDASSOCIADO LEFT JOIN TB_CONTATOASSOCIADOS_CAS ON TB_ASSOCIADOS_ASS.CODIGO=TB_CONTATOASSOCIADOS_CAS.IDASSOCIADO LEFT JOIN TB_ESTADOS_EST ON TB_ASSOCIADOS_ASS.IDESTADO=TB_ESTADOS_EST.IDESTADO WHERE TB_PRODUTOS_ASSOCIADOS_PAS.IDPRODUTO=@EITA AND TB_ASSOCIADOS_ASS.IDSTATUS=1 AND TB_CONTATOASSOCIADOS_CAS.IDCARGO='125' OR TB_PRODUTOS_ASSOCIADOS_PAS.IDPRODUTO=@EITA AND TB_ASSOCIADOS_ASS.IDSTATUS=1 AND TB_CONTATOASSOCIADOS_CAS.IDCARGO='116' or TB_PRODUTOS_ASSOCIADOS_PAS.IDPRODUTO=@EITA AND TB_ASSOCIADOS_ASS.modulo='GUIA' AND TB_CONTATOASSOCIADOS_CAS.IDCARGO='125' OR TB_PRODUTOS_ASSOCIADOS_PAS.IDPRODUTO=@EITA AND TB_ASSOCIADOS_ASS.MODULO='GUIA' AND TB_CONTATOASSOCIADOS_CAS.IDCARGO='116' ORDER BY FANTASIA"
    
              Dim sConn As String
              Dim conn As SqlConnection
              Dim cmd As New SqlCommand
              Dim dr As SqlDataReader
    
              sConn = ConfigurationSettings.AppSettings("ConnectionString")
              conn = New SqlConnection(sConn)
    
              cmd.Connection=conn
    
              cmd.Parameters.Clear()
              cmd.Parameters.Add(New SqlParameter("@EITA", SqlDbType.Varchar)).Value = eita
              cmd.CommandText = sql
              cmd.CommandType = CommandType.Text
    
              conn.Open()
    
              dr = cmd.ExecuteReader()
    
              If dr.HasRows Then
                  dtlFornecedores.DataSource = dr
                  dtlFornecedores.DataBind()
                  volta.visible=True
                  fornecedor.visible=True
                  busca.visible=false
                  resultado.visible=false
                  lbllista.visible=false
                  lblempcad.visible=true
                  lblinfo.visible=false
              Else
                  Response.Redirect("guianenhum.aspx")
              End If
    
              dr.close()
              conn.close()
              conn.dispose()
    
         End Sub 'BindList2
    
         Sub dltProdutos_ItemCommand(sender As Object, e As DataListCommandEventArgs)
             'dltProdutos.SelectedIndex=e.Item.ItemIndex
             If e.CommandName="Teste" Then
                 eita=e.CommandArgument.ToString()
                 BindList2()
             End If
             'linha que traz o valor index do dataList'
             'label7.text=dltProdutos.SelectedIndex
         End Sub 'DataList_ItemCommand
    
          'função que traz as informações do bd'
          Private Function Empresa()
    
              Dim sql As String
              sql="Select * from TB_ASSOCIADOS_ASS left join TB_CONTATOASSOCIADOS_CAS on TB_ASSOCIADOS_ASS.CODIGO=TB_CONTATOASSOCIADOS_CAS.IDASSOCIADO left join TB_ESTADOS_EST on TB_ASSOCIADOS_ASS.idEstado=TB_ESTADOS_EST.idestado where TB_ASSOCIADOS_ASS.FANTASIA like '%'+@Empresa+'%' and TB_ASSOCIADOS_ASS.MODULO='GUIA' and TB_CONTATOASSOCIADOS_CAS.IDCARGO='125' or TB_ASSOCIADOS_ASS.FANTASIA like '%'+@Empresa+'%' and TB_ASSOCIADOS_ASS.MODULO='GUIA' and TB_CONTATOASSOCIADOS_CAS.IDCARGO='116' OR TB_ASSOCIADOS_ASS.FANTASIA like '%'+@Empresa+'%' and TB_ASSOCIADOS_ASS.idStatus=1 and TB_CONTATOASSOCIADOS_CAS.IDCARGO='125' or TB_ASSOCIADOS_ASS.FANTASIA like '%'+@Empresa+'%' and TB_ASSOCIADOS_ASS.idStatus=1 and TB_CONTATOASSOCIADOS_CAS.IDCARGO='116' Order By FANTASIA"
    
              Dim sConn As String
              Dim conn As SqlConnection
              Dim cmd As New SqlCommand
              Dim dr As SqlDataReader
    
              sConn = ConfigurationSettings.AppSettings("ConnectionString")
              conn = New SqlConnection(sConn)
    
              cmd.Connection=conn
    
              cmd.Parameters.Clear()
              cmd.Parameters.Add(New SqlParameter("@Empresa", SqlDbType.Varchar)).Value = txtBuscaEmp.Text
              cmd.CommandText = sql
              cmd.CommandType = CommandType.Text
    
              conn.Open()
    
              dr = cmd.ExecuteReader()
    
              If dr.HasRows Then
                  dtlFornecedores.DataSource = dr
                  dtlFornecedores.DataBind()
                  volta.visible=True
                  fornecedor.visible=True
                  busca.visible=false
                  resultado.visible=false
                  lblempcad.visible=true
                  lblinfo.visible=false
              Else
                  Response.Redirect("guianenhum.aspx")
              End If
    
              dr.close()
              conn.close()
              conn.dispose()
    
          End Function
    
          'sub acionada pelo click no botão Busca produto'
          Sub textodigitado(sender As Object, e As ImageClickEventArgs)
    
              Console.writeline(Produto)
    
          End Sub
    
         'sub acionada pelo click no botão busca empresa'
          Sub textodigitado1(sender As Object, e As ImageClickEventArgs)
    
              Console.WriteLine(Empresa)
    
          End Sub

</script>
<html>
<head>
    <link href="inc/ITC_Styles.css" type="text/css" rel="stylesheet" />
    <style>.caixa {
	BORDER-RIGHT: #000000 1px outset; BORDER-TOP: #000000 1px outset; FONT-WEIGHT: bold; FILTER: Alpha(Opacity=70, FinishOpacity=100, style=2, StartX=100, StartY=15, FinishX=100, FinishY=100); BORDER-LEFT: #000000 1px outset; BORDER-BOTTOM: #000000 1px outset; HEIGHT: 20px; BACKGROUND-COLOR: #ffcc66
}
.caixa1 {
	BORDER-RIGHT: #000000 1px outset; BORDER-TOP: #000000 1px outset; FONT-WEIGHT: bold; BORDER-LEFT: #000000 1px outset; BORDER-BOTTOM: #000000 1px outset; HEIGHT: 20px; BACKGROUND-COLOR: #ffffff
}
.caixa2 {
	BORDER-RIGHT: #000000 1px outset; BORDER-TOP: #000000 1px outset; FONT-WEIGHT: bold; BORDER-LEFT: #000000 1px outset; BORDER-BOTTOM: #000000 1px outset; HEIGHT: 20px; BACKGROUND-COLOR: #ffcc66
}
.botao {
	FONT-WEIGHT: bold; FONT-SIZE: 10px; FONT-FAMILY: Verdana; HEIGHT: 20px; BACKGROUND-COLOR: #fe7914
}
.texto {
	FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #000000; FONT-FAMILY: verdana
}
.texto1 {
	FONT-SIZE: 11px; COLOR: #000000; FONT-FAMILY: verdana
}
A {
	TEXT-DECORATION: none
}
A:hover {
	TEXT-DECORATION: underline
}
.letra1 {
	FONT-SIZE: 10px; FONT-FAMILY: verdana
}
.listaprd {
	BORDER-RIGHT: #000000 0px outset; PADDING-RIGHT: 0px; BORDER-TOP: #000000 0px outset; PADDING-LEFT: 0px; SCROLLBAR-FACE-COLOR: #ffcc66; FONT-WEIGHT: bold; FONT-SIZE: 12px; PADDING-BOTTOM: 0px; MARGIN: 0px; SCROLLBAR-HIGHLIGHT-COLOR: #ffaa44; BORDER-LEFT: #000000 0px outset; CURSOR: default; SCROLLBAR-SHADOW-COLOR: #ffaa44; COLOR: #000000; SCROLLBAR-3DLIGHT-COLOR: #ffcc66; SCROLLBAR-ARROW-COLOR: #ffffff; PADDING-TOP: 0px; SCROLLBAR-TRACK-COLOR: #ffaa44; BORDER-BOTTOM: #000000 0px outset; FONT-FAMILY: Verdana; SCROLLBAR-DARKSHADOW-COLOR: #ffcc66; BACKGROUND-COLOR: #ffffff
}
.barra1 {
scrollbar-face-color: #FF5E01;
scrollbar-highlight-color: #ffffff;
scrollbar-3dlight-color: #FE5F01;
scrollbar-darkshadow-color: #FE5F01;
scrollbar-shadow-color: #ffffff;
scrollbar-arrow-color: #FFFFFF;
scrollbar-track-color: #fed5bf;
}
</style>
    <script language="JavaScript">

	function foco() {
	visao.focus()
	}

</script>
</head>
<body onload="vertical();horizontal();"  bottommargin="0" leftmargin="0" topmargin="0" onload="foco()" rightmargin="0">
    <form id="frmGuiaFornecedor" method="post" runat="server">
        <table>
            <tbody>
                <tr>
                    <td id="visao">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
        <div id="info" style="FONT-SIZE: 10px; LEFT: 5px; FONT-FAMILY: verdana; POSITION: relative; TOP: 5px; align: left" align="center" runat="server" visible="true"><asp:Label id="lblinfo" runat="server" visible="true"> <font class="f10">Na
            busca abaixo você terá acesso fácil aos melhores produtos, fornecedores e prestadores
            de serviço do setor da construção. </font> </asp:Label><asp:Label id="lblempcad" runat="server" visible="false"> <font style="font-size: 13px; font-weight: bold; color: #000000;"> Empresas
            Cadastradas </font> </asp:Label>
        </div>
        <div id="volta" style="FONT-SIZE: 10px; LEFT: 5px; FONT-FAMILY: verdana; POSITION: absolute; TOP: 5px; align: left" align="left" runat="server" visible="false"><a href="buscadornovo.aspx"><font color="#0000ff"><b>&lt;&lt;
            NOVA PESQUISA </b></font></a>
        </div>
        <!-- O div abaixo apresenta o quadro de busca -->
        <div id="busca" style="MARGIN-TOP: 10px; FONT-SIZE: 12px; MARGIN-LEFT: 3px; FONT-FAMILY: verdana; POSITION: relative" align="center" runat="server" visible="true">
            <br />
            <br />
            <asp:Table id="principal12" style="BACKGROUND-REPEAT: no-repeat" runat="server" background="imagens/fundoguia.jpg" Cellpadding="0" border="0" cellspacing="0" width="401">
                <asp:TableRow>
                    <asp:TableCell colspan="3" width="401" height="4"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ROWSPAN="4" width="305" height="71" valign="top" align="center">
                        <div style="margin-top: 5px; margin-left: 85px;">
                            <asp:TextBox tabindex="0" runat="server" ID="txtBuscaPrd" size="26" Maxlength="30" style="height: 16px; border: 0; font-family: verdana;"></asp:TextBox>
                        </div>
                        <div style="margin-top: 17px; margin-left: 85px;">
                            <asp:TextBox tabindex="2" runat="server" ID="txtBuscaEmp" size="26" Maxlength="30" style="height: 16px; border: 0; font-family: verdana;"></asp:TextBox>
                        </div>
                    </asp:TAbleCell>
                    <asp:TableCell width="30" height="30">
                        <!-- <IMG SRC="images/Guia_03.jpg" WIDTH=30 HEIGHT=30 ALT="" style="cursor: hand;"> -->
                        <asp:ImageButton tabindex="1" runat="server" id="btnBuscaPrd" imageurl="imagens/Guia_03.jpg" alt="Busca produtos" onClick="textodigitado" />
                    </asp:TableCell>
                    <asp:TableCell ROWSPAN="4" width="66">
                        <!-- <IMG SRC="images/Guia_04.jpg" WIDTH=66 HEIGHT=71 ALT=""> -->
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell width="30" height="7">
                        <!-- <IMG SRC="imagens/Guia_05.jpg" WIDTH=30 HEIGHT=7 ALT=""> -->
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <!-- <IMG SRC="imagens/Guia_06.jpg" WIDTH=30 HEIGHT=30 ALT="botao2" style="cursor: hand;"> -->
                        <asp:ImageButton tabindex="3" runat="server" id="btnBuscaEmp" imageUrl="imagens/Guia_06.jpg" alt="Busca empresas" onClick="textodigitado1"></asp:ImageButton>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell width="30" height="4">
                        <!-- <IMG SRC="images/Guia_07.jpg" WIDTH=30 HEIGHT=4 ALT=""> -->
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <!-- Aqui é a lista de produtos que deverá aparecer com o clique no botão -->
        <div class="listaprd" id="resultado" style="MARGIN-TOP: 30px; FONT-SIZE: 12px; BACKGROUND: url(imagens/listaprd.jpg) no-repeat; MARGIN-LEFT: 120px; WIDTH: 350px; POSITION: relative; HEIGHT: 230px; text-family: verdana" align="left" runat="server" visible="false">
            <br />
            <asp:Label id="lbllista" runat="server" visible="false"><b>&nbsp;Selecione o produto
            desejado:</b> </asp:Label>
            <br />
            <br />
            <div class="barra1" id="insideresult" style="OVERFLOW: auto; WIDTH: 342px; HEIGHT: 168px">
                <asp:DataList id="dltProdutos" runat="server" OnItemCommand="dltProdutos_ItemCommand" RepeatDirection="vertical">
                    <ItemTemplate>
                        <asp:LinkButton align="center" runat="server" CommandName="Teste" CommandArgument='<%# Container.DataItem("IDPRODUTO") %>' id="button1" class="texto1"> &nbsp;<%# Container.DataItem("DESCRICAOPRODUTO") %>&nbsp; </asp:LinkButton>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <!-- Este é o div de Resposta. Traz as informações das empresas -->
        <div class="barra1" id="fornecedor" style="MARGIN-TOP: 25px; FONT-SIZE: 12px; MARGIN-LEFT: 8px; OVERFLOW: auto; WIDTH: 558px; POSITION: absolute; HEIGHT: 430px; text-family: verdana" align="left" runat="server" visible="false">
            <asp:DataList id="dtlFornecedores" style="OVERFLOW: auto" CssClass="f8" Runat="server">
                <ItemTemplate>
                    <table width="100%" bgcolor="000000" height="60" border="0" align="center" cellpadding="1" cellspacing="1">
                        <tr>
                            <td bgcolor="FFFFFF" width="100" align="center" height="76">
                                <img src="imagens/<%# iif(DataBinder.Eval(Container.DataItem, "ImagemGuia")= "", "sem_imagem.gif", DataBinder.Eval(Container.DataItem, "ImagemGuia"))%>"></td>
                            <td bgcolor="#FE5F01" width="500" valign="top">
                                <table width="100%" border="0" cellspacing="2" cellpadding="0" background="imagens/fundoemp.jpg" style="background-repeat: no-repeat;">
                                    <tr>
                                        <td class="f8" colspan="4">
                                            <b><%# Ucase(DataBinder.Eval(Container.DataItem, "Fantasia"))%></b></td>
                                    </tr>
                                    <tr>
                                        <td class="f8" colspan="4">
                                            Endereço:&nbsp;<%# Ucase(DataBinder.Eval(Container.DataItem, "Endereco"))%></td>
                                    </tr>
                                    <tr>
                                        <td class="f8" >
                                            Cidade:&nbsp; <%# Ucase(DataBinder.Eval(Container.DataItem, "Cidade"))%>
                                        </td>
                                        <td class="f8">
                                            UF: &nbsp;<%# DataBinder.Eval(Container.DataItem, "UF")%>
                                        </td>
                                        <td class="f8">
                                            Fone:&nbsp;(<%# Ucase(DataBinder.Eval(Container.DataItem, "DDD"))%>)&nbsp;<%# Ucase(DataBinder.Eval(Container.DataItem, "Telefone"))%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="f8" colspan="2">
                                            Site:&nbsp;<b><a href='<%# DataBinder.Eval(Container.DataItem, "WebSite")%>', target="_blank"><%# DataBinder.Eval(Container.DataItem, "WebSite")%></a></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="f8" colspan="3">
                                            E-Mail:&nbsp;<b><a href='mailto:<%# DataBinder.Eval(Container.DataItem, "EMAIL")%>'><%# DataBinder.Eval(Container.DataItem, "EMAIL")%></a></b></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
