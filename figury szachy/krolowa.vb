Public Class krolowa
    Inherits figura


    Public Sub New(ByVal x, ByVal y, ByVal kolor)
        MyBase.New(x, y, kolor)
        If Me.kolor = "white" Then Me.obraz = My.Resources.Resource1.queen_white
        If Me.kolor = "black" Then Me.obraz = My.Resources.Resource1.queen_black
    End Sub

    Public Sub wypelnij_siatke(ByVal szachownica)

        siatka.Clear()

        For i = Me.y + 1 To 8 Step 1
            If IsNothing(szachownica(Me.x, i)) Then
                siatka.Add(New pole(Me.x, i))
            Else
                If szachownica(Me.x, i).kolor <> Me.kolor Then
                    siatka.Add(New pole(Me.x, i))
                End If
                Exit For
            End If
        Next i

        For i = Me.y - 1 To 1 Step -1
            If IsNothing(szachownica(Me.x, i)) Then
                siatka.Add(New pole(Me.x, i))
            Else
                If szachownica(Me.x, i).kolor <> Me.kolor Then
                    siatka.Add(New pole(Me.x, i))
                End If
                Exit For
            End If
        Next i

        For i = Me.x + 1 To 8 Step 1
            If IsNothing(szachownica(i, Me.y)) Then
                siatka.Add(New pole(i, Me.y))
            Else
                If szachownica(i, Me.y).kolor <> Me.kolor Then
                    siatka.Add(New pole(i, Me.y))
                End If
                Exit For
            End If
        Next i

        For i = Me.x - 1 To 1 Step -1
            If IsNothing(szachownica(i, Me.y)) Then
                siatka.Add(New pole(i, Me.y))
            Else
                If szachownica(i, Me.y).kolor <> Me.kolor Then
                    siatka.Add(New pole(i, Me.y))
                End If
                Exit For
            End If
        Next i

        Dim j = Me.y

        For i = Me.x + 1 To 8 Step 1
            j += 1
            If j = 9 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                siatka.Add(New pole(i, j))
            Else
                If szachownica(i, j).kolor <> Me.kolor Then
                    siatka.Add(New pole(i, j))
                End If
                Exit For
            End If
        Next i

        j = Me.y

        For i = Me.x - 1 To 1 Step -1
            j -= 1
            If j = 0 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                siatka.Add(New pole(i, j))
            Else
                If szachownica(i, j).kolor <> Me.kolor Then
                    siatka.Add(New pole(i, j))
                End If
                Exit For
            End If
        Next i

        j = Me.y

        For i = Me.x + 1 To 8 Step 1
            j -= 1
            If j = 0 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                siatka.Add(New pole(i, j))
            Else
                If szachownica(i, j).kolor <> Me.kolor Then
                    siatka.Add(New pole(i, j))
                End If
                Exit For
            End If
        Next i

        j = Me.y

        For i = Me.x - 1 To 1 Step -1
            j += 1
            If j = 9 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                siatka.Add(New pole(i, j))
            Else
                If szachownica(i, j).kolor <> Me.kolor Then
                    siatka.Add(New pole(i, j))
                End If
                Exit For
            End If
        Next i
    End Sub

End Class
