Public Class frmVoucherPrintReport

    Private _reportType As String
    Private _VH_Lnk_No As String
    Private _Code As String
    Private _VH_Trn_Typ As String
    Private _pDbkName As String
    Public parentForm As frmFAMSMain

    Public Sub SetControls(ByVal pReportType As String, ByVal pLinkNumber As String, ByVal pCode As String, ByVal pTrnType As String, ByVal pDbkName As String)
        _reportType = pReportType
        _VH_Lnk_No = pLinkNumber
        _Code = pCode
        _VH_Trn_Typ = pTrnType
        _pDbkName = pDbkName
        Me.parentForm.pnlNavigator.Visible = False
    End Sub

    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadReport()
    End Sub

    Private Sub LoadReport()

        Try
            Select Case _reportType
                Case "Voucher"
                    ShowVoucherReport()
                Case "Account"
                    ShowAccountReport()
                Case "Daybook"
                    ShowDaybookReport()
            End Select
        Catch ex As Exception
            MessageBox.Show("Error Occurred !!!")
        End Try
    End Sub

    Private Sub ShowVoucherReport()
        Dim view As New rptPrintVoucher
        Dim user As String = System.Configuration.ConfigurationSettings.AppSettings("Username")
        Dim pwd As String = System.Configuration.ConfigurationSettings.AppSettings("Password")
        Dim Server As String = System.Configuration.ConfigurationSettings.AppSettings("Server")
        Dim Database As String = System.Configuration.ConfigurationSettings.AppSettings("Database") + InstitutionMasterData.XFinYr
        view.DataSourceConnections(0).SetConnection(Server, Database, user, pwd)
        view.SetDatabaseLogon(user, pwd, Server, Database)
        view.SetParameterValue("@instType", InstitutionMasterData.XInstType)
        view.SetParameterValue("@VH_Lnk_No", _VH_Lnk_No)
        view.SetParameterValue("@VH_Dbk_Cd", _Code)
        view.SetParameterValue("@VH_Trn_Typ", _VH_Trn_Typ)
        view.SetParameterValue("@VH_Fin_Yr", InstitutionMasterData.XFinYr)
        view.SetParameterValue("@instCode", InstitutionMasterData.XInstCode)
        crystalviewerVoucher.ReportSource = view
        crystalviewerVoucher.DisplayGroupTree = False
        crystalviewerVoucher.ShowRefreshButton = False
    End Sub

    Private Sub ShowAccountReport()
        Dim view As New rptPrintAccount
        Dim user As String = System.Configuration.ConfigurationSettings.AppSettings("Username")
        Dim pwd As String = System.Configuration.ConfigurationSettings.AppSettings("Password")
        Dim Server As String = System.Configuration.ConfigurationSettings.AppSettings("Server")
        Dim Database As String = System.Configuration.ConfigurationSettings.AppSettings("Database") + InstitutionMasterData.XFinYr
        view.DataSourceConnections(0).SetConnection(Server, Database, user, pwd)
        view.SetDatabaseLogon(user, pwd, Server, Database)
        view.SetParameterValue("@instType", InstitutionMasterData.XInstType)
        view.SetParameterValue("@AccCode", _Code)
        view.SetParameterValue("@VH_Fin_Yr", InstitutionMasterData.XFinYr)
        view.SetParameterValue("@instCode", InstitutionMasterData.XInstCode)

        crystalviewerVoucher.ReportSource = view
        crystalviewerVoucher.DisplayGroupTree = False
        crystalviewerVoucher.ShowRefreshButton = False
    End Sub

    Private Sub ShowDaybookReport()
        Dim view As New rptPrintDaybook
        Dim user As String = System.Configuration.ConfigurationSettings.AppSettings("Username")
        Dim pwd As String = System.Configuration.ConfigurationSettings.AppSettings("Password")
        Dim Server As String = System.Configuration.ConfigurationSettings.AppSettings("Server")
        Dim Database As String = System.Configuration.ConfigurationSettings.AppSettings("Database") + InstitutionMasterData.XFinYr
        view.DataSourceConnections(0).SetConnection(Server, Database, user, pwd)
        view.SetDatabaseLogon(user, pwd, Server, Database)
        view.SetParameterValue("@DaybookCode", _Code)
        view.SetParameterValue("@instType", InstitutionMasterData.XInstType)
        view.SetParameterValue("@VH_Fin_Yr", InstitutionMasterData.XFinYr)
        view.SetParameterValue("@instCode", InstitutionMasterData.XInstCode)

        crystalviewerVoucher.ReportSource = view
        crystalviewerVoucher.DisplayGroupTree = False
        crystalviewerVoucher.ShowRefreshButton = False
    End Sub

    Private Sub frmVoucherPrintReport_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.parentForm.pnlNavigator.Visible = True
    End Sub
End Class