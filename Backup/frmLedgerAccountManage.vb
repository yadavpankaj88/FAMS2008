Public Class frmLedgerAccountManage

    Dim validateAcc As ValidateClass
    Dim ledgerAcc As LedgerAccountHelper
    Dim accCode As String

    Public WithEvents bindingSourceCtrl As BindingSource
    Dim dtAccounts As DataTable

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        validateAcc = New ValidateClass
        ledgerAcc = New LedgerAccountHelper

        bindingSourceCtrl = New BindingSource
        BindData()

    End Sub

    Sub New(ByVal pAccCode As String)
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        validateAcc = New ValidateClass
        ledgerAcc = New LedgerAccountHelper
        accCode = pAccCode
    End Sub

    Private Sub frmLedgerAccountManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        drpOpenBalEff.DataSource = CommonFunctions.BindCreditDebit()
        drpOpenBalEff.DisplayMember = "Text"
        drpOpenBalEff.ValueMember = "Value"

    End Sub

    Private Sub txtAccCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAccCode.Validating
        If Not validateAcc.CheckAccountCode(txtAccCode.Text) Then
            txtAccCode.BackColor = Color.Red
        Else
            txtAccCode.BackColor = Color.White
        End If
    End Sub

    Private Sub txtNumeric_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLYBudget.Validating, txtLYActual.Validating, txtLLYBudget.Validating, txtLLYActual.Validating, txtCYBudget.Validating, txtAccOpenBalance.Validating
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If txt IsNot Nothing And Not String.IsNullOrEmpty(txt.Text) Then
            If Not validateAcc.CheckNumber(txt.Text) Then
                txt.BackColor = Color.Red
            Else
                txt.BackColor = Color.White
            End If
        End If
    End Sub


    Private Sub BindData()

        Try
            dtAccounts = ledgerAcc.GetAccountDetails(String.Empty)

            For Each row As DataRow In dtAccounts.Rows
                If row("AM_Calls") Is DBNull.Value Then
                    row("AM_Calls") = "Not Linked"
                    row.AcceptChanges()
                End If
            Next

            dtAccounts.AcceptChanges()
            bindingSourceCtrl.DataSource = dtAccounts
            bindingSourceCtrl.Sort = "AM_Acc_Cd Asc"

            txtAccCode.DataBindings.Add("Text", bindingSourceCtrl, "AM_Acc_Cd", True)
            txtAccName.DataBindings.Add("Text", bindingSourceCtrl, "AM_Acc_Nm", True)
            txtAccName.Text = txtAccName.Text.Trim()
            drpOpenBalEff.DataBindings.Add("SelectedValue", bindingSourceCtrl, "AM_OB_Cr_Dr", True)
            txtAccOpenBalance.DataBindings.Add("Text", bindingSourceCtrl, "AM_ABS_Opn_Bal", True)
            txtLLYBudget.DataBindings.Add("Text", bindingSourceCtrl, "AM_LLY_Budg", True)
            txtLLYActual.DataBindings.Add("Text", bindingSourceCtrl, "AM_LLY_Actu", True)
            txtLYActual.DataBindings.Add("Text", bindingSourceCtrl, "AM_LYr_Budg", True)
            txtLYBudget.DataBindings.Add("Text", bindingSourceCtrl, "AM_LYr_Actu", True)
            txtCYBudget.DataBindings.Add("Text", bindingSourceCtrl, "AM_Cyr_Budg", True)
            LblLinkedTo.DataBindings.Add("Text", bindingSourceCtrl, "AM_Calls", True)

            EnableDisableControls(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Sub SaveData()
        Try
            bindingSourceCtrl.EndEdit()
            If validateAcc.CheckAccName(txtAccName.Text) And validateAcc.CheckAccountCode(txtAccCode.Text) Then
                If ledgerAcc.SaveData(DirectCast(bindingSourceCtrl.DataSource, DataTable)) Then
                    MessageBox.Show("Data updated Successfully")
                    EnableDisableControls(False)
                Else
                    EnableDisableControls(True)
                End If
            Else
                MessageBox.Show("There are some errors, please correct it !!!", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error occurred!!")
        End Try
    End Sub

    Private Function IsDecimal(keyArgs As KeyPressEventArgs, sender As TextBox) As Boolean
        Dim backspace As Integer = 8
        Dim decPoint As Integer = 46
        Dim zero As Integer = 48
        Dim nine As Integer = 57
        Dim NotFound As Integer = -1

        Dim charValue As Integer

        Dim checkDecimal As Boolean = False


        If Integer.TryParse(AscW(keyArgs.KeyChar), charValue) Then
            If (charValue >= zero And charValue <= nine) Or charValue = backspace Then
                checkDecimal = True
            End If

            If charValue = decPoint And sender.Text.IndexOf(".") = NotFound Then
                checkDecimal = True
            End If
        End If

        Return checkDecimal
    End Function

    Public Function DeleteData() As Boolean
        Dim currentRec As DataRowView = DirectCast(bindingSourceCtrl.Current, DataRowView)
        Dim helper As LedgerAccountHelper = New LedgerAccountHelper()

        If currentRec("AM_Acc_Cd") IsNot DBNull.Value And currentRec("AM_Calls") IsNot DBNull.Value Then

            Dim transCount As Integer = helper.GetTransactionCount(currentRec("AM_Acc_Cd"), currentRec("AM_Calls"))

            If transCount = 0 Then

                If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    DialogResult.Yes Then
                    ledgerAcc.DeleteAccount(currentRec.Row("AM_Acc_Cd").ToString)
                    Return True
                Else
                    Return False
                End If
            Else
                MessageBox.Show("This account is currently used in transactions, and cannot be deleted")
                Return False
            End If
        Else
            If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                   DialogResult.Yes Then
                ledgerAcc.DeleteAccount(currentRec.Row("AM_Acc_Cd").ToString)
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Private Sub frmLedgerAccountManage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        If frmMain IsNot Nothing Then
            frmMain.mainBindingNavigator.BindingSource = Nothing
            frmMain.pnlNavigator.Visible = False
            frmMain.pnlMenu.Visible = True
            frmMain.EnableNavToolBar()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim itemPosition As Integer = bindingSourceCtrl.Find("AM_Acc_Cd", txtAccCode.Text)
            txtAccCode.BackColor = Color.White
            If itemPosition >= 0 Then
                bindingSourceCtrl.Position = itemPosition
            Else
                MessageBox.Show("Account not found")
            End If

        Catch ex As Exception
            MessageBox.Show("Account not found")
        End Try

    End Sub

    Private Sub bindingSourceCtrl_PositionChanged(sender As Object, e As EventArgs) Handles bindingSourceCtrl.PositionChanged
        If Not bindingSourceCtrl.Position >= DirectCast(bindingSourceCtrl.DataSource, DataTable).Rows.Count Then
            EnableDisableControls(False)
        Else
            EnableDisableControls(True)
        End If
    End Sub

    Public Sub EnableDisableControls(pFlg As Boolean)

        txtAccCode.Enabled = True
        btnSearch.Enabled = True
        drpOpenBalEff.Enabled = pFlg
        txtAccName.Enabled = pFlg
        txtAccOpenBalance.Enabled = pFlg
        txtCYBudget.Enabled = pFlg
        txtLYBudget.Enabled = pFlg
        txtLYActual.Enabled = pFlg
        txtLLYActual.Enabled = pFlg
        txtLLYBudget.Enabled = pFlg
    End Sub

    Private Sub txtAccName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAccName.Validating
        If Not validateAcc.CheckAccName(txtAccName.Text) Then
            txtAccName.BackColor = Color.Red
        Else
            txtAccName.BackColor = Color.White
        End If
    End Sub

    Private Sub txtAccOpenBalance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccOpenBalance.KeyPress
        If IsDecimal(e, txtAccOpenBalance) Then
            Return
        End If
        e.Handled = True
    End Sub
End Class