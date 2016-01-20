Public Class frmFillAccCode
    Public val As String
    Dim ID As String

    Private Sub frmFillAccCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim ldgAccHelper As New LedgerAccountHelper
        Dim ledgerAccMngr As New frmLedgerAccountManage
        ' ID = ledgerAccMngr.textboxval
        dt = ldgAccHelper.CheckAccCd(ID)
        dgvFillAccCode.DataSource = dt
    End Sub

    Sub setvalue(ByVal str As String)
        ID = str
    End Sub

    Private Sub dgvFillAccCode_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFillAccCode.CellContentClick
        val = dgvFillAccCode.Rows(e.RowIndex).Cells(0).Value
        Me.Close()
    End Sub
End Class