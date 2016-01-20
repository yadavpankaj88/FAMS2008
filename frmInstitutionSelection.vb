Public Class frmInstitutionSelection

    Dim frmMain As frmFAMSMain
    Private _institutionDetails As InstitutionMasterData

    Public ReadOnly Property InstituInformation
        Get
            Return _institutionDetails
        End Get
    End Property

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(institutionDetails As InstitutionMasterData)
        Try
            InitializeComponent()
            ' TODO: Complete member initialization 
            _institutionDetails = institutionDetails

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        _institutionDetails.SetGlobalVariables(DirectCast(drpInstitutionList.SelectedItem, DataRowView))

        If validateClass.CheckLicenseDate(InstitutionMasterData.XDate, _institutionDetails.XFAMDate) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show(" Financial Accounting Module was not installed/active on this date ")
        End If
    End Sub


    Private Sub BindInstitutionDetails()
        Dim dt As New DataTable()
        Try
            dt = _institutionDetails.GetInstitutionData()
            drpInstitutionList.DataSource = dt
            drpInstitutionList.DisplayMember = "Inst_Nm"
            drpInstitutionList.ValueMember = "Inst_Cd"
            ' drpInstitutionList.SelectedIndex = "0"
        Catch sqlEx As SqlClient.SqlException
            MessageBox.Show(" Financial Accounting Module was not installed/active on this date ")
            Me.Close()
        Catch ex As Exception

            Throw
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmInstitutionSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BindInstitutionDetails()

    End Sub
End Class