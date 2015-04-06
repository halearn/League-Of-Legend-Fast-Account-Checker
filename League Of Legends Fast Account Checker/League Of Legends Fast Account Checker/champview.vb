Imports PVPNetConnect.RiotObjects.Platform.Catalog.Champion

Public Class champview

    Private Sub champview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each champ In Form1.champions
            If champ.Owned Then

                ListView1.Items.Add(idtochampname(champ.ChampionId))

            End If
        Next
    End Sub
    Function idtochampname(ByVal id As String)
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://global.api.pvp.net/api/lol/static-data/eune/v1.2/champion/" & id & "?champData=stats&api_key=" & Form1.riotapikey)
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

    Public choosenchamp As Integer
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            choosenchamp = ListView1.SelectedIndices(0)
        Catch ex As Exception
        End Try
    End Sub

   
    Public Shared Function championToId(name As String) As Integer
        Select Case name

            Case "AATROX"
                Return 266
            Case "AHRI"
                Return 103
            Case "AKALI"
                Return 84
            Case "ALISTAR"
                Return 12
            Case "AMUMU"
                Return 32
            Case "ANIVIA"
                Return 34
            Case "ANNIE"
                Return 1
            Case "ASHE"
                Return 22
            Case "AZIR"
                Return 268
            Case "BLITZCRANK"
                Return 53
            Case "BRAND"
                Return 63
            Case "BRAUM"
                Return 201
            Case "CAITLYN"
                Return 51
            Case "CASSIOPEIA"
                Return 69
            Case "CHOGATH"
                Return 31
            Case "CORKI"
                Return 42
            Case "DARIUS"
                Return 122
            Case "DIANA"
                Return 131
            Case "MUNDO"
                Return 36
            Case "DRAVEN"
                Return 119
            Case "ELISE"
                Return 60
            Case "EVELYNN"
                Return 28
            Case "EZREAL"
                Return 81
            Case "FIDDLESTICKS"
                Return 9
            Case "FIORA"
                Return 114
            Case "FIZZ"
                Return 105
            Case "GALIO"
                Return 3
            Case "GANGPLANK"
                Return 41
            Case "GAREN"
                Return 86
            Case "GNAR"
                Return 150
            Case "GRAGAS"
                Return 79
            Case "GRAVES"
                Return 104
            Case "HECARIM"
                Return 120
            Case "HEIMERDIGER"
                Return 74
            Case "IRELIA"
                Return 39
            Case "JANNA"
                Return 40
            Case "JARVAN"
                Return 59
            Case "JAX"
                Return 24
            Case "JAYCE"
                Return 126
            Case "JINX"
                Return 222
            Case "KALISTA"
                Return 429
            Case "KARMA"
                Return 43
            Case "KARTHUS"
                Return 30
            Case "KASSADIN"
                Return 38
            Case "KATARINA"
                Return 55
            Case "KAYLE"
                Return 10
            Case "KENNEN"
                Return 85
            Case "KHAZIX"
                Return 121
            Case "KOGMAW"
                Return 96
            Case "LEBLANC"
                Return 7
            Case "LEESIN"
                Return 64
            Case "LEONA"
                Return 89
            Case "LISSANDRA"
                Return 127
            Case "LUCIAN"
                Return 236
            Case "LULU"
                Return 117
            Case "LUX"
                Return 99
            Case "MALPHITE"
                Return 54
            Case "MALZAHAR"
                Return 90
            Case "MAOKAI"
                Return 57
            Case "MASTERYI"
                Return 11
            Case "MISSFORTUNE"
                Return 21
            Case "MORDEKAISER"
                Return 82
            Case "MORGANA"
                Return 25
            Case "NAMI"
                Return 267
            Case "NASUS"
                Return 75
            Case "NAUTILUS"
                Return 111
            Case "NIDALEE"
                Return 76
            Case "NOCTURNE"
                Return 56
            Case "NUNU"
                Return 20
            Case "OLAF"
                Return 2
            Case "ORIANNA"
                Return 61
            Case "PANTHEON"
                Return 80
            Case "POPPY"
                Return 78
            Case "QUINN"
                Return 133
            Case "REKSAI"
                Return 421
            Case "RAMMUS"
                Return 33
            Case "RENEKTON"
                Return 58
            Case "RENGAR"
                Return 107
            Case "RIVEN"
                Return 92
            Case "RUMBLE"
                Return 68
            Case "RYZE"
                Return 13
            Case "SEJUANI"
                Return 113
            Case "SHACO"
                Return 35
            Case "SHEN"
                Return 98
            Case "SHYVANA"
                Return 102
            Case "SINGED"
                Return 27
            Case "SION"
                Return 14
            Case "SIVIR"
                Return 15
            Case "SKARNER"
                Return 72
            Case "SONA"
                Return 37
            Case "SORAKA"
                Return 16
            Case "SWAIN"
                Return 50
            Case "SYNDRA"
                Return 134
            Case "TALON"
                Return 91
            Case "TARIC"
                Return 44
            Case "TEEMO"
                Return 17
            Case "THRESH"
                Return 412
            Case "TRISTANA"
                Return 18
            Case "TRUNDLE"
                Return 48
            Case "TRYNDAMERE"
                Return 23
            Case "TWISTEDFATE"
                Return 4
            Case "TWITCH"
                Return 29
            Case "UDYR"
                Return 77
            Case "URGOT"
                Return 6
            Case "VARUS"
                Return 110
            Case "VAYNE"
                Return 67
            Case "VEIGAR"
                Return 45
            Case "VELKOZ"
                Return 161
            Case "VI"
                Return 254
            Case "VIKTOR"
                Return 112
            Case "VLADIMIR"
                Return 8
            Case "VOLIBEAR"
                Return 106
            Case "WARWICK"
                Return 19
            Case "WUKONG"
                Return 62
            Case "XERATH"
                Return 101
            Case "XINZHAO"
                Return 5
            Case "YASUO"
                Return 157
            Case "YORICK"
                Return 83
            Case "ZAC"
                Return 154
            Case "ZED"
                Return 238
            Case "ZIGGS"
                Return 115
            Case "ZILEAN"
                Return 26
            Case "ZYRA"
                Return 143
            Case Else
                Return 0
        End Select
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
      

    End Sub
End Class