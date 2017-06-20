Const ForReading = 1

Main wscript.arguments

Sub Main(args)
    Set fso = CreateObject("Scripting.FileSystemObject")
    Set strmRead = fso.OpenTextFile(args(0), ForReading)
    text = strmRead.ReadAll
    strmRead.Close
    Set reg = New RegExp
    reg.Global = True
    reg.Pattern = "^"
    text = reg.Replace(text, "|")
    reg.Pattern = "\u" & Hex(AscW("¡¡"))
    text = reg.Replace(text, "|")
    reg.Pattern = "\r\n"
    text = reg.Replace(text, "||" & vbCrLf & "|")
    Set writeStrm = fso.CreateTextFile(Mid(args(0), 1, InStrRev(args(0),".") - 1) & ".md", False)
    writeStrm.WriteLine "|¼ÙÃû|ÈÕÎÄºº×Ö|·­Òë|"
    writeStrm.WriteLine "|-|-|-|"
    writeStrm.Write text
    writeStrm.WriteLine "||"
    writeStrm.Close
End Sub