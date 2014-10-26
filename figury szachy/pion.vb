Public Class pion
    Inherits figura

    Public Sub New(ByVal x, ByVal y, ByVal kolor)
        MyBase.New(x, y, kolor)
        Me.pierwszy_ruch = True
        'Me.obraz = "ikony_szachy\pawn_" & Me.kolor & ".png"
        If Me.kolor = "white" Then Me.obraz = My.Resources.Resource1.pawn_white
        If Me.kolor = "black" Then Me.obraz = My.Resources.Resource1.pawn_black
    End Sub
    Public Sub zmiana_pion(ByVal szachownica)
        If Me.kolor = "black" And Me.y = 1 Then
            szachy.a = Me.x
            szachy.b = Me.y
            szachy.c = Me.kolor
            Form2.Show()
            szachy.tura -= 1
        End If

        If Me.kolor = "white" And Me.y = 8 Then
            szachy.a = Me.x
            szachy.b = Me.y
            szachy.c = Me.kolor
            Form2.Show()
            szachy.tura -= 1
        End If
    End Sub

    Public Sub wypelnij_siatke(ByVal szachownica)

        siatka.Clear()
        If Me.x <= 7 And Me.y <= 7 Then
            If Me.kolor = "white" And IsNothing(szachownica(Me.x + 1, Me.y + 1)) = False Then
                If szachownica(Me.x + 1, Me.y + 1).kolor <> Me.kolor Then
                    siatka.Add(New pole(Me.x + 1, Me.y + 1))
                End If
            End If
        End If

        If Me.x <= 8 And Me.y <= 7 Then
            If Me.kolor = "white" And IsNothing(szachownica(Me.x - 1, Me.y + 1)) = False Then
                If szachownica(Me.x - 1, Me.y + 1).kolor <> Me.kolor Then
                    siatka.Add(New pole(Me.x - 1, Me.y + 1))
                End If
            End If
        End If

        If Me.x <= 7 Then
            If Me.kolor = "black" And IsNothing(szachownica(Me.x + 1, Me.y - 1)) = False Then
                If szachownica(Me.x + 1, Me.y - 1).kolor <> Me.kolor Then
                    siatka.Add(New pole(Me.x + 1, Me.y - 1))
                End If

            End If
        End If

        If Me.kolor = "black" And IsNothing(szachownica(Me.x - 1, Me.y - 1)) = False Then
            If szachownica(Me.x - 1, Me.y - 1).kolor <> Me.kolor Then
                siatka.Add(New pole(Me.x - 1, Me.y - 1))
            End If

        End If

        If Me.x <= 8 And Me.y <= 7 Then
            If Me.kolor = "white" And Me.y < 8 And IsNothing(szachownica(Me.x, Me.y + 1)) Then
                siatka.Add(New pole(Me.x, Me.y + 1))

                If Me.pierwszy_ruch = True And IsNothing(szachownica(Me.x, Me.y + 1)) Then
                    If IsNothing(szachownica(Me.x, Me.y + 2)) Then
                        siatka.Add(New pole(Me.x, Me.y + 2))
                    End If
                End If

            ElseIf Me.kolor = "black" And Me.y > 0 And IsNothing(szachownica(Me.x, Me.y - 1)) Then
                siatka.Add(New pole(Me.x, Me.y - 1))

                If Me.pierwszy_ruch = True And IsNothing(szachownica(Me.x, Me.y - 1)) Then
                    If IsNothing(szachownica(Me.x, Me.y - 2)) Then
                        siatka.Add(New pole(Me.x, Me.y - 2))
                    End If

                End If
            End If
        End If
        
    End Sub

End Class
