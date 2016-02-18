Public Class frmSelectDaybook

    Dim objCashReceipt As frmReports
    Private _mode As String

    Private Sub btncontinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncontinue.Click
        ShowReport()
    End Sub

    Private Sub frmReports_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        If frmMain IsNot Nothing Then
            frmMain.mainBindingNavigator.BindingSource = Nothing
            frmMain.pnlNavigator.Visible = False
            frmMain.pnlMenu.Visible = True
            frmMain.EnableNavToolBar()
        End If
    End Sub

    Public Sub SetControls(ByVal pMode As String)
        _mode = pMode
    End Sub

    Private Sub ShowReport()
        Try
            If (Not String.IsNullOrEmpty(_mode) And Not String.IsNullOrEmpty(dtpfromdate.Value.ToString()) And Not String.IsNullOrEmpty(dtptodate.Value.ToString())) Then
                If ((dtpfromdate.Value >= InstitutionMasterData.XStartFinYr And dtpfromdate.Value <= InstitutionMasterData.XEndFinYr) And (dtptodate.Value >= InstitutionMasterData.XStartFinYr And dtptodate.Value <= InstitutionMasterData.XEndFinYr)) Then
                    If ((String.Equals(_mode, "GeneralLedgerCASHBank") Or String.Equals(_mode, "GeneralLedgerOther")) And String.IsNullOrEmpty(txtAccountFrom.Text) And String.IsNullOrEmpty(txtAccountTo.Text)) Then
                        MessageBox.Show("Please select all neccessary parameters")
                    Else
                        If (LoadReportCount() > 0) Then
                            If ((_mode = "CashBook" Or _mode = "BankBook") And String.IsNullOrEmpty(ddldaybookcode.SelectedValue)) Then
                                MessageBox.Show("Please select all neccessary parameters")
                            Else
                                objCashReceipt = New frmReports
                                objCashReceipt.SetControls(_mode, ddldaybookcode.SelectedValue, dtpfromdate.Value, dtptodate.Value, txtAccountFrom.Text, txtAccountTo.Text, ddldaybookcode.Text)
                                Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
                                frmMain.ShowNewForm(objCashReceipt, Nothing)
                                Me.Hide()
                            End If
                        Else
                            MessageBox.Show("No data available for selected parameters")
                        End If
                    End If
                Else
                    MessageBox.Show("Please select date from current financial year")
                End If
            Else
                MessageBox.Show("Please select all neccessary parameters")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function LoadReportCount()
        Dim reportCountHelper As New ReportHelper
        Dim count As Integer = 0
        Select Case _mode
            Case "CashBook"
                count = reportCountHelper.GetCashBankBookReportCount(dtpfromdate.Value, dtptodate.Value, ddldaybookcode.SelectedValue, ddldaybookcode.Text, "Cash")
            Case "BankBook"
                count = reportCountHelper.GetCashBankBookReportCount(dtpfromdate.Value, dtptodate.Value, ddldaybookcode.SelectedValue, ddldaybookcode.Text, "Bank")
            Case "GeneralLedgerCASHBank"
                count = reportCountHelper.GetLedgerReportCount(dtpfromdate.Value, dtptodate.Value, True, txtAccountFrom.Text, txtAccountTo.Text)
            Case "GeneralLedgerOther"
                count = reportCountHelper.GetLedgerReportCount(dtpfromdate.Value, dtptodate.Value, False, txtAccountFrom.Text, txtAccountTo.Text)
            Case "TrialBalance"
                count = reportCountHelper.GetTrialBalanceReportCount(dtpfromdate.Value, dtptodate.Value)
        End Select
        Return count
    End Function

    Private Sub BindDaybookCode()
        Dim ledgeAccHelper As New LedgerAccountHelper
        Dim ledgerTable As New DataTable()
        Dim dbkTyp As String

        If (_mode = "CashBook") Then
            dbkTyp = "C"
        Else
            dbkTyp = "B"
        End If
        ledgerTable = ledgeAccHelper.FillDaybookCode(dbkTyp)
        ddldaybookcode.DataSource = ledgerTable
        ddldaybookcode.DisplayMember = "Daybook_Code"
        ddldaybookcode.ValueMember = "DM_Dbk_Cd"
    End Sub

    Private Sub frmSelectDaybook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowDayBookOption()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub ShowDayBookOption()
        Dim showDayBookOption As Boolean = False
        Dim showAccountCodeOption As Boolean = False
        Select Case _mode
            Case "CashBook"
                showDayBookOption = True
                showAccountCodeOption = False
            Case "BankBook"
                showDayBookOption = True
                showAccountCodeOption = False
            Case "GeneralLedgerCASHBank"
                showDayBookOption = False
                showAccountCodeOption = True
            Case "GeneralLedgerOther"
                showDayBookOption = False
                showAccountCodeOption = True
            Case "TrialBalance"
                showDayBookOption = False
                showAccountCodeOption = False
        End Select

        EnabledPanelContents(pnlDaybook, showDayBookOption)
        EnabledPanelContents(pnlAccountRange, showAccountCodeOption)
        BindDaybookCode()

    End Sub

    Private Sub EnabledPanelContents(ByVal panel As Panel, ByVal enabled As Boolean)
        For Each ctrl As Control In panel.Controls
            ctrl.Enabled = enabled
        Next
    End Sub

End Class