Public Class frmVoucherPrintReport

    Private _VH_Lnk_No As String
    Private _VH_Dbk_Cd As String
    Private _VH_Trn_Typ As String

    'Private Sub frmReports_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    Dim frmMain As frmFAMSMain = DirectCast(Me.MdiParent, frmFAMSMain)
    '    If frmMain IsNot Nothing Then
    '        frmMain.mainBindingNavigator.BindingSource = Nothing
    '        frmMain.pnlNavigator.Visible = False
    '        frmMain.pnlMenu.Visible = True
    '        frmMain.EnableNavToolBar()
    '    End If
    'End Sub

    'Private Sub frmReports_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '    Dim frmfammain As frmFAMSMain = DirectCast(ActiveForm, frmFAMSMain)
    '    'frmfammain.Show()
    'End Sub

    Public Sub SetControls(ByVal pLinkNumber As String, ByVal pDbkCode As String, ByVal pTrnType As String)
        _VH_Lnk_No = pLinkNumber
        _VH_Dbk_Cd = pDbkCode
        _VH_Trn_Typ = pTrnType
    End Sub


    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim view As New rptPrintVoucher
        Dim user As String = System.Configuration.ConfigurationSettings.AppSettings("Username")
        Dim pwd As String = System.Configuration.ConfigurationSettings.AppSettings("Password")
        Dim Server As String = System.Configuration.ConfigurationSettings.AppSettings("Server")
        Dim Database As String = System.Configuration.ConfigurationSettings.AppSettings("Database")
        view.SetDatabaseLogon(user, pwd, Server, Database)
        view.SetParameterValue("@instType", InstitutionMasterData.XInstType)
        view.SetParameterValue("@VH_Lnk_No", _VH_Lnk_No)
        view.SetParameterValue("@VH_Dbk_Cd", _VH_Dbk_Cd)
        view.SetParameterValue("@VH_Trn_Typ", _VH_Trn_Typ)
        view.SetParameterValue("@VH_Fin_Yr", InstitutionMasterData.XFinYr)
        crystalviewerVoucher.ReportSource = view
        crystalviewerVoucher.DisplayGroupTree = False
        crystalviewerVoucher.ShowRefreshButton = False
    End Sub

End Class