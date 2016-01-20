Public Class frmCashBankContraV
    Inherits Form
    Dim frmAddVoucher As frmAddVoucher
    Dim screenTitle As String = "Cash Bank Contra Voucher- {0}"
    Private frmParent As frmFAMSMain = Nothing
    Private ledgerAcc As LedgerAccountHelper
    Private daybookHelper As DayBooksHelper
    Private instMaster As InstitutionMasterData
    Private voucherHelper As VoucherHelper
    Private dtVoucherDetails As DataTable
    Private _mode As String
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ledgerAcc = New LedgerAccountHelper
        daybookHelper = New DayBooksHelper
        instMaster = New InstitutionMasterData
        voucherHelper = New VoucherHelper
    End Sub



    Public WriteOnly Property MDIForm() As frmFAMSMain
        Set(ByVal value As frmFAMSMain)
            frmParent = value
            frmParent.pnlNavigator.Visible = True
            frmParent.pnlMenu.Visible = False
            frmParent.pnlNavigator.Enabled = False
        End Set
    End Property


    Private Sub BindDaybooks()
        Dim dtGoesOut As DataTable = daybookHelper.GetDaybooksByType(String.Empty, True)
        Dim dtGoesIn As DataTable = Nothing
        Try
            If Not dtGoesOut Is Nothing Then
                dtGoesIn = dtGoesOut.Copy()
                If dtGoesOut.Rows.Count > 0 Then

                    ComboBoxGoesInto.DataSource = dtGoesIn
                    ComboBoxGoesInto.DisplayMember = "DisplayName"
                    ComboBoxGoesInto.ValueMember = "DM_Dbk_Cd"
                    ComboBoxGoesInto.SelectedIndex = -1

                    ComboBoxGoesOut.Enabled = True
                    ComboBoxGoesOut.DataSource = dtGoesOut
                    ComboBoxGoesOut.DisplayMember = "DisplayName"
                    ComboBoxGoesOut.ValueMember = "DM_Dbk_Cd"
                    ComboBoxGoesOut.SelectedIndex = -1


                Else
                    MessageBox.Show("There are no daybooks configured for this transaction type , please configure the daybooks", "Configuration Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ComboBoxGoesOut.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error Occurred!!!")
        End Try

    End Sub

    Private Sub FilterGoesIntoVals(ByVal pDayBookCode As String)
        Dim dtFilter As DataTable = Nothing
        If Not String.IsNullOrEmpty(pDayBookCode) Then
            dtFilter = DirectCast(ComboBoxGoesInto.DataSource, DataTable)
            If dtFilter IsNot Nothing Then
                dtFilter.DefaultView.RowFilter = String.Format("DM_Dbk_Cd <> '{0}'", pDayBookCode)
            End If
        End If
    End Sub

    Private Sub frmCashBankContraV_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        BindDaybooks()
    End Sub

    Private Sub ComboBoxGoesOut_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxGoesOut.SelectedValueChanged
        If ComboBoxGoesOut.SelectedValue IsNot Nothing And Not TypeOf (ComboBoxGoesOut.SelectedValue) Is DataRowView Then
            frmParent.pnlNavigator.Enabled = True
            frmParent.DisableNavToolBar(frmFAMSMain.NavSettings.Voucher)

            If ComboBoxGoesOut.SelectedValue IsNot Nothing Then
                FilterGoesIntoVals(ComboBoxGoesOut.SelectedValue.ToString())
            End If
        End If
    End Sub

    Public Sub SetControls(ByVal pMode As String)
        _mode = pMode
        lblStatus.Text = ""
        Try
            'ClearControls()
            Select Case _mode
                Case "add"

                    AddOperation()
                Case "edit"
                    UpdateOperation()
                Case "view"
                    ViewOperation()
                Case "clear"
                    ClearControls()
                Case "confirm"
                    EnableSearchVouchers()
                Case "delete"
                    DeleteOperation()
            End Select
        Catch ex As Exception
            MessageBox.Show("Error Occurred !!!")
        End Try

    End Sub

    Private Sub AddOperation()
        Try
            If Not ValidateClass.CheckComboxSelected(ComboBoxGoesOut.SelectedValue) Then
                ComboBoxGoesOut.Enabled = False
                SplitContainer1.Panel2Collapsed = False
                panelVoucherControls.Visible = True
                DatePickerVoucherDate.Visible = True
                LabelVoucherDate.Visible = True
                txtLinkVoucherNumber.Text = instMaster.GetNextInstitutionLinkNumber().ToString().PadLeft(12, "0")
                txtLinkVoucherNumber.Enabled = False
                DatePickerVoucherDate.Value = InstitutionMasterData.XDate
                CheckDaybookType(ComboBoxGoesOut.SelectedItem)

            Else
                MessageBox.Show("Please Select a Daybook!!!")
            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub UpdateOperation()
        EnableSearchVouchers()
    End Sub

    Private Sub ViewOperation()
        EnableSearchVouchers()
    End Sub

    Private Sub CheckDaybookType(ByVal pDayBook As DataRowView)
        Dim daybookType As String
        Dim bankBalance As String
        Try
            If pDayBook IsNot Nothing Then
                daybookType = pDayBook.Row("DM_Dbk_Typ").ToString()
                Select Case daybookType
                    Case "B"
                        TextBoxChequeNo.Enabled = True
                        datepickerChequeDate.Enabled = True
                        frmParent.lblBankBalance.Visible = True
                        bankBalance = ledgerAcc.GetBalance(pDaybookcode:=pDayBook.Row("DM_Dbk_Cd").ToString)
                        frmParent.lblBankBalance.Text = String.Format("Bank Balance : {0}", bankBalance)
                    Case "C"
                        TextBoxChequeNo.Enabled = False
                        datepickerChequeDate.Enabled = False
                        frmParent.lblBankBalance.Visible = False
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearControls()
        TextBoxChequeNo.Text = String.Empty
        TextBoxAmount.Text = String.Empty
        txtLinkVoucherNumber.Text = String.Empty
        pnlConfirm.Visible = True
        pnlConfirm.Enabled = False
        panelVoucherControls.Enabled = True
        TextBoxChequeNo.Enabled = True
        ComboBoxGoesInto.Enabled = True
        TextBoxAmount.Enabled = True
        datepickerChequeDate.Enabled = True
        TextBoxNameOfPayee.Enabled = True
        SplitContainer1.Panel2Collapsed = True
        ComboBoxGoesOut.Enabled = True
        TextBoxNameOfPayee.Text = String.Empty
        frmParent.toolstripSave.Enabled = False
        lblVoucherConfNo.Text = "-"
        lblVoucherConfNo.BackColor = Color.Transparent
        lblConfirmedVoucherNumber.Text = "-"
        lblConfirmedVoucherNumber.BackColor = Color.Transparent

    End Sub

    Private Sub DeleteOperation()
        EnableSearchVouchers()
    End Sub

    Private Sub EnableSearchVouchers()
        If Not ValidateClass.CheckComboxSelected(ComboBoxGoesOut.SelectedValue) Then
            Me.ComboBoxGoesOut.Enabled = False
            Me.SplitContainer1.Panel2Collapsed = False
            panelVoucherControls.Visible = False
            txtLinkVoucherNumber.Visible = True
            txtLinkVoucherNumber.Enabled = True
            txtLinkVoucherNumber.Focus()
            LabelVoucherDate.Visible = False
            DatePickerVoucherDate.Visible = False
            CheckDaybookType(ComboBoxGoesOut.SelectedItem)
        Else
            MessageBox.Show("Please Select a Daybook!!!")
        End If
    End Sub

    Private Function BindVoucherDetails() As Boolean
        Dim helper As VoucherHelper = New VoucherHelper()

        Dim voucherHeader As VoucherHeader
        Dim dtVoucherDetails As DataTable = Nothing
        Dim dayBookCode As String
        Dim flgEnable As Boolean = False
        Try
            dayBookCode = ComboBoxGoesOut.SelectedValue.ToString()
            voucherHeader = Nothing
            helper.GetVoucherHeader("CT", dayBookCode, txtLinkVoucherNumber.Text.Trim.PadLeft(12, "0"), voucherHeader, dtVoucherDetails)
            If voucherHeader IsNot Nothing Then

                If (voucherHeader.VH_VCH_Dt IsNot Nothing And voucherHeader.VH_VCH_NO IsNot Nothing) Then
                    Select Case _mode
                        Case "delete", "edit"
                            MessageBox.Show("Voucher is confirmed, no modification/deletion not allowed")
                            Return False
                        Case "view"
                            lblVoucherConfNo.BackColor = Color.Red
                    End Select
                    pnlConfirm.Visible = True
                    pnlConfirm.Enabled = True
                    datepickerVoucherConfirm.Value = voucherHeader.VH_VCH_Dt
                    lblVoucherConfNo.Text = voucherHeader.VH_VCH_NO
                    lblStatus.Text = "Status: CONFIRMED"
                Else
                    lblStatus.Text = "Status: UN-CONFIRMED"
                End If

                SplitContainer1.Panel2Collapsed = False
                DatePickerVoucherDate.Value = voucherHeader.VH_Lnk_Dt
                TextBoxChequeNo.Text = voucherHeader.VH_Chq_No

                If (voucherHeader.VH_Chq_Dt.HasValue) Then
                    datepickerChequeDate.Value = voucherHeader.VH_Chq_Dt
                Else
                    datepickerChequeDate.Format = DateTimePickerFormat.Custom
                    datepickerChequeDate.CustomFormat = " "
                End If

                TextBoxNameOfPayee.Text = voucherHeader.VH_Pty_Nm
                TextBoxAmount.Text = voucherHeader.VH_ABS_Amt.ToString
                lblConfirmedVoucherNumber.Text = voucherHeader.VH_VCH_Ref_No.ToString()
                lblConfirmedVoucherNumber.BackColor = Color.Red

                'ComboBoxCreditDebit.SelectedItem = voucherHeader.VH_Cr_Dr
                flgEnable = True
            Else
                MessageBox.Show("No matching Voucher Entry found")
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return flgEnable
    End Function

    Public Function ValidateDates() As String
        Dim messageToShow As String = String.Empty
        Dim voucherlinkDateValidation As String = String.Empty
        Dim referenceDateValidation As String = String.Empty
        Dim voucherConfirmationDateValidation As String = String.Empty

        If (DatePickerVoucherDate.Enabled And Not ValidateClass.CheckVoucherDate(DatePickerVoucherDate.Value.Date, voucherlinkDateValidation)) Then
            messageToShow += Environment.NewLine + "- " + voucherlinkDateValidation
        End If

        If (datepickerVoucherConfirm.Enabled And Not ValidateClass.CheckConfirmationdate(datepickerVoucherConfirm.Value.Date, voucherConfirmationDateValidation, DatePickerVoucherDate.Value.Date)) Then
            messageToShow += Environment.NewLine + "- " + voucherConfirmationDateValidation
        End If

        If (datepickerChequeDate.Visible And datepickerChequeDate.Value.Date.CompareTo(InstitutionMasterData.XDate) > 0) Then
            messageToShow += Environment.NewLine + "- " + "Cheque date cannot be greater that processing date"
        End If
        Return messageToShow
    End Function

    Public Function SaveVoucher() As Boolean


        Dim mandatoryFields As String = String.Empty
        Dim dateValidationMessage As String = String.Empty

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

            dateValidationMessage = ValidateDates()

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


            If frmParent.lblBankBalance.Visible Then
                If TextBoxChequeNo.Text = String.Empty Then
                    mandatoryFields += "Cheque Number"
                End If
                If datepickerChequeDate.Value.ToString() = String.Empty Then
                    mandatoryFields += ", Cheque date"
                End If

            End If

            If TextBoxNameOfPayee.Text = String.Empty Then
                mandatoryFields += ", Particulars"
            End If


            If TextBoxAmount.Text = String.Empty Then
                mandatoryFields += ", Amount"
            End If

            Dim crdr As Boolean = False

            If ComboBoxGoesInto.SelectedItem Is Nothing Then
                mandatoryFields += ", Goes into account not present"
            End If

            If (mandatoryFields.StartsWith(",")) Then
                mandatoryFields = mandatoryFields.Substring(1)
            End If

            If Not mandatoryFields = String.Empty Then
                MessageBox.Show(mandatoryFields + " are compulsory for saving voucher")
                Return False
            Else

                Dim header As VoucherHeader = New VoucherHeader()
                header.VH_Inst_Cd = InstitutionMasterData.XInstCode
                header.VH_Inst_Typ = InstitutionMasterData.XInstType
                header.VH_Fin_Yr = InstitutionMasterData.XFinYr
                header.VH_Lnk_No = txtLinkVoucherNumber.Text
                header.VH_Lnk_Dt = DatePickerVoucherDate.Value.Date
                header.VH_Pty_Nm = TextBoxNameOfPayee.Text
                header.VH_Cr_Dr = "Cr"
                header.VH_ABS_Amt = Decimal.Parse(TextBoxAmount.Text)
                header.VH_Amt = Decimal.Parse(TextBoxAmount.Text) * -1
                header.VH_Dbk_Cd = ComboBoxGoesOut.SelectedValue
                header.VH_Trn_Typ = "CT"
                If datepickerChequeDate.Enabled Then
                    header.VH_Chq_No = TextBoxChequeNo.Text
                    header.VH_Chq_Dt = datepickerChequeDate.Value
                End If

                header.VH_Acc_Cd = DirectCast(ComboBoxGoesOut.Items(ComboBoxGoesOut.SelectedIndex), DataRowView)("DM_Acc_Cd").ToString()
                header.VH_Lgr_Cd = "00"
                header.VH_Brn_Cd = "HO"

                Dim vchRefNo As Int64
                If Me._mode.ToLower() = "add" Then
                    vchRefNo = instMaster.GetNextInstitutionVoucherReferenceNumber()
                ElseIf Me._mode.ToLower() = "edit" Then
                    vchRefNo = Convert.ToInt64(lblConfirmedVoucherNumber.Text.Trim())
                End If

                header.VH_VCH_Ref_No = vchRefNo.ToString().PadLeft(6, "0")

                voucherHelper.SaveVoucherHeader(header)
                Dim voucherDetail As VoucherDetails = New VoucherDetails()
                voucherDetail.VD_Fin_Yr = InstitutionMasterData.XFinYr
                voucherDetail.VD_Inst_Cd = InstitutionMasterData.XInstCode
                voucherDetail.VD_Inst_Typ = InstitutionMasterData.XInstType
                voucherDetail.VD_Dbk_Cd = ComboBoxGoesOut.SelectedValue
                voucherDetail.VD_Trn_Typ = "CT"
                voucherDetail.VD_Lgr_Cd = "00"
                voucherDetail.VD_Lnk_No = txtLinkVoucherNumber.Text
                voucherDetail.VD_Narr = TextBoxNameOfPayee.Text
                voucherDetail.VD_Cr_Dr = "Dr"
                voucherDetail.VD_ABS_Amt = Decimal.Parse(TextBoxAmount.Text)
                voucherDetail.VD_Amt = Decimal.Parse(TextBoxAmount.Text)
                voucherDetail.VD_Seq_No = "001"
                voucherDetail.VD_Acc_Cd = DirectCast(ComboBoxGoesInto.Items(ComboBoxGoesInto.SelectedIndex), DataRowView)("DM_Acc_Cd").ToString()
                voucherDetail.VD_Brn_Cd = "HO"
                voucherDetail.VD_Ent_By = InstitutionMasterData.XUsrId
                voucherDetail.VD_Vch_Ref_No = vchRefNo.ToString().PadLeft(6, "0")
                voucherHelper.SaveVoucherDetail(voucherDetail)

                If Me._mode = "add" Then
                    instMaster.UpdateLinkNumber(txtLinkVoucherNumber.Text.Trim(), vchRefNo, InstitutionMasterData.XInstCode)
                End If
                MessageBox.Show("Voucher saved successfully.")
                Return True
            End If
        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Sub DeleteVoucher()

        If Not String.IsNullOrEmpty(txtLinkVoucherNumber.Text) Then
            voucherHelper.DeleteUnConfirmedVouchers(txtLinkVoucherNumber.Text)
        End If
    End Sub

    Private Sub ConfirmVoucher()
        Dim helper As VoucherHelper = New VoucherHelper()
        Dim calculateDiff As Boolean = True
        Dim balanceAmt As Double
        Dim index As Integer
        Try

            If frmParent.lblBankBalance.Visible Then
                index = frmParent.lblBankBalance.Text.IndexOf(":")
                balanceAmt = Double.Parse(frmParent.lblBankBalance.Text.Substring(index + 1))
                calculateDiff = ValidateClass.CheckBalance(balanceAmt, Double.Parse(TextBoxAmount.Text))
            Else
                index = frmParent.lblCashBalance.Text.IndexOf(":")
                balanceAmt = Double.Parse(frmParent.lblCashBalance.Text.Substring(index + 1))
                calculateDiff = ValidateClass.CheckBalance(balanceAmt, Double.Parse(TextBoxAmount.Text))
            End If

            If calculateDiff Then
                If (Not String.IsNullOrEmpty(ComboBoxGoesOut.SelectedValue) And Not String.IsNullOrEmpty(txtLinkVoucherNumber.Text) And Not String.IsNullOrEmpty(ComboBoxGoesInto.SelectedValue)) Then

                    Dim dt As DataTable = helper.GetNextVoucherNumber(datepickerVoucherConfirm.Value, ComboBoxGoesOut.SelectedValue)
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            lblVoucherConfNo.Text = String.Format("{0}", dt.Rows(0)(0).ToString())
                            lblVoucherConfNo.BackColor = Color.Red
                            'lblVchRefNo.Text = dt.Rows(0)(1).ToString()
                            'lblVchRefNo.BackColor = Color.Red
                            'lblVchRefNo.ForeColor = Color.DarkGray
                        End If
                    End If

                    lblVoucherConfNo.Visible = True
                    If (lblVoucherConfNo.Text.Trim() <> "-") Then
                        helper.ConfirmVoucher(txtLinkVoucherNumber.Text, Convert.ToDateTime(datepickerVoucherConfirm.Value.ToString()), lblVoucherConfNo.Text.Trim())
                    End If

                    Dim lgdr As Ledger = New Ledger()
                    Dim lgdrhelper As LedgerHelper = New LedgerHelper()

                    Dim str As String
                    str = txtLinkVoucherNumber.Text
                    Dim ledgercount As Integer = lgdrhelper.GetCountFromLedger(str)
                    If ledgercount = 0 Then
                        lgdrhelper.AddLedger(str)
                        lgdrhelper.AddLedgerDetail(str)
                    Else
                        MessageBox.Show("Data is already in Ledger")
                    End If


                    Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
                    If frmMain IsNot Nothing Then
                        frmMain.SetBalance()
                        If frmParent.lblBankBalance.Visible Then
                            Dim ledgerAccBalance As Double = ledgerAcc.GetBalance(pDaybookcode:=ComboBoxGoesOut.SelectedValue.ToString)
                            frmParent.lblBankBalance.Text = String.Format("Bank Balance : {0}", ledgerAccBalance)
                        End If
                    End If

                    MessageBox.Show("Voucher confirmed successfully." + Environment.NewLine + "Voucher Confirm Number: " + lblVoucherConfNo.Text)

                End If
            Else
                MessageBox.Show("Insufficient Balance cannot confirm voucher !!!", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub



    Private Sub TextBoxAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxAmount.Validating
        Dim balanceAmount As Double
        Dim enteredAmount As Double
        Try
            enteredAmount = Double.Parse(TextBoxAmount.Text)
            If frmParent.lblBankBalance.Visible Then
                balanceAmount = Double.Parse(frmParent.lblBankBalance.Text.Substring(frmParent.lblBankBalance.Text.IndexOf(":") + 1))
            Else
                balanceAmount = Double.Parse(frmParent.lblCashBalance.Text.Substring(frmParent.lblCashBalance.Text.IndexOf(":") + 1))
            End If
            If Not ValidateClass.CheckBalance(balanceAmount, enteredAmount) Then
                MessageBox.Show("Insufficient Balance cannot save the voucher")
            End If
        Catch ex As Exception
            'Throw
        End Try
    End Sub

    Private Sub txtLinkVoucherNumber_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLinkVoucherNumber.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Tab
                If BindVoucherDetails() Then
                    Select Case _mode
                        Case "view"
                            Me.panelVoucherControls.Visible = True
                            Me.panelVoucherControls.Enabled = False
                            txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                            Me.DatePickerVoucherDate.Visible = True
                            LabelVoucherDate.Visible = True
                            txtLinkVoucherNumber.Enabled = False
                            Me.DatePickerVoucherDate.Enabled = False
                            Me.panelVoucherControls.Enabled = False
                            Me.pnlConfirm.Visible = True
                            Me.pnlConfirm.Enabled = True

                        Case "delete"
                            Me.panelVoucherControls.Visible = True
                            Me.panelVoucherControls.Enabled = False
                            txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                            txtLinkVoucherNumber.Enabled = False
                            Me.DatePickerVoucherDate.Visible = True
                            Me.DatePickerVoucherDate.Enabled = False
                            LabelVoucherDate.Visible = True
                            Me.panelVoucherControls.Enabled = False

                        Case "edit"
                            Me.panelVoucherControls.Visible = True
                            Me.DatePickerVoucherDate.Visible = True
                            txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                            Me.DatePickerVoucherDate.Visible = True
                            Me.DatePickerVoucherDate.Enabled = True
                            LabelVoucherDate.Visible = True
                            txtLinkVoucherNumber.Enabled = False
                            If frmParent.lblBankBalance.Visible Then
                                TextBoxChequeNo.Enabled = True
                                datepickerChequeDate.Enabled = True
                            Else
                                TextBoxChequeNo.Enabled = False
                                datepickerChequeDate.Enabled = False
                            End If
                        Case "confirm"
                            Me.panelVoucherControls.Visible = True
                            Me.panelVoucherControls.Enabled = True
                            txtLinkVoucherNumber.Text = txtLinkVoucherNumber.Text.PadLeft(12, "0")
                            txtLinkVoucherNumber.Enabled = False
                            DatePickerVoucherDate.Visible = True
                            DatePickerVoucherDate.Enabled = False
                            TextBoxChequeNo.Enabled = False
                            datepickerChequeDate.Enabled = False
                            TextBoxAmount.Enabled = False
                            TextBoxNameOfPayee.Enabled = False
                            Me.pnlConfirm.Visible = True
                            Me.pnlConfirm.Enabled = True
                            ComboBoxGoesInto.Enabled = False

                            frmParent.toolstripSave.Enabled = True
                            LabelVoucherDate.Visible = True
                            txtLinkVoucherNumber.Enabled = False
                            lblVoucherConfNo.Text = "-"
                            lblVoucherConfNo.BackColor = Color.Transparent
                    End Select
                Else
                    Me.panelVoucherControls.Visible = False
                    'Me.dgvVoucherDetails.Enabled = False
                End If
            Case Keys.F2
                Dim helper As popupHelper = New popupHelper(1)
                helper.TransType = "CT"
                helper.dbkCode = ComboBoxGoesOut.SelectedValue.ToString()
                helper.currentMode = Me._mode
                helper.ShowDialog()
                txtLinkVoucherNumber.Text = helper.selectedCode
        End Select
    End Sub

    Private Sub frmCashBankContraV_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.frmParent.pnlNavigator.Visible = False
        Me.frmParent.pnlMenu.Visible = True
        Me.frmParent.MenuVisibility = True
        Me.frmParent.lblBankBalance.Text = String.Empty
        Me.frmParent.lblBankBalance.Visible = False

    End Sub



    Private Sub DatePickerVoucherDate_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DatePickerVoucherDate.ValueChanged
        Dim errMessage As String = String.Empty
        Dim datetimePicker As DateTimePicker

        Try
            If Not _mode = "view" Or _mode = "delete" Then
                datetimePicker = DirectCast(sender, DateTimePicker)
                ValidateClass.CheckVoucherDate(datetimePicker.Value, errMessage)

                If Not String.IsNullOrEmpty(errMessage) Then
                    MessageBox.Show(errMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub datepickerVoucherConfirm_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles datepickerVoucherConfirm.ValueChanged
        Dim errMessage As String = String.Empty
        Dim datetimePicker As DateTimePicker
        Dim VoucherDate As DateTimePicker = DirectCast(DatePickerVoucherDate, DateTimePicker)
        Try
            If Not _mode = "view" Then
                datetimePicker = DirectCast(sender, DateTimePicker)
                ValidateClass.CheckConfirmationdate(datetimePicker.Value, errMessage, VoucherDate.Value)

                If Not String.IsNullOrEmpty(errMessage) Then
                    MessageBox.Show(errMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub datepickerChequeDate_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles datepickerChequeDate.ValueChanged
        Dim datetimePicker As DateTimePicker
        Try
            If Not _mode = "view" Then
                datetimePicker = DirectCast(sender, DateTimePicker)
                If datetimePicker.Value.Date.CompareTo(InstitutionMasterData.XDate) > 0 Then
                    MessageBox.Show("Cheque date cannot be greater that processing date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub


End Class