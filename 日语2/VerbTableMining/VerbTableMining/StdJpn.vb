Public Module StdJpn
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
        {"か", "ka"}, {"き", "ku"}, {"く", "ko"},
        {"さ", "sa"}, {"し", "su"}, {"す", "so"},
        {"な", "na"}, {"に", "nu"}, {"ぬ", "no"},
        {"は", "ha"}, {"ひ", "hu"}, {"ふ", "fo"},
        {"ま", "ma"}, {"み", "mu"}, {"む", "mo"},
        {"や", "ya"}, {"ゆ", "yu"}, {"よ", "yo"}
    }
End Module
