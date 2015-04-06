Imports PVPNetConnect.PVPNetConnection
Imports PVPNetConnect
Imports PVPNetConnect.RiotObjects.Platform.Clientfacade.Domain
Imports PVPNetConnect.RiotObjects.Platform.Catalog.Champion
Imports Newtonsoft
Imports Newtonsoft.Json.Linq
Imports System.Net

Public Class Form1
    Protected Friend riotapikey As String = "Input your riot developer api key here !"
    Dim connectednow As Boolean
    Public version As String
    Public upurl As String
    Public upavail As Boolean
    Private Async Sub checkforupdate()
        Dim client As WebClient
        Dim url As String = "http://halearn.mzzhost.com/checker.txt"
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(url)
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim update As String = sr.ReadToEnd()
            Dim ve = update.Split("|")
            If ve(0) = Application.ProductVersion Then
                upavail = False
            Else
                upavail = True
                upurl = ve(1)
                version = ve(0)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.SelectedIndex = 0
        Label4.Visible = False
        checkforupdate()
        If upavail Then
            MsgBox("The Program Will Update Now !")
            upform.ShowDialog()
        Else

        End If
    End Sub
    Dim password As String
    Dim username As String
    Dim region As PVPNetConnect.Region
    Public connection As PVPNetConnect.PVPNetConnection
    Function login(ByVal username As String, ByVal password As String, ByRef region As PVPNetConnect.Region)
        connection = New PVPNetConnection
        AddHandler connection.OnLogin, New OnLoginHandler(AddressOf OnLogin)
        AddHandler connection.OnError, New OnErrorHandler(AddressOf OnError)
        connection.Connect(username, password, region, "5.6.15")
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If connectednow Then
            connection.Disconnect()
        Else

        End If
        connectednow = True
        skins.ListView1.Items.Clear()
        champview.ListView1.Items.Clear()
        password = TextBox2.Text
        username = TextBox1.Text
        If ComboBox1.Text = "EUNE" Then region = PVPNetConnect.Region.EUN
        If ComboBox1.Text = "EUW" Then region = PVPNetConnect.Region.EUW
        If ComboBox1.Text = "NA" Then region = PVPNetConnect.Region.NA
        If ComboBox1.Text = "OCE" Then region = PVPNetConnect.Region.OCE
        If ComboBox1.Text = "LAS" Then region = PVPNetConnect.Region.LA1
        If ComboBox1.Text = "LAN" Then region = PVPNetConnect.Region.LA2
        ProgressBar1.Visible = True
        Label4.Visible = True
        Label4.Text = "Status : Authenticating The Account"
        login(username, password, region)
    End Sub
    Function idtochampname(ByVal id As String)
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://global.api.pvp.net/api/lol/static-data/eune/v1.2/champion/" & id & "?champData=stats&api_key=" & riotapikey)
        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim sourcecode As String = sr.ReadToEnd()
        Dim nae = sourcecode.Split(",")
        Dim n As String = nae(2)
        Dim data = n.Split(":")
        Dim nam As String = data(1)
        Dim name As String = nam.Substring(1, nam.Length - 2)
        Return (name)
    End Function
    Private Sub OnError(ByVal sender As Object, ByVal [error] As PVPNetConnect.Error)
        ProgressBar1.Visible = False
        connection.Disconnect()
        connectednow = False
        Select Case [error].Type
            Case ErrorType.AuthKey
                MsgBox("Unable to authenticate , Check password and username Or internet Connection")
                Label4.Text = "Status :  Unable to authenticate"

                Exit Select
            Case ErrorType.Connect
                MsgBox("Unable to connect to PvP.Net")
                Label4.Text = "Status : Unable to connect to PvP.Net"

                Exit Select
            Case ErrorType.Receive
                If ([error].ErrorCode = "LOGIN-0018") Then
                    MsgBox("This account requires a password change in order to login.")
                    Label4.Text = "Status : This account requires a password change in order to login."

                End If
                Exit Select
            Case Else
                MsgBox(String.Format("Unregisted error - Type: {0} - Code: {1}", [error].Type, [error].ErrorCode))
                Label4.Text = ("Status : Unregisted error")
                Exit Select
        End Select
    End Sub
    Public champions As ChampionDTO()
    Private Async Function OnLogin(ByVal sender As Object, ByVal username As String, ByVal ipAddress As String) As Threading.Tasks.Task
        Label4.Text = "Status : Logging in"
        Dim loginPacket As LoginDataPacket = Await connection.GetLoginDataPacketForUser
        If (loginPacket.AllSummonerData Is Nothing) Then
            MsgBox("Summoner not yet created.")
            Label4.Text = "Status : Summoner not yet created."

        End If

        Dim rp As Integer = loginPacket.RpBalance
        Dim ip As Integer = loginPacket.IpBalance
        Dim summonername As String = loginPacket.AllSummonerData.Summoner.Name
        Dim level As Integer = loginPacket.AllSummonerData.SummonerLevel.Level
        Dim summonerid As String = loginPacket.AllSummonerData.SummonerDefaultSpells.SummonerId
        Dim chatris As Integer = loginPacket.RestrictedChatGamesRemaining
        champions = Await connection.GetAvailableChampions
        Dim champcount As Integer = 0
        Dim skincount As Integer = 0

        For Each champ In champions
            If champ.Owned Then
                champcount += 1
                For Each skin As ChampionSkinDTO In champ.ChampionSkins
                    If skin.Owned Then

                        skincount += 1
                    End If
                Next

            End If
        Next
        Label4.Text = "Status : Logged in."
        Label5.Text = "Rp : " & rp
        Label6.Text = "IP : " & ip
        Label7.Text = "Level : " & level
        Label8.Text = "Summoner Name : " & summonername
        Label9.Text = "Summoner ID : " & summonerid
        Label10.Text = "Skins Owned : " & skincount
        Label11.Text = "Champions Owned : " & champcount
        Label12.Text = "Restricted Chat Games Remaining : " & chatris
        Dim dat As Date = loginPacket.AllSummonerData.Summoner.LastGameDate
        Label13.Text = "Laste Game Played On : " & dat.ToString
        ProgressBar1.Visible = False
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            connection.Disconnect()
            connectednow = False
            MsgBox("Disconnected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        champview.ShowDialog()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        skins.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If connectednow Then

            Button2.Enabled = True
        Else
            Button4.Enabled = False
            Button3.Enabled = False
            Button2.Enabled = False
            Button5.Enabled = False

        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("Coming SoonTM...", MsgBoxStyle.Information)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MsgBox("League Of Legends Fast Account Checker , Version 1.0.0.0  By Saeed Suleiman :)" & vbNewLine & "Used PVPNETCONNECT.dll by Snowl for getting all the info , CreepScore.dll For Getting Match History (Soon)")
    End Sub
End Class
