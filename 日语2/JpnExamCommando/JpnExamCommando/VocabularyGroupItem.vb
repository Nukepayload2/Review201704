Public Class VocabularyGroupItem
    Implements INotifyPropertyChanged

    Public Sub New(假名 As String, 日文汉字 As String, 翻译 As String, 词性 As String, 课程 As Integer)
        Me.Jm = 假名
        Me.Hanz = 日文汉字
        Me.Translation = 翻译
        Me.Kind = 词性
        Me.Course = 课程
    End Sub

    Public Property Jm As String
    Public Property Hanz As String
    Public Property Translation As String
    Public Property Kind As String
    Public Property Course As Integer

    Dim _Trained As Boolean
    Public Property Trained As Boolean
        Get
            Return _Trained
        End Get
        Set(value As Boolean)
            _Trained = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Trained)))
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
