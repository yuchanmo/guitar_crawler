Module Module1

    Sub Main()
        Dim SWFToImage = CreateObject(“SWFToImage.SWFToImageObject”)

        SWFToImage.InitLibrary(“demo”, “demo”)

        Dim WshShell, fs, f, fc, f1, tsFile
        Dim WshShell = WScript.CreateObject(“WScript.Shell”)

        sCurrentFolder = WshShell.CurrentDirectory

Set fs = CreateObject(“Scripting.FileSystemObject”)
Set f = fs.GetFolder(sCurrentFolder) ' current directory
Set fc = f.Files
Set fs = Nothing

' converting SWF files to JPG image files
For Each f1 In fc
            If UCase(Mid(f1.name, InStrRev(f1.name, “.”) + 1)) = “SWF” Then
                SWFToImage.InputSWFFileName = f1.name
                SWFToImage.FrameIndex = 1 ' number of frame to extract
                SWFToImage.ImageOutputType = 1 ' set output image type to Jpeg (0 = BMP, 1 = JPG, 2 = GIF)
                SWFToImage.Execute
                SWFToImage.SaveToFile Mid(f1.name, 1, InStr(f1.name, “.”) – 1) & “.jpg”
End If

        Next

Set SWFToImage = nothing
    End Sub

End Module
