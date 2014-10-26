Public Class pole
    Public x As String
    Public y As String

    Public Sub New(ByVal x, ByVal y)
        Me.x = x
        Me.y = y
    End Sub

End Class

Public Class pole_ruch
    Public xp
    Public yp
    Public xk
    Public yk

    Public Sub New(ByVal xp, ByVal yp, ByVal xk, ByVal yk)
        Me.xp = xp
        Me.yp = yp
        Me.xk = xk
        Me.yk = yk
    End Sub
End Class



