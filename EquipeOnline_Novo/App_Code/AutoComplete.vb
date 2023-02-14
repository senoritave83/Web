Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

<WebService(Namespace:="http://xmsistemas.com.br/equipeonline/AutoComplete")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class AutoComplete
    Inherits System.Web.Services.WebService


    <WebMethod()> _
    Public Function GetClienteCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim cli As New clsClientes
        Dim dr As IDataReader = cli.Listar(prefixText, contextKey)
        Dim suggestions As New List(Of String)
        With dr
            Do While .Read
                suggestions.Add(.GetString(1))
            Loop
        End With
        Return suggestions.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetResponsaveisCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim rsp As New clsResponsaveis
        Dim dr As IDataReader = rsp.Listar(prefixText, contextKey)
        Dim suggestions As New List(Of String)
        With dr
            Do While .Read
                suggestions.Add(.GetString(1))
            Loop
        End With
        Return suggestions.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetDestinatariosCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim rsp As New clsResponsaveis
        Dim dr As IDataReader = rsp.ListarDestinatarios(prefixText, contextKey)
        Dim suggestions As New List(Of String)
        With dr
            Do While .Read
                suggestions.Add(.GetString(1))
            Loop
        End With
        Return suggestions.ToArray()
    End Function


End Class
