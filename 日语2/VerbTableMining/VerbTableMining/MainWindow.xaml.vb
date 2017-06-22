Imports System.IO
Imports Newtonsoft.Json
Imports VerbTableMining

Class MainWindow
    Private Async Sub MainWindow_LoadedAsync(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim vm As New StdJpnVerbs1aViewModel
        prgProcess.IsIndeterminate = True
        'Await vm.LoadAsync
        'File.WriteAllText("data.json", newtonsoft.json.jsonconvert.Serializeobject(vm))
        Await Task.Run(
            Sub()
                'JsonConvert.PopulateObject(File.ReadAllText("data.json")， vm)
                'File.WriteAllText("refined.json", JsonConvert.SerializeObject(vm.Refine))
                'Dim refined As New RefinedVerbs
                'JsonConvert.PopulateObject(File.ReadAllText("refined.json"), refined)
                'Dim refined5Kinds As New RefinedFiveKindVerbs
                'VerbGroupConverter.转换为五类动词表(refined, refined5Kinds)
                'File.WriteAllText("refined5kinds.json", JsonConvert.SerializeObject(refined5Kinds))

            End Sub)
        Await Vocabulary.RefineAsync
        prgProcess.IsIndeterminate = False
    End Sub
End Class
