Public Class frmAddVoucher
    Private _Voucher_Type As String
    Private _PayeeReceipt As String
    Private _TrnType As String
    Private _mode As String

    Private ledgerAcc As LedgerAccountHelper
    Private parentForm As frmFAMSMain
    Private ledgerAccBalance As Double
    Dim firsttime As Boolean = False
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
        Set(value As String)
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

    Public WriteOnly Property MDIForm As frmFAMSMain
        Set(ByVal Value As frmFAMSMain)
            parentForm = Value
        End Set
    End Property

    Private lastVoucherDateValue As DateTime = InstitutionMasterData.XDate

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ledgerAcc = New LedgerAccountHelper

        AddHandler txtLinkVoucherNumber.LostFocus, AddressOf txtLinkVoucherNumber_LostFocus

        '        AddHandler DatePickerVoucherDate.ValueChanged, AddressOf DateTimeReferenceDate_ValueChanged


    End Sub

    Private Sub txtLinkVoucherNumber_LostFocus(sender As Object, args As EventArgs)
        If _mode IsNot Nothing Then

            If _mode.ToLower() = "edit" Or _mode.ToLower() = "delete" Or _mode = "confirm" Then
                If txtLinkVoucherNumber.Text <> String.Empty Then

                    'populate voucher details
                    If BindVoucherDetails() Then
                        Select Case _mode
                            Case "view"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Me.DatePickerVoucherDate.Visible = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False
                                Me.DatePickerVoucherDate.Enabled = False

                            Case "delete"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                txtLinkVoucherNumber.Enabled = False
                                Me.DatePickerVoucherDate.Visible = True
                                Me.DatePickerVoucherDate.Enabled = False
                                LabelVoucherDate.Visible = True


                            Case "edit"
                                Me.panelVoucherControls.Visible = True
                                Me.dgvVoucherDetails.Visible = True
                                Me.DatePickerVoucherDate.Visible = True
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Me.DatePickerVoucherDate.Visible = True
                                Me.DatePickerVoucherDate.Enabled = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False

                            Case "confirm"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Dim vHelper As VoucherHelper = New VoucherHelper()
                                Dim dt As DataTable = vHelper.GetNextVoucherNumber(datepickerVoucherConfirm.Value.Month, ComboBoxDaybookSelect.SelectedValue)
                                If Not dt Is Nothing Then
                                    If dt.Rows.Count > 0 Then
                                        lblConfirmNumber.Text = String.Format(_TrnType + "-{0}", dt.Rows(0)(0).ToString())
                                        lblConfirmNumber.BackColor = Color.Red
                                        lblConfirmNumber.ForeColor = Color.White
                                        txtNextCount.Text = dt.Rows(0)(1).ToString()
                                    End If
                                End If
                                txtLinkVoucherNumber.Enabled = False
                                DatePickerVoucherDate.Visible = True
                                DatePickerVoucherDate.Enabled = False
                                Me.pnlConfirm.Visible = True
                                Me.pnlConfirm.Enabled = True
                                Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
                                frmMain.toolstripSave.Enabled = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False

                        End Select
                    End If

                End If
            End If

        End If

    End Sub

    Public Sub SetControlsForEdit()

    End Sub

    Public Sub ClearControls()
        txtLinkVoucherNumber.Text = String.Empty
        txtRefNumber.Text = String.Empty
        TextBoxChequeNo.Text = String.Empty
        TextBoxNameOfPayee.Text = String.Empty
        TextBoxAmount.Text = String.Empty
        ComboBoxCreditDebit.SelectedIndex = 0
        lblConfirmedVoucherNumber.Text = String.Empty
        pnlConfirm.Visible = False
        panelVoucherControls.Visible = False
        SplitContainer1.Panel2Collapsed = True
        SplitContainer1.Panel1Collapsed = False

        If _mode IsNot Nothing Then
            If _mode.ToLower() = "clear" Then
                ComboBoxDaybookSelect.Enabled = True
                ButtonNext.Enabled = True

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


    Private Sub frmAddVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(VoucherType) Then
            parentForm.pnlNavigator.Visible = True
            parentForm.pnlMenu.Visible = False
            parentForm.pnlNavigator.Enabled = False
            ComboBoxDaybookSelect.Enabled = True
            ButtonNext.Enabled = True
            Dim dbHelper As DayBooksHelper = New DayBooksHelper()
            Dim dt As DataTable = dbHelper.GetDaybooksByType(VoucherType)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    ComboBoxDaybookSelect.DataSource = dt
                    ComboBoxDaybookSelect.DisplayMember = "DM_Dbk_Nm"
                    ComboBoxDaybookSelect.ValueMember = "DM_Dbk_Cd"
                    ComboBoxDaybookSelect.SelectedIndex = 0
                Else
                    MessageBox.Show("There are no daybooks configured for this transaction type , please configure the daybooks", "Configuration Help",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ButtonNext.Enabled = False
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(PaymentReceipt) Then
            If PaymentReceipt = "P" Then
                LabelNameOfPayee.Text = "Name of Payee"
                ComboBoxCreditDebit.Items.Add("Cr")
                ComboBoxCreditDebit.SelectedIndex = 0
            ElseIf PaymentReceipt = "R" Then
                LabelNameOfPayee.Text = "Received from"
                ComboBoxCreditDebit.Items.Add("Dr")
                ComboBoxCreditDebit.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        'SplitContainer1.Panel1Collapsed = True
        'SplitContainer1.Panel2Collapsed = False
        'panelVoucherControls.Visible = False
        'LabelVoucherDate.Visible = False
        'DatePickerVoucherDate.Visible = False
        'parentForm.pnlNavigator.Visible = True
        'parentForm.pnlNavigator.Enabled = True
        'parentForm.DisableNavToolBar(frmFAMSMain.NavSettings.Voucher)
        'ComboBoxDaybookSelect.Enabled = False
        'ButtonNext.Enabled = False

    End Sub

    Private Sub ConfirmVoucher()
        Dim helper As VoucherHelper = New VoucherHelper()
        Dim validate As New ValidateClass
        Dim calculateDiff As Boolean = True
        Try
            If _TrnType.Equals("BP") Or _TrnType.Equals("CP") Then
                calculateDiff = validate.CheckBalance(ledgerAccBalance, Double.Parse(TextBoxAmount.Text))
            End If
            If calculateDiff Then
                If (Not String.IsNullOrEmpty(ComboBoxDaybookSelect.SelectedValue) And Not String.IsNullOrEmpty(txtLinkVoucherNumber.Text)) Then
                    helper.ConfirmVoucher(ComboBoxDaybookSelect.SelectedValue, txtLinkVoucherNumber.Text, Convert.ToDateTime(datepickerVoucherConfirm.Value.ToString()), lblConfirmNumber.Text.Split("-")(1).Trim(), txtNextCount.Text)
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

    Public Function SaveVoucher() As Boolean


        Dim mandatoryFields As String = String.Empty

        Try
            If Me._mode.ToLower() = "delete" Then
                Dim dlgResult As DialogResult = MessageBox.Show("Are you sure you want to delete this voucher?", "Delete?", MessageBoxButtons.YesNo)
                If (dlgResult = Windows.Forms.DialogResult.Yes) Then
                    DeleteVoucher()
                    Return True
                Else
                    Return False
                End If
            End If

            If Me._mode.ToLower() = "confirm" Then

                If String.IsNullOrEmpty(datepickerVoucherConfirm.Value) Then
                    MessageBox.Show("Please enter voucher confirmation date ", "", MessageBoxButtons.OK)
                    Return False
                Else
                    If datepickerVoucherConfirm.Value.CompareTo(DatePickerVoucherDate.Value.Date) < 0 Then
                        MessageBox.Show("Voucher Confirm date cannot be lesser than link voucher date ", "", MessageBoxButtons.OK)
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


            End If





            If txtRefNumber.Text = String.Empty Then
                mandatoryFields = "Reference Number"
            End If

            If DateTimeReferenceDate.Value.ToString() = String.Empty Then
                mandatoryFields += "   Reference Date"
            End If

            If VoucherType = "B" Then
                If TextBoxChequeNo.Text = String.Empty Then
                    mandatoryFields += "  Cheque Number"
                End If
                If datepickerChequeDate.Value.ToString() = String.Empty Then
                    mandatoryFields += "  Cheque date"
                End If

            End If

            If TextBoxAmount.Text = String.Empty Then
                mandatoryFields += " Amount"
            End If

            Dim crdr As Boolean = False

            If Not ComboBoxCreditDebit.SelectedItem = Nothing Then
                If Not ComboBoxCreditDebit.SelectedItem = String.Empty Then
                    crdr = True
                End If
            End If

            If Not crdr Then
                mandatoryFields += "Credit/Debit"

            End If

            If Not mandatoryFields = String.Empty Then
                MessageBox.Show(mandatoryFields + " are compulsory for saving voucher")
                Return False
            Else
                If BalanceValidation() Then
                    Dim header As VoucherHeader = New VoucherHeader()
                    header.VH_Inst_Cd = InstitutionMasterData.XInstCode
                    header.VH_Inst_Typ = InstitutionMasterData.XInstType
                    header.VH_Fin_Yr = InstitutionMasterData.XFinYr
                    header.VH_Lnk_No = txtLinkVoucherNumber.Text
                    header.VH_Lnk_Dt = DatePickerVoucherDate.Value
                    header.VH_Pty_Nm = TextBoxNameOfPayee.Text
                    header.VH_Ref_No = txtRefNumber.Text
                    header.VH_Ref_Dt = DateTimeReferenceDate.Value
                    header.VH_Cr_Dr = ComboBoxCreditDebit.SelectedItem.ToString()
                    header.VH_ABS_Amt = Decimal.Parse(TextBoxAmount.Text)
                    header.VH_Amt = IIf(ComboBoxCreditDebit.SelectedItem = "Dr", Decimal.Parse(TextBoxAmount.Text), Decimal.Parse(TextBoxAmount.Text) * -1)
                    header.VH_Dbk_Cd = ComboBoxDaybookSelect.SelectedValue
                    header.VH_Trn_Typ = TransactionType
                    If datepickerChequeDate.Enabled Then
                        header.VH_Chq_No = TextBoxChequeNo.Text
                        header.VH_Chq_Dt = datepickerChequeDate.Value
                    End If

                    header.VH_Acc_Cd = DirectCast(ComboBoxDaybookSelect.Items(ComboBoxDaybookSelect.SelectedIndex), DataRowView)("DM_Acc_Cd").ToString()
                    header.VH_Lgr_Cd = "00"
                    header.VH_Brn_Cd = ""
                    Dim instMaster As InstitutionMasterData = New InstitutionMasterData()
                    Dim vchRefNo As Int64 = instMaster.GetNextInstitutionVoucherReferenceNumber()
                    header.VH_VCH_Ref_No = vchRefNo.ToString().PadLeft(6, "0")

                    Dim helper As VoucherHelper = New VoucherHelper()
                    helper.SaveVoucherHeader(header)

                    Dim i As Integer = 0
                    For Each dgRows As DataGridViewRow In dgvVoucherDetails.Rows
                        If Not dgRows.Cells("DebitCr").Value = String.Empty And Not dgRows.Cells("Amount").EditedFormattedValue = String.Empty And Not dgRows.Cells("LedgerAccount").Value = String.Empty Then
                            i = i + 1
                            Dim drcr As String = dgRows.Cells("DebitCr").Value
                            Dim amount As String = dgRows.Cells("Amount").EditedFormattedValue
                            Dim ledgerAccount As String = dgRows.Cells("LedgerAccount").EditedFormattedValue
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
                            voucherDetail.VD_Amt = IIf(drcr = "Cr", Decimal.Parse(amount), Decimal.Parse(amount) * -1)
                            voucherDetail.VD_Ref_No = txtRefNumber.Text
                            voucherDetail.VD_Ref_Dt = DateTimeReferenceDate.Value
                            voucherDetail.VD_Seq_No = i.ToString().PadLeft(3, "0")
                            voucherDetail.VD_Acc_Cd = ledgerAccount
                            voucherDetail.VD_Brn_Cd = ""
                            voucherDetail.VD_Ent_By = "TUser"
                            voucherDetail.VD_Vch_Ref_No = vchRefNo.ToString().PadLeft(6, "0")
                            helper.SaveVoucherDetail(voucherDetail)
                        End If
                    Next

                    If Me._mode = "add" Then
                        instMaster.UpdateLinkNumber(txtLinkVoucherNumber.Text.Trim(), vchRefNo, InstitutionMasterData.XInstCode)
                    End If
                Else
                    Return False
                End If
            End If
            ClearControls()
            Return True
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Function BalanceValidation() As Boolean
        Dim headerValue As Decimal
        Dim validate As New ValidateClass
        Dim calculateDiff As Boolean = True

        headerValue = Decimal.Parse(TextBoxAmount.Text)

        If _TrnType.Equals("BP") Or _TrnType.Equals("CP") Then
            calculateDiff = validate.CheckBalance(ledgerAccBalance, headerValue)
        End If

        If calculateDiff Then
            If ComboBoxCreditDebit.SelectedItem = "Cr" Then
                headerValue = headerValue * -1
            End If

            Dim detailValues As Decimal

            For Each dgvrow As DataGridViewRow In dgvVoucherDetails.Rows
                If Not dgvrow.Cells("DebitCr").Value = String.Empty And Not dgvrow.Cells("Amount").EditedFormattedValue = String.Empty Then
                    Dim rowDecimal As Decimal
                    rowDecimal = Decimal.Parse(dgvrow.Cells("Amount").EditedFormattedValue)
                    If dgvrow.Cells("DebitCr").Value = "Cr" Then
                        rowDecimal = rowDecimal * -1
                    End If

                    detailValues += rowDecimal
                End If

            Next

            Dim amount As Decimal = headerValue + detailValues

            If amount <> 0 Then
                MessageBox.Show("Amount is not balanced, difference of " + amount.ToString())
                Return False
            End If

            Return True
        Else
            MessageBox.Show("Insufficient balance, cannot add the voucher!!", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

    Private Sub DateTimeReferenceDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimeReferenceDate.ValueChanged
        Dim validate As New ValidateClass
        Dim errMessage As String = String.Empty
        Dim datetimePicker As DateTimePicker
        Dim VoucherDate As DateTimePicker
        Try
            If Not _mode = "view" Then
                datetimePicker = DirectCast(sender, DateTimePicker)
                VoucherDate = DirectCast(DatePickerVoucherDate, DateTimePicker)
                If Not validate.CheckReferenceDate(datetimePicker.Value, errMessage, VoucherDate.Value) Then
                    MessageBox.Show(errMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    datetimePicker.Value = lastVoucherDateValue
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DateTimeReferenceDate_CloseUp(sender As Object, e As EventArgs) Handles DateTimeReferenceDate.CloseUp
        Dim datetimePicker As DateTimePicker
        datetimePicker = DirectCast(sender, DateTimePicker)
        Call DateTimeReferenceDate_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub DateTimeReferenceDate_DropDown(sender As Object, e As EventArgs) Handles DateTimeReferenceDate.DropDown
        Dim datetimePicker As DateTimePicker
        datetimePicker = DirectCast(sender, DateTimePicker)
        ' RemoveHandler datetimePicker.ValueChanged, AddressOf DateTimeReferenceDate_ValueChanged
    End Sub

    Private Sub DatePickerVoucherDate_ValueChanged(sender As Object, e As EventArgs) Handles DatePickerVoucherDate.ValueChanged
        Dim validate As New ValidateClass
        Dim errMessage As String = String.Empty
        Dim datetimePicker As DateTimePicker
        Dim ReferenceDate As DateTimePicker = DirectCast(DateTimeReferenceDate, DateTimePicker)
        Try
            If Not _mode = "view" Then
                datetimePicker = DirectCast(sender, DateTimePicker)

                If Not firsttime Then

                    If validate.CheckVoucherDate(datetimePicker.Value, errMessage) Then
                        lastVoucherDateValue = datetimePicker.Value
                        If _mode = "add" Or _mode = "edit" Then
                            If Not validate.CheckReferenceDate(ReferenceDate.Value, errMessage, datetimePicker.Value) Then
                                MessageBox.Show(errMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                DateTimeReferenceDate.Value = lastVoucherDateValue
                            End If
                        End If
                    Else
                        MessageBox.Show(errMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        datetimePicker.Value = lastVoucherDateValue
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DatePickerVoucherDate_DropDown(sender As Object, e As EventArgs) Handles DatePickerVoucherDate.DropDown
        Dim datetimePicker As DateTimePicker
        datetimePicker = DirectCast(sender, DateTimePicker)
        RemoveHandler datetimePicker.ValueChanged, AddressOf DatePickerVoucherDate_ValueChanged
    End Sub

    Private Sub DatePickerVoucherDate_CloseUp(sender As Object, e As EventArgs) Handles DatePickerVoucherDate.CloseUp
        Dim datetimePicker As DateTimePicker
        datetimePicker = DirectCast(sender, DateTimePicker)
        AddHandler DatePickerVoucherDate.ValueChanged, AddressOf DatePickerVoucherDate_ValueChanged
        Call DatePickerVoucherDate_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub dgvVoucherDetails_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvVoucherDetails.EditingControlShowing
        If dgvVoucherDetails.Columns(dgvVoucherDetails.CurrentCell.ColumnIndex).Name = "LedgerAccount" Then
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            AddHandler tb.KeyDown, AddressOf dataGridViewTextBox_KeyDown
            AddHandler tb.Validating, AddressOf dataGridViewTextBox_Validating
        End If

        If dgvVoucherDetails.Columns(dgvVoucherDetails.CurrentCell.ColumnIndex).Name = "Amount" Then
            Dim tb As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            AddHandler tb.KeyPress, AddressOf Amount_KeyPress
        End If


    End Sub

    Private Sub dataGridViewTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
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

    Private Sub dataGridViewTextBox_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.F2 And Not e.Handled Then
            Dim helper As popupHelper = New popupHelper(0)
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

    Private Sub dgvVoucherDetails_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVoucherDetails.RowEnter
        dgvVoucherDetails.Rows(e.RowIndex).Cells("RefNo").Value = txtRefNumber.Text
        dgvVoucherDetails.Rows(e.RowIndex).Cells("RefDate").Value = DateTimeReferenceDate.Value.ToShortDateString()

        If Not String.IsNullOrEmpty(PaymentReceipt) Then
            If PaymentReceipt = "P" Then
                dgvVoucherDetails.Rows(e.RowIndex).Cells("DebitCr").Value = "Dr"
            ElseIf PaymentReceipt = "R" Then
                dgvVoucherDetails.Rows(e.RowIndex).Cells("DebitCr").Value = "Cr"
            End If
        End If

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

    Private Sub TextBoxAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxAmount.KeyPress
        If IsDecimal(e, TextBoxAmount) Then
            Return
        End If
        e.Handled = True
    End Sub

    Private Sub Amount_KeyPress(sender As Object, e As KeyPressEventArgs)
        If dgvVoucherDetails.Columns(dgvVoucherDetails.CurrentCell.ColumnIndex).Name = "Amount" And Not e.Handled Then
            If IsDecimal(e, sender) Then
                Return
            Else
                e.Handled = True
            End If
        End If

    End Sub

    Sub SetControls(pMode As String)
        Select Case _mode
            Case "view"
                'Me.SplitContainer1.Panel1Collapsed = True
                Me.SplitContainer1.Panel2Collapsed = False
                Me.panelVoucherControls.Visible = False
                Me.LabelVoucherDate.Visible = False
                Me.DatePickerVoucherDate.Visible = False
                Me.txtLinkVoucherNumber.Visible = True
                Me.Label1.Visible = True
                Me.dgvVoucherDetails.Visible = False
                Me.txtLinkVoucherNumber.Enabled = True
                Me.pnlConfirm.Visible = False
                ComboBoxDaybookSelect.Enabled = False
                ButtonNext.Enabled = False


            Case "confirm"
                'Me.SplitContainer1.Panel1Collapsed = True
                Me.SplitContainer1.Panel2Collapsed = False
                Me.panelVoucherControls.Visible = False
                Me.LabelVoucherDate.Visible = False
                Me.DatePickerVoucherDate.Visible = False
                Me.txtLinkVoucherNumber.Visible = True
                Me.Label1.Visible = True
                Me.dgvVoucherDetails.Visible = False
                Me.txtLinkVoucherNumber.Enabled = True
                Me.pnlConfirm.Visible = False
                ComboBoxDaybookSelect.Enabled = False
                ButtonNext.Enabled = False
                DatePickerVoucherDate.Visible = False
                LabelVoucherDate.Visible = False
                ComboBoxDaybookSelect.Enabled = False


            Case "delete"
                ' Me.SplitContainer1.Panel1Collapsed = True
                Me.SplitContainer1.Panel2Collapsed = False
                Me.panelVoucherControls.Visible = False
                Me.LabelVoucherDate.Visible = False
                Me.DatePickerVoucherDate.Visible = False
                Me.txtLinkVoucherNumber.Visible = True
                Me.Label1.Visible = True
                Me.dgvVoucherDetails.Visible = False
                Me.txtLinkVoucherNumber.Enabled = True
                Me.pnlConfirm.Visible = False
                ComboBoxDaybookSelect.Enabled = False
                ButtonNext.Enabled = False

            Case "add"
                Dim instMaster As InstitutionMasterData = New InstitutionMasterData()
                txtLinkVoucherNumber.Text = instMaster.GetNextInstitutionLinkNumber().ToString().PadLeft(12, "0")
                txtLinkVoucherNumber.Enabled = False
                If VoucherType = "B" Then
                    TextBoxChequeNo.Enabled = True
                    datepickerChequeDate.Enabled = True
                Else
                    TextBoxChequeNo.Enabled = False
                    datepickerChequeDate.Enabled = False

                End If
                SplitContainer1.Panel2Collapsed = False
                lastVoucherDateValue = DatePickerVoucherDate.Value
                panelVoucherControls.Visible = True
                panelVoucherControls.Enabled = True
                ComboBoxDaybookSelect.Enabled = False
                dgvVoucherDetails.Visible = True
                firsttime = True
                DatePickerVoucherDate.Value = InstitutionMasterData.XDate
                DateTimeReferenceDate.Value = InstitutionMasterData.XDate
                datepickerChequeDate.Value = InstitutionMasterData.XDate
                firsttime = False

            Case "edit"
                txtLinkVoucherNumber.Enabled = True
                If VoucherType = "B" Then
                    TextBoxChequeNo.Enabled = True
                    datepickerChequeDate.Enabled = True
                Else
                    TextBoxChequeNo.Enabled = False
                    datepickerChequeDate.Enabled = False

                End If
                SplitContainer1.Panel2Collapsed = False
                panelVoucherControls.Visible = False
                DatePickerVoucherDate.Visible = False
                LabelVoucherDate.Visible = False
                panelVoucherControls.Enabled = True
                dgvVoucherDetails.Enabled = True
                ComboBoxDaybookSelect.Enabled = False

        End Select
    End Sub

    Sub SetOperationMode(pMode As String)
        _mode = pMode
        ' ClearControls()

    End Sub



    Private Sub txtLinkVoucherNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLinkVoucherNumber.KeyDown
        Try
            Select Case e.KeyCode
                Case (Keys.Enter)
                    If BindVoucherDetails() Then
                        Select Case _mode
                            Case "view"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Me.DatePickerVoucherDate.Visible = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False
                                Me.DatePickerVoucherDate.Enabled = False

                            Case "delete"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                txtLinkVoucherNumber.Enabled = False
                                Me.DatePickerVoucherDate.Visible = True
                                Me.DatePickerVoucherDate.Enabled = False
                                LabelVoucherDate.Visible = True


                            Case "edit"
                                Me.panelVoucherControls.Visible = True
                                Me.dgvVoucherDetails.Visible = True
                                Me.DatePickerVoucherDate.Visible = True
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Me.DatePickerVoucherDate.Visible = True
                                Me.DatePickerVoucherDate.Enabled = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False

                            Case "confirm"
                                Me.panelVoucherControls.Visible = True
                                Me.panelVoucherControls.Enabled = False
                                Me.dgvVoucherDetails.Visible = True
                                Me.dgvVoucherDetails.Enabled = False
                                txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                                Dim vHelper As VoucherHelper = New VoucherHelper()
                                Dim dt As DataTable = vHelper.GetNextVoucherNumber(datepickerVoucherConfirm.Value.Month, ComboBoxDaybookSelect.SelectedValue)
                                If Not dt Is Nothing Then
                                    If dt.Rows.Count > 0 Then
                                        lblConfirmNumber.Text = String.Format(_TrnType + "-{0}", dt.Rows(0)(0).ToString())
                                        lblConfirmNumber.BackColor = Color.Red
                                        lblConfirmNumber.ForeColor = Color.White
                                        txtNextCount.Text = dt.Rows(0)(1).ToString()
                                    End If
                                End If
                                txtLinkVoucherNumber.Enabled = False
                                DatePickerVoucherDate.Visible = True
                                DatePickerVoucherDate.Enabled = False
                                Me.pnlConfirm.Visible = True
                                Me.pnlConfirm.Enabled = True
                                Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
                                frmMain.toolstripSave.Enabled = True
                                LabelVoucherDate.Visible = True
                                txtLinkVoucherNumber.Enabled = False

                        End Select
                    Else
                        Me.panelVoucherControls.Visible = False
                        'Me.dgvVoucherDetails.Enabled = False
                    End If
                Case Keys.F2
                    Dim helper As popupHelper = New popupHelper(1)
                    helper.TransType = TransactionType
                    helper.dbkCode = ComboBoxDaybookSelect.SelectedValue.ToString()
                    helper.currentMode = Me._mode
                    helper.ShowDialog()
                    txtLinkVoucherNumber.Text = helper.selectedCode
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Function BindVoucherDetails() As Boolean
        Dim helper As VoucherHelper = New VoucherHelper()

        Dim voucherHeader As VoucherHeader
        Dim dtVoucherDetails As DataTable = Nothing
        Dim dayBookCode As String
        Dim flgEnable As Boolean = False
        Try
            dayBookCode = ComboBoxDaybookSelect.SelectedValue.ToString()
            voucherHeader = Nothing
            helper.GetVoucherHeader(TransactionType, dayBookCode, txtLinkVoucherNumber.Text.Trim.PadLeft(12, "0"), voucherHeader, dtVoucherDetails)
            If voucherHeader IsNot Nothing Then

                If (voucherHeader.VH_VCH_Dt IsNot Nothing And voucherHeader.VH_VCH_NO IsNot Nothing) Then
                    Select Case _mode
                        Case "delete", "edit"
                            MessageBox.Show("Voucher is confirmed , no modification/deletion not allowed")
                            Return False
                        Case "view"
                            lblConfirmNumber.BackColor = Color.Red
                            lblConfirmNumber.ForeColor = Color.White
                    End Select
                    pnlConfirm.Visible = True
                    pnlConfirm.Enabled = False
                    datepickerVoucherConfirm.Value = voucherHeader.VH_VCH_Dt
                    lblConfirmNumber.Text = String.Format("{0}-{1}", _TrnType, voucherHeader.VH_VCH_NO)
                    lblConfirmedVoucherNumber.Text = voucherHeader.VH_VCH_Ref_No.ToString()
                    lblConfirmedVoucherNumber.BackColor = Color.Red
                    lblConfirmedVoucherNumber.ForeColor = Color.White

                End If

                If _mode.ToLower() = "confirm" Then
                    lblConfirmedVoucherNumber.Text = voucherHeader.VH_VCH_Ref_No.ToString()
                    lblConfirmedVoucherNumber.BackColor = Color.Red
                    lblConfirmedVoucherNumber.ForeColor = Color.White
                End If


                txtRefNumber.Text = voucherHeader.VH_Ref_No
                DatePickerVoucherDate.Value = voucherHeader.VH_Lnk_Dt
                DateTimeReferenceDate.Value = voucherHeader.VH_Ref_Dt
                TextBoxChequeNo.Text = voucherHeader.VH_Chq_No
                datepickerChequeDate.Value = voucherHeader.VH_Chq_Dt
                TextBoxNameOfPayee.Text = voucherHeader.VH_Pty_Nm
                TextBoxAmount.Text = voucherHeader.VH_ABS_Amt.ToString
                'ComboBoxCreditDebit.SelectedItem = voucherHeader.VH_Cr_Dr
                flgEnable = True

                If dtVoucherDetails IsNot Nothing Then
                    dgvVoucherDetails.DataSource = dtVoucherDetails

                End If
            Else
                MessageBox.Show("No matching Voucher Entry found")
            End If



        Catch ex As Exception
            Throw ex
        End Try
        Return flgEnable
    End Function

    Private Sub frmAddVoucher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        ''frmMain.mainBindingNavigator.BindingSource = Nothing
        Me.parentForm.pnlNavigator.Visible = False
        Me.parentForm.pnlMenu.Visible = True
        Me.parentForm.MenuVisibility = True
        Me.parentForm.lblBankBalance.Text = String.Empty
        Me.parentForm.lblBankBalance.Visible = False
        ''frmMain.EnableNavToolBar()
    End Sub



    Private Sub ComboBoxDaybookSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDaybookSelect.SelectedIndexChanged
        If ComboBoxDaybookSelect.SelectedValue IsNot Nothing Then
            If TypeOf ComboBoxDaybookSelect.SelectedValue Is DataRowView Then
                ledgerAccBalance = ledgerAcc.GetBalance(pDaybookcode:=DirectCast(ComboBoxDaybookSelect.SelectedValue, DataRowView).Row("DM_Dbk_Cd").ToString)
                lblDbkNm.Text = DirectCast(ComboBoxDaybookSelect.SelectedValue, DataRowView).Row("DM_Dbk_Nm").ToString()
            Else
                ledgerAccBalance = ledgerAcc.GetBalance(pDaybookcode:=ComboBoxDaybookSelect.SelectedValue.ToString)
            End If

            parentForm.pnlNavigator.Enabled = True
            parentForm.DisableNavToolBar(frmFAMSMain.NavSettings.Voucher)
            'ComboBoxDaybookSelect.Enabled = False
            'ButtonNext.Enabled = False


            'If ComboBoxDaybookSelect.SelectedValue <> String.Empty Then
            '    parentForm.pnlNavigator.Enabled = True
            '    parentForm.DisableNavToolBar(frmFAMSMain.NavSettings.Voucher)
            '    ComboBoxDaybookSelect.Enabled = False
            '    ButtonNext.Enabled = False
            'Else

            '    parentForm.pnlNavigator.Enabled = False
            'End If


            parentForm.lblBankBalance.Text = String.Format("Bank Balance : {0}", ledgerAccBalance)
        Else
            parentForm.pnlNavigator.Enabled = False
        End If
    End Sub



    Private Sub datepickerVoucherConfirm_ValueChanged(sender As Object, e As EventArgs) Handles datepickerVoucherConfirm.ValueChanged
        Dim validate As New ValidateClass
        Dim errMessage As String = String.Empty
        Dim datetimePicker As DateTimePicker
        Dim VoucherDate As DateTimePicker = DirectCast(DatePickerVoucherDate, DateTimePicker)
        Try
            If Not _mode = "view" Then
                datetimePicker = DirectCast(sender, DateTimePicker)
                If validate.CheckConfirmationdate(datetimePicker.Value, errMessage, VoucherDate.Value) Then
                    lastVoucherDateValue = datetimePicker.Value
                Else
                    MessageBox.Show(errMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    datetimePicker.Value = lastVoucherDateValue
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub datepickerVoucherConfirm_CloseUp(sender As Object, e As EventArgs) Handles datepickerVoucherConfirm.CloseUp
        Dim datetimePicker As DateTimePicker
        datetimePicker = DirectCast(sender, DateTimePicker)
        AddHandler DatePickerVoucherDate.ValueChanged, AddressOf datepickerVoucherConfirm_ValueChanged
        Call datepickerVoucherConfirm_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub datepickerVoucherConfirm_DropDown(sender As Object, e As EventArgs) Handles datepickerVoucherConfirm.DropDown
        Dim datetimePicker As DateTimePicker
        datetimePicker = DirectCast(sender, DateTimePicker)
        RemoveHandler datetimePicker.ValueChanged, AddressOf datepickerVoucherConfirm_ValueChanged
    End Sub

    Private Sub TextBoxAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxAmount.Validating
        Dim calculateDiff As Boolean = True
        Dim validate As New ValidateClass()
        If _mode IsNot Nothing Then

            If _mode.ToLower() = "add" Or _mode.ToLower() = "edit" Then
                If _TrnType.Equals("BP") Or _TrnType.Equals("CP") Then

                    If TextBoxAmount.Text <> String.Empty Then
                        calculateDiff = validate.CheckBalance(ledgerAccBalance, Double.Parse(TextBoxAmount.Text))
                        If Not calculateDiff Then
                            MessageBox.Show("Insufficient Balance cannot save voucher !!!", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                End If
            End If
        End If

    End Sub

    Private Sub txtLinkVoucherNumber_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub datepickerChequeDate_ValueChanged(sender As Object, e As EventArgs) Handles datepickerChequeDate.ValueChanged
        Dim validate As New ValidateClass
        Dim datetimePicker As DateTimePicker
        Try
            If Not _mode = "view" Then
                datetimePicker = DirectCast(sender, DateTimePicker)
                If datetimePicker.Value.Date.CompareTo(InstitutionMasterData.XDate) > 0 Then
                    MessageBox.Show("Cheque date cannot be greater that processing date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    datetimePicker.Value = lastVoucherDateValue
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class