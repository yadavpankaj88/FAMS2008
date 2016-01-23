Public Class frmLedgerAccountManage

    Dim ledgerAcc As LedgerAccountHelper
    Dim accCode As String
    Dim account As New Accounts
    Public val As String = ""
    Private _mode As String
    Public textboxval As String
    Public WithEvents bindingSourceCtrl As BindingSource
    Dim dtAccounts As DataTable

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ledgerAcc = New LedgerAccountHelper

        bindingSourceCtrl = New BindingSource
        txtAccCode.Text = String.Empty
        BindData()

    End Sub

    Sub New(ByVal pAccCode As String)
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ledgerAcc = New LedgerAccountHelper
        accCode = pAccCode
    End Sub

    Private Sub frmLedgerAccountManage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        drpOpenBalEff.DataSource = CommonFunctions.BindCreditDebit()
        drpOpenBalEff.DisplayMember = "Text"
        drpOpenBalEff.ValueMember = "Value"
        Me.KeyPreview = True
        If bindingSourceCtrl.Count = 0 Then
            btnSearch.Visible = False
        Else
            btnSearch.Visible = True
        End If

    End Sub

    Private Sub txtLYBudget_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLYBudget.KeyPress

        If IsDecimal(e, txtLYBudget) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub txtLYActual_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLYActual.KeyPress

        If IsDecimal(e, txtLYActual) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub txtLLYBudget_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLLYBudget.KeyPress

        If IsDecimal(e, txtLLYBudget) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub txtLLYActual_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLLYActual.KeyPress

        If IsDecimal(e, txtLLYActual) Then
            Return
        End If
        e.Handled = True
    End Sub

    Private Sub txtCYBudget_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCYBudget.KeyPress

        If IsDecimal(e, txtCYBudget) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub txtAccOpenBalance_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtAccOpenBalance.KeyPress
        If IsDecimal(e, txtAccOpenBalance) Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub txtAccCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAccCode.Validating
        If Not ValidateClass.CheckAccountCode(txtAccCode.Text) Then
            txtAccCode.BackColor = Color.Red
            Dim lbl As New Label
            lbl.Text = "1st character should be A,E,I,L "
        Else
            txtAccCode.BackColor = Color.White
        End If
    End Sub

    Private Sub BindData()

        Try
            dtAccounts = ledgerAcc.GetAccountDetails(String.Empty)
            BindPaginationControl(dtAccounts)

            txtAccCode.DataBindings.Add("Text", bindingSourceCtrl, "AM_Acc_Cd", True)
            txtAccName.DataBindings.Add("Text", bindingSourceCtrl, "AM_Acc_Nm", True)
            txtAccName.Text = txtAccName.Text.Trim()

            drpOpenBalEff.DataBindings.Clear()
            drpOpenBalEff.DataBindings.Add("SelectedValue", bindingSourceCtrl, "AM_OB_Cr_Dr", True)

            txtAccOpenBalance.DataBindings.Clear()
            txtAccOpenBalance.DataBindings.Add("Text", bindingSourceCtrl, "AM_ABS_Opn_Bal", True)
            txtLLYBudget.DataBindings.Add("Text", bindingSourceCtrl, "AM_LLY_Budg", True)
            txtLLYActual.DataBindings.Add("Text", bindingSourceCtrl, "AM_LLY_Actu", True)
            txtLYActual.DataBindings.Add("Text", bindingSourceCtrl, "AM_LYr_Actu", True)
            txtLYBudget.DataBindings.Add("Text", bindingSourceCtrl, "AM_LYr_Budg", True)
            txtCYBudget.DataBindings.Add("Text", bindingSourceCtrl, "AM_Cyr_Budg", True)
            LblLinkedTo.DataBindings.Add("Text", bindingSourceCtrl, "AM_Calls", True)

            EnableDisableControls(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Sub SetControls(ByVal pMode As String)
        _mode = pMode
    End Sub

    Public Sub SaveData()
        Try
            If Not ValidateClass.CheckAccountCode(txtAccCode.Text) Then
                txtAccCode.BackColor = Color.Red
                MessageBox.Show("Account number is not in correct format")
            Else
                txtAccCode.BackColor = Color.White
                Dim errorStr As String = ""
                errorStr = Validation()
                If errorStr = "" Then
                    account.AccCode = txtAccCode.Text.ToString()
                    account.AccName = txtAccName.Text.Trim
                    account.CreditDebit = drpOpenBalEff.SelectedValue
                    account.AccAbsOpenBalance = decimal_Notnull(txtAccOpenBalance.Text)
                    account.AccLLYbudget = decimal_Notnull(txtLLYBudget.Text)
                    account.AccLLYactual = decimal_Notnull(txtLLYActual.Text)
                    account.AccLYbudget = decimal_Notnull(txtLYBudget.Text)
                    account.AccLYactual = decimal_Notnull(txtLYActual.Text)
                    account.AccCYbudget = decimal_Notnull(txtCYBudget.Text)
                    If (_mode = "add" And ledgerAcc.GetCount(txtAccCode.Text) > 0) Then
                        MessageBox.Show("Account code already exists")
                    Else
                        ledgerAcc.AddLedgerAccount(account)
                        dtAccounts = ledgerAcc.GetAccountDetails(String.Empty)
                        BindPaginationControl(dtAccounts)
                        ClearData()
                        MessageBox.Show("Data updated successfully")

                    End If
                Else
                    EnableDisableControls(True)
                    MessageBox.Show(errorStr)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Function decimal_Notnull(ByVal txtbox As String) As Decimal
        If txtbox = "" Then
            txtbox = 0
        Else
            Decimal.Parse(txtbox)
        End If
        Return txtbox
    End Function

    Private Function IsDecimal(ByVal keyArgs As KeyPressEventArgs, ByVal sender As TextBox) As Boolean
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

                If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ledgerAcc.DeleteAccount(currentRec.Row("AM_Acc_Cd").ToString)
                    txtAccCode.Text = "true"
                    txtAccName.Text = ""
                    txtAccOpenBalance.Text = ""
                    txtCYBudget.Text = ""
                    txtLLYActual.Text = ""
                    txtLLYBudget.Text = ""
                    txtLYActual.Text = ""
                    txtLYBudget.Text = ""
                    Me.Close()
                    Return True

                Else

                    Return False
                End If
            Else
                MessageBox.Show("This account is currently used in transactions, and cannot be deleted")
                Return False
            End If
        ElseIf currentRec("AM_Acc_Cd") Is DBNull.Value And currentRec("AM_Calls") Is DBNull.Value Then

            MessageBox.Show("It's empty record")
        Else
            If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ledgerAcc.DeleteAccount(currentRec.Row("AM_Acc_Cd").ToString)
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Private Sub frmLedgerAccountManage_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        If frmMain IsNot Nothing Then
            frmMain.mainBindingNavigator.BindingSource = Nothing
            frmMain.pnlNavigator.Visible = False
            frmMain.pnlMenu.Visible = True
            frmMain.EnableNavToolBar()
        End If
        OnForClosing()
    End Sub

    Function CheckValidAccountCode() As Boolean
        If Not ValidateClass.CheckAccountCode(txtAccCode.Text) Then
            txtAccCode.BackColor = Color.Red
        Else
            txtAccCode.BackColor = Color.White
        End If
    End Function

    Function OnForClosing() As Boolean
        Dim ledgerAcchelper As New LedgerAccountHelper
        Dim dt As DataTable

        dt = ledgerAcchelper.GetAccDetails(txtAccCode.Text)
        If dt.Rows.Count() > 0 Then
            If txtAccOpenBalance.Text = "" Then

                If dt.Rows(0)("AM_ABS_Opn_Bal") = 0.0 Then
                    txtAccOpenBalance.Text = 0
                    dt.Rows(0)("AM_ABS_Opn_Bal") = Math.Round(dt.Rows(0)("AM_ABS_Opn_Bal"))
                Else
                    dt.Rows(0)("AM_ABS_Opn_Bal") = Math.Round(dt.Rows(0)("AM_ABS_Opn_Bal"))
                    txtAccOpenBalance.Text = Math.Round(Convert.ToDecimal(txtAccOpenBalance.Text))
                End If
            Else
                dt.Rows(0)("AM_ABS_Opn_Bal") = Math.Round(dt.Rows(0)("AM_ABS_Opn_Bal"))
                txtAccOpenBalance.Text = Math.Round(Convert.ToDecimal(txtAccOpenBalance.Text))
            End If

            If txtLLYBudget.Text = "" Then
                If dt.Rows(0)("AM_LLY_Budg") = 0.0 Then
                    txtLLYBudget.Text = 0
                    dt.Rows(0)("AM_LLY_Budg") = 0

                Else
                    dt.Rows(0)("AM_LLY_Budg") = Math.Round(dt.Rows(0)("AM_LLY_Budg"))
                    txtLLYBudget.Text = Math.Round(Convert.ToDecimal(txtLLYBudget.Text))
                End If
            Else
                dt.Rows(0)("AM_LLY_Budg") = Math.Round(dt.Rows(0)("AM_LLY_Budg"))
                txtLLYBudget.Text = Math.Round(Convert.ToDecimal(txtLLYBudget.Text))
            End If

            If txtLLYActual.Text = "" Then

                If dt.Rows(0)("AM_LLY_Actu") = 0.0 Then
                    txtLLYActual.Text = 0
                    dt.Rows(0)("AM_LLY_Actu") = 0
                Else
                    dt.Rows(0)("AM_LLY_Actu") = Math.Round(dt.Rows(0)("AM_LLY_Actu"))
                    txtLLYActual.Text = Math.Round(Convert.ToDecimal(txtLLYActual.Text))
                End If
            Else
                dt.Rows(0)("AM_LLY_Actu") = Math.Round(dt.Rows(0)("AM_LLY_Actu"))
                txtLLYActual.Text = Math.Round(Convert.ToDecimal(txtLLYActual.Text))
            End If

            If txtLYBudget.Text = "" Then

                If dt.Rows(0)("AM_LYr_Budg") = 0.0 Then
                    txtLYBudget.Text = 0
                    dt.Rows(0)("AM_LYr_Budg") = 0
                Else
                    dt.Rows(0)("AM_LYr_Budg") = Math.Round(dt.Rows(0)("AM_LYr_Budg"))
                    txtLYBudget.Text = Math.Round(Convert.ToDecimal(txtLYBudget.Text))
                End If
            Else
                dt.Rows(0)("AM_LYr_Budg") = Math.Round(dt.Rows(0)("AM_LYr_Budg"))
                txtLYBudget.Text = Math.Round(Convert.ToDecimal(txtLYBudget.Text))
            End If

            If txtLYActual.Text = "" Then
                If dt.Rows(0)("AM_LYr_Actu") = 0 Then
                    txtLYActual.Text = 0
                    dt.Rows(0)("AM_LYr_Actu") = 0
                Else
                    dt.Rows(0)("AM_LYr_Actu") = Math.Round(dt.Rows(0)("AM_LYr_Actu"))
                    txtLYActual.Text = Math.Round(Convert.ToDecimal(txtLYActual.Text))
                End If
            Else
                dt.Rows(0)("AM_LYr_Actu") = Math.Round(dt.Rows(0)("AM_LYr_Actu"))
                txtLYActual.Text = Math.Round(Convert.ToDecimal(txtLYActual.Text))
            End If

            If txtCYBudget.Text = "" Then

                If dt.Rows(0)("AM_Cyr_Budg") = 0.0 Then
                    txtCYBudget.Text = 0
                    dt.Rows(0)("AM_Cyr_Budg") = 0
                Else
                    dt.Rows(0)("AM_Cyr_Budg") = Math.Round(dt.Rows(0)("AM_Cyr_Budg"))
                    txtCYBudget.Text = Math.Round(Convert.ToDecimal(txtCYBudget.Text))
                End If
            Else
                dt.Rows(0)("AM_Cyr_Budg") = Math.Round(dt.Rows(0)("AM_Cyr_Budg"))
                txtCYBudget.Text = Math.Round(Convert.ToDecimal(txtCYBudget.Text))
            End If

        Else
            If (txtAccCode.Text = "TRUE" Or txtAccCode.Text = "" Or txtAccName.Text = "") Then

            Else
                If MessageBox.Show("Do you want to save changes?", " Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    SaveData()
                    Return True
                Else
                    Return False
                    Me.Close()
                End If
            End If
        End If
        ' End If
        If (txtAccCode.Text = "TRUE" Or txtAccCode.Text = "" Or txtAccName.Text = "") Then

        Else
            If (dt.Rows(0)("AM_ABS_Opn_Bal").ToString() <> txtAccOpenBalance.Text) Or dt.Rows(0)("AM_LLY_Budg").ToString() <> txtLLYBudget.Text Or (dt.Rows(0)("AM_LLY_Actu").ToString() <> txtLLYActual.Text) Or (dt.Rows(0)("AM_LYr_Budg").ToString() <> txtLYBudget.Text) Or (dt.Rows(0)("AM_LYr_Actu").ToString() <> txtLYActual.Text) Or (dt.Rows(0)("AM_Cyr_Budg").ToString() <> txtCYBudget.Text) Then
                If MessageBox.Show("Do you want to save changes?", " Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    SaveData()
                    Return True
                Else
                    Return False
                    Me.Close()
                End If
            Else
                Return False
                Me.Close()
            End If
            Me.Close()
        End If
    End Function

    Private Sub bindingSourceCtrl_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles bindingSourceCtrl.PositionChanged
        If Not bindingSourceCtrl.Position >= DirectCast(bindingSourceCtrl.DataSource, DataTable).Rows.Count Then
            EnableDisableControls(False)
        Else
            EnableDisableControls(True)
        End If
    End Sub

    Public Sub EnableDisableControls(ByVal pFlg As Boolean)

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

    Private Sub drpOpenBalEff_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpOpenBalEff.Leave
        If drpOpenBalEff.Text = String.Empty Then
            drpOpenBalEff.Focus()
        End If
    End Sub

    Function Validation() As String
        Dim result As String = ""

        If txtAccCode.Text.Trim = String.Empty Or txtAccCode.Text = "   " Or String.IsNullOrEmpty(txtAccCode.Text.Trim()) Then
            result = result & "- Account code is empty" & vbNewLine
        End If

        If txtAccName.Text = String.Empty Then
            result = result & "- Account name is empty" & vbNewLine
        End If
        If drpOpenBalEff.SelectedIndex = -1 Then
            result = result & "- Please select credit/debit" & vbNewLine
        End If
        Return result
    End Function

    Private Sub frmLedgerAccountManage_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dim frmfammain As frmFAMSMain = DirectCast(ActiveForm, frmFAMSMain)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim dt As New DataTable
            Dim ldgAccHelper As New LedgerAccountHelper
            Dim fillAccCode As New frmFillAccCode
            Dim message As String
            Dim itemPosition As Integer = bindingSourceCtrl.Find("AM_Acc_Cd", txtAccCode.Text)
            fillAccCode.setvalue(txtAccCode.Text)
            fillAccCode.ShowDialog()
            message = fillAccCode.msg
            If (message <> "") Then
                MessageBox.Show(message)
                ClearData()
            Else
                'fillAccCode.ShowDialog()

                ldgAccHelper.CheckAccCd(txtAccCode.Text)
                txtAccCode.Text = fillAccCode.val
                If (fillAccCode.val = Nothing) Then
                    MessageBox.Show("Please select account")
                    fillAccCode.ShowDialog()
                    txtAccCode.Text = fillAccCode.val
                End If
                dt = ledgerAcc.GetAccountDetails(txtAccCode.Text)
                txtAccCode.BackColor = Color.White
                txtAccName.Text = dt.Rows(0)("AM_Acc_Nm").ToString()
                txtAccOpenBalance.Text = dt.Rows(0)("AM_ABS_Opn_Bal").ToString()
                txtLLYBudget.Text = dt.Rows(0)("AM_LLY_Budg")
                txtLLYActual.Text = dt.Rows(0)("AM_LLY_Actu")
                txtLYActual.Text = dt.Rows(0)("AM_LYr_Actu")
                txtLYBudget.Text = dt.Rows(0)("AM_LYr_Budg")
                txtCYBudget.Text = dt.Rows(0)("AM_Cyr_Budg")
                LblLinkedTo.Text = dt.Rows(0)("AM_Calls")
            End If
            EnableDisableControls(False)

        Catch ex As Exception
            MessageBox.Show("Account not found")
        End Try

    End Sub

    Private Sub frmLedgerAccountManage_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode.ToString = "S" Then
            SaveData()
        End If
        If e.Control And e.KeyCode.ToString = "N" Then
            EnableDisableControls(True)
            LblLinkedTo.Text = "Not Linked"
            frmFAMSMain.toolstripSave.Enabled = True
            frmFAMSMain.DisableNavToolBar(frmFAMSMain.NavSettings.Add)
            ClearData()
        End If

    End Sub

    Sub ClearData()
        txtAccCode.Text = ""
        txtAccName.Text = ""
        txtAccOpenBalance.Text = "0"
        txtCYBudget.Text = "0"
        txtLLYActual.Text = "0"
        txtLLYBudget.Text = "0"
        txtLYActual.Text = "0"
        txtLYBudget.Text = "0"
        txtCYBudget.Text = "0"
        txtAccCode.Enabled = True
        txtAccCode.Focus()
        LblLinkedTo.Text = ""

    End Sub

    Sub BindPaginationControl(ByVal dtAccounts As DataTable)
        For Each row As DataRow In dtAccounts.Rows
            If row("AM_Calls") Is DBNull.Value Then
                row("AM_Calls") = "Not Linked"
                row.AcceptChanges()
            End If
        Next

        dtAccounts.AcceptChanges()
        bindingSourceCtrl.DataSource = dtAccounts
        bindingSourceCtrl.Sort = "AM_Acc_Cd Asc"

    End Sub

    Private Sub txtAccCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccCode.Leave
        If (_mode = "add") Then


            If txtAccCode.Text.Contains("A") Or txtAccCode.Text.Contains("E") Then
                drpOpenBalEff.Text = "Debit"
            Else
                drpOpenBalEff.Text = "Credit"
            End If
        End If
    End Sub

End Class