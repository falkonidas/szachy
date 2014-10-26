Public Class damka_w
    Inherits figura
    Public Sub New(ByVal x, ByVal y, ByVal kolor)
        MyBase.New(x, y, kolor)
        'Me.obraz = "ikony_szachy\bishop_" & Me.kolor & ".png"
        If Me.kolor = "white" Then Me.obraz = My.Resources.Resource1.bishop_white
        If Me.kolor = "black" Then Me.obraz = My.Resources.Resource1.bishop_black
    End Sub
    Public Sub czy_bicie(ByVal szachownica)
        Dim stop_szuk As Boolean = False
        Dim j = Me.y

        If stop_szuk = False Then
            For i = Me.x + 1 To 8 Step 1
                j += 1
                If j = 9 Then Exit For
                If IsNothing(szachownica(i, j)) Then
                    Continue For
                ElseIf Not IsNothing(szachownica(i, j)) Then
                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False
                            stop_szuk = True
                        Else
                            If IsNothing(szachownica(i + 1, j + 1)) = True Then
                                warcaby.bicie = True
                                stop_szuk = True
                            End If

                            If IsNothing(szachownica(i + 1, j + 1)) = False Then warcaby.bicie = False
                        End If

                    End If

                End If
                If szachownica(i, j).kolor = Me.kolor Then
                    warcaby.bicie = False
                End If

                Exit For

            Next i
        End If


        If stop_szuk = False Then
            j = Me.y

            For i = Me.x - 1 To 1 Step -1
                j -= 1
                If j = 0 Then Exit For
                If IsNothing(szachownica(i, j)) Then
                    Continue For
                ElseIf Not IsNothing(szachownica(i, j)) Then
                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False
                            stop_szuk = True
                        Else
                            If IsNothing(szachownica(i - 1, j - 1)) = True Then
                                warcaby.bicie = True
                                stop_szuk = True
                            End If

                            If IsNothing(szachownica(i - 1, j - 1)) = False Then
                                warcaby.bicie = False
                                stop_szuk = True
                            End If

                        End If

                    End If
                    If szachownica(i, j).kolor = Me.kolor Then
                        warcaby.bicie = False
                        stop_szuk = True
                    End If
                    Exit For
                End If
            Next i
        End If



        If stop_szuk = False Then
            j = Me.y

            For i = Me.x + 1 To 8 Step 1
                j -= 1
                If j = 0 Then Exit For
                If IsNothing(szachownica(i, j)) Then
                    Continue For
                ElseIf Not IsNothing(szachownica(i, j)) Then
                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False
                            stop_szuk = True
                        Else
                            If IsNothing(szachownica(i + 1, j - 1)) = True Then
                                warcaby.bicie = True
                                stop_szuk = True
                            End If

                            If IsNothing(szachownica(i + 1, j - 1)) = False Then
                                warcaby.bicie = False
                                stop_szuk = True
                            End If

                        End If

                    End If
                    If szachownica(i, j).kolor = Me.kolor Then
                        warcaby.bicie = False
                        stop_szuk = True
                    End If
                    Exit For
                End If
            Next i
        End If



        If stop_szuk = False Then
            j = Me.y

            For i = Me.x - 1 To 1 Step -1
                j += 1
                If j = 9 Then Exit For
                If IsNothing(szachownica(i, j)) Then
                    Continue For
                ElseIf Not IsNothing(szachownica(i, j)) Then
                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False
                            stop_szuk = True
                        Else
                            If IsNothing(szachownica(i - 1, j + 1)) = True Then
                                warcaby.bicie = True
                                stop_szuk = True
                            End If

                            If IsNothing(szachownica(i - 1, j + 1)) = False Then
                                warcaby.bicie = False
                                stop_szuk = True
                            End If

                        End If
                    End If
                    If szachownica(i, j).kolor = Me.kolor Then
                        warcaby.bicie = False
                        stop_szuk = True
                    End If
                    Exit For
                End If
            Next i
        End If

    End Sub
    Public Sub wypelnij_siatke(ByVal szachownica)

        siatka_leg.Clear()

        Dim j = Me.y

        For i = Me.x + 1 To 8 Step 1
            j += 1
            If j = 9 Then Exit For
            If IsNothing(szachownica(i, j)) And warcaby.bicie = False Then
                siatka_leg.Add(New pole(i, j))
            Else
                If IsNothing(szachownica(i, j)) = False Then
                    If szachownica(i, j).kolor = Me.kolor Then
                        Exit For
                    End If

                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False
                        Else
                            If IsNothing(szachownica(i + 1, j + 1)) = True Then
                                siatka_leg.Add(New pole(i + 1, j + 1))
                                warcaby.pole_bicie = szachownica(i, j)
                                Exit For
                            End If
                            If IsNothing(szachownica(i + 1, j + 1)) = False Then
                                Exit For
                            End If
                        End If

                    End If
                    Exit For
                End If

            End If
        Next i

        j = Me.y

        For i = Me.x - 1 To 1 Step -1
            j -= 1
            If j = 0 Then Exit For
            If IsNothing(szachownica(i, j)) And warcaby.bicie = False Then
                siatka_leg.Add(New pole(i, j))
            Else
                If IsNothing(szachownica(i, j)) = False Then
                    If szachownica(i, j).kolor = Me.kolor Then
                        Exit For
                    End If

                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False

                        Else
                            If IsNothing(szachownica(i - 1, j - 1)) = True Then
                                siatka_leg.Add(New pole(i - 1, j - 1))
                                warcaby.pole_bicie = szachownica(i, j)
                                Exit For
                            End If
                            If IsNothing(szachownica(i - 1, j - 1)) = False Then
                                Exit For
                            End If
                        End If

                    End If

                    Exit For
                End If
            End If
        Next i

        j = Me.y

        For i = Me.x + 1 To 8 Step 1
            j -= 1
            If j = 0 Then Exit For
            If IsNothing(szachownica(i, j)) And warcaby.bicie = False Then
                siatka_leg.Add(New pole(i, j))
            Else
                If IsNothing(szachownica(i, j)) = False Then
                    If szachownica(i, j).kolor = Me.kolor Then
                        Exit For
                    End If

                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False

                        Else
                            If IsNothing(szachownica(i + 1, j - 1)) = True Then
                                siatka_leg.Add(New pole(i + 1, j - 1))
                                warcaby.pole_bicie = szachownica(i, j)
                                Exit For
                            End If
                            If IsNothing(szachownica(i + 1, j - 1)) = False Then
                                Exit For
                            End If
                        End If

                    End If

                    Exit For
                End If
            End If
        Next i

        j = Me.y

        For i = Me.x - 1 To 1 Step -1
            j += 1
            If j = 9 Then Exit For
            If IsNothing(szachownica(i, j)) And warcaby.bicie = False Then
                siatka_leg.Add(New pole(i, j))
            Else
                If IsNothing(szachownica(i, j)) = False Then
                    If szachownica(i, j).kolor = Me.kolor Then
                        Exit For
                    End If

                    If szachownica(i, j).kolor <> Me.kolor Then
                        If szachownica(i, j).x = 1 Or szachownica(i, j).x = 8 Or szachownica(i, j).y = 1 Or szachownica(i, j).y = 1 Then
                            warcaby.bicie = False

                        Else
                            If IsNothing(szachownica(i - 1, j + 1)) = True Then
                                siatka_leg.Add(New pole(i - 1, j + 1))
                                warcaby.pole_bicie = szachownica(i, j)
                                Exit For
                            End If
                            If IsNothing(szachownica(i - 1, j + 1)) = False Then
                                Exit For
                            End If
                        End If
                    End If
                    Exit For
                End If
                
            End If
        Next i

        warcaby.bicie = False
    End Sub
End Class
