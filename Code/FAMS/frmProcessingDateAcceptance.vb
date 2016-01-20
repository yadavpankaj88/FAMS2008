
Public Class frmProcessingDateAcceptance
    Dim objInstituionMaster As frmInstitutionSelection
    Dim institutionDetails As InstitutionMasterData
    Dim validateUser As ValidateUserClass

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        validateUser = New ValidateUserClass()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        If (validateUser.CheckProcessingDate(dtpProcessingDate.Value)) Then
            institutionDetails = New InstitutionMasterData()
            institutionDetails.XDate = dtpProcessingDate.Value
            institutionDetails.XFinYr = validateUser.CheckFinancialYear(dtpProcessingDate.Value)
            validateUser.GetNextandPrevFinancialYear(institutionDetails)
            Dim mainFormThread As New Threading.Thread(AddressOf OpenInstitutionSelection)
            mainFormThread.Start()
            Me.Close()
        Else
            MessageBox.Show("Date cannot be greater than todays date")
        End If
    End Sub

    Private Sub OpenInstitutionSelection()
        objInstituionMaster = New frmInstitutionSelection(institutionDetails)
        Application.Run(objInstituionMaster)
    End Sub

End Class
