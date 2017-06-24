Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class Vocabulary

    Public Shared Async Function RefineAsync() As Task
        Dim markdowns = Aggregate fn In Enumerable.Range(8, 13)
                        Select $"G:\vs2017\Review201704\日语2\单词{fn.ToString("00")}.md" Into ToArray
        Await RefineAsync(markdowns)
    End Function

    Public Shared Async Function RefineAsync(markdowns As String()) As Task
        Await Task.Run(
            Sub()
                Dim contents = Aggregate md In markdowns.AsParallel
                               Let fileContent = File.ReadAllText(md, Encoding.UTF8)
                               Let lines = fileContent.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries).Skip(2)
                               Select md, Content = Aggregate line In lines
                                                    Select VocabularyItem.ParseLine(line) Into ToArray
                               Into ToArray
                File.WriteAllText("vocabulary8to20.json", JsonConvert.SerializeObject(contents))
            End Sub)
    End Function
End Class
