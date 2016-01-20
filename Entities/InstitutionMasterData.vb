Public Class InstitutionMasterData


    Public Shared XDate As DateTime
    Public Shared XFinYr As String
    Public XPrevYr As String
    Public XNextYr As String
    Public XYrBeginDate As DateTime
    Public XYrEndDate As DateTime
    Public Shared XUsrId As String
    Public Shared XUsrName As String
    Public Shared XUsrRole As String

    Public Shared XInstCode As String
    Public Shared currDaybookCode As String
    Public Shared XInstName As String
    Public XInstAdd As String
    Public XInstTel As String
    Public Shared XInstType As String
    Public XPrincipalName As String
    Public XPrincipalDesignation As String
    Public XInstCloseYear As String
    Public XInstRegNumber As String
    Public XFAMDate As DateTime
    Public Shared XStartFinYr As DateTime
    Public Shared XEndFinYr As DateTime

    Public Sub UpdateLinkNumber(ByVal linkNo As String, ByVal VCHRefNo As String, ByVal instCode As String)
        Dim query As String = "Update Inst_Master Set Inst_Link_No=@LinkNo,Inst_Vch_Ref_No=@VchRefNo where Inst_Cd=@InstCd"
        Dim helper As DataHelper = New DataHelper()
        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        params.Add("@LinkNo", linkNo)
        params.Add("@VchRefNo", VCHRefNo)
        params.Add("@InstCd", instCode)
        helper.ExecuteNonQuery(query, CommandType.Text, params)
    End Sub

    Public Function GetInstitutionData() As DataTable
        Dim dt As DataTable = New DataTable()
        Try
            Dim dataHelper As New DataHelper
            'dataHelper.CreateConnection()
            dt = dataHelper.ExecuteQuery("Select LTRIM(RTRIM(Inst_Cd)) as 'Inst_Cd',LTRIM(RTRIM(Inst_Cls_Yr)) as 'Inst_Cls_Yr',LTRIM(RTRIM(Inst_Typ)) as 'Inst_Typ',LTRIM(RTRIM(Inst_Nm)) as Inst_Nm,Inst_80G_Reg_No,Inst_Prin_Nm,Inst_Prin_Dsgn,Inst_FAM_Dt from Inst_Master", CommandType.Text)

            'If (dt.Rows.Count > 0) Then
            '    InstitutionMasterData.XInstCode = dt.Rows(0)("Inst_Cd").ToString
            '    Me.XInstCloseYear = dt.Rows(0)("Inst_Cls_Yr").ToString
            '    InstitutionMasterData.XInstType = dt.Rows(0)("Inst_Typ").ToString
            '    InstitutionMasterData.XInstName = dt.Rows(0)("Inst_Nm").ToString
            '    Me.XInstRegNumber = dt.Rows(0)("Inst_80G_Reg_No").ToString
            '    Me.XPrincipalName = dt.Rows(0)("Inst_Prin_Nm").ToString
            '    Me.XPrincipalDesignation = dt.Rows(0)("Inst_Prin_Dsgn").ToString
            '    Me.XFAMDate = Convert.ToDateTime(dt.Rows(0)("Inst_FAM_Dt").ToString)
            'End If
        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function

    Public Sub SetGlobalVariables(ByVal dr As DataRowView)
        InstitutionMasterData.XInstCode = dr("Inst_Cd").ToString
        Me.XInstCloseYear = dr("Inst_Cls_Yr").ToString
        InstitutionMasterData.XInstType = dr("Inst_Typ").ToString
        InstitutionMasterData.XInstName = dr("Inst_Nm").ToString
        Me.XInstRegNumber = dr("Inst_80G_Reg_No").ToString
        Me.XPrincipalName = dr("Inst_Prin_Nm").ToString
        Me.XPrincipalDesignation = dr("Inst_Prin_Dsgn").ToString
        Me.XFAMDate = Convert.ToDateTime(dr("Inst_FAM_Dt").ToString)
    End Sub

    Public Function GetNextInstitutionVoucherReferenceNumber() As Int64
        Dim dt As DataTable = New DataTable()
        Dim vchRefNo As Int64 = 0

        Try
            Dim dataHelper As New DataHelper
            dt = dataHelper.ExecuteQuery("Select LTRIM(RTRIM(Inst_Vch_Ref_No)) AS [Inst_Vch_Ref_No] from Inst_Master where Inst_Cd='" + InstitutionMasterData.XInstCode + "'", CommandType.Text)
            If (dt.Rows.Count > 0) Then

                If dt.Rows(0)("Inst_Vch_Ref_No") IsNot DBNull.Value Then
                    Int64.TryParse(dt.Rows(0)("Inst_Vch_Ref_No").ToString(), vchRefNo)
                    vchRefNo = vchRefNo + 1
                Else
                    vchRefNo = 1
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return vchRefNo
    End Function


    Public Function GetNextInstitutionLinkNumber() As Int64
        Dim dt As DataTable = New DataTable()
        Dim linkNo As Int64 = 0

        Try
            Dim dataHelper As New DataHelper
            dt = dataHelper.ExecuteQuery("Select LTRIM(RTRIM(Inst_Link_No)) AS [Inst_Link_No] from Inst_Master where Inst_Cd='" + InstitutionMasterData.XInstCode + "'", CommandType.Text)
            If (dt.Rows.Count > 0) Then
                Int64.TryParse(dt.Rows(0)("Inst_Link_No").ToString(), linkNo)
                linkNo = linkNo + 1
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return linkNo
    End Function

End Class
