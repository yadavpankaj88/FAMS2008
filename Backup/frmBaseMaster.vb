Public Class frmBaseMaster



    Public WriteOnly Property IsVoucherForm() As Boolean
        Set(ByVal value As Boolean)

            btnConfirm.Visible = value
        End Set
    End Property



    Protected Overridable Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    End Sub

    Protected Overridable Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

    End Sub

    Protected Overridable Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Protected Overridable Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

    End Sub
End Class