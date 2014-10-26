Public Class Form4
    Dim kolor As Color
    Private Sub ComboBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox1.DrawItem, ComboBox2.DrawItem, ComboBox3.DrawItem, ComboBox4.DrawItem
        e.DrawBackground()
        e.DrawFocusRectangle()

        If e.Index >= 0 Then

            Dim aColor As Color = CType(sender.Items(e.Index), Color)

            Dim rect As Rectangle = New Rectangle(5, e.Bounds.Top + 2, e.Bounds.Height, e.Bounds.Height - 5)
            Dim br As Brush = Brushes.White

            e.DrawBackground()
            e.DrawFocusRectangle()

            If e.State = DrawItemState.Selected OrElse e.State = DrawItemState.ComboBoxEdit Then
                br = Brushes.White
            Else
                br = Brushes.Black
            End If

            e.Graphics.DrawRectangle(New Pen(aColor), rect)
            e.Graphics.FillRectangle(New SolidBrush(aColor), rect)
            rect.Inflate(1, 1)
            e.Graphics.DrawRectangle(Pens.Black, rect)
            e.Graphics.DrawString(" " & aColor.Name, sender.Font, br, e.Bounds.Height + 5, ((e.Bounds.Height - sender.Font.Height) \ 2) + e.Bounds.Top)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        root.kolorb = ComboBox1.SelectedItem
        root.kolorc = ComboBox2.SelectedItem
        root.kolors = ComboBox3.SelectedItem
        root.kolork = ComboBox4.SelectedItem
        Form1.PictureBox1.Refresh()
        Me.Close()
    End Sub

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ComboBox1.SelectedItem = root.kolorb
        Me.ComboBox2.SelectedItem = root.kolorc
        Me.ComboBox3.SelectedItem = root.kolors
        Me.ComboBox4.SelectedItem = root.kolork
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class