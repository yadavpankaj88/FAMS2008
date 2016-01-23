Public Class frmFillAccCode
    Public val As String
    Public msg As String = ""
    Dim ID As String

    Private Sub frmFillAccCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim ldgAccHelper As New LedgerAccountHelper
        Dim ledgerAccMngr As New frmLedgerAccountManage
        ' ID = ledgerAccMngr.textboxval
        dt = ldgAccHelper.CheckAccCd(ID)
        dgvFillAccCode.DataSource = dt

        If dt.Rows.Count = 0 Then
            Me.Close()
            msg = "Record not present"
        End If

    End Sub

    Sub setvalue(ByVal str As String)
        ID = str
    End Sub

    Private Sub dgvFillAccCode_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFillAccCode.CellClick
        val = dgvFillAccCode.Rows(e.RowIndex).Cells(0).Value
        Me.Close()
    End Sub
End Class