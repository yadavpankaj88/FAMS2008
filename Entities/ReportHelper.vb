Public Class ReportHelper

    Dim Query As String
    Dim dataHelper As DataHelper = New DataHelper()

    Function GetLedgerReportCount(Optional ByVal Fromdate? As DateTime = Nothing, Optional ByVal ToDate? As DateTime = Nothing, Optional ByVal pIsCashBank As Boolean = True, Optional ByVal pAccountFrom As String = "", Optional ByVal pAccountTo As String = "") As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetGeneralLedgerReportDetails"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.Value)
            parameters.Add("@ToDate", ToDate.Value)
            parameters.Add("@IsCashBank", pIsCashBank)
            parameters.Add("@AccountFrom", pAccountFrom)
            parameters.Add("@AccountTo", pAccountTo)
            dtCount = dataHelper.ExecuteQuery(query, CommandType.StoredProcedure, parameters)
            If dtCount Is Nothing Then
            Else
                count = dtCount.Rows.Count
            End If
        Catch ex As Exception
            Throw
        End Try
        Return count
    End Function

    Function GetCashBankBookReportCount(Optional ByVal Fromdate? As DateTime = Nothing, Optional ByVal ToDate? As DateTime = Nothing, Optional ByVal pDaybookcode As String = "", Optional ByVal pAccountFrom As String = "", Optional ByVal pAccountTo As String = "") As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetCashBankReportDetails"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.Value)
            parameters.Add("@ToDate", ToDate.Value)
            parameters.Add("@VH_Dbk_Cd", pDaybookcode)
            parameters.Add("@AccountFrom", pAccountFrom)
            parameters.Add("@AccountTo", pAccountTo)
            dtCount = dataHelper.ExecuteQuery(query, CommandType.StoredProcedure, parameters)
            If dtCount Is Nothing Then
            Else
                count = dtCount.Rows.Count
            End If
        Catch ex As Exception
            Throw
        End Try
        Return count
    End Function

    Function GetTrialBalanceReportCount(Optional ByVal Fromdate? As DateTime = Nothing, Optional ByVal ToDate? As DateTime = Nothing) As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetTrialBalanceReportDetails"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.Value)
            parameters.Add("@ToDate", ToDate.Value)
            dtCount = dataHelper.ExecuteQuery(query, CommandType.StoredProcedure, parameters)
            If dtCount Is Nothing Then
            Else
                count = dtCount.Rows.Count
            End If
        Catch ex As Exception
            Throw
        End Try
        Return count
    End Function

End Class
