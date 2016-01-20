Public Class frmLedgerAccMaster
    Inherits frmBaseMaster
    Dim frmLedgerAcc As frmLedgerAccountManage
    Dim screenTitle As String = "Ledger Account {0}"

    Protected Overrides Sub btnAdd_Click(sender As Object, e As EventArgs)
        frmLedgerAcc = New frmLedgerAccountManage()

        frmLedgerAcc.Text = String.Format(screenTitle, "Add")
        frmLedgerAcc.ShowDialog()
    End Sub

    Protected Overrides Sub btnUpdate_Click(sender As Object, e As EventArgs)
        frmLedgerAcc = New frmLedgerAccountManage("A34651")
        frmLedgerAcc.Text = String.Format(screenTitle, "Update")
        frmLedgerAcc.ShowDialog()
    End Sub
End Class