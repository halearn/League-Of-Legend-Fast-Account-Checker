Imports PVPNetConnect
Imports PVPNetConnect.RiotObjects
Imports PVPNetConnect.RiotObjects.Platform.Catalog.Champion
Imports PVPNetConnect.RiotObjects.Platform.Catalog


Public Class skins
    Public champ As String
    Function idtoskinname(ByRef champid As String, ByVal id As String)
        Dim url As String = "https://global.api.pvp.net/api/lol/static-data/eune/v1.2/champion/" & champid & "?champData=skins&api_key=" & Form1.riotapikey
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)
        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim sourcecode As String = sr.ReadToEnd()
        Dim all = sourcecode.Split("{")
     
        Dim semi As String
        For Each word In all
            If word.Contains(id) Then
                semi = word
            Else

            End If
        Next
        Dim ss = semi.Split(",")
        Dim name As String = ss(1)
        Dim final = name.Split(":")
        Dim skinname As String = final(1).Substring(1, final(1).Length - 2)
        Return (skinname)
    End Function
    Private Sub skins_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Me.Text = "Skins of " & champ
        For Each champi In Form1.champions
            If champi.Owned Then
                For Each skin As ChampionSkinDTO In champi.ChampionSkins
                    If skin.Owned Then
                        ListView1.Items.Add(idtoskinname(champi.ChampionId, skin.SkinId))
                    Else

                    End If

                Next

            End If
        Next


    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
     
        ' 
    End Sub
End Class