Imports System.IO
Imports Shell32

Public Enum ActionToTake As Short
    None = 0
    Markup = 1
    Review = 2
    Display = 3
    Archive = 4
    Augment = 5
End Enum

Module code
    Public DuplicatesAction As New Dictionary(Of String, String)
    Public clsArchiveDevice As New ArchiveDevice

    ''' <summary>
    '''  Renames a file to have the word Archived at the start
    ''' </summary>
    ''' <param name="Target">The full path of the file to be marked up archived</param>
    Public Sub MarkFileArchived(Target As String)

        Dim Tnew = "Archived " & Path.GetFileName(Target)
        Try
            My.Computer.FileSystem.RenameFile(Target, Tnew)
        Catch ex As ArgumentException
            MsgBox("File " & Path.GetFileName(Target) & " not marked as Archived" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Oh well thats how it is")
        End Try
    End Sub

    Public Sub CopyPhotoToArchive(PhotoPath As String, ArchivePath As String)
        My.Computer.FileSystem.CopyFile(PhotoPath, ArchivePath, overwrite:=True)
    End Sub

    Public Sub DeleteFolder(FolderPath As String)
        My.Computer.FileSystem.DeleteDirectory(FolderPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Public Sub DeletePhoto(PhotoPath As String)
        My.Computer.FileSystem.DeleteFile(PhotoPath)
    End Sub

    ''' <summary>
    ''' Renames a folder to have the word Archived at the start
    ''' </summary>
    ''' <param name="Target">The path of the folder to be marked up archived</param>
    Public Sub MarkFolderArchived(Target As String)
        Dim FolderName As String

        Try
            FolderName = Path.GetFileName(Target.TrimEnd(Path.DirectorySeparatorChar))
            My.Computer.FileSystem.RenameDirectory(Target, "Archived " & FolderName)
        Catch ex As ArgumentException
            MsgBox("Folder " & Target & " not marked as Archived" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Oh well thats how it is")
        End Try

    End Sub

    ''' <summary>
    ''' Test a path, if it contains the word Archived
    ''' </summary>
    ''' <param name="Target">Return True or False</param>
    ''' <returns></returns>
    Public Function IsMarkedArchived(Target As String) As Boolean
        If Target.Contains("Archived") Then Return True
        Return False
    End Function

    ''' <summary>
    ''' Counts how many files there are in a folder and sub folders of a given name
    ''' </summary>
    ''' <param name="FolderToSearch">Full path of folder to be searched for the filename</param>
    ''' <param name="Filename">Name of file to search for</param>
    ''' <returns>interger count of files found</returns>
    Public Function CounFilesOfName(FolderToSearch As String, Filename As String) As Integer
        Dim FilesArray As String() = Directory.GetFiles(FolderToSearch, Filename, SearchOption.AllDirectories)
        Return UBound(FilesArray) + 1
    End Function

    ''' <summary>
    '''  Extract a meaningfull portion of the path which can be used in the list and to build a
    '''  path that can be used in the private archive
    ''' </summary>
    ''' <param name="MyPath">The path of photos to be archive</param>
    ''' <returns></returns>
    Public Function GetArchivePathPart(MyPath As String) As String
        Dim PathParts As String()
        Dim PathPart As String
        Dim I As Int16

        PathParts = MyPath.Split("\")

        For I = 1 To UBound(PathParts)
            If PathParts(I).Contains(".JPG") Then Exit For
            If PathParts(I) = "Users" Then
                I += 2
            End If
            PathPart = PathPart & "\" & PathParts(I)
        Next

        Return PathPart.Remove(0, 1)

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
    Public Sub GetXtdShellInfo(ByVal filepath As String, ByRef ExtData As Dictionary(Of String, String))
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
            If shFolder.GetDetailsOf(s, 0).ToLowerInvariant = Path.GetFileName(filepath).ToLowerInvariant Then
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

    Sub TestGetFileProperties()
        Dim FileName As String
        FileName = "C:\Users\watso\Pictures\Duplicate Test\Duplicate - Copy.JPG"
        Dim Properties As Dictionary(Of Integer, KeyValuePair(Of String, String)) = GetFileProperties(FileName)
        For Each FileProperty As KeyValuePair(Of Integer, KeyValuePair(Of String, String)) In Properties
            Console.WriteLine("{0}: {1}", FileProperty.Value.Key, FileProperty.Value.Value)
        Next
        DeletePhoto(FileName)
    End Sub

    Public Function GetFileProperties(ByVal FileName As String) As Dictionary(Of Integer, KeyValuePair(Of String, String))
        Dim Shell As New Shell
        Dim Folder As Folder = Shell.[NameSpace](Path.GetDirectoryName(FileName))
        Dim File As FolderItem = Folder.ParseName(Path.GetFileName(FileName))
        Dim Properties As New Dictionary(Of Integer, KeyValuePair(Of String, String))()
        Dim Index As Integer
        Dim Keys As Integer = Folder.GetDetailsOf(File, 0).Count

        For Index = 0 To Keys - 1
            Dim CurrentKey As String = Folder.GetDetailsOf(Nothing, Index)
            Dim CurrentValue As String = Folder.GetDetailsOf(File, Index)
            If CurrentValue <> "" Then
                Properties.Add(Index, New KeyValuePair(Of String, String)(CurrentKey, CurrentValue))
            End If
        Next

        Return Properties
    End Function
End Module
