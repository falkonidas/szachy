Public Class root
    Public Shared szachownica_tab(8, 8)
    Public Shared o As Point
    Public Shared tura As String
    Public Shared stan_gry As String = "wyb_fig"
    Public Shared gracz As String
    Public Shared gra As String

    'x,y początkowe końcowe klikanie ruchu
    Public Shared x_p As Integer
    Public Shared x_k As Integer
    Public Shared y_p As Integer
    Public Shared y_k As Integer

    Public Shared last_move As New pole(0, 0)
    Public Shared last_move2 As New pole(0, 0)

    Public Shared kolorb As Color = My.Settings.kolorb
    Public Shared kolorc As Color = My.Settings.kolorc
    Public Shared kolors As Color = My.Settings.kolors
    Public Shared kolork As Color = My.Settings.kolork

    Public Shared klik As Point

    Public Shared Sub stan()
        Form1.TextBox7.Clear()
        Form1.TextBox7.AppendText(If(CBool((tura) Mod 2), "Czarne", "Białe"))
        Form1.PictureBox3.BackColor = If(CBool((tura) Mod 2), Color.Black, Color.White)
    End Sub

    Public Shared Function ruch_komputera()
        Dim ruchy As New List(Of pole_ruch)

        For Each p As Object In szachownica_tab
            If IsNothing(p) = False Then
                If p.kolor = "black" Then

                    warcaby.szuk_bicie()

                    p.wypelnij_siatke(szachownica_tab)

                    If gra = "szach" Then p.wyp_siatka_leg(p.x, p.y, szachownica_tab)

                    For Each d As pole In p.siatka_leg
                        ruchy.Add(New pole_ruch(p.x, p.y, d.x, d.y))
                    Next
                End If
            End If
        Next
        Dim rnd = New Random()

        Dim random_move = ruchy(rnd.Next(0, ruchy.Count))

        'ostatni ruch komputera
        last_move.x = random_move.xp
        last_move.y = random_move.yp
        last_move2.x = random_move.xk
        last_move2.y = random_move.yk

        Dim ruch = ""
        If gra = "szach" Then
            ruch = szachownica_tab(random_move.xp, random_move.yp).ruch(random_move.xp, random_move.yp, random_move.xk, random_move.yk, szachownica_tab)
        ElseIf gra = "war" Then
            ruch = szachownica_tab(random_move.xp, random_move.yp).ruch_w(random_move.xp, random_move.yp, random_move.xk, random_move.yk, szachownica_tab)
        End If

        Return ruch

    End Function

    Public Shared Sub test()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
        Form1.TextBox1.AppendText(o.X)
        Form1.TextBox2.AppendText(o.Y)
    End Sub

    Public Shared Sub test2()
        Form1.TextBox3.Clear()
        For Each p As pole In root.szachownica_tab(1 + szachy.o.X, 8 - szachy.o.Y).siatka_leg
            Form1.TextBox3.AppendText(p.x & p.y & " ")
        Next

        Form1.TextBox4.Clear()
        Form1.TextBox4.AppendText(warcaby.bicie)

        If IsNothing(last_move) = False Then
            Form1.TextBox5.Clear()
            Form1.TextBox5.AppendText(last_move.x & last_move.y)
        End If

    End Sub
End Class
