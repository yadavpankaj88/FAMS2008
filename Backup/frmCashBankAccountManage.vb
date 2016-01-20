Public Class frmCashBankAccountManage

    Dim sourceDatatable As DataTable
    Dim enableControls As Boolean = True
    Private ledgeAccHelper As LedgerAccountHelper
    Private daybookHelper As DayBooksHelper

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ledgeAccHelper = New LedgerAccountHelper
        daybookHelper = New DayBooksHelper

    End Sub




    Private Sub frmCashBankAccountManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindDayBookType()
        BindLedgerCombobox()
        EnableBankDetails()

        FillRecords()
        'AttachBindings()
        EnableDisableControls(False)
        TextBoxDayBookCode.Enabled = True
        '  SetToolStripMode()

    End Sub

    Private Sub AttachBindings()
        'TextBoxDayBookCode.DataBindings.Clear()
        'TextBoxDayBookCode.DataBindings.Add("Text", BindingSource1, "DM_Dbk_Cd", True)
        'TextBoxDayBookCode.DataBindings.

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


    Public Sub EnableDisableControls(enable As Boolean)
        TextBoxDayBookCode.Enabled = enable
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
        BindingSource1.DataSource = Nothing
        BindingSource1.DataSource = dt


        sourceDatatable = New DataTable()
        sourceDatatable = dt

        'TextBoxDayBookCode.Text = dt.Rows(0)("DM_Dbk_Cd")

        AttachBindings()
        'If dt.Rows.Count > 0 Then
        '    AssignControls(dt.Rows(0))
        'Else
        '    ClearControls(BindingSource1)
        'End If
    End Sub

    Private Sub AssignControls(datarow As DataRow)
        TextBoxDayBookCode.Text = datarow("DM_Dbk_Cd").ToString()
        TextBoxDaybookName.Text = datarow("DM_Dbk_Nm").ToString()
        ComboBoxDaybookType.SelectedValue = datarow("DM_Dbk_Typ").ToString()
        ComboBoxLedgerAccountCode.SelectedValue = datarow("DM_Acc_Cd")
        TextBoxBankOD.Text = datarow("DM_Bnk_Od")


        If ComboBoxDaybookType.SelectedValue = "B" Then
            TextBoxBankName.Text = IIf(datarow("DM_Bnk_Nm").ToString() <> String.Empty, datarow("DM_Bnk_Nm"), String.Empty)
            TextBoxBranchName.Text = IIf(datarow("DM_Bnk_Brn").ToString() <> String.Empty, datarow("DM_Bnk_Brn"), String.Empty)
            TextBoxAccountNumber.Text = IIf(datarow("DM_Bnk_AcNo").ToString() <> String.Empty, datarow("DM_Bnk_AcNo"), String.Empty)
        Else
            TextBoxBankName.Text = String.Empty
            TextBoxBranchName.Text = String.Empty
            TextBoxAccountNumber.Text = String.Empty
        End If
    End Sub

    Private Sub ClearControls()
        TextBoxDayBookCode.Text = String.Empty
        TextBoxDaybookName.Text = String.Empty
        ComboBoxDaybookType.SelectedIndex = 0
        ComboBoxLedgerAccountCode.SelectedIndex = 0
        TextBoxBankName.Text = String.Empty
        TextBoxBranchName.Text = String.Empty
        TextBoxAccountNumber.Text = String.Empty
        TextBoxBankOD.Text = String.Empty
        EnableBankDetails()
    End Sub

    Public Sub SetToolStripMode(mode As String)

        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)

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

        ledgerTable = ledgeAccHelper.GetAccountDetails(String.Empty)
        ComboBoxLedgerAccountCode.DataSource = ledgerTable
        ComboBoxLedgerAccountCode.DisplayMember = "AM_Acc_Nm"
        ComboBoxLedgerAccountCode.ValueMember = "AM_Acc_Cd"
    End Sub

    Private Sub ComboBoxDaybookType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDaybookType.SelectedIndexChanged
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

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs)
        SaveDaybooks()
    End Sub

    Public Sub SaveDaybooks()

        If Not IsAccountLinked() Then
            Dim daybook As New Daybooks

            daybook.DMDaybookCode = TextBoxDayBookCode.Text.ToString()
            daybook.DMDaybookName = TextBoxDaybookName.Text.ToString()
            daybook.DMDaybookType = ComboBoxDaybookType.SelectedValue
            daybook.DMAccountCode = ComboBoxLedgerAccountCode.SelectedValue

            If ComboBoxDaybookType.SelectedValue = "B" Then
                daybook.DMBankAccNo = TextBoxAccountNumber.Text.ToString()
                daybook.DMBankBranch = TextBoxBranchName.Text.ToString()
                daybook.DMBankName = TextBoxBankName.Text.ToString()
            End If

            daybook.DMBankOD = TextBoxBankOD.Text.ToString()
            daybook.DMInstCd = InstitutionMasterData.XInstCode.Trim
            daybook.DMInstTyp = InstitutionMasterData.XInstType.Trim
            daybook.DMFinYear = InstitutionMasterData.XFinYr.Trim


            daybookHelper.SaveDaybooks(daybook)

            FillRecords()

            EnableDisableControls(False)
        Else
            MessageBox.Show("There are errors please correct it before saving!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim daybookHelper As New DayBooksHelper
        'Dim dt As DataTable = daybookHelper.GetDaybooksByCode(TextBoxDayBookCode.Text)
        'If dt.Rows.Count > 0 Then
        '    AssignControls(dt.Rows(0))
        'Else
        '    ClearControls()
        'End If

        'Dim source As DataTable = sourceDatatable
        'Dim drows As DataRow() = sourceDatatable.Select("DM_Dbk_Cd='" + TextBoxDayBookCode.Text.ToString() + "'")

        Dim dr As DataRow = FindDaybookRecord()
        If Not dr Is Nothing Then
            Dim index As Integer = sourceDatatable.Rows.IndexOf(dr)
            BindingSource1.Position = index
            ''TextBoxDayBookCode.Text = sourceDatatable.Rows(index)("DM_Dbk_Cd").ToString()
        End If

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        DeleteDaybooks()
    End Sub

    Public Sub DeleteDaybooks()
        Dim currentRec As DataRowView = DirectCast(BindingSource1.Current, DataRowView)
        Dim helper As LedgerAccountHelper = New LedgerAccountHelper()
        If currentRec("DM_Acc_Cd") IsNot DBNull.Value And currentRec("DM_Dbk_Cd") IsNot DBNull.Value Then
            Dim transCount As Integer = helper.GetTransactionCount(currentRec("DM_Acc_Cd"), currentRec("DM_Dbk_Cd"))
            If transCount = 0 Then
                If MessageBox.Show("You are about to delete an Account , are you sure you want to delete?", "Deleting Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                    DialogResult.Yes Then
                    daybookHelper.Delete(TextBoxDayBookCode.Text)
                End If
            Else
                MessageBox.Show("This account is currently used in transactions, and cannot be deleted")
            End If
        End If



        'DirectCast(BindingSource1.DataSource, DataTable).Rows(BindingSource1.Position).Delete()
        'BindingSource1.EndEdit()
        'FillRecords()
        'AttachBindings()
    End Sub


    Private Sub frmCashBankAccountManage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        frmMain.mainBindingNavigator.BindingSource = Nothing
        frmMain.pnlNavigator.Visible = False
        frmMain.pnlMenu.Visible = True
        frmMain.EnableNavToolBar()

    End Sub

    Private Sub BindingSource1_PositionChanged(sender As Object, e As EventArgs) Handles BindingSource1.PositionChanged
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
    End Function

End Class