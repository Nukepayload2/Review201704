Imports Windows.UI

Public Class RememberedConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        If value Then
            Return New SolidColorBrush(Colors.Green)
        Else
            Return New SolidColorBrush(Colors.Red)
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
