Public Class frmCashBankAccountManage
    Dim sourceDatatable As DataTable
    Dim enableControls As Boolean = True
    Private ledgeAccHelper As LedgerAccountHelper
    Private daybookHelper As DayBooksHelper
    Private _mode As String

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ledgeAccHelper = New LedgerAccountHelper
        daybookHelper = New DayBooksHelper

    End Sub

    Private Sub frmCashBankAccountManage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        BindDayBookType()
        BindLedgerCombobox()
        EnableBankDetails()
        FillRecords()
        AttachBindings()
        EnableDisableControls(False)
        TextBoxDayBookCode.Enabled = True
        If BindingSource1.Count = 0 Then
            ButtonSearch.Visible = False
        Else
            ButtonSearch.Visible = True
        End If
        Me.KeyPreview = True
    End Sub

    Private Sub AttachBindings()
        TextBoxDaybookName.DataBindings.Clear()
        TextBoxDaybookName.DataBindings.Add("Text", BindingSource1, "DM_Dbk_Nm", True)

        ComboBoxDaybookType.DataBindings.Clear()
        ComboBoxDaybookType.DataBindings.Add("SelectedValue", BindingSource1, "DM_Dbk_Typ", True)

        ComboBoxLedgerAccountCode.DataBindings.Clear()
        ComboBoxLedgerAccountCode.DataBindings.Add("SelectedValue", BindingSource1, "DM_Acc_Cd", True)

        TextBoxBankOD.DataBindings.Clear()
        TextBoxBankOD.DataBindings.Add("Text", BindingSource1, "DM_Bnk_Od", True)

        TextBoxBankName.DataBindings.Clear()
        TextBoxBankName.DataBindings.Add("Text", BindingSource1, "DM_Bnk_Nm", True)

        TextBoxBranchName.DataBindings.Clear()
        TextBoxBranchName.DataBindings.Add("Text", BindingSource1, "DM_Bnk_Brn", True)

        TextBoxAccountNumber.DataBindings.Clear()
        TextBoxAccountNumber.DataBindings.Add("Text", BindingSource1, "DM_Bnk_AcNo", True)
    End Sub

    Public Sub ClearDataBindings()

        TextBoxDaybookName.DataBindings.Clear()

        ComboBoxDaybookType.DataBindings.Clear()

        ComboBoxLedgerAccountCode.DataBindings.Clear()

        TextBoxBankOD.DataBindings.Clear()

        TextBoxBankName.DataBindings.Clear()

        TextBoxBranchName.DataBindings.Clear()

        TextBoxAccountNumber.DataBindings.Clear()

    End Sub

    Public Sub EnableDisableControls(ByVal enable As Boolean)
        TextBoxDayBookCode.Enabled = True
        TextBoxDaybookName.Enabled = enable
        ComboBoxDaybookType.Enabled = enable
        ComboBoxLedgerAccountCode.Enabled = enable
        TextBoxBankName.Enabled = enable
        TextBoxBranchName.Enabled = enable
        TextBoxBankOD.Enabled = enable
        TextBoxAccountNumber.Enabled = enable
        enableControls = enable
    End Sub

    Public Sub FillRecords()

        Dim dt As DataTable = daybookHelper.GetDaybooks()

        ClearDataBindings()
        BindPaginationControl(dt)

        sourceDatatable = New DataTable()
        sourceDatatable = dt

        AttachBindings()
    End Sub

    Private Sub AssignControls(ByVal datarow As DataRow)
        TextBoxDayBookCode.Text = datarow("DM_Dbk_Cd").ToString().Trim()
        TextBoxDaybookName.Text = datarow("DM_Dbk_Nm").ToString().Trim()
        ComboBoxDaybookType.SelectedValue = datarow("DM_Dbk_Typ").ToString().Trim()
        ComboBoxLedgerAccountCode.SelectedValue = datarow("DM_Acc_Cd")
        TextBoxBankOD.Text = datarow("DM_Bnk_Od")

        If ComboBoxDaybookType.SelectedValue = "B" Then
            TextBoxBankName.Text = IIf(datarow("DM_Bnk_Nm").ToString().Trim() <> String.Empty, datarow("DM_Bnk_Nm"), String.Empty)
            TextBoxBranchName.Text = IIf(datarow("DM_Bnk_Brn").ToString().Trim() <> String.Empty, datarow("DM_Bnk_Brn"), String.Empty)
            TextBoxAccountNumber.Text = IIf(datarow("DM_Bnk_AcNo").ToString().Trim() <> String.Empty, datarow("DM_Bnk_AcNo"), String.Empty)
        Else
            TextBoxBankName.Text = String.Empty
            TextBoxBranchName.Text = String.Empty
            TextBoxAccountNumber.Text = String.Empty
        End If
    End Sub

    'Private Sub ClearControls()
    '    TextBoxDayBookCode.Text = String.Empty
    '    TextBoxDaybookName.Text = String.Empty
    '    ComboBoxDaybookType.SelectedIndex = 0
    '    ComboBoxLedgerAccountCode.SelectedIndex = 0
    '    TextBoxBankName.Text = String.Empty
    '    TextBoxBranchName.Text = String.Empty
    '    TextBoxAccountNumber.Text = String.Empty
    '    TextBoxBankOD.Text = String.Empty
    '    EnableBankDetails()
    'End Sub

    Public Sub SetToolStripMode(ByVal mode As String)

        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        _mode = mode
        Select Case mode
            Case "View"
                frmMain.ToolStripButtonView.Enabled = True
                frmMain.ToolStripButtonClear.Enabled = True
                frmMain.toolstripedit.Enabled = True
                frmMain.toolstripSave.Enabled = False
                frmMain.toolstripDeleteItem.Enabled = True
                ClearDataBindings()
                FillRecords()
            Case "AddNew"
                frmMain.toolstripedit.Enabled = False
                frmMain.toolstripDeleteItem.Enabled = False
                frmMain.toolstripAdd.Enabled = False
                
        End Select

    End Sub

    Private Sub BindDayBookType()

        Dim DayBookTypes As New List(Of ComboBoxHelper)
        DayBookTypes.Add(New ComboBoxHelper() With { _
              .Text = "Bank", _
             .Value = "B" _
        })

        DayBookTypes.Add(New ComboBoxHelper() With { _
             .Text = "Cash", _
            .Value = "C" _
       })

        DayBookTypes.Add(New ComboBoxHelper() With { _
            .Text = "Voucher", _
           .Value = "V" _
      })

        ComboBoxDaybookType.DataSource = DayBookTypes
        ComboBoxDaybookType.DisplayMember = "Text"
        ComboBoxDaybookType.ValueMember = "Value"
    End Sub

    Private Sub BindLedgerCombobox()
        Dim ledgerTable As New DataTable()
        ledgerTable = ledgeAccHelper.FillAccountCode()
        ComboBoxLedgerAccountCode.DataSource = ledgerTable
        ComboBoxLedgerAccountCode.DisplayMember = "name"
        ComboBoxLedgerAccountCode.ValueMember = "AM_Acc_Cd"
    End Sub

    Private Sub ComboBoxDaybookType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxDaybookType.SelectedIndexChanged
        EnableBankDetails()
    End Sub

    Public Sub EnableBankDetails()
        Dim enable As Boolean = IIf(ComboBoxDaybookType.SelectedValue.ToString() = "B", True, False)
        If enableControls Then
            TextBoxBankName.Enabled = enable
            TextBoxAccountNumber.Enabled = enable
            TextBoxBranchName.Enabled = enable

            If (Not enable) Then
                TextBoxBankName.Text = String.Empty
                TextBoxAccountNumber.Text = String.Empty
                TextBoxBranchName.Text = String.Empty
            Else
                Dim dt As DataTable = DirectCast(BindingSource1.DataSource, DataTable)
                If (Not dt Is Nothing) Then
                    Try
                        TextBoxBankName.Text = dt.Rows(BindingSource1.Position)("DM_Bnk_Nm")
                        TextBoxBranchName.Text = dt.Rows(BindingSource1.Position)("DM_Bnk_Brn")
                        TextBoxAccountNumber.Text = dt.Rows(BindingSource1.Position)("DM_Bnk_AcNo")
                    Catch ex As Exception

                    End Try
                End If
            End If

        End If
    End Sub

    Public Sub SaveDaybooks()
        Dim dt As DataTable = daybookHelper.GetDaybooksByCode(TextBoxDayBookCode.Text)

        If Not IsAccountLinked() Then

            Dim daybook As New Daybooks
            Dim errorStr As String = ""
            errorStr = Validation()

            If errorStr = "" Then

                daybook.DMDaybookCode = TextBoxDayBookCode.Text.ToString().Trim()
                daybook.DMDaybookName = TextBoxDaybookName.Text.ToString().Trim()
                daybook.DMDaybookType = ComboBoxDaybookType.SelectedValue.Trim()
                daybook.DMAccountCode = ComboBoxLedgerAccountCode.SelectedValue.Trim()
                If ComboBoxDaybookType.SelectedValue = "B" Then
                    daybook.DMBankAccNo = TextBoxAccountNumber.Text.ToString().Trim()
                    daybook.DMBankBranch = TextBoxBranchName.Text.ToString().Trim()
                    daybook.DMBankName = TextBoxBankName.Text.ToString().Trim()
                End If

                daybook.DMBankOD = TextBoxBankOD.Text.ToString().Trim()
                daybook.DMInstCd = InstitutionMasterData.XInstCode.Trim()
                daybook.DMInstTyp = InstitutionMasterData.XInstType.Trim()
                daybook.DMFinYear = InstitutionMasterData.XFinYr.Trim()
                daybook.DMBranchCode = "HO"
                If (_mode = "AddNew" And daybookHelper.GetCount(TextBoxDayBookCode.Text) > 0) Then
                    MessageBox.Show("Daybook code already exists")
                Else
                    If (_mode = "edit") Then
                        daybookHelper.UpdateAccCode(dt.Rows(0)("DM_Acc_Cd").ToString())
                    End If
                    daybookHelper.SaveDaybooks(daybook)
                    MessageBox.Show("Data updated successfully")
                    FillRecords()
                    ClearData()
                End If
            Else
                MessageBox.Show(errorStr)
            End If
        Else
            MessageBox.Show("There are errors, please correct them before saving!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSearch.Click
        'Dim daybookHelper As New DayBooksHelper
        'Dim dt As DataTable = daybookHelper.GetDaybooksByCode(TextBoxDayBookCode.Text)
        'If dt.Rows.Count > 0 Then
        '    AssignControls(dt.Rows(0))
        'Else
        '    ClearControls()
        'End If

        'Dim source As DataTable = sourceDatatable
        'Dim drows As DataRow() = sourceDatatable.Select("DM_Dbk_Cd='" + TextBoxDayBookCode.Text.ToString() + "'")
        Dim daybookcode As String
        Dim daybookHelper As New DayBooksHelper
        Dim daybook As New frmFillDaybookCode
        Dim message As String
        daybook.setvalue(TextBoxDayBookCode.Text)
        daybook.ShowDialog()
        daybookcode = daybook.val
        If (daybookcode = Nothing) Then
            MessageBox.Show("Please select daybook")
            daybook.ShowDialog()
            message = daybook.msg
            If (message <> "") Then
                MessageBox.Show(message)
                ClearData()
            Else
                daybookHelper.CheckDaybookCd(TextBoxDayBookCode.Text)

                daybookcode = daybook.val
            End If
            Dim dt As DataTable = daybookHelper.GetDaybooksDetails(daybookcode)
            TextBoxDayBookCode.Text = daybookcode
            If dt.Rows(0)("DM_Dbk_Typ") = "B" Then
                TextBoxBankName.Text = dt.Rows(0)("DM_Bnk_Nm")
                TextBoxBranchName.Text = dt.Rows(0)("DM_Bnk_Brn")
                TextBoxAccountNumber.Text = dt.Rows(0)("DM_Bnk_AcNo")
                TextBoxBankOD.Text = dt.Rows(0)("DM_Bnk_OD")
            Else
                TextBoxBankName.Text = ""
                TextBoxBranchName.Text = ""
                TextBoxAccountNumber.Text = ""
                'TextBoxBankOD.Text = ""
            End If
            TextBoxDaybookName.Text = dt.Rows(0)("DM_Dbk_Nm").ToString()
            If (dt.Rows(0)("DM_Dbk_Typ") = "V") Then
                ComboBoxDaybookType.Text = "Voucher"
            End If

            If (dt.Rows(0)("DM_Dbk_Typ") = "C") Then
                ComboBoxDaybookType.Text = "Cash"
            End If

            If (dt.Rows(0)("DM_Dbk_Typ") = "B") Then
                ComboBoxDaybookType.Text = "Bank"
            End If

            ' ComboBoxDaybookType.Text = dt.Rows(0)("DM_Dbk_Typ")
            ComboBoxLedgerAccountCode.Text = dt.Rows(0)("DM_Acc_Cd")
        End If

        EnableDisableControls(False)

        'Dim dr As DataRow = FindDaybookRecord()
        'If Not dr Is Nothing Then
        '    Dim index As Integer = sourceDatatable.Rows.IndexOf(dr)
        '    BindingSource1.Position = index
        '    ''TextBoxDayBookCode.Text = sourceDatatable.Rows(index)("DM_Dbk_Cd").ToString()
        'End If

    End Sub

    Public Function FindDaybookRecord() As DataRow
        Dim dr As DataRow = Nothing

        For index As Integer = 0 To sourceDatatable.Rows.Count - 1
            If sourceDatatable.Rows(index)("DM_Dbk_Cd").ToString().Trim() = TextBoxDayBookCode.Text.Trim() Then

                dr = sourceDatatable.Rows(index)
                Exit For
            End If
        Next

        Return dr
    End Function

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        DeleteDaybooks()
    End Sub

    Public Sub DeleteDaybooks()
        Dim currentRec As DataRowView = DirectCast(BindingSource1.Current, DataRowView)
        Dim helper As LedgerAccountHelper = New LedgerAccountHelper()
        If currentRec("DM_Acc_Cd") IsNot DBNull.Value And currentRec("DM_Dbk_Cd") IsNot DBNull.Value Then
            Dim transCount As Integer = helper.GetTransactionCount(currentRec("DM_Acc_Cd"), currentRec("DM_Dbk_Cd"))
            If transCount = 0 Then
                If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    daybookHelper.Delete(TextBoxDayBookCode.Text)
                    TextBoxDayBookCode.Text = "true"
                    TextBoxDaybookName.Text = ""
                    ComboBoxDaybookType.Text = ""
                    ComboBoxLedgerAccountCode.Text = ""
                    TextBoxBankName.Text = ""
                    TextBoxBranchName.Text = ""
                    TextBoxAccountNumber.Text = ""
                    TextBoxBankOD.Text = ""
                    Me.Close()
                End If
            Else
                MessageBox.Show("This account is currently used in transactions, and cannot be deleted")
            End If
        ElseIf currentRec("DM_Acc_Cd") Is DBNull.Value And currentRec("DM_Dbk_Cd") Is DBNull.Value Then
            MessageBox.Show("It's empty record")
        End If

        'DirectCast(BindingSource1.DataSource, DataTable).Rows(BindingSource1.Position).Delete()
        'BindingSource1.EndEdit()
        'FillRecords()
        'AttachBindings()
    End Sub

    Private Sub frmCashBankAccountManage_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        frmMain.mainBindingNavigator.BindingSource = Nothing
        frmMain.pnlNavigator.Visible = False
        frmMain.pnlMenu.Visible = True
        frmMain.EnableNavToolBar()
        CheckChange()

    End Sub

    Function CheckChange() As Boolean
        Dim daybookhelper As New DayBooksHelper
        Dim dt As DataTable
        dt = daybookhelper.GetDaybooksDetails(TextBoxDayBookCode.Text)

        If TextBoxBankOD.Text = "" Then
            TextBoxBankOD.Text = 0
        End If

        If dt.Rows.Count() > 0 Then
            If TextBoxBankOD.Text = "" Then

                If dt.Rows(0)("DM_Bnk_OD") = 0.0 Then
                    TextBoxBankOD.Text = 0
                    dt.Rows(0)("DM_Bnk_OD") = Math.Round(dt.Rows(0)("DM_Bnk_OD"))
                Else
                    dt.Rows(0)("DM_Bnk_OD") = Math.Round(dt.Rows(0)("DM_Bnk_OD"))
                    TextBoxBankOD.Text = Math.Round(Convert.ToDecimal(TextBoxBankOD.Text))
                End If
            Else
                dt.Rows(0)("DM_Bnk_OD") = Math.Round(dt.Rows(0)("DM_Bnk_OD"))
                TextBoxBankOD.Text = Math.Round(Convert.ToDecimal(TextBoxBankOD.Text))

                If (ComboBoxDaybookType.SelectedValue = Nothing) Then
                    ComboBoxDaybookType.SelectedValue = dt.Rows(0)("DM_Dbk_Typ").ToString()
                End If
                
            End If
            If (IsAccountLinked()) Then
                If (ComboBoxLedgerAccountCode.SelectedValue = Nothing) Then
                    ComboBoxLedgerAccountCode.SelectedValue = dt.Rows(0)("DM_Acc_Cd").ToString()
                End If
                If dt.Rows(0)("DM_Dbk_Typ").ToString().Trim() <> ComboBoxDaybookType.SelectedValue.Trim() Or dt.Rows(0)("DM_Acc_Cd").ToString().Trim() <> ComboBoxLedgerAccountCode.SelectedValue.Trim() Or (dt.Rows(0)("DM_Bnk_Nm").ToString().Trim() <> TextBoxBankName.Text.Trim()) Or (dt.Rows(0)("DM_Bnk_Brn").ToString().Trim() <> TextBoxBranchName.Text.Trim()) Or (dt.Rows(0)("DM_Bnk_AcNo").ToString().Trim() <> TextBoxAccountNumber.Text.Trim()) Or (dt.Rows(0)("DM_Bnk_OD").ToString().Trim() <> TextBoxBankOD.Text.Trim()) Then
                    If MessageBox.Show("Do you want to save changes?", " Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        SaveDaybooks()
                        Return True
                    Else
                        Return False
                        Me.Close()
                    End If
                Else
                    Return False
                    Me.Close()
                End If
            Else

                If dt.Rows(0)("DM_Dbk_Typ").ToString().Trim() <> ComboBoxDaybookType.SelectedValue.Trim() Or (dt.Rows(0)("DM_Bnk_Nm").ToString().Trim() <> TextBoxBankName.Text.Trim()) Or (dt.Rows(0)("DM_Bnk_Brn").ToString().Trim() <> TextBoxBranchName.Text.Trim()) Or (dt.Rows(0)("DM_Bnk_AcNo").ToString().Trim() <> TextBoxAccountNumber.Text.Trim()) Or (dt.Rows(0)("DM_Bnk_OD").ToString().Trim() <> TextBoxBankOD.Text.Trim()) Then
                    If MessageBox.Show("Do you want to save changes?", " Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        SaveDaybooks()
                        Return True
                    Else
                        Return False
                        Me.Close()
                    End If
                Else
                    Return False
                    Me.Close()
                End If
            End If
            
        Else

            If (TextBoxDayBookCode.Text = "true" Or TextBoxDayBookCode.Text = "" Or TextBoxDaybookName.Text = "") Then
                ' SaveDaybooks()
            Else
                If MessageBox.Show("Do you want to save changes?", " Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    SaveDaybooks()
                    Return True
                Else
                    Return False
                    Me.Close()
                End If
            End If
        End If

    End Function

    Private Sub BindingSource1_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BindingSource1.PositionChanged
        Dim source As DataTable = BindingSource1.DataSource
        If Not source Is Nothing Then
            If Not BindingSource1.Position >= source.Rows.Count And source.Rows.Count > 0 Then
                TextBoxDayBookCode.Text = source.Rows(BindingSource1.Position)("DM_Dbk_Cd").ToString()
            Else
                TextBoxDayBookCode.Text = String.Empty
            End If
        End If
    End Sub

    'Private Sub ComboBoxLedgerAccountCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxLedgerAccountCode.SelectedValueChanged

    'End Sub

    Private Function IsAccountLinked() As Boolean
        If (_mode <> "edit") Then
            Dim pAccountCode, pDaybook As String
            Try
                pAccountCode = ComboBoxLedgerAccountCode.SelectedValue.ToString
                pDaybook = TextBoxDayBookCode.Text
                If ledgeAccHelper.IsAccountLinked(pAccountCode, pDaybook) Then
                    lblAcccodeErr.Visible = True
                Else
                    lblAcccodeErr.Visible = False
                End If
            Catch ex As Exception

            End Try
            Return lblAcccodeErr.Visible
        Else
            Return False
        End If
    End Function

#Region "validation"
    '------------------------------------------------------------validation---------------------------------------------------------------------------

    Function Validation() As String
        Dim result As String = ""
        If TextBoxDayBookCode.Text = String.Empty Then
            result = result & " Daybook code is empty" & vbNewLine
        End If

        If TextBoxDaybookName.Text = String.Empty Then
            result = result & " Daybook name is empty" & vbNewLine
        End If

        If ComboBoxLedgerAccountCode.SelectedIndex = -1 Then
            result = result & " Please select account code" & vbNewLine
        End If
        If ComboBoxDaybookType.SelectedIndex = -1 Then
            result = result & " Please select Daybook  type" & vbNewLine
        End If
        Return result
    End Function

    Private Sub TextBoxAccountNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAccountNumber.KeyPress

        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBoxBankOD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBankOD.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBoxLedgerAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ComboBoxLedgerAccountCode.Text = String.Empty Then
            ComboBoxLedgerAccountCode.Focus()
        End If
    End Sub
#End Region

    Private Sub frmCashBankAccountManage_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dim frmfammain As frmFAMSMain = DirectCast(ActiveForm, frmFAMSMain)
    End Sub

    Private Sub frmCashBankAccountManage_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode.ToString = "S" Then
            SaveDaybooks()
        End If
        If e.Control And e.KeyCode.ToString = "N" Then
            SetToolStripMode("AddNew")
            EnableDisableControls(True)
            TextBoxDayBookCode.Enabled = True
            frmFAMSMain.toolstripSave.Enabled = True
            frmFAMSMain.DisableNavToolBar(frmFAMSMain.NavSettings.Add)
            ClearData()
        End If
    End Sub

    Sub ClearData()
        TextBoxDayBookCode.Text = ""
        TextBoxDaybookName.Text = ""
        ComboBoxDaybookType.Text = ""
        ComboBoxLedgerAccountCode.Text = ""
        TextBoxBankName.Text = ""
        TextBoxBranchName.Text = ""
        TextBoxAccountNumber.Text = ""
        TextBoxBankOD.Text = "0"
        TextBoxDayBookCode.Focus()
    End Sub

    Sub BindPaginationControl(ByVal dt As DataTable)
        BindingSource1.DataSource = Nothing
        BindingSource1.DataSource = dt

    End Sub
End Class