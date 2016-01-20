Public Class frmFillDaybookCode
    Public val As String
    Dim ID As String
    Private Sub frmFillDaybookCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim daybookHelper As New DayBooksHelper
        Dim cashbankMngr As New frmCashBankAccountManage
        dt = daybookHelper.CheckDaybookCd(ID)
        dgvDaybookCode.DataSource = dt
    End Sub

    Private Sub dgvDaybookCode_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDaybookCode.CellContentClick

    End Sub

    Private Sub dgvDaybookCode_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDaybookCode.CellClick
            val = dgvDaybookCode.Rows(e.RowIndex).Cells(0).Value
        Me.Close()
    End Sub

    Sub setvalue(ByVal str As String)
        ID = str
    End Sub
End Class