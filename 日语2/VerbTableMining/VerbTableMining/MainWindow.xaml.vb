Imports System.IO

Class MainWindow
    Private Async Sub MainWindow_LoadedAsync(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim vm As New 标准日本语初级上册动词表
        prgProcess.IsIndeterminate = True
        'Await vm.LoadAsync
        'File.WriteAllText("data.json", newtonsoft.json.jsonconvert.Serializeobject(vm))
        Await Task.Run(
            Sub()
                Newtonsoft.Json.JsonConvert.PopulateObject(File.ReadAllText("data.json")， vm)

            End Sub)
        prgProcess.IsIndeterminate = False
    End Sub
End Class
