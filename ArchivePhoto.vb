Imports System.IO
Imports System.Text

Public Class ArchivePhoto
    Private _fullpath As String
    Private _filecreateddate As String
    Private _datetaken As String
    Private _title As String
    Private _subject As String
    Private _keywords As String
    Private _comments As String
    Private _author As String

#Region "Class properties and actions"
    Property SourcePhotoPath() As String
        Get
            Return _fullpath
        End Get
        Set(value As String)
            _fullpath = value
            LoadImage()
        End Set
    End Property

    ReadOnly Property ArchivePhotoPath(Optional Destination As String = "Auto") As String
        Get
            Return GetArchivePhotoPath(Destination)
        End Get
    End Property

    ReadOnly Property Score() As Int16
        Get
            Return getScore()
        End Get
    End Property

    Public Sub Photo(SourcePhotoPath As String, ArchiveAction As String)
        _fullpath = SourcePhotoPath
        LoadImage()
        Debug.Print(Len(_title))
        Debug.Print(Len(Trim(_title)))
        Debug.Print(Left(_title, Len(_title) - 1))
    End Sub

#End Region

    ''' <summary>
    ''' Score position in Public archive
    '''   0 = Goes into Needs more work without date taken in the path
    '''   1 = Goes into Needs more work with date taken in the path
    '''   2 = Goes into Review
    '''   3 = Goes into Display Ready
    ''' </summary>
    ''' <returns>Score 0 to 3</returns>
    Private Function getScore() As Int16
        Dim Score As Int16 = 0

        If Len(_datetaken) = 12 Then Score += 1 ' Date is valid
        If Len(_title) > 4 Then Score += 1 ' Title is valid is valid
        If Len(_subject) = 10 And (Not _title = _subject) Then Score += 1 ' Date is valid

        Return Score
    End Function

#Region "Calculating the path in the archive"
    Private Function GetArchivePhotoPath(Destination As String) As String
        Select Case Destination
            Case "Auto"
                Select Case Score()
                    Case < 5
                    Case < 10
                End Select
            Case "Family"
                Return FamilyHistoryPath()
            Case "Private"
                Return PrivatePath()
        End Select

        Return "Not calculated"
    End Function

    Private Function PrivatePath() As String
        Return clsArchiveDevice.DriveLetter & My.Settings.Archive & "\" & ArchivePathDate() & " - " & _title & "\" & Path.GetFileName(_fullpath)
    End Function

    Private Function FamilyHistoryPath() As String
        Return clsArchiveDevice.DriveLetter & My.Settings.FamilyHistory & "\" & ArchivePathDate() & " - " & _title & "\" & Path.GetFileName(_fullpath)
    End Function

    Private Function NeedsWorkPath() As String
        Return clsArchiveDevice.DriveLetter & My.Settings.Needswork & "\" & ArchivePathDate() & " - " & _title & "\" & Path.GetFileName(_fullpath)
    End Function

    Private Function ReviewPath() As String
        Return clsArchiveDevice.DriveLetter & My.Settings.ForReview & "\" & ArchivePathDate() & " - " & _title & "\" & Path.GetFileName(_fullpath)
    End Function

    Private Function DisplayReadyPath() As String
        Return clsArchiveDevice.DriveLetter & My.Settings.Displayready & "\" & ArchivePathDate() & " - " & _title & "\" & Path.GetFileName(_fullpath)
    End Function

    ''' <summary>
    '''  Extract a meaningfull portion of the path which can be used in the list and to build a
    '''  path that can be used in the private archive
    ''' </summary>
    ''' <returns></returns>
    Public Function GetArchivePathPart() As String
        Dim PathParts As String()
        Dim PathPart As String = ""
        Dim I As Int16

        PathParts = _fullpath.Split("\")

        For I = 1 To UBound(PathParts)
            If PathParts(I).Contains(".JPG") Then Exit For
            If PathParts(I) = "Users" Then
                I += 2                                                   ' Skip past the user part of the path
            End If
            PathPart = PathPart & "\" & PathParts(I)
        Next

        Return PathPart.Remove(0, 1)

    End Function

    Private Function ArchivePathDate() As String
        If Len(_datetaken) = 10 Then Return _datetaken
        If Len(_filecreateddate) = 10 Then Return _filecreateddate
        Return "No date"
    End Function

#End Region

    Private Sub LoadImage()
        Dim utf8 As New UTF8Encoding(True, True)
        Dim _myimage As Image

        'LoadImage()
        _myimage = Image.FromFile(_fullpath)
        _filecreateddate = File.GetCreationTime(_fullpath).ToString("yyyy-mm-dd")

        Try
            Dim Datebits() As String
            Datebits = Split(Split(Encoding.UTF8.GetString(_myimage.GetPropertyItem(36868).Value), " ")(0), ":")
            _datetaken = Datebits(0) & "-" & Datebits(1) & "-" & Datebits(2)
        Catch ex As Exception
            _datetaken = ""
        End Try

        Try
            _title = Encoding.Unicode.GetString(_myimage.GetPropertyItem(40091).Value)
            _title = Left(_title, Len(_title) - 1)
        Catch ex As Exception
            _title = ""
        End Try

        Try
            _subject = Encoding.Unicode.GetString(_myimage.GetPropertyItem(40095).Value)
            _subject = Left(_subject, Len(_subject) - 1)
        Catch ex As Exception
            _subject = ""
        End Try

        Try
            _keywords = Encoding.Unicode.GetString(_myimage.GetPropertyItem(40094).Value)
            _keywords = Left(_keywords, Len(_keywords) - 1)
        Catch ex As Exception
            _keywords = ""
        End Try

        Try
            _comments = Encoding.Unicode.GetString(_myimage.GetPropertyItem(40092).Value)
            _comments = Left(_comments, Len(_comments) - 1)
        Catch ex As Exception
            _comments = ""
        End Try

        Try
            _author = Encoding.Unicode.GetString(_myimage.GetPropertyItem(40093).Value)
            _author = Left(_author, Len(_author) - 1)
        Catch ex As Exception
            _author = ""
        End Try

        _myimage.Dispose()

    End Sub
End Class
