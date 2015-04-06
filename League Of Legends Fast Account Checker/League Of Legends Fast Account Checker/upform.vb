Imports System.Net

Public Class upform

    Private Sub update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Updater - " & Form1.version
        update(Form1.upurl, Application.StartupPath & "\up.exe")

    End Sub
    Public Async Function update(ByVal url As String, ByVal place As String) As Threading.Tasks.Task
        Dim client As WebClient = New WebClient
        AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
        client.DownloadFileAsync(New Uri(url), place)
    End Function
    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
            Dim percentage As Double = bytesIn / totalBytes * 100
            ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
        Catch

        End Try
    End Sub
    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Process.Start(Application.StartupPath & "\up.exe")
        Me.Close()
        Form1.Close()
        skins.Close()
        champview.Close()

    End Sub
End Class