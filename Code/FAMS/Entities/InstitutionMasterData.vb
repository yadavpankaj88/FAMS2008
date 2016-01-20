Public Class InstitutionMasterData


    Public XDate As DateTime
    Public XFinYr As String
    Public XPrevYr As String
    Public XNextYr As String
    Public XYrBeginDate As DateTime
    Public XYrEndDate As DateTime
    Public XUsrId As String
    Public XUsrName As String
    Public XUsrRole As String

    Public XInstCode As String
    Public XInstName As String
    Public XInstAdd As String
    Public XInstTel As String
    Public XInstType As String
    Public XPrincipalName As String
    Public XPrincipalDesignation As String
    Public XInstCloseYear As String
    Public XInstRegNumber As String
    Public XFAMDate As DateTime


    Public Sub GetInstitutionData()
        Dim dt As DataTable
        Try
            Dim dataHelper As New DataHelper
            dataHelper.CreateConnection()
            dt = dataHelper.ExecuteQuery("Select * from Inst_Master", CommandType.Text)
            If (dt.Rows.Count > 0) Then
                Me.XInstCode = dt.Rows(0)("Inst_Cd").ToString
                Me.XInstCloseYear = dt.Rows(0)("Inst_Cls_Yr").ToString
                Me.XInstType = dt.Rows(0)("Inst_Typ").ToString
                Me.XInstName = dt.Rows(0)("Inst_Nm").ToString
                Me.XInstRegNumber = dt.Rows(0)("Inst_80G_Reg_No").ToString
                Me.XPrincipalName = dt.Rows(0)("Inst_Prin_Nm").ToString
                ' Me.XPrincipalDesignation = dt.Rows(0)("Inst_Prin_Dsgn").ToString
                Me.XFAMDate = Convert.ToDateTime(dt.Rows(0)("Inst_FAM_Dt").ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insertdata()
        Try
            Dim dataHelper As New DataHelper
            dataHelper.CreateConnection()

        Catch ex As Exception

        End Try
    End Sub
End Class
