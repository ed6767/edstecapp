Public Class Form1

    Private Sub Form1_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles Me.ChangeUICues

    End Sub

    Private Sub Form1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        MsgBox("you can not put that here!")
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        MsgBox("see ya!")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser2.Navigate(" ")
        WebBrowser3.Navigate(" ")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Me.Refresh()
        Me.Show()
        MsgBox("reloaded")
    End Sub

    Public Sub NotifyIcon1_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        MsgBox("eds tec app is open")
    End Sub

    Private Sub no(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click

    End Sub

    Private Sub Form1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        ForeColor = ColorDialog1.Color
    End Sub

    Private Sub Form1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Font = FontDialog1.Font
    End Sub

    Private Sub NotifyIcon1_Mousehover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseHover

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox("open")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("eep! I will now only show the open the system tools and eds will run in the backround!")
        Me.Hide()
        MsgBox("i have gone! close this box to open")
        Me.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        Me.Show()
        Me.Hide()
        MsgBox("ok i will close!")
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NotifyIcon3.Visible = False

    End Sub

    Private Sub NotifyIcon3_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon3.MouseDoubleClick

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If NotifyIcon1.Visible = False Then
            MsgBox("allready hidden!")
        End If
        NotifyIcon1.Visible = False
        NotifyIcon2.Visible = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If NotifyIcon1.Visible = True Then
            MsgBox("it is allready there!")
        End If
        NotifyIcon1.Visible = True
        NotifyIcon2.Visible = True
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Do
            Me.Hide()
            Me.Show()
        Loop
    End Sub

    Private Sub NotifyIcon4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon4.Click
        Me.Show()
        NotifyIcon4.Visible = False
    End Sub

    Private Sub NotifyIcon4_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon4.MouseDoubleClick
        Me.Show()
        NotifyIcon4.Visible = False
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        NotifyIcon4.Visible = True
        Me.Hide()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("ignore it! if you are on youtube home just click no thanks!")
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("just click close script")
    End Sub

    Private Sub NotifyIcon2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon2.Click
        MsgBox("eds is open!!!!!!")
    End Sub

    Private Sub NotifyIcon2_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon2.MouseDoubleClick
        MsgBox("eds is open!!!!!!!")
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub Button9_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ColorDialog1.ShowDialog()
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Button10.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub Button10_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button10.ForeColorChanged
        MsgBox("color changed")
    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        FontDialog1.ShowDialog()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

    End Sub

    Private Sub FontDialog1_Apply(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontDialog1.Apply

    End Sub

    Private Sub TabPage11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage11.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.Enter

    End Sub

    Private Sub Label3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseEnter
        Label3.Text = ComboBox1.Text
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If NotifyIcon5.Visible = True Then
            NotifyIcon5.Visible = False
        End If
        NotifyIcon5.Visible = True
    End Sub

    Private Sub NotifyIcon5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon5.Click
        If CheckBox1.Checked Then
            MsgBox(ComboBox3.Text)
        End If
    End Sub

    Private Sub NotifyIcon5_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon5.MouseDoubleClick

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        NotifyIcon5.Text = ComboBox2.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ProgressBar1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)

    End Sub

    Private Sub ProgressBar1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
 
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button16.Visible = False
    End Sub

    Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Start()


    End Sub

    Private Sub TextBox1_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Timer1.Equals(TextBox1.Text) Then
            MsgBox("your s up!")
            Me.Close()
        End If
    End Sub

    Private Sub Button16_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        TextBox1.Text = ("paste text here")
    End Sub

    Private Sub Button17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button17_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button17_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        MsgBox("you have 5 mins to save and close files")

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox4.Text = ("https://avatar-ssl.xboxlive.com/avatar/type-gamertag-here/avatar-body.png")
    End Sub

    Private Sub WebBrowser2_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        WebBrowser2.Navigate(TextBox4.Text)
        WebBrowser3.Navigate(TextBox4.Text)




    End Sub

    Private Sub Button17_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        TextBox4.Text = ("https://avatar-ssl.xboxlive.com/avatar/type-gamertag-here/avatar-body.png")

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        WebBrowser2.Navigate("https://avatar-ssl.xboxlive.com/avatar/t/avatar-body.png")
    End Sub

    Private Sub WebBrowser3_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser3.DocumentCompleted

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button19_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button19_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)

    End Sub

    Private Sub TabPage9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage9.Click
    End Sub

    Private Sub Button19_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        If main_window.MenuStrip1.Text = ("error") Then
            MsgBox("oops! Did you do this? an error stoped main window from opening!")
        Else
            main_window.Show()
        End If

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub
End Class
