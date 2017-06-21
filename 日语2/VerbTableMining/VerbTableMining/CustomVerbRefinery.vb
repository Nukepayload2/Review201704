Imports System.Text.RegularExpressions

Public Class CustomVerbRefinery

    Shared 汉字正则 As New Regex("\w+(?=（)", RegexOptions.Compiled)
    Shared 汉字假名正则 As New Regex("(?<=（)\w+(?=）)", RegexOptions.Compiled)
    Shared 假名部分正则 As New Regex("(?<=）)\w+", RegexOptions.Compiled)

    Public Shared Function Refine(data As Verb) As RefinedVerb
        If data Is Nothing Then
            Throw New ArgumentNullException(NameOf(data))
        End If
        Dim ます形 = data.ます形
        Dim result As New RefinedVerb
        Dim 无汉字 = result.无汉字版本
        If ます形.Contains("（") Then
            Dim 汉字 = 汉字正则.Match(ます形).Value
            If String.IsNullOrEmpty(汉字) Then
                Throw New NotSupportedException("不能提取汉字。内容是: " & ます形)
            End If
            Dim 汉字假名 = 汉字假名正则.Match(ます形).Value
            If String.IsNullOrEmpty(汉字假名) Then
                Throw New NotSupportedException("不能提取汉字假名。内容是: " & ます形)
            End If
            Dim ます假名部分 = 假名部分正则.Match(ます形).Value
            If String.IsNullOrEmpty(ます假名部分) Then
                Throw New NotSupportedException("不能提取假名部分。内容是: " & ます形)
            End If

            Dim 有汉字 = result.有汉字版本

            Dim 非ます变形 =
                Sub(数据形式$, ByRef 有汉字形式$, ByRef 无汉字形式$)
                    If 数据形式.StartsWith(汉字) Then
                        有汉字形式 = 数据形式
                        无汉字形式 = 汉字假名 + 数据形式.Substring(汉字.Length)
                    Else
                        无汉字形式 = 数据形式
                        有汉字形式 = 汉字 + 数据形式.Substring(汉字假名.Length)
                    End If
                End Sub

            非ます变形(data.て形, 有汉字.て形, 无汉字.て形)
            非ます变形(data.た形, 有汉字.た形, 无汉字.た形)
            非ます变形(data.ない形, 有汉字.ない形, 无汉字.ない形)
            非ます变形(data.基本形, 有汉字.基本形, 无汉字.基本形)

            有汉字.ます形 = 汉字 + ます假名部分
            无汉字.ます形 = 汉字假名 + ます假名部分
        Else
            With 无汉字
                .た形 = data.た形
                .て形 = data.て形
                .ない形 = data.ない形
                .ます形 = data.ます形
                .基本形 = data.基本形
            End With
        End If
        Return result
    End Function

End Class
