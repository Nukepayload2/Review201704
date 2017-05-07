Imports Nukepayload2.OfficeHelper.ExcelFileHelper
Public Class 标准日本语初级上册动词表
    Public Property 一类 As 标准日本语初级上册动词表_一类()
    Public Property 二类 As 标准日本语初级上册动词表_二类()
    Public Property 三类 As 标准日本语初级上册动词表_三类()
    Public Async Function LoadAsync() As Task
        一类 = Await LoadFromXlsxAsync(Of 标准日本语初级上册动词表_一类)("C:\Users\James\OneDrive\标准日本语初级上册动词表.xlsx", "一类")
        二类 = Await LoadFromXlsxAsync(Of 标准日本语初级上册动词表_二类)("C:\Users\James\OneDrive\标准日本语初级上册动词表.xlsx", "二类")
        三类 = Await LoadFromXlsxAsync(Of 标准日本语初级上册动词表_三类)("C:\Users\James\OneDrive\标准日本语初级上册动词表.xlsx", "三类")
    End Function
End Class