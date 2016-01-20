Public Class frmInstitutionSelection

    Dim frmMain As frmFAMSMain
    Private _institutionDetails As InstitutionMasterData
    Dim validateClass As ValidateUserClass
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        validateClass = New ValidateUserClass
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(institutionDetails As InstitutionMasterData)
        InitializeComponent()
        ' TODO: Complete member initialization 
        _institutionDetails = institutionDetails
        validateClass = New ValidateUserClass
        GetInstitutionDetails()
        drpInstitutionList.SelectedIndex = 0
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If validateClass.CheckLicenseDate(_institutionDetails.XDate, _institutionDetails.XFAMDate) Then
            Dim mainFormThread As New Threading.Thread(AddressOf StartMDIForm)
            mainFormThread.Start()
            Me.Close()
        Else
            MessageBox.Show(" Financial Accounting Module was not installed/active on this date ")
        End If
    End Sub

    Private Sub StartMDIForm()
        frmMain = New frmFAMSMain(_institutionDetails)
        Application.Run(frmMain)
    End Sub

    Private Sub GetInstitutionDetails()
        Try
            _institutionDetails.GetInstitutionData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmInstitutionSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class