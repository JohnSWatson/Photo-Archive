' class to hold the goodies
Friend Class ShellInfo
    Public Property Name As String
    Public Property Value As String

    Public Sub New(n As String, v As String)
        Name = n
        Value = v
    End Sub

    Public Overrides Function ToString() As String
        Return Name

    End Function
End Class
