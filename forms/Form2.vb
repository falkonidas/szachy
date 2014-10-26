Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        szachy.szachownica_tab(szachy.a, szachy.b) = New skoczek(szachy.a, szachy.b, szachy.c)
        Form1.PictureBox1.Invalidate()
        Me.Close()
        szachy.tura += 1
        System.Threading.Thread.Sleep(100)
        If szachy.gracz = "komp" Then
            szachy.ruch_komputera()
        End If
        szachy.stan()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        szachy.szachownica_tab(szachy.a, szachy.b) = New krolowa(szachy.a, szachy.b, szachy.c)
        Form1.PictureBox1.Invalidate()
        Me.Close()
        szachy.tura += 1
        System.Threading.Thread.Sleep(100)
        If szachy.gracz = "komp" Then
            szachy.ruch_komputera()
        End If
        szachy.stan()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        szachy.szachownica_tab(szachy.a, szachy.b) = New goniec(szachy.a, szachy.b, szachy.c)
        Form1.PictureBox1.Invalidate()
        Me.Close()
        System.Threading.Thread.Sleep(100)
        szachy.tura += 1
        If szachy.gracz = "komp" Then
            szachy.ruch_komputera()
        End If
        szachy.stan()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        szachy.szachownica_tab(szachy.a, szachy.b) = New wieza(szachy.a, szachy.b, szachy.c)
        Form1.PictureBox1.Invalidate()
        Me.Close()
        System.Threading.Thread.Sleep(100)
        szachy.tura += 1
        If szachy.gracz = "komp" Then
            szachy.ruch_komputera()
        End If
        szachy.stan()
    End Sub
End Class