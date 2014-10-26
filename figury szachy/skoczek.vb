Public Class skoczek
    Inherits figura

    Public Sub New(ByVal x, ByVal y, ByVal kolor)
        MyBase.New(x, y, kolor)
        'Me.obraz = "ikony_szachy\knight_" & Me.kolor & ".png"
        If Me.kolor = "white" Then Me.obraz = My.Resources.Resource1.knight_white
        If Me.kolor = "black" Then Me.obraz = My.Resources.Resource1.knight_black
    End Sub

    Public Sub wypelnij_siatke(ByVal szachownica)

        siatka.Clear()

        For Each i In {-1, 1}
            For Each j In {-2, 2}
                If Me.x + i >= 1 And Me.x + i <= 8 And Me.y + j >= 1 And Me.y + j <= 8 Then
                    If IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        siatka.Add(New pole(Me.x + i, Me.y + j))
                    Else
                        If szachownica(Me.x + i, Me.y + j).kolor <> Me.kolor Then
                            siatka.Add(New pole(Me.x + i, Me.y + j))
                        End If
                    End If
                End If
            Next
        Next

        For Each i In {-2, 2}
            For Each j In {-1, 1}
                If Me.x + i >= 1 And Me.x + i <= 8 And Me.y + j >= 1 And Me.y + j <= 8 Then
                    If IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        siatka.Add(New pole(Me.x + i, Me.y + j))
                    Else
                        If szachownica(Me.x + i, Me.y + j).kolor <> Me.kolor Then
                            siatka.Add(New pole(Me.x + i, Me.y + j))
                        End If
                    End If
                End If
            Next
        Next
    End Sub
End Class
