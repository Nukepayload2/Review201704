Imports System.Runtime.CompilerServices

Module LineExtension
    ''' <summary>
    ''' 如果满足条件，则分到第一个组。否则分到第二个组。
    ''' </summary>
    <Extension>
    Function 分两组(Of TCondiction, TResult)(seq As IEnumerable(Of TCondiction),
                                            predic As Predicate(Of TCondiction),
                                            selector As Func(Of TCondiction, TResult)) As (
                                            trueGroup As List(Of TResult),
                                            falseGroup As List(Of TResult))
        Dim trueG As New List(Of TResult), falseG As New List(Of TResult)
        For Each o In seq
            If predic(o) Then
                trueG.Add(selector(o))
            Else
                falseG.Add(selector(o))
            End If
        Next
        Return (trueG, falseG)
    End Function
End Module