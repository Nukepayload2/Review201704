Imports System.IO
Imports Newtonsoft.Json

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
                Dim refined As New RefinedVerbs
                JsonConvert.PopulateObject(File.ReadAllText("data.json"), refined)

            End Sub)
        prgProcess.IsIndeterminate = False
    End Sub
End Class
