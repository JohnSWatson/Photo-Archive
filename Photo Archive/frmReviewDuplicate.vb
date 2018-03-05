Imports System.IO

Public Class frmReviewDuplicate
    Public LeftImagePath As String
    Public RightImagePath As String

    Private Sub btnTakeAction_Click(sender As Object, e As EventArgs) Handles btnTakeAction.Click
        If Me.Tag = "" Then
            MsgBox("You must select an action.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "No action selected")
        Else
            Me.Hide() ' Hide form and return control
        End If
    End Sub

    Private Sub btnReplaceInArchive_CheckedChanged(sender As Object, e As EventArgs) Handles btnReplaceInArchive.CheckedChanged
        Me.Tag = "Replace in archive"
        Me.lblWhatWillHappen.Text = "The image in the archive will be replaced with the new one (on te left)"
    End Sub

    Private Sub btnMarkArchived_CheckedChanged(sender As Object, e As EventArgs) Handles btnMarkArchived.CheckedChanged
        Me.Tag = "Mark as archived"
        Me.lblWhatWillHappen.Text = "The image in the archive will not be touched. The image on the left will be marked as archived"
    End Sub

    Private Sub btnPutinDisplayReady_CheckedChanged(sender As Object, e As EventArgs) Handles btnPutinDisplayReady.CheckedChanged
        Me.Tag = "Put in display ready"
        Me.lblWhatWillHappen.Text = "The image on the left will be put in the Display Ready archive, any existing image will be replaced or removed"
    End Sub

    Private Sub btnPutinNeedsWork_CheckedChanged(sender As Object, e As EventArgs) Handles btnPutinNeedsWork.CheckedChanged
        Me.Tag = "Put in needs work"
        Me.lblWhatWillHappen.Text = "The image on the left will be put in the Needs Work archive, any existing image will be replaced or removed"
    End Sub

    Private Sub btnPutinReview_CheckedChanged(sender As Object, e As EventArgs) Handles btnPutinReview.CheckedChanged
        Me.Tag = "Put in review"
        Me.lblWhatWillHappen.Text = "The image on the left will be put in the Review archive, any existing image will be replaced or removed"
    End Sub

    Private Sub RemoveFromArchive_CheckedChanged(sender As Object, e As EventArgs) Handles RemoveFromArchive.CheckedChanged
        Me.Tag = "Remove from this archive"
        Me.lblWhatWillHappen.Text = "The image in the archive will be removed. The image on the left will be marked as archived"
    End Sub

    Private Sub btnPutinPrivateArchive_CheckedChanged(sender As Object, e As EventArgs) Handles btnPutinPrivateArchive.CheckedChanged
        Me.Tag = "Put in private archive"
        Me.lblWhatWillHappen.Text = "The image on the left will be put in the Private archive, any existing image will be replaced or removed"
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Text = "Review next duplicate" Then
            CheckBox1.Text = "Do this for all other duplicates"
        Else
            CheckBox1.Text = "Review next duplicate"
        End If
    End Sub

    Private Sub frmReviewDuplicate_Load(sender As Object, e As EventArgs) Handles Me.Load

        Tag = ""
        btnMarkArchived.Checked = False
        btnPutinDisplayReady.Checked = False
        btnPutinNeedsWork.Checked = False
        btnPutinPrivateArchive.Checked = False
        btnPutinReview.Checked = False
        btnReplaceInArchive.Checked = False


        Dim Streaml As FileStream = New FileStream(LeftImagePath, FileMode.Open, FileAccess.Read)
        ArchiveingPicture.Image = Image.FromStream(Streaml)
        Streaml.Close()

        Dim Streamr As FileStream = New FileStream(RightImagePath, FileMode.Open, FileAccess.Read)
        DuplicatePicture.Image = Image.FromStream(Streamr)
        Streamr.Close()

    End Sub
End Class