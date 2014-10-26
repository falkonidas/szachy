Public Class krol
    Inherits figura


    Public Sub New(ByVal x, ByVal y, ByVal kolor)
        MyBase.New(x, y, kolor)
        If Me.kolor = "white" Then Me.obraz = My.Resources.Resource1.king_white
        If Me.kolor = "black" Then Me.obraz = My.Resources.Resource1.king_black

    End Sub

    Public Sub wypelnij_siatke(ByVal szachownica)

        siatka.Clear()

        For Each i In {-1, 1}
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

        For Each i In {0}
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

        For Each i In {-1, 1}
            For Each j In {0}
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

    Public Function czy_szach(ByVal szachownica)
        'szukanie wiez i krolowych

        Dim b As Boolean

        For i = Me.y + 1 To 8 Step 1
            If IsNothing(szachownica(Me.x, i)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(Me.x, i)) Then
                If szachownica(Me.x, i).kolor <> Me.kolor And (szachownica(Me.x, i).GetType() = GetType(wieza) Or szachownica(Me.x, i).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        For i = Me.y - 1 To 1 Step -1
            If IsNothing(szachownica(Me.x, i)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(Me.x, i)) Then
                If szachownica(Me.x, i).kolor <> Me.kolor And (szachownica(Me.x, i).GetType() = GetType(wieza) Or szachownica(Me.x, i).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        For i = Me.x + 1 To 8 Step 1
            If IsNothing(szachownica(i, Me.y)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(i, Me.y)) Then
                If szachownica(i, Me.y).kolor <> Me.kolor And (szachownica(i, Me.y).GetType() = GetType(wieza) Or szachownica(i, Me.y).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        For i = Me.x - 1 To 1 Step -1
            If IsNothing(szachownica(i, Me.y)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(i, Me.y)) Then
                If szachownica(i, Me.y).kolor <> Me.kolor And (szachownica(i, Me.y).GetType() = GetType(wieza) Or szachownica(i, Me.y).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        'szukanie goncow i krolowych
        Dim j = Me.y

        For i = Me.x + 1 To 8 Step 1
            j += 1
            If j = 9 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(i, j)) Then
                If szachownica(i, j).kolor <> Me.kolor And (szachownica(i, j).GetType() = GetType(goniec) Or szachownica(i, j).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        j = Me.y

        For i = Me.x - 1 To 1 Step -1
            j -= 1
            If j = 0 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(i, j)) Then
                If szachownica(i, j).kolor <> Me.kolor And (szachownica(i, j).GetType() = GetType(goniec) Or szachownica(i, j).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        j = Me.y

        For i = Me.x + 1 To 8 Step 1
            j -= 1
            If j = 0 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(i, j)) Then
                If szachownica(i, j).kolor <> Me.kolor And (szachownica(i, j).GetType() = GetType(goniec) Or szachownica(i, j).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        j = Me.y

        For i = Me.x - 1 To 1 Step -1
            j += 1
            If j = 9 Then Exit For
            If IsNothing(szachownica(i, j)) Then
                Continue For
            ElseIf Not IsNothing(szachownica(i, j)) Then
                If szachownica(i, j).kolor <> Me.kolor And (szachownica(i, j).GetType() = GetType(goniec) Or szachownica(i, j).GetType() = GetType(krolowa)) Then
                    b = True
                End If
                Exit For
            End If
        Next i

        'szukanie skoczków

        For Each i In {-1, 1}
            For Each j In {-2, 2}
                If Me.x + i >= 1 And Me.x + i <= 8 And Me.y + j >= 1 And Me.y + j <= 8 Then
                    If IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        Continue For
                    ElseIf Not IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        If szachownica(Me.x + i, Me.y + j).kolor <> Me.kolor And szachownica(Me.x + i, Me.y + j).GetType() = GetType(skoczek) Then
                            b = True
                        End If
                    End If
                End If
            Next
        Next

        For Each i In {-2, 2}
            For Each j In {-1, 1}
                If Me.x + i >= 1 And Me.x + i <= 8 And Me.y + j >= 1 And Me.y + j <= 8 Then
                    If IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        Continue For
                    ElseIf Not IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        If szachownica(Me.x + i, Me.y + j).kolor <> Me.kolor And szachownica(Me.x + i, Me.y + j).GetType() = GetType(skoczek) Then
                            b = True
                        End If
                    End If
                End If
            Next
        Next

        'szukanie kroli

        For Each i In {-1, 1}
            For Each j In {-1, 1}
                If Me.x + i >= 1 And Me.x + i <= 8 And Me.y + j >= 1 And Me.y + j <= 8 Then
                    If IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        Continue For
                    ElseIf Not IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        If szachownica(Me.x + i, Me.y + j).kolor <> Me.kolor And szachownica(Me.x + i, Me.y + j).GetType() = GetType(krol) Then
                            b = True
                        End If
                    End If
                End If
            Next
        Next

        For Each i In {0}
            For Each j In {-1, 1}
                If Me.x + i >= 1 And Me.x + i <= 8 And Me.y + j >= 1 And Me.y + j <= 8 Then
                    If IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        Continue For
                    ElseIf Not IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        If szachownica(Me.x + i, Me.y + j).kolor <> Me.kolor And szachownica(Me.x + i, Me.y + j).GetType() = GetType(krol) Then
                            b = True
                        End If
                    End If
                End If
            Next
        Next

        For Each i In {-1, 1}
            For Each j In {0}
                If Me.x + i >= 1 And Me.x + i <= 8 And Me.y + j >= 1 And Me.y + j <= 8 Then
                    If IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        Continue For
                    ElseIf Not IsNothing(szachownica(Me.x + i, Me.y + j)) Then
                        If szachownica(Me.x + i, Me.y + j).kolor <> Me.kolor And szachownica(Me.x + i, Me.y + j).GetType() = GetType(krol) Then
                            b = True
                        End If
                    End If
                End If
            Next
        Next

        'szukanie pionów

        If Me.x <= 7 And Me.y <= 7 Then
            If Me.kolor = "white" And IsNothing(szachownica(Me.x + 1, Me.y + 1)) = False Then
                If szachownica(Me.x + 1, Me.y + 1).kolor <> Me.kolor Then
                    b = True
                End If
            End If
        End If

        If Me.x <= 8 And Me.y <= 7 Then
            If Me.kolor = "white" And IsNothing(szachownica(Me.x - 1, Me.y + 1)) = False Then
                If szachownica(Me.x - 1, Me.y + 1).kolor <> Me.kolor Then
                    b = True
                End If
            End If
        End If


        If Me.x <= 7 Then
            If Me.kolor = "black" And IsNothing(szachownica(Me.x + 1, Me.y - 1)) = False Then
                If szachownica(Me.x + 1, Me.y - 1).kolor <> Me.kolor Then
                    b = True
                End If

            End If
        End If

        If Me.kolor = "black" And IsNothing(szachownica(Me.x - 1, Me.y - 1)) = False Then
            If szachownica(Me.x - 1, Me.y - 1).kolor <> Me.kolor Then
                b = True
            End If

        End If

        Return b

    End Function
End Class
