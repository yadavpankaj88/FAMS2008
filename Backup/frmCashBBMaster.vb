Public Class frmCashBBMaster
    Inherits FAMS.frmBaseMaster
    Dim frmCashBankManage As frmCashBankAccountManage
    Dim screenTitle As String = "Cash Bank Book {0}"


    Protected Overrides Sub btnAdd_Click(sender As Object, e As EventArgs)
        frmCashBankManage = New frmCashBankAccountManage()

        frmCashBankManage.Text = String.Format(screenTitle, "Add")
        frmCashBankManage.ShowDialog()
    End Sub


    Private Sub frmCashBBMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class