Imports System.Data.SqlClient
Imports System.Text

Public Class LedgerAccountHelper

    Dim dataHelper As New DataHelper

    Public Function AddLedgerAccount(ByVal account As Accounts) As Boolean

        Dim pCommands As New List(Of SqlCommand)
        Try
            Dim upsertAccountCommand As New SqlCommand
            upsertAccountCommand.CommandType = CommandType.Text
            Dim saveQuery As String
            saveQuery = "if ((select count(*) from " + InstitutionMasterData.XInstType + "_Accounts where AM_Acc_Cd=@AccCode and AM_Inst_Cd=@InstitutionCode and AM_Inst_Typ=@InstType and AM_Fin_Yr=@finYear)=0)" + _
                " Begin " + _
                "INSERT INTO " + InstitutionMasterData.XInstType + "_Accounts ([AM_Fin_Yr] ,[AM_Inst_Cd],[AM_Inst_Typ],[AM_Brn_Cd],[AM_Lgr_Cd],[AM_Acc_Cd],[AM_Acc_Nm],[AM_Opn_Bal],[AM_OB_Cr_Dr],[AM_ABS_Opn_Bal],[AM_LLY_Budg],[AM_LLY_Actu],[AM_LYr_Budg],[AM_LYr_Actu],[AM_Cyr_Budg],[AM_Ent_By],[AM_Ent_Dt])" + _
                " Values(@finYear, @InstitutionCode, @InstType,'01','00', @AccCode, @AccName,@AccOpenBal,@AccOB_CR_DR,@AccABSOpenBal,@AccLLYBud,@AccLLYAct,@AccLYBud,@AccLYAct,@AccCYBud,@createBy,GetDate())" + _
                " end " + _
                " else " + _
                " UPDATE " + InstitutionMasterData.XInstType + "_Accounts" + _
                " SET [AM_Acc_Nm] = @AccName,[AM_Opn_Bal] = @AccOpenBal,[AM_OB_Cr_Dr] = @AccOB_CR_DR ,[AM_ABS_Opn_Bal] = @AccABSOpenBal,[AM_LLY_Budg] = @AccLLYBud,[AM_LLY_Actu] = @AccLLYAct,[AM_LYr_Budg] = @AccLYBud," + _
                "[AM_LYr_Actu] = @AccLYAct,[AM_Cyr_Budg] = @AccCYBud ,[AM_Upd_By]= @updatedBy,[AM_Upd_Dt]=GetDate()" + _
                "where AM_Acc_Cd=@AccCode and AM_Inst_Cd=@InstitutionCode and AM_Inst_Typ=@InstType and AM_Fin_Yr=@finYear"

            Dim parameters As New Dictionary(Of String, Object)()
            parameters.Add("@finYear", InstitutionMasterData.XFinYr)
            parameters.Add("@InstitutionCode", InstitutionMasterData.XInstCode)
            parameters.Add("@InstType", InstitutionMasterData.XInstType)
            parameters.Add("@AccCode", account.AccCode)
            parameters.Add("@AccName", account.AccName)
            parameters.Add("@AccABSOpenBal", account.AccAbsOpenBalance)
            parameters.Add("@AccOB_CR_DR", account.CreditDebit)
            If account.CreditDebit = "CR" Then
                account.AccOpenBalance = account.AccAbsOpenBalance * -1
            Else
                account.AccOpenBalance = account.AccAbsOpenBalance
            End If
            parameters.Add("@AccOpenBal", account.AccOpenBalance)
            parameters.Add("@AccLLYBud", account.AccLLYbudget)
            parameters.Add("@AccLLYAct", account.AccLLYactual)
            parameters.Add("@AccLYBud", account.AccLYbudget)
            parameters.Add("@AccLYAct", account.AccLYactual)
            parameters.Add("@AccCYBud", account.AccCYbudget)
            parameters.Add("@createBy", InstitutionMasterData.XUsrId)
            parameters.Add("@createdOn", DateTime.Now)
            parameters.Add("@updatedBy", InstitutionMasterData.XUsrId)
            parameters.Add("@updatedOn", DateTime.Now)
            dataHelper.ExecuteNonQuery(saveQuery, CommandType.Text, parameters)

        Catch ex As Exception
            Throw
        End Try

        Return True
    End Function

    Function GetAccountDetails(ByVal pAccCode As String, Optional ByVal pNotLinked As Boolean = False) As DataTable

        Dim query As StringBuilder
        Try
            query = New StringBuilder()
            If String.IsNullOrEmpty(pAccCode) Then
                query.Append(String.Format("SELECT [AM_Fin_Yr],[AM_Inst_Cd],[AM_Inst_Typ],[AM_Brn_Cd],[AM_Lgr_Cd],[AM_Acc_Cd],Ltrim(Rtrim([AM_Acc_Nm])) as AM_Acc_Nm, Ltrim(Rtrim([AM_Acc_Nm])) +'_'+[AM_Acc_Cd] as name ,[AM_Calls],[AM_Opn_Bal],[AM_OB_Cr_Dr],[AM_ABS_Opn_Bal],[AM_LLY_Budg],[AM_LLY_Actu],[AM_LYr_Budg],[AM_LYr_Actu],[AM_Cyr_Budg],[AM_Ent_By]" + _
                ",[AM_Ent_Dt],[AM_Upd_By],[AM_Upd_Dt] FROM " + InstitutionMasterData.XInstType + "_Accounts where AM_Inst_Cd='{0}' and AM_Inst_Typ='{1}' and AM_Fin_Yr='{2}'", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            Else
                query.Append(String.Format("SELECT [AM_Fin_Yr],[AM_Inst_Cd],[AM_Inst_Typ],[AM_Brn_Cd],[AM_Lgr_Cd],[AM_Acc_Cd],Ltrim(Rtrim([AM_Acc_Nm])) as AM_Acc_Nm, [AM_Acc_Cd] +'_'+Ltrim(Rtrim([AM_Acc_Nm])) as name,[AM_Calls],[AM_Opn_Bal],[AM_OB_Cr_Dr],[AM_ABS_Opn_Bal],[AM_LLY_Budg],[AM_LLY_Actu],[AM_LYr_Budg],[AM_LYr_Actu],[AM_Cyr_Budg],[AM_Ent_By]" + _
                     ",[AM_Ent_Dt],[AM_Upd_By],[AM_Upd_Dt] FROM " + InstitutionMasterData.XInstType + "_Accounts  where AM_Acc_Cd='{0}' and AM_Inst_Cd='{1}' and AM_Inst_Typ='{2}' and AM_Fin_Yr='{3}'", pAccCode, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            End If

            If pNotLinked Then
                query.Append(" and AM_Calls is null order by [AM_Acc_Nm]")
            Else
                query.Append(" order by [AM_Acc_Cd]")
            End If

            Return dataHelper.ExecuteQuery(query.ToString, CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Function FillAccountCode() As DataTable
        Dim query As StringBuilder
        Dim CrDr As String = "DR"
        Try
            query = New StringBuilder()
            query.Append(String.Format("SELECT [AM_Acc_Cd],Ltrim(Rtrim([AM_Acc_Nm])) as AM_Acc_Nm,[AM_Acc_Cd] +'_'+ Ltrim(Rtrim([AM_Acc_Nm])) as name  FROM " + InstitutionMasterData.XInstType + "_Accounts where AM_Inst_Cd='{0}' and AM_Inst_Typ='{1}' and AM_Fin_Yr='{2}' and AM_OB_Cr_Dr='" + CrDr + "' order by [AM_Acc_Nm] asc", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            Return dataHelper.ExecuteQuery(query.ToString, CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Function FillDaybookCode(ByVal dbkType As String) As DataTable
        Dim query As StringBuilder
        Try
            query = New StringBuilder()
            query.Append(String.Format("SELECT [DM_Dbk_Cd],Ltrim(Rtrim([DM_Dbk_Nm])) as Daybook_Name, [DM_Dbk_Cd]  +' - '+ Ltrim(Rtrim([DM_Dbk_Nm])) as Daybook_Code  FROM " + InstitutionMasterData.XInstType + "_Daybooks where DM_Inst_Cd='{0}' and DM_Inst_Typ='{1}' and DM_Fin_Yr='{2}' and DM_Dbk_Typ='{3}' order by [DM_Dbk_Nm] asc", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr, dbkType))
            Return dataHelper.ExecuteQuery(query.ToString, CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetAccDetails(ByVal AccCode As String) As DataTable
        Dim dtAccDetail As DataTable = Nothing
        Dim str As String
        str = String.Format("select [AM_ABS_Opn_Bal],[AM_LLY_Budg],[AM_LLY_Actu],[AM_LYr_Budg],[AM_LYr_Actu],[AM_Cyr_Budg],[AM_OB_Cr_Dr] FROM " + InstitutionMasterData.XInstType + "_Accounts where AM_Acc_Cd='{0}' ", AccCode)
        Dim dataHelper As DataHelper = New DataHelper()
        dtAccDetail = dataHelper.ExecuteQuery(str, CommandType.Text, Nothing)
        Return dtAccDetail
    End Function

    Function GetTransactionCount(ByVal pAccCode As String, ByVal pDayBookCode As String) As Integer
        Dim query As String
        Dim count As Integer
        Try
            query = String.Format("SELECT count(*) from " + InstitutionMasterData.XInstType + "_Voucher_Header where VH_Fin_Yr='{1}' and VH_Inst_Cd='{2}' and VH_Inst_Typ='{3}'" + _
                                  " and VH_Acc_Cd='{4}' and VH_Dbk_Cd='{5}'", InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, pAccCode, pDayBookCode)

            Int32.TryParse(dataHelper.ExecuteScalar(query, CommandType.Text, Nothing), count)
            Return count
        Catch ex As Exception
            Throw
        End Try

    End Function

    Sub DeleteAccount(ByVal pAccCode As String)
        Try
            dataHelper.ExecuteNonQuery(String.Format("Delete from " + InstitutionMasterData.XInstType + "_Accounts where AM_Acc_Cd='{0}' and AM_Inst_Cd='{1}' and AM_Inst_Typ='{2}' and AM_Fin_Yr={3}", pAccCode, InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr), CommandType.Text)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Function IsAccountLinked(ByVal pAccountCode As String, ByVal pDaybookcode As String) As Boolean
        Dim count As Integer
        Dim query As String = String.Format("Select AM_Acc_Cd,AM_Calls from " + InstitutionMasterData.XInstType + "_Accounts where AM_Inst_Cd='{0}' and AM_Inst_Typ='{1}' " + _
                                            "and AM_Fin_Yr='{2}' and AM_Acc_Cd='{3}'", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr, pAccountCode.Trim)
        Dim dtAccount As DataTable
        Try
            dtAccount = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)
            If dtAccount.Rows.Count > 0 Then
                Dim selectedAccount, selectedDaybook As String

                selectedAccount = dtAccount.Rows(0)("AM_Acc_Cd").ToString
                If dtAccount.Rows(0)("AM_Acc_Cd") IsNot DBNull.Value Then
                    selectedDaybook = String.Empty
                Else
                    selectedDaybook = dtAccount.Rows(0)("AM_Calls").ToString()
                End If

                If String.IsNullOrEmpty(selectedDaybook) Then
                    Return False
                Else
                    Return True
                End If
            End If
            Return count
        Catch ex As Exception
            Throw
        End Try
    End Function

    Function GetBalance(Optional ByVal pDate As DateTime = Nothing, Optional ByVal pDaybookcode As String = "") As Double
        Dim query As String
        Dim dtAcc As DataTable
        Dim dtBalance As DataTable
        Try
            Dim parameters As New Dictionary(Of String, Object)()

            If Not String.IsNullOrEmpty(pDaybookcode) Then
                query = "Select DM_Acc_Cd from  " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Cd='" + pDaybookcode + "'"
                dtAcc = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)
            Else
                query = "Select DM_Acc_Cd from  " + InstitutionMasterData.XInstType + "_Daybooks where DM_Dbk_Typ='C'"
                dtAcc = dataHelper.ExecuteQuery(query, CommandType.Text, Nothing)
            End If

            If dtAcc.Rows.Count > 0 Then
                query = "CalculateBalance"
                parameters.Add("@lgrCode", dtAcc.Rows(0)("DM_Acc_Cd").ToString())

                If pDate <> DateTime.MinValue Then
                    parameters.Add("@vchDate", pDate.Date)
                Else
                    parameters.Add("@vchDate", InstitutionMasterData.XDate.Date.ToString("yyyy-MM-dd"))
                End If
                parameters.Add("@instType", InstitutionMasterData.XInstType)

                dtBalance = dataHelper.ExecuteQuery(query, CommandType.StoredProcedure, parameters)
                If dtBalance.Rows.Count > 0 Then
                    Return Convert.ToDouble(dtBalance.Rows(0)("Total Balance"))
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
        Return 0
    End Function

    Function CheckAccCd(ByVal str As String) As DataTable
        Dim query As StringBuilder
        Dim dt As New DataTable
        Try
            query = New StringBuilder()
            query = New StringBuilder()
            If String.IsNullOrEmpty(str) Then
                query.Append(String.Format("select [AM_Acc_Cd] as AccountCode,[AM_Acc_Nm] as AccountName from " + InstitutionMasterData.XInstType + "_Accounts"))
            Else
                query.Append(String.Format("select [AM_Acc_Cd] as AccountCode,[AM_Acc_Nm] as AccountName from " + InstitutionMasterData.XInstType + "_Accounts where AM_Inst_Cd='{0}' and AM_Inst_Typ='{1}' and AM_Fin_Yr='{2}' and [AM_Acc_Cd] like  '%" & str & "%' ", InstitutionMasterData.XInstCode, InstitutionMasterData.XInstType, InstitutionMasterData.XFinYr))
            End If
            Return dataHelper.ExecuteQuery(query.ToString, CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Function GetCount(ByVal AccountCode As String) As Integer
        Dim query As StringBuilder
        Try
            query = New StringBuilder()
            query.Append(String.Format("select count(*) from " + InstitutionMasterData.XInstType + "_Accounts where AM_Acc_Cd='" + AccountCode + "' and AM_Inst_Cd= '" + InstitutionMasterData.XInstCode + "' and AM_Inst_Typ='" + InstitutionMasterData.XInstType + "' and AM_Fin_Yr='" + InstitutionMasterData.XFinYr + "'"))
            Return dataHelper.ExecuteScalar(query.ToString, CommandType.Text, Nothing)
        Catch ex As Exception
            Throw
        End Try
    End Function


End Class
