Namespace controls
    Partial Class ImageRotator
        Inherits System.Web.UI.UserControl
        Protected m_colImages As ImageCollection
        Protected m_strOnClientChange As String = ""
        Protected m_strOnClientClick As String = ""
        Protected m_intVelocity As Integer = 5000
        Protected m_blnPauseOver As Boolean = True
        Protected m_blnUseTransition As Boolean = True

        Public Property CssClass() As String
            Get
                Return pnlControle.CssClass
            End Get
            Set(ByVal value As String)
                pnlControle.CssClass = value
            End Set
        End Property

        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            If UBound(savedState) = 7 Then
                m_colImages = New ImageCollection
                m_colImages.LoadViewState(savedState(0))
                Width = savedState(1)
                Height = savedState(2)
                Velocity = savedState(3)
                PauseOver = savedState(4)
                UseTransition = savedState(5)
                onClientClick = savedState(6)
                onClientChange = savedState(7)
            End If
        End Sub

        Protected Overrides Function SaveViewState() As Object
            Dim obj(7) As Object
            obj(0) = m_colImages.SaveViewState()
            obj(1) = Width
            obj(2) = Height
            obj(3) = Velocity
            obj(4) = PauseOver
            obj(5) = UseTransition
            obj(6) = onClientClick
            obj(7) = onClientChange
            Return obj
        End Function


        Public ReadOnly Property Images() As ImageCollection
            Get
                Return m_colImages
            End Get
        End Property

        Public Property Width() As Unit
            Get
                Return pnlControle.Width
            End Get
            Set(ByVal value As Unit)
                pnlControle.Width = value
            End Set
        End Property

        Public Property Height() As Unit
            Get
                Return pnlControle.Height
            End Get
            Set(ByVal value As Unit)
                pnlControle.Height = value
            End Set
        End Property

        Public Property Velocity() As Integer
            Get
                Return m_intVelocity
            End Get
            Set(ByVal value As Integer)
                m_intVelocity = value
            End Set
        End Property

        Public Property PauseOver() As Boolean
            Get
                Return m_blnPauseOver
            End Get
            Set(ByVal value As Boolean)
                m_blnPauseOver = value
            End Set
        End Property


        Public Property UseTransition() As Boolean
            Get
                Return m_blnUseTransition
            End Get
            Set(ByVal value As Boolean)
                m_blnUseTransition = value
            End Set
        End Property


        Public Property onClientClick() As String
            Get
                Return m_strOnClientClick
            End Get
            Set(ByVal value As String)
                m_strOnClientClick = value
            End Set
        End Property


        Public Property onClientChange() As String
            Get
                Return m_strOnClientChange
            End Get
            Set(ByVal value As String)
                m_strOnClientChange = value
            End Set
        End Property


        Public Sub New()
            m_colImages = New ImageCollection
        End Sub

        Public Function GetRotatorID() As String
            Return img.ClientID
        End Function

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
            MyBase.OnPreRender(e)

            If Images.Count > 0 Then
                img.ImageUrl = Images(0).Value
            End If
            If onClientClick <> "" Then
                img.Attributes.Add("onClick", Me.onClientClick & "(this, new TRotatorEventArgs(this));")
            End If
            If onClientChange <> "" Then
                'img.Attributes.Add("onClick", Me.onClientClick & "(this, new TRotatorEventArgs(this));")
            End If

            ltrFunction.Text = Environment.NewLine & "RegisterRotator('" & img.ClientID & "', '" & Images.GetAllValues() & "', '" & Images.GetAllKeys() & "', " & Velocity & ", " & IIf(UseTransition, "true", "false") & ", " & IIf(PauseOver, "true", "false") & ", " & IIf(onClientChange = "", "null", onClientChange) & ");" & Environment.NewLine
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            ScriptManager.RegisterClientScriptInclude(Me.Page, Me.GetType(), "image_rotator", "../js/imagerotator.js")
        End Sub

        Public Class ImageCollection
            Inherits Generic.List(Of ImageItem)
            Implements IStateManager

            Private m_blnTrackViewState As Boolean = False

            Public Function GetAllValues() As String
                Dim strRet As String = ""
                For i As Integer = 0 To Me.Count - 1
                    If i > 0 Then strRet &= "|"
                    strRet &= Me.Item(i).Value
                Next
                Return strRet
            End Function

            Public Function GetAllKeys() As String
                Dim strRet As String = ""
                For i As Integer = 0 To Me.Count - 1
                    If i > 0 Then strRet &= "|"
                    strRet &= Me.Item(i).Key
                Next
                Return strRet
            End Function

            Public Sub LoadViewState(ByVal state As Object) Implements System.Web.UI.IStateManager.LoadViewState
                If UBound(state) = 1 Then
                    Dim strValues() As String = state(0).Split("|")
                    Dim strKeys() As String = state(1).Split("|")
                    Me.Clear()
                    For i As Integer = 0 To strValues.Length - 1
                        Me.Add(strKeys(i), strValues(i))
                    Next
                End If
            End Sub

            Public Overloads Sub Add(ByVal key As String, ByVal value As String)
                Dim it As New ImageItem(key, value, MyBase.Count)
                MyBase.Add(it)
            End Sub

            Public ReadOnly Property IsTrackingViewState() As Boolean Implements System.Web.UI.IStateManager.IsTrackingViewState
                Get
                    Return True
                End Get
            End Property

            Public Function SaveViewState() As Object Implements System.Web.UI.IStateManager.SaveViewState
                Dim obj(1) As Object
                obj(0) = GetAllValues()
                obj(1) = GetAllKeys()
                Return obj
            End Function

            Public Sub TrackViewState() Implements System.Web.UI.IStateManager.TrackViewState
                m_blnTrackViewState = True
            End Sub


            Public Class ImageItem
                Private m_strValue As String
                Private m_strKey As String
                Private m_intIndex As Integer

                Public ReadOnly Property Value() As String
                    Get
                        Return m_strValue
                    End Get
                End Property

                Public ReadOnly Property Key() As String
                    Get
                        Return m_strKey
                    End Get
                End Property

                Public Property Index() As Integer
                    Get
                        Return m_intIndex
                    End Get
                    Set(ByVal value As Integer)
                        m_intIndex = value
                    End Set
                End Property

                Public Sub New(ByVal key As String, ByVal value As String, ByVal index As Integer)
                    m_strValue = value
                    m_strKey = key
                    m_intIndex = index
                End Sub

            End Class

        End Class

    End Class


End Namespace
