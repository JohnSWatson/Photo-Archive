<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArchive
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArchive))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar2 = New System.Windows.Forms.ToolStripProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvFolders = New System.Windows.Forms.ListView()
        Me.Folder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Photos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Method = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FullPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Notes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectAllforActions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeselectall = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuActions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivefordisplay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnArchiveforFamilyHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchiveForPrivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDoNotArchive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteSource = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTickAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUntickAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTickSpecialAction = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAuto = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMoreWork = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPublic = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPutInFamilyHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPublicPrivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDontArchive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDoArchive = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArchiveHelpProvider = New System.Windows.Forms.HelpProvider()
        Me.mnuArchiveforPrivateDisplay = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripProgressBar2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 574)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1372, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(113, 17)
        Me.ToolStripStatusLabel2.Text = "Searching folders     "
        '
        'ToolStripProgressBar2
        '
        Me.ToolStripProgressBar2.Name = "ToolStripProgressBar2"
        Me.ToolStripProgressBar2.Size = New System.Drawing.Size(300, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1372, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(145, 20)
        Me.LoadToolStripMenuItem.Text = "Select Folder To Archive"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'lvFolders
        '
        Me.lvFolders.CheckBoxes = True
        Me.lvFolders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Folder, Me.Photos, Me.Status, Me.Method, Me.FullPath, Me.Notes})
        Me.lvFolders.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvFolders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvFolders.FullRowSelect = True
        Me.lvFolders.GridLines = True
        Me.ArchiveHelpProvider.SetHelpString(Me.lvFolders, "Lists all folders with photos selected. Those folders with a tick will be actione" &
        "d.")
        Me.lvFolders.Location = New System.Drawing.Point(0, 24)
        Me.lvFolders.MultiSelect = False
        Me.lvFolders.Name = "lvFolders"
        Me.ArchiveHelpProvider.SetShowHelp(Me.lvFolders, True)
        Me.lvFolders.Size = New System.Drawing.Size(1372, 550)
        Me.lvFolders.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvFolders.TabIndex = 4
        Me.lvFolders.UseCompatibleStateImageBehavior = False
        Me.lvFolders.View = System.Windows.Forms.View.Details
        '
        'Folder
        '
        Me.Folder.Text = "Folders"
        Me.Folder.Width = 600
        '
        'Photos
        '
        Me.Photos.Text = "Photos"
        Me.Photos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Photos.Width = 100
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 100
        '
        'Method
        '
        Me.Method.Text = "Archive Action"
        Me.Method.Width = 120
        '
        'FullPath
        '
        Me.FullPath.Text = "Full path"
        Me.FullPath.Width = 0
        '
        'Notes
        '
        Me.Notes.Text = "Notes"
        Me.Notes.Width = 400
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelection, Me.mnuActions, Me.mnuTickAll, Me.mnuUntickAll, Me.mnuTickSpecialAction, Me.ToolStripSeparator1, Me.mnuAuto, Me.mnuPrivate, Me.mnuMoreWork, Me.mnuPublic, Me.mnuPutInFamilyHistory, Me.mnuPublicPrivate, Me.ToolStripSeparator3, Me.mnuDontArchive, Me.mnuDeleteFolder, Me.ToolStripSeparator2, Me.mnuDoArchive})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(304, 352)
        '
        'mnuSelection
        '
        Me.mnuSelection.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectAllforActions, Me.mnuDeselectall})
        Me.mnuSelection.Name = "mnuSelection"
        Me.mnuSelection.Size = New System.Drawing.Size(303, 22)
        Me.mnuSelection.Text = "Select for Actions"
        '
        'mnuSelectAllforActions
        '
        Me.mnuSelectAllforActions.Name = "mnuSelectAllforActions"
        Me.mnuSelectAllforActions.Size = New System.Drawing.Size(133, 22)
        Me.mnuSelectAllforActions.Text = "Select all"
        '
        'mnuDeselectall
        '
        Me.mnuDeselectall.Name = "mnuDeselectall"
        Me.mnuDeselectall.Size = New System.Drawing.Size(133, 22)
        Me.mnuDeselectall.Text = "Deselect all"
        '
        'mnuActions
        '
        Me.mnuActions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivefordisplay, Me.mnuArchiveForPrivate, Me.mnuArchiveforPrivateDisplay, Me.mnArchiveforFamilyHistory, Me.mnuDoNotArchive, Me.mnuDeleteSource})
        Me.mnuActions.Name = "mnuActions"
        Me.mnuActions.Size = New System.Drawing.Size(303, 22)
        Me.mnuActions.Text = "Actions"
        '
        'mnuArchivefordisplay
        '
        Me.mnuArchivefordisplay.Name = "mnuArchivefordisplay"
        Me.mnuArchivefordisplay.Size = New System.Drawing.Size(215, 22)
        Me.mnuArchivefordisplay.Text = "Archive for Display"
        '
        'mnArchiveforFamilyHistory
        '
        Me.mnArchiveforFamilyHistory.Name = "mnArchiveforFamilyHistory"
        Me.mnArchiveforFamilyHistory.Size = New System.Drawing.Size(215, 22)
        Me.mnArchiveforFamilyHistory.Text = "Archive for Family History"
        '
        'mnuArchiveForPrivate
        '
        Me.mnuArchiveForPrivate.Name = "mnuArchiveForPrivate"
        Me.mnuArchiveForPrivate.Size = New System.Drawing.Size(215, 22)
        Me.mnuArchiveForPrivate.Text = "Archive For Private"
        '
        'mnuDoNotArchive
        '
        Me.mnuDoNotArchive.Name = "mnuDoNotArchive"
        Me.mnuDoNotArchive.Size = New System.Drawing.Size(215, 22)
        Me.mnuDoNotArchive.Text = "Don't archive"
        '
        'mnuDeleteSource
        '
        Me.mnuDeleteSource.Name = "mnuDeleteSource"
        Me.mnuDeleteSource.Size = New System.Drawing.Size(215, 22)
        Me.mnuDeleteSource.Text = "Delete Source"
        '
        'mnuTickAll
        '
        Me.mnuTickAll.BackColor = System.Drawing.Color.Yellow
        Me.mnuTickAll.Name = "mnuTickAll"
        Me.mnuTickAll.Size = New System.Drawing.Size(303, 22)
        Me.mnuTickAll.Text = "Tick All"
        '
        'mnuUntickAll
        '
        Me.mnuUntickAll.BackColor = System.Drawing.Color.Yellow
        Me.mnuUntickAll.Name = "mnuUntickAll"
        Me.mnuUntickAll.Size = New System.Drawing.Size(303, 22)
        Me.mnuUntickAll.Text = "Untick All"
        '
        'mnuTickSpecialAction
        '
        Me.mnuTickSpecialAction.BackColor = System.Drawing.Color.Yellow
        Me.mnuTickSpecialAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.mnuTickSpecialAction.Name = "mnuTickSpecialAction"
        Me.mnuTickSpecialAction.Size = New System.Drawing.Size(303, 22)
        Me.mnuTickSpecialAction.Text = "Tick Special Action (Not Auto)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem2.Text = "ToolStripMenuItem2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(300, 6)
        '
        'mnuAuto
        '
        Me.mnuAuto.Name = "mnuAuto"
        Me.mnuAuto.Size = New System.Drawing.Size(303, 22)
        Me.mnuAuto.Text = "Mark ticked to auto select archive action"
        '
        'mnuPrivate
        '
        Me.mnuPrivate.Name = "mnuPrivate"
        Me.mnuPrivate.Size = New System.Drawing.Size(303, 22)
        Me.mnuPrivate.Text = "Mark ticked to put in private archive"
        '
        'mnuMoreWork
        '
        Me.mnuMoreWork.Name = "mnuMoreWork"
        Me.mnuMoreWork.Size = New System.Drawing.Size(303, 22)
        Me.mnuMoreWork.Text = "Mark ticked to put in More work archive"
        '
        'mnuPublic
        '
        Me.mnuPublic.Name = "mnuPublic"
        Me.mnuPublic.Size = New System.Drawing.Size(303, 22)
        Me.mnuPublic.Text = "Mark ticked to put in public archive"
        '
        'mnuPutInFamilyHistory
        '
        Me.mnuPutInFamilyHistory.Name = "mnuPutInFamilyHistory"
        Me.mnuPutInFamilyHistory.Size = New System.Drawing.Size(303, 22)
        Me.mnuPutInFamilyHistory.Text = "Mark ticked to put in Family history"
        '
        'mnuPublicPrivate
        '
        Me.mnuPublicPrivate.Name = "mnuPublicPrivate"
        Me.mnuPublicPrivate.Size = New System.Drawing.Size(303, 22)
        Me.mnuPublicPrivate.Text = "Mark ticked to put in public AND private archive"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(300, 6)
        '
        'mnuDontArchive
        '
        Me.mnuDontArchive.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mnuDontArchive.Name = "mnuDontArchive"
        Me.mnuDontArchive.Size = New System.Drawing.Size(303, 22)
        Me.mnuDontArchive.Text = "Dont archive"
        '
        'mnuDeleteFolder
        '
        Me.mnuDeleteFolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mnuDeleteFolder.Name = "mnuDeleteFolder"
        Me.mnuDeleteFolder.Size = New System.Drawing.Size(303, 22)
        Me.mnuDeleteFolder.Text = "Delete this folder"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(300, 6)
        '
        'mnuDoArchive
        '
        Me.mnuDoArchive.BackColor = System.Drawing.Color.Red
        Me.mnuDoArchive.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.mnuDoArchive.Name = "mnuDoArchive"
        Me.mnuDoArchive.Size = New System.Drawing.Size(303, 22)
        Me.mnuDoArchive.Text = "Archaive all ticked folders"
        '
        'mnuArchiveforPrivateDisplay
        '
        Me.mnuArchiveforPrivateDisplay.Name = "mnuArchiveforPrivateDisplay"
        Me.mnuArchiveforPrivateDisplay.Size = New System.Drawing.Size(215, 22)
        Me.mnuArchiveforPrivateDisplay.Text = "Archive for Private & Display"
        '
        'frmArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1372, 596)
        Me.Controls.Add(Me.lvFolders)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmArchive"
        Me.Text = "Archive"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar2 As ToolStripProgressBar
    Friend WithEvents lvFolders As ListView
    Friend WithEvents Folder As ColumnHeader
    Friend WithEvents Photos As ColumnHeader
    Friend WithEvents Status As ColumnHeader
    Friend WithEvents Method As ColumnHeader
    Friend WithEvents FullPath As ColumnHeader
    Friend WithEvents ArchiveHelpProvider As HelpProvider
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents mnuTickAll As ToolStripMenuItem
    Friend WithEvents mnuUntickAll As ToolStripMenuItem
    Friend WithEvents mnuTickSpecialAction As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuAuto As ToolStripMenuItem
    Friend WithEvents mnuPrivate As ToolStripMenuItem
    Friend WithEvents mnuMoreWork As ToolStripMenuItem
    Friend WithEvents mnuPublic As ToolStripMenuItem
    Friend WithEvents mnuPublicPrivate As ToolStripMenuItem
    Friend WithEvents mnuDontArchive As ToolStripMenuItem
    Friend WithEvents mnuDeleteFolder As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuDoArchive As ToolStripMenuItem
    Friend WithEvents mnuPutInFamilyHistory As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Notes As ColumnHeader
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents mnuSelection As ToolStripMenuItem
    Friend WithEvents mnuSelectAllforActions As ToolStripMenuItem
    Friend WithEvents mnuDeselectall As ToolStripMenuItem
    Friend WithEvents mnuActions As ToolStripMenuItem
    Friend WithEvents mnuArchivefordisplay As ToolStripMenuItem
    Friend WithEvents mnArchiveforFamilyHistory As ToolStripMenuItem
    Friend WithEvents mnuArchiveForPrivate As ToolStripMenuItem
    Friend WithEvents mnuDoNotArchive As ToolStripMenuItem
    Friend WithEvents mnuDeleteSource As ToolStripMenuItem
    Friend WithEvents mnuArchiveforPrivateDisplay As ToolStripMenuItem
End Class
