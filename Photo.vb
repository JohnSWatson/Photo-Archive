Imports System.Drawing.Imaging
Imports System.IO

Public Class Photo
    Private _path As String
    Private _name As String
    Private _datetaken As String
    Private _title As String
    Private _subject As String
    Private _archiveaction As Short

    Private _archivepath As String
    Private _requestedaction As String

    Private _hasdatetaken As Boolean
    Private _hastitle As Boolean
    Private _hassubject As Boolean
    Private _hasduplicates As Boolean
    Private _ErrorProcessing As Boolean

    Private ExtendedData As New Dictionary(Of String, String)
    Private _DuplicatesInDisplay As String()                              ' An array of files with the same name in the "Display ready" archive
    Private _DuplicatesInNeedsWork As String()                            ' An array of files with the same name in the "Needs work" archive
    Private _DuplicatesInReview As String()                               ' An array of files with the same name in the "For review" archive
    Private _DuplicatesInArchive As String()                              ' An array of files with the same name in the "Arcive" archive


    ''' <summary>
    ''' Initialise class with image pointed to by mypath
    ''' </summary>
    ''' <param name="mypath"></param>
    Public Sub New(ByVal mypath As String, ArchivePath As String, RequestedAction As String)

        _path = mypath
        _name = Path.GetFileName(mypath)
        _archivepath = ArchivePath
        _requestedaction = RequestedAction

        GetXtdShellInfo(_path, ExtendedData)
        _hasdatetaken = IIf((ExtendedData.Item("Date taken").Length > 6), True, False)
        _datetaken = ExtendedData.Item("Date taken")
        _hastitle = IIf((ExtendedData.Item("Title").Length > 2), True, False)
        _title = ExtendedData.Item("Title")
        _hassubject = IIf((ExtendedData.Item("Subject").Length > 2), True, False)
        _subject = ExtendedData.Item("Subject")
        _ErrorProcessing = False

        FindDuplicateFiles()

    End Sub

    Public ReadOnly Property GoodToGo() As Boolean
        Get
            If _ErrorProcessing Then Return False
            If Not _hasdatetaken Then Return False
            If Not _hastitle Then Return False
            If Not _hassubject Then Return False
            If _title.ToUpper = _subject.ToUpper Then Return False
            If _title.ToUpper.Contains("XXX") Then Return False
            If _subject.ToUpper.Contains("XXX") Then Return False
            If _subject.ToUpper.Contains("NO SUBJECT") Then Return False
            If _title.Length < 3 Then Return False
            If _subject.Length < 3 Then Return False
            Return True
        End Get
    End Property

    Public ReadOnly Property RejectMessage() As String
        Get
            If _ErrorProcessing Then Return _path & ". Error processing file"
            If Not _hasdatetaken Then Return _path & ". No no date taken"
            If Not _hastitle Then Return _path & ". No title"
            If Not _hassubject Then Return _path & ". No subject"
            If _title.ToUpper = _subject.ToUpper Then Return _path & ". Title contains XXX"
            If _title.ToUpper.Contains("XXX") Then Return _path & ". Subject contains XXX"
            If _subject.ToUpper.Contains("XXX") Then Return _path & ". Bad subject"
            If _subject.ToUpper.Contains("NO SUBJECT") Then Return _path & ". Bad subject"
            If _title.Length < 3 Then Return _path & ". Title to short"
            If _subject.Length < 3 Then Return _path & ". Subject to short"
            Return _path & ". Good to go"
        End Get
    End Property

    Public Property PhotoPath() As String
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
        End Set
    End Property

    Public ReadOnly Property ArchivePath(Destination As String) As String
        Get
            Select Case Destination
                Case "Archive"
                    If _hassubject Then
                        Return clsArchiveDevice.DriveLetter & My.Settings.Archive & "\" & _datetaken & " - " & _title & "\" & _name
                    Else
                        Return clsArchiveDevice.DriveLetter & My.Settings.Archive & "\" & _archivepath & "\" & _datetaken & "\" & _name
                    End If
                Case "NeedsWork"
                    Return clsArchiveDevice.DriveLetter & My.Settings.Needswork & "\" & _datetaken & " - " & _title & "\" & _name
                Case "Display"
                    Return clsArchiveDevice.DriveLetter & My.Settings.Displayready & "\" & _datetaken & " - " & _title & "\" & _name
                Case "Review"
                    If _hastitle Then
                        Return clsArchiveDevice.DriveLetter & My.Settings.ForReview & "\" & _datetaken & " - " & _title & "\" & _name
                    Else
                        Return clsArchiveDevice.DriveLetter & My.Settings.ForReview & "\" & _archivepath & "\" & _datetaken & "\" & _name
                    End If
            End Select
            Return ""
        End Get

    End Property

    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
        End Set
    End Property

    Public Property Subject() As String
        Get
            Return _subject
        End Get
        Set(value As String)
            _subject = value
        End Set
    End Property

    Public Property DateTaken() As String
        Get
            Return _datetaken
        End Get
        Set(value As String)
            _datetaken = value
        End Set

    End Property

    Public Property HasTitle() As Boolean
        Get
            HasTitle = _hastitle
        End Get
        Set(value As Boolean)
            _hastitle = value
        End Set
    End Property

    Public Property HasSubject() As Boolean
        Get
            HasSubject = _hassubject
        End Get
        Set(value As Boolean)
            _hassubject = value
        End Set
    End Property

    Public ReadOnly Property FileName() As String
        Get
            Return Path.GetFileName(_path)
        End Get
    End Property

    Public ReadOnly Property ArchiveAction() As String
        Get
            Return _archiveaction
        End Get
    End Property

    ''' <summary>
    ''' Depreciated use function GetXtdShellInfo
    ''' </summary>
    Private Sub GetExtendedData()
        Dim MyImage As Bitmap
        Dim pic_time As PropertyItem
        Dim pic_title As PropertyItem
        Dim pic_subject As PropertyItem

        'Create an Image object. 
        Try
            MyImage = New Bitmap(_path)
        Catch ex As ArgumentException
            _ErrorProcessing = True
            '            MsgBox(ex.Message & vbCrLf & "Error while processing " & _path, MsgBoxStyle.AbortRetryIgnore, "Oh god")
            Exit Sub
        End Try

        'Get the PropertyItems property from image. 
        'Dim propItems As PropertyItem() = Image.PropertyItems

        'pic_time = MyImage.GetPropertyItem(306)                 ' Date taken tag 
        Try
            pic_time = MyImage.GetPropertyItem(36867)               ' Date taken tag 
            _hasdatetaken = True
        Catch ex As ArgumentException
            _hasdatetaken = False
        End Try

        Try
            pic_title = MyImage.GetPropertyItem(40091)             ' Title tag
            _hastitle = True
        Catch ex As ArgumentException
            _hastitle = False
        End Try

        Try
            pic_subject = MyImage.GetPropertyItem(40095)           ' Subject tag
            _hassubject = True
        Catch ex As ArgumentException
            _hassubject = False
        End Try

        If _hasdatetaken Then
            _datetaken = System.Text.Encoding.ASCII.GetString(pic_time.Value, 0, pic_time.Len - 1).Substring(0, 10).Replace(":", "-")
        Else
            _datetaken = "No date taken"
        End If
        If _hastitle Then _title = System.Text.Encoding.Unicode.GetString(pic_title.Value, 0, pic_title.Len - 2)
        If _hassubject Then _subject = System.Text.Encoding.Unicode.GetString(pic_subject.Value, 0, pic_subject.Len - 2)

        MyImage.Dispose()

    End Sub

    Public Function ArchivePhoto() As String
        If _hasduplicates Then Return "Duplicate"   ' The duplicate process handeles
        Return DoArchiveAction()
    End Function

    ''' <summary>
    ''' Depreciated
    ''' </summary>
    ''' <param name="Part1"></param>
    ''' <returns></returns>
    Private Function ArchivePathPart(Part1 As String) As String
        MsgBox("Oh my god this should not be reached")
        Dim I As Short
        Dim strReturn As String
        Dim pathparts As String() = _path.Split("\")    ' never use the first and last parts

        strReturn = Part1
        For I = LBound(pathparts) + 1 To UBound(pathparts)
            If Not pathparts(I) = "Users" Then ' Users" then
                strReturn = strReturn & "\" & pathparts(I)
            End If
        Next
        Return strReturn
    End Function

    ''' <summary>
    ''' Depreciated test if file is found in display ready
    ''' </summary>
    Public Function FileFoundInDisplayReady() As Boolean
        Stop  ' Depreciated
        Dim I As Short
        Dim FilesArray As String() = Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.Displayready, _name, SearchOption.AllDirectories)

        For I = LBound(FilesArray) To UBound(FilesArray)  ' check the data taken
            If FilesArray.Contains(_datetaken) Then Return True
        Next
        Return False

    End Function

    ''' <summary>
    ''' Find any files with a duplicate name in the four archive folders
    ''' and set the hasduplicates flag
    ''' </summary>
    Private Sub FindDuplicateFiles()
        Dim duppath As String
        Dim DupExtData As New Dictionary(Of String, String)
        Dim dupaction As String
        Dim ActionToTake As String

        _hasduplicates = False

        If DuplicatesAction.ContainsKey(_path) Then
            dupaction = DuplicatesAction.Item(_path)
        Else
            dupaction = ""
        End If

        _DuplicatesInDisplay = Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.Displayready, _name, SearchOption.AllDirectories)
        For Each duppath In _DuplicatesInDisplay
            GetXtdShellInfo(duppath, DupExtData)
            If _datetaken = DupExtData.Item("Date taken") Then
                If dupaction = "" Then
                    ActionToTake = GetdupAction(DupExtData, duppath, "Display Ready")
                    DoDupAction(ActionToTake, _path, duppath, "Display Ready")
                End If
                _hasduplicates = True
            End If
            DupExtData.Clear()
        Next

        _DuplicatesInNeedsWork = Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.Needswork, _name, SearchOption.AllDirectories)
        For Each duppath In _DuplicatesInNeedsWork
            GetXtdShellInfo(duppath, DupExtData)
            If _datetaken = DupExtData.Item("Date taken") Then
                If dupaction = "" Then
                    ActionToTake = GetdupAction(DupExtData, duppath, "Needs Work")
                    DoDupAction(ActionToTake, _path, duppath, "Needs work")
                End If
                _hasduplicates = True
            End If
            DupExtData.Clear()
        Next

        _DuplicatesInReview = Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.ForReview, _name, SearchOption.AllDirectories)
        For Each duppath In _DuplicatesInReview
            GetXtdShellInfo(duppath, DupExtData)
            If _datetaken = DupExtData.Item("Date taken") Then
                If dupaction = "" Then
                    ActionToTake = GetdupAction(DupExtData, duppath, "Review")
                    DoDupAction(ActionToTake, _path, duppath, "Review")
                End If
                _hasduplicates = True
            End If
            DupExtData.Clear()
        Next

        _DuplicatesInArchive = Directory.GetFiles(clsArchiveDevice.DriveLetter & "\" & My.Settings.Archive, _name, SearchOption.AllDirectories)
        For Each duppath In _DuplicatesInArchive
            GetXtdShellInfo(duppath, DupExtData)
            If _datetaken = DupExtData.Item("Date taken") Then
                If dupaction = "" Then
                    ActionToTake = GetdupAction(DupExtData, duppath, "Private")
                    DoDupAction(ActionToTake, _path, duppath, "Private")
                End If
                _hasduplicates = True
            End If
            DupExtData.Clear()
        Next
    End Sub

    Private Sub DoDupAction(ActionToDo As String, PhotoPath As String, ArchivePath As String, ArchiveLocation As String)

        'Console.WriteLine(ppp)
        Select Case ActionToDo
            Case "Replace in archive”
                CopyPhotoToArchive(PhotoPath, ArchivePath) ' Copy new photo over the old
            Case "Mark as archived”
                ' No need it will happen later
            Case "Put in display ready”
                DeletePhoto(ArchivePath)     ' Delete the photo in the archive
                ' copy the new photo to the archive
                CopyPhotoToArchive(_path, clsArchiveDevice.DriveLetter & "\" & My.Settings.Displayready & "\" & _datetaken & " - " & _title & "\" & _name)
            Case "Put in needs work”
                ' copy the new photo to the archive
                DeletePhoto(ArchivePath)      ' Delete the photo in the archive
                ' copy the new photo to the archive
                CopyPhotoToArchive(_path, clsArchiveDevice.DriveLetter & "\" & My.Settings.Needswork & "\" & _datetaken & " - " & _title & "\" & _name)
            Case “Put in review"
                DeletePhoto(ArchivePath)        ' Delete the photo in the archive
                ' copy the new photo to the archive
                CopyPhotoToArchive(_path, clsArchiveDevice.DriveLetter & "\" & My.Settings.ForReview & "\" & _datetaken & " - " & _title & "\" & _name)
            Case "Put in private archive"
        End Select
    End Sub

    ''' <summary>
    ''' Show review duplicates form and initiate the selected action
    ''' </summary>
    ''' <param name="DupExtData"></param>
    ''' <param name="duppath"></param>
    ''' <param name="ArchiveLocation"></param>
    ''' <returns>action taken</returns>
    Private Function GetdupAction(ByRef DupExtData As Dictionary(Of String, String), duppath As String, ArchiveLocation As String) As String
        Dim frmDup As New frmReviewDuplicate
        Dim DupAction As String

        ' The image in the archive is the duplicate of the image to be loaded into the archive
        frmDup.txtArchiveingHeading.Text = _path
        frmDup.LeftImagePath = _path
        frmDup.txtArchiveingPath.Text = _path
        frmDup.txtArchiveingDateTaken.Text = _datetaken
        frmDup.txtArchiveingTitle.Text = _title
        frmDup.txtArchiveingSubject.Text = _subject
        frmDup.txtArchiveingTags.Text = ExtendedData.Item("Tags")
        frmDup.txtArchiveingRating.Text = ExtendedData.Item("Rating")
        frmDup.txtArchiveingComment.Text = ExtendedData.Item("Comments")

        ' The image in the archive is the duplicate of the image to be loaded into the archive
        frmDup.txtDuplicateHeading.Text = ArchiveLocation
        frmDup.RightImagePath = duppath
        frmDup.txtDuplicatePath.Text = duppath
        frmDup.txtDuplicateDateTaken.Text = DupExtData.Item("Date taken")
        frmDup.txtDuplicateTitle.Text = DupExtData.Item("Title")
        frmDup.txtDuplicateSubject.Text = DupExtData.Item("Subject")
        frmDup.txtDuplicateTags.Text = DupExtData.Item("Tags")
        frmDup.txtDuplicateRating.Text = DupExtData.Item("Rating")
        frmDup.txtDuplicateComment.Text = DupExtData.Item("Comments")

        frmDup.ShowDialog()

        If frmDup.CheckBox1.Checked Then
            If Not DuplicatesAction.ContainsKey(Path.GetDirectoryName(_path)) Then
                DuplicatesAction.Add(Path.GetDirectoryName(_path), frmDup.Tag)
            End If
        End If
        DupAction = frmDup.Tag
        frmDup = Nothing
        Return DupAction

    End Function


    ''' <summary>
    '''  Extract file extended data and keep all values in  Dictionary ExtendedData as strings
    '''  The usefull keys and example values are: 
    ''' Date created,: 16/04/2017 12:20 PM
    ''' Perceived type: Image
    ''' Owner: LAPTOP-EPEJAV15\watso
    ''' Kind: Picture
    ''' Date taken: ?25/?05/?2015 ??11:30 AM
    ''' Tags: Tag1; Tag2
    ''' Rating: 2 Stars
    ''' Authors: Sandy Watson
    ''' Title: Image title
    ''' Subject: A test
    ''' Comments: Testing archive
    ''' Camera model: Canon PowerShot SX50 HS
    ''' Dimensions: ?1920 x 1080?
    ''' Camera maker: Canon
    ''' Computer: LAPTOP-EPEJAV15 (this PC)
    ''' File extension: .JPG
    ''' Filename: IMG_5468.JPG
    ''' Folder name: 294_2505
    ''' Folder path: D:\Backup from Sandy Camera 20170416\DCIM 1\294_2505
    ''' Folder: 294_2505 (D:\Backup from Sandy Camera 20170416\DCIM 1)
    ''' Path: D:\Backup from Sandy Camera 20170416\DCIM 1\294_2505\IMG_5468.JPG
    ''' Exposure time: ?1/1000 sec.
    ''' F-stop: f/6.3
    ''' Flash mode: No flash, compulsory
    ''' Focal length: ?19 mm
    ''' 35mm focal length: 
    ''' ISO speed: ISO-160
    ''' </summary>
    Private Sub GetXtdShellInfoX(ByVal filepath As String, ByRef ExtData As Dictionary(Of String, String))
        ' ToDo: add error checking, maybe Try/Catch and 
        ' surely check if the file exists before trying
        Dim shell As New Shell32.Shell
        Dim shFolder As Shell32.Folder

        shFolder = shell.NameSpace(Path.GetDirectoryName(filepath))

        ' its com so iterate to find what we want -
        ' or modify to return a dictionary of lists for all the items
        Dim key As String

        For Each s In shFolder.Items
            ' look for the one we are after
            If shFolder.GetDetailsOf(s, 0).ToLowerInvariant = Path.GetFileName(_path).ToLowerInvariant Then
                Dim ndx As Int32 = 0
                key = shFolder.GetDetailsOf(shFolder.Items, ndx)

                ' there are a varying number of entries depending on the OS
                ' 34 min, W7=290, W8=309 with some blanks
                ' this should get up to 310 non blank elements
                Do Until String.IsNullOrEmpty(key) AndAlso ndx > 310
                    If String.IsNullOrEmpty(key) = False Then
                        If key = "Date taken" Then                ' convert to internal format
                            Dim strdatetaken = MakeADate(shFolder.GetDetailsOf(s, ndx))
                            'ExtendedData.Item("Date taken").Substring(0, 13)

                            ' dont know why this was necessary but it works for now
                            '                            strdatetaken = strdatetaken.Substring(8, 5) + "-" + strdatetaken.Substring(4, 3) + "-" + strdatetaken.Substring(0, 3)
                            If Not ExtData.ContainsKey(key) Then ExtData.Add(key, strdatetaken)
                        Else
                            If Not ExtData.ContainsKey(key) Then ExtData.Add(key, shFolder.GetDetailsOf(s, ndx))
                        End If
                    End If
                    ndx += 1
                    key = shFolder.GetDetailsOf(shFolder.Items, ndx)
                Loop
                ' we got what we came for
                Exit For
            End If
        Next
        shFolder = Nothing

    End Sub

    ''' <summary>
    ''' takes a data taken string which may have chracters left over from the encoding and extracts the date
    ''' </summary>
    ''' <param name="DateTaken">A string from the pictures exif data</param>
    ''' <returns>string in format yyyy-mm-dd</returns>
    Private Function MakeADate(DateTaken As String) As String
        Dim Split1 As String()
        Dim I As Integer
        Dim c As Char
        Dim newstr As String

        ' This is the only way I could handel this due to unprintable chracters
        For I = 1 To 14
            c = Mid(DateTaken, I, 1)
            If Asc(c) = 32 Then Exit For
            If Asc(c) >= 47 And Asc(c) <= 57 Then newstr += c
        Next

        Split1 = Split(newstr, "/")
        'Console.WriteLine("P1 {0}  P2 {1}  P3 {2}", Split1(0), Split1(1), Split1(2))

        Return Split1(2) + "-" + Split1(1).PadLeft(2, "0") + "-" + Split1(0).PadLeft(2, "0")

    End Function

    Private Function DoArchiveAction() As String

        If _hasduplicates Then
            MarkFileArchived(_path)  ' Its already processed so mark it
            Return "Duplicate"       ' The duplicate handling did this
        End If

        Select Case _requestedaction
            Case "None"     ' Just mark the source as archived
                MarkFileArchived(_path)
                Return "None"
            Case "Private"  ' Put in the private archive and mark the source archived
                CopyPhotoToArchive(_path, ArchivePath("Archive"))
                MarkFileArchived(_path)
                Return "Private"
            Case "Auto"     ' Determine where to put it and mark the source as archived
                If ExtendedData.Item("Tags").Contains("Private") Then
                    CopyPhotoToArchive(_path, ArchivePath("Archive"))
                    MarkFileArchived(_path)
                    Return "Private"
                Else
                    CopyPhotoToArchive(_path, ArchivePath(PublicArchive()))
                    MarkFileArchived(_path)
                    Return "Public"
                End If
            Case "Public"   ' Determine where in the public archive to put it and mark the source as archived
                CopyPhotoToArchive(_path, ArchivePath(PublicArchive()))
                MarkFileArchived(_path)
                Return "Public"
            Case "Both"     ' Put in the private archive, determine where in the public archive to put it and mark the source as archived
                CopyPhotoToArchive(_path, ArchivePath(PublicArchive()))
                CopyPhotoToArchive(_path, ArchivePath("Archive"))
                MarkFileArchived(_path)
                Return "Both"
        End Select
        Return "Failed"
    End Function

    ''' <summary>
    ''' Determin which of the three public archives to put the photo
    ''' </summary>
    ''' <returns>Public archive name</returns>
    Private Function PublicArchive() As String
        If _hasdatetaken And _hastitle And HasSubject Then Return "Display"
        If _hasdatetaken And _hastitle Then Return "NeedsWork"
        Return "Review"
    End Function

End Class
