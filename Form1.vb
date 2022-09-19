Option Explicit On
Option Strict Off
Imports System.ComponentModel
Imports WindowsApplication26.SampleAudioAPI
Public Class form1
    Dim hh As String
    Dim n As String = 1
    Dim y As Integer
    Dim yy As Integer
    Dim yyy As Integer
    Dim yyyy As Integer
    Dim yyyyy As Integer
    Dim yyyyyy As Integer
    Dim koll As String
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Private AudioAPI As New SampleAudioAPI()
    Private WithEvents Observer As New System.Windows.Forms.Timer() With {.Interval = 10, .Enabled = True}

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MICROPHONE_BAR.Maximum = 100
    End Sub
    Private Sub Start(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplashScreen1.Show()
        IN_MasterScalarValue = AudioAPI.IN_MasterScalar
        RaiseEvent MicrophoneValueChanged(IN_MasterScalarValue)
        OUT_MasterScalarValue = AudioAPI.OUT_MasterScalar
        RaiseEvent SpeakersValueChanged(OUT_MasterScalarValue)

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.SendToBack()
        Button1.Height = 23
        Button1.Width = 107
        Button2.BringToFront()
        Button2.Visible = True
        Label2.BringToFront()
        Label3.BringToFront()
        Label4.BringToFront()
        Label4.Show()
        Label5.BringToFront()
        Label6.BringToFront()
        PictureBox1.SendToBack()
        PictureBox2.BringToFront()
        Timer1.Start()
        Timer1.Interval = 1000
        mciSendString("open new Type waveaudio Alias j", "", 0, 0)
        mciSendString("record j", "", 0, 0)
        Button4.Visible = False
        PictureBox3.Visible = False
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox1.BringToFront()
        SaveFileDialog1.Filter = "Windows Media Audio File|*.wav"
        Timer1.Stop()
        Button1.Text = "Resume Recording"
        PictureBox1.BringToFront()
        Label4.Hide()
        Button1.BringToFront()
        Label2.BringToFront()
        Label3.BringToFront()
        Label5.BringToFront()
        Label6.BringToFront()
        Button1.Height = 23
        Button1.Width = 122
        PictureBox1.BringToFront()
        PictureBox2.SendToBack()
        mciSendString("pause j", "", 0, 0)
        Button2.SendToBack()
        My.Computer.Audio.Stop()
        Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        SaveFileDialog1.ShowDialog()
        Label2.BringToFront()
        Label3.BringToFront()
        Label4.BringToFront()
        Label5.BringToFront()
        Label6.BringToFront()
        Button2.Visible = False
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        y = y + 1
        Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        If y = 10 Then
            y = 0
            yy = yy + 1
            Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        End If
        If yy = 6 Then
            yy = 0
            yyy = yyy + 1
            Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        End If
        If yyy = 10 Then
            yyy = 0
            yyyy = yyyy + 1
            Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        End If
        If yyyy = 6 Then
            yyyy = 0
            yyyyy = yyyyy + 1
            Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        End If
        If yyyyy = 6 Then
            yyyyy = 0
            yyyyyy = yyy + 1
            Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        End If
        If yyyyyy = 6 Then
            Timer1.Stop()
            Label1.Text = yyyyyy & yyyyy & ":" & yyyy & yyy & ":" & yy & y
        End If

    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles SaveFileDialog1.FileOk
        Label2.BringToFront()
        Label3.BringToFront()
        Label4.BringToFront()
        Label4.Show()
        Label5.BringToFront()
        Label6.BringToFront()
        n = n + 1
        Dim j As String
        Button1.Height = 23
        Button1.Width = 107
        hh = SaveFileDialog1.FileName
        j = System.IO.Path.GetFileName(SaveFileDialog1.FileName)
        Button1.Text = "Start Recording"
        PictureBox1.BringToFront()
        PictureBox2.SendToBack()
        Button2.Text = "Stop Recording"
        mciSendString("save j " + SaveFileDialog1.FileName, "", 0, 0)
        mciSendString("close j", "", 0, 0)
        SaveFileDialog1.FileName = "Untitled(" + n + ")"
        Label1.Text = "00:00:00"
        y = 0
        yy = 0
        yyy = 0
        yyyy = 0
        yyyyy = 0
        yyyyyy = 0
        Label2.BringToFront()
        Label3.BringToFront()
        Label4.BringToFront()
        Label4.Show()
        Label5.BringToFront()
        Label6.BringToFront()
        Button4.Visible = True
        PictureBox3.Visible = True
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveFileDialog1.FileName = "Untitled(" + n + ")"
        VPB_IN_MASTER.Value = SingleToIntPercentage(AudioAPI.Value(Channels.IN_Master, _SMOOTHTRANSITION))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Computer.Audio.Play(hh)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Form2.Label8.Visible = True Then
            Form2.Label1.Focus()
            Microsoft.VisualBasic.Beep()
        End If
        Form2.Show()
        Form2.Label8.Visible = True
        If Form3.Label1.Visible = True Then
            Form3.Label1.Focus()
            Microsoft.VisualBasic.Beep()
        End If
    End Sub
    Private Sub Observer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Observer.Tick
        If Not ((MICROPHONE.Checked = False) And (AudioAPI.IN_MUTE = True)) Then
            MICROPHONE.Checked = If(AudioAPI.IN_MUTE = True, False, True)
        End If
        If Not (OUT_MasterScalarValue = AudioAPI.OUT_MasterScalar) Then RaiseEvent SpeakersValueChanged(AudioAPI.OUT_MasterScalar)
        If Not (IN_MasterScalarValue = AudioAPI.IN_MasterScalar) Then RaiseEvent MicrophoneValueChanged(AudioAPI.IN_MasterScalar)
        Refresher()
    End Sub
    Private IN_MasterScalarValue As Single = 0.0F
    Private OUT_MasterScalarValue As Single = 0.0F
    Private Event MicrophoneValueChanged(ByVal value As Single)
    Private Event SpeakersValueChanged(ByVal value As Single)
    Private Sub Microphone_ValueChanged(ByVal value As Single) Handles Me.MicrophoneValueChanged
        IN_MasterScalarValue = value
        MICROPHONE_BAR.Value = (SingleToIntPercentage(value))
    End Sub
    Dim _SMOOTHTRANSITION As Boolean = True
    Private Sub Refresher()
        VPB_IN_MASTER.Value = SingleToIntPercentage(AudioAPI.Value(Channels.IN_Master, _SMOOTHTRANSITION))
    End Sub
    Private Sub Microphone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MICROPHONE.CheckedChanged
        AudioAPI.IN_MUTE = If(MICROPHONE.Checked = True, False, True)
    End Sub
    Private Sub Microphone_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MICROPHONE_BAR.Scroll
        AudioAPI.IN_MasterScalar = IntToSinglePercentage(MICROPHONE_BAR.Value)
    End Sub
End Class
