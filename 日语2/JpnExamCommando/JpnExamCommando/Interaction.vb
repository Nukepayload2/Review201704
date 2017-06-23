#If WINDOWS_UWP Then
Imports Windows.UI.Popups
Public Module Interaction
    Public Async Function MsgBoxAsync(Prompt$, Optional HasCancel As Boolean = False, Optional Title$ = Nothing, Optional OK$ = "确定", Optional Cancel$ = "取消") As Task(Of Boolean?)
        If Title Is Nothing Then
            Title = Package.Current.DisplayName
        End If
        Dim dlg As New MessageDialog(Prompt, Title)
        Dim Result As Boolean?
        Dim msg As New MessageDialog(Prompt, Title)
        msg.Commands.Add(New UICommand(OK, Sub(command) Result = True))
        msg.DefaultCommandIndex = 0
        If HasCancel Then
            msg.Commands.Add(New UICommand(Cancel, Sub(command) Result = False))
            msg.CancelCommandIndex = 1
        End If
        Dim tsk = msg.ShowAsync
        Await tsk
        Return Result
    End Function

    Public Sub SaveSetting(Of T)(Section$, Key$, Value As T)
        Dim sto = Windows.Storage.ApplicationData.Current.LocalSettings.Values
        Dim Name = Section & "\" & Key
        If sto.ContainsKey(Name) Then
            sto(Name) = Value
        Else
            sto.Add(Name, Value)
        End If
    End Sub

    Public Sub DeleteSetting(Section$, Key$)
        Dim sto = Windows.Storage.ApplicationData.Current.LocalSettings.Values
        Dim Name = Section & "\" & Key
        If sto.ContainsKey(Name) Then sto.Remove(Name)
    End Sub

    Public Function LoadSetting(Of T)(Section$, Key$, Optional DefaultValue As T = Nothing) As T
        Dim sto = Windows.Storage.ApplicationData.Current.LocalSettings.Values
        Dim Name = Section & "\" & Key
        If sto.ContainsKey(Name) Then
            Dim v = sto(Name)
            If TypeOf v Is T Then
                Return DirectCast(v, T)
            Else
                Return DefaultValue
            End If
        End If
        Return DefaultValue
    End Function
End Module
#End If