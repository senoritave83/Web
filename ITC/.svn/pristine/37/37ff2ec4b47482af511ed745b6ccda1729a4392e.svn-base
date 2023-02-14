
Imports System.Data.SqlClient

Public Class ProcessoAtualizacaoEncode

    Inherits XMWebPage
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Page.Request("ACAO") <> "ATUALIZAR" Then Exit Sub

        Dim xmc As New XMLConfig()
        Dim cn As New SqlConnection(xmc.GetValue("ConnectionString", "", False))
        Dim cn2 As New SqlConnection(xmc.GetValue("ConnectionString", "", False))
        cn.Open()
        cn2.Open()
        Dim cm As New SqlCommand("SP_SE_OBRAS", cn)
        Dim rd As SqlDataReader
        Dim strUPDATE As String = ""
        Dim intCodigo As Integer = 0

        rd = cm.ExecuteReader()
        Do While rd.Read()

            strUPDATE = "UPDATE TB_OBRAS_OBR SET "
            strUPDATE &= "CODIGOANTIGO='" & CStr(Server.HtmlDecode(rd("CodigoAntigo") & "")) & "', "
            strUPDATE &= "NRDAREVISAO=" & CLng(0 & Server.HtmlDecode(rd("NrDaRevisao"))) & ", "
            strUPDATE &= "PROJETO='" & CStr(Server.HtmlDecode(rd("Projeto") & "")) & "', "
            strUPDATE &= "AREACONSTRUIDA='" & CStr(Server.HtmlDecode(rd("AreaConstruida") & "")) & "', "
            strUPDATE &= "CAPACIDADEDEPRODUCAO='" & CStr(Server.HtmlDecode(rd("CapacidadeDeProducao") & "")) & "', "
            strUPDATE &= "MATERIAPRIMA='" & CStr(Server.HtmlDecode(rd("MateriaPrima") & "")) & "', "
            strUPDATE &= "ENDERECO='" & CStr(Server.HtmlDecode(rd("Endereco") & "")) & "', "
            strUPDATE &= "COMPLEMENTO='" & CStr(Server.HtmlDecode(rd("Complemento") & "")) & "', "
            strUPDATE &= "CEP='" & CStr(Server.HtmlDecode(rd("CEP") & "")) & "', "
            strUPDATE &= "CIDADE='" & CStr(Server.HtmlDecode(rd("Cidade") & "")) & "', "
            strUPDATE &= "DESCPROJ1='" & CStr(Server.HtmlDecode(rd("DescProj1") & "")) & "', "
            strUPDATE &= "INICIOTERMINO='" & CStr(Server.HtmlDecode(rd("InicioTermino") & "")) & "' "
            strUPDATE &= "WHERE CODIGO=" & CLng(0 & rd("Codigo"))
            Try
                intCodigo = CLng(0 & rd("Codigo"))
                cm = New SqlCommand(strUPDATE, cn2)
                cm.ExecuteNonQuery()
            Catch ex As Exception
                Response.Write("OBRAS - Erro no registro " & intCodigo & vbCrLf)
            End Try

        Loop

        rd.Close()

        cm = New SqlCommand("SP_SE_EMPRESAS", cn)
        rd = cm.ExecuteReader()

        Do While rd.Read()

            strUPDATE = "UPDATE TB_EMPRESAS_EMP SET "
            strUPDATE &= "FANTASIA='" & CStr(Server.HtmlDecode(rd("FANTASIA") & "")) & "', "
            strUPDATE &= "RAZAOSOCIAL='" & CStr(Server.HtmlDecode(rd("RAZAOSOCIAL"))) & "', "
            strUPDATE &= "ENDERECO='" & CStr(Server.HtmlDecode(rd("ENDERECO") & "")) & "', "
            strUPDATE &= "COMPLEMENTO='" & CStr(Server.HtmlDecode(rd("COMPLEMENTO") & "")) & "', "
            strUPDATE &= "CEP='" & CStr(Server.HtmlDecode(rd("CEP") & "")) & "', "
            strUPDATE &= "CIDADE='" & CStr(Server.HtmlDecode(rd("CIDADE") & "")) & "', "
            strUPDATE &= "CNPJ='" & CStr(Server.HtmlDecode(rd("CNPJ") & "")) & "', "
            strUPDATE &= "InscricaoEstadual='" & CStr(Server.HtmlDecode(rd("InscricaoEstadual") & "")) & "', "
            strUPDATE &= "InscricaoMunicipal='" & CStr(Server.HtmlDecode(rd("InscricaoMunicipal") & "")) & "', "
            strUPDATE &= "WebSite='" & CStr(Server.HtmlDecode(rd("WebSite") & "")) & "', "
            strUPDATE &= "EMail='" & CStr(Server.HtmlDecode(rd("EMail") & "")) & "' "
            strUPDATE &= "WHERE CODIGO=" & CLng(0 & rd("Codigo"))

            Try
                intCodigo = CLng(0 & rd("Codigo"))
                cm = New SqlCommand(strUPDATE, cn2)
                cm.ExecuteNonQuery()
            Catch ex As Exception
                Response.Write("EMPRESAS - Erro no registro " & intCodigo & vbCrLf)
            End Try

        Loop

        rd.Close()

        lblMensagem.Text = "ATUALIZAÇÃO TERMINADA COM SUCESSO !"

    End Sub

End Class
