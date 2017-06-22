Friend Class VerbGroupConverter

    Friend Shared Sub 转换为五类动词表(书后动词表 As RefinedVerbs, 五类动词表 As RefinedFiveKindVerbs)
        With 五类动词表
            .五段 = 书后动词表.一类
            Dim 一段 = (
                      From 单词 In 书后动词表.二类
                      Let 基本型 = 单词.无汉字版本.基本形
                      Let 判定字 = 基本型.Substring(基本型.Length - 2).First
                      Let 判定字罗马音标 = 假名到罗马音标(判定字)).
                      分两组(Function(c) c.判定字罗马音标.EndsWith("i"), Function(c) c.单词)
            .上一段 = 一段.trueGroup.ToArray
            .下一段 = 一段.falseGroup.ToArray
            Dim 三类 = (
                      From 单词 In 书后动词表.三类
                      Let 基本型 = 单词.无汉字版本.基本形).
                      分两组(Function(c) c.基本型 = "くる", Function(c) c.单词)
            .か变 = 三类.trueGroup.ToArray
            .さ变 = 三类.falseGroup.ToArray
        End With
    End Sub
End Class
