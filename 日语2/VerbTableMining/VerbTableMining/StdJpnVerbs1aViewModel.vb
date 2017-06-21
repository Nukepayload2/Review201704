Imports Nukepayload2.OfficeHelper.ExcelFileHelper

Public Class StdJpnVerbs1aViewModel

    Public Property 一类 As Verb()
    Public Property 二类 As Verb()
    Public Property 三类 As Verb()

    Public Async Function LoadAsync() As Task
        一类 = Await LoadFromXlsxAsync(Of Verb)("C:\Users\James\OneDrive\标准日本语初级上册动词表.xlsx", "一类")
        二类 = Await LoadFromXlsxAsync(Of Verb)("C:\Users\James\OneDrive\标准日本语初级上册动词表.xlsx", "二类")
        三类 = Await LoadFromXlsxAsync(Of Verb)("C:\Users\James\OneDrive\标准日本语初级上册动词表.xlsx", "三类")
    End Function

    Public Function Refine() As RefinedVerbs
        Dim result As New RefinedVerbs
        With result
            .一类 = Aggregate verb In 一类 Select CustomVerbRefinery.Refine(verb) Into ToArray
            .二类 = Aggregate verb In 二类 Select CustomVerbRefinery.Refine(verb) Into ToArray
            .三类 = Aggregate verb In 三类 Select CustomVerbRefinery.Refine(verb) Into ToArray
        End With
        Return result
    End Function
End Class