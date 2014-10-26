Module funkcje
    Public szachownica_tab(8, 8)

    'Public krol_b As New krol(5, 1, "white")
    'Public krol_c As New krol(5, 8, "black")

    Public a
    Public b
    Public c

    Public stan_gry As String = "wyb_fig"

    'x,y początkowe końcowe klikanie ruchu
    Public x_p As Integer
    Public x_k As Integer
    Public y_p As Integer
    Public y_k As Integer

    Public tura As String

    Public mat As Boolean = False

    Public Sub szukanie_pion()
        For Each p In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(pion) Then
                    p.zmiana_pion(szachownica_tab)
                End If
            End If
        Next
    End Sub
    Public Function szukanie_krol(ByVal k As String)
        Dim a As Boolean = False
        For Each p As Object In szachownica_tab
            If IsNothing(p) = False Then
                If p.GetType() = GetType(krol) And p.kolor = k Then
                    p.czy_szach(szachownica_tab)
                    If p.czy_szach(szachownica_tab) = True Then
                        a = True
                        'MsgBox("szach")
                    End If
                End If
            End If
        Next
        Return a
    End Function

    Public Sub szukanie_szach(ByVal k As String)
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

    Public Sub szach_mat()
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

    Public Function ruch_komputera()
        Dim ruchy As New List(Of pole_ruch)

        For Each p As Object In szachownica_tab
            If IsNothing(p) = False Then
                If p.kolor = "black" Then
                    p.wypelnij_siatke(szachownica_tab)
                    p.wyp_siatka_leg(p.x, p.y, szachownica_tab)
                    For Each d As pole In p.siatka_leg
                        ruchy.Add(New pole_ruch(p.x, p.y, d.x, d.y))
                        'Form1.TextBox10.AppendText(TypeName(p) & p.x & p.y & d.x & d.y & " ")
                    Next
                End If
            End If
        Next

        Dim rnd = New Random()

        Dim random_move = ruchy(rnd.Next(0, ruchy.Count))
        'Form1.TextBox10.AppendText(random_move.xp & random_move.yp & random_move.xk & random_move.yk)

        Return szachownica_tab(random_move.xp, random_move.yp).ruch(random_move.xp, random_move.yp, random_move.xk, random_move.yk, szachownica_tab)
    End Function
End Module

