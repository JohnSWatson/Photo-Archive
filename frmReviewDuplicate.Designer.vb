<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReviewDuplicate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReviewDuplicate))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.RemoveFromArchive = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtArchiveingDateTaken = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnTakeAction = New System.Windows.Forms.Button()
        Me.ArchiveingPicture = New System.Windows.Forms.PictureBox()
        Me.btnPutinPrivateArchive = New System.Windows.Forms.RadioButton()
        Me.btnPutinReview = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPutinNeedsWork = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnPutinDisplayReady = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReplaceInArchive = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMarkArchived = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtArchiveingTags = New System.Windows.Forms.TextBox()
        Me.txtArchiveingComment = New System.Windows.Forms.TextBox()
        Me.txtArchiveingRating = New System.Windows.Forms.TextBox()
        Me.txtArchiveingSubject = New System.Windows.Forms.TextBox()
        Me.txtArchiveingTitle = New System.Windows.Forms.TextBox()
        Me.txtArchiveingHeading = New System.Windows.Forms.TextBox()
        Me.lblWhatWillHappen = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDuplicateDateTaken = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DuplicatePicture = New System.Windows.Forms.PictureBox()
        Me.txtDuplicateHeading = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDuplicateTags = New System.Windows.Forms.TextBox()
        Me.txtDuplicateComment = New System.Windows.Forms.TextBox()
        Me.txtDuplicateRating = New System.Windows.Forms.TextBox()
        Me.txtDuplicateSubject = New System.Windows.Forms.TextBox()
        Me.txtDuplicateTitle = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtArchiveingPath = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDuplicatePath = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ArchiveingPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DuplicatePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingPath)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RemoveFromArchive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingDateTaken)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnTakeAction)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ArchiveingPicture)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPutinPrivateArchive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPutinReview)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPutinNeedsWork)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnPutinDisplayReady)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnReplaceInArchive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnMarkArchived)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingTags)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingComment)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingRating)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtArchiveingHeading)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicatePath)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblWhatWillHappen)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicateDateTaken)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DuplicatePicture)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicateHeading)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicateTags)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicateComment)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicateRating)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicateSubject)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDuplicateTitle)
        Me.SplitContainer1.Size = New System.Drawing.Size(1386, 646)
        Me.SplitContainer1.SplitterDistance = 687
        Me.SplitContainer1.TabIndex = 0
        '
        'RemoveFromArchive
        '
        Me.RemoveFromArchive.AutoSize = True
        Me.RemoveFromArchive.Location = New System.Drawing.Point(402, 492)
        Me.RemoveFromArchive.Name = "RemoveFromArchive"
        Me.RemoveFromArchive.Size = New System.Drawing.Size(126, 17)
        Me.RemoveFromArchive.TabIndex = 37
        Me.RemoveFromArchive.Text = "Remove from archive"
        Me.RemoveFromArchive.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(91, 563)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(100, 3, 100, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(122, 23)
        Me.CheckBox1.TabIndex = 36
        Me.CheckBox1.Text = "Review next duplicate"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(28, 364)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Date taken"
        '
        'txtArchiveingDateTaken
        '
        Me.txtArchiveingDateTaken.Enabled = False
        Me.txtArchiveingDateTaken.Location = New System.Drawing.Point(89, 360)
        Me.txtArchiveingDateTaken.Name = "txtArchiveingDateTaken"
        Me.txtArchiveingDateTaken.Size = New System.Drawing.Size(495, 20)
        Me.txtArchiveingDateTaken.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Window
        Me.Label11.Location = New System.Drawing.Point(236, 602)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(199, 22)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Picture To Be Archived"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnTakeAction
        '
        Me.btnTakeAction.Location = New System.Drawing.Point(578, 593)
        Me.btnTakeAction.Name = "btnTakeAction"
        Me.btnTakeAction.Size = New System.Drawing.Size(81, 28)
        Me.btnTakeAction.TabIndex = 29
        Me.btnTakeAction.Text = "Take Action"
        Me.btnTakeAction.UseVisualStyleBackColor = True
        '
        'ArchiveingPicture
        '
        Me.ArchiveingPicture.Location = New System.Drawing.Point(26, 26)
        Me.ArchiveingPicture.Name = "ArchiveingPicture"
        Me.ArchiveingPicture.Size = New System.Drawing.Size(609, 300)
        Me.ArchiveingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ArchiveingPicture.TabIndex = 11
        Me.ArchiveingPicture.TabStop = False
        '
        'btnPutinPrivateArchive
        '
        Me.btnPutinPrivateArchive.AutoSize = True
        Me.btnPutinPrivateArchive.Location = New System.Drawing.Point(251, 540)
        Me.btnPutinPrivateArchive.Name = "btnPutinPrivateArchive"
        Me.btnPutinPrivateArchive.Size = New System.Drawing.Size(126, 17)
        Me.btnPutinPrivateArchive.TabIndex = 28
        Me.btnPutinPrivateArchive.Text = "Put in private Archive"
        Me.btnPutinPrivateArchive.UseVisualStyleBackColor = True
        '
        'btnPutinReview
        '
        Me.btnPutinReview.AutoSize = True
        Me.btnPutinReview.Location = New System.Drawing.Point(251, 516)
        Me.btnPutinReview.Name = "btnPutinReview"
        Me.btnPutinReview.Size = New System.Drawing.Size(91, 17)
        Me.btnPutinReview.TabIndex = 27
        Me.btnPutinReview.Text = "Put in Review"
        Me.btnPutinReview.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 464)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Tags"
        '
        'btnPutinNeedsWork
        '
        Me.btnPutinNeedsWork.AutoSize = True
        Me.btnPutinNeedsWork.Location = New System.Drawing.Point(251, 492)
        Me.btnPutinNeedsWork.Name = "btnPutinNeedsWork"
        Me.btnPutinNeedsWork.Size = New System.Drawing.Size(112, 17)
        Me.btnPutinNeedsWork.TabIndex = 26
        Me.btnPutinNeedsWork.Text = "Put in Needs work"
        Me.btnPutinNeedsWork.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 444)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Comment"
        '
        'btnPutinDisplayReady
        '
        Me.btnPutinDisplayReady.AutoSize = True
        Me.btnPutinDisplayReady.Location = New System.Drawing.Point(91, 540)
        Me.btnPutinDisplayReady.Name = "btnPutinDisplayReady"
        Me.btnPutinDisplayReady.Size = New System.Drawing.Size(116, 17)
        Me.btnPutinDisplayReady.TabIndex = 25
        Me.btnPutinDisplayReady.Text = "Put in display ready"
        Me.btnPutinDisplayReady.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ratting"
        '
        'btnReplaceInArchive
        '
        Me.btnReplaceInArchive.AutoSize = True
        Me.btnReplaceInArchive.Location = New System.Drawing.Point(91, 516)
        Me.btnReplaceInArchive.Name = "btnReplaceInArchive"
        Me.btnReplaceInArchive.Size = New System.Drawing.Size(114, 17)
        Me.btnReplaceInArchive.TabIndex = 24
        Me.btnReplaceInArchive.Text = "Replace in archive"
        Me.btnReplaceInArchive.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 404)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Subject"
        '
        'btnMarkArchived
        '
        Me.btnMarkArchived.AutoSize = True
        Me.btnMarkArchived.Location = New System.Drawing.Point(91, 492)
        Me.btnMarkArchived.Name = "btnMarkArchived"
        Me.btnMarkArchived.Size = New System.Drawing.Size(93, 17)
        Me.btnMarkArchived.TabIndex = 23
        Me.btnMarkArchived.Text = "Mark archived"
        Me.btnMarkArchived.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 384)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Title"
        '
        'txtArchiveingTags
        '
        Me.txtArchiveingTags.Enabled = False
        Me.txtArchiveingTags.Location = New System.Drawing.Point(89, 460)
        Me.txtArchiveingTags.Name = "txtArchiveingTags"
        Me.txtArchiveingTags.Size = New System.Drawing.Size(495, 20)
        Me.txtArchiveingTags.TabIndex = 5
        '
        'txtArchiveingComment
        '
        Me.txtArchiveingComment.Enabled = False
        Me.txtArchiveingComment.Location = New System.Drawing.Point(89, 440)
        Me.txtArchiveingComment.Name = "txtArchiveingComment"
        Me.txtArchiveingComment.Size = New System.Drawing.Size(495, 20)
        Me.txtArchiveingComment.TabIndex = 4
        '
        'txtArchiveingRating
        '
        Me.txtArchiveingRating.Enabled = False
        Me.txtArchiveingRating.Location = New System.Drawing.Point(89, 420)
        Me.txtArchiveingRating.Name = "txtArchiveingRating"
        Me.txtArchiveingRating.Size = New System.Drawing.Size(495, 20)
        Me.txtArchiveingRating.TabIndex = 3
        '
        'txtArchiveingSubject
        '
        Me.txtArchiveingSubject.Enabled = False
        Me.txtArchiveingSubject.Location = New System.Drawing.Point(89, 400)
        Me.txtArchiveingSubject.Name = "txtArchiveingSubject"
        Me.txtArchiveingSubject.Size = New System.Drawing.Size(495, 20)
        Me.txtArchiveingSubject.TabIndex = 2
        '
        'txtArchiveingTitle
        '
        Me.txtArchiveingTitle.Enabled = False
        Me.txtArchiveingTitle.Location = New System.Drawing.Point(89, 380)
        Me.txtArchiveingTitle.Name = "txtArchiveingTitle"
        Me.txtArchiveingTitle.Size = New System.Drawing.Size(495, 20)
        Me.txtArchiveingTitle.TabIndex = 1
        '
        'txtArchiveingHeading
        '
        Me.txtArchiveingHeading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtArchiveingHeading.Enabled = False
        Me.txtArchiveingHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchiveingHeading.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtArchiveingHeading.Location = New System.Drawing.Point(26, 3)
        Me.txtArchiveingHeading.Name = "txtArchiveingHeading"
        Me.txtArchiveingHeading.Size = New System.Drawing.Size(609, 23)
        Me.txtArchiveingHeading.TabIndex = 0
        '
        'lblWhatWillHappen
        '
        Me.lblWhatWillHappen.BackColor = System.Drawing.SystemColors.Control
        Me.lblWhatWillHappen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblWhatWillHappen.Enabled = False
        Me.lblWhatWillHappen.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhatWillHappen.Location = New System.Drawing.Point(49, 502)
        Me.lblWhatWillHappen.Multiline = True
        Me.lblWhatWillHappen.Name = "lblWhatWillHappen"
        Me.lblWhatWillHappen.Size = New System.Drawing.Size(609, 82)
        Me.lblWhatWillHappen.TabIndex = 35
        Me.lblWhatWillHappen.Text = "No action selected for the image"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(50, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Date taken"
        '
        'txtDuplicateDateTaken
        '
        Me.txtDuplicateDateTaken.Enabled = False
        Me.txtDuplicateDateTaken.Location = New System.Drawing.Point(111, 360)
        Me.txtDuplicateDateTaken.Name = "txtDuplicateDateTaken"
        Me.txtDuplicateDateTaken.Size = New System.Drawing.Size(495, 20)
        Me.txtDuplicateDateTaken.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Window
        Me.Label12.Location = New System.Drawing.Point(246, 600)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(188, 22)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Picture In the Archive"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DuplicatePicture
        '
        Me.DuplicatePicture.Location = New System.Drawing.Point(51, 26)
        Me.DuplicatePicture.Name = "DuplicatePicture"
        Me.DuplicatePicture.Size = New System.Drawing.Size(609, 300)
        Me.DuplicatePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.DuplicatePicture.TabIndex = 22
        Me.DuplicatePicture.TabStop = False
        '
        'txtDuplicateHeading
        '
        Me.txtDuplicateHeading.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDuplicateHeading.Enabled = False
        Me.txtDuplicateHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuplicateHeading.ForeColor = System.Drawing.SystemColors.MenuText
        Me.txtDuplicateHeading.Location = New System.Drawing.Point(51, 3)
        Me.txtDuplicateHeading.Name = "txtDuplicateHeading"
        Me.txtDuplicateHeading.Size = New System.Drawing.Size(609, 23)
        Me.txtDuplicateHeading.TabIndex = 21
        Me.txtDuplicateHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 464)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tags"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 444)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Comment"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 424)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Ratting"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(50, 404)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Subject"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(50, 384)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Title"
        '
        'txtDuplicateTags
        '
        Me.txtDuplicateTags.Enabled = False
        Me.txtDuplicateTags.Location = New System.Drawing.Point(111, 460)
        Me.txtDuplicateTags.Name = "txtDuplicateTags"
        Me.txtDuplicateTags.Size = New System.Drawing.Size(495, 20)
        Me.txtDuplicateTags.TabIndex = 15
        '
        'txtDuplicateComment
        '
        Me.txtDuplicateComment.Enabled = False
        Me.txtDuplicateComment.Location = New System.Drawing.Point(111, 440)
        Me.txtDuplicateComment.Name = "txtDuplicateComment"
        Me.txtDuplicateComment.Size = New System.Drawing.Size(495, 20)
        Me.txtDuplicateComment.TabIndex = 14
        '
        'txtDuplicateRating
        '
        Me.txtDuplicateRating.Enabled = False
        Me.txtDuplicateRating.Location = New System.Drawing.Point(111, 420)
        Me.txtDuplicateRating.Name = "txtDuplicateRating"
        Me.txtDuplicateRating.Size = New System.Drawing.Size(495, 20)
        Me.txtDuplicateRating.TabIndex = 13
        '
        'txtDuplicateSubject
        '
        Me.txtDuplicateSubject.Enabled = False
        Me.txtDuplicateSubject.Location = New System.Drawing.Point(111, 400)
        Me.txtDuplicateSubject.Name = "txtDuplicateSubject"
        Me.txtDuplicateSubject.Size = New System.Drawing.Size(495, 20)
        Me.txtDuplicateSubject.TabIndex = 12
        '
        'txtDuplicateTitle
        '
        Me.txtDuplicateTitle.Enabled = False
        Me.txtDuplicateTitle.Location = New System.Drawing.Point(111, 380)
        Me.txtDuplicateTitle.Name = "txtDuplicateTitle"
        Me.txtDuplicateTitle.Size = New System.Drawing.Size(495, 20)
        Me.txtDuplicateTitle.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(28, 343)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Path"
        '
        'txtArchiveingPath
        '
        Me.txtArchiveingPath.Enabled = False
        Me.txtArchiveingPath.Location = New System.Drawing.Point(89, 340)
        Me.txtArchiveingPath.Name = "txtArchiveingPath"
        Me.txtArchiveingPath.Size = New System.Drawing.Size(495, 20)
        Me.txtArchiveingPath.TabIndex = 38
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(50, 344)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 13)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Path"
        '
        'txtDuplicatePath
        '
        Me.txtDuplicatePath.Enabled = False
        Me.txtDuplicatePath.Location = New System.Drawing.Point(111, 340)
        Me.txtDuplicatePath.Name = "txtDuplicatePath"
        Me.txtDuplicatePath.Size = New System.Drawing.Size(495, 20)
        Me.txtDuplicatePath.TabIndex = 36
        '
        'frmReviewDuplicate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1386, 646)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReviewDuplicate"
        Me.Text = "Duplicate image"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ArchiveingPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DuplicatePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents txtArchiveingComment As TextBox
    Friend WithEvents txtArchiveingRating As TextBox
    Friend WithEvents txtArchiveingSubject As TextBox
    Friend WithEvents txtArchiveingTitle As TextBox
    Friend WithEvents txtArchiveingHeading As TextBox
    Friend WithEvents ArchiveingPicture As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtArchiveingTags As TextBox
    Friend WithEvents DuplicatePicture As PictureBox
    Friend WithEvents txtDuplicateHeading As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDuplicateTags As TextBox
    Friend WithEvents txtDuplicateComment As TextBox
    Friend WithEvents txtDuplicateRating As TextBox
    Friend WithEvents txtDuplicateSubject As TextBox
    Friend WithEvents txtDuplicateTitle As TextBox
    Friend WithEvents btnTakeAction As Button
    Friend WithEvents btnPutinPrivateArchive As RadioButton
    Friend WithEvents btnPutinReview As RadioButton
    Friend WithEvents btnPutinNeedsWork As RadioButton
    Friend WithEvents btnPutinDisplayReady As RadioButton
    Friend WithEvents btnReplaceInArchive As RadioButton
    Friend WithEvents btnMarkArchived As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtArchiveingDateTaken As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtDuplicateDateTaken As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents lblWhatWillHappen As TextBox
    Friend WithEvents RemoveFromArchive As RadioButton
    Friend WithEvents Label15 As Label
    Friend WithEvents txtArchiveingPath As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDuplicatePath As TextBox
End Class
