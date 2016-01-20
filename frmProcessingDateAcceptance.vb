
Public Class frmProcessingDateAcceptance
    Dim objInstituionMaster As frmInstitutionSelection
    Dim institutionDetails As InstitutionMasterData

    Public ReadOnly Property InstituInformation
        Get
            Return institutionDetails
        End Get
    End Property

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        If (ValidateClass.CheckProcessingDate(dtpProcessingDate.Value)) Then
            institutionDetails = New InstitutionMasterData()
            InstitutionMasterData.XDate = dtpProcessingDate.Value
            InstitutionMasterData.XFinYr = ValidateClass.CheckFinancialYear(dtpProcessingDate.Value)
            ValidateClass.SetFinancialYear(institutionDetails)
            ValidateClass.GetNextandPrevFinancialYear(institutionDetails)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Date cannot be greater than todays date")
        End If
    End Sub
    

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class