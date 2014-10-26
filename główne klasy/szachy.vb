Public Class szachy
    Inherits root

    Public Shared a
    Public Shared b
    Public Shared c
    Public Shared mat As Boolean = False

    Public Shared Sub wyp_szach()
        mat = False
        tura = 0
        stan_gry = "wyb_fig"

        Array.Clear(szachownica_tab, 0, szachownica_tab.Length)

        For i = 1 To 8
            szachownica_tab(i, 2) = New pion(i, 2, "white")
            szachownica_tab(i, 7) = New pion(i, 7, "black")
        Next i

        szachownica_tab(1, 1) = New wieza(1, 1, "white")
        szachownica_tab(8, 1) = New wieza(8, 1, "white")
        szachownica_tab(1, 8) = New wieza(1, 8, "black")
        szachownica_tab(8, 8) = New wieza(8, 8, "black")

        szachownica_tab(3, 1) = New goniec(3, 1, "white")
        szachownica_tab(6, 1) = New goniec(6, 1, "white")
        szachownica_tab(3, 8) = New goniec(3, 8, "black")
        szachownica_tab(6, 8) = New goniec(6, 8, "black")

        szachownica_tab(2, 1) = New skoczek(2, 1, "white")
        szachownica_tab(7, 1) = New skoczek(7, 1, "white")
        szachownica_tab(2, 8) = New skoczek(2, 8, "black")
        szachownica_tab(7, 8) = New skoczek(7, 8, "black")

        szachownica_tab(4, 1) = New krolowa(4, 1, "white")
        szachownica_tab(4, 8) = New krolowa(4, 8, "black")

        szachownica_tab(5, 1) = New krol(5, 1, "white")
        szachownica_tab(5, 8) = New krol(5, 8, "black")
    End Sub

    Public Shared Sub szuk_zmian_pion()
        For Each p In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(pion) Then
                    p.zmiana_pion(szachownica_tab)
                End If
            End If
        Next
    End Sub
    Public Shared Function szukanie_krol(ByVal k As String)
        Dim a As Boolean = False
        For Each p As Object In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(krol) And p.kolor = k Then
                    p.czy_szach(szachownica_tab)
                    If p.czy_szach(szachownica_tab) = True Then
                        a = True
                    End If
                End If
            End If
        Next
        Return a
    End Function

    Public Shared Sub szukanie_szach(ByVal k As String)
        Dim a As Boolean = False
        For Each p As Object In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(krol) And p.kolor = k Then
                    p.czy_szach(szachownica_tab)
                    If p.czy_szach(szachownica_tab) = True Then
                        a = True
                        MsgBox("szach")
                    End If
                End If
            End If
        Next
    End Sub

    Public Shared Sub koniec_gry()
        Dim s As New List(Of pole)
        For Each p As Object In szachownica_tab
            If IsNothing(p) = False Then
                If p.kolor = If(CBool((tura) Mod 2), "black", "white") Then
                    p.wypelnij_siatke(szachownica_tab)
                    p.wyp_siatka_leg(p.x, p.y, szachownica_tab)
                    For Each d As pole In p.siatka_leg
                        s.Add(d)
                    Next
                End If
            End If
        Next
        If s.Count = 0 Then
            MsgBox("szachmat")
            mat = True
            Form1.PictureBox1.Enabled = False
        End If
    End Sub

    Public Shared Sub proces_gry()
        If IsNothing(szachownica_tab(o.X + 1, 8 - o.Y)) = False And stan_gry = "wyb_fig" Then
            If szachownica_tab(o.X + 1, 8 - o.Y).kolor = If(CBool((tura) Mod 2), "black", "white") Then
                stan_gry = "wyb_pol"
                x_p = o.X
                y_p = o.Y
                szachownica_tab(x_p + 1, 8 - y_p).wypelnij_siatke(szachownica_tab)
                szachownica_tab(x_p + 1, 8 - y_p).wyp_siatka_leg(x_p + 1, 8 - y_p, szachownica_tab)

            End If
        End If

        If stan_gry = "wyb_pol" And x_p = o.X And y_p = o.Y Then
        ElseIf stan_gry = "wyb_pol" Then

            szachownica_tab(x_p + 1, 8 - y_p).wypelnij_siatke(szachownica_tab)
            szachownica_tab(x_p + 1, 8 - y_p).wyp_siatka_leg(x_p + 1, 8 - y_p, szachownica_tab)
            szachownica_tab(x_p + 1, 8 - y_p).ruch(x_p + 1, 8 - y_p, o.X + 1, 8 - o.Y, szachownica_tab)

            szuk_zmian_pion()
            koniec_gry()

            If gracz = "komp" Then
                If tura Mod 2 = 1 And mat = False Then
                    root.kolors = Color.Transparent
                    Form1.PictureBox1.Refresh()
                    System.Threading.Thread.Sleep(1000)
                    ruch_komputera()
                    root.kolors = Form4.ComboBox3.SelectedItem
                End If
            End If

            szukanie_szach("white")
            stan_gry = "wyb_fig"
        End If
        stan()
    End Sub
End Class
