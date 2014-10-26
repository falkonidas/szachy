Public Class Form1
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        root.gra = "szach"
        Form3.ShowDialog()
        szachy.wyp_szach()
        PictureBox1.Enabled = True
        Me.PictureBox1.Invalidate()
        szachy.stan()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        root.gra = "war"
        Form3.ShowDialog()
        warcaby.wyp_szach()
        PictureBox1.Enabled = True
        Me.PictureBox1.Invalidate()
        warcaby.stan()
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint

        'rysowanie szachownicy 1 warstwa

        Dim cellSize As Size = New Size(20, 20)

        For x As Integer = 0 To 7
            For y As Integer = 0 To 7

                Dim cellLocation As Point = New Point(x * cellSize.Width, y * cellSize.Height)

                Dim cell As Rectangle = New Rectangle(cellLocation, cellSize)

                Using cellBrush As SolidBrush = If(CBool((x + y) Mod 2), New SolidBrush(root.kolorb), New SolidBrush(root.kolorc))

                    e.Graphics.FillRectangle(cellBrush, cell)
                End Using

            Next
        Next

        If root.stan_gry = "wyb_pol" Then
            'rysowanie siatki

            For x As Integer = 0 To 7
                For y As Integer = 0 To 7

                    Dim cellLocation As Point = New Point(x * cellSize.Width, y * cellSize.Height)

                    Dim cell As Rectangle = New Rectangle(cellLocation, cellSize)
                    '----------------------------------------------------------------------------------
                    'ostatni ruch komutera
                    If IsNothing(root.last_move) = False Then
                        If root.last_move.x = x + 1 And root.last_move.y = 8 - y Then
                            Using cellBrush As SolidBrush = New SolidBrush(Color.FromArgb(0, 0, 100, 0))
                                e.Graphics.FillRectangle(cellBrush, cell)
                            End Using
                        End If
                    End If

                    If IsNothing(root.last_move2) = False Then
                        If root.last_move2.x = x + 1 And root.last_move2.y = 8 - y Then
                            Using cellBrush As SolidBrush = New SolidBrush(Color.FromArgb(0, 0, 100, 0))
                                e.Graphics.FillRectangle(cellBrush, cell)
                            End Using
                        End If
                    End If
                    '-------------------------------------------------------------------------------
                    'siatka
                    Try
                        For Each number As pole In root.szachownica_tab(1 + szachy.o.X, 8 - szachy.o.Y).siatka_leg
                            If number.x = x + 1 And number.y = 8 - y Then
                                Using cellBrush As SolidBrush = New SolidBrush(root.kolors)
                                    e.Graphics.FillRectangle(cellBrush, cell)
                                End Using
                            End If
                        Next
                    Catch ex As Exception

                    End Try

                    'rysowanie klikniętego pola
                    If root.o.X = x And root.o.Y = y Then
                        Using cellBrush As SolidBrush = New SolidBrush(root.kolork)
                            e.Graphics.FillRectangle(cellBrush, cell)
                        End Using
                    End If

                Next
            Next
        End If

        'rysowanie figur
        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                Dim cellLocation As Point = New Point(x * cellSize.Width, y * cellSize.Height)

                Dim cell As Rectangle = New Rectangle(cellLocation, cellSize)

                If IsNothing(root.szachownica_tab(1 + x, 8 - y)) = False Then
                    'Dim image1 As Bitmap = CType(Image.FromFile(root.szachownica_tab(1 + x, 8 - y).obraz, True), Bitmap)
                    Dim image1 As Bitmap = CType(root.szachownica_tab(1 + x, 8 - y).obraz, Bitmap)
                    Dim texture As New TextureBrush(image1)
                    texture.WrapMode = Drawing2D.WrapMode.Tile
                    e.Graphics.FillRectangle(texture, cell)
                End If
            Next
        Next
    End Sub

    Private Sub PictureBox2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint

        Dim drawFont As New System.Drawing.Font("Arial", 16)
        Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
        Dim drawFormat As New System.Drawing.StringFormat

        Dim a As Single = 20.0
        Dim b As Single = 0
        Dim drawStringlitery As String
        Dim drawStringliczby As Integer

        For i As Integer = 0 To 7
            drawStringlitery = "ABCDEFGH"(i)
            drawStringliczby = 8 - i
            e.Graphics.DrawString(drawStringlitery, drawFont, drawBrush, a + i * 20, b, drawFormat)
            e.Graphics.DrawString(drawStringlitery, drawFont, drawBrush, a + i * 20, b + 185, drawFormat)
            e.Graphics.DrawString(drawStringliczby, drawFont, drawBrush, a - 20, b + 23 + 20 * i, drawFormat)
            e.Graphics.DrawString(drawStringliczby, drawFont, drawBrush, a + 162, b + 23 + 20 * i, drawFormat)
        Next
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal ByValsender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        root.o.X = (e.X - 10) / 20
        root.o.Y = (e.Y - 10) / 20
    End Sub

    Private Sub PictureBox1_MouseClick(ByVal ByValsender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        root.test()

        If root.gra = "szach" Then
            szachy.proces_gry()
        ElseIf root.gra = "war" Then
            warcaby.proces_gry()
        End If
        PictureBox1.Refresh()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form4.ShowDialog()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.kolorb = root.kolorb
        My.Settings.kolorc = root.kolorc
        My.Settings.kolors = root.kolors
        My.Settings.kolork = root.kolork
        My.Settings.Save()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CurrColor As Color
        For Each aColorName As String In System.Enum.GetNames(GetType(System.Drawing.KnownColor))
            CurrColor = Color.FromName(aColorName)
            'If CurrColor.IsSystemColor = False Then ComboBox1.Items.Add(CurrColor)
            'If CurrColor.IsSystemColor = False Then ComboBox2.Items.Add(CurrColor)
            'If CurrColor.IsSystemColor = False Then ComboBox3.Items.Add(CurrColor)
            'If CurrColor.IsSystemColor = False Then ComboBox4.Items.Add(CurrColor)
            Form4.ComboBox1.Items.Add(CurrColor)
            Form4.ComboBox2.Items.Add(CurrColor)
            Form4.ComboBox3.Items.Add(CurrColor)
            Form4.ComboBox4.Items.Add(CurrColor)
        Next aColorName

        For Each c As Control In Me.Controls
            If (TypeOf c Is ComboBox) Then
                c.Refresh()
            End If
        Next

        Form4.ComboBox1.SelectedItem = root.kolorb
        Form4.ComboBox2.SelectedItem = root.kolorc
        Form4.ComboBox3.SelectedItem = root.kolors
        Form4.ComboBox4.SelectedItem = root.kolork

    End Sub

End Class
