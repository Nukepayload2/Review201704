' https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

Imports Newtonsoft.Json
Imports Windows.Storage
''' <summary>
''' 可用于自身或导航至 Frame 内部的空白页。
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Async Sub MainPage_LoadedAsync(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim json = Await FileIO.ReadTextAsync(Await StorageFile.GetFileFromApplicationUriAsync(New Uri("ms-appx:///vocabulary8to20.json")))
        Dim obj = JsonConvert.DeserializeObject(Of VocabularyCourse())(json)

    End Sub
End Class
