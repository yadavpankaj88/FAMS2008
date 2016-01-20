Public Class ComboBoxHelper

    Dim _Text, _Value As String

    Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal Value As String)
            _Text = Value
        End Set
    End Property

    Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal Value As String)
            _Value = Value
        End Set
    End Property
End Class
