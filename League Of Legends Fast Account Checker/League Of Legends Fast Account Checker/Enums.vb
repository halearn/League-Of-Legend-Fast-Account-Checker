Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace RitoBot
    Class Enums
        Public Shared champions As Object() = New Object() {"AATROX", "AHRI", "AKALI", "ALISTAR", "AMUMU", "ANIVIA", _
            "ANNIE", "ASHE", "AZIR", "BLITZCRANK", "BRAND", "BRAUM", _
            "CAITLYN", "CASSIOPEIA", "CHOGATH", "CORKI", "DARIUS", "DIANA", _
            "MUNDO", "DRAVEN", "ELISE", "EVELYNN", "EZREAL", "FIDDLESTICKS", _
            "FIORA", "FIZZ", "GALIO", "GANGPLANK", "GAREN", "GNAR", _
            "GRAGAS", "GRAVES", "HECARIM", "HEIMERDIGER", "IRELIA", "JANNA", _
            "JARVAN", "JAX", "JAYCE", "JINX", "KALISTA", "KARMA", _
            "KARTHUS", "KASSADIN", "KATARINA", "KAYLE", "KENNEN", "KHAZIX", _
            "KOGMAW", "LEBLANC", "LEESIN", "LEONA", "LISSANDRA", "LUCIAN", _
            "LULU", "LUX", "MALPHITE", "MALZAHAR", "MAOKAI", "MASTERYI", _
            "MISSFORTUNE", "MORDEKAISER", "MORGANA", "NAMI", "NASUS", "NAUTILUS", _
            "NIDALEE", "NOCTURNE", "NUNU", "OLAF", "ORIANNA", "PANTHEON", _
            "POPPY", "QUINN", "REKSAI", "RAMMUS", "RENEKTON", "RENGAR", _
            "RIVEN", "RUMBLE", "RYZE", "SEJUANI", "SHACO", "SHEN", _
            "SHYVANA", "SINGED", "SION", "SIVIR", "SKARNER", "SONA", _
            "SORAKA", "SWAIN", "SYNDRA", "TALON", "TARIC", "TEEMO", _
            "THRESH", "TRISTANA", "TRUNDLE", "TRYNDAMERE", "TWISTEDFATE", "TWITCH", _
            "UDYR", "URGOT", "VARUS", "VAYNE", "VEIGAR", "VELKOZ", _
            "VI", "VIKTOR", "VLADIMIR", "VOLIBEAR", "WARWICK", "WUKONG", _
            "XERATH", "XINZHAO", "YASUO", "YORICK", "ZAC", "ZED", _
            "ZIGGS", "ZILEAN", "ZYRA"}
        Public Shared queues As Object() = New Object() {"NORMAL_5x5", "NORMAL_3x3", "INTRO_BOT", "BEGINNER_BOT", "MEDIUM_BOT", "ARAM"}
        Public Shared regions As Object() = New Object() {"NA", "EUW", "EUNE", "OCE", "LAN", "LAS", _
            "BR", "TR", "RU", "QQ"}
        Public Shared spells As Object() = New Object() {"BARRIER", "CLAIRVOYANCE", "CLARITY", "CLEANSE", "EXHAUST", "FLASH", _
            "GARRISON", "GHOST", "HEAL", "IGNITE", "REVIVE", "SMITE", _
            "TELEPORT"}
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

        Public Shared Function spellToId(name As String) As Integer
            Select Case name
                Case "BARRIER"
                    Return 21
                Case "CLAIRVOYANCE"
                    Return 2
                Case "CLARITY"
                    Return 13
                Case "CLEANSE"
                    Return 1
                Case "EXHAUST"
                    Return 3
                Case "FLASH"
                    Return 4
                Case "GARRISON"
                    Return 17
                Case "GHOST"
                    Return 6
                Case "HEAL"
                    Return 7
                Case "IGNITE"
                    Return 14
                Case "REVIVE"
                    Return 10
                Case "SMITE"
                    Return 11
                Case "TELEPORT"
                    Return 12
                Case Else
                    Return 0
            End Select
        End Function
    End Class
End Namespace