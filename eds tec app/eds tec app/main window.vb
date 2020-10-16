Public Class main_window

    Private Sub AppdatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppdatToolStripMenuItem.Click
        MsgBox("appdat was killed")

        MenuStrip1.Text = ("error")
        prol.Text = (":( :( :( :( :( error!")
        Me.Cursor = Cursors.No



    End Sub

    Private Sub MenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuToolStripMenuItem.Click
        If MenuStrip1.Text = ("error") Then
            Me.Hide()
            MsgBox("menu can not be opened because eds tec app.exe/appdat/er5.eds was not found!")

        Else

        End If
    End Sub

    Private Sub EdsTecAppexeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdsTecAppexeToolStripMenuItem.Click
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MenuStrip1.Text = ("error") Then
            Me.Hide()
            MsgBox("failed to find appdat")
        Else


        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        If MenuStrip1.Text = ("error") Then
            Me.Hide()
            MsgBox("could not find appdat")
        End If
        If ComboBox1.Text = ("hompage") Then
            ComboBox1.Text = ("about:blank")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MenuStrip1.Text = ("error") Then
            Me.Hide()
            MsgBox("could not find appdat")
        Else
            Form2.Show()
        End If
    End Sub
End Class