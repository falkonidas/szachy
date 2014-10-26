Public Class pole
    Public x As String
    Public y As String

    Public Sub New(ByVal a, ByVal b)
        Me.x = a
        Me.y = b
    End Sub

End Class

Public Class pole_ruch
    Public xp
    Public yp
    Public xk
    Public yk

    Public Sub New(ByVal a, ByVal b, ByVal c, ByVal d)
        Me.xp = a
        Me.yp = b
        Me.xk = c
        Me.yk = d
    End Sub
End Class



