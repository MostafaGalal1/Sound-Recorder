Public NotInheritable Class SplashScreen1
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        Timer4.Start()
        Timer1.Interval = 900
        Timer2.Interval = 2780
        Timer3.Interval = 3230
        Timer4.Interval = 3540
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = "Initializing UI..."
        Timer1.Stop()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label4.Text = "Initializing Components..."
        Timer2.Stop()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label4.Text = "Building Interface..."
        Timer3.Stop()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        form1.Show()
        Me.Hide()
        Timer4.Stop()
    End Sub
End Class
