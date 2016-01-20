Public Class frmBankPayV
    Inherits FAMS.frmBaseMaster

    Dim frmAddVoucher As frmAddVoucher
    Dim screenTitle As String = "Bank Payment Voucher- {0}"


    Protected Overrides Sub btnAdd_Click(sender As Object, e As EventArgs)
        frmAddVoucher = New frmAddVoucher()

        frmAddVoucher.Text = String.Format(screenTitle, "Add")
        frmAddVoucher.ShowDialog()
    End Sub


End Class