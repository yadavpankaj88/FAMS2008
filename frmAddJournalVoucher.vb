﻿Public Class frmAddJournalVoucher
#Region "Private variables"
    Private _Voucher_Type As String
    Private _PayeeReceipt As String
    Private _TrnType As String
    Private _mode As String
    Private ledgerAcc As LedgerAccountHelper
    Private parentForm As frmFAMSMain
    Private ledgerAccBalance As Double
    Dim firsttime As Boolean = False
#End Region

#Region "Public Properties"

    Property VoucherType() As String
        Get
            Return _Voucher_Type
        End Get
        Set(ByVal Value As String)
            _Voucher_Type = Value
        End Set
    End Property

    Property PaymentReceipt() As String
        Get
            Return _PayeeReceipt
        End Get
        Set(ByVal Value As String)
            _PayeeReceipt = Value
        End Set
    End Property

    Property TransactionType() As String
        Get
            Return _TrnType
        End Get
        Set(ByVal value As String)
            _TrnType = value
            Select Case _TrnType
                Case "BP", "BR"
                    parentForm.lblBankBalance.Visible = True
                    parentForm.lblBankBalance.Text = "Bank Balance : "
                Case Else
                    parentForm.lblBankBalance.Visible = False

            End Select
        End Set
    End Property

    Public WriteOnly Property MDIForm() As frmFAMSMain
        Set(ByVal Value As frmFAMSMain)
            parentForm = Value
        End Set
    End Property

    Private lastVoucherDateValue As DateTime = InstitutionMasterData.XDate

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        dgvVoucherDetails.AutoGenerateColumns = False
        ' Add any initialization after the InitializeComponent() call.
        ledgerAcc = New LedgerAccountHelper

    End Sub

    Private Function LinkNumberTextChange(ByVal ShowMessagebox As Boolean) As Boolean
        If _mode IsNot Nothing Then
            If _mode.ToLower() = "edit" Or _mode.ToLower() = "delete" Or _mode = "confirm" Or _mode = "view" Then
                If txtLinkVoucherNumber.Text <> String.Empty Then
                    Dim flgEnable As String = BindVoucherDetails()
                    Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
                    'populate voucher details
                    If String.IsNullOrEmpty(flgEnable) Then
                        Me.pnlConfirm.Visible = True

                        Select Case _mode
                            Case "view"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Me.DatePickerVoucherLinkDate.Visible = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False
                                Me.DatePickerVoucherLinkDate.Enabled = False
                                frmMain.ToolStripButtonPrint.Enabled = True
                            Case "delete"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                txtLinkVoucherNumber.Enabled = False
                                Me.DatePickerVoucherLinkDate.Visible = True
                                Me.DatePickerVoucherLinkDate.Enabled = False
                                LabelVoucherDate.Visible = True
                                frmMain.toolstripSave.Enabled = True
                                frmMain.ToolStripButtonPrint.Enabled = False
                            Case "edit"
                                Me.panelVoucherControls.Visible = True
                                Me.dgvVoucherDetails.Visible = True
                                Me.DatePickerVoucherLinkDate.Visible = True
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Me.DatePickerVoucherLinkDate.Visible = True
                                Me.DatePickerVoucherLinkDate.Enabled = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False
                                frmMain.toolstripSave.Enabled = True
                                frmMain.ToolStripButtonPrint.Enabled = False
                            Case "confirm"
                                datepickerVoucherDateConfirm.Format = DateTimePickerFormat.Short
                                datepickerVoucherDateConfirm.CustomFormat = "dd-mm-yyyy"
                                datepickerVoucherDateConfirm.Value = InstitutionMasterData.XDate
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                txtLinkVoucherNumber.Enabled = False
                                DatePickerVoucherLinkDate.Visible = True
                                DatePickerVoucherLinkDate.Enabled = False
                                Me.pnlConfirm.Enabled = True
                                lblConfirmNumber.Text = "-"
                                lblConfirmNumber.BackColor = Color.Transparent
                                lblConfirmedVoucherNumber.Visible = False
                                frmMain.toolstripSave.Enabled = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False
                                datepickerVoucherDateConfirm.Enabled = True
                                frmMain.ToolStripButtonPrint.Enabled = False
                        End Select
                    Else
                        If (ShowMessagebox) Then
                            MessageBox.Show(flgEnable)
                        End If
                        Me.panelVoucherControls.Visible = False
                    End If
                End If
            End If
        End If
    End Function

    Private Sub txtLinkVoucherNumber_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLinkVoucherNumber.KeyUp
        Try
            Select Case e.KeyCode
                Case (Keys.Tab)
                    LinkNumberTextChange(True)
                Case (Keys.Enter)
                    LinkNumberTextChange(True)
                Case Keys.F2
                    Dim helper As popupHelper = New popupHelper(1, VoucherType)
                    helper.TransType = TransactionType
                    helper.dbkCode = ComboBoxDaybookSelect.SelectedValue.ToString()
                    helper.currentMode = Me._mode
                    helper.ShowDialog()
                    txtLinkVoucherNumber.Text = helper.selectedCode
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetControlsForEdit()

    End Sub

    Public Sub ClearControls()
        txtLinkVoucherNumber.Text = String.Empty
        lblConfirmedVoucherNumber.Text = String.Empty
        pnlConfirm.Enabled = False
        panelVoucherControls.Visible = False
        SplitContainer1.Panel2Collapsed = True
        SplitContainer1.Panel1Collapsed = False
        lblConfirmNumber.Text = "-"
        lblConfirmNumber.BackColor = Color.Transparent
        If _mode IsNot Nothing Then
            If _mode.ToLower() = "clear" Then
                ComboBoxDaybookSelect.Enabled = True
            End If
        End If

        Try
            dgvVoucherDetails.Rows.Clear()

        Catch ex As Exception
            Dim dt As DataTable = dgvVoucherDetails.DataSource
            If dt IsNot Nothing Then
                dt.Clear()
            End If

        End Try


    End Sub

    Private Sub frmAddVoucher_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        If Not String.IsNullOrEmpty(VoucherType) Then
            parentForm.pnlNavigator.Visible = True
            parentForm.pnlMenu.Visible = False
            parentForm.pnlNavigator.Enabled = False
            ComboBoxDaybookSelect.Enabled = True
            PupulateDaybookCombo()
        End If


        If VoucherType = "J" Then
            'ComboBoxCreditDebit.SelectedIndex = 0
        End If

        SetOperationMode(String.Empty)
        SetControls(String.Empty)

    End Sub

    Private Sub PupulateDaybookCombo()
        Dim dbHelper As DayBooksHelper = New DayBooksHelper()
        Dim dt As DataTable = dbHelper.GetDaybooksByType(VoucherType)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                ComboBoxDaybookSelect.DataSource = dt
                ComboBoxDaybookSelect.DisplayMember = "DisplayName"
                ComboBoxDaybookSelect.ValueMember = "DM_Dbk_Cd"
            Else
                MessageBox.Show("There are no daybooks configured for this transaction type , please configure the daybooks", "Configuration Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ConfirmVoucher()
        Dim helper As VoucherHelper = New VoucherHelper()
        Dim calculateDiff As Boolean = True
        Try
            If _TrnType.Equals("BP") Or _TrnType.Equals("CP") Then
                'calculateDiff = ValidateClass.CheckBalance(ledgerAccBalance, Double.Parse(TextBoxAmount.Text))
            End If
            If calculateDiff Then
                If (Not String.IsNullOrEmpty(ComboBoxDaybookSelect.SelectedValue) And Not String.IsNullOrEmpty(txtLinkVoucherNumber.Text)) Then

                    If (datepickerVoucherDateConfirm.Enabled) Then
                        Dim vHelper As VoucherHelper = New VoucherHelper()
                        Dim dt As DataTable = vHelper.GetNextVoucherNumber(datepickerVoucherDateConfirm.Value, ComboBoxDaybookSelect.SelectedValue)
                        If Not dt Is Nothing Then
                            If dt.Rows.Count > 0 Then
                                lblConfirmNumber.Text = dt.Rows(0)(0).ToString()
                                lblConfirmNumber.BackColor = Color.Red
                                lblConfirmNumber.ForeColor = Color.White
                                txtNextCount.Text = dt.Rows(0)(1).ToString()
                            End If
                        End If
                    End If

                    Dim instMaster As InstitutionMasterData = New InstitutionMasterData()
                    Dim vchRefNo As Int64
                    vchRefNo = instMaster.GetNextInstitutionVoucherReferenceNumber()

                    lblConfirmedVoucherNumber.Visible = True
                    lblConfirmedVoucherNumber.Text = vchRefNo.ToString().PadLeft(6, "0")

                    If (lblConfirmNumber.Text.Trim() <> "-") Then
                        helper.ConfirmVoucher(txtLinkVoucherNumber.Text, datepickerVoucherDateConfirm.Value.ToString(), lblConfirmNumber.Text.Trim(), vchRefNo.ToString().PadLeft(6, "0"), VoucherType)
                        instMaster.UpdateRefernceNumber(vchRefNo, InstitutionMasterData.XInstCode)
                    End If

                    Dim lgdr As Ledger = New Ledger()
                    Dim lgdrhelper As LedgerHelper = New LedgerHelper()

                    Dim str As String
                    str = txtLinkVoucherNumber.Text
                    Dim ledgercount As Integer = lgdrhelper.GetCountFromLedger(str)
                    If ledgercount = 0 Then
                        lgdrhelper.AddLedger(str)
                        lgdrhelper.AddLedgerDetail(str, VoucherType)
                    Else
                        MessageBox.Show("Data is already in Ledger")
                    End If

                    Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
                    If frmMain IsNot Nothing Then
                        frmMain.SetBalance()

                        Select Case TransactionType
                            Case "BP", "BR"
                                parentForm.lblBankBalance.Visible = True
                                ledgerAccBalance = ledgerAcc.GetBalance(pDaybookcode:=ComboBoxDaybookSelect.SelectedValue.ToString)
                                parentForm.lblBankBalance.Text = String.Format("Bank Balance : {0}", ledgerAccBalance)
                            Case Else
                                parentForm.lblBankBalance.Visible = False

                        End Select
                    End If
                    MessageBox.Show("Voucher confirmed successfully." + Environment.NewLine + "Voucher Confirm Number: " + lblConfirmNumber.Text + Environment.NewLine + "Voucher Reference Number: " + lblConfirmedVoucherNumber.Text)
                End If
            Else
                MessageBox.Show("Insufficient Balance cannot confirm voucher !!!", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub DeleteVoucher()
        Dim helper As VoucherHelper = New VoucherHelper()
        If Not String.IsNullOrEmpty(txtLinkVoucherNumber.Text) Then
            helper.DeleteUnConfirmedVouchers(txtLinkVoucherNumber.Text)
        End If
    End Sub

    Public Function ValidateForm() As String
        Dim mandatoryFields As String = String.Empty






        Dim crdr As Boolean = False


        If Not crdr Then
            mandatoryFields += ", Credit/Debit"
        End If



        If (mandatoryFields.StartsWith(",")) Then
            mandatoryFields = mandatoryFields.Substring(1)
        End If

        Return mandatoryFields.Trim()
    End Function

    Public Function ValidateDates() As String
        Dim messageToShow As String = String.Empty
        Dim voucherlinkDateValidation As String = String.Empty
        Dim referenceDateValidation As String = String.Empty
        Dim voucherConfirmationDateValidation As String = String.Empty

        If (DatePickerVoucherLinkDate.Enabled And Not ValidateClass.CheckVoucherDate(DatePickerVoucherLinkDate.Value.Date, voucherlinkDateValidation)) Then
            messageToShow += Environment.NewLine + "- " + voucherlinkDateValidation
        End If

        'If (DateTimeReferenceDate.Enabled And Not ValidateClass.CheckReferenceDate(DateTimeReferenceDate.Value.Date, referenceDateValidation, DatePickerVoucherLinkDate.Value.Date)) Then
        '    messageToShow += Environment.NewLine + "- " + referenceDateValidation
        'End If

        If (datepickerVoucherDateConfirm.Enabled And Not ValidateClass.CheckConfirmationdate(datepickerVoucherDateConfirm.Value.Date, voucherConfirmationDateValidation, DatePickerVoucherLinkDate.Value.Date)) Then
            messageToShow += Environment.NewLine + "- " + voucherConfirmationDateValidation
        End If

        'If (datepickerChequeDate.Enabled And datepickerChequeDate.Value.Date.CompareTo(InstitutionMasterData.XDate) > 0) Then
        '    messageToShow += Environment.NewLine + "- " + "Cheque date cannot be greater that processing date"
        'End If
        Return messageToShow
    End Function

    Public Function SaveVoucher() As Boolean

        Dim header As VoucherHeader = New VoucherHeader()
        Dim helper As VoucherHelper = New VoucherHelper()
        Dim mandatoryFields As String = String.Empty
        Dim dateValidationMessage As String = String.Empty

        Try
            If Me._mode.ToLower() = "delete" Then
                Dim dlgResult As DialogResult = MessageBox.Show("Are you sure you want to delete this voucher?", "Delete?", MessageBoxButtons.YesNo)
                If (dlgResult = Windows.Forms.DialogResult.Yes) Then
                    DeleteVoucher()
                    MessageBox.Show("Voucher deleted successfully.")
                    Return True
                Else
                    Return False
                End If
            End If

            dateValidationMessage = ValidateDates()

            If Me._mode.ToLower() = "confirm" Then
                If Not dateValidationMessage = String.Empty Then
                    MessageBox.Show("Please correct below errors: " + dateValidationMessage)
                    Return False
                Else
                    Dim dlgResult As DialogResult = MessageBox.Show("Are you sure you want to confirm this voucher?", "Confirm?", MessageBoxButtons.YesNo)
                    If (dlgResult = Windows.Forms.DialogResult.Yes) Then
                        ConfirmVoucher()
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If

            mandatoryFields = ValidateForm()




            If VoucherType = "J" Then
                Dim IsSuccessFull As Boolean = True
                Dim InValidLedgerCode As Boolean = False
                Dim instMaster As InstitutionMasterData = New InstitutionMasterData()
                Dim vchRefNo As Int64
                If Me._mode.ToLower() = "add" Then
                    vchRefNo = instMaster.GetNextInstitutionVoucherReferenceNumber()
                ElseIf Me._mode.ToLower() = "edit" Then
                    vchRefNo = Convert.ToInt64(lblConfirmedVoucherNumber.Text.Trim())
                End If

                Dim i As Integer = 0

                If dgvVoucherDetails.Rows.Count > 0 Then
                    For Each dgRows As DataGridViewRow In dgvVoucherDetails.Rows
                        If Not dgRows.Cells("DebitCr").Value = String.Empty And Not dgRows.Cells("Amount").EditedFormattedValue = String.Empty And dgRows.Cells("LedgerAccount").Value IsNot DBNull.Value And Not dgRows.Cells("LedgerAccount").Value = String.Empty And Not dgRows.Cells("RefDate").EditedFormattedValue = String.Empty And Not dgRows.Cells("RefNo").EditedFormattedValue = String.Empty Then
                            i = i + 1
                        End If
                    Next
                End If

                If dgvVoucherDetails.Rows.Count > 0 And (i > 0 And i = (dgvVoucherDetails.Rows.Count - 1)) Then
                    If BalanceValidation() Then
                        For Each dgRows As DataGridViewRow In dgvVoucherDetails.Rows
                            Try
                                If Not dgRows.Cells("DebitCr").Value = String.Empty And Not dgRows.Cells("Amount").EditedFormattedValue = String.Empty And dgRows.Cells("LedgerAccount").Value IsNot DBNull.Value And Not dgRows.Cells("LedgerAccount").Value = String.Empty And Not dgRows.Cells("RefDate").EditedFormattedValue = String.Empty And Not dgRows.Cells("RefNo").EditedFormattedValue = String.Empty Then
                                    Dim drcr As String = dgRows.Cells("DebitCr").EditedFormattedValue.ToString()
                                    Dim amount As String = dgRows.Cells("Amount").EditedFormattedValue
                                    Dim ledgerAccount As String = dgRows.Cells("LedgerAccount").EditedFormattedValue
                                    Dim seqNo As String = dgRows.Cells("SeqNo").EditedFormattedValue

                                    Dim lgrHelper As LedgerAccountHelper = New LedgerAccountHelper()
                                    Dim dt As DataTable = lgrHelper.GetAccountDetails(ledgerAccount)
                                    If dt IsNot Nothing Then
                                        If dt.Rows.Count < 1 Then
                                            IsSuccessFull = False
                                            InValidLedgerCode = True
                                            Exit For
                                        End If
                                    End If

                                    Dim voucherDetail As VoucherDetails = New VoucherDetails()
                                    voucherDetail.VD_Fin_Yr = InstitutionMasterData.XFinYr
                                    voucherDetail.VD_Inst_Cd = InstitutionMasterData.XInstCode
                                    voucherDetail.VD_Inst_Typ = InstitutionMasterData.XInstType
                                    voucherDetail.VD_Dbk_Cd = ComboBoxDaybookSelect.SelectedValue
                                    voucherDetail.VD_Trn_Typ = TransactionType
                                    voucherDetail.VD_Lgr_Cd = "00"
                                    voucherDetail.VD_Lnk_No = txtLinkVoucherNumber.Text
                                    voucherDetail.VD_Narr = dgRows.Cells("VoucherDesc").EditedFormattedValue
                                    voucherDetail.VD_Cr_Dr = drcr
                                    voucherDetail.VD_ABS_Amt = amount
                                    voucherDetail.VD_Amt = IIf(drcr = "Dr", Decimal.Parse(amount), Decimal.Parse(amount) * -1)
                                    voucherDetail.VD_Ref_No = dgRows.Cells("RefNo").EditedFormattedValue
                                    voucherDetail.VD_Ref_Dt = Convert.ToDateTime(dgRows.Cells("RefDate").EditedFormattedValue)
                                    voucherDetail.VD_Seq_No = seqNo
                                    voucherDetail.VD_Acc_Cd = ledgerAccount
                                    voucherDetail.VD_Brn_Cd = "HO"
                                    voucherDetail.VD_Ent_By = InstitutionMasterData.XUsrId
                                    voucherDetail.VD_Vch_Ref_No = vchRefNo.ToString().PadLeft(6, "0")
                                    voucherDetail.VD_Lnk_Dt = DatePickerVoucherLinkDate.Value
                                    helper.SaveVoucherDetail(voucherDetail)
                                End If
                            Catch ex As Exception
                                IsSuccessFull = False
                            End Try
                        Next
                    Else
                        Return False
                    End If
                End If

                If (IsSuccessFull And (i > 0 And i = (dgvVoucherDetails.Rows.Count - 1))) Then
                    If Me._mode = "add" Then
                        instMaster.UpdateLinkNumber(txtLinkVoucherNumber.Text.Trim(), InstitutionMasterData.XInstCode)
                    End If
                    MessageBox.Show("Voucher saved successfully.")
                Else
                    If InValidLedgerCode Then
                        MessageBox.Show("Invalid ledger code for one of the voucher details entry")
                    ElseIf Not IsSuccessFull Then
                        MessageBox.Show("Error occured while saving voucher details")
                    ElseIf i <= 0 Or Not i = (dgvVoucherDetails.Rows.Count - 1) Then
                        MessageBox.Show("Please enter atleast one valid voucher details entry")
                    End If
                    Return False
                End If
            Else
                Return False
            End If



            ClearControls()
            Return True
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function BalanceValidation() As Boolean

        Dim crAmount As Integer = 0
        Dim drAmount As Integer = 0

        For Each dgvrow As DataGridViewRow In dgvVoucherDetails.Rows

            Dim ledgerAccount As String = dgvrow.Cells("LedgerAccount").EditedFormattedValue
            Dim InValidLedgerCode As Boolean = False
            Dim lgrHelper As LedgerAccountHelper = New LedgerAccountHelper()
            Dim dt As DataTable = lgrHelper.GetAccountDetails(ledgerAccount)
            If dt IsNot Nothing Then
                If dt.Rows.Count < 1 Then
                    InValidLedgerCode = True
                    Exit For
                End If
            End If

            If Not InValidLedgerCode And Not dgvrow.Cells("Amount").EditedFormattedValue = String.Empty And Not dgvrow.Cells("LedgerAccount").EditedFormattedValue = String.Empty And Not dgvrow.Cells("RefDate").EditedFormattedValue = String.Empty And Not dgvrow.Cells("RefNo").EditedFormattedValue = String.Empty Then
                Dim rowDecimal As Decimal
                rowDecimal = Decimal.Parse(dgvrow.Cells("Amount").EditedFormattedValue)
                Dim drcr As String = dgvrow.Cells("DebitCr").EditedFormattedValue.ToString()
                If drcr = "Cr" Then
                    crAmount = crAmount + rowDecimal
                Else
                    drAmount = drAmount + rowDecimal
                End If
            End If

        Next

        If drAmount <> crAmount Then
            MessageBox.Show("Total of all Cr and Dr should be zero", "Incorrect Amount")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub dgvVoucherDetails_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles dgvVoucherDetails.EditingControlShowing
        If dgvVoucherDetails.Columns(dgvVoucherDetails.CurrentCell.ColumnIndex).Name = "LedgerAccount" Then
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            AddHandler tb.KeyDown, AddressOf dataGridViewTextBox_KeyDown
            AddHandler tb.Validating, AddressOf dataGridViewTextBox_Validating
        End If

        If dgvVoucherDetails.Columns(dgvVoucherDetails.CurrentCell.ColumnIndex).Name = "Amount" Then
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            AddHandler tb.KeyPress, AddressOf Amount_KeyPress
        End If

        If TypeOf e.Control Is TextBox Then
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
        End If

    End Sub

    Private Sub dataGridViewTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If dgvVoucherDetails.Columns(dgvVoucherDetails.CurrentCell.ColumnIndex).Name = "LedgerAccount" Then
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
            If tb IsNot Nothing Then
                If tb.Text IsNot String.Empty Then
                    Dim lgrCode As String = tb.Text
                    Dim lgrHelper As LedgerAccountHelper = New LedgerAccountHelper()
                    Dim dt As DataTable = lgrHelper.GetAccountDetails(lgrCode)
                    If dt IsNot Nothing Then
                        If dt.Rows.Count = 1 Then
                            dgvVoucherDetails.Rows(dgvVoucherDetails.CurrentRow.Index).Cells("AccountName").Value = dt.Rows(0)("AM_Acc_Nm").ToString()
                        Else
                            MessageBox.Show("Invalid ledger code,Please press F2 for help")
                            tb.Focus()
                            e.Cancel = True
                            RemoveHandler tb.Validating, AddressOf dataGridViewTextBox_Validating
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dataGridViewTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

        If e.KeyCode = Keys.F2 And Not e.Handled Then
            Dim helper As popupHelper = New popupHelper(0, VoucherType)
            helper.ShowDialog()

            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)

            If Not tb Is Nothing Then
                tb.Text = helper.selectedCode
                dgvVoucherDetails.Rows(dgvVoucherDetails.CurrentRow.Index).Cells("AccountName").Value = helper.selectedCodeName
            End If

            e.Handled = True

        ElseIf e.KeyCode = Keys.Tab Then
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
            If tb IsNot Nothing Then
                If tb.Text IsNot String.Empty Then

                End If

            End If
        End If
    End Sub

    Private Sub dgvVoucherDetails_RowEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvVoucherDetails.RowEnter
        'dgvVoucherDetails.Rows(e.RowIndex).Cells("RefNo").Value = txtRefNumber.Text
        'dgvVoucherDetails.Rows(e.RowIndex).Cells("RefDate").Value = DateTimeReferenceDate.Value.ToShortDateString()

        If (String.IsNullOrEmpty(dgvVoucherDetails.Rows(e.RowIndex).Cells("SeqNo").Value)) Then
            Dim newSeqNo As Integer = 0
            For x As Integer = 0 To dgvVoucherDetails.Rows.Count - 1
                If newSeqNo = 0 Then
                    newSeqNo = Convert.ToInt32(dgvVoucherDetails.Rows(x).Cells("SeqNo").Value)
                Else
                    If newSeqNo < Convert.ToInt32(dgvVoucherDetails.Rows(x).Cells("SeqNo").Value) Then newSeqNo = Convert.ToInt32(dgvVoucherDetails.Rows(x).Cells("SeqNo").Value)
                End If
            Next
            dgvVoucherDetails.Rows(e.RowIndex).Cells("SeqNo").Value = (newSeqNo + 1).ToString().PadLeft(3, "0")
        End If

        If (String.IsNullOrEmpty(dgvVoucherDetails.Rows(e.RowIndex).Cells("DebitCr").Value)) Then
            If Not String.IsNullOrEmpty(PaymentReceipt) Then
                If PaymentReceipt = "P" Then
                    dgvVoucherDetails.Rows(e.RowIndex).Cells("DebitCr").Value = "Dr"
                ElseIf PaymentReceipt = "R" Then
                    dgvVoucherDetails.Rows(e.RowIndex).Cells("DebitCr").Value = "Cr"
                End If
            End If
        End If
    End Sub

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

    Private Sub Amount_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If dgvVoucherDetails.Columns(dgvVoucherDetails.CurrentCell.ColumnIndex).Name = "Amount" And Not e.Handled Then
            If IsDecimal(e, sender) Then
                Return
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Sub SetVoucherLinkControls(ByVal Visibility As Boolean)


    End Sub

    Sub SetControls(ByVal pMode As String)
        lableVoucherStatus.Text = ""

        datepickerVoucherDateConfirm.Format = DateTimePickerFormat.Custom
        datepickerVoucherDateConfirm.CustomFormat = " "

        Me.pnlConfirm.Visible = False
        Select Case _mode
            Case "view"
                Me.SplitContainer1.Panel2Collapsed = False
                Me.panelVoucherControls.Visible = False
                Me.dgvVoucherDetails.Visible = False
                Me.pnlConfirm.Enabled = False
                Me.Text = Me.Text.Split("(")(0).Trim() + " (Operation: View)"
                ComboBoxDaybookSelect.Enabled = False
                Me.txtLinkVoucherNumber.Enabled = True
                Me.lblLinkVoucherNumber.Visible = True
                Me.txtLinkVoucherNumber.Visible = True
                Me.LabelVoucherDate.Visible = False
                Me.DatePickerVoucherLinkDate.Visible = False
            Case "confirm"
                Me.SplitContainer1.Panel2Collapsed = False
                Me.panelVoucherControls.Visible = False
                Me.LabelVoucherDate.Visible = False
                Me.DatePickerVoucherLinkDate.Visible = False
                Me.txtLinkVoucherNumber.Visible = True
                Me.lblLinkVoucherNumber.Visible = True
                Me.txtLinkVoucherNumber.Enabled = True
                Me.dgvVoucherDetails.Visible = False
                Me.pnlConfirm.Enabled = False
                ComboBoxDaybookSelect.Enabled = False
                DatePickerVoucherLinkDate.Visible = False
                LabelVoucherDate.Visible = False
                ComboBoxDaybookSelect.Enabled = False

                Me.Text = Me.Text.Split("(")(0).Trim() + " (Operation: Confirm)"

            Case "delete"
                Me.SplitContainer1.Panel2Collapsed = False
                Me.panelVoucherControls.Visible = False
                Me.LabelVoucherDate.Visible = False
                Me.DatePickerVoucherLinkDate.Visible = False
                Me.txtLinkVoucherNumber.Visible = True
                Me.lblLinkVoucherNumber.Visible = True
                Me.txtLinkVoucherNumber.Enabled = True

                Me.dgvVoucherDetails.Visible = False
                Me.pnlConfirm.Enabled = False
                ComboBoxDaybookSelect.Enabled = False

                Me.Text = Me.Text.Split("(")(0).Trim() + " (Operation: Delete)"

            Case "add"
                Dim instMaster As InstitutionMasterData = New InstitutionMasterData()
                txtLinkVoucherNumber.Text = instMaster.GetNextInstitutionLinkNumber().ToString().PadLeft(12, "0")
                txtLinkVoucherNumber.Enabled = False

                If VoucherType = "J" Then
                    TextBoxNarration.Enabled = False
                End If
                SplitContainer1.Panel2Collapsed = False
                lastVoucherDateValue = DatePickerVoucherLinkDate.Value
                panelVoucherControls.Visible = True
                panelVoucherControls.Enabled = True
                ComboBoxDaybookSelect.Enabled = False
                dgvVoucherDetails.Visible = True
                DatePickerVoucherLinkDate.Value = InstitutionMasterData.XDate
                DatePickerVoucherLinkDate.Enabled = True
                dgvVoucherDetails.Enabled = True
                Me.pnlConfirm.Visible = True

                Me.Text = Me.Text.Split("(")(0).Trim() + " (Operation: Add New)"

            Case "edit"
                txtLinkVoucherNumber.Enabled = True

                If VoucherType = "J" Then
                    TextBoxNarration.Enabled = False
                End If
                SplitContainer1.Panel2Collapsed = False
                panelVoucherControls.Visible = False

                DatePickerVoucherLinkDate.Visible = False
                LabelVoucherDate.Visible = False

                panelVoucherControls.Enabled = True
                dgvVoucherDetails.Enabled = True
                ComboBoxDaybookSelect.Enabled = False

                Me.Text = Me.Text.Split("(")(0).Trim() + " (Operation: Edit)"
            Case String.Empty
                Me.Text = Me.Text.Split("(")(0).Trim() + " (Please select operation to be performed)"
            Case "clear"
                Me.Text = Me.Text.Split("(")(0).Trim() + " (Please select operation to be performed)"
        End Select
    End Sub

    Sub SetOperationMode(ByVal pMode As String)
        _mode = pMode
    End Sub

    Private Function BindVoucherDetails() As String
        Dim helper As VoucherHelper = New VoucherHelper()

        Dim voucherHeader As VoucherHeader
        Dim dtVoucherDetails As DataTable = Nothing
        Dim dayBookCode As String
        Dim flgEnable As String = String.Empty
        Try
            dayBookCode = ComboBoxDaybookSelect.SelectedValue.ToString()
            voucherHeader = Nothing
            helper.GetVoucherHeader(TransactionType, dayBookCode, txtLinkVoucherNumber.Text.Trim.PadLeft(12, "0"), voucherHeader, dtVoucherDetails)

            If VoucherType = "J" Then
                If dtVoucherDetails IsNot Nothing Then

                    dgvVoucherDetails.DataSource = dtVoucherDetails

                    If dtVoucherDetails IsNot Nothing And dtVoucherDetails.Rows.Count > 0 Then
                        Dim dr As DataRow = dtVoucherDetails.Rows(0)

                        If dr("VD_VCH_Dt") IsNot Nothing And dr("VD_VCH_Dt") IsNot DBNull.Value And dr("VD_VCH_No") IsNot Nothing And dr("VD_VCH_No") IsNot DBNull.Value Then
                            If (_mode = "delete" Or _mode = "edit") Then
                                flgEnable = "Voucher is confirmed , modification/deletion not allowed"
                                Return flgEnable
                            ElseIf (_mode = "confirm") Then
                                flgEnable = "Voucher is already confirmed"
                                Return flgEnable
                            End If
                            pnlConfirm.Enabled = False
                            datepickerVoucherDateConfirm.Format = DateTimePickerFormat.Short
                            datepickerVoucherDateConfirm.CustomFormat = "dd-mm-yyyy"
                            datepickerVoucherDateConfirm.Value = dr("VD_VCH_Dt").ToString()
                            datepickerVoucherDateConfirm.Enabled = False
                            lblConfirmNumber.Text = dr("VD_VCH_No").ToString()
                            lblConfirmNumber.BackColor = Color.Red
                            lblConfirmNumber.ForeColor = Color.White
                            lableVoucherStatus.Text = "Status: CONFIRMED"
                            lblConfirmedVoucherNumber.Visible = True
                        Else
                            lableVoucherStatus.Text = "Status: UN-CONFIRMED"
                            datepickerVoucherDateConfirm.Format = DateTimePickerFormat.Custom
                            datepickerVoucherDateConfirm.CustomFormat = " "
                        End If

                        lblConfirmedVoucherNumber.Text = dr("VD_VCH_Ref_No").ToString()
                        lblConfirmedVoucherNumber.BackColor = Color.Red
                        lblConfirmedVoucherNumber.ForeColor = Color.White
                        DatePickerVoucherLinkDate.Value = dr("VD_Lnk_Dt").ToString()

                        flgEnable = String.Empty

                    End If
                Else
                    flgEnable = "No matching Voucher Entry found"
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return flgEnable
    End Function

    Private Sub frmAddVoucher_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.parentForm.pnlNavigator.Visible = False
        Me.parentForm.pnlMenu.Visible = True
        Me.parentForm.MenuVisibility = True
        Me.parentForm.lblBankBalance.Text = String.Empty
        Me.parentForm.lblBankBalance.Visible = False
    End Sub

    Private Sub ComboBoxDaybookSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxDaybookSelect.SelectedIndexChanged
        If ComboBoxDaybookSelect.SelectedValue IsNot Nothing Then
            If TypeOf ComboBoxDaybookSelect.SelectedValue Is DataRowView Then
                ledgerAccBalance = ledgerAcc.GetBalance(pDaybookcode:=DirectCast(ComboBoxDaybookSelect.SelectedValue, DataRowView).Row("DM_Dbk_Cd").ToString)
                lblDbkNm.Text = DirectCast(ComboBoxDaybookSelect.SelectedValue, DataRowView).Row("DM_Dbk_Nm").ToString()
            Else
                ledgerAccBalance = ledgerAcc.GetBalance(pDaybookcode:=ComboBoxDaybookSelect.SelectedValue.ToString)
            End If

            parentForm.pnlNavigator.Enabled = True
            parentForm.DisableNavToolBar(frmFAMSMain.NavSettings.Voucher)

            parentForm.lblBankBalance.Text = String.Format("Bank Balance : {0}", ledgerAccBalance)
        Else
            parentForm.pnlNavigator.Enabled = False
        End If
    End Sub

    Private rowIndex As Integer = 0
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Not dgvVoucherDetails.Rows(Me.rowIndex).IsNewRow Then
            dgvVoucherDetails.Rows.RemoveAt(Me.rowIndex)
        End If
    End Sub

    Private Sub dgvVoucherDetails_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvVoucherDetails.CellMouseUp
        If e.Button = MouseButtons.Right Then
            dgvVoucherDetails.Rows(e.RowIndex).Selected = True
            rowIndex = e.RowIndex
            dgvVoucherDetails.CurrentCell = dgvVoucherDetails.Rows(e.RowIndex).Cells(1)
            VoucherDetailsDeleteMenu.Show(dgvVoucherDetails, e.Location)
            VoucherDetailsDeleteMenu.Show(Cursor.Position)
        End If
    End Sub

    Public Sub PrintVoucher()
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        Dim objfrmVoucherPrintReport As New frmVoucherPrintReport
        objfrmVoucherPrintReport.parentForm = frmMain
        objfrmVoucherPrintReport.SetControls("Voucher", txtLinkVoucherNumber.Text, ComboBoxDaybookSelect.SelectedValue, TransactionType, ComboBoxDaybookSelect.Text)
        frmMain.ShowNewForm(objfrmVoucherPrintReport, Nothing)
    End Sub

    Public Sub PrintJournalVoucher()
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        Dim objfrmVoucherPrintReport As New frmVoucherPrintReport
        objfrmVoucherPrintReport.parentForm = frmMain
        objfrmVoucherPrintReport.SetControls("JournalVoucher", txtLinkVoucherNumber.Text, ComboBoxDaybookSelect.SelectedValue, TransactionType, ComboBoxDaybookSelect.Text)
        frmMain.ShowNewForm(objfrmVoucherPrintReport, Nothing)
    End Sub

End Class