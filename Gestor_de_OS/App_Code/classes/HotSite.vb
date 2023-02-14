Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class HotSite
    Inherits DataClass

    Public ReadOnly Property ExibirHotSite() As Boolean
        Get
            'Dim blnShow As Boolean = False
            'If HttpContext.Current.Session("ExibirHotSite") Is Nothing Then
            '    blnShow = True
            'Else
            '    blnShow = HttpContext.Current.Session("ExibirHotSite")
            'End If
            'If blnShow Then
            '    Return ShowHotSite
            'End If
            'Return False
            Return ShowHotSite
        End Get
    End Property

    Public Sub HotSiteExibido()
        HttpContext.Current.Session("ExibirHotSite") = False
    End Sub


    Public Property ShowHotSite() As Boolean
        Get
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SQLPREFIXO & "SE_HOTSITE"

            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = Identity.IDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
            Return ExecuteScalar(cmd)
        End Get
        Set(ByVal value As Boolean)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SQLPREFIXO & "UP_HOTSITE"

            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = Identity.IDUsuario
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
            cmd.Parameters.Add("@VALUE", SqlDbType.Bit).Value = value

            ExecuteNonQuery(cmd)
        End Set
    End Property

    Public ReadOnly Property Logado() As Boolean
        Get
            Return Identity.Logado
        End Get
    End Property

    Public Function ShowScript() As String
        Dim strScript As New StringBuilder
        strScript.AppendLine("<script type=""text/JavaScript"">")
        strScript.AppendLine("<!--")
        strScript.AppendLine("var wh = window.open('../hotsite/default.aspx','hotsite_nextel','width=630,height=700,status=no,scrollbars=yes,toolbar=no,top=20,left=20');")
        'strScript.AppendLine("wh.focus();")
        'strScript.AppendLine("$(wh).focus(); ")
        strScript.AppendLine("-->")
        strScript.AppendLine("</script>")

        Return strScript.ToString
    End Function

End Class
