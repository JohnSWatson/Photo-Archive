Imports System.Drawing.Imaging
Imports System.IO

Public Class frmArchive
    Private Source As String
    Private Built As Boolean = False

#Region "Load data view"

    ''' <summary>
    ''' On Load select a folder to add to the archive
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmArchive_Load(sender As Object, e As EventArgs) Handles Me.Load
        SelectFolderToArchive()
    End Sub

    ''' <summary>
    ''' Select a folder to archive
    ''' </summary>
    Private Sub SelectFolderToArchive()
        ' With Folder browser select a folder to archive
        With FolderBrowserDialog1
            .Description = "Select folder to markup"
            .ShowNewFolderButton = False
            .ShowDialog()
            Source = .SelectedPath
            .Reset()
        End With
        If Source = "" Then Exit Sub

        'Clear the list view and start again
        Dim item As ListViewItem
        For Each item In lvFolders.Items
            item.Remove()
        Next

        ToolStripStatusLabel2.Text = "Searching folder " & Source
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        ' Check we are not trying to archive a folder in the archive
        If clsArchiveDevice.ValidSourcePath(Source) Then
            Built = False
            ArchiveIt(Source)
            Cursor = Cursors.Default
            Built = True
        Else
            Cursor = Cursors.Default
            MsgBox("You cant archive from here, it is the archive", MsgBoxStyle.Question + MsgBoxStyle.OkOnly, "Common be real")
        End If
    End Sub

    ''' <summary>
    ''' Recursive function
    ''' Given the source folder load the data grid with all the folder
    ''' and sub folders
    ''' </summary>
    ''' <param name="MySource">Folder selected for archive</param>
    Private Sub ArchiveIt(MySource)
        Dim FileCount As Integer
        Dim FolderCount As Integer

        FolderCount = Directory.GetDirectories(MySource).Count
        ToolStripStatusLabel2.Text = MySource & ", " & FolderCount
        Application.DoEvents()

        Dim LVI As String() = {"Folder", "02", "Status", "None", "Full path", "Not selected!"}
        Cursor = Cursors.WaitCursor
        For Each Dir As String In Directory.GetDirectories(MySource)
            ArchiveIt(Dir)
        Next

        If Not IsMarkedArchived(MySource) Then    ' Skip any folder already archived
            FileCount = Directory.GetFiles(MySource, "*.JPG", SearchOption.TopDirectoryOnly).Count
            If FileCount > 0 Then   ' Skip folders with no jpg photos
                LVI = {GetArchivePathPart(MySource), FileCount.ToString("#,###,##0"), "Pending", "None", MySource, "Not selected no archive action set"}
                lvFolders.Items.Add(New ListViewItem(LVI))
            End If
        End If
    End Sub


    ''' <summary>
    ''' Get a source to archive, validate it then get on with the job
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        SelectFolderToArchive()
    End Sub


#End Region

#Region "Data view events"
    Private Sub lvFolders_DoubleClick(sender As Object, e As EventArgs) Handles lvFolders.DoubleClick
        Dim MyPath As String = Me.lvFolders.SelectedItems(0).SubItems.Item(4).Text
        Process.Start("explorer.exe", MyPath)
    End Sub

    Private Sub lvFolders_Click(sender As Object, e As EventArgs) Handles lvFolders.Click
        If Not Built Then Exit Sub
        ToolStripStatusLabel2.Text = lvFolders.Items(0).SubItems.Item(4).Text
        'Me.lvFolders.SelectedItems(0).SubItems.Item(5).Text = "Selected"
    End Sub

    Private Sub lvFolders_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lvFolders.ItemChecked
        If Not Built Then Exit Sub
        ToolStripStatusLabel2.Text = Me.lvFolders.CheckedItems.Count.ToString("#,##0") & " folder selected"
    End Sub

#End Region

    Private Sub ArchiveFile(filepath As String)
        Dim clsPhoto As New Photo(filepath, GetArchivePathPart(filepath), "Auto")
    End Sub

    Private Function ArchivePhoto(PhotoPath As String, RequestedAction As String) As String
        Dim WhatHappend As String

        ' get a list of the JPG in source
        Dim jpgFilesArray As String() = Directory.GetFiles(PhotoPath, "*.JPG", SearchOption.TopDirectoryOnly)
        ToolStripStatusLabel2.Text = String.Concat("Processing ", jpgFilesArray.Count.ToString("#,###,##0"))
        ToolStripProgressBar2.Maximum = jpgFilesArray.Count

        Dim I As Integer = 1
        For Each SourceFile In jpgFilesArray
            ToolStripProgressBar2.Value = I
            If Not SourceFile.Contains("Archived") Then
                Dim CP As New Photo(SourceFile, GetArchivePathPart(PhotoPath), RequestedAction)
                WhatHappend = CP.ArchivePhoto()
            End If
            I += 1
        Next
        ' Mark folder as archived
        MarkFolderArchived(PhotoPath)
        Return "Archived"
    End Function

    Private Function ArchiveToMoreWork(PhotoPath As String) As String
        Dim MyDate As String
        Dim Archivefoldername As String


        Archivefoldername = InputBox("Enter archive folder name for folder " & PhotoPath, "Archive folder", "Please Enter Value")
        If Archivefoldername = "Please Enter Value" Or Archivefoldername = "" Then
            MsgBox("You have note entered an archive folder name, the archive operation has been canceled", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Operation canceled")
            Return "Cancelled"
        End If

        ' get a list of the JPG in source
        Dim jpgFilesArray As String() = Directory.GetFiles(PhotoPath, "*.JPG", SearchOption.TopDirectoryOnly)
        ToolStripStatusLabel2.Text = String.Concat("Processing    ", jpgFilesArray.Count.ToString("#,###,##0"), " from folder ", Path.GetFileName(PhotoPath), "  ")
        ToolStripProgressBar2.Value = 0
        ToolStripProgressBar2.Maximum = jpgFilesArray.Count
        Me.Refresh()

        Dim I As Integer = 1

        For Each SourceFile In jpgFilesArray
            ToolStripProgressBar2.Value = I
            If Not SourceFile.Contains("Archived") Then
                MyDate = File.GetCreationTime(SourceFile).ToString("yyyy-mm-dd")
                code.CopyPhotoToArchive(SourceFile, clsArchiveDevice.DriveLetter & "\" & My.Settings.Needswork & "\" & Archivefoldername & "\" & MyDate & "\" & Path.GetFileName(SourceFile))
                code.MarkFileArchived(SourceFile)
            End If
            I += 1
        Next
        ' Mark folder as archived
        MarkFolderArchived(PhotoPath)
        Return "Archived"
    End Function

    Private Function ArchiveToPrivate(PhotoPath As String) As String
        Dim MyDate As String
        Dim Archivefoldername As String


        Archivefoldername = InputBox("Enter archive folder name", "Archive folder", "Please Enter Value")
        If Archivefoldername = "Please Enter Value" Or Archivefoldername = "" Then
            MsgBox("You have note entered an archive folder name, the archive operation has been canceled", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Operation canceled")
            Return "Cancelled"
        End If

        ' get a list of the JPG in source
        Dim jpgFilesArray As String() = Directory.GetFiles(PhotoPath, "*.JPG", SearchOption.TopDirectoryOnly)
        ToolStripStatusLabel2.Text = String.Concat("Processing    ", jpgFilesArray.Count.ToString("#,###,##0"), " from folder ", Path.GetFileName(PhotoPath), "  ")
        ToolStripProgressBar2.Value = 0
        ToolStripProgressBar2.Maximum = jpgFilesArray.Count

        Dim I As Integer = 1

        For Each SourceFile In jpgFilesArray
            ToolStripProgressBar2.Value = I
            If Not SourceFile.Contains("Archived") Then
                MyDate = File.GetCreationTime(SourceFile).ToString("yyyy-mm-dd")
                code.CopyPhotoToArchive(SourceFile, clsArchiveDevice.DriveLetter & "\" & My.Settings.Archive & "\" & Archivefoldername & "\" & MyDate & "\" & Path.GetFileName(SourceFile))
                code.MarkFileArchived(SourceFile)
            End If
            I += 1
        Next
        ' Mark folder as archived
        MarkFolderArchived(PhotoPath)
        Return "Archived"
    End Function

    Private Function ArchiveToFamilyHistory(PhotoPath As String) As String

        ' get a list of the JPG in source
        Dim jpgFilesArray As String() = Directory.GetFiles(PhotoPath, "*.JPG", SearchOption.TopDirectoryOnly)
        ToolStripStatusLabel2.Text = String.Concat("Processing    ", jpgFilesArray.Count.ToString("#,###,##0"), " from folder ", Path.GetFileName(PhotoPath), "  ")
        ToolStripProgressBar2.Value = 0
        ToolStripProgressBar2.Maximum = jpgFilesArray.Count

        Dim I As Integer = 1

        For Each SourceFile In jpgFilesArray
            ToolStripProgressBar2.Value = I
            If Not SourceFile.Contains("Archived") Then
                Dim ArchivePath As String = clsArchiveDevice.DriveLetter & "\" & My.Settings.FamilyHistory & "\" & FamilyHistoryPath(SourceFile) & "\" & Path.GetFileName(SourceFile)
                code.CopyPhotoToArchive(SourceFile, ArchivePath)
                code.MarkFileArchived(SourceFile)


            End If
            I += 1
        Next
        ' Mark folder as archived
        MarkFolderArchived(PhotoPath)
        Return "Archived"
    End Function

    Private Function DoMoveToArchive(PhotoToMove As String) As String
        Dim DuplicateAction As String
        Dim FileName As String = Path.GetFileName(PhotoToMove)

        '   Dim dupPhotos As String() = IO.Directory.GetFiles(clsArchiveDevice.DriveLetter, Path.GetFileName(PhotoToMove), SearchOption.AllDirectories)
        For Each TopDir In IO.Directory.GetDirectories(clsArchiveDevice.DriveLetter, "*archive", SearchOption.TopDirectoryOnly)
            For Each dupPhoto In IO.Directory.GetFiles(TopDir, FileName, SearchOption.AllDirectories)
                DuplicateAction = GetDuplicateAction(PhotoToMove, dupPhoto)
            Next
        Next

        Return "Good"
    End Function

    Private Function GetDuplicateAction(_path As String, duppath As String) As String
        Dim frmDup As New frmReviewDuplicate
        Dim DupAction As String

        ' The image in the archive is the duplicate of the image to be loaded into the archive
        frmDup.txtArchiveingHeading.Text = _path
        frmDup.LeftImagePath = _path
        frmDup.txtArchiveingPath.Text = _path
        frmDup.txtArchiveingDateTaken.Text = ""
        frmDup.txtArchiveingTitle.Text = ""
        frmDup.txtArchiveingSubject.Text = ""
        frmDup.txtArchiveingTags.Text = ""
        frmDup.txtArchiveingRating.Text = ""
        frmDup.txtArchiveingComment.Text = ""

        ' The image in the archive is the duplicate of the image to be loaded into the archive
        frmDup.txtDuplicateHeading.Text = Split(duppath, "\")(1)
        frmDup.RightImagePath = duppath
        frmDup.txtDuplicatePath.Text = duppath
        frmDup.txtDuplicateDateTaken.Text = ""
        frmDup.txtDuplicateTitle.Text = ""
        frmDup.txtDuplicateSubject.Text = ""
        frmDup.txtDuplicateTags.Text = ""
        frmDup.txtDuplicateRating.Text = ""
        frmDup.txtDuplicateComment.Text = ""

        frmDup.ShowDialog()

        If frmDup.CheckBox1.Checked Then
            If Not DuplicatesAction.ContainsKey(Path.GetDirectoryName(_path)) Then
                DuplicatesAction.Add(Path.GetDirectoryName(_path), frmDup.Tag)
            End If
        End If
        DupAction = frmDup.Tag
        frmDup = Nothing
        Return DupAction
end function


    Private Function FamilyHistoryPath(PhotoPath As String) As String
        Dim BadList() As String = {"ORIGINALS", "IMAGES", "CONVERTED", "ARCHIVE", "green", "blue", "RED", "indigo", "violet", "RED"}
        Dim Parts() As String = Split(PhotoPath, "\")

        For i As Integer = Parts.Count - 2 To 0 Step -1
            If BadList.Contains(Parts(i).ToUpper) Then Continue For

            Return Parts(i)
        Next i

        Dim Archivefoldername As String

        Archivefoldername = InputBox("Enter archive folder name for folder " & PhotoPath, "Archive folder", "Please Enter Value")
        If Archivefoldername = "Please Enter Value" Or Archivefoldername = "" Then
            MsgBox("You have note entered an archive folder name, the archive operation has been canceled", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Operation canceled")
            Return "Cancelled"
        End If

        Return Archivefoldername

    End Function



#Region "Tool strib buttons"
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
#End Region

#Region "Data list context menu functions"
    ''' <summary>
    ''' Tick all dataview list items
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuTickAll_Click(sender As Object, e As EventArgs) Handles mnuTickAll.Click
        Dim item As ListViewItem
        For Each item In lvFolders.Items
            item.Checked = True
            item.SubItems(5).Text = "Selected"
        Next
    End Sub

    Private Sub mnuUntickAll_Click(sender As Object, e As EventArgs) Handles mnuUntickAll.Click
        Dim item As ListViewItem
        For Each item In lvFolders.Items
            item.Checked = False
        Next
    End Sub

    Private Sub mnuTickSpecialAction_Click(sender As Object, e As EventArgs) Handles mnuTickSpecialAction.Click
        Dim item As ListViewItem
        For Each item In lvFolders.Items
            If Not item.SubItems.Item(2).Text = "Archived" Then
                If Not item.SubItems.Item(3).Text = "Auto" Then
                    item.Checked = True
                Else
                    item.Checked = False
                End If
            End If
        Next
    End Sub

    Private Sub mnuAuto_Click(sender As Object, e As EventArgs) Handles mnuAuto.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Auto"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuPrivate_Click(sender As Object, e As EventArgs) Handles mnuPrivate.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Private"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuMoreWork_Click(sender As Object, e As EventArgs) Handles mnuMoreWork.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "More work"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuPublic_Click(sender As Object, e As EventArgs) Handles mnuPublic.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems   '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Public"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuPutInFamilyHistory_Click(sender As Object, e As EventArgs) Handles mnuPutInFamilyHistory.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems   '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Family history"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuPublicPrivate_Click(sender As Object, e As EventArgs) Handles mnuPublicPrivate.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems   '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Both"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuDontArchive_Click(sender As Object, e As EventArgs) Handles mnuDontArchive.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems  '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "None"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuDeleteFolder_Click(sender As Object, e As EventArgs) Handles mnuDeleteFolder.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems   '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Delete"
            item.Checked = False
        Next
    End Sub

    ''' <summary>
    ''' Archive the folder listed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuDoArchive_Click(sender As Object, e As EventArgs) Handles mnuDoArchive.Click
        ProcessTheListviewActions()
    End Sub
#End Region

#Region "Process photos into the archive"
    Private Sub ProcessTheListviewActions()

        For Each item As ListViewItem In Me.lvFolders.Items
            If Not (item.SubItems.Item(2).Text = "Archived" Or item.SubItems.Item(3).Text = "None") Then
                Cursor = Cursors.WaitCursor
                item.SubItems.Item(2).Text = "Processing"
                item.SubItems.Item(2).BackColor = Color.Red
                ProcessListViewItem(item.SubItems.Item(4).Text, item.SubItems.Item(3).Text)
                item.Checked = False
                item.SubItems.Item(2).Text = "Archived"
                item.SubItems.Item(2).BackColor = Color.Green
                Me.Refresh()
                Cursor = Cursors.Default
            End If
        Next

        ToolStripStatusLabel2.Text = "Archive operation complete     "
        ToolStripProgressBar2.Value = 0
        ToolStripProgressBar2.Maximum = 0
    End Sub

    Private Sub ProcessListViewItem(FolderToArchive As String, ArchiveAction As String)

        Select Case ArchiveAction
            Case "Display", "Family History", "Private", "Both"
                ProcessFilesInFolderToArchive(FolderToArchive, ArchiveAction)
                MarkFolderArchived(FolderToArchive)
            Case "Delete this folder"
                If MsgBox("Delete folder " & vbCrLf & FolderToArchive & vbCrLf & "and all its contents", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm delete") = MsgBoxResult.Yes Then
                    code.DeleteFolder(FolderToArchive)
                End If
            Case "Do not Archive"
                MarkFolderArchived(FolderToArchive)
            Case Else
                MsgBox("No action specified for """ + ArchiveAction + """", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Speack to your developer")
        End Select

    End Sub

    Private Sub ProcessFilesInFolderToArchive(FolderToArchive As String, ArchiveAction As String)
        ' get a list of the JPG in source
        Dim jpgFilesArray As String() = Directory.GetFiles(FolderToArchive, "*.JPG", SearchOption.TopDirectoryOnly)
        ToolStripStatusLabel2.Text = String.Concat("Processing    ", jpgFilesArray.Count.ToString("#,###,##0"), " from folder ", Path.GetFileName(FolderToArchive))
        ToolStripProgressBar2.Value = 0
        ToolStripProgressBar2.Maximum = jpgFilesArray.Count


        Dim I As Integer = 1
        Dim Archiveit As New ArchivePhoto
        For Each SourceFile In jpgFilesArray
            ToolStripProgressBar2.Value = I
            Me.Refresh()
            Archiveit.Photo(SourceFile, ArchiveAction)

            I += 1
        Next

    End Sub
#End Region

#Region "Context menu event handler"
    Private Sub mnuSelectAllforActions_Click(sender As Object, e As EventArgs) Handles mnuSelectAllforActions.Click
        Dim item As ListViewItem
        For Each item In lvFolders.Items
            item.Checked = True
        Next
    End Sub

    Private Sub mnuDeselectall_Click(sender As Object, e As EventArgs) Handles mnuDeselectall.Click
        Dim item As ListViewItem
        For Each item In lvFolders.Items
            item.Checked = False
        Next
    End Sub

    Private Sub mnuArchivefordisplay_Click(sender As Object, e As EventArgs) Handles mnuArchivefordisplay.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Display"
            item.Checked = False
        Next
    End Sub

    Private Sub mnArchiveforFamilyHistory_Click(sender As Object, e As EventArgs) Handles mnArchiveforFamilyHistory.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Family History"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuArchiveForPrivate_Click(sender As Object, e As EventArgs) Handles mnuArchiveForPrivate.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Private"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuArchiveforPrivateDisplay_Click(sender As Object, e As EventArgs) Handles mnuArchiveforPrivateDisplay.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Both"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuDoNotArchive_Click(sender As Object, e As EventArgs) Handles mnuDoNotArchive.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Do not Archive"
            item.Checked = False
        Next
    End Sub

    Private Sub mnuDeleteSource_Click(sender As Object, e As EventArgs) Handles mnuDeleteSource.Click
        For Each item As ListViewItem In Me.lvFolders.CheckedItems '.SelectedItems  'Items
            item.SubItems.Item(3).Text = "Delete this folder"
            item.Checked = False
        Next
    End Sub


#End Region
End Class