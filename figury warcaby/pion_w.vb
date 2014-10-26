Public Class pion_w
    Inherits figura

    Public Sub New(ByVal x, ByVal y, ByVal kolor)
        MyBase.New(x, y, kolor)
        'Me.obraz = "ikony_szachy\stone_" & Me.kolor & ".png"
        If Me.kolor = "white" Then Me.obraz = My.Resources.Resource1.stone_white
        If Me.kolor = "black" Then Me.obraz = My.Resources.Resource1.stone_black
    End Sub

    Public Sub zmiana_pion(ByVal szachownica)
        If Me.kolor = "black" And Me.y = 1 Then
            warcaby.szachownica_tab(Me.x, Me.y) = New damka_w(Me.x, Me.y, Me.kolor)
        End If

        If Me.kolor = "white" And Me.y = 8 Then
            warcaby.szachownica_tab(Me.x, Me.y) = New damka_w(Me.x, Me.y, Me.kolor)
        End If
    End Sub

    Public Sub czy_bicie(ByVal szachownica)

        If root.tura Mod 2 = 0 Then
            If Me.x > 0 And Me.x <= 6 And Me.y <= 6 Then 'TODO

                If Me.kolor = "white" And IsNothing(szachownica(Me.x + 1, Me.y + 1)) = False Then
                    If szachownica(Me.x + 1, Me.y + 1).kolor <> Me.kolor And IsNothing(szachownica(Me.x + 2, Me.y + 2)) = True Then
                        warcaby.bicie = True
                    End If
                End If

            End If

            If Me.x > 2 And Me.x <= 8 And Me.y <= 6 Then

                If Me.kolor = "white" And IsNothing(szachownica(Me.x - 1, Me.y + 1)) = False Then
                    If szachownica(Me.x - 1, Me.y + 1).kolor <> Me.kolor And IsNothing(szachownica(Me.x - 2, Me.y + 2)) Then
                        warcaby.bicie = True
                    End If
                End If

            End If
        End If

        '-------------------------------------------------
        If root.tura Mod 2 = 1 Then
            If Me.x < 7 Then 'Me.x > 0 And Me.x <= 6 And Me.y <= 6 Then

                If Me.kolor = "black" And IsNothing(szachownica(Me.x + 1, Me.y - 1)) = False Then
                    If szachownica(Me.x + 1, Me.y - 1).kolor <> Me.kolor And IsNothing(szachownica(Me.x + 2, Me.y - 2)) = True Then
                        warcaby.bicie = True
                    End If
                End If

            End If

            If Me.x > 1 Then 'Me.x > 2 And Me.x <= 8 And Me.y <= 6 Then

                If Me.kolor = "black" And IsNothing(szachownica(Me.x - 1, Me.y - 1)) = False And Me.x <> 2 Then
                    If szachownica(Me.x - 1, Me.y - 1).kolor <> Me.kolor And IsNothing(szachownica(Me.x - 2, Me.y - 2)) Then
                        warcaby.bicie = True
                    End If
                End If

            End If
        End If
    End Sub

    Public Sub wypelnij_siatke(ByVal szachownica)
        siatka_leg.Clear()
        If root.tura Mod 2 = 0 Then
            If Me.x <= 7 And Me.y <= 7 Then
                'zbicia
                If Me.kolor = "white" And IsNothing(szachownica(Me.x + 1, Me.y + 1)) = False Then
                    If szachownica(Me.x + 1, Me.y + 1).kolor <> Me.kolor And Me.y <> 7 = True And Me.x <> 7 = True Then
                        If IsNothing(szachownica(Me.x + 2, Me.y + 2)) = True Then
                            siatka_leg.Add(New pole(Me.x + 2, Me.y + 2))
                            warcaby.pole_bicie = szachownica(Me.x + 1, Me.y + 1)
                        End If
                    End If
                End If

                'ruch
                If Me.kolor = "white" And IsNothing(szachownica(Me.x + 1, Me.y + 1)) = True And warcaby.bicie = False Then
                    siatka_leg.Add(New pole(Me.x + 1, Me.y + 1))
                End If

            End If

            If Me.x <= 8 And Me.y <= 7 Then
                'zbicia
                If Me.kolor = "white" And IsNothing(szachownica(Me.x - 1, Me.y + 1)) = False Then
                    If szachownica(Me.x - 1, Me.y + 1).kolor <> Me.kolor And Me.y <> 7 = True And Me.x <> 2 Then
                        If IsNothing(szachownica(Me.x - 2, Me.y + 2)) = True Then
                            siatka_leg.Add(New pole(Me.x - 2, Me.y + 2))
                            warcaby.pole_bicie = szachownica(Me.x - 1, Me.y + 1)
                        End If
                    End If
                End If
            End If

            'ruch
            If Me.x > 1 And Me.x <= 8 And Me.y <= 7 Then
                If Me.kolor = "white" And IsNothing(szachownica(Me.x - 1, Me.y + 1)) = True And warcaby.bicie = False Then
                    siatka_leg.Add(New pole(Me.x - 1, Me.y + 1))
                End If
            End If

        End If
        '--------------------------------------------------------
        If root.tura Mod 2 = 1 Then

            'zbicia
            If Me.x <= 7 Then
                If Me.kolor = "black" And IsNothing(szachownica(Me.x + 1, Me.y - 1)) = False Then
                    If szachownica(Me.x + 1, Me.y - 1).kolor <> Me.kolor And Me.y <> 2 = True And Me.x <> 7 Then
                        If IsNothing(szachownica(Me.x + 2, Me.y - 2)) = True Then
                            siatka_leg.Add(New pole(Me.x + 2, Me.y - 2))
                            warcaby.pole_bicie = szachownica(Me.x + 1, Me.y - 1)
                        End If
                    End If
                End If
            End If

            'zbicia
            If Me.kolor = "black" And IsNothing(szachownica(Me.x - 1, Me.y - 1)) = False Then
                If szachownica(Me.x - 1, Me.y - 1).kolor <> Me.kolor And Me.y <> 2 = True And Me.x <> 2 Then
                    If IsNothing(szachownica(Me.x - 2, Me.y - 2)) = True Then
                        siatka_leg.Add(New pole(Me.x - 2, Me.y - 2))
                        warcaby.pole_bicie = szachownica(Me.x - 1, Me.y - 1)
                    End If
                End If
            End If

            If Me.x <= 7 Then
                'ruch
                If Me.kolor = "black" And IsNothing(szachownica(Me.x + 1, Me.y - 1)) = True And warcaby.bicie = False Then
                    siatka_leg.Add(New pole(Me.x + 1, Me.y - 1))
                End If
            End If
            If Me.x > 1 Then

                'ruch
                If Me.kolor = "black" And IsNothing(szachownica(Me.x - 1, Me.y - 1)) = True And warcaby.bicie = False Then
                    siatka_leg.Add(New pole(Me.x - 1, Me.y - 1))
                End If
            End If
        End If

        warcaby.bicie = False
    End Sub
    Public Sub dalsze_bicie()
        If root.szachownica_tab(Me.x, Me.y).czy_bicie(root.szachownica_tab) = True Then
            MsgBox("drugie bicie")
        Else
            'MsgBox("test")
        End If
    End Sub
End Class
