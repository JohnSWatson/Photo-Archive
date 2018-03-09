Imports System.IO

Public Class ArchivedImage
    Private _path As String
    Private _name As String
    Private _archive As String
    Private _datetaken As String
    Private _title As String
    Private _subject As String

    Private ExtendedData As New Dictionary(Of String, String)

    ''' <summary>
    ''' Initialise class with image pointed to by mypath
    ''' </summary>
    ''' <param name="mypath"></param>
    Public Sub New(ByVal mypath As String)

        _path = mypath
        _name = Path.GetFileName(mypath)
        Dim PathParts As String() = _path.Split("\")
        _archive = PathParts(1)

        GetXtdShellInfo(_path, ExtendedData)
        _title = ExtendedData.Item("Title")
        _subject = ExtendedData.Item("Subject")
        _datetaken = ExtendedData.Item("Date taken")

    End Sub

    Public ReadOnly Property Info() As String
        Get
            Return "Name:       " & vbTab & _name & vbCrLf &
                   "In archive: " & vbTab & _archive & vbCrLf &
                   "Title:      " & vbTab & vbTab & _title & vbCrLf &
                   "Subject:    " & vbTab & vbTab & _subject & vbCrLf &
                   "Taken:      " & vbTab & vbTab & _datetaken & vbTab
        End Get
    End Property





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
End Class
