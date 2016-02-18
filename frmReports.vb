
Public Class frmReports

    Private _mode As String
    Private _dayBookCode As String
    Private _fromDate As DateTime
    Private _toDate As DateTime
    Private _accountFrom As String
    Private _accountTo As String
    Private _dbkName As String

    Private Sub frmReports_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
        If frmMain IsNot Nothing Then
            frmMain.mainBindingNavigator.BindingSource = Nothing
            frmMain.pnlNavigator.Visible = False
            frmMain.pnlMenu.Visible = True
            frmMain.EnableNavToolBar()
        End If
    End Sub

    Private Sub frmReports_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dim frmfammain As frmFAMSMain = DirectCast(ActiveForm, frmFAMSMain)
        'frmfammain.Show()
    End Sub

    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadReport()
    End Sub

    Private Sub LoadReport()

        Try
            'ClearControls()
            Select Case _mode
                Case "CashBook"
                    ShowCashBookReport("Cash")
                Case "BankBook"
                    ShowCashBookReport("Bank")
                Case "GeneralLedgerCASHBank"
                    ShowGeneralLedger(True)
                Case "GeneralLedgerOther"
                    ShowGeneralLedger(False)
                Case "TrialBalance"
                    ShowTrialBalance()
            End Select
        Catch ex As Exception
            MessageBox.Show("Error Occurred !!!")
        End Try
    End Sub

    Public Sub SetControls(ByVal pMode As String, ByVal pDayBkCode As String, ByVal pfromDate As DateTime, ByVal ptoDate As DateTime, ByVal paccountFrom As String, ByVal paccountTo As String, ByVal pDBKName As String)
        _mode = pMode
        _dayBookCode = pDayBkCode
        _fromDate = pfromDate
        _toDate = ptoDate
        _accountFrom = paccountFrom
        _accountTo = paccountTo
        _dbkName = pDBKName
    End Sub

    Private Sub ShowCashBookReport(ByVal Mode As String)
        Dim view As New rptCashBook2008
        Dim user As String = System.Configuration.ConfigurationSettings.AppSettings("Username")
        Dim pwd As String = System.Configuration.ConfigurationSettings.AppSettings("Password")
        Dim Server As String = System.Configuration.ConfigurationSettings.AppSettings("Server")
        Dim Database As String = System.Configuration.ConfigurationSettings.AppSettings("Database") + InstitutionMasterData.XFinYr
        view.DataSourceConnections(0).SetConnection(Server, Database, user, pwd)
        view.SetDatabaseLogon(user, pwd, Server, Database)
        view.SetParameterValue("@instType", InstitutionMasterData.XInstType)
        view.SetParameterValue("@Fromdate", _fromDate.ToShortDateString())
        view.SetParameterValue("@ToDate", _toDate.ToShortDateString())
        view.SetParameterValue("@VH_Dbk_Cd", _dayBookCode)
        view.SetParameterValue("@instCode", InstitutionMasterData.XInstCode)
        view.SetParameterValue("@DayBookName", _dbkName)
        view.SetParameterValue("@DayBookType", Mode)
        crystalRptVwr.ReportSource = view
        crystalRptVwr.DisplayGroupTree = False
        crystalRptVwr.ShowRefreshButton = False

    End Sub

    Private Sub ShowGeneralLedger(ByVal pIsCashBank As Boolean)
        Dim view As New rptGeneralLedger2008
        Dim user As String = System.Configuration.ConfigurationSettings.AppSettings("Username")
        Dim pwd As String = System.Configuration.ConfigurationSettings.AppSettings("Password")
        Dim Server As String = System.Configuration.ConfigurationSettings.AppSettings("Server")
        Dim Database As String = System.Configuration.ConfigurationSettings.AppSettings("Database") + InstitutionMasterData.XFinYr
        view.DataSourceConnections(0).SetConnection(Server, Database, user, pwd)
        view.SetDatabaseLogon(user, pwd, Server, Database)
        view.SetParameterValue("@instType", InstitutionMasterData.XInstType)
        view.SetParameterValue("@Fromdate", _fromDate.ToShortDateString())
        view.SetParameterValue("@ToDate", _toDate.ToShortDateString())
        view.SetParameterValue("@IsCashBank", pIsCashBank)
        view.SetParameterValue("@AccountFrom", _accountFrom)
        view.SetParameterValue("@AccountTo", _accountTo)
        view.SetParameterValue("@instCode", InstitutionMasterData.XInstCode)
        crystalRptVwr.ReportSource = view
        crystalRptVwr.DisplayGroupTree = False
        crystalRptVwr.ShowRefreshButton = False
    End Sub

    Private Sub ShowTrialBalance()
        Dim view As New rptTrialBalance2008
        Dim user As String = System.Configuration.ConfigurationSettings.AppSettings("Username")
        Dim Server As String = System.Configuration.ConfigurationSettings.AppSettings("Server")
        Dim Database As String = System.Configuration.ConfigurationSettings.AppSettings("Database") + InstitutionMasterData.XFinYr
        Dim pwd As String = System.Configuration.ConfigurationSettings.AppSettings("Password")
        view.DataSourceConnections(0).SetConnection(Server, Database, user, pwd)
        view.SetDatabaseLogon(user, pwd, Server, Database)
        view.SetParameterValue("@instType", InstitutionMasterData.XInstType)
        view.SetParameterValue("@Fromdate", _fromDate.ToShortDateString())
        view.SetParameterValue("@ToDate", _toDate.ToShortDateString())
        view.SetParameterValue("@instCode", InstitutionMasterData.XInstCode)
        crystalRptVwr.ReportSource = view
        crystalRptVwr.DisplayGroupTree = False
        crystalRptVwr.ShowRefreshButton = False
    End Sub

End Class