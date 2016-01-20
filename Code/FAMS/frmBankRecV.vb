Public Class frmBankRecV
    Inherits FAMS.frmBaseMaster
    Dim frmAddVoucher As frmAddVoucher
    Dim screenTitle As String = "Bank Receipt Voucher- {0}"


    Protected Overrides Sub btnAdd_Click(sender As Object, e As EventArgs)
        frmAddVoucher = New frmAddVoucher()

        frmAddVoucher.Text = String.Format(screenTitle, "Add")
        frmAddVoucher.ShowDialog()
    End Sub

    Private Sub btnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class