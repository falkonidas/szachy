Public Class warcaby
    Inherits root
    Public Shared bicie = False
    Public Shared pole_bicie As figura
    Public Shared koniec As Boolean = False

    Public Shared zbity As Boolean

    Public Shared Sub wyp_szach()
        koniec = False
        tura = 0
        stan_gry = "wyb_fig"
        Array.Clear(szachownica_tab, 0, szachownica_tab.Length)

        For i = 1 To 8
            For j = 1 To 3 'Step 2
                If (i + j) Mod 2 = 0 Then
                    szachownica_tab(i, j) = New pion_w(i, j, "white")
                Else
                    szachownica_tab(i, j + 5) = New pion_w(i, j + 5, "black")
                End If
            Next j
        Next i
        'szachownica_tab(4, 4) = New pion_w(4, 4, "black")
        'szachownica_tab(6, 6) = New pion_w(6, 6, "black")
        'szachownica_tab(7, 7) = New pion_w(7, 7, "white")
        'szachownica_tab(3, 3) = New pion_w(3, 3, "white")
        'szachownica_tab(3, 3) = New pion_w(3, 3, "white")
        'szachownica_tab(4, 4) = New pion_w(4, 4, "white")

    End Sub

    Public Shared Sub szuk_zmian_pion()
        For Each p In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(pion_w) Then
                    p.zmiana_pion(szachownica_tab)
                End If
            End If
        Next
    End Sub

    Public Shared Sub szuk_bicie()
        For Each p In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(pion_w) Or p.GetType() = GetType(damka_w) And p.kolor = If(CBool((tura) Mod 2), "black", "white") Then
                    p.czy_bicie(szachownica_tab)
                End If
            End If
            If warcaby.bicie = True Then Exit For
        Next
    End Sub

    Public Shared Sub koniec_gry()
        Dim bia As Integer = 0
        Dim cza As Integer = 0
        For Each p In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(pion_w) Or p.GetType() = GetType(damka_w) Then
                    If p.kolor = "white" Then bia += 1
                    If p.kolor = "black" Then cza += 1
                End If
            End If
        Next

        If bia = 0 Then
            MsgBox("Koniec gry, wygrały czarne")
            koniec = True
        End If

        If cza = 0 Then
            MsgBox("Koniec gry, wygrały białe")
            koniec = True
        End If

        bia = 0
        cza = 0
    End Sub

    Public Shared Sub proces_gry()
        If IsNothing(szachownica_tab(o.X + 1, 8 - o.Y)) = False And stan_gry = "wyb_fig" Then
            If szachownica_tab(o.X + 1, 8 - o.Y).kolor = If(CBool((tura) Mod 2), "black", "white") Then
                stan_gry = "wyb_pol"
                x_p = o.X
                y_p = o.Y
                szuk_bicie()
                szachownica_tab(x_p + 1, 8 - y_p).wypelnij_siatke(szachownica_tab)
                test2()

            End If
        End If

        If stan_gry = "wyb_pol" And x_p = o.X And y_p = o.Y Then
        ElseIf stan_gry = "wyb_pol" Then
            szuk_bicie()
            szachownica_tab(x_p + 1, 8 - y_p).wypelnij_siatke(szachownica_tab)
            szachownica_tab(x_p + 1, 8 - y_p).ruch_w(x_p + 1, 8 - y_p, o.X + 1, 8 - o.Y, szachownica_tab)
            test()
            koniec_gry()
            If gracz = "komp" And tura Mod 2 = 1 And koniec = False Then
                root.kolors = Color.Transparent
                Form1.PictureBox1.Refresh()
                Do
                    System.Threading.Thread.Sleep(1000)
                    ruch_komputera()
                    Form1.PictureBox1.Refresh()
                Loop Until warcaby.zbity = False
                root.kolors = Form4.ComboBox3.SelectedItem
            End If

            'koniec_gry()
            szuk_zmian_pion()
            stan_gry = "wyb_fig"
        End If
            stan()
    End Sub

End Class
