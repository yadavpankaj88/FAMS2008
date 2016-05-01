Public Class ReportHelper

    Dim Query As String
    Dim dataHelper As DataHelper = New DataHelper()

    Function GetLedgerReportCount(Optional ByVal Fromdate As DateTime = Nothing, Optional ByVal ToDate As DateTime = Nothing, Optional ByVal pIsCashBank As Boolean = True, Optional ByVal pAccountFrom As String = "", Optional ByVal pAccountTo As String = "") As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetGeneralLedgerReportDetails"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.ToString("MM-dd-yyyy"))
            parameters.Add("@ToDate", ToDate.ToString("MM-dd-yyyy"))
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

    Function GetConsolidatedBankBookReportCount(Optional ByVal Fromdate As DateTime = Nothing, Optional ByVal ToDate As DateTime = Nothing) As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetConsolidatedBankReportDetails"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.ToString("MM-dd-yyyy"))
            parameters.Add("@ToDate", ToDate.ToString("MM-dd-yyyy"))
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

    Function GetCashBankBookReportCount(Optional ByVal Fromdate As DateTime = Nothing, Optional ByVal ToDate As DateTime = Nothing, Optional ByVal pDaybookcode As String = "", Optional ByVal pDaybookName As String = "", Optional ByVal ReportType As String = "") As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetCashBankReportDetails"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.ToString("MM-dd-yyyy"))
            parameters.Add("@ToDate", ToDate.ToString("MM-dd-yyyy"))
            parameters.Add("@VH_Dbk_Cd", pDaybookcode)
            parameters.Add("@DayBookName", pDaybookName)
            parameters.Add("@DayBookType", ReportType)
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

    Function GetTrialBalanceReportCount(Optional ByVal Fromdate As DateTime = Nothing, Optional ByVal ToDate As DateTime = Nothing) As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetTrialBalanceReportDetails"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.ToString("MM-dd-yyyy"))
            parameters.Add("@ToDate", ToDate.ToString("MM-dd-yyyy"))
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

    Function GetCashBankContraRegisterReportCount(Optional ByVal Fromdate As DateTime = Nothing, Optional ByVal ToDate As DateTime = Nothing) As Integer
        Dim query As String
        Dim count As Integer = 0
        Dim dtCount As DataTable
        Dim parameters As New Dictionary(Of String, Object)()
        Try
            query = "GetCashBankContraRegister"
            parameters.Add("@instType", InstitutionMasterData.XInstType)
            parameters.Add("@Fromdate", Fromdate.ToString("MM-dd-yyyy"))
            parameters.Add("@ToDate", ToDate.ToString("MM-dd-yyyy"))
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
