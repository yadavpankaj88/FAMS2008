Public Class frmFillUserName
    Public Val As String
    Private Sub frmFillUserName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim userhelper As New UserHelper
        dt = userhelper.FillUserID()
        dgvusername.DataSource = dt
    End Sub

    Private Sub dgvusername_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvusername.CellContentClick

    End Sub

    Private Sub dgvusername_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvusername.CellClick
        If dgvusername.Rows(e.RowIndex).Cells(0).Value Is DBNull.Value Then
        Else
            Val = dgvusername.Rows(e.RowIndex).Cells(0).Value
            Me.Close()
        End If
    End Sub
End Class