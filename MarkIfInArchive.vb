Imports System.Windows.Forms
Imports System.IO

Public Class MarkIfInArchive
    Private Source As String
    Dim jpgFilesArray As String()

    Private Sub ToolStripMenuItemSelectSource_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSelectSource.Click

        With FolderBrowserDialog1
            .Description = "Select folder to markup"
            .ShowNewFolderButton = False
            .ShowDialog()
            Source = .SelectedPath
            .Reset()
        End With
        If Source = "" Then Exit Sub

        jpgFilesArray = Directory.GetFiles(Source, "*.JPG", SearchOption.AllDirectories)
        Me.ToolStripProgressBar1.Maximum = jpgFilesArray.Count
        Me.ToolStripStatusLabel1.Text = Source & ", " & jpgFilesArray.Count.ToString("#,###,##0") & " photos to review"
        Markup()

    End Sub

    Sub Markup()
        Dim I As Long
        Dim T As String
        Dim Tnew As String

        Cursor = Cursors.WaitCursor
        For I = LBound(jpgFilesArray) To UBound(jpgFilesArray)
            T = jpgFilesArray(I)

            Dim clsPhoto As New Photo(T, T, T)
            If clsPhoto.ArchiveAction = "markup" Then
                Tnew = "Archived " & Path.GetFileName(T)
                'If MsgBox("Rename " & T & vbCrLf & "To" & vbCrLf & Tnew, MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Make up your mind") = MsgBoxResult.Ok Then
                My.Computer.FileSystem.RenameFile(T, Tnew)
                'End If
            End If
            Application.DoEvents()
            Me.ToolStripProgressBar1.Value = I
        Next
        Cursor = Cursors.Default
    End Sub


End Class