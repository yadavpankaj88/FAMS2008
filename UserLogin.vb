Public Class UserLogin
    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Dim mandatoryFields As String = String.Empty
        Dim template As String = "{0} {1} compulsory for login"
        Dim cnt As Integer
        Dim dt As New DataTable
        Dim userhelper As New UserHelper
        Dim i As Integer = 0
        If (txtuserID.Text = "") Then
            mandatoryFields = "User ID"
            i = i + 1
        End If
        If (txtpassword.Text = "") Then
            mandatoryFields += ", Password"
            i = i + 1
        End If

        If (mandatoryFields.StartsWith(",")) Then
            mandatoryFields = mandatoryFields.Substring(1)
        End If

        If i > 0 Then
            If (i = 1) Then
                MessageBox.Show(String.Format(template, mandatoryFields, "is"))
            Else
                MessageBox.Show(String.Format(template, mandatoryFields, "are"))
            End If
        Else
            cnt = userhelper.GetCountUserID(txtuserID.Text)
            If (cnt = 0) Then
                MessageBox.Show(txtuserID.Text + " does not have permission to work in Accounting Module")
            Else
                dt = userhelper.CheckUser(txtuserID.Text, txtpassword.Text)
                If dt.Rows.Count() = 0 Then
                    MessageBox.Show("User ID or password is wrong")
                    'End If
                Else
                    'Dim userlocked As String = dt.Rows(0)("Usr_Lckd")
                    'If userlocked = "Y" Then
                    '    MessageBox.Show("User locked")
                    'Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                    InstitutionMasterData.XUsrId = dt.Rows(0)("Usr_Id")
                    InstitutionMasterData.XUsrName = dt.Rows(0)("Usr_Nm")
                    InstitutionMasterData.XUsrRole = dt.Rows(0)("Usr_Role")
                    ' End If
                End If
                'Next
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class