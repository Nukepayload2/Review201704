<Flags>
Public Enum VerbKinds
    Unknown
    五段 = 1
    一类 = 五段
    上一段 = 2
    下一段 = 4
    一段 = 上一段 Or 下一段
    二类 = 一段
    か变 = 8
    さ变 = 16
    か变和さ变 = か变 Or さ变
    三类 = か变和さ变
End Enum
