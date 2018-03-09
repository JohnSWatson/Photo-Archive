<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PhotoArchiveMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PhotoArchiveMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchive = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ArciveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSearchTerm = New System.Windows.Forms.ToolStripLabel()
        Me.SearchTerm = New System.Windows.Forms.ToolStripTextBox()
        Me.mnuAbout = New System.Windows.Forms.ToolStripButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.mnuTreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExpandTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCollapseTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefreshTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenInExplorer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGetDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMoveToPrivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMoveToReview = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMoveToNeedsWork = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMoveToDisplayReady = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToClipBoard = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteThis = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuStatistics = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Pic1Name = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pic2Name = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.mnuTreeView.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuArchive, Me.lblSearchTerm, Me.SearchTerm, Me.mnuAbout})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1300, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.FileToolStripMenuItem})
        Me.mnuFile.Image = CType(resources.GetObject("mnuFile.Image"), System.Drawing.Image)
        Me.mnuFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(38, 22)
        Me.mnuFile.Text = "File"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(89, 6)
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.FileToolStripMenuItem.Text = "Exit"
        '
        'mnuArchive
        '
        Me.mnuArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuArchive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArciveToolStripMenuItem, Me.SearchArchiveToolStripMenuItem})
        Me.mnuArchive.Image = CType(resources.GetObject("mnuArchive.Image"), System.Drawing.Image)
        Me.mnuArchive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuArchive.Name = "mnuArchive"
        Me.mnuArchive.Size = New System.Drawing.Size(60, 22)
        Me.mnuArchive.Text = "Archive"
        '
        'ArciveToolStripMenuItem
        '
        Me.ArciveToolStripMenuItem.Name = "ArciveToolStripMenuItem"
        Me.ArciveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ArciveToolStripMenuItem.Text = "Archive Folder"
        '
        'SearchArchiveToolStripMenuItem
        '
        Me.SearchArchiveToolStripMenuItem.Name = "SearchArchiveToolStripMenuItem"
        Me.SearchArchiveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SearchArchiveToolStripMenuItem.Text = "Search Archive"
        '
        'lblSearchTerm
        '
        Me.lblSearchTerm.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblSearchTerm.BackgroundImage = Global.Photo_Archive.My.Resources.Resources.download
        Me.lblSearchTerm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblSearchTerm.Name = "lblSearchTerm"
        Me.lblSearchTerm.Size = New System.Drawing.Size(42, 22)
        Me.lblSearchTerm.Text = "Search"
        '
        'SearchTerm
        '
        Me.SearchTerm.BackColor = System.Drawing.SystemColors.Info
        Me.SearchTerm.Name = "SearchTerm"
        Me.SearchTerm.Size = New System.Drawing.Size(200, 25)
        '
        'mnuAbout
        '
        Me.mnuAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuAbout.Image = CType(resources.GetObject("mnuAbout.Image"), System.Drawing.Image)
        Me.mnuAbout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(44, 22)
        Me.mnuAbout.Text = "About"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1300, 584)
        Me.SplitContainer1.SplitterDistance = 433
        Me.SplitContainer1.TabIndex = 1
        '
        'TreeView1
        '
        Me.TreeView1.ContextMenuStrip = Me.mnuTreeView
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(433, 584)
        Me.TreeView1.TabIndex = 0
        '
        'mnuTreeView
        '
        Me.mnuTreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExpandTree, Me.mnuCollapseTree, Me.mnuRefreshTree, Me.ToolStripSeparator2, Me.mnuEditImage, Me.mnuOpenInExplorer, Me.mnuGetDetails, Me.ToolStripSeparator3, Me.mnuMoveToPrivate, Me.mnuMoveToReview, Me.mnuMoveToNeedsWork, Me.mnuMoveToDisplayReady, Me.CopyToClipBoard, Me.mnuDeleteThis, Me.ToolStripSeparator4, Me.mnuStatistics})
        Me.mnuTreeView.Name = "ContextMenuStrip1"
        Me.mnuTreeView.Size = New System.Drawing.Size(198, 308)
        '
        'mnuExpandTree
        '
        Me.mnuExpandTree.Name = "mnuExpandTree"
        Me.mnuExpandTree.Size = New System.Drawing.Size(197, 22)
        Me.mnuExpandTree.Text = "Expand The Tree"
        '
        'mnuCollapseTree
        '
        Me.mnuCollapseTree.Name = "mnuCollapseTree"
        Me.mnuCollapseTree.Size = New System.Drawing.Size(197, 22)
        Me.mnuCollapseTree.Text = "Collapse the tree"
        '
        'mnuRefreshTree
        '
        Me.mnuRefreshTree.Name = "mnuRefreshTree"
        Me.mnuRefreshTree.Size = New System.Drawing.Size(197, 22)
        Me.mnuRefreshTree.Text = "Refresh the tree"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(194, 6)
        '
        'mnuEditImage
        '
        Me.mnuEditImage.Name = "mnuEditImage"
        Me.mnuEditImage.Size = New System.Drawing.Size(197, 22)
        Me.mnuEditImage.Text = "Edit Image"
        '
        'mnuOpenInExplorer
        '
        Me.mnuOpenInExplorer.Name = "mnuOpenInExplorer"
        Me.mnuOpenInExplorer.Size = New System.Drawing.Size(197, 22)
        Me.mnuOpenInExplorer.Text = "Open Folder in explorer"
        '
        'mnuGetDetails
        '
        Me.mnuGetDetails.Name = "mnuGetDetails"
        Me.mnuGetDetails.Size = New System.Drawing.Size(197, 22)
        Me.mnuGetDetails.Text = "Get details"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(194, 6)
        '
        'mnuMoveToPrivate
        '
        Me.mnuMoveToPrivate.Name = "mnuMoveToPrivate"
        Me.mnuMoveToPrivate.Size = New System.Drawing.Size(197, 22)
        Me.mnuMoveToPrivate.Text = "Move this to Privete"
        '
        'mnuMoveToReview
        '
        Me.mnuMoveToReview.Name = "mnuMoveToReview"
        Me.mnuMoveToReview.Size = New System.Drawing.Size(197, 22)
        Me.mnuMoveToReview.Text = "Move to Review"
        '
        'mnuMoveToNeedsWork
        '
        Me.mnuMoveToNeedsWork.Name = "mnuMoveToNeedsWork"
        Me.mnuMoveToNeedsWork.Size = New System.Drawing.Size(197, 22)
        Me.mnuMoveToNeedsWork.Text = "Move to Needs Work"
        '
        'mnuMoveToDisplayReady
        '
        Me.mnuMoveToDisplayReady.Name = "mnuMoveToDisplayReady"
        Me.mnuMoveToDisplayReady.Size = New System.Drawing.Size(197, 22)
        Me.mnuMoveToDisplayReady.Text = "Move to Display Ready"
        '
        'CopyToClipBoard
        '
        Me.CopyToClipBoard.Name = "CopyToClipBoard"
        Me.CopyToClipBoard.Size = New System.Drawing.Size(197, 22)
        Me.CopyToClipBoard.Text = "Copy to clipboard"
        '
        'mnuDeleteThis
        '
        Me.mnuDeleteThis.Name = "mnuDeleteThis"
        Me.mnuDeleteThis.Size = New System.Drawing.Size(197, 22)
        Me.mnuDeleteThis.Text = "Delete this"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(194, 6)
        '
        'mnuStatistics
        '
        Me.mnuStatistics.Name = "mnuStatistics"
        Me.mnuStatistics.Size = New System.Drawing.Size(197, 22)
        Me.mnuStatistics.Text = "Statistics"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Closed Folder.ico")
        Me.ImageList1.Images.SetKeyName(1, "Open folder.ico")
        Me.ImageList1.Images.SetKeyName(2, "shuter.ico")
        Me.ImageList1.Images.SetKeyName(3, "pictures.ico")
        Me.ImageList1.Images.SetKeyName(4, "folder with Contents.ico")
        Me.ImageList1.Images.SetKeyName(5, "SelectedPhoto.ico")
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Pic1Name)
        Me.SplitContainer2.Panel1.Controls.Add(Me.PictureBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Pic2Name)
        Me.SplitContainer2.Panel2.Controls.Add(Me.PictureBox2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Splitter2)
        Me.SplitContainer2.Size = New System.Drawing.Size(860, 584)
        Me.SplitContainer2.SplitterDistance = 301
        Me.SplitContainer2.TabIndex = 1
        '
        'Pic1Name
        '
        Me.Pic1Name.AutoSize = True
        Me.Pic1Name.BackColor = System.Drawing.Color.Yellow
        Me.Pic1Name.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pic1Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pic1Name.Location = New System.Drawing.Point(0, 0)
        Me.Pic1Name.Name = "Pic1Name"
        Me.Pic1Name.Size = New System.Drawing.Size(48, 18)
        Me.Pic1Name.TabIndex = 1
        Me.Pic1Name.Text = "Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(860, 301)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Pic2Name
        '
        Me.Pic2Name.AutoSize = True
        Me.Pic2Name.BackColor = System.Drawing.Color.SpringGreen
        Me.Pic2Name.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pic2Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pic2Name.Location = New System.Drawing.Point(3, 0)
        Me.Pic2Name.Name = "Pic2Name"
        Me.Pic2Name.Size = New System.Drawing.Size(48, 18)
        Me.Pic2Name.TabIndex = 2
        Me.Pic2Name.Text = "Name"
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(857, 279)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Splitter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter2.Location = New System.Drawing.Point(0, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 279)
        Me.Splitter2.TabIndex = 0
        Me.Splitter2.TabStop = False
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 584)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'PhotoArchiveMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 609)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PhotoArchiveMain"
        Me.Text = "Photo Archive"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.mnuTreeView.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents mnuFile As ToolStripDropDownButton
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents mnuArchive As ToolStripDropDownButton
    Friend WithEvents ArciveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuAbout As ToolStripButton
    Friend WithEvents SearchArchiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Splitter2 As Splitter
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents lblSearchTerm As ToolStripLabel
    Friend WithEvents SearchTerm As ToolStripTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Pic1Name As Label
    Friend WithEvents Pic2Name As Label
    Friend WithEvents mnuTreeView As ContextMenuStrip
    Friend WithEvents mnuDeleteThis As ToolStripMenuItem
    Friend WithEvents mnuMoveToPrivate As ToolStripMenuItem
    Friend WithEvents mnuGetDetails As ToolStripMenuItem
    Friend WithEvents mnuMoveToReview As ToolStripMenuItem
    Friend WithEvents mnuMoveToNeedsWork As ToolStripMenuItem
    Friend WithEvents mnuMoveToDisplayReady As ToolStripMenuItem
    Friend WithEvents mnuOpenInExplorer As ToolStripMenuItem
    Friend WithEvents mnuRefreshTree As ToolStripMenuItem
    Friend WithEvents mnuEditImage As ToolStripMenuItem
    Friend WithEvents mnuExpandTree As ToolStripMenuItem
    Friend WithEvents mnuCollapseTree As ToolStripMenuItem
    Friend WithEvents CopyToClipBoard As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents mnuStatistics As ToolStripMenuItem
End Class
