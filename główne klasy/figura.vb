Public MustInherit Class figura
    Public x As Integer
    Public y As Integer
    Public kolor As String
    Public siatka As New List(Of pole)
    Public siatka_leg As New List(Of pole)
    Public obraz As Image
    Public pierwszy_ruch As Boolean

    Public Sub New(ByVal x, ByVal y, ByVal kolor)
        Me.x = x
        Me.y = y
        Me.kolor = kolor
    End Sub
    Public Sub ruch(ByVal start_x, ByVal start_y, ByVal dest_x, ByVal dest_y, ByVal szachownica)
        For Each pole In szachownica(start_x, start_y).siatka_leg
            If pole.x = dest_x And pole.y = dest_y Then

                'ruch ogólny
                Me.x = dest_x
                Me.y = dest_y
                szachownica(dest_x, dest_y) = Me
                szachownica(start_x, start_y) = Nothing
                Me.pierwszy_ruch = False
                szachy.tura += 1

            End If
        Next
    End Sub

    Public Sub ruch_w(ByVal start_x, ByVal start_y, ByVal dest_x, ByVal dest_y, ByVal szachownica)

        For Each pole In szachownica(start_x, start_y).siatka_leg
            If pole.x = dest_x And pole.y = dest_y Then

                'ruch ogólny
                Me.x = dest_x
                Me.y = dest_y
                szachownica(dest_x, dest_y) = Me
                szachownica(start_x, start_y) = Nothing
                Me.pierwszy_ruch = False

                'bicie dla warcabów
                If IsNothing(warcaby.pole_bicie) = False Then
                    szachownica(warcaby.pole_bicie.x, warcaby.pole_bicie.y) = Nothing
                    warcaby.pole_bicie = Nothing
                    warcaby.zbity = True
                End If

                'sprawdzanie kontynuacji bicia
                szachownica(dest_x, dest_y).czy_bicie(szachownica)
                If warcaby.bicie = True And warcaby.zbity = True Then

                Else
                    warcaby.tura += 1
                    warcaby.zbity = False
                End If

            End If
        Next
    End Sub

    Public Sub wyp_siatka_leg(ByVal start_x, ByVal start_y, ByVal szachownica)

        siatka_leg.Clear()

        For ix = 0 To 8
            For jy = 0 To 8
                Dim bufor As Object
                bufor = Nothing

                For Each pola In szachownica(start_x, start_y).siatka
                    If pola.x = ix And pola.y = jy Then
                        Me.x = ix
                        Me.y = jy

                        If IsNothing(szachownica(ix, jy)) = False Then
                            bufor = szachownica(ix, jy)
                        End If

                        szachownica(ix, jy) = Me
                        szachownica(start_x, start_y) = Nothing

                        If szachy.szukanie_krol(If(CBool((szachy.tura) Mod 2), "black", "white")) = False Then

                            siatka_leg.Add(New pole(ix, jy))
                        End If

                        Me.x = start_x
                        Me.y = start_y

                        szachownica(ix, jy) = bufor
                        szachownica(start_x, start_y) = Me

                        bufor = Nothing

                    End If
                Next
            Next
        Next

    End Sub
End Class
