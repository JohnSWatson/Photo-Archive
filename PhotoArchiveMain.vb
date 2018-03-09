Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient


Public Class PhotoArchiveMain
    Dim ds As New DataSet()
    ' Backing storage -- a generic dictionary
    Dim Photos As New Dictionary(Of String, Photo)
    Dim PictureboxToUse As Int16 = 1
    Dim DispayedNode1 As TreeNode
    Dim DispayedNode2 As TreeNode


    Private Structure ExtendedData
        Public DateTaken As String
        Public Title As String
        Public Subject As String
    End Structure

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

        Close()

    End Sub

    Private Function FindPicDate(PicFile As String) As ExtendedData
        Dim ED As New ExtendedData
        Dim pic_time As PropertyItem
        Dim pic_title As PropertyItem
        Dim pic_subject As PropertyItem

        'Create an Image object. 
        Dim Image As Bitmap = New Bitmap(PicFile)

        'Get the PropertyItems property from image. 
        'Dim propItems As PropertyItem() = Image.PropertyItems

        pic_time = Image.GetPropertyItem(306)                ' Date taken tag
        pic_title = Image.GetPropertyItem(40091)             ' Title tag
        pic_subject = Image.GetPropertyItem(40095)           ' Subject tag


        ED.DateTaken = System.Text.Encoding.ASCII.GetString(pic_time.Value, 0, pic_time.Len - 1).Substring(0, 10).Replace(":", "-")
        ED.Title = System.Text.Encoding.Unicode.GetString(pic_title.Value, 0, pic_title.Len - 2)
        ED.Subject = System.Text.Encoding.Unicode.GetString(pic_subject.Value, 0, pic_subject.Len - 2)

        Return ED
    End Function


    Private Sub GetExtendedData(ByRef clsPhoto As Photo, path As String)
        Dim MyImage As Bitmap
        Dim pic_time As PropertyItem
        Dim pic_title As PropertyItem
        Dim pic_subject As PropertyItem

        clsPhoto.PhotoPath = path

        'Create an Image object. 
        Try
            MyImage = New Bitmap(path)
        Catch ex As ArgumentException
            MsgBox(ex.Message & vbCrLf & "Error while processing " & path, MsgBoxStyle.AbortRetryIgnore, "Oh god")
            Exit Sub
        End Try

        'Get the PropertyItems property from image. 
        'Dim propItems As PropertyItem() = Image.PropertyItems

        pic_time = MyImage.GetPropertyItem(306)                ' Date taken tag

        Try
            pic_title = MyImage.GetPropertyItem(40091)             ' Title tag
            clsPhoto.HasTitle = True
        Catch ex As ArgumentException
            clsPhoto.HasTitle = False
        End Try

        Try
            pic_subject = MyImage.GetPropertyItem(40095)           ' Subject tag
            clsPhoto.HasSubject = True
        Catch ex As ArgumentException
            clsPhoto.HasSubject = False
        End Try

        clsPhoto.DateTaken = System.Text.Encoding.ASCII.GetString(pic_time.Value, 0, pic_time.Len - 1).Substring(0, 10).Replace(":", "-")
        If clsPhoto.HasTitle Then clsPhoto.Title = System.Text.Encoding.Unicode.GetString(pic_title.Value, 0, pic_title.Len - 2)
        If clsPhoto.HasSubject Then clsPhoto.Subject = System.Text.Encoding.Unicode.GetString(pic_subject.Value, 0, pic_subject.Len - 2)

        MyImage.Dispose()

    End Sub


    Private Sub MarkIfInArchiveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim MyForm As New MarkIfInArchive

        MyForm.Show()
    End Sub

    Private Sub ArciveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArciveToolStripMenuItem.Click
        If clsArchiveDevice.ArchiveAttached Then
            Dim MyForm As New frmArchive
            MyForm.Show()
        Else
            MsgBox("The ""Photo Archive"" disk is not attached", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Archive not available")
        End If
    End Sub


    Private Sub SearchArchiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchArchiveToolStripMenuItem.Click
        If clsArchiveDevice.ArchiveAttached Then
            Process.Start("explorer.exe", clsArchiveDevice.DriveLetter)
        Else
            MsgBox("Archive disk not available", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "No archive")
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles mnuAbout.Click
        Dim frmAbout As New AboutBox
        frmAbout.ShowDialog()
    End Sub

    Private Sub LoadTree(ByVal rootDir As String)
        Dim root As New TreeNode

        PictureboxToUse = 1
        Try
            PictureBox1.Image = Nothing
            Pic1Name.Text = "No picture"
        Catch ex As Exception
        End Try
        Try
            PictureBox2.Image = Nothing
            Pic2Name.Text = "No picture"
        Catch ex As Exception
        End Try

        TreeView1.BeginUpdate()
        TreeView1.Nodes.Clear()
        DispayedNode1 = Nothing
        DispayedNode2 = Nothing

        TreeView1.ImageIndex = 0
        TreeView1.SelectedImageIndex = 1

        root.Name = rootDir
        root.Text = rootDir & " (Archive disk)"
        root.Tag = "Folder"

        root.ImageIndex = 0

        'Add this drive as a root node
        TreeView1.Nodes.Add(root)
        PopulateTreeView(rootDir, TreeView1.Nodes(0))
        TreeView1.EndUpdate()

        ' If SearchTerm.Text > "" Then ClearEmptyNodes(TreeView1.Nodes)
        'ClearEmptyNodes(TreeView1.Nodes)

        TreeView1.EndUpdate()

    End Sub

    Private Sub PopulateTreeView(ByVal dir As String, ByVal parentNode As TreeNode)
        Dim folder As String = String.Empty
        Dim ST As String = SearchTerm.Text.ToUpper
        Dim ToolTip As String
        Dim FileCount As Int64

        If dir = "" Then Exit Sub

        ToolTip = Split(dir, "\")(1)

        FileCount = 0

        Try
            'Add the files to treeview
            Dim files() As String = IO.Directory.GetFiles(dir)
            If files.Length <> 0 Then
                Dim fileNode As TreeNode = Nothing
                For Each file As String In files
                    If file.ToUpper.Contains(ST) Then                                      '  The search term
                        fileNode = parentNode.Nodes.Add(file)
                        fileNode.Name = file
                        fileNode.Text = IO.Path.GetFileName(file)
                        fileNode.Tag = "File"
                        fileNode.ToolTipText = ToolTip
                        fileNode.ImageIndex = 3
                        fileNode.SelectedImageIndex = 5
                        fileNode.Parent.ImageIndex = 4
                    End If
                Next
            End If

            'Add folders to treeview
            Dim folders() As String = IO.Directory.GetDirectories(dir)
            If folders.Length <> 0 Then

                For Each folder In folders
                    If folder.Contains("archive") Then
                        If HasSearchTerm(folder) Then
                            Dim folderNode As TreeNode = Nothing
                            Dim folderName As String = String.Empty

                            folderName = IO.Path.GetFileName(folder)
                            folderNode = parentNode.Nodes.Add(folder)
                            folderNode.Name = folder
                            folderNode.Text = folderName
                            folderNode.Tag = "Folder"
                            folderNode.ToolTipText = ToolTip
                            PopulateTreeView(folder, folderNode)
                        End If
                    End If
                Next
            End If
        Catch ex As UnauthorizedAccessException
            parentNode.Nodes.Add("Access Denied")
        End Try
    End Sub

    Private Function HasSearchTerm(ByVal Folder As String) As Boolean
        If SearchTerm.Text = "" Then Return True

        Dim ST As String = SearchTerm.Text.ToUpper

        Dim PicsFound As String() = Directory.GetFiles(Folder, "*.jpg", SearchOption.AllDirectories)
        For Each file In PicsFound
            If file.ToUpper.Contains(ST) Then Return True
        Next
        Return False
    End Function

    Private Sub PhotoArchiveMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        If clsArchiveDevice.ArchiveAttached Then
            LoadTree(clsArchiveDevice.DriveLetter)
        Else
            TreeView1.Nodes.Add("Attach the archive")
        End If
    End Sub

    Private Sub SearchTerm_KeyUp(sender As Object, e As KeyEventArgs) Handles SearchTerm.KeyUp
        If e.KeyCode = Keys.Enter Then '
            LoadTree(clsArchiveDevice.DriveLetter)
        End If
    End Sub

    Private Sub GetStatistics()
        Dim cntDisplay As Long = IO.Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.Displayready, "*.jpg", SearchOption.AllDirectories).Count
        Dim cntForReview As Long = IO.Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.ForReview, "*.jpg", SearchOption.AllDirectories).Count
        Dim cntMoreWork As Long = IO.Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.Needswork, "*.jpg", SearchOption.AllDirectories).Count
        Dim cntPrivate As Long = IO.Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.Archive, "*.jpg", SearchOption.AllDirectories).Count
        Dim cntFamilyHistory As Long = IO.Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.FamilyHistory, "*.jpg", SearchOption.AllDirectories).Count
        Dim cntTotal As Long = cntDisplay + cntForReview + cntMoreWork + cntPrivate

        MsgBox("Archive statistics:" & vbCrLf &
               "Private:" & vbTab & vbTab & cntPrivate.ToString("#,###,##0") & vbCrLf &
               "Need work:" & vbTab & cntMoreWork.ToString("#,###,##0") & vbCrLf &
               "For review:" & vbTab & cntForReview.ToString("#,###,##0") & vbCrLf &
               "For Display:" & vbTab & cntDisplay.ToString("#,###,##0") & vbCrLf &
               "Family history:" & vbTab & cntFamilyHistory.ToString("#,###,##0") & vbCrLf & vbCrLf &
               "Total:" & vbTab & vbTab & cntTotal.ToString("#,###,##0"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Dim SelectedNode As New TreeNode

        Cursor = Cursors.WaitCursor
        SelectedNode = e.Node
        If Not SelectedNode.Tag = "Folder" Then
            Select Case PictureboxToUse
                Case 1
                    Dim Streaml As FileStream = New FileStream(SelectedNode.Name, FileMode.Open, FileAccess.Read)
                    PictureBox1.Image = Image.FromStream(Streaml)
                    Streaml.Close()
                    PictureboxToUse = 2
                    Pic1Name.Text = SelectedNode.Name
                    SelectedNode.BackColor = Color.Yellow
                    If Not DispayedNode1 Is Nothing Then DispayedNode1.BackColor = Color.White
                    DispayedNode1 = SelectedNode
                Case 2
                    Dim Streaml As FileStream = New FileStream(SelectedNode.Name, FileMode.Open, FileAccess.Read)
                    PictureBox2.Image = Image.FromStream(Streaml)
                    Streaml.Close()
                    PictureboxToUse = 1
                    Pic2Name.Text = SelectedNode.Name
                    SelectedNode.BackColor = Color.SpringGreen
                    If Not DispayedNode2 Is Nothing Then DispayedNode2.BackColor = Color.White
                    DispayedNode2 = SelectedNode
            End Select
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ClearEmptyNodes(TRC As TreeNodeCollection)
        ExamineNode(TreeView1.TopNode)
    End Sub

    Private Sub ExamineNode(thisNode As TreeNode)
        Dim MyNodes As TreeNodeCollection

        MyNodes = thisNode.Nodes
        Debug.Print("Examining " & thisNode.Name & ", with " & MyNodes.Count)

        For Each MyNode In MyNodes
            Try
                If MyNode.tag = "Folder" And MyNode.nodes.count = 0 Then
                    'Debug.Print("Removing " & MyNode.Name & ", with " & MyNode.nodes.cout)
                    TreeView1.Nodes.Remove(MyNode)
                Else
                    ExamineNode(MyNode)
                End If
            Catch ex As Exception

            End Try

        Next

        If thisNode.Tag = "Folder" And thisNode.Nodes.Count = 0 Then
            'Debug.Print("Finished and removing " & thisNode.Name & ", with " & thisNode.Nodes.Count)
            TreeView1.Nodes.Remove(thisNode)
        Else
            'Debug.Print("Finished              " & thisNode.Name & ", with " & thisNode.Nodes.Count)
        End If

    End Sub



    Private Sub mnuGetDetails_Click(sender As Object, e As EventArgs) Handles mnuGetDetails.Click
        Dim SelectedNode As New TreeNode
        SelectedNode = TreeView1.SelectedNode
        If Not SelectedNode.Name = Nothing Then
            If SelectedNode.Tag = "File" Then
                Cursor = Cursors.WaitCursor
                Dim cAI As New ArchivedImage(SelectedNode.Name)
                MsgBox(cAI.Info)
            Else
                MsgBox("Its a folder")
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mnuDeleteThis_Click(sender As Object, e As EventArgs) Handles mnuDeleteThis.Click
        Dim SelectedNode As New TreeNode
        SelectedNode = TreeView1.SelectedNode
        If SelectedNode.Tag = "File" Then
            If MsgBox("Delete file:" & vbCrLf & SelectedNode.Name, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm delete") = vbYes Then
                code.DeletePhoto(SelectedNode.Name)
            End If
        Else
            If SelectedNode.Level < 2 Then
                MsgBox("Not allowed")
            Else
                If MsgBox("Delete folder and all files:" & vbCrLf & SelectedNode.Name, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm delete the whole blody lot") = vbYes Then
                    code.DeleteFolder(SelectedNode.Name)
                End If
            End If
        End If
    End Sub

    Private Sub mnuMoveToPrivate_Click(sender As Object, e As EventArgs) Handles mnuMoveToPrivate.Click
        MsgBox("Not yet available")
    End Sub

    Private Sub mnuMoveToReview_Click(sender As Object, e As EventArgs) Handles mnuMoveToReview.Click
        MsgBox("Not yet available")
    End Sub

    Private Sub mnuMoveToNeedsWork_Click(sender As Object, e As EventArgs) Handles mnuMoveToNeedsWork.Click
        MsgBox("Not yet available")
    End Sub

    Private Sub mnuMoveToDisplayReady_Click(sender As Object, e As EventArgs) Handles mnuMoveToDisplayReady.Click
        MsgBox("Not yet available")
    End Sub

    Private Sub mnuOpenInExplorer_Click(sender As Object, e As EventArgs) Handles mnuOpenInExplorer.Click
        Dim SelectedNode As New TreeNode
        Dim Args As String

        SelectedNode = TreeView1.SelectedNode
        If Not SelectedNode.Name = Nothing Then
            If SelectedNode.Tag = "File" Then
                Args = ControlChars.Quote & IO.Path.Combine(Path.GetDirectoryName(SelectedNode.Name)) & ControlChars.Quote
                'Process.Start("explorer.exe", Path.GetDirectoryName(SelectedNode.Name))
            Else
                Args = ControlChars.Quote & IO.Path.Combine(SelectedNode.Name) & ControlChars.Quote
                '                Process.Start("explorer.exe", SelectedNode.Name)
            End If
            Dim Proc As String = "Explorer.exe"

            Process.Start(Proc, Args)
        End If
    End Sub

    Private Sub mnuRefreshTree_Click(sender As Object, e As EventArgs) Handles mnuRefreshTree.Click
        If clsArchiveDevice.ArchiveAttached Then
            Cursor = Cursors.WaitCursor
            LoadTree(clsArchiveDevice.DriveLetter)
            Cursor = Cursors.Default
        Else
            Cursor = Cursors.WaitCursor
            TreeView1.BeginUpdate()
            TreeView1.Nodes.Clear()
            TreeView1.Nodes.Add("Attach the archive")
            TreeView1.EndUpdate()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mnuEditImage_Click(sender As Object, e As EventArgs) Handles mnuEditImage.Click
        Dim SelectedNode As New TreeNode
        SelectedNode = TreeView1.SelectedNode
        If Not SelectedNode.Name = Nothing Then
            If SelectedNode.Tag = "File" Then
                Try
                    System.Diagnostics.Process.Start(SelectedNode.Name)

                Catch ex As Exception
                    MsgBox("Unable to load the file. Maybe it was deleted?")
                End Try
                'If result Then
                ' Process.Start("explorer.exe", SelectedNode.Name)
            End If
        End If
    End Sub

    Private Sub mnuCollapseTree_Click(sender As Object, e As EventArgs) Handles mnuCollapseTree.Click
        TreeView1.CollapseAll()
    End Sub

    Private Sub mnuExpandTree_Click(sender As Object, e As EventArgs) Handles mnuExpandTree.Click
        TreeView1.ExpandAll()
    End Sub

    Private Sub CopyToClipBoard_Click(sender As Object, e As EventArgs) Handles CopyToClipBoard.Click
        Dim SelectedNode As New TreeNode
        SelectedNode = TreeView1.SelectedNode
        If Not SelectedNode.Name = Nothing Then
            If SelectedNode.Tag = "File" Then
                Dim DataObject As New DataObject
                Dim tempFileArray(0) As String
                'NOTE THAT IT MUST BE PASSED AN ARRAY!!!
                tempFileArray(0) = SelectedNode.Name
                DataObject.SetData(DataFormats.FileDrop, False, tempFileArray)
                Clipboard.SetDataObject(DataObject)
            Else
                MsgBox("No image selected", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "You must select an image")
            End If
        Else
            MsgBox("No image selected", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "You must select an image")
        End If
    End Sub

    Private Sub mnuStatistics_Click(sender As Object, e As EventArgs) Handles mnuStatistics.Click
        GetStatistics()
    End Sub
End Class
