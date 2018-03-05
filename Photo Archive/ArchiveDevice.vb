Imports System.IO

Public Class ArchiveDevice

    Private _driveletter As String
    Private _ArchiveAttached As Boolean

    ''' <summary>
    ''' Advice if archive disk is attached
    ''' </summary>
    ''' <returns>True/False</returns>
    Public ReadOnly Property ArchiveAttached() As Boolean
        Get
            LookForDevice()
            Return _ArchiveAttached
        End Get
    End Property

    ''' <summary>
    ''' Gets the drive letter for the archive disk
    ''' </summary>
    ''' <returns>Returns the drive letter of the photo archive disk</returns>
    Public ReadOnly Property DriveLetter() As String
        Get
            LookForDevice()
            If _ArchiveAttached Then
                Return _driveletter
            Else
                Return ""
            End If
        End Get
    End Property

    ''' <summary>
    ''' Determin if source path is on the "Photo Archive" volume
    ''' </summary>
    ''' <param name="SourcePath"></param>
    ''' <returns>True if source path is not on the Photo Archive volume otherwise return True</returns>
    Public Function ValidSourcePath(SourcePath As String) As Boolean
        If Path.GetPathRoot(SourcePath) = _driveletter Then Return False
        Return True
    End Function

    ''' <summary>
    ''' Iterate the drives attached to this computer  to find one with the volume labbel "Photo Arcive"
    ''' If the volume exists record the drive letter
    ''' </summary>
    Private Sub LookForDevice()
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo

        _ArchiveAttached = False                      ' Untill we know better
        For Each d In allDrives
            If d.IsReady = True Then
                If d.VolumeLabel = "Photo Archive" Then
                    _ArchiveAttached = True
                    _driveletter = d.Name
                End If
            End If
        Next
    End Sub

End Class
