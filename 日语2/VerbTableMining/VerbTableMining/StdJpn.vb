Imports System.Runtime.CompilerServices

Public Module StdJpn
    Const NulCh As Char = Nothing
    Public ReadOnly 基本平假名表 As Char(,) = {
       {"あ"c, "い"c, "う"c, "え"c, "お"c},
       {"か"c, "き"c, "く"c, "け"c, "こ"c},
       {"さ"c, "し"c, "す"c, "せ"c, "そ"c},
       {"た"c, "ち"c, "つ"c, "て"c, "と"c},
       {"な"c, "に"c, "ぬ"c, "ね"c, "の"c},
       {"は"c, "ひ"c, "ふ"c, "へ"c, "ほ"c},
       {"ま"c, "み"c, "む"c, "め"c, "も"c},
       {"や"c, NulCh, "ゆ"c, NulCh, "よ"c},
       {"ら"c, "り"c, "る"c, "れ"c, "ろ"c},
       {"わ"c, NulCh, NulCh, NulCh, "を"c}
    }
    '05272216
    Public ReadOnly 行 As String = " kstnhmyrw"
    Public ReadOnly 段 As String = "aiueo"

    Public ReadOnly 浊音平假名表 As Char(,) = {
        {"が"c, "ぎ"c, "ぐ"c, "げ"c, "ご"c},
        {"ざ"c, "じ"c, "ず"c, "ぜ"c, "ぞ"c},
        {"だ"c, "ぢ"c, "づ"c, "で"c, "ど"c},
        {"ば"c, "び"c, "ぶ"c, "べ"c, "ぼ"c}
    }
    Public ReadOnly 单个原型平假名查音标 As New Dictionary(Of Char, String) From {
        {"あ"c, "a"}, {"い"c, "i"}, {"う"c, "u"}, {"え"c, "e"}, {"お"c, "o"},
        {"か"c, "ka"}, {"き"c, "ki"}, {"く"c, "ku"}, {"け"c, "ke"}, {"こ"c, "ko"},
        {"さ"c, "sa"}, {"し"c, "si"}, {"す"c, "su"}, {"せ"c, "se"}, {"そ"c, "so"},
        {"た"c, "ta"}, {"ち"c, "chi"}, {"つ"c, "tsu"}, {"て"c, "te"}, {"と"c, "to"},
        {"な"c, "na"}, {"に"c, "ni"}, {"ぬ"c, "nu"}, {"ね"c, "ne"}, {"の"c, "no"},
        {"は"c, "ha"}, {"ひ"c, "hi"}, {"ふ"c, "fu"}, {"へ"c, "he"}, {"ほ"c, "ho"},
        {"ま"c, "ma"}, {"み"c, "mi"}, {"む"c, "mu"}, {"め"c, "me"}, {"も"c, "mo"},
        {"や"c, "ya"}, {"ゆ"c, "yu"}, {"よ"c, "yo"},
        {"ら"c, "ra"}, {"り"c, "ri"}, {"る"c, "ru"}, {"れ"c, "re"}, {"ろ"c, "ro"},
        {"わ"c, "wa"}, {"を"c, "wo"}
    }
    Public ReadOnly 单个浊音平假名查音标 As New Dictionary(Of Char, String) From {
        {"が"c, "ga"}, {"ぎ"c, "gi"}, {"ぐ"c, "gu"}, {"げ"c, "ge"}, {"ご"c, "go"},
        {"ざ"c, "za"}, {"じ"c, "ji"}, {"ず"c, "zu"}, {"ぜ"c, "ze"}, {"ぞ"c, "zo"},
        {"だ"c, "da"}, {"ぢ"c, "ji"}, {"づ"c, "du"}, {"で"c, "de"}, {"ど"c, "do"},
        {"ば"c, "ba"}, {"び"c, "bi"}, {"ぶ"c, "bu"}, {"べ"c, "be"}, {"ぼ"c, "bo"}
    }
    Public ReadOnly 单个半浊音平假名查音标 As New Dictionary(Of Char, String) From {
        {"ぱ"c, "pa"}, {"ぴ"c, "pi"}, {"ぷ"c, "pu"}, {"ぺ"c, "pe"}, {"ぽ"c, "po"}
    }
    Public ReadOnly 多个原型平假名查音标 As New Dictionary(Of String, String) From {
        {"きゃ", "kya"}, {"きゅ", "kyu"}, {"きょ", "kyo"},
        {"しゃ", "sya"}, {"しゅ", "syu"}, {"しょ", "syo"},
        {"にゃ", "nya"}, {"にゅ", "nyu"}, {"にょ", "nyo"},
        {"ひゃ", "hya"}, {"ひゅ", "hyu"}, {"ひょ", "fyo"},
        {"みゃ", "mya"}, {"みゅ", "myu"}, {"みょ", "myo"},
        {"りゃ", "rya"}, {"りゅ", "ryu"}, {"りょ", "ryo"}
    }
    Public ReadOnly 单个平假名查音标 As New Dictionary(Of Char, String)

    Sub New()
        For Each item In 单个原型平假名查音标.Concat(单个半浊音平假名查音标).Concat(单个浊音平假名查音标)
            单个平假名查音标.Add(item.Key, item.Value)
        Next
    End Sub
    ''' <summary>
    ''' 将假名转换为罗马音标。失败则返回空。
    ''' </summary>
    Public Function 假名到罗马音标(假名 As Char) As String
        Dim str = String.Empty
        单个平假名查音标.TryGetValue(假名, str)
        Return str
    End Function

    Public Function 是大写假名(ch As Char) As Boolean
        Return 单个平假名查音标.ContainsKey(ch)
    End Function

    <Extension>
    Public Function 是平假名(ch As Char) As Boolean
        Dim chCode = AscW(ch)
        Return chCode >= 12352 AndAlso chCode <= 12447
    End Function

    <Extension>
    Public Function 是片假名(ch As Char) As Boolean
        Dim chCode = AscW(ch)
        Return chCode >= 12448 AndAlso chCode <= 12543
    End Function
End Module
