Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports XMSistemas.Web
Imports Classes

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://www.xmsistemas.com.br/xmpromotores/formulario")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class webservice_formulario
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Sub GravarXMLItem(ByVal vIdentifier As String, ByVal vIDProduto As Integer, ByVal vXML As String)
        Dim arrIdentifier() As String = Split(XMCrypto.Decrypt(vIdentifier), "_")
        Dim intIDVisita, intIDEmpresa, intIDUsuario As Integer

        intIDEmpresa = arrIdentifier(0)
        intIDUsuario = arrIdentifier(1)
        intIDVisita = arrIdentifier(2)

        Dim frm As New clsFormVisita.clsFormProduto
        frm.GravarPesquisa(intIDVisita, intIDUsuario, intIDEmpresa, vIDProduto, vXML)

    End Sub

    Public Sub GravarXMLEntidade(ByVal vIdentifier As String, ByVal vTipoEntidade As Integer, ByVal vIDReferencia As Integer, ByVal vXML As String)
        Dim arrIdentifier() As String = Split(XMCrypto.Decrypt(vIdentifier), "_")
        Dim intIDVisita, intIDEmpresa, intIDUsuario, intIDPesquisa As Integer

        intIDEmpresa = arrIdentifier(0)
        intIDUsuario = arrIdentifier(1)
        intIDVisita = arrIdentifier(2)
        intIDPesquisa = arrIdentifier(3)

        Dim frm As New clsFormVisita
        frm.GravarEntidadePesquisa(intIDVisita, intIDUsuario, intIDEmpresa, vTipoEntidade, vIDReferencia, intIDPesquisa, vXML)
    End Sub


End Class

