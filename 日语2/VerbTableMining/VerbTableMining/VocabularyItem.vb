Public Class VocabularyItem
    Public Property 假名 As String
    Public Property 日文汉字 As String
    Public Property 翻译 As String
    Public Property 词性 As String

    Shared s_wdTable As New Dictionary(Of String, 词汇分类) From {
        {"n", 词汇分类.名词}, {"adj1", 词汇分类.形容词1}, {"adj2", 词汇分类.形容词2},
        {"v1", 词汇分类.动词1}, {"v2", 词汇分类.动词2}, {"v3", 词汇分类.动词3},
        {"v5", 词汇分类.五段动词}, {"v1i", 词汇分类.上一段动词}, {"v1e", 词汇分类.下一段动词},
        {"vs", 词汇分类.さ变动词}, {"vk", 词汇分类.か变动词}, {"int", 词汇分类.叹词},
        {"cmp", 词汇分类.课本未分类的词或合成词}, {"pri", 词汇分类.专有词}, {"conj", 词汇分类.连词},
        {"qua", 词汇分类.量词}, {"pron", 词汇分类.代词}, {"que", 词汇分类.疑问词}, {"adv", 词汇分类.副词}
    }

    Public Shared Function ParseLine(line As String) As VocabularyItem
        If String.IsNullOrEmpty(line) Then
            Throw New ArgumentException(NameOf（line))
        End If
        Dim items = line.Split("|"c)
        If items.Length <> 6 Then
            Throw New ArgumentException(NameOf(line))
        End If
        Dim 词性 = s_wdTable(items(4))
        Dim 词性结果$
        Dim 有汉字 As Boolean
        Dim 没假名 As Boolean
        Dim 有平假名 As Boolean
        Dim 有片假名 As Boolean
        Select Case 词性
            Case 词汇分类.名词
                有汉字 = Not String.IsNullOrWhiteSpace(items(2))
                If 有汉字 Then
                    没假名 = 0 = Aggregate ch In items(2) Where ch.是平假名 OrElse ch.是片假名 Into Count
                End If
                ' 确定词性
                If 有汉字 Then
                    有平假名 = 0 < Aggregate ch In items(2) Where Not Char.IsSymbol(ch) AndAlso
                                        Not Char.IsWhiteSpace(ch) AndAlso ch.是平假名 Into Count
                    有片假名 = 0 < Aggregate ch In items(2) Where Not Char.IsSymbol(ch) AndAlso
                                        Not Char.IsWhiteSpace(ch) AndAlso ch.是片假名 Into Count
                    If 没假名 Then
                        词性结果 = "纯汉字名词"
                    Else
                        If 有平假名 Then
                            If 有片假名 Then
                                词性结果 = "带汉字平假名片假名名词"
                            Else
                                词性结果 = "带汉字平假名名词"
                            End If
                        Else
                            If 有片假名 Then
                                词性结果 = "带汉字片假名名词"
                            Else
                                Throw New ArgumentException(NameOf(line))
                            End If
                        End If
                    End If
                Else
                    有平假名 = 0 < Aggregate ch In items(1) Where Not Char.IsSymbol(ch) AndAlso
                                            Not Char.IsWhiteSpace(ch) AndAlso ch.是平假名 Into Count
                    有片假名 = 0 < Aggregate ch In items(1) Where Not Char.IsSymbol(ch) AndAlso
                                            Not Char.IsWhiteSpace(ch) AndAlso ch.是片假名 Into Count
                    If 有平假名 Then
                        If 有片假名 Then
                            词性结果 = "平假名片假名名词"
                        Else
                            词性结果 = "纯平假名名词"
                        End If
                    Else
                        If 有片假名 Then
                            词性结果 = "纯片假名名词"
                        Else
                            Throw New ArgumentException(NameOf(line))
                        End If
                    End If
                End If
            Case Else
                词性结果 = 词性.ToString
        End Select
        If 词性 = 词汇分类.名词 Then
        Else
        End If
        Return New VocabularyItem With {
            .假名 = items(1), .日文汉字 = items(2), .翻译 = items(3), .词性 = 词性结果
        }
    End Function
End Class
