Imports Microsoft.VisualBasic
Imports System.Web.Compilation
Imports System.CodeDom
Imports System.Configuration.ConfigurationManager
Imports System.Xml


<ExpressionPrefix("Settings")> _
Public Class SettingsExpression
    Inherits ExpressionBuilder

    Public Structure stRequired
        Public Atributo As String
        Public Entidade As String
        Public DefaultValue As Boolean
    End Structure

    Public Overrides Function GetCodeExpression(ByVal entry As System.Web.UI.BoundPropertyEntry, ByVal parsedData As Object, ByVal context As System.Web.Compilation.ExpressionBuilderContext) As System.CodeDom.CodeExpression

        Dim strProperty As String = "Empty"
        Dim blnDefault As Boolean = False
        Dim strAtributo As String = "empty"

        If TypeOf (parsedData) Is stRequired Then
            With CType(parsedData, stRequired)
                strProperty = .Entidade
                blnDefault = .DefaultValue
                strAtributo = .Atributo
            End With
        End If

        Dim att As CodePrimitiveExpression = New CodePrimitiveExpression(strAtributo)
        Dim prim As CodePrimitiveExpression = New CodePrimitiveExpression(strProperty)
        Dim def As CodePrimitiveExpression = New CodePrimitiveExpression(blnDefault)
        Dim args() As CodeExpression = New CodeExpression(2) {att, prim, def}

        Dim refType As CodeTypeReferenceExpression
        refType = New CodeTypeReferenceExpression(Me.GetType())
        Return New CodeMethodInvokeExpression(refType, "GetProperty", args)

    End Function

    Public Overrides Function ParseExpression(ByVal expression As String, ByVal propertyType As System.Type, ByVal context As System.Web.Compilation.ExpressionBuilderContext) As Object
        Dim vArr() As String = Split(expression, ",")
        Dim st As stRequired
        st.Atributo = Trim(vArr(0))
        st.Entidade = Trim(vArr(1))
        st.DefaultValue = (Trim(vArr(2)).ToLower = "true")
        Return st
    End Function

    Public Shared Function GetProperty(ByVal vAtributo As String, ByVal vProperty As String, ByVal vDefault As Boolean) As Boolean


        Dim strValue As String = IIf(vDefault, "true", "")
        Dim strFileName As String = HttpContext.Current.Server.MapPath("~") & "\settings.xml"

        If IO.File.Exists(strFileName) Then
            Dim doc As New XmlDocument
            doc.Load(strFileName)
            Dim nd As XmlNode = doc.SelectSingleNode("/settings/" & Replace(vProperty, ".", "/"))
            If Not nd Is Nothing Then
                Dim at As XmlNode = nd.Attributes.GetNamedItem(vAtributo.ToLower)
                If Not at Is Nothing Then
                    strValue = at.Value
                End If
            End If
        End If
        Return (strValue.ToLower = "true")
    End Function

    Public Overrides Function EvaluateExpression(ByVal target As Object, ByVal entry As System.Web.UI.BoundPropertyEntry, ByVal parsedData As Object, ByVal context As System.Web.Compilation.ExpressionBuilderContext) As Object

        Dim strProperty As String = "Empty"
        Dim blnDefault As Boolean = False
        Dim strAtributo As String = "empty"

        If TypeOf (parsedData) Is stRequired Then
            With CType(parsedData, stRequired)
                strProperty = .Entidade
                blnDefault = .DefaultValue
                strAtributo = .Atributo
            End With
        End If

        Return GetProperty(strAtributo, strProperty, blnDefault)
    End Function

    Public Overrides ReadOnly Property SupportsEvaluate() As Boolean
        Get
            Return True
        End Get
    End Property

End Class
